using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    class Enemy: MovableUnit
    {
        public Enemy()
            : base()
        { }

        public Enemy(string bitmapPath) :
            base(bitmapPath)
        {
            movers.Add(Mario.MotionState.NotMoving, delegate() { });
        }

        public Enemy(string bitmapPath, int life)
            : this(bitmapPath)
        { this.life = life; }

        public Enemy(string bitmapPath, int life, System.Drawing.Point p)
            : base(bitmapPath, life)
        { this.position = p; }

    }
}