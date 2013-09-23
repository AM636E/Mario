using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    public class Prize: Unit
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

        public override void Dead()
        {
        }
    }
}
