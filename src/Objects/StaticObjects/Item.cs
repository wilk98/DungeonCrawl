namespace Dungeon_Crawl.src.StaticObjects
{
    internal class Item : StaticObject, IPickable
    {
        public Item(Position position) : base(position)
        {
        }

        public bool IsPickable => throw new NotImplementedException();

        protected override string Symbol { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool PickUp()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
