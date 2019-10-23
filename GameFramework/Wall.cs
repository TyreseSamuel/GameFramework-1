using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Wall : Entity
    {
        //Creates a new solid Wall at the specified position represented by '#'
        public Wall(int x, int y) : base('█', "images/tile015.png")
        {
            X = x;
            Y = y;
            Solid = true;
        }
    }
}
