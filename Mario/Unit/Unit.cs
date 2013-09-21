using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    public abstract class Unit: BitMapSprite
    {
        protected const int STEP = 20;//number of pixels unit that unit step have

        protected int life;

        public int Life { get { return life; } set { life = value; } }

        public Unit()
            :base()
        {
        }

        public Unit(string bitmapPath) :
            base(bitmapPath)
        { }

        public Unit(string bitmapPath, int life)
            :this(bitmapPath)
        {
            this.life = life;
        }

        public Unit(string bitmapPath, int life, System.Drawing.Point p)
            : base(p, bitmapPath)
        {
            this.life = life;
        }

        public bool IsDeading()
        {
            return life <= 0;
        }

        public abstract void Dead();
    }
}