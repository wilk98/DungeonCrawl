namespace Dungeon_Crawl.src.Core.View
{
    internal class Info
    {
        public delegate void SelectedChoiceHandler(bool accepted);

        private const int _width = 50;
        private readonly Tuple<string, string> choices;
        private int _selectedChoice = 0;
        private SelectedChoiceHandler _selectedChoiceHandler;

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
        public bool Accepted { get; private set; }
        public bool Resolved { get; private set; }

        internal void Select()
        {
            Resolved = true;
            Accepted = _selectedChoice == 0;
            _selectedChoiceHandler(Accepted);
        }

        public Info(string text, Tuple<string, string> choices, SelectedChoiceHandler handler)
        {
            Text = text;
            this.choices = choices;
            _selectedChoiceHandler = handler;
        }
    }
}