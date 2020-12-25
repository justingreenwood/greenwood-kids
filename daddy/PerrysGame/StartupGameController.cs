using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PerrysGame
{
    public class StartupGameController : IGameController
    {
        private Font _font = new Font(FontFamily.GenericSansSerif, 30);
        private Font _smallerFont = new Font(FontFamily.GenericSansSerif, 20);

        public StartupGameController()
        {
        }

        public void Stop()
        {
        }

        public void Tick()
        {

        }

        public void DrawTheGame(Graphics g)
        {
            g.FillRectangle(Brushes.Black, ScreenInfo.ClientRectangle);
            Brush b = new SolidBrush(Tools.RandomColor());
            var spacingChunk = ScreenInfo.ClientSize.Width / 20;
            g.DrawString("Welcome to Perry's Game!", _font, b, new Rectangle(spacingChunk, spacingChunk, ScreenInfo.ClientSize.Width-20, ScreenInfo.ClientSize.Height - 20));
            g.DrawString("Press SPACEBAR to play...", _smallerFont, Brushes.White, new Rectangle(spacingChunk, spacingChunk * 3, ScreenInfo.ClientSize.Width - 20, ScreenInfo.ClientSize.Height - 20));
            g.DrawString("Press Q to quit...", _smallerFont, Brushes.White, new Rectangle(spacingChunk, spacingChunk * 4, ScreenInfo.ClientSize.Width - 20, ScreenInfo.ClientSize.Height - 20));
        }

        public void Resize()
        {
            _font = new Font(FontFamily.GenericSansSerif, ScreenInfo.ClientSize.Width/20);
            _smallerFont = new Font(FontFamily.GenericSansSerif, ScreenInfo.ClientSize.Width / 30);
        }

        public void KeyDown(KeyEventArgs e)
        {
        }

        public void KeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                MasterControl.SendEvent(GameStateChangeEventType.Play);
            else if (e.KeyCode == Keys.Q)
                MasterControl.SendEvent(GameStateChangeEventType.Quit);
        }

        public void Start()
        {
            Resize();
        }
    }
}
