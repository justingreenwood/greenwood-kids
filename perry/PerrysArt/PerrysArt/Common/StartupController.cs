using System;
using System.Collections.Generic;
using System.Drawing;
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
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
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
