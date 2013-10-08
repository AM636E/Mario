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

        Dictionary<Point, Box> _prizes;

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
                _gameLoop.Stop();
                _gameLoop.Interval = value;
                _gameLoop.Start();
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
            _prizes = new Dictionary<Point, Box>();

            Point p = new Point(500, 00);

            _mustUpdate.Add(_prizes[p]);
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

        private void _player_MovedLeft(object sender, EventArgs e)
        {
            Point p = _player.UpRight;
        }

        private void _player_MovedRight(object sender, EventArgs e)
        {
        }

        private void _gameLoop_Tick(object sender, EventArgs e)
        {
         
        }

        public void CreateGraphics()
        {
            _graphics = _canvas.CreateGraphics();
        }

        private void OnUnitNeedUpdate(object sender, EventArgs e)
        {
            _mustUpdate.Add(sender as Unit);
        }

        private void AddHandlers(Dictionary<Point, Box> items)
        {
            foreach (Unit u in items.Values)
            {
                u.NeedUpdateTrue += OnUnitNeedUpdate;
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
