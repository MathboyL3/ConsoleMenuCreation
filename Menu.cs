

using ConsoleWriter;
using System.Runtime.ConstrainedExecution;

namespace ConsoleMenuCreation
{
    public class Menu
    {
        public static Menu selected_menu;

        private string title;
        private List<Option> options;
        private List<SelectableOption> selectable_options;
        private List<(int x, int y)> selectable_options_position;
        private int last_option_index;
        private int current_selected_option_index;

        public ConsoleColor selected_option_font_color { get; private set; }
        public ConsoleColor selected_option_background_color { get; private set; }
        public bool show_arrows_in_selected_option { get; private set; }

        public Menu(string title) 
        {
            this.title = title;
            options = new List<Option>();
            selectable_options_position = new List<(int x, int y)>();
            selectable_options = new List<SelectableOption>();
            show_arrows_in_selected_option = true;
            selected_option_font_color = ConsoleColor.DarkGreen;
            selected_option_background_color = ConsoleColor.White;
        }

        public void AddOption(Option option)
        {
            options.Add(option);
        }

        public void ChangeOptionTo(int index, Option op)
        {
            options[index] = op;
            if(selected_menu == this)
                selected_menu.ShowMenu();
        }

        public void ShowMenu()
        {
            selected_menu = this;
            current_selected_option_index = 0;
            last_option_index = -1;
            UpdateMenuVisual(false);
            GetSelectableOptions();
            WaitForSelection();
        }

        private void UpdateMenuVisual(bool only_update_selected_options = true)
        {
            if (!only_update_selected_options)
            {
                Console.Clear();
                selectable_options_position = new List<(int x, int y)>();
                Console.WriteLine(title);
                for(int i = 0; i < options.Count; i++)
                {
                    if (options[i] is SelectableOption)
                    {
                        selectable_options_position.Add(Console.GetCursorPosition());
                    }
                    else
                    {
                        if(i == current_selected_option_index)
                        {
                            current_selected_option_index++;
                        }
                    }
                    
                    if (i == current_selected_option_index)
                    {
                        if (show_arrows_in_selected_option)
                            Writer.WriteLine($"> {options[i].label} < ", selected_option_font_color, selected_option_background_color);
                        else
                            Writer.WriteLine(options[i].label, selected_option_font_color, selected_option_background_color);
                    }
                    else
                        Writer.WriteLine(options[i].label, options[i].font_color);
                }
                current_selected_option_index = 0;
            }
            else
            {
                if (last_option_index == current_selected_option_index)
                    return;

                if (last_option_index >= 0)
                {
                    Writer.ClearLine(selectable_options_position[last_option_index].y);
                    SelectableOption last_option = selectable_options[last_option_index];
                    Writer.Write(last_option.label, last_option.font_color);
                }

                Writer.ClearLine(selectable_options_position[current_selected_option_index].y);

                if (show_arrows_in_selected_option)
                    Writer.Write($"> {selectable_options[current_selected_option_index].label} < ", selected_option_font_color, selected_option_background_color);
                else
                    Writer.Write($"{selectable_options[current_selected_option_index].label}", selected_option_font_color, selected_option_background_color);

            }
        }

        private void GetSelectableOptions()
        {
            selectable_options = new List<SelectableOption>();
            foreach (var option in options)
            {
                if(option is SelectableOption)
                {
                    selectable_options.Add((SelectableOption)option);
                }
            }
        }

        private void NextOption()
        {
            last_option_index = current_selected_option_index;
            current_selected_option_index++;
            current_selected_option_index = current_selected_option_index == selectable_options.Count ? 0 : current_selected_option_index;
        }

        private void PreviousOption()
        {
            last_option_index = current_selected_option_index;
            current_selected_option_index--;
            current_selected_option_index = current_selected_option_index == -1 ? selectable_options.Count-1 : current_selected_option_index;
        }

        private bool ExecuteCurrentSelectedOption()
        {
            return selectable_options[current_selected_option_index].InvokeAction();
        }

        private void WaitForSelection()
        {
            while(true)
            {
                ConsoleKeyInfo key_info = Console.ReadKey(true);
                ConsoleKey key = key_info.Key;

                if (key == ConsoleKey.DownArrow)
                {
                    NextOption();
                    UpdateMenuVisual();
                }else if (key == ConsoleKey.UpArrow)
                {
                    PreviousOption();
                    UpdateMenuVisual();
                }
                else if(key == ConsoleKey.Enter)
                {
                    if(ExecuteCurrentSelectedOption())
                        break;
                }
            }
        }

        public void ChangeTitleTo(string new_title)
        {
            title = new_title;
        }
        public void SetSelectedOptionFontColor(ConsoleColor new_font_color)
        {
            selected_option_font_color = new_font_color;
        }
        public void SetSelectedOptionBackgroundtColor(ConsoleColor new_background_color)
        {
            selected_option_background_color = new_background_color;
        }
        public void SetShowArrowsInSelectedOption(bool should_show_arrows)
        {
            show_arrows_in_selected_option = should_show_arrows;
        }
    }
}
