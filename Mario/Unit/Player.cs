using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    enum PlayerMotionState
    {
        MovingLeft,
        MovindRight,
        Jump,
        JumpLeft,
        JumpRight,
        DoubleJump,
        NotMoving,
    }

    class Player: MovableUnit, IPlayer
    {
        public event EventHandler OnDead;

        private const int _POWER = 20;

        private PlayerMotionState _motionState = PlayerMotionState.NotMoving;

        public PlayerMotionState MotionState { get { return _motionState; } set { _motionState = value; } }

        public Player(string bitmap, int life):
            base(bitmap, life )
        { }

        public Player(string bitmap, int life, System.Drawing.Point p)
            :this(bitmap, life )
        {
            this.position = p;
        }

        public Player(String bitmap, int life, int x, int y)
            :this( bitmap, life, new System.Drawing.Point(x, y ) )
        { }

        public override void Dead()
        {
            OnDead(this, EventArgs.Empty);
        }       

        public void Kick(Unit s)
        {
            s.Life = _POWER;       
        }

        public void Jump()
        {
            
        }
    }
}
