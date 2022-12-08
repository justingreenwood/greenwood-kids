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
        public int levelChoice = 0;
        public float ScaleFactor => 1;
        private bool GoingDown = false;
        private bool GoingUp = false;
        private bool _playButtonPressed = false;
        private bool _optionButtonPressed = false;
        private int buttonChoice = 1;
        private int optionChoice = 1;
        public bool cheatsOn = false;

        public MenuController(FormTriangleTrees form)
        {
            _form = form;
        }
        public void DrawTheGame(Graphics g)
        {
            g.FillRectangle(brush, 100, 100, 100, 50);
            if (_playButtonPressed)
            {
                for (int i = 0; i < _levelCount; i++)
                {
                    var level = _levels[i];
                    Brush brush = Brushes.Black;
                    if (i == levelChoice)
                    {
                        brush = Brushes.Red;
                    }
                    g.DrawString($" Level {i + 1}: Score {level.HighScore}/{level.Score} IsWon {level.IsWon}",
                    SystemFonts.DefaultFont, brush, 500, 100 + (i * 20));
                }
            }
            else if (_optionButtonPressed)
            {
                for (int i = 1; i <= 1; i++)
                {
                    Brush brush = Brushes.Black;
                    if (i == buttonChoice)
                    {
                        brush = Brushes.Red;
                    }
                    if (i == 1)
                        g.DrawString($"CheatsOn {cheatsOn}", SystemFonts.DefaultFont, brush, 500, 100 + (i * 20));
                }
            }
            else
            {
                for (int i = 1; i <= 3; i++)
                {                    
                    Brush brush = Brushes.Black;
                    if (i == buttonChoice)
                    {
                        brush = Brushes.Red;
                    }
                    if(i==1)
                        g.DrawString($"Play", SystemFonts.DefaultFont, brush, 500, 100 + (i * 20));
                    else if(i==2)
                        g.DrawString($"Options", SystemFonts.DefaultFont, brush, 500, 100 + (i * 20));
                    else if(i==3)
                        g.DrawString($"Exit", SystemFonts.DefaultFont, brush, 500, 100 + (i * 20));
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
                if(_playButtonPressed)
                    willPlay = true;
                else if (_optionButtonPressed)
                {
                    if(optionChoice == 1)
                    {
                        if (cheatsOn)
                            cheatsOn = false;
                        else
                            cheatsOn = true;
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
                    if (levelChoice < _levelCount - 1)
                    {
                        levelChoice++;
                    }
                    else
                    {
                        levelChoice = 0;
                    }
                }
                else if (_optionButtonPressed)
                {
                    if (buttonChoice < 1)
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
                    if (buttonChoice < 3)
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
                    if (levelChoice > 0)
                    {
                        levelChoice--;
                    }
                    else
                    {
                        levelChoice = _levelCount - 1;
                    }
                }
                else if(_optionButtonPressed)
                {
                    if(buttonChoice > 1)
                    {
                        buttonChoice--;
                    }
                    else
                    {
                        buttonChoice = 1;
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
                        buttonChoice = 3;
                    }
                }
            }
            _form.Invalidate();
        }

        

    }
}
