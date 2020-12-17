using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerrysArt
{
    public class Tree : Tile
    {
        public static Random _rand = new Random();
        public static Bitmap _treeImage = new Bitmap("TreeTester.png");
        public static Bitmap _tree1Image = new Bitmap("PerrysArtTree1.png");
        public static Bitmap _tree2Image = new Bitmap("PerrysArtChristmasTree.png");//111111111111111111111111111111111111
        public const char TileLetter = 'T';

        private int _treeType = _rand.Next(3);

        public Tree() : base() { }
        public Tree(int colIndex, int rowIndex) :base(colIndex, rowIndex) { }

        //public override Brush TileBrush => Brushes.ForestGreen;

        public override void DrawMe(Graphics g, float zoom = 1)
        {
            if (DateTime.Now.Month != 10)
            {
                if (_treeType == 0)
                {
                    //base.DrawMe(g, zoom);
                    g.DrawImage(_treeImage, GetRect(zoom));
                }
                else if (_treeType == 1 && DateTime.Now.Month >= 12)
                {
                    //base.DrawMe(g, zoom);
                    g.DrawImage(_tree2Image, GetRect(zoom));
                }
                else
                {
                    g.DrawImage(_tree1Image, GetRect(zoom));
                }
            }
            else
            {

                if(_treeType == 0)
                    g.FillRectangle(Brushes.OrangeRed, GetRect(zoom));
                else if (_treeType == 1)
                    g.FillRectangle(Brushes.DarkOrange, GetRect(zoom));
                else
                    g.FillRectangle(Brushes.Orange, GetRect(zoom));
            }
        }
    }

    public class Lava : Tile
    {
        public const char TileLetter = 'L';

        public Lava() : base() { }
        public Lava(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.OrangeRed;
    }
    public class Grass : Tile
    {
        public const char TileLetter = 'G';

        public Grass() : base() { }
        public Grass(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.Lime;
    }

    public class Water : Tile
    {
        public const char TileLetter = 'W';

        public Water() : base() { }
        public Water(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.Aqua;
    }

    public class Bridge : Tile
    {
        public const char TileLetter = 'E';

        public Bridge() : base() { }
        public Bridge(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.SaddleBrown;
    }
    public class Sand : Tile
    {
        public const char TileLetter = 'S';

        public Sand() : base() { }
        public Sand(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.Tan;
    }
    public class Wall : Tile
    {
        public const char TileLetter = 'B';

        public Wall() : base() { }
        public Wall(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.SlateGray;
    }
    public class Border : Tile
    {
        public static Bitmap _BorderImage = new Bitmap("PerrysArtBorder.png");
        public const char TileLetter = 'O';

        public Border() : base() { }
        public Border(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }
        public override void DrawMe(Graphics g, float zoom = 1)
        {
            //base.DrawMe(g, zoom);
            g.DrawImage(_BorderImage, GetRect(zoom));
        }
        public override Brush TileBrush => Brushes.Black;
    }
    public class DeepWater : Tile
    {
        public const char TileLetter = 'Q';

        public DeepWater() : base() { }
        public DeepWater(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.Navy;
    }
    public class Door : Tile
    {
        public static Bitmap _DoorImage = new Bitmap("ClosedDoor.png");
        public static Bitmap _DoorImage2 = new Bitmap("ClosedDoor2.png");        
        public const char TileLetter = 'D';

        public Door() : base() { }
        public Door(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.Brown;
    }
    public class Snow : Tile
    {
        public const char TileLetter = 'S';

        public Snow() : base() { }
        public Snow(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.White;
    }
    public class AmmoPack : DrawableObject
    {
        public const char TileLetter = 'A';
        private Brush BackgroundBrush { get { return Brushes.Green; } }
        private Pen OutlinePen { get { return Pens.Black; } }

        public AmmoPack() 
        {
            this.Size = 10;
            this.IsAlive = false;
        }

        public int Ammo = 100;
        public int ReviveAmmo = 0;

        public override void DrawMe(Graphics g, float zoom = 1)
        {
            g.FillRectangle(BackgroundBrush, GetRect(zoom));
            g.DrawRectangle(OutlinePen, GetRect(zoom));
        }
    }
    public class Gold : DrawableObject
    {
        public const char GrassTileLetter = 'g';
        public const char NoTileLetter = 't';
        private Brush BackgroundBrush { get { return Brushes.Gold; } }

        public Gold()
        {
            this.Size = 10;
            this.IsAlive = false;
        }

        public int Coins = 100;

        public override void DrawMe(Graphics g, float zoom = 1)
        {
            g.FillEllipse(BackgroundBrush, GetRect(zoom));
        }
    }
}
