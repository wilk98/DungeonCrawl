using Dungeon_Crawl.src.Objects.DynamicObjects.Player;

namespace Dungeon_Crawl.src.Objects.StaticObjects;
internal class Key : StaticObject, IPickable
{
    public Key(Position position) : base(position)
    {
    }

    protected override string Symbol => "K";
    public bool IsPickable { get; }
    public bool PickUp(Player player)
    {
        throw new NotImplementedException();
    }
}

