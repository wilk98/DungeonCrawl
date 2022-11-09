namespace Dungeon_Crawl.src.Manager
{
    public interface IPlayerDao
    {

        public void Add(Player player);
        public Player Get(int id);
        public void Update(Player player);
        
    }
}