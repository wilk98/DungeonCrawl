using Dungeon_Crawl.src.Objects;

namespace Dungeon_Crawl.src.StaticObjects
{
    abstract internal class StaticObject : GameObject
    {
        abstract protected string Symbol { get; set; }
        public override string Render()
        {
            return Symbol;
        }
        public override void Update() { }
    }
}
