using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuCreation
{
    /// <summary>
    /// An implementation of an Option, this OptionLabel will only show in the menu as a text, cannot be selected.
    /// </summary>
    public class OptionLabel : Option
    {
        public OptionLabel(string text)
        {
            label = text;
            font_color = ConsoleColor.White;
        }

        public OptionLabel(string text, ConsoleColor color)
        {
            label = text;
            font_color = color;
        }
    }
}
