using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mario.Interface;
namespace Mario
{
    class Enemy: MovableUnit
    {
        public Enemy()
            : base()
        { }

        public Enemy(string bitmapPath) :
            base(bitmapPath)
        { }

        public Enemy(string bitmapPath, int life)
            : this(bitmapPath)
        {
            this.life = life;
            _motionState = MotionState.MovingRight;
        }

        public Enemy(string bitmapPath, int life, System.Drawing.Point p)
            : base(bitmapPath, life)
        {
            this.position = p;
            _motionState = MotionState.MovingRight;
            movers.Add(Mario.MotionState.MovingLeft, this.MoveLeft);
            movers.Add(Mario.MotionState.MovingRight, this.MoveRight);
        }

        public override bool MoveLeft()
        {
            if (base.MoveLeft() != true )
            {
                _motionState = Mario.MotionState.MovingRight;
                return false;
            }

            return true;
        }

        public override bool MoveRight()
        {
            if (base.MoveRight() != true)
            {
                _motionState = Mario.MotionState.MovingLeft;
                return false;
            }

            return true;
        }

        public override void Dead()
        {
            console.log("enemy is dead.");
        }

        public override void ColliseRight(Player p)
        {
            p.Dead();
        }
        
        public override void ColliseLeft(Player p)
        {
           p.Dead();
        }
    }
}