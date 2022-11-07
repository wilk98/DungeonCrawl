namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class ItemList
{
    private List<Item> Items;

    public ItemList(Position position, Map map)
    {
        Items = new List<Item>()
        {
            new Sword(position, map),
            new Shield(position, map),
            new Helmet(position, map),
            new Greaves(position, map),
            new HealthPotion(position, map),
            new StrengthPotion(position, map),
            new DefensePotion(position, map),
        };
    }

    public Item RandomItem()
    {
        var random = new Random();
        var itemIndex = random.Next(Items.Count);
        var item = Items[itemIndex];
        return item;
    }
}

