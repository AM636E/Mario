using System;
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
            Logger.Clear();

            _mustUpdate = new List<Unit>();
            _prizes = new List<Prize>();
            _enemyes = new List<Enemy>();

            Point p = new Point(500, 00);

            _prizes.Add(new Box(@"Images\prize.png", 100, p));

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

            _player = new Player(@"Images/Mario.jpg", 100, new Point(0, height - 200));

            _ground = new BitMapSprite(@"Images/ground.png", new Point(0, height - 100), width, 100);
        }

        public Game(Form canvas, Player player,  int width, int height)
            : this(canvas, width, height)
        {
            _player = player;
            _player.OnDead += (sender, e) => { MessageBox.Show("Aaa!"); };
        }        

        public void Start()
        {
            _gameLoop.Tick += new EventHandler(_gameLoop_Tick);
            _gameLoop.Start();

            _player.MovedLeft += new EventHandler(_player_MovedLeft);
            _player.MovedRight += new EventHandler(_player_MovedRight);
            _player.Jumping += _player_Jumping;
            _player.JumpingLeft += _player_JumpingLeft;
        }

        void _player_JumpingLeft(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void _player_Jumping(object sender, EventArgs e)
        {
           
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

            _mustUpdate.Clear();
        }

        public void UpdateView()
        {
            UpdateView(_graphics);
        }
    }
}
