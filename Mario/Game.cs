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
        public int GameLoopInterval { get { return _gameLoop.Interval; } set { _gameLoop.Interval = value; } }

        public Game(string pathToXml)
        {
        }

        public Game(Form canvas)
        {
            _canvas = canvas;
          // _graphics = _canvas.CreateGraphics();
            CretateGraphics();
            _gameLoop = new Timer();
        }

        public Game(Form canvas, int width, int height)
            :this( canvas )
        {
            _canvas.Width = _canvasWidth = width;
            _canvas.Height = _canvasHeight = height;
            CretateGraphics();

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
            if (_player.UpRightX >= _canvasWidth)
            {
                _stopMove = true;                   
            }
        }

        private void _player_MovedRight(object sender, EventArgs e)
        {
        }

        private void _gameLoop_Tick(object sender, EventArgs e)
        {
            if (!_stopMove)
            {
                _player.MoveLeft();
                _player.Draw(_graphics);
            }
        }

        public void CretateGraphics()
        {
            _graphics = _canvas.CreateGraphics();
        }

        /*DBG*/
        bool _stopMove;
        /*-------------*/
    }
}
