using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Learning
{
    public class Gemxx : ICell
    {
        public static Random _rand = new Random();

        public Gemxx(Point p) : this(p.X, p.Y)
        {
        }

        public Gemxx(int x, int y)
        {
            this.BirthColumn = x;
            X = x;
            Y = y;
            switch (_rand.Next(4))
            {
                case 0: Color = ConsoleColor.Green; BackgroundColor = ConsoleColor.DarkGreen; Character = 'X'; break;
                case 1: Color = ConsoleColor.Red; BackgroundColor = ConsoleColor.DarkRed; Character = 'O'; break;
                case 2: Color = ConsoleColor.Yellow; BackgroundColor = ConsoleColor.DarkYellow; Character = '$'; break;
                case 3: Color = ConsoleColor.Cyan; BackgroundColor = ConsoleColor.DarkBlue; Character = '@'; break;
            }
        }

        public Gemxx(int x, int y, ConsoleColor color, char c) : this(new Point(x, y), color, c) { }

        public Gemxx(Point p, ConsoleColor color, char c)
        {
            X = p.X;
            Y = p.Y;
            Color = color;
            Character = c;
        }

        public CellType Type => CellType.Gem;

        public ConsoleColor Color { get; set; }
        public ConsoleColor BackgroundColor { get; set; }

        public char Character { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int BirthColumn { get; set; }
        public int? PreviousX { get; set; }
        public int? PreviousY { get; set; }
        public bool IsDirty => X != PreviousX || Y != PreviousY;
        public void MarkClean()
        {
            PreviousX = X;
            PreviousY = Y;
        }
    }
}
