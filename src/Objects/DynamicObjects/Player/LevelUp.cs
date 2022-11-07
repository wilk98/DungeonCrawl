using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player;

internal class LevelUp
{
    public int level;
    public int experience;
    public int experienceRequired;

    public LevelUp()
    {
        level = 1;
        experience = 0;
        experienceRequired = 100;
    }

    public void IncreaseLevel(Player player)
    {
        level += 1;
        experience = 0;
        player.Stats.Defense += 2;
        player.Stats.Strength += 2;
        player.Stats.HealthPoints += 10;
        experienceRequired += 100;
    }
    public void Update(Player player)
    {
        if (experience >= experienceRequired)
            IncreaseLevel(player);
    }
}
