﻿using Dungeon_Crawl.src.Objects;

namespace Dungeon_Crawl.src.StaticObjects
{
    abstract internal class StaticObject : GameObject
    {
        protected StaticObject(Position position) : base(position)
        {
        }

        
        public override string Render()
        {
            return Symbol;
        }
        public override void Update() { }
    }
}
