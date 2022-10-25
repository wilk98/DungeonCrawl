using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Crawl.src.Game;

namespace Dungeon_Crawl.src.Objects.DynamicObjects
{
    internal interface IControlable
    {
        public abstract void ProcessInput(char key);
    }
}
