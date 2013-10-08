using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mario
{
    public enum MotionState
    {
        MovingLeft,
        MovingRight,
        Jump,
        JumpLeft,
        JumpRight,
        DoubleJump,
        NotMoving,
    }

    public class Player: MovableUnit, IPlayer
    {
        public event EventHandler OnDead;

        private const int _POWER = 20;

        public int Score { get; set; }

        public Player(string bitmap, int life):
            base(bitmap, life )
        {
            Logger.Clear();
            movers.Add(Mario.MotionState.MovingLeft, this.FireMoveLeftEvent);
            movers.Add(Mario.MotionState.MovingRight, this.FireMoveRightEvent);
        }

        public Player(string bitmap, int life, System.Drawing.Point p)
            :this(bitmap, life )
        {
            this.position = p;
        }

        public Player(String bitmap, int life, int x, int y)
            :this( bitmap, life, new System.Drawing.Point(x, y ) )
        { }

        public CollisionType CheckCollision(IList units)
        {
            foreach (Unit u in units)
            {
                if (this.IsCollisedLeft(u))
                {
                    if (OnDead != null)
                    {
                        OnDead(this, EventArgs.Empty);
                    }
                    return CollisionType.LEFT;
                }
                if (this.IsCollisedRight(u))
                {
                    if (OnDead != null)
                    {
                        OnDead(this, EventArgs.Empty);
                    }
                    return CollisionType.RIGHT;
                }
                if (this.IsCollisedUp(u))
                {
                    u.Dead();
                    return CollisionType.UP;
                }
                if (this.IsCollisedBottom(u))
                {
                    return CollisionType.BOTTOM;
                }
            }
            return CollisionType.NONE;
        }

        public override void Dead()
        {
            MessageBox.Show("test");
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
