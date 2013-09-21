using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    public abstract class Prize: Unit
    {
        protected int cost;//score that prize add to player score

        public int Cost { get { return cost; } }

        public Prize()
            :base()
        { }

        public Prize(string path)
            : base(path)
        { }

    /*    public Prize()
            :base(*/
    }
}
