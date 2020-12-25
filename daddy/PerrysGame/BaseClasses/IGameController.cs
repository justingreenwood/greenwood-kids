using System.Drawing;
using System.Windows.Forms;

namespace PerrysGame
{
    public interface IGameController
    {
        void Start();
        void Stop();
        void Tick();
        void DrawTheGame(Graphics g);
        void KeyDown(KeyEventArgs e);
        void KeyUp(KeyEventArgs e);
        void Resize();
    }
}
