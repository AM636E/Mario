using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    public abstract class Unit: BitMapSprite, Mario.Interface.ICollisable
    {
        public event EventHandler Deading;

        private CollisionType _collisionEnemies = CollisionType.NONE;
        private CollisionType _collisionPrizes = CollisionType.NONE;

        private CollisionType _collisioin = CollisionType.NONE;

        public CollisionType Collision
        {
            get { return _collisioin;  }
            set { _collisioin = value;  }
        }

        public CollisionType CollisionEnemies
        {
            get { return _collisionEnemies; }
            set { _collisionEnemies = value; }
        }

        public CollisionType CollisionPrizes
        {
            get { return _collisionPrizes; }
            set { _collisionPrizes = value; }
        }

        protected int life;

        public int Life { get { return life; } set { life = value; } }

        public Unit()
            :base()
        { }

        public Unit(System.Drawing.Bitmap bitmap, System.Drawing.Point p)
            : base(bitmap, p)
        { }

        public Unit(string bitmapPath) :
            base(bitmapPath)
        { }

        public Unit(string bitmapPath, int life)
            :this(bitmapPath)
        {
            this.life = life;
        }

        public Unit(string bitmapPath, int life, System.Drawing.Point p)
            : base(p, bitmapPath)
        {
            this.life = life;
        }

        public bool IsDeading()
        {
            return life <= 0;
        }

        public virtual void Dead()
        {
            if(Deading != null)
            {
                Deading(this, EventArgs.Empty);
            }
        }

        public virtual CollisionType CheckCollision(IList units)
        {
            foreach (Unit u in units)
            {
                if(this == u)
                {
                    continue;
                }
                if (this.IsSpriteOnLeft(u))
                {
                    return _collisioin = CollisionType.LEFT;
                }
                if (this.IsSpriteOnRight(u))
                {
                    return _collisioin = CollisionType.RIGHT;
                }
                if (this.IsSpriteUp(u))
                {
                    return _collisioin = CollisionType.UP;
                }
                if (this.IsSpriteBottom(u))
                {
                    return _collisioin = CollisionType.BOTTOM;
                }
            }

            return _collisioin = CollisionType.NONE;
        }

        public virtual void ColliseLeft(Player p) { Dead();  }
        public virtual void ColliseRight(Player p) { Dead(); }
        public virtual void ColliseUp(Player p) { Dead(); }
        public virtual void ColliseBottom(Player p) { Dead(); }
    }
}