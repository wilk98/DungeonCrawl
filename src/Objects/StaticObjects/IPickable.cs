namespace Dungeon_Crawl.src.StaticObjects
{
    internal interface IPickable
    {
        abstract bool IsPickable { get; }
        abstract bool PickUp();
    }
}
