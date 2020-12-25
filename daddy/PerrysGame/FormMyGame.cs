using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerrysGame
{

    public partial class FormMyGame : Form
    {
        Controls controls = new Controls();

        private StartupGameController _menu = new StartupGameController();
        private MainGameController _mainGame = new MainGameController();
        private IGameController _currentGame;

        public FormMyGame()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            
            ScreenInfo.UseForm(this);
            MasterControl.UseForm(this);
            _currentGame = _menu;
        }

        public void PerformEventChange(GameStateChangeEventType eventType, object data = null)
        {
            _currentGame.Stop();
            switch(eventType)
            {
                case GameStateChangeEventType.Menu:
                    _currentGame = _menu;
                    break;
                case GameStateChangeEventType.Play:
                    _currentGame = _mainGame;
                    break;
                case GameStateChangeEventType.Quit:
                    this.Close();
                    Application.Exit();
                    return;
                default:
                    throw new NotImplementedException();
            }
            _currentGame.Start();
        }

        private void FormMyGame_Load(object sender, EventArgs e)
        {
            _currentGame.Start();
            gameTimer.Enabled = true;
        }

        public void Stop()
        {
            gameTimer.Enabled = false;
            _currentGame.Stop();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            _currentGame.Tick();
            Invalidate();
        }

        private void DrawTheGame(Graphics g)
        {
            _currentGame.DrawTheGame(g);
        }

        private void FormMyGame_KeyDown(object sender, KeyEventArgs e)
        {
            _currentGame.KeyDown(e);
        }

        private void FormMyGame_KeyUp(object sender, KeyEventArgs e)
        {
            _currentGame.KeyUp(e);
        }

        private void FormMyGame_Resize(object sender, EventArgs e)
        {
            _currentGame.Resize();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            var g = pe.Graphics;
            using (Bitmap frontLayerBmp = new Bitmap(this.Size.Width, this.Size.Height))
            {
                using (var frontLayer = Graphics.FromImage(frontLayerBmp))
                {
                    frontLayer.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    frontLayer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                    frontLayer.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
                    frontLayer.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                    frontLayer.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;

                    try
                    {
                        DrawTheGame(frontLayer);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("***********************************");
                        System.Diagnostics.Debug.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
                        System.Diagnostics.Debugger.Break();
                    }

                    g.DrawImage(frontLayerBmp, this.ClientRectangle);
                }
            }
        }
    }
}
