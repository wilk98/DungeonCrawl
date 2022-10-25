namespace Dungeon_Crawl.src.Core
{
    internal class Info
    {
        private const int _width = 50;
        private readonly Tuple<string, string> choices;
        private int _selectedChoice = 0;

        public string Text { get; }
        public string Choices 
        {
            get
            {
                if (_selectedChoice == 0)
                {
                    return $"<{choices.Item1}> {choices.Item2}";
                }
                else
                {
                    return $"{choices.Item1} <{choices.Item2}>";
                }
            }
        }

        public void SelectLeft() => _selectedChoice = 0;
        public void SelectRight() => _selectedChoice = 1;
        public Info(string text, Tuple<string, string> choices)
        {
            Text = text;
            this.choices = choices;
        }
    }
}