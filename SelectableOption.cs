using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuCreation
{
    /// <summary>
    /// This abstract class represents an option that can be selectable and can execute code on selection
    /// </summary>
    public abstract class SelectableOption : Option
    {
        protected Action click_action { get; set; }

        public virtual void SetClickAction(Action new_click_action)
        {
            click_action = new_click_action;
        }

        public virtual void AddToClickAction(Action click_action_to_add)
        {
            click_action += click_action_to_add;
        }

        public virtual void InvokeAction()
        {
            if (click_action != null)
                click_action.Invoke();
        }
    }

    
}
