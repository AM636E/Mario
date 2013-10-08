using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario.Interface
{
    /*
     * Provides actions that collisable sprite must do
     * when collised with player
     */

    public interface ICollisable
    {
        void ColliseRight(Player p);
        void ColliseLeft(Player p);
        void ColliseUp(Player p);
        void ColliseBottom(Player p);   
    }
}
