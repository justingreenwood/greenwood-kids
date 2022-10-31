using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos
{
    public interface ILevel
    {
        string[] levelTop { get; }
        string[] levelBottom { get; }
        bool IsWon { get; }


    }
    public class Level1 : ILevel
    {
        public string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level1Top.txt");

        public string[] levelBottom => File.ReadAllLines(@"Resources/Maps/Level1Bottom.txt");

        public bool IsWon => false;
    }
}
