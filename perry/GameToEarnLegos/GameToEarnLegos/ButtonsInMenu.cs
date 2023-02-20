using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos
{
    public class ButtonsInMenu
    {
        public string Name;
        public bool IsPressed = false;
        Level level;
        public ButtonsInMenu(string name)
        {
            Name = name;

        }
        public ButtonsInMenu(Level level)
        {
            Name = level.Name;
            this.level = level;
        }
    }
}
