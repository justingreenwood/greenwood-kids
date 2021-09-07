using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Learning
{
    public class Gem : ICell
    {
        public static Random _rand = new Random();

        public Gem(Point p) : this(p.X, p.Y)
        {
        }

        public Gem(int x, int y)
        {
            this.BirthColumn = x;
            X = x;
            Y = y;
            switch (_rand.Next(4))
            {
                case 0: Color = ConsoleColor.Green; Character = 'X'; break;
                case 1: Color = ConsoleColor.Red; Character = 'O'; break;
                case 2: Color = ConsoleColor.Yellow; Character = '$'; break;
                case 3: Color = ConsoleColor.Cyan; Character = '@'; break;
            }
        }

        public Gem(int x, int y, ConsoleColor color, char c) : this(new Point(x, y), color, c) { }

        public Gem(Point p, ConsoleColor color, char c)
        {
            X = p.X;
            Y = p.Y;
            Color = color;
            Character = c;
        }

        public CellType Type => CellType.Gem;

        public ConsoleColor Color { get; set; }

        public char Character { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int BirthColumn { get; set; }
    }
}
