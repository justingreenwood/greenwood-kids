using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos
{
    public interface ILevel
    {
        string[] levelTop { get; }
        bool IsWon { get; set;}
        int Score { get; }
        int HighScore { get; set;}
        int CurrentScore { get; set; }
        string Goal { get; }

    }
    public abstract class Level : ILevel
    {
        public virtual string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level1Bottom.txt");
        public int Score
        {
            get
            {
                int numberOfGold = 0;
                int numberOfBadguys = 0;
                for (int row = 0; row < levelTop.Length; row++)
                {
                    var higherLevelRow = levelTop[row];
                    for (int column = 0; column < higherLevelRow.Length; column++)
                    {
                        var letter = higherLevelRow[column];

                        if (letter == 'g')
                        {
                            numberOfGold++;
                        }
                        else if (letter == 'V')
                        {
                            numberOfBadguys++;
                        }
                    }
                }
                return numberOfGold * 5 + numberOfBadguys;

            }
        }

        public int CurrentScore { get; set; }
        public bool IsWon { get; set; }
        public int HighScore { get; set; }
        public virtual string Goal => "Elimination";
    }
    public class Level1 : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level1Top.txt");
        public override string Goal => "Treasure Hunt";
    }

    public class Level2 : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level2.txt");
    }
    public class Level3 : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level1Bottom.txt");
    }
}
