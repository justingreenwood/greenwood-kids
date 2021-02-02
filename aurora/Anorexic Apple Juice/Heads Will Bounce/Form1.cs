using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heads_Will_Bounce
{
    //I added and removed, added and removed, but nothing could change.
    public partial class Form1 : Form
    {
        private static Image _head1Image = new Bitmap("AuroraSprite1.png");
        private static Image _head2Image = new Bitmap("AuroraSprite2.png");
        private const int TickDistance = 20;
        private static Random _random = new Random();
        
        private bool isFirstHead = true;
        private int yThingy = 50;

        private Character _dude = new Character();
        private Keys _currentKey = Keys.None;

        public Form1()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Start();
        }


        public void Start()
        {
            gameTimer.Enabled = true;
        }

        public void Stop()
        {
            gameTimer.Enabled = false;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            yThingy++;
            switch (_currentKey)
            {
                case Keys.C: 
                    _dude.Color = Color.FromArgb(100, _random.Next(256), _random.Next(256), _random.Next(256)); 
                    break;
                case Keys.X: 
                    isFirstHead = !isFirstHead; 
                    break;
                case Keys.Up: _dude.Top -= TickDistance; break;
                case Keys.Down: _dude.Top += TickDistance; break;
                case Keys.Left: _dude.Left -= TickDistance; break;
                case Keys.Right: _dude.Left += TickDistance; break;
                case Keys.Add: _dude.Size += TickDistance; break;
                case Keys.Subtract: _dude.Size -= TickDistance; break;
            }
            Invalidate();
        }

        private void DrawTheGame(Graphics g)
        {
            var brush = new SolidBrush(_dude.Color);


            g.DrawImage(_head2Image, new Rectangle(235, 0, 400, 400));

           
            if (isFirstHead)
                g.DrawImage(_head1Image, _dude.SizeAndLocation);
            else
                g.DrawImage(_head2Image, _dude.SizeAndLocation);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (_currentKey == Keys.None)
                _currentKey = e.KeyCode;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == _currentKey)
                _currentKey = Keys.None;
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

        public class Character
        {
            public Color Color = Color.Red;
            public float Left = 200;
            public float Top = 100;
            public float Size = 100;

            public RectangleF SizeAndLocation
            {
                get
                {
                    return new RectangleF(Left, Top, Size, Size);
                }
            }
        }
    }
}
