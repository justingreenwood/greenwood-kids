using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Learning
{
    public interface ICellxx
    {
        CellType Type { get; }
        ConsoleColor Color { get; }
        char Character { get; }
    }
}
