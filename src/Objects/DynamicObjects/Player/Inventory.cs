namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player;

internal class Inventory
{
    private List<Item> _items = new();

    public void AddItem(Item item)
    {

    }

    public void RemoveItem(Item item)
    {

    }
    public void DropItem(Item item)
    {

    }
    public List<string> GetItemNames()
    {
        return _items.Select(item => item.Name).ToList();
    }
}

