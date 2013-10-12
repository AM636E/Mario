﻿using System;
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

        public event EventHandler Deading;
        public event EventHandler Jumping;
        public event EventHandler JumpingLeft;

        public bool OnGround { get { return _isOnGround; } set { _isOnGround = value; } }
        public int Score { get; set; }

        public Player(string bitmap, int life) :
            base(bitmap, life)
        {
            console.Clear();
            movers.Add(Mario.MotionState.MovingLeft, this.FireMoveLeftEvent);
            movers.Add(Mario.MotionState.MovingRight, this.FireMoveRightEvent);
            movers.Add(Mario.MotionState.Jump, this.FireJumpEvent);
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

        public override void Dead()
        {
            if (Deading != null)
            {
                Deading(this, EventArgs.Empty);
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
            this.Y -= 100;
        }

        public void MoveDown()
        {
            this.Y += 100;
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            base.Draw(g);
        }

        public void JumpLeft()
        {
            console.log("JumpLeft");
        }

        public CollisionType CheckCollision(IList units)
        {
            foreach (Unit u in units)
            {
                if (this.IsSpriteOnLeft(u))
                {
                    console.log("Left ", u.ToString());
                    u.ColliseLeft(this);
                    return CollisionType.LEFT;
                }
                if (this.IsSpriteOnRight(u))
                {
                    console.log("Right ", u.ToString());
                    u.ColliseRight(this); return CollisionType.RIGHT;
                }
                if (this.IsSpriteUp(u))
                {
                    console.log(u.ToString());
                    u.ColliseUp(this);
                    return CollisionType.UP;
                }
                if (this.IsSpriteBottom(u))
                {
                    console.log(u.ToString());
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
