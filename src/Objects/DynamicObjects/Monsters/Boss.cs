using Dungeon_Crawl.src.Objects.DynamicObjects;

namespace Dungeon_Crawl.src.Monsters;

internal class Boss : Monster
{
    public Boss(Position position) : base(position)
    {
    }

    protected override string Symbol { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override string Render()
    {
        throw new NotImplementedException();
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }
}

