using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario.Interface
{
    public interface ICollisable
    {
        void ColliseRight(Player p);
        void ColliseLeft(Player p);
        void ColliseUp(Player p);
        void ColliseBottom(Player p);
        bool IsCollisedLeft(Unit u );
        bool IsCollisedRihgt(Unit u );
        bool IsCollisedUp(Unit u );
        bool IsCollisedBottom(Unit u);    
    }
}
