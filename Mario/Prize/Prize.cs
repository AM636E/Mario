using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mario.Interface;

namespace Mario
{
    public class Prize: Unit, ICollisable
    {
        protected int cost;//score that prize add to player score

        public int Cost { get { return cost; } }

        public Prize()
            :base()
        { }

        public Prize(string path)
            : base(path)
        { }

        public Prize(string path, int life)
            : base(path, life)
        { }

        public Prize(string path, int life, System.Drawing.Point p)
            : base(path, life, p)
        { }

        public Prize(System.Drawing.Bitmap bitmap, System.Drawing.Point p)
            : base(bitmap, p)
        { }

        public void ColliseUp(Player p)
        {
            Dead();
        }

        public override void Dead()
        {
            
        }
    }
}
