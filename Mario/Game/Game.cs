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
            console.Clear();

            _mustUpdate = new List<Unit>();
            _prizes = new List<Prize>();
            _enemyes = new List<Enemy>();

            Point p = new Point(600, 300);

            _prizes.Add(new Box(@"Images/prize.png", 100, p));
            _enemyes.Add(new Enemy(@"Images/enemy.png", 100, new Point(150, 350)));

            _mustUpdate.Add(_prizes[0]);
            _mustUpdate.Add(_enemyes[0]);

            _prizes[0].Deading += (o, e) =>
                {
                    console.log((o as Prize).ToString(), " Dead");
                };

            _canvas.KeyDown += this.OnKeyDown;
            _canvas.KeyUp += this.OnKeyUp;
            AddHandlers(_prizes, this.OnUnitNeedUpdate);
            AddHandlers(_enemyes, this.OnUnitNeedUpdate);
        }

        public Game(Form canvas, int width, int height)
            : this(canvas)
        {
            _canvas.Width = _canvasWidth = width;
            _canvas.Height = _canvasHeight = height;
            CreateGraphics();

            _player = new Player(@"Images/Mario.jpg", 100, new Point(0, height - 200));

            _jump = new Jumper(_player.MoveUp);
            _ground = new BitMapSprite(@"Images/ground.png", new Point(0, height - 100), width, 100);
        }

        public Game(Form canvas, Player player, int width, int height)
            : this(canvas, width, height)
        {
            _player = player;
            
        }

        public void Start()
        {
            _gameLoop.Tick += new EventHandler(_gameLoop_Tick);
            _gameLoop.Start();

            _player.MoveDownEvent += _player_MoveDownEvent;
            _player.Deading += (sender, e) => { MessageBox.Show("Aaa!  };"); };
            _player.MoveUpEvent += _player_MoveUpEvent;
            _player.Jumping += _player_Jumping;

            _player.JumpingLeft += _player_JumpingLeft;
        }

        void _player_JumpingLeft(object sender, EventArgs e)
        {

        }

        public delegate Enemy MapFunction(Enemy x);

        public List<Enemy> Map(List<Enemy> target, MapFunction func )
        {
            List<Enemy> newlist = new List<Enemy>(target.Count);
            
            for(var i = 0; i < target.Count; i ++)
            {
                newlist[i] = func(target[i]);
            }

            return newlist;
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

        public void UpdateView(Graphics g)
        {
            _player.Draw(g);
            _ground.FillRectangle(g);
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