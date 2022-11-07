namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player;

internal class Inventory
{

    private readonly Player _player;

    public Inventory(Player player)
    {
        _player = player;
    }

    private List<Item> _items = new();
    private int _selectedItem = 0;

    public void SelectNext() => _selectedItem = Math.Min(_selectedItem + 1, _items.Count - 1);
    public void SelectPrevious() => _selectedItem = Math.Max(0, _selectedItem - 1);
    public Item SelectedItem => _items.ElementAt(_selectedItem);
    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        _items.Remove(item);
    }
    public void DropItem(Item item)
    {

    }
    public List<Item> GetItems()
    {
        return _items;
    }
    public State UseItem()
    {
        var newState = SelectedItem.Use(_player);
        _selectedItem = Math.Max(_selectedItem - 1, 0);
        return newState;
    }
}

