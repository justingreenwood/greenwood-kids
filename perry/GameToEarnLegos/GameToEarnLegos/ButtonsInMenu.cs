﻿using System;
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
        public Level level;
        public List<Bitmap> NameBitmap;
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
