using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    public abstract class MovableUnit: Unit, IMovable
    {
        public event EventHandler MovedLeft;
        public event EventHandler MovedRight;

        public MovableUnit(string bitmapPath, int life)
            :base(bitmapPath)
        {
            this.life = life;
        }

        public MovableUnit(string bitmapPath, int life, System.Drawing.Point p)
            :base(bitmapPath, life, p )
        { }

        public void MoveLeft()
        {
            this.X += STEP;

            if (MovedLeft != null)
            {
                MovedLeft(this, EventArgs.Empty);
            }
        }

        public void MoveRight()
        {
            this.X -= STEP;

            if (MovedRight != null)
            {
                MovedRight(this, EventArgs.Empty);
            }
        }
    }
}
