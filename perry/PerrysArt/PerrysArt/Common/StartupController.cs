using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerrysArt
{
    public class StartupController : IGameController
    {
        private FormMyGame _form;
        public StartupController(FormMyGame gameForm)
        {
            _form = gameForm;
        }
        public void DrawTheGame(Graphics g)
        {
            g.DrawImage(Drawings.Background, 0, 0, 840, 700);
            //g.FillRectangle(Brushes.Gray, 330, 280, 150, 50);
            //g.DrawString("(P)lay", SystemFonts.CaptionFont, Brushes.Black, 360, 295);
            //g.FillRectangle(Brushes.Gray, 330, 360, 150, 50);
            //g.DrawString("(L)oad", SystemFonts.CaptionFont, Brushes.Black, 360, 375);
            //g.FillRectangle(Brushes.Gray, 330, 440, 150, 50);
            //g.DrawString("(V)iew High Score", SystemFonts.CaptionFont, Brushes.Black, 360, 455);
            //g.FillRectangle(Brushes.Gray, 330, 520, 150, 50);
            //g.DrawString("(E)xit", SystemFonts.CaptionFont, Brushes.Black, 360, 535);
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V)//els
            {
                
            }
            else if (e.KeyCode == Keys.Q)
            {
                Application.Exit();
            }
            else if (e.KeyCode == Keys.L)
            {

            }
            else if (e.KeyCode == Keys.P)
            {
                _form.StartupMainGame();
            }

        }

        public void Start(string startInfo = null)
        {
            _form.BackColor = Color.Orange;
        }

        public void Stop()
        {
        }

        public void Tick()
        {
        }
    }
}
