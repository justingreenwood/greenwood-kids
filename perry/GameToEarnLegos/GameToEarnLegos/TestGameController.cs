using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos
{
    public class TestGameController : IGameController
    {
        private FormTriangleTrees _form;
        private SolidBrush _goldBrush = new SolidBrush(Color.Thistle);
        private float _scaleFactor = 4.2f;
        public void MouseDown(object sender, MouseEventArgs e)
        {
        }
        public TestGameController(FormTriangleTrees form)
        {
            _form = form;
        }

        public float ScaleFactor => _scaleFactor;

        public void DrawTheGame(Graphics g)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if ((x+y) % 2 == 0)
                        DrawScaledTile(g, Resources.Image_Wall, null, tileX: x, tileY: y);
                    else
                        DrawScaledTile(g, Resources.Image_Wall, _goldBrush, tileX: x, tileY: y);
                }
            }
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) _scaleFactor += 0.1f;
            if (e.KeyCode == Keys.S && _scaleFactor > 0.1) _scaleFactor -= 0.1f;
            //this._form.Invalidate();
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
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

        public float? _h;

        private void DrawScaledTile(Graphics g, Bitmap img, Brush b, int tileX, int tileY, float scaleFactor = 1.0f)
        {
            float imgW = img.Width;
            float imgH = img.Height;
            float
                x = tileX * imgW * scaleFactor,
                y = tileY * imgH * scaleFactor,
                w = imgW * scaleFactor,
                h = imgH * scaleFactor;

            if (b == null)
            {
                g.DrawImage(
                    img,
                    x: x, //20*2 = 40
                    y: y, //20*2 = 40
                    width: w,
                    height: h);
            }
            else
                g.FillRectangle(
                    b,
                    x: x, //20*2 = 40
                    y: y, //20*2 = 40
                    width: w,
                    height: h);
        }
    }
}
