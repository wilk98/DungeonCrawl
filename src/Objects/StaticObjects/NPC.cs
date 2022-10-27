namespace Dungeon_Crawl.src.Objects.StaticObjects;
internal class NPC : StaticObject
{
    private List<string> dialog = new();
    private int currentPhrase = -1;
    public NPC(Position position) : base(position)
    {
        dialog.Add("Hello stranger!");
        dialog.Add("Middle");
        dialog.Add("Bye!");
    }

    public bool Finished { get; private set; }

    public override bool IsPassable => true;

    protected override string Symbol { get => "N"; set => throw new NotImplementedException(); }
    public string GetNextPhrase()
    {
        currentPhrase = Math.Min(++currentPhrase, dialog.Count - 1);
        if (currentPhrase == dialog.Count - 1)
        {
            Finished = true;
        }
        return dialog[currentPhrase];
    }
}

