using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    public interface ICollisableCheck
    {
        bool IsCollisedLeft(Sprite u);
        bool IsCollisedRight(Sprite u);
        bool IsCollisedUp(Sprite u);
        bool IsCollisedBottom(Sprite u);    
    }
}
