using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mario
{
    public enum MotionState
    {
        Moving,
        MovingLeft,
        MovingRight,
        MovingUp,
        MovingDown,
        Jump,
        JumpLeft,
        JumpRight,
        DoubleJump,
        NotMoving,
    }

    public class Player : MovableUnit, IPlayer
    {
        private const int _POWER = 20;
        private int _maxJumpHeight;
        private int _startY;
        private bool _isOnGround = false;

        public event EventHandler Jumping;
        public event EventHandler JumpingLeft;
        public event EventHandler MoveDownEvent;
        public event EventHandler MoveUpEvent;


        public bool OnGround { get { return _isOnGround; } set { _isOnGround = value; } }
        public int Score { get; set; }

        public Player(string bitmap, int life) :
            base(bitmap, life)
        {
            console.Clear();
            movers.Add(Mario.MotionState.MovingLeft, this.MoveLeft);
            movers.Add(Mario.MotionState.MovingRight, this.MoveRight);
            movers.Add(Mario.MotionState.MovingUp, this.MoveUp);
            movers.Add(Mario.MotionState.MovingDown, this.MoveDown);
            movers.Add(Mario.MotionState.Jump, this.Jump);
        }

        public Player(string bitmap, int life, System.Drawing.Point p)
            : this(bitmap, life)
        {
            this.position = p;
            _maxJumpHeight = this.Y - MaxJumpHeight;
            _startY = Y;
        }

        public Player(String bitmap, int life, int x, int y)
            : this(bitmap, life, new System.Drawing.Point(x, y))
        { }

        public void FireMoveUpEvent()
        {
            if(MoveUpEvent != null)
            {
                MoveUpEvent(this, EventArgs.Empty);
            }
        }

        public void FireMoveDownEvent()
        {
            if(MoveDownEvent != null)
            {
                MoveDownEvent(this, EventArgs.Empty);
            }
        }

        public void FireJumpEvent()
        {
            if (Jumping != null)
            {
                _plusY *= 1;
                Jumping(this, EventArgs.Empty);
            }
        }

        public void FireJumpLeftEvent()
        {
            if (JumpingLeft != null)
            {
                JumpingLeft(this, EventArgs.Empty);
            }
        }

        public void Kick(Unit s)
        {
            s.Life -= _POWER;
        }

        public const int MaxJumpHeight = 200;
        private int _plusY = -100;

        public void MoveUp()
        {
            if (CollisionPrizes != CollisionType.UP)
            {
                this.Y -= 101;
            }
        }

        public void MoveDown()
        {
            if (CollisionGround == CollisionType.NONE && CollisionPrizes == CollisionType.NONE)
            {
                this.Y += 100;
            }
        }

        public override void MoveRight()
        {
            base.MoveRight();
        }

        public override void MoveLeft()
        {
            base.MoveLeft();
        }

        public void MoveDown(Sprite ground)
        {
            if(this.IsSpriteBottom(ground) == false)
            {
                MoveDown();
            }
        }

        public void Jump()
        {
            MoveUp();
        }

        public void JumpLeft()
        {
              
        }

        public override CollisionType CheckCollision(IList units)
        {
            foreach (Unit u in units)
            {
                if (this.IsSpriteOnLeft(u))
                {
                    u.ColliseLeft(this);
                    return CollisionType.LEFT;
                }
                if (this.IsSpriteOnRight(u))
                {
                    u.ColliseRight(this);
                    return CollisionType.RIGHT;
                }
                if (this.IsSpriteUp(u))
                {
                    u.ColliseUp(this);
                    return CollisionType.UP;
                }
                if (this.IsSpriteBottom(u))
                {
                    u.ColliseBottom(this);
                    return CollisionType.BOTTOM;
                }                
            }

            return CollisionType.NONE;
        }

        public override void ColliseLeft(Player p) { }
        public override void ColliseRight(Player p) { }
        public override void ColliseUp(Player p) { }
        public override void ColliseBottom(Player p) { }
    }
}