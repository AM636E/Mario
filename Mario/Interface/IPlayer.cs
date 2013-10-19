using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    interface IPlayer: IBoxer
    {
        bool MoveUp();
        bool MoveDown();
    }
}
