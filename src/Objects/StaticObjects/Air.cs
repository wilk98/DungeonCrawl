using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl.src.Objects.StaticObjects
{
    internal class Air : StaticObject
    {
        public Air(Position position) : base(position)
        {
        }

        protected override string Symbol { get => " "; set => throw new NotImplementedException(); }
    }
}
