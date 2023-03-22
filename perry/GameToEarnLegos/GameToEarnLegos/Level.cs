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
                int badguyPoints = 0;
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
                            badguyPoints++;
                        }
                        else if (letter == 't')
                        {
                            badguyPoints+=5;
                        }
                        else if (letter == 'v')
                        {
                            badguyPoints+= 2;
                        }
                        else if (letter == '0')
                        {
                            badguyPoints += 10;
                        }
                    }
                }
                return numberOfGold * 5 + badguyPoints;

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
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level1.txt");
        public override string Name => "The Beginning";
        public override string Goal => "Completion";
    }

    public class Level2 : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level2.txt");
        public override string Name => "Deers of Death";
    }
    public class Level3 : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level3.txt");
        public override string Goal => "Treasure Hunt";
        public override string Name => "The Ruins";
    }
    public class TestLevel : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/TestLevel.txt");
        public override string Name => "Testing";
    }
    public class Level4 : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level4.txt");
        public override string Name => "Fort Bird";
    }
    public class Level5 : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level5.txt");
        public override string Name => "The King of Deer";
        public override string Goal => "?????????";
    }
    public class Level6 : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level6.txt");
        public override string Name => "Fried";
    }
    public class Level7 : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level7.txt");
        public override string Name => "Save The Trees";
        public override string Goal => "Extinguish";
    }
    public class Level8 : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level8.txt");
        public override string Name => "Flames Alive";
        public override string Goal => "Extinguish";
    }
    public class Level9 : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level9.txt");
        public override string Name => "The Path of Destruction";
    }
    public class Level10 : Level
    {
        public override string[] levelTop => File.ReadAllLines(@"Resources/Maps/Level10.txt");
        public override string Name => "To Slay A Beast";
        public override string Goal => "?????????";
    }
}
