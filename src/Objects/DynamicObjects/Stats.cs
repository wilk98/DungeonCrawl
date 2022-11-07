namespace Dungeon_Crawl.src.Objects.DynamicObjects;

internal class Stats
{
    internal int Level { get; set; }
    internal int HealthPoints { get; set; }
    internal int Strength { get; set; }
    internal int Defense { get; set; }

    public void UpdateStats(int level ,int healthPoints, int strength, int defense)
    {
        Level += level;
        HealthPoints += healthPoints;
        Strength += strength;
        Defense += defense;
    }
}
