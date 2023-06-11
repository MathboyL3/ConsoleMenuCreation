using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuCreation
{
    /// <summary>
    /// This abstract class represents a simple option that will only show it's label and cannot be selected
    /// </summary>
    public abstract class Option
    {
        public string label { get; set; }
        public ConsoleColor font_color { get; set; }

        public virtual void ChangeFontColorTo(ConsoleColor new_font_color)
        {
            font_color = new_font_color;
        }

        public virtual void ChangeLabelTo(string new_label)
        {
            label = new_label;
        }
    }
}
