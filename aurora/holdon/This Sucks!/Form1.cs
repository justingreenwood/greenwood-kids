using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace This_Sucks_
{
    public partial class Spring : Form
    {
        private const int TickDistance = 10;
        private static Random _random = new Random();

        private List<Flower> _flowers = new List<Flower>();
        private Character _dude = new Character();
        private Keys _currentKey = Keys.None;

        public Spring()
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
            if (e.Button == MouseButtons.Right)
            {
                _dude.Left = e.X;
                _dude.Top = e.Y;
            } 
            else
            {
                _flowers.Add(new Flower
                {
                    Left = e.X,
                    Top = e.Y
                });
            }
        }

        private void DrawTheGame(Graphics g)
        {
            var brush = new SolidBrush(_dude.Color);

            foreach (var f in _flowers)
            {
                g.FillRectangle(Brushes.LightGreen,f.SizeAndLocation);
                g.DrawImage(Flower.Image, f.SizeAndLocation);
            }

            g.FillEllipse(brush, _dude.SizeAndLocation);
            g.DrawEllipse(Pens.Black, _dude.SizeAndLocation);
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

        public class Flower
        {
            public static Bitmap Image = new Bitmap("flower-32.png");
            public float Left = 0;
            public float Top = 0;
            public float Size = 32;

            public RectangleF SizeAndLocation
            {
                get
                {
                    return new RectangleF(Left, Top, Size, Size);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Console.Beep();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Beep();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.Beep();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.Beep();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("It is spring!");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}