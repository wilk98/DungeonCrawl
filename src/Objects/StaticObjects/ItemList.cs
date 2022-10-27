namespace Dungeon_Crawl.src.Objects.StaticObjects;
internal class ItemList
{
    private List<Item> Items;

    public ItemList(Position position, Map map)
    {
        Items = new List<Item>()
        {
            new Item("Sword", position, map),
            new Item("Armor", position, map),
            new Item("Shield", position, map),
            new Item("Helmet", position, map),
            new Item("Greaves", position, map),
            new Item("Health potion", position, map),
            new Item("Strength potion", position, map),
            new Item("Defense potion", position, map),
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

