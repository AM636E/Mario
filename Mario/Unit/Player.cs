﻿using System;
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
        public event EventHandler JumpingLeft;

        private const int _POWER = 20;
        private int _maxJumpHeight;
        private int _startY;

        public int Score { get; set; }

        public Player(string bitmap, int life) :
            base(bitmap, life)
        {
            Logger.Clear();
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
            if(Jumping != null)
            {
                _plusY *= 1;
                Jumping(this, EventArgs.Empty);
            }
        }

        public void FireJumpLeftEvent()
        {
            if(JumpingLeft != null)
            {
                JumpingLeft(this, EventArgs.Empty);
            }
        }

        public CollisionType CheckCollision(IList units)
        {
            foreach (Unit u in units)
            {
                if (this.IsCollisedLeft(u))
                {
                    u.ColliseLeft(this); MessageBox.Show("a");
                    return CollisionType.LEFT;
                }
                if (this.IsCollisedRight(u))
                {
                    MessageBox.Show("a");
                    u.ColliseRight(this); return CollisionType.RIGHT;
                }
                if (this.IsCollisedUp(u))
                {
                    u.ColliseUp(this); MessageBox.Show("a");
                    return CollisionType.UP;
                }
                if (this.IsCollisedBottom(u))
                {
                    u.ColliseBottom(this); MessageBox.Show("a");
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

        public const int MaxJumpHeight = 200;
        private int _plusY = -100;
        bool isUp = true;
        public void Jump()
        {
            this.Y += _plusY;
            
            if(this.Y > _maxJumpHeight)
            {
                _plusY *= -1;
            }
            
            if(this.Y == _startY )
            {
                _motionState = Mario.MotionState.NotMoving;
            }
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            base.Draw(g);

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
