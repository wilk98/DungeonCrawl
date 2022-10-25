namespace Dungeon_Crawl.src.StaticObjects
{
    internal class Item : StaticObject, IPickable
    {
        public Item(string name, Position position) : base(position)
        {
            Name = name;
        }

        public bool IsPickable => throw new NotImplementedException();

        public string Name { get; internal set; }
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
