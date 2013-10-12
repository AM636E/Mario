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

        public event EventHandler MovedLeft;
        public event EventHandler MovedRight;       

        public delegate void Mover();

        public MovableUnit()
            : base()
        { }

        public MovableUnit(string bitmapPath) :
            base(bitmapPath)
        {
            movers.Add(Mario.MotionState.NotMoving, delegate() { });
        }

        public MovableUnit(string bitmapPath, int life)
            : this(bitmapPath)
        { this.life = life; }

        public MovableUnit(string bitmapPath, int life, System.Drawing.Point p)
            : base(bitmapPath, life)
        { this.position = p; }

        /*
         * Move Event Just fires an event 
         * Event handler must check if unit can move on
         * and move or not move unit                   
         */                                            
        public void FireMoveLeftEvent()                
        {                                              
            if (MovedLeft != null)                     
            {                                          
                MovedLeft(this, EventArgs.Empty);
            }
        }

        public void FireMoveRightEvent()
        {
            if (MovedRight != null)
            {
                MovedRight(this, EventArgs.Empty);
            }
        }
        /*-------------------------------------------*/

        public void MoveLeft()
        {
            this.X -= STEP;
        }

        public void MoveRight()
        {
            this.X += STEP;
        }

        public override void Dead()
        { }

        public void Move()
        {
            this.movers[_motionState]();            
        }
    }
}
