namespace Dungeon_Crawl.src.Objects;

internal abstract class DynamicObject
{
    private string Symbol { get; set; }

    public abstract void processInput(char key);

    public void Move()
    {

    }

    public void Attack()
    {

    }
}

