using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace PerrysCrossword
{
    class Program
    {
        static Bitmap woodfloor = new Bitmap("justin-tile-1.png");
        const int NumberOfProblems = 20;
        static Random rand = new Random();
        //var bn = rand.Next(15);
        

        static void Main(string[] args)
        {
              
            DrawIt(1900, 875);
        }

        static void DrawIt(int w, int h)
        {
            using (var myImage = new Bitmap(w, h))
            using (var g = Graphics.FromImage(myImage))
            {
                g.FillRectangle(Brushes.LightGray, 0, 0, w, h);
                //DrawHouse(34, 54, g);
                for(int i = 46; i <= 1666; i += 180)
                {
                    DrawHouse(i, 54, g);
                }

                myImage.Save(@"poop.jpg", ImageFormat.Jpeg);
            }

            System.Diagnostics.Process.Start(@"mspaint.exe", @"poop.jpg");
        }

        static void DrawCivilian(int x, int y, Graphics g)
        {
            g.FillEllipse(Brushes.Orange, x, y, 20, 20);
            g.FillEllipse(Brushes.Black, x + 4, y + 4, 5, 5);
            g.FillEllipse(Brushes.White, x + 11, y + 4, 5, 5);
            g.FillRectangle(Brushes.Red, x + 6, y + 15, 9, 3);
            g.FillRectangle(Brushes.Sienna, x + 7, y + 10, 6, 3);
        }
        static void DrawBadGuy(int x, int y, Graphics g)
        {
            g.FillEllipse(Brushes.Gray, x, y, 20, 20);
            g.FillEllipse(Brushes.Red, x + 4, y + 4, 5, 5);
            g.FillEllipse(Brushes.Red, x + 11, y + 4, 5, 5);
            g.FillRectangle(Brushes.Black, x + 6, y + 15, 9, 3);
            g.FillRectangle(Brushes.Black, x + 7, y + 10, 6, 3);
        }
        static void DrawBadGuy0(int x, int y, Graphics g)
        {
            g.FillEllipse(Brushes.DimGray, x, y, 20, 20);
            g.FillEllipse(Brushes.IndianRed, x + 4, y + 4, 5, 5);
            g.FillEllipse(Brushes.IndianRed, x + 11, y + 4, 5, 5);
            g.FillRectangle(Brushes.Black, x + 6, y + 15, 9, 3);
            g.FillRectangle(Brushes.Black, x + 7, y + 10, 6, 3);
        }
        static void DrawBadGuyLeader(int x, int y, Graphics g)
        {
            g.FillEllipse(Brushes.Navy, x, y, 20, 20);
            g.FillEllipse(Brushes.Purple, x + 4, y + 4, 5, 5);
            g.FillEllipse(Brushes.Purple, x + 11, y + 4, 5, 5);
            g.FillRectangle(Brushes.Black, x + 6, y + 15, 9, 3);
            g.FillRectangle(Brushes.Black, x + 7, y + 10, 6, 3);
        }
        static void DrawWall(int x, int y, Graphics g)
        {
            g.FillRectangle(Brushes.SlateGray, x, y, 20, 20);
        }
        static void DrawWall0(int x, int y, Graphics g)
        {
            g.FillRectangle(Brushes.DarkGray, x, y, 20, 20);
        }
        static void DrawWall1(int x, int y, Graphics g)
        {
            g.FillRectangle(Brushes.LightYellow, x, y, 20, 20);
        }
        static void DrawWall2(int x, int y, Graphics g)
        {
            g.FillRectangle(Brushes.DeepPink, x, y, 20, 20);
        }
        static void DrawDoor(int x, int y, Graphics g)
        {
            g.FillRectangle(Brushes.Goldenrod, x, y, 20, 20);
        }
        static void DrawBadGuy1(int x, int y, Graphics g)
        {
            g.FillRectangle(Brushes.DarkGray, x, y, 20, 30);
            g.FillEllipse(Brushes.DarkRed, x + 4, y + 4, 5, 5);
            g.FillEllipse(Brushes.DarkRed, x + 11, y + 4, 5, 5);
            g.FillRectangle(Brushes.Black, x + 6, y + 15, 9, 3);
            g.FillRectangle(Brushes.Black, x + 7, y + 10, 6, 3);
        }

        static void DrawHouse(int x, int y, Graphics g)
        {
            int house = rand.Next(10);
            int guy = rand.Next(12);
            

            // Tiling code ------------------------
            int tileSize = 15;
            for (int x1 = 0; x1 < 140; x1 += tileSize)
            {
                for (int y1 = 0; y1 < 120; y1 += tileSize)
                {
                    g.DrawImage(woodfloor, x + x1, y + y1, tileSize, tileSize);
                }
            }
            // Tiling code ------------------------

            if (house == 1 || house == 2 || house == 3)
            { 
                for (int i = 0; i <= 120; i += 20)
                {
                    DrawWall(x + i, y, g);
                }
                for (int i = 0; i <= 100; i += 20)
                {
                    DrawWall(x + 120, y + i, g);
                }
                for (int i = 0; i <= 100; i += 20)
                {
                    DrawWall(x, y + i, g);
                }
                for (int i = 0; i <= 100; i += 20)
                {
                    DrawWall(x + i, y + 100, g);
                }
            }
            else if (house == 4 || house == 5 || house == 6)
            {
                for (int i = 0; i <= 120; i += 20)
                {
                    DrawWall1(x + i, y, g);
                }
                for (int i = 0; i <= 100; i += 20)
                {
                    DrawWall1(x + 120, y + i, g);
                }
                for (int i = 0; i <= 100; i += 20)
                {
                    DrawWall1(x, y + i, g);
                }
                for (int i = 0; i <= 100; i += 20)
                {
                    DrawWall1(x + i, y + 100, g);
                }
            }
            else if (house == 7 || house == 8|| house == 9)
            {
                for (int i = 0; i <= 120; i += 20)
                {
                    DrawWall0(x + i, y, g);
                }
                for (int i = 0; i <= 100; i += 20)
                {
                    DrawWall0(x + 120, y + i, g);
                }
                for (int i = 0; i <= 100; i += 20)
                {
                    DrawWall0(x, y + i, g);
                }
                for (int i = 0; i <= 100; i += 20)
                {
                    DrawWall0(x + i, y + 100, g);
                }
            }
            else
            {
                for (int i = 0; i <= 120; i += 20)
                {
                    DrawWall2(x + i, y, g);
                }
                for (int i = 0; i <= 100; i += 20)
                {
                    DrawWall2(x + 120, y + i, g);
                }
                for (int i = 0; i <= 100; i += 20)
                {
                    DrawWall2(x, y + i, g);
                }
                for (int i = 0; i <= 100; i += 20)
                {
                    DrawWall2(x + i, y + 100, g);
                }
            }

            DrawDoor(x + 60, y + 100, g);
            if(guy == 1 ||guy == 2)
            {
                DrawBadGuy(x + 40, y + 50, g);
            }
            else if (guy == 3 || guy == 4)
            {
                DrawBadGuy0(x + 40, y + 50, g);
            }
            else if (guy == 5)
            {
                DrawBadGuy1(x + 40, y + 50, g);
            }
            else if (guy == 6)
            {
                DrawBadGuyLeader(x + 40, y + 50, g);
            }
            else 
                DrawCivilian(x + 40, y + 50, g);


        }
    }
}
