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
        }

        public Enemy(string bitmapPath, int life, System.Drawing.Point p)
            : base(bitmapPath, life)
        {
            this.position = p;;
            movers.Add(Mario.MotionState.MovingLeft, this.MoveLeft);
            movers.Add(Mario.MotionState.MovingRight, this.MoveRight);
        }

        public Enemy(Enemy copy)
        {
            var a = new Enemy(copy.BitmapPath, copy.Life, new System.Drawing.Point(copy.X, copy.Y));
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