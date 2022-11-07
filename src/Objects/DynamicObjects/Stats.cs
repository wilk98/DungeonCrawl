namespace Dungeon_Crawl.src.Objects.DynamicObjects;

internal class Stats
{
    internal int HealthPoints { get; set; }
    internal int Strength { get; set; }
    internal int Defense { get; set; }

    public void UpdateStats(int healthPoints, int strength, int defense)
    {
        HealthPoints += healthPoints;
        Strength += strength;
        Defense += defense;
    }
}
