using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos
{
    public class GameController : IGameController
    {
        private const float TileSize = 20f;
        private float scaleFactor = 0.8f;
        private FormTriangleTrees _form;
        private bool gameOver = false;
        public bool goToMenu = false;
        public bool CHEATS => _form.CHEATS;
        public float ScaleFactor => scaleFactor;
        private ILevel _currentLevel => _form.currentLevel;
        int AliveBadguys;
        Player player;
        List<Water> waters = new List<Water>();
        List<DeepWater> deepWaters = new List<DeepWater>();
        List<Block> blocks = new List<Block>();
        List<Badguy> badguys = new List<Badguy>();
        List<Tile> tiles = new List<Tile>();
        List<Gold> golds = new List<Gold>();
        List<Ammunition> ammunitions = new List<Ammunition>();
        string[] levelTop => _currentLevel.levelTop;
        private int ShootingCoolDown = 5;
        public GameController(FormTriangleTrees form)
        {
            _form = form;
        }

        public PointF CenterPoint => new PointF(player.X + (player.Width) / 2, player.Y + (player.Height / 2));

        public void DrawTheGame(Graphics g)
        {
            foreach (Tile tile in tiles)
            {
                DrawScaledTiles(g, tile);
            }
            foreach (Gold gold in golds.Where(t => t.IsPickedUp == false))
            {
                DrawScaledTiles(g, gold);
            }
            foreach (Badguy badguy in badguys)
            {
                DrawScaledTiles(g, badguy);
            }
            if (player.IsAlive)
                DrawScaledTiles(g, player);
            foreach (Ammunition ammunition in ammunitions)
            {
                DrawScaledTiles(g, ammunition);
            }
            if (CHEATS)
            {
                g.DrawString($"IsRunning:{player.IsRunning} IsInWater:{player.IsInWater} IsShooting:{player.IsShooting} " +
                    $"Ammo:{player.ammunition} Score {_currentLevel.CurrentScore}/{_currentLevel.Score} Badguys: {AliveBadguys}",
                    SystemFonts.DefaultFont, Brushes.LightGray, 5, 5);
            }
            else
            {
                g.DrawString($"Ammo:{player.ammunition} Score {_currentLevel.CurrentScore}/{_currentLevel.Score} Badguys: {AliveBadguys}",
                    SystemFonts.DefaultFont, Brushes.LightGray, 5, 5);
            }
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            if (player.IsAlive && gameOver == false)
            {
                if (e.KeyCode == Keys.ShiftKey)
                {
                    // player.Speed = player.RunSpeed;
                    player.IsRunning = true;
                }
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
                    player.GoingDown = true;
                }
                if (e.KeyCode == Keys.W)
                {
                    player.GoingUp = true;
                }
                if (e.KeyCode == Keys.A)
                {
                    player.GoingLeft = true;
                }
                if (e.KeyCode == Keys.D)
                {
                    player.GoingRight = true;
                }
                if (e.KeyCode == Keys.F12 && CHEATS)
                {
                    foreach( Badguy badguy in badguys)
                    {
                        badguy.IsDead = true;
                    }
                    _currentLevel.CurrentScore = 999;
                }
                //Shooting Direction
                {
                    if (player.GoingDown && player.GoingRight)
                    {
                        player.LastWentDirection = "southeast";
                    }
                    else if (player.GoingDown && player.GoingLeft)
                    {
                        player.LastWentDirection = "southwest";
                    }
                    else if (player.GoingUp && player.GoingRight)
                    {
                        player.LastWentDirection = "northeast";
                    }
                    else if (player.GoingUp && player.GoingLeft)
                    {
                        player.LastWentDirection = "northwest";
                    }
                    else if (player.GoingDown)
                    {
                        player.LastWentDirection = "south";
                    }
                    else if (player.GoingLeft)
                    {
                        player.LastWentDirection = "west";
                    }
                    else if (player.GoingRight)
                    {
                        player.LastWentDirection = "east";
                    }
                    else if (player.GoingUp)
                    {
                        player.LastWentDirection = "north";
                    }
                }

                if (e.KeyCode == Keys.Space)
                {
                    if (player.ammunition > 0)
                    {                        
                        player.IsShooting = true;
                        if (ShootingCoolDown == 0)
                        {                           
                            player.ammunition -= 1;
                            ammunitions.Add( new Ammunition(player.X, player.Y, player.LastWentDirection));                            
                            ShootingCoolDown = 15;
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (gameOver)
                {
                    goToMenu = true;
                }
            }

            player.UpdateAnimationState();
            this._form.Invalidate();
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                // player.Speed = player.NormalSpeed;
                player.IsRunning = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                player.IsShooting = false;
            }
            if (e.KeyCode == Keys.S)
            {
                player.GoingDown = false;
            }
            if (e.KeyCode == Keys.W)
            {
                player.GoingUp = false;
            }
            if (e.KeyCode == Keys.A)
            {
                player.GoingLeft = false;
            }
            if (e.KeyCode == Keys.D)
            {
                player.GoingRight = false;
            }

            player.UpdateAnimationState();
            this._form.Invalidate();
        }

        private bool IsBlocked
        {
            get 
            {
                var isBlocked = false;
                foreach (Tile blocker in tiles.Where(t => t.IsBlocker))
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
        public void MouseDown(object sender, MouseEventArgs e)
        {
        }

        public void Start(string startInfo = null)
        {
            Refresh();
            for (int row = 0; row < levelTop.Length; row++)
            {
                var higherLevelRow = levelTop[row];
                for (int column = 0; column < higherLevelRow.Length; column++)
                {
                    var letter = higherLevelRow[column];

                    if (letter == 'W')
                    {
                        tiles.Add(new Water(column, row, Color.Blue));
                    }
                    else if(letter == 'E')
                    {
                        tiles.Add(new Block(column, row, Color.Brown));
                    }
                    else if (letter == 'L')
                    {
                        tiles.Add(new Block(column, row, Color.OrangeRed));
                    }
                    else if (letter == 'S')
                    {
                        tiles.Add(new Block(column, row, Color.SandyBrown));
                    }
                    else if (letter == 'D')
                    {
                        tiles.Add(new Block(column, row, Color.SaddleBrown));
                    }
                    else
                    {
                        tiles.Add(new Block(column, row, Color.Green));
                    }

                    if (letter == 'P')
                    {
                        player = new Player(column, row);
                    }
                    else  if (letter == 'V')
                    {
                        badguys.Add(new Badguy(column, row));
                    }
                    else if (letter == 'v')
                    {
                        badguys.Add(new Badguy(column, row, 2f, 9f));
                    }
                    else if (letter == 'g')
                    {
                        golds.Add(new Gold(column, row, Color.Gold));
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
                    else if (letter == 'Q')
                    {
                        tiles.Add(new DeepWater(column, row, Color.Navy));
                    }
                }
            }
        }

        public void Stop()
        {
            
        }

        public void Tick()
        {
            if (gameOver == false)
            {
                int aliveBadguys = 0;
                if (player.IsAlive)
                {
                    player.AnimationTick();

                    if (ShootingCoolDown > 0)
                        ShootingCoolDown--;
                    foreach (Badguy badguy in badguys)
                    {
                        if (badguy.IsDead == false)
                        {
                            aliveBadguys++;
                            badguy.Move(scaleFactor);
                            foreach (Tile blocker in tiles.Where(t => t.IsBlocker))
                            {
                                if (badguy.Rect(scaleFactor).IntersectsWith(blocker.Rect(scaleFactor)))
                                {
                                    badguy.Reverse();
                                    badguy.Move(scaleFactor);
                                }
                            }
                            foreach (Tile water in tiles.Where(w => w.Tag == "water"))
                            {
                                if (badguy.Rect(scaleFactor).IntersectsWith(water.Rect(scaleFactor)))
                                {
                                    badguy.IsInWater = true;
                                    break;
                                }
                                else
                                    badguy.IsInWater = false;
                            }

                            if (badguy.Rect(scaleFactor).IntersectsWith(player.Rect(scaleFactor)))
                            {
                                player.IsAlive = false;
                                gameOver = true;
                            }
                        }
                        else
                        {
                            badguy.image = Resources.Image_DeadBadguy;
                        }
                    }
                    foreach (Tile water in tiles.Where(w => w.Tag == "water"))
                    {
                        if (player.Rect(scaleFactor).IntersectsWith(water.Rect(scaleFactor)))
                        {
                            player.IsInWater = true;
                            break;
                        }
                        else
                        {
                            player.IsInWater = false;
                        }

                    }
                    foreach (Ammunition ammunition in ammunitions)
                    {
                        ammunition.Move(scaleFactor);
                        foreach (Tile blocker in tiles.Where(t => t.IsBlocker))
                        {
                            if (ammunition.Rect(scaleFactor).IntersectsWith(blocker.Rect(scaleFactor)))
                            {
                                ammunition.IsDead = true;
                                break;
                            }
                        }
                        foreach (Badguy badguy in badguys.Where(b => !b.IsDead))
                        {
                            if (ammunition.Rect(scaleFactor).IntersectsWith(badguy.Rect(scaleFactor)))
                            {
                                ammunition.IsDead = true;
                                badguy.Health -= 3;
                                if (badguy.Health <= 0)
                                {
                                    badguy.IsDead = true;
                                    aliveBadguys--;
                                    _currentLevel.CurrentScore++;
                                }                            
                            }
                        }
                        if (ammunition.IsDead == true)
                        {
                            ammunitions.Remove(ammunition);
                            break;
                        }

                    }

                    AliveBadguys = aliveBadguys;

                    float currentX = player.X, currentY = player.Y;
                    if (player.GoingUp)
                    {
                        player.Y -= player.Speed;
                        if (IsBlocked) player.Y = currentY;
                    }
                    if (player.GoingDown)
                    {
                        player.Y += player.Speed;
                        if (IsBlocked) player.Y = currentY;
                    }
                    if (player.GoingRight)
                    {
                        player.X += player.Speed;
                        if (IsBlocked) player.X = currentX;
                    }
                    if (player.GoingLeft)
                    {
                        player.X -= player.Speed;
                        if (IsBlocked) player.X = currentX;
                    }
                    foreach (Gold gold in golds.Where(t => t.IsPickedUp == false))
                    {
                        if (player.Rect(scaleFactor).IntersectsWith(gold.Rect(scaleFactor)))
                        {
                            gold.IsPickedUp = true;
                            _currentLevel.CurrentScore += 5;
                        }
                    }
                    if (AliveBadguys == 0)
                    {
                        _currentLevel.IsWon = true;
                        
                        if (_currentLevel.HighScore < _currentLevel.CurrentScore)
                            _currentLevel.HighScore = _currentLevel.CurrentScore;
                        gameOver = true;
                    }

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

        
        private void Refresh()
        {
            waters.Clear();
            blocks.Clear();
            badguys.Clear();
            tiles.Clear();
            golds.Clear();
            ammunitions.Clear();
            _currentLevel.CurrentScore = 0;
            gameOver = false;

        }

    }
}
