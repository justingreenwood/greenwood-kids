﻿using System;
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
    public class GameController : IGameController
    {
        private static Random _rand = new Random();
        private FormMyGame _form;
        private float _zoom = 1.0f;
        int Score;
        int alivebadguys = 0;
        Dude dude = new Dude();
        AmmoPack ammopack = new AmmoPack();

        Controls controls = new Controls();
        List<Tile> backgroundTiles = new List<Tile>();
        List<Bullet> bullets = new List<Bullet>();
        List<BadGuy> badGuys = new List<BadGuy>();
        List<Gold> golds = new List<Gold>();

        public GameController(FormMyGame gameForm)
        {
            _form = gameForm;
        }

        public void Start(string startInfo = null)
        {
            if (DateTime.Now.Month >= 12)
            {
                _form.BackColor = Color.White;
            } 
            else
            {
                _form.BackColor = Color.LimeGreen;
            }

            //this determines which level we start with.
            var lines = File.ReadAllLines($"level-{startInfo ?? "01"}.txt");
            int apple = _rand.Next(2);
            if (apple == 0)
            {
                lines = File.ReadAllLines("level-02.txt");
            }


            for (int row = 0; row < lines.Length; row++)
            {
                var line = lines[row];
                for (int col = 0; col < line.Length; col++)
                {
                    var tileLetter = line[col];
                    switch (tileLetter)
                    {
                        case Tree.TileLetter:
                            this.backgroundTiles.Add(new Tree(col, row));
                            break;
                        case Grass.TileLetter:
                            this.backgroundTiles.Add(new Grass(col, row));
                            break;
                        case Water.TileLetter:
                            this.backgroundTiles.Add(new Water(col, row));
                            break;
                        case Lava.TileLetter:
                            this.backgroundTiles.Add(new Lava(col, row));
                            break;
                        case Wall.TileLetter:
                            this.backgroundTiles.Add(new Wall(col, row));
                            break;
                        case Bridge.TileLetter:
                            this.backgroundTiles.Add(new Bridge(col, row));
                            break;
                        case Sand.TileLetter:
                            this.backgroundTiles.Add(new Sand(col, row));
                            break;
                        case Border.TileLetter:
                            this.backgroundTiles.Add(new Border(col, row));
                            break;
                        case DeepWater.TileLetter:
                            this.backgroundTiles.Add(new DeepWater(col, row));
                            break;
                        case Door.TileLetter:
                            this.backgroundTiles.Add(new Door(col, row));
                            break;
                        case Dude.CharacterLetter:
                            this.dude.SetPosition(col, row);
                            break;
                        case BadGuy.CharacterLetter:
                            var bg = new BadGuy();
                            bg.SetPosition(col, row);
                            bg.BaseSpeed = _rand.Next(3, 6);
                            this.badGuys.Add(bg);
                            alivebadguys += 1;
                            break;
                        case Gold.NoTileLetter:
                            {
                                var gt = new Gold();
                                gt.SetPosition(col, row);
                                this.golds.Add(gt);
                                break;
                            }
                        case Gold.GrassTileLetter:
                            {
                                this.backgroundTiles.Add(new Grass(col, row));

                                var gt = new Gold();
                                gt.SetPosition(col, row);
                                this.golds.Add(gt);
                                break;
                            }

                    }
                    // (col, row)
                }
            }

            // gameTimer.Enabled = true; *****************
        }





        public void Stop()
        {
            // gameTimer.Enabled = false; *****************
        }

        public void Tick()
        {
            // gets called every 50 milliseconds
            // handle movement here, possibly

            if (Keys.Control == (Control.ModifierKeys & Keys.Control) && controls.IsDirectionKeyPressed)
            {
                controls.Sneak = true;
            }
            else
            {
                controls.Sneak = false;
            }

            if (Keys.Shift == (Control.ModifierKeys & Keys.Shift) && controls.IsDirectionKeyPressed)
            {
                controls.Run = true;
            }
            else
            {
                controls.Run = false;
            }


            ammopack.ReviveAmmo++;
            if (dude.IsAlive)
            {
                for (var i = bullets.Count - 1; i >= 0; i--)
                {
                    var b = bullets[i];
                    if (!b.IsDead)
                    {
                        b.Move();
                        foreach (var baddude in badGuys)
                        {
                            if (baddude.IsAlive)
                            {
                                if (b.GetRect(_zoom).IntersectsWith(baddude.GetRect(_zoom)))
                                {
                                    // kill the bullet
                                    b.IsDead = true;

                                    // enemy was hit. reduce his health
                                    baddude.health -= _rand.Next(10, 25);
                                    baddude.WasHit = true;

                                    if (baddude.health <= 0)
                                    {
                                        // crap - he's dead
                                        baddude.IsAlive = false;
                                        alivebadguys--;
                                        Score++;

                                    }
                                }

                            }
                        }
                        for (var k = backgroundTiles.Count - 1; k >= 0; k--)
                        {
                            var tile = backgroundTiles[k];
                            if (tile is Wall || tile is Border || tile is Tree)
                            {
                                if (b.GetRect(_zoom).IntersectsWith(tile.GetRect(_zoom)))
                                {
                                    b.IsDead = true;


                                }
                            }
                        }
                        if (b.IsDead || b.Distance > 300)
                        {
                            b.IsDead = true;
                            bullets.Remove(b);
                        }
                    }
                }
            }
            if (controls.KillAllEnemies)
            {
                for (var i = badGuys.Count - 1; i >= 0; i--)
                {
                    var b = badGuys[i];
                    if (b.IsAlive)
                    {
                        b.IsAlive = false;
                        alivebadguys--;
                    }
                }
            }
            if (ammopack.IsAlive)
            {
                if (dude.IsAlive && ammopack.GetRect(_zoom).IntersectsWith(dude.GetRect(_zoom)))
                {
                    ammopack.IsAlive = false;
                    dude.Ammo += 50;
                    ammopack.ReviveAmmo = 0;
                }
            }
            else
            {
                if (ammopack.ReviveAmmo < 500)
                {
                    ammopack.ReviveAmmo++;
                }
                else
                {
                    ammopack.X = 305;
                    ammopack.Y = 340;
                    ammopack.IsAlive = true;
                }
            }


            for (var i = golds.Count - 1; i >= 0; i--)
            {
                if (golds[i].GetRect(_zoom).IntersectsWith(dude.GetRect(_zoom)))
                {
                    dude.Treasure += golds[i].Coins;
                    golds.RemoveAt(i);
                    Score += 5;
                }
            }

            for (var i = badGuys.Count - 1; i >= 0; i--)
            {
                var b = badGuys[i];
                if (b.IsAlive)
                {
                    if (b.GetRect(_zoom).IntersectsWith(dude.GetRect(_zoom)))
                    {
                        dude.IsAlive = false;
                    }

                    b.Move(_form.ClientSize.Width, _form.ClientSize.Height);

                }
            }

            var inWater = false;
            var inLava = false;

            for (var j = badGuys.Count - 1; j >= 0; j--) badGuys[j].IsInWater = false;


            for (var i = backgroundTiles.Count - 1; i >= 0; i--)
            {
                var tile = backgroundTiles[i];
                var isBadGuyBlocker = (tile is Wall || tile is Lava || tile is Border || tile is Tree || tile is DeepWater);

                if (tile is Water)
                {
                    var waterTile = tile as Water;
                    var dudeGotWet = waterTile.GetRect(_zoom).IntersectsWith(dude.GetRect(_zoom));
                    if (dudeGotWet) inWater = true;
                    for (var j = badGuys.Count - 1; j >= 0; j--)
                    {
                        var enemy = badGuys[j];
                        var enemyWet = waterTile.GetRect(_zoom).IntersectsWith(enemy.GetRect(_zoom));
                        if (enemyWet) enemy.IsInWater = true;
                    }
                }
                else if (tile is Lava)
                {
                    var lavaTile = tile as Lava;
                    var dudeGotHotFeet = lavaTile.GetRect(_zoom).IntersectsWith(dude.GetRect(_zoom));
                    if (dudeGotHotFeet) inLava = true;
                }

                if (isBadGuyBlocker)
                {
                    var blockerRect = tile.GetRect(_zoom);
                    for (var j = badGuys.Count - 1; j >= 0; j--)
                    {
                        var enemy = badGuys[j];
                        var isInBlockingTile = blockerRect.IntersectsWith(enemy.GetRect(_zoom));
                        if (isInBlockingTile)
                            enemy.ReverseAndMoveOut(_zoom, _form.ClientSize.Width, _form.ClientSize.Height, blockerRect);
                    }
                }

            }
            dude.IsInWater = inWater;
            if (inLava) dude.IsAlive = false;

            dude.IsRunning = controls.Run;
            dude.IsSneaking = controls.Sneak;


            if (controls.IsDirectionKeyPressed)
            {
                int treeCheckX = dude.X, treeCheckY = dude.Y;
                if (controls.Up)
                {
                    treeCheckY = dude.Y - dude.Speed;

                }
                if (controls.Down)
                {
                    treeCheckY = dude.Y + dude.Speed;

                }
                if (controls.Left)
                {
                    treeCheckX = dude.X - dude.Speed;

                }
                if (controls.Right)
                {
                    treeCheckX = dude.X + dude.Speed;

                }
                var hitSomething = false;
                var treeCheckRect = new Rectangle(treeCheckX, treeCheckY,
                    Convert.ToInt32(dude.Size * _zoom), Convert.ToInt32(dude.Size * _zoom));

                for (var i = backgroundTiles.Count - 1; i >= 0; i--)
                {
                    var tile = backgroundTiles[i];
                    if (tile is Wall || tile is Tree || tile is Border || tile is DeepWater)
                    {
                        var wallkinwall = tile.GetRect(_zoom).IntersectsWith(treeCheckRect);
                        if (wallkinwall) hitSomething = true;
                    }
                }
                if (!hitSomething)
                {
                    dude.X = treeCheckX;
                    dude.Y = treeCheckY;
                }
                dude.LastKnownDirection = controls.CurrentDirection;

            }

            if (controls.Death)
            {
                dude.IsAlive = false;
            }


            if (controls.Exit)
            {
                _form.Close();
                Application.Exit();
            }
            _form.Invalidate();
        }

        public void DrawTheGame(Graphics g)//                             DRAW GAME
        {

            foreach (var tile in backgroundTiles)
            {
                tile.DrawMe(g, _zoom);
            }



            if (dude.IsAlive)
            {
                g.DrawString($"Score {Score} - Badguys {alivebadguys} - Treasure: {dude.Treasure} - Ammo: {dude.Ammo} -  Controls: {controls}", SystemFonts.DefaultFont, Brushes.White, 5, 5);
                dude.DrawMe(g, _zoom);
            }
            else
            {
                g.DrawString("YOU DIED!", SystemFonts.DefaultFont, Brushes.DarkRed, 400, 340);
                _form.Close();
                Application.Exit();
            }
            if (alivebadguys == 0)
            {
                g.DrawString("YOU WIN!", SystemFonts.DefaultFont, Brushes.DarkRed, 400, 340);
                System.Threading.Thread.Sleep(2000);
                Application.Exit();
                //_form.NextLevel();
            }


            if (ammopack.IsAlive)
            {
                g.DrawImage(Drawings.AmmopackImage, ammopack.GetRect(_zoom));
            }

            foreach (var gold in golds)
            {
                gold.DrawMe(g, _zoom);
            }

            if (dude.IsAlive)
            {
                foreach (var b in bullets)
                {
                    if (!b.IsDead)
                    {
                        b.DrawMe(g, _zoom);
                    }
                }
            }
            foreach (var b in badGuys)
            {
                if (b.IsAlive)
                {
                    b.DrawMe(g, _zoom);
                }
                else
                {
                    g.DrawImage(Drawings.DeadBadguyImage, b.GetRect(_zoom));
                }
            }

        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            // key is pressed
            if (e.KeyCode == Keys.W)
            {
                controls.Up = true;
            }
            if (e.KeyCode == Keys.S)
            {
                controls.Down = true;
            }
            if (e.KeyCode == Keys.A)
            {
                controls.Left = true;
            }
            if (e.KeyCode == Keys.D)
            {
                controls.Right = true;
            }
            if (e.KeyCode == Keys.F12)
            {
                controls.Death = true;
            }
            if (e.KeyCode == Keys.F11)
            {
                controls.KillAllEnemies = true;

            }
            if (e.KeyCode == Keys.Escape)
            {
                controls.Exit = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                controls.Fire = true;

                if (dude.Ammo > 0)
                {
                    var bullet = new Bullet
                    {
                        X = dude.X,
                        Y = dude.Y
                    };

                    bullet.SetDirectionAndSpeed(dude.LastKnownDirection, 20);

                    bullets.Add(bullet);
                    dude.Ammo--;
                }
            }



        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            // key is released
            if (e.KeyCode == Keys.W)
            {
                controls.Up = false;
            }
            if (e.KeyCode == Keys.S)
            {
                controls.Down = false;
            }
            if (e.KeyCode == Keys.A)
            {
                controls.Left = false;
            }
            if (e.KeyCode == Keys.D)
            {
                controls.Right = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                controls.Fire = false;
            }
        }
    }
}
