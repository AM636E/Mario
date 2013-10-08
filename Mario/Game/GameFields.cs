using System;
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

        private Form _canvas;
        private Graphics _graphics;
        private int _canvasWidth;
        private int _canvasHeight;

        private CollisionType _collisionPrizes = CollisionType.NONE;
        private CollisionType _collisionEnemies = CollisionType.NONE;

        private BitMapSprite _ground;
        
        private Timer _gameLoop;

        private List<Prize> _prizes;
        private List<Enemy> _enemyes;
        private List<Unit> _mustUpdate;
        private Dictionary<CollisionType, CollisionAction> _collisionActions;

        
        public List<Unit> NeedUpdate { get { return _mustUpdate; } }
    }
}
