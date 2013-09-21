using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    class Box: Prize
    {
        public Box(string path)
            : base(path)
        { }


        public override void Dead()
        {
        }
    }
}
