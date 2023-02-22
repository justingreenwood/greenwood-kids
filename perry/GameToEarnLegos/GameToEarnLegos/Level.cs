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
        string Name { get; }
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
                int bossPoints = 0;
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
                        else if (letter == 'V' || letter == 'v')
                        {
                            numberOfBadguys++;
                        }
                        else if (letter == '0')
                        {
                            bossPoints += 10;
                        }
                    }
                }
                return numberOfGold * 5 + numberOfBadguys + bossPoints;

            }
        }
        public virtual string Name => "Not Named";
        public int CurrentScore { get; set; }
        public bool IsWon { get; set; }
        public int HighScore { get; set; }
        public virtual string Goal => "Elimination";
    }
    public class Level1 : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level1Top.txt");
        public override string Goal => "Treasure Hunt";
        public override string Name => "Treasure in the Ruins";
    }

    public class Level2 : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level2.txt");
        public override string Name => "Fort Bird";
    }
    public class Level3 : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level1Bottom.txt");
        public override string Name => "Oh Deer!";
    }
    public class Level5 : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level5.txt");
        public override string Name => "Deer";
    }
}
