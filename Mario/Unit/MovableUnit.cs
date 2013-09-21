using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    class MovableUnit: Unit, IMovable
    {
        public event EventHandler MovedLeft;
        public event EventHandler MovedRight;

        public MovableUnit()
            : base ()
        {}

        public MovableUnit(string bitmapPath) :
            base(bitmapPath)
        { }

        public MovableUnit(string bitmapPath, int life)
            :base(bitmapPath, life)
        {  }

        public MovableUnit(string bitmapPath, int life, System.Drawing.Point p)
            : base(bitmapPath, life, p)
        { }

        public void MoveLeft()
        {
            Logger.Log("Movable Unit Width: " + this.Width.ToString());
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

        public override void Dead()
        {
        }
    }
}
