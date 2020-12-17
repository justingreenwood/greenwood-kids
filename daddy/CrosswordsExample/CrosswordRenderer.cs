using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace CrosswordsExample
{
    public static class CrosswordRenderer
    {
        public const int SquareSize = 60;
        public static void DrawThePuzzle(CrossWord cw, bool showCheats)
        {
            if (cw == null) return;
            var centerFormat = new StringFormat();
            centerFormat.LineAlignment = StringAlignment.Center;
            centerFormat.Alignment = StringAlignment.Center;

            var font = new Font(FontFamily.GenericSansSerif, SquareSize, FontStyle.Regular, GraphicsUnit.Pixel);
            var tinyFont = new Font(FontFamily.GenericSansSerif, SquareSize/2, FontStyle.Regular, GraphicsUnit.Pixel);
            int w = cw.Width * SquareSize;
            int h = cw.Height * SquareSize;

            using (Bitmap image = new Bitmap(w, h))
            using (Graphics g = Graphics.FromImage(image))
            {
                g.FillRectangle(Brushes.Black, 0, 0, w, h);


                for (var y = 0; y < cw.WordSearchLetters.GetLength(1); y++)
                {
                    for (var x = 0; x < cw.WordSearchLetters.GetLength(0); x++)
                    {
                        var hasWord = cw.HasWord(x, y);
                        if (hasWord)
                        {
                            var sx = x * SquareSize;
                            var sy = y * SquareSize;
                            var word = cw.GetWordIfFirstIndex(x, y);

                            g.FillRectangle(Brushes.White, sx, sy, SquareSize, SquareSize);
                            g.DrawRectangle(Pens.Black, sx, sy, SquareSize, SquareSize);

                            if (showCheats)
                            {
                                g.DrawString($"{cw.WordSearchLetters[x, y]}", font, Brushes.Red, sx+(SquareSize/2), sy + (SquareSize / 2), centerFormat);
                            }
                            else if (word != null)
                            {
                                g.DrawString($"{word.Number}", tinyFont, Brushes.Black, sx+1, sy+1, StringFormat.GenericTypographic);
                            }
                        }
                    }
                    Console.WriteLine();
                }

                image.Save($"mycrossword.png", ImageFormat.Png);

                var process = new ProcessStartInfo()
                {
                    FileName = "mspaint.exe",
                    Arguments = $"mycrossword.png"
                };
                System.Diagnostics.Process.Start(process);
            }
        }
    }
}
