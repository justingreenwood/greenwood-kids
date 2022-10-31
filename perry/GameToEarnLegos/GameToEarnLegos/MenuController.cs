using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public float ScaleFactor => 1;
        public MenuController(FormTriangleTrees form)
        {
            _form = form;
        }
        public void DrawTheGame(Graphics g)
        {
            g.FillRectangle(brush, 100, 100, 100, 50);
            
            
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

            }
        }
        public void MouseDown(object sender, MouseEventArgs e)
        {
            if(1==2)
            {
                bool willPlay = true;
            }
        }
        public void KeyUp(object sender, KeyEventArgs e)
        {

        }

        public void Start(string startInfo = null)
        {
            
        }

        public void Stop()
        {
        }

        public void Tick()
        {
            
        }

        

    }
}
