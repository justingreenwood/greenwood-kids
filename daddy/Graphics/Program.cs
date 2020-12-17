using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace GraphicsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var myImage = new Bitmap(1000, 1000))
            using (var g = Graphics.FromImage(myImage))
            {
                var testBrush = new SolidBrush(Color.FromArgb(128, 23, 123, 254));


                g.FillRectangle(Brushes.Red, 0, 0, 1000, 1000);

                g.DrawImage(new Bitmap(@"C:\Users\green\OneDrive\Pictures\Untitled.png"), 10, 10);

                g.FillEllipse(testBrush, 20, 20, 200, 200);
                g.DrawEllipse(Pens.Chocolate, 20, 20, 200, 200);

                myImage.Save(@"C:\Users\green\OneDrive\Desktop\poop.png", ImageFormat.Png);
            }

            /*
            var name = "perry";
            var s1 = "this is traditional\r\n " + name + " - \" \\ ";
            var s2 = $"this is traditional\r\n {name} - \" \\ ";
            var s3 = @"this is traditional
" + name + @" - "" \ ";*/
        }
    }
}
