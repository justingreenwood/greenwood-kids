using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchGame
{
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;
        IfsForAnimals ifsForAnimals = new IfsForAnimals();


        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
        }

        private void SetUpGame()
        {
            List<string> Picture = new List<string>()
            {
                "🐭","🐭",
                "🐵","🐵",
                "😺","😺",
                "🐗","🐗",
                "🐰","🐰",
                "🦝","🦝",
                "🐔","🐔",
                "🐼","🐼",
            };
            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    int index = random.Next(Picture.Count);
                    string nextPicture = Picture[index];
                    textBlock.Text = nextPicture;
                    Picture.RemoveAt(index);
                    textBlock.Visibility = Visibility.Visible;
                    if(textBlock.Text == "🐭")
                    {
                        textBlock.Name = "Mouse";
                    }
                    else if (textBlock.Text == "🐵")
                    {
                        textBlock.Name = "Monkey";
                    }
                    else if (textBlock.Text == "😺")
                    {
                        textBlock.Name = "Cat";
                    }
                    else if (textBlock.Text == "🐗")
                    {
                        textBlock.Name = "Pig";
                    }
                    else if (textBlock.Text == "🐰")
                    {
                        textBlock.Name = "Rabbit";
                    }
                    else if (textBlock.Text == "🦝")
                    {
                        textBlock.Name = "Racoon";
                    }
                    else if (textBlock.Text == "🐔")
                    {
                        textBlock.Name = "Chicken";
                    }
                    else
                    {
                        textBlock.Name = "Panda";
                    }
                    textBlock.Text = "     ";
                }
            }

            timer.Start();
            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;  
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;
        //Pressing and Matching
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                //textBlock.Visibility = Visibility.Hidden;
                foreach(TextBlock block in mainGrid.Children.OfType<TextBlock>())
                {
                    if(block.Text != "     " || textBlock.Name != "timeTextBlock")
                    {
                        block.Text = "     ";
                    }
                }
                
                textBlock.Text = ifsForAnimals.NameToAnimal(textBlock.Name);
                lastTextBlockClicked = textBlock;
                findingMatch = true;

            }
            else if (textBlock.Name == lastTextBlockClicked.Name && textBlock !=lastTextBlockClicked)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                //lastTextBlockClicked.Visibility = Visibility.Visible;
                textBlock.Text = ifsForAnimals.NameToAnimal(textBlock.Name);
                findingMatch = false;
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }


        
    }

}
