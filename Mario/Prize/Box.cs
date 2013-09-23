using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    class Box: Prize
    {
        public Box()
            :base()
        { }

        public Box(string path)
            : base(path)
        { }

        public Box(string path, int life)
            : base(path, life)
        { }

        public Box(string path, int life, System.Drawing.Point p)
            : base(path, life, p)
        { }


        public override void Dead()
        {
        }
    }
}
