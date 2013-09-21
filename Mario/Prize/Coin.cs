using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    class Coin: Prize
    {
        public Coin(string path)
            : base(path)
        { }

        public override void Dead()
        {
        }
    }
}
