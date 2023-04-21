using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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
        private int DistanceDown = 180;
        //private int optionChoice = 1;
        public bool cheatsOn = false;
        private List<ButtonsInMenu> MenuChoices => _form.MenuChoices;
        private List<ButtonsInMenu> OptionChoices => _form.OptionChoices;
        //private List<ButtonsInMenu> LevelChoices => _form.LevelChoices;
        private List<ButtonsInMenu> LevelChoices = new List<ButtonsInMenu>();
        private List<ButtonsInMenu> LevelFormChoices => _form.LevelChoices;
        public MenuController(FormTriangleTrees form)
        {
            _form = form;
        }
        public void DrawTheGame(Graphics g)
        {
            var imageRect = Utility.FillInRect(new RectangleF(new PointF(0,0), Resources.Image_MenuBackground.Size), this._form.DisplayRectangle);
            var titleWidth = (int)Math.Round(this._form.Width * 0.8);
            var titleHeight = (int)Math.Round((double)titleWidth * ((double)Resources.Image_Title.Height / (double)Resources.Image_Title.Width));
            var textTopOffset = (int)Math.Round(this._form.Height * 0.3);
            var textLeftOffset = (int)Math.Round(this._form.Width * 0.4);

            g.DrawImage(Resources.Image_MenuBackground, imageRect);// 0, 0, this._form.Width, this._form.Height);
            //var titleWidth = (int)Math.Round(this._form.Width * 0.8); 
            //var titleHeight = (int)Math.Round((double)titleWidth * ((double)Resources.Image_Title.Height / (double)Resources.Image_Title.Width)); 
            g.DrawImage(Resources.Image_Title,
                Convert.ToInt32(Math.Round(this._form.Width * 0.1)), Convert.ToInt32(Math.Round(this._form.Height*0.1)),
                titleWidth, titleHeight);

            if (_playButtonPressed)
            {
                for (int i = 1; i <= LevelChoices.Count; i++)
                {
                    if (i != LevelChoices.Count)
                    {
                        var level = _levels[i - 1];
                        g.DrawString($" {level.Name} Score: {level.HighScore}/{level.Score} Goal: {level.Goal}",
                        SystemFonts.DefaultFont, Brushes.Black, textLeftOffset, textTopOffset + (i * 60)+40);
                    }
                }
                DrawWords(LevelChoices, g, textLeftOffset, textTopOffset);
            }
            else if (_optionButtonPressed)
            {
                DrawWords(OptionChoices, g, textLeftOffset, textTopOffset);
            }
            else
            {
                DrawWords(MenuChoices, g, textLeftOffset, textTopOffset);

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
                    if (levelChoiceNumber != LevelChoices.Count-1)
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
                        Start();
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
            foreach (ButtonsInMenu level in LevelFormChoices.Where(l=> l.level != null && l.level.IsWon == true))
            {
                if(level == LevelFormChoices[10])
                {
                    if(cheatsOn)
                        LevelChoices.Add(level);
                }
                else
                    LevelChoices.Add(level);
            }
            if(LevelChoices.Count < 10)
            LevelChoices.Add(LevelFormChoices[LevelChoices.Count()]);
            LevelChoices.Add(LevelFormChoices[LevelFormChoices.Count()-1]);
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
                        levelChoiceNumber = LevelChoices.Count-1;
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

        public void DrawWords(List<ButtonsInMenu> list, Graphics g, int textLeftOffset, int textTopOffset)
        {
            for (int i = 1; i <= list.Count; i++)
            {
                var choice = list[i - 1];
                Brush brush = Brushes.White;
                
                if (list == LevelChoices)
                {
                    if (i == levelChoiceNumber + 1)
                    {
                        brush = Brushes.Red;
                    }
                }
                else
                {
                    if (i == buttonChoice)
                    {
                        brush = Brushes.Red;
                    }
                }
                int j = textLeftOffset;
                if (brush != Brushes.Red)
                {
                    foreach (Bitmap bitmap in list[i - 1].NameBitmap)
                    {
                        if(bitmap != Resources.Image_Tree1)
                            g.DrawImage(bitmap, j, textTopOffset + (i * 60), 21, 35);
                        j += 25;
                    }
                }
                else
                {
                    foreach (Bitmap bitmap in list[i - 1].NameBitmap)
                    {
                        if (bitmap != Resources.Image_Tree1)
                        {
                            g.FillRectangle(Brushes.Yellow, j, textTopOffset + (i * 60), 21, 35);
                            g.FillEllipse(Brushes.Yellow, j-2, textTopOffset + (i * 60)-2, 25, 39);
                            g.DrawImage(bitmap, j, textTopOffset + (i * 60), 21, 35);

                        }
                        j += 25;
                    }
                }
            }
        }

    }
}
