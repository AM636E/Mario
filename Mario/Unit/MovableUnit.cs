using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    public abstract class MovableUnit : Unit, IMovable
    {
        protected Dictionary<MotionState, Mover> movers = new Dictionary<MotionState, Mover>();
        protected MotionState _motionState = MotionState.NotMoving;
        public MotionState MotionState { get { return _motionState; } set { _motionState = value; } }

        public const int STEP = 20;//number of pixels unit that unit step have   

        public delegate bool Mover();

        public MovableUnit()
            : base()
        { }

        public MovableUnit(string bitmapPath) :
            base(bitmapPath)
        {
            movers.Add(Mario.MotionState.NotMoving, delegate() { return false; });
        }

        public MovableUnit(string bitmapPath, int life)
            : this(bitmapPath)
        { this.life = life; }

        public MovableUnit(string bitmapPath, int life, System.Drawing.Point p)
            : base(bitmapPath, life)
        { this.position = p; }

        public virtual bool MoveLeft()
        {
            if (this.CollisionPrizes != CollisionType.LEFT && this.CollisionEnemies != CollisionType.LEFT)
            {
                this.X -= STEP;

                return true;
            }

            return false;
        }

        public virtual bool MoveRight()
        {
            if (this.CollisionPrizes != CollisionType.RIGHT && this.CollisionEnemies != CollisionType.RIGHT)
            {
                this.X += STEP;
                return true;
            }

            return false;
        }

        public override void Dead()
        {
            console.log("player is dead");
        }

        public void Move()
        {
            try
            {
                console.log(this, " moves ", _motionState);
                this.movers[_motionState]();
            }
            catch
            {
                this.MotionState = MotionState.NotMoving;
            }
        }
    }
}
