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

namespace PerrysArt
{

    public partial class FormMyGame : Form
    {
        private StartupController _startup;
        private GameController _mainGame;
        private IGameController _currentGame;

        public FormMyGame()
        {
            InitializeComponent();

            _startup = new StartupController(this);
            _mainGame = new GameController(this);

            _currentGame = _startup;

            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Start();
        }

        public void StartupMainGame()
        {
            _currentGame.Stop();
            _currentGame = _mainGame;
            _currentGame.Start("01");
        }
        //public void NextLevel()
        //{
        //    Stop();
        //    _mainGame = new GameController(this);
        //    _currentGame = _mainGame;
        //    _currentGame.Start("02");
        //    gameTimer.Enabled = true;
        //}

        public void Start()
        {
            _currentGame.Start();
            gameTimer.Enabled = true;
        }

        public void Stop()
        {
            _currentGame.Stop();
            gameTimer.Enabled = false;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            _currentGame.Tick();
        }

        private void DrawTheGame(Graphics g)//                             DRAW GAME
        {
            _currentGame.DrawTheGame(g);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            _currentGame.KeyDown(sender, e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            _currentGame.KeyUp(sender, e);   
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
