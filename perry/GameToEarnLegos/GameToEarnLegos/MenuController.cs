using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameToEarnLegos
{
    public class MenuController :IGameController
    {
        public bool willPlay = false;
        SolidBrush brush = new SolidBrush(Color.Green);
        Rectangle rect = new Rectangle(100,100,100,50);
        private FormTriangleTrees _form;
        private List<ILevel> _levels => _form.levels;
        private int _levelCount => _levels.Count;
        public int levelChoiceNumber = 0;
        public ILevel levelChoice;
        public float ScaleFactor => 1;
        private bool GoingDown = false;
        private bool GoingUp = false;
        private bool _playButtonPressed = false;
        private bool _optionButtonPressed = false;
        private int buttonChoice = 1;
        //private int optionChoice = 1;
        public bool cheatsOn = false;
        private List<ButtonsInMenu> MenuChoices => _form.MenuChoices;
        private List<ButtonsInMenu> OptionChoices => _form.OptionChoices;
        //private List<ButtonsInMenu> LevelChoices => _form.LevelChoices;
        private List<ButtonsInMenu> LevelChoices = new List<ButtonsInMenu>();
        public MenuController(FormTriangleTrees form)
        {
            _form = form;
        }
        public void DrawTheGame(Graphics g)
        {
            //g.FillRectangle(brush, 100, 100, 100, 50);
            if (_playButtonPressed)
            {
                for (int i = 0; i < LevelChoices.Count; i++)
                {

                    Brush brush = Brushes.White;
                    if (i == levelChoiceNumber)
                    {
                        brush = Brushes.Red;
                        
                    }

                    if (i == LevelChoices.Count-1)
                    {
                        g.DrawString($" Return", SystemFonts.DefaultFont, brush, 500, 100 + (i * 20));
                    }
                    else
                    {
                        var level = _levels[i];
                        g.DrawString($" {level.Name} Score: {level.HighScore}/{level.Score} Goal: {level.Goal} IsWon {level.IsWon}",
                        SystemFonts.DefaultFont, brush, 500, 100 + (i * 20));
                    }
                }
            }
            else if (_optionButtonPressed)
            {
                for (int i = 1; i <= OptionChoices.Count; i++)
                {
                    var option = OptionChoices[i-1];
                    Brush brush = Brushes.White;
                    if (i == buttonChoice)
                    {
                        brush = Brushes.Red;
                    }
                    if(option.Name == "Cheats")
                        g.DrawString($"{option.Name} {cheatsOn}", SystemFonts.DefaultFont, brush, 500, 100 + (i * 20));

                    else
                        g.DrawString($"{option.Name}", SystemFonts.DefaultFont, brush, 500, 100 + (i * 20));

                }
            }
            else
            {
                for (int i = 1; i <= MenuChoices.Count; i++)
                {
                    var choice = MenuChoices[i-1];
                    Brush brush = Brushes.White;
                    if (i == buttonChoice)
                    {
                        brush = Brushes.Red;
                    }
                    foreach (var menuchoice in MenuChoices)
                    {
                    }
                    g.DrawString($"{choice.Name}", SystemFonts.DefaultFont, brush, 500, 100 + (i * 20));
                }
            }

        }
        public void KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                GoingDown = true;
            }
            if (e.KeyCode == Keys.Up||e.KeyCode == Keys.W)
            {
                GoingUp = true;
            }
            if(e.KeyCode == Keys.Enter)
            {
                if (_playButtonPressed)
                {
                    if (levelChoiceNumber != LevelChoices.Count - 1)
                    {                        
                        willPlay = true;
                        levelChoice = _levels[levelChoiceNumber];
                    }                        
                    else
                        _playButtonPressed = false;
                }
                else if (_optionButtonPressed)
                {
                    if(buttonChoice == 1)
                    {
                        if (cheatsOn)
                            cheatsOn = false;
                        else
                            cheatsOn = true;
                    }
                    else if (buttonChoice == 2)
                    {
                        foreach (Level level in _levels)
                        {
                            level.IsWon = true;
                            Start();
                        }
                    }
                    else if (buttonChoice == 3)
                    {
                        _optionButtonPressed = false;
                    }
                }
                else
                {
                    if(buttonChoice == 1)
                    {
                        _playButtonPressed = true;
                    }
                    else if(buttonChoice == 2)
                    {
                        _optionButtonPressed = true;
                    }
                    else if (buttonChoice == 3)
                    {
                        Application.Exit();
                    }
                }
                buttonChoice = 1;
            }
            if(e.KeyCode == Keys.Escape)
            {
                if (_playButtonPressed)
                    _playButtonPressed = false;
                else if (_optionButtonPressed)
                    _optionButtonPressed = false;
            }
        }
        public void MouseDown(object sender, MouseEventArgs e)
        {
        }
        public void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                GoingDown = false;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                GoingUp = false;
            }
        }
        public void Start(string startInfo = null)
        {
            LevelChoices.Clear();
            foreach (Level level in _levels)
            {
                LevelChoices.Add(new ButtonsInMenu(level));
                if(level.IsWon == false)
                {
                    break;
                }
            }


            LevelChoices.Add(new ButtonsInMenu("Return"));

            _playButtonPressed = false;
            _form.Refresh();
        }

        public void Stop()
        {
        }

        public void Tick()
        {

            if (GoingDown)
            {

                if (_playButtonPressed)
                {
                    if (levelChoiceNumber < LevelChoices.Count-1)
                    {
                        levelChoiceNumber++;
                    }
                    else
                    {
                        levelChoiceNumber = 0;
                    }
                }
                else if (_optionButtonPressed)
                {
                    if (buttonChoice < OptionChoices.Count)
                    {
                        buttonChoice++;
                    }
                    else
                    {
                        buttonChoice = 1;
                    }
                }
                else
                {
                    if (buttonChoice < MenuChoices.Count)
                    {
                        buttonChoice++;
                    }
                    else
                    {
                        buttonChoice = 1;
                    }
                }

            }
            else if (GoingUp)
            {
                if (_playButtonPressed)
                {
                    if (levelChoiceNumber > 0)
                    {
                        levelChoiceNumber--;
                    }
                    else
                    {
                        levelChoiceNumber = LevelChoices.Count -1;
                    }
                }
                else if (_optionButtonPressed)
                {
                    if (buttonChoice > 1)
                    {
                        buttonChoice--;
                    }
                    else
                    {
                        buttonChoice = OptionChoices.Count;
                    }
                }
                else
                {
                    if (buttonChoice > 1)
                    {
                        buttonChoice--;
                    }
                    else
                    {
                        buttonChoice = MenuChoices.Count;
                    }
                }
            }

            _form.Invalidate();
        }

        

    }
}
