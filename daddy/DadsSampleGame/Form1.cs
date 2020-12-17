
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DadsSampleGame
{
    public partial class Form1 : Form
    {
        private const int TickDistance = 5;
        private const int RandomEventTickCount = 100;
        private static Random _random = new Random();

        private Color _bgColor = Color.Gray;
        private int _tickIndex = 0;
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
            switch (_currentKey)
            {
                case Keys.C: _dude.Color = Color.FromArgb(100, _random.Next(256), _random.Next(256), _random.Next(256)); break;
                case Keys.Up: _dude.Top -= TickDistance; break;
                case Keys.Down: _dude.Top += TickDistance; break;
                case Keys.Left: _dude.Left -= TickDistance; break;
                case Keys.Right: _dude.Left += TickDistance; break;
                case Keys.Add: _dude.Size += TickDistance; break;
                case Keys.Subtract: _dude.Size -= TickDistance; break;
            }
            Invalidate();

            _tickIndex++;
        }

        private void DrawTheGame(Graphics g)
        {
            var brush = new SolidBrush(_dude.Color);
            var bgBrush = new SolidBrush(_bgColor);

            if (_tickIndex >= RandomEventTickCount)
            {
                _bgColor = Color.FromArgb(100, _random.Next(256), _random.Next(256), _random.Next(256));
                _tickIndex = 0;
            }

            g.FillRectangle(bgBrush, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

            if (_dude.Shape == "circle")
            {
                g.FillEllipse(brush, _dude.SizeAndLocation);
                g.DrawEllipse(Pens.Black, _dude.SizeAndLocation);
            }
            else
            {
                g.FillRectangle(brush, _dude.SizeAndLocation);
                g.DrawRectangle(Pens.Black, _dude.SizeAndLocation);
            }
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

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _dude.Shape = "square";
            } else
            {
                _dude.Shape = "circle";
            }

            _dude.Left = e.X;
            _dude.Top = e.Y;
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
            public int Left = 200;
            public int Top = 100;
            public int Size = 100;
            public string Shape = "circle";

            public Rectangle SizeAndLocation
            {
                get
                {
                    return new Rectangle(Left, Top, Size, Size);
                }
            }
        }
    }
}
