using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos
{
    public class GameController : IGameController
    {
        private const float TileSize = 20f;
        private float scaleFactor = 0.5f;
        private FormTriangleTrees _form;
        public float ScaleFactor => scaleFactor;
        Player player;        
        List<Block> blocks = new List<Block>();
        List<Badguy> badguys = new List<Badguy>();
        List<Tile> tiles = new List<Tile>();
        string[] levelBottom = File.ReadAllLines(@"Resources/Maps/Level1Bottom.txt");
        string[] levelTop = File.ReadAllLines(@"Resources/Maps/Level1Top.txt");

        public GameController(FormTriangleTrees form)
        {
            _form = form;
        }

        public void DrawTheGame(Graphics g)
        {
            //Bitmap bitmap = Resources.Image_Wall;
            //for (int row = 0; row < levelBottom.Length; row++)
            //{
            //    var lowerLevelRow = levelBottom[row];
            //    for (int column = 0; column < lowerLevelRow.Length; column++)
            //    {
            //        var brush = new SolidBrush(Color.Green);
            //        var letter = lowerLevelRow[column];
            //        if (letter == 'W')
            //        {
            //            brush.Color = Color.Blue;
            //        }
            //        if (letter == 'E')
            //        {
            //            brush.Color = Color.Brown;
            //        }
            //        else if (letter == 'g')
            //        {
            //            brush.Color = Color.Gold;
            //        }
            //        else if (letter == 'L')
            //        {
            //            brush.Color = Color.OrangeRed;
            //        }
            //        DrawScaledTiles(g, brush, bitmap, column, row);
            //    }
            //}
            
            //for (int row = 0; row < levelTop.Length; row++)
            //{
            //    var higherLevelRow = levelTop[row];
            //    for (int column = 0; column < higherLevelRow.Length; column++)
            //    {
            //        var brush = new SolidBrush(Color.White);
            //        var letter = higherLevelRow[column];
            //        if (letter == 'E')
            //        {
            //            brush.Color = Color.Brown;
            //        }
            //        else if (letter == 'g')
            //        {
            //            brush.Color = Color.Gold;
            //        }
            //        else if (letter == 'L')
            //        {
            //            brush.Color = Color.OrangeRed;
            //        }                   
            //        DrawScaledTiles(g, brush, bitmap, column, row);
                    
            //    }
            //}
            foreach (Block block in blocks)
            {
                //DrawScaledTiles(g, tile.brush, tile.image, 0, 0, tile.X, tile.Y, 20, 20);
                DrawScaledTiles(g, block);
            }
            foreach (Tile tile in tiles)
            {
                //DrawScaledTiles(g, tile.brush, tile.image, 0, 0, tile.X, tile.Y, 20, 20);
                DrawScaledTiles(g, tile);
            }
            foreach (Badguy badguy in badguys)
            {
                //DrawScaledTiles(g, badguy.brush, badguy.image, 0, 0, badguy.X, badguy.Y, badguy.Height, badguy.Width);
                DrawScaledTiles(g, badguy);
            }
            if (player.IsAlive)
                DrawScaledTiles(g, player);

        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            if (player.IsAlive)
            {
                float currentX = player.X, currentY = player.Y;
                if (e.KeyCode == Keys.Z && scaleFactor < 1f)
                {
                    scaleFactor += 0.1f;
                }
                if (e.KeyCode == Keys.X && scaleFactor > 0.3f)
                {
                    scaleFactor -= 0.1f;
                }
                if (e.KeyCode == Keys.S)
                {
                    player.Y += player.Speed;
                    if (IsBlocked) player.Y = currentY;
                }
                if (e.KeyCode == Keys.W)
                {
                    player.Y += -player.Speed;
                    if (IsBlocked) player.Y = currentY;
                }
                if (e.KeyCode == Keys.A)
                {
                    player.X += -player.Speed;
                    if (IsBlocked) player.X = currentX;
                }
                if (e.KeyCode == Keys.D)
                {
                    player.X += player.Speed;
                    if (IsBlocked) player.X = currentX;
                }
            }

            this._form.Invalidate();
        }

        private bool IsBlocked
        {
            get 
            {
                var isBlocked = false;
                foreach (Blockers blocker in tiles)
                {
                    if (player.Rect(scaleFactor).IntersectsWith(blocker.Rect(scaleFactor)))
                    {
                        isBlocked = true;
                        break;
                    }
                }
                return isBlocked;
            }
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        public void Start(string startInfo = null)
        {
            for (int row = 0; row < levelTop.Length; row++)
            {
                var higherLevelRow = levelTop[row];
                for (int column = 0; column < higherLevelRow.Length; column++)
                {
                    var letter = higherLevelRow[column];

                    if (letter == 'W')
                    {
                        blocks.Add(new Block(column, row, Color.Blue));
                    }
                    else if(letter == 'E')
                    {
                        blocks.Add(new Block(column, row, Color.Brown));
                    }
                    else if (letter == 'g')
                    {
                        blocks.Add(new Block(column, row, Color.Gold));
                    }
                    else if (letter == 'L')
                    {
                        blocks.Add(new Block(column, row, Color.OrangeRed));
                    }
                    else
                    {
                        blocks.Add(new Block(column, row, Color.Green));
                    }

                    if (letter == 'P')
                    {
                        player = new Player(column, row);
                    }
                    else  if (letter == 'V')
                    {
                        badguys.Add(new Badguy(column, row));
                    }
                    else if(letter == 'T')
                    {
                        tiles.Add(new Tree(column,row));
                    }
                    else if(letter == 'O')
                    {
                        tiles.Add(new Border(column, row));
                    }
                    else if(letter == 'B')
                    {
                        tiles.Add(new Wall(column, row));
                    }
                }
            }
        }

        public void Stop()
        {
            
        }

        public void Tick()
        {

            foreach (Badguy badguy in badguys)
            {
                badguy.Move(scaleFactor);
                foreach (Blockers blocker in tiles)
                {
                    if (badguy.Rect(scaleFactor).IntersectsWith(blocker.Rect(scaleFactor)))
                    {
                        badguy.Reverse();
                        badguy.Move(scaleFactor);
                    }
                }
                
                if (badguy.Rect(scaleFactor).IntersectsWith(player.Rect(scaleFactor)))
                {
                    //player.IsAlive = false;
                }
            }


            _form.Invalidate();
        }

        public void DrawScaledTiles(Graphics g, SolidBrush brush, Bitmap image, int x = 0, int y = 0, float xFloat = 100, float yFloat = 0, float imgH = 20, float imgW = 20, float scale = 1.0f)
        {

            if (xFloat == 100)
            {
                xFloat = x;
                yFloat = y;
            }
            var imageH = imgH * scale;
            var imageW = imgW * scale;
            var imageX = xFloat * 20 * scale;
            var imageY = yFloat * 20 * scale;
            if (brush.Color == Color.Black)
            {
                g.DrawImage(image, imageX, imageY, imageW, imageH);
            }
            else if (brush.Color == Color.White)
            {

            }
            else
            {
                g.FillRectangle(brush, imageX, imageY, imageW, imageH);
            }
        }

        public void DrawScaledTiles(Graphics g, IDrawable t)
        {
            if (t.Brush.Color == Color.Black)
            {
                g.DrawImage(t.Image, t.Rect(ScaleFactor));
            }
            else if (t.Brush.Color == Color.White)
            {

            }
            else
            {
                g.FillRectangle(t.Brush, t.Rect(ScaleFactor));
            }
        }

    }
}
