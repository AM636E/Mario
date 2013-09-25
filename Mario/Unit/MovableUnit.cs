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

        private bool _canMoveLeft;
        private bool _canMoveRight;

        public bool CanMoveLeft { get { return _canMoveLeft; } set { _canMoveLeft = value; } }
        public bool CanMoveRight { get { return _canMoveRight; } set { _canMoveRight = value; } }

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


        /*
         * Movers fires an event.
         * Event handler checks if Unit can move
         * and modifies needed property ( Move[MoveDiretion] )
         */
        public void MoveLeft()
        {
            if (MovedLeft != null)
            {
                MovedLeft(this, EventArgs.Empty);
            }

            if (_canMoveLeft == true)
            {
                this.X += STEP;
            }
        }

        public void MoveRight()
        {
            if (MovedRight != null)
            {
                MovedRight(this, EventArgs.Empty);
            }

            if (_canMoveRight == true)
            {
                this.X -= STEP;
            }
        }
        /*-------------------------------------------*/

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
