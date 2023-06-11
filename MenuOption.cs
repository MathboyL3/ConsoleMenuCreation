

namespace ConsoleMenuCreation
{
    /// <summary>
    /// An implementation of a SelectableOption, this option will show in the menu and can be selected
    /// </summary>
    public class MenuOption : SelectableOption
    {
        public MenuOption(Action click_action, string label)
        {
            this.click_action = click_action;
            this.label = label;
            font_color = ConsoleColor.White;
        }
        public MenuOption(Action click_action, string label, ConsoleColor font_color)
        {
            this.click_action = click_action;
            this.label = label;
            this.font_color = font_color;
        }
    }
}
