using Dungeon_Crawl.src.Objects.DynamicObjects.Player;

namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class Key : Item, IPickable
{
    public string Color { get; }
    public Key(Position position, string color, Map map) : base(position, map)
    {
        Color = color;
    }

    public override bool IsPassable => true;
    protected override string Symbol => "K";
    public override string Name { get => Color + " key"; }
}

