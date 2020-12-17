using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerrysArt
{
    public class Controls
    {
        public bool Up;
        public bool Down;
        public bool Left;
        public bool Right;
        public bool Fire;
        public bool Death;
        public bool Exit;
        public bool KillAllEnemies;
        public bool Run;
        public bool Sneak;        
        public bool IsDirectionKeyPressed
        {
            get
            {
                return Up || Down || Right || Left;
            }
        }

        public int CurrentDirection
        {
            get
            {
                if (Up && Left) return 135;
                else if (Up && Right) return 45;
                else if (Down && Left) return 225;
                else if (Down && Right) return 315;
                else if (Up) return 90;
                else if (Down) return 270;
                else if (Left) return 180;
                else if (Right) return 0;

                return 0;
            }
        }

        public override string ToString()
        {
            string s = "";
            if (Run) s += "Run ";
            if (Sneak) s += "Sneak ";
            if (Up) s += "Up ";
            if (Down) s += "Down ";
            if (Left) s += "Left ";
            if (Right) s += "Right ";
            if (Fire) s += "FIRE ";
            return s.Trim();
        }
    }
}
