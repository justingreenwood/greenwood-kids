using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Learning
{
    public static class DroppingCrystal
    {
        public static int _zoom = 3;
        public static Random _rand = new Random();
        public static char[,] _level;
        public static Gem[,] _levelCells;
        public static List<Point> _spawners = new List<Point>();
        //public static List<Gem> _gems = new List<Gem>();

        public static void Run()
        {
            int fps = 1;
            int frms = 1000 / fps;
            //Console.SetCursorPosition(0, 0);

            ConsoleKey? lastKeyPressed = null;
            Console.CursorVisible = false;
            var flipper = _rand.Next(1) == 0;

            ReadInGameArray();
            DrawBackground();

            var sw = new Stopwatch();
            do
            {
                sw.Start();
                while (!Console.KeyAvailable)
                {
                    // handle controls!
                    if (lastKeyPressed.HasValue) 
                    {
                        //char tmp = (char)lastKeyPressed.Value;
                        //if (c != tmp && char.IsLetterOrDigit(tmp)) c = tmp;
                        //else if (lastKeyPressed == ConsoleKey.UpArrow && fps < 1000) fps += 1;
                        //else if (lastKeyPressed == ConsoleKey.DownArrow && fps > 1) fps -= 1;

                        frms = 1000 / fps;
                        lastKeyPressed = null;
                    }
                    if (sw.ElapsedMilliseconds >= frms)
                    {
                        DoGemMovementLogic(ref flipper);

                        // Do something
                        //Console.SetCursorPosition(1, 0);
                        //Console.Write(c);
                        RenderGems();

                        sw.Restart();
                    }
                }
                sw.Stop();
            } while ((lastKeyPressed = Console.ReadKey(true).Key) != ConsoleKey.Escape);
            Console.CursorVisible = true;
        }

        public static void DoGemMovementLogic(ref bool flipper)
        {
            // next step - Put all gems in array with everything else. determine movement by checking array.
            // Apply changes to array after movement (to prevent sequential weirdness)
            var columnsBlocked = new List<int>();
            var columnsMoved = new List<int>();
            var gemsNotMovedInRow = new List<Gem>();
            for (var cy = _levelCells.GetLength(1) - 1; cy >= 0; cy--)
            {
                // looping through the rows, bottom to top
                for (var cx = 0; cx < _levelCells.GetLength(0); cx++)
                {
                    var gem = _levelCells[cx, cy];
                    if (gem != null)
                    {
                        int tX = gem.X, tY = gem.Y + 1;
                        var blockedBelow = _level[tX, tY] != '_' || _levelCells[tX, tY] != null;
                        if (blockedBelow)
                        {
                            if (!columnsBlocked.Contains(gem.X)) columnsBlocked.Add(gem.X);
                            gemsNotMovedInRow.Add(gem);
                        }
                        else
                        {
                            if (!columnsMoved.Contains(gem.X)) columnsMoved.Add(gem.X);
                            MoveCell(gem, tX, tY);
                        }
                    }
                }
            }

            //----------------------------------------------------------------------------------------
            // check columns? -- still sucks!
            if (columnsBlocked.Count > 0)
            {
                bool movingUp = true;
                List<int> indexes = new List<int>();
                int cx = 0, leftx = 0, rightx = _levelCells.GetLength(0);
                while (columnsBlocked.Count > 0)
                {
                    if (columnsBlocked.Contains(cx))
                    {
                        movingUp = !movingUp;
                        columnsBlocked.Remove(cx);

                        // looping through the columns
                        for (var cy = 0; cy < _levelCells.GetLength(1); cy++)
                        //for (var cy = _levelCells.GetLength(1) - 1; cy >= 0; cy--)
                        {
                            var gem = _levelCells[cx, cy];
                            if (_level[cx, cy] == '_')
                            {
                                if (!gemsNotMovedInRow.Contains(gem)) break;

                                if (gem != null && gemsNotMovedInRow.Contains(gem))
                                {
                                    bool couldMoveLeft = _level[cx - 1, cy] == '_' && _levelCells[cx - 1, cy] == null,
                                        couldMoveRight = _level[cx + 1, cy] == '_' && _levelCells[cx + 1, cy] == null,
                                        couldMoveDownLeft = couldMoveLeft && _level[cx - 1, cy + 1] == '_' && _levelCells[cx - 1, cy + 1] == null,
                                        couldMoveDownRight = couldMoveRight && _level[cx + 1, cy + 1] == '_' && _levelCells[cx + 1, cy + 1] == null;

                                    bool move = false;
                                    int tX = cx, tY = cy;
                                    if (couldMoveDownLeft || couldMoveDownRight)
                                    {
                                        move = true;

                                        if (couldMoveDownLeft && couldMoveDownRight)
                                        {
                                            couldMoveDownRight = flipper;
                                            couldMoveDownLeft = !flipper;

                                            flipper = !flipper;
                                        }
                                        tX = gem.X + (couldMoveDownRight ? 1 : -1);
                                    }
                                    else if (couldMoveLeft || couldMoveRight)
                                    {
                                        if (gem.X != gem.BirthColumn)
                                        {
                                            if ((gem.X < gem.BirthColumn && couldMoveLeft) || (gem.X > gem.BirthColumn && couldMoveRight))
                                            {
                                                move = true;
                                                tX = gem.X + (couldMoveRight ? 1 : -1);
                                            }
                                        }
                                        else
                                        {
                                            move = true;
                                            if (couldMoveLeft && couldMoveRight)
                                            {
                                                couldMoveLeft = flipper;
                                                couldMoveRight = !flipper;

                                                flipper = !flipper;
                                            }
                                            tX = gem.X + (couldMoveRight ? 1 : -1);
                                        }
                                    }

                                    if (move)
                                    {
                                        MoveCell(gem, tX, tY);

                                        // move down above crap
                                        for (var yy = cy - 1; yy >= 0; yy--)
                                        {
                                            if (_levelCells[cx, yy] != null && _levelCells[cx, yy + 1] == null)
                                            {
                                                MoveCell(_levelCells[cx, yy], cx, yy + 1);
                                            }
                                        }

                                        break;
                                    }
                                }
                            }
                        }
                    }

                    if (movingUp)
                    {
                        leftx++;
                        cx = leftx;
                    }
                    else
                    {
                        rightx--;
                        cx = rightx;
                    }
                }
            }

            // spawn!
            foreach (var spawner in _spawners)
            {
                if (_levelCells[spawner.X, spawner.Y + 1] == null)
                {
                    var gem = new Gem(spawner.X, spawner.Y + 1);
                    //_gems.Insert(0, gem);
                    _levelCells[gem.X, gem.Y] = gem;
                    //Console.SetCursorPosition(gem.X, gem.Y);
                    //Console.BackgroundColor = ConsoleColor.Black;
                    //Console.ForegroundColor = gem.Color;
                    //Console.Write(gem.Character);
                }
            }
        }

        public static void MoveCell(Gem gem, int newX, int newY)
        {
            //Console.SetCursorPosition(gem.X, gem.Y);
            //Console.BackgroundColor = ConsoleColor.Black;
            //Console.Write(' ');
            _levelCells[gem.X, gem.Y] = null;
            gem.X = newX;
            gem.Y = newY;
            _levelCells[gem.X, gem.Y] = gem;
            //Console.SetCursorPosition(gem.X, gem.Y);
            //Console.BackgroundColor = ConsoleColor.Black;
            //Console.ForegroundColor = gem.Color;
            //Console.Write(gem.Character);
        }

        public static void ReadInGameArray()
        {
            int longestLine = 0;
            var lines = new List<string>();
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(Level_01)))
            using (var sr = new StreamReader(ms))
            {
                do
                {
                    var l = sr.ReadLine();
                    longestLine = Math.Max(longestLine, l.Length);
                    lines.Add(l);
                } while (!sr.EndOfStream);
            }

            _level = new char[longestLine, lines.Count];
            _levelCells = new Gem[longestLine, lines.Count];

            if (Console.WindowWidth >= longestLine)
            {
                //int xindent = (Console.WindowWidth - longestLine) / 2;
                //int yindent = (Console.WindowHeight - lines.Count) / 2;
                int xindent = 0, yindent = 0;
                for (int j = 0; j < lines.Count; j++)
                {
                    var l = lines[j];
                    for (int i = 0; i < l.Length; i++)
                    {
                        int x = xindent + i, y = yindent + j;
                        _level[x, y] = l[i];
                        switch (l[i])
                        {
                            case 'S':
                                _spawners.Add(new Point(x, y));
                                break;
                        }
                    }
                }
            }
        }

        private static void DrawBackground(int? left = null, int? top = null, int? right = null, int? bottom = null)
        {
            var draw = false;
            if (HasConsoleSizeChanged)
            {
                draw = true;
                left = 0;
                top = 0;
                //right = Console.WindowWidth;
                //bottom = Console.WindowHeight;
                right = _level.GetLength(0);
                bottom = _level.GetLength(1);
                SetConsoleSize();
            }
            else if (left.HasValue || top.HasValue || right.HasValue || bottom.HasValue)
            {
                draw = true;
                left ??= 0;
                top ??= 0;
                //right ??= Console.WindowWidth;
                //bottom ??= Console.WindowHeight;
                right ??= _level.GetLength(0);
                bottom ??= _level.GetLength(1);
            }

            if (draw)
            {
                //Console.ForegroundColor = (ConsoleColor)(_rand.Next(16));
                for (var y = top.Value; y < bottom; y++)
                {
                    for (var x = left.Value; x < right; x++)
                    {
                        switch (_level[x, y])
                        {
                            case 'W':
                                DrawZoomedTile(x, y, ConsoleColor.White, ConsoleColor.Gray, '#');
                                //Console.SetCursorPosition(x*_zoom, y * _zoom);
                                //Console.BackgroundColor = ConsoleColor.Gray;
                                //Console.ForegroundColor = ConsoleColor.White;
                                //Console.Write("#");
                                break;
                            case 'S':
                                DrawZoomedTile(x, y, ConsoleColor.DarkGray, ConsoleColor.Black, '^');
                                //Console.SetCursorPosition(x * _zoom, y * _zoom);
                                //Console.ForegroundColor = ConsoleColor.DarkGray;
                                //Console.Write("^");
                                break;
                            case '_':
                                DrawZoomedTile(x, y, ConsoleColor.Black, ConsoleColor.Black, ' ');
                                //Console.SetCursorPosition(x * _zoom, y * _zoom);
                                //Console.BackgroundColor = ConsoleColor.Black;
                                //Console.Write(" ");
                                break;
                        }
                    }
                }
            }
        }

        public static void RenderGems()
        {
            for (int x = 0; x < _levelCells.GetLength(0); x++)
            {
                for (int y = 0; y < _levelCells.GetLength(1); y++)
                {
                    var gem = _levelCells[x, y];
                    if (gem?.IsDirty ?? false) // this gem has moved
                    {
                        if (gem.PreviousX.HasValue && gem.PreviousY.HasValue &&
                            _levelCells[gem.PreviousX.Value, gem.PreviousY.Value] == null)
                        {
                            // nothing is where this gem was, so clear it out!
                            DrawZoomedTile(gem.PreviousX.Value, gem.PreviousY.Value, ConsoleColor.Black, ConsoleColor.Black, ' ');
                            //Console.SetCursorPosition(gem.PreviousX.Value * _zoom, gem.PreviousY.Value * _zoom);
                            //Console.BackgroundColor = ConsoleColor.Black;
                            //Console.Write(' ');
                        }

                        DrawZoomedTile(gem);
                        //Console.SetCursorPosition(gem.X * _zoom, gem.Y * _zoom);
                        //Console.BackgroundColor = ConsoleColor.Black;
                        //Console.ForegroundColor = gem.Color;
                        //Console.Write(gem.Character);
                        gem.MarkClean();
                    }
                }
            }
        }

        public static void DrawZoomedTile(Gem gem)
        {
            DrawZoomedTile(gem.X, gem.Y, gem.Color, gem.BackgroundColor, gem.Character);
        }
        public static void DrawZoomedTile(int x, int y, ConsoleColor color, ConsoleColor bgColor, char c)
        {
            for (var x2add = 0; x2add < _zoom; x2add++)
            {
                for (var y2add = 0; y2add < _zoom; y2add++)
                {
                    Console.SetCursorPosition((x * _zoom) + x2add, (y * _zoom) + y2add);
                    Console.BackgroundColor = bgColor;
                    Console.ForegroundColor = color;
                    Console.Write(c);
                }
            }
        }

        private static Size SavedConsoleSize;

        public static bool HasConsoleSizeChanged => SavedConsoleSize?.W != Console.WindowWidth || SavedConsoleSize?.H != Console.WindowHeight;

        public static void SetConsoleSize() => SavedConsoleSize = new Size(Console.WindowWidth, Console.WindowHeight);

        public static readonly string Level_02 =
@"
   S
  W_W
 W___W
W_____W
W_____W
 W___W
  W_W
   W
   
";
        public static readonly string Level_01 =
@"
   SSSSSSSSS
  W_________W
 W___________W
W_____________W
W_____________W
W______W______W
 W____W W____W
  W__W   W__W
   WW     WW
";
    }
}
