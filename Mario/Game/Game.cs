﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Mario
{
    partial class Game
    {
        private Player _player;

        private Timer _gameLoop;

        List<Prize> _prizes;
        List<Enemy> _enemyes;

        List<Unit> _mustUpdate;

        private Form _canvas;
        private Graphics _graphics;
        private int _canvasWidth;
        private int _canvasHeight;

        public Graphics Graphics { get { return _graphics; } set { _graphics = value; } }
        public int GameLoopInterval
        {
            get
            {
                return _gameLoop.Interval;
            }
            set
            {
                _gameLoop.Interval = value;
            }
        }

        public Game(string pathToXml)
        { }

        public Game(Form canvas)
        {
            _canvas = canvas;
            CreateGraphics();
            _gameLoop = new Timer();
            Logger.Clear();

            _mustUpdate = new List<Unit>();
            _prizes = new List<Prize>();
            _enemyes = new List<Enemy>();

            Point p = new Point(500, 00);

            _prizes.Add(new Box(@"D:\GitHub\HTML_CSS_JAVASCRIPT\task3\memory_puzzle\images\2.jpg", 100, p));

            _mustUpdate.Add(_prizes[0]);

            _canvas.KeyDown += this.OnKeyDown;
            _canvas.KeyUp += this.OnKeyUp;

            AddHandlers(_prizes, this.OnUnitNeedUpdate);
            AddHandlers(_enemyes, this.OnUnitNeedUpdate);
        }

        public Game(Form canvas, int width, int height)
            :this( canvas )
        {
            _canvas.Width = _canvasWidth = width;
            _canvas.Height = _canvasHeight = height;
            CreateGraphics();

        }

        public Game(Form canvas, Player player,  int width, int height)
            : this(canvas, width, height)
        {
            _player = player;
        }        

        public void Start()
        {
            _gameLoop.Tick += new EventHandler(_gameLoop_Tick);
            _gameLoop.Start();

            _player.MovedLeft += new EventHandler(_player_MovedLeft);
            _player.MovedRight += new EventHandler(_player_MovedRight);
        }
        
        public void CreateGraphics()
        {
            _graphics = _canvas.CreateGraphics();
        }

        private void AddHandlers(IList items, EventHandler handler)
        {
            foreach (Unit u in items)
            {
                u.OnNeedUpdate += handler;
            }
        }

        public List<Unit> NeedUpdate { get { return _mustUpdate; } }

        public void UpdateView(Graphics g)
        {
            _player.Draw(g);

            foreach (Unit toUpdate in _mustUpdate)
            {
                toUpdate.Draw(g);
            }
        }

        public void UpdateView()
        {
            UpdateView(_graphics);
        }
    }
}
