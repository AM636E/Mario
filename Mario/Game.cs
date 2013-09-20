using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Mario
{
    class Game
    {
        private Player _player;

        private Timer _gameLoop;

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
                _gameLoop.Stop();
                _gameLoop.Interval = value;
                _gameLoop.Start();
            }
        }

        public Game(string pathToXml)
        {
        }

        public Game(Form canvas)
        {
            _canvas = canvas;
            CreateGraphics();
            _gameLoop = new Timer();
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
            _stopMove = false;
            _gameLoop.Tick += new EventHandler(_gameLoop_Tick);
            _gameLoop.Start();

            _player.MovedLeft += new EventHandler(_player_MovedLeft);
            _player.MovedRight += new EventHandler(_player_MovedRight);
        }

        private void _player_MovedLeft(object sender, EventArgs e)
        {
            if (_player.UpRightX -500 >= _canvasWidth)
            {
                MessageBox.Show(_player.UpRightX.ToString());
                _stopMove = true;              
            }
        }

        private void _player_MovedRight(object sender, EventArgs e)
        {
        }

        private void _gameLoop_Tick(object sender, EventArgs e)
        {
            if (_stopMove != true)
            {
                _player.MoveLeft();
                _canvas.Invalidate();
            }
        }

        public void CreateGraphics()
        {
            _graphics = _canvas.CreateGraphics();
        }

        public void UpdateView(Graphics g)
        {
            _player.Draw(g);
        }

        public void UpdateView()
        {
            _player.Draw(_graphics);
        }

        /*DBG*/
        bool _stopMove;
        /*-------------*/
    }
}
