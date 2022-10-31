using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos
{
    public interface IGameController
    {
        void Start(string startInfo = null);
        void Stop();
        void Tick();
        void DrawTheGame(Graphics g);
        void KeyDown(object sender, KeyEventArgs e);
        void KeyUp(object sender, KeyEventArgs e);
        void MouseDown(object sender, MouseEventArgs e);

        float ScaleFactor { get; }
    }
}
