using Dungeon_Crawl.src.Objects.DynamicObjects.Player;

namespace Dungeon_Crawl.src.Objects.StaticObjects;
internal class Key : StaticObject, IPickable
{
    public string Color { get; }
    public Key(Position position, string color) : base(position)
    {
        Color = color;
    }

    public override bool IsPassable => true;
    protected override string Symbol => "K";
    public bool IsPickable { get; }
    public bool PickUp(Player player)
    {
        throw new NotImplementedException();
    }
}

