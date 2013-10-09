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

    public class Player : MovableUnit, IPlayer
    {
        public event EventHandler OnDead;
        public event EventHandler Jumping;

        private const int _POWER = 20;

        public int Score { get; set; }

        public Player(string bitmap, int life) :
            base(bitmap, life)
        {
            Logger.Clear();
            movers.Add(Mario.MotionState.MovingLeft, this.FireMoveLeftEvent);
            movers.Add(Mario.MotionState.MovingRight, this.FireMoveRightEvent);
            movers.Add(Mario.MotionState.Jump, this.Fi)
        }

        public Player(string bitmap, int life, System.Drawing.Point p)
            : this(bitmap, life)
        {
            this.position = p;
        }

        public Player(String bitmap, int life, int x, int y)
            : this(bitmap, life, new System.Drawing.Point(x, y))
        { }

        public void FireJumpEvent()
        {
            if(Jumping != null)
            {
                Jumping(this, EventArgs.Empty);
            }
        }

        public CollisionType CheckCollision(IList units)
        {
            foreach (Unit u in units)
            {
                if (this.IsCollisedLeft(u))
                {
                    u.ColliseLeft(this);
                    return CollisionType.LEFT;
                }
                if (this.IsCollisedRight(u))
                {
                    u.ColliseRight(this); return CollisionType.RIGHT;
                }
                if (this.IsCollisedUp(u))
                {
                    u.ColliseUp(this);
                    return CollisionType.UP;
                }
                if (this.IsCollisedBottom(u))
                {
                    u.ColliseBottom(this);
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

        public override void ColliseLeft(Player p) { }
        public override void ColliseRight(Player p) { }
        public override void ColliseUp(Player p) { }
        public override void ColliseBottom(Player p) { }
    }
}
