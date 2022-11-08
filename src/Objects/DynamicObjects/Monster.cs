namespace Dungeon_Crawl.src.Objects.DynamicObjects;
internal abstract class Monster : DynamicObject
{
    private List<string> dialog = new();
    private int currentPhrase = -1;
    public virtual Stats Stats { get; internal set; }
    public bool Finished { get; private set; }
    internal abstract int experienceToGain { get; }
    protected Monster(Position position) : base(position)
    {
        dialog.Add("Fight");
    }
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

