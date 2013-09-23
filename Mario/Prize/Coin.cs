using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    class Coin: Prize
    {
        public Coin()
            :base()
        { }

        public Coin(string path)
            : base(path)
        { }

        public Coin(string path, int life)
            : base(path, life)
        { }

        public Coin(string path, int life, System.Drawing.Point p)
            : base(path, life, p)
        { }

        public override void Dead()
        {
        }
    }
}
