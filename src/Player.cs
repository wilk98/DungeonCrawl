namespace Dungeon_Crawl.src;

internal class Player : DynamicObject, IMovable
{
    public Player(Position position) : base(position)
    {
    }

    protected override string Symbol { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void ProcessInput(char key)
    {
        throw new NotImplementedException();
    }

    public override string Render()
    {
        throw new NotImplementedException();
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }
}

