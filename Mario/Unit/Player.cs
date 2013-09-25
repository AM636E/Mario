using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mario
{
    enum MotionState
    {
        MovingLeft,
        MovingRight,
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

        public Player(string bitmap, int life):
            base(bitmap, life )
        {
            Logger.Clear();
            movers.Add(Mario.MotionState.MovingLeft, this.MoveLeft);
            movers.Add(Mario.MotionState.MovingRight, this.MoveRight);
            movers.Add(Mario.MotionState.JumpLeft, this.JumpLeft);
            movers.Add(Mario.MotionState.Jump, this.Jump);
        }

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
            s.Life -= _POWER;       
        }

        public void Jump()
        {
            Logger.Log("Jump");
        }

        public void JumpLeft()
        {
            Logger.Log("JumpLeft");
        }
    }
}
