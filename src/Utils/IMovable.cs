using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl.src.Utils
{
    internal interface IMovable
    {
        public abstract void ProcessInput(char key);
    }
}
