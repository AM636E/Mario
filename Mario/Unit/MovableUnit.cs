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

        public delegate void Mover();

        public MovableUnit()
            : base ()
        {}

        public MovableUnit(string bitmapPath) :
            base(bitmapPath)
        {
            movers.Add(Mario.MotionState.NotMoving, delegate() { });
        }

        public MovableUnit(string bitmapPath, int life)
            :this(bitmapPath)
        { this.life = life; }

        public MovableUnit(string bitmapPath, int life, System.Drawing.Point p)
            : base(bitmapPath, life)
        { this.position = p; }

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

        public void Move()
        {
            this.movers[_motionState]();
        }

        protected Dictionary<MotionState, Mover> movers = new Dictionary<MotionState,Mover>();

        protected MotionState _motionState = MotionState.NotMoving;

        public MotionState MotionState { get { return _motionState; } set { _motionState = value; } }
    }
}
