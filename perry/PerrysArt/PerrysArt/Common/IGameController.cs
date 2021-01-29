using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PerrysArt
{
    public interface IGameController
    {
        void Start(string startInfo = null);
        void Stop();
        void Tick();
        void DrawTheGame(Graphics g);
        void KeyDown(object sender, KeyEventArgs e);
        void KeyUp(object sender, KeyEventArgs e);
    }
}
