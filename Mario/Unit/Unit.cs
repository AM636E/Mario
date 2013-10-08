using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    public abstract class Unit: BitMapSprite, Mario.Interface.ICollisable
    {

        protected int life;

        public int Life { get { return life; } set { life = value; } }

        public Unit()
            :base()
        { }

        public Unit(System.Drawing.Bitmap bitmap, System.Drawing.Point p)
            : base(bitmap, p)
        { }

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

        public virtual void ColliseLeft(Player p) { Dead(); }
        public virtual void ColliseRight(Player p) { Dead(); }
        public virtual void ColliseUp(Player p) { Dead(); }
        public virtual void ColliseBottom(Player p) { Dead(); }

    }
}