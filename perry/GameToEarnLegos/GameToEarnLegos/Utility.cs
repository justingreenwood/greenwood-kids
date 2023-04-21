using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos
{
    public static class Utility
    {


        public static RectangleF FitAndCenterInRect(RectangleF sourceRect, RectangleF containerRect)
        {
            //EXAMPLE: 20x40 is the image
            //---------------------------
            //fit in 500x100
            //500/20=25, 100/40=2 1/2 - zoom to 50x100
            //fit in 100x500
            //100/20=5, 500/40=12 1/2 - zoom to 100x200
            var factor = Math.Min(containerRect.Width / sourceRect.Width, containerRect.Height / sourceRect.Height);
            return new RectangleF(
                containerRect.X + ((containerRect.Width - (sourceRect.Width * factor)) / 2f),
                containerRect.Y + ((containerRect.Height - (sourceRect.Height * factor)) / 2f),
                sourceRect.Width * factor,
                sourceRect.Height * factor);
        }

        public static RectangleF FillInRect(RectangleF sourceRect, RectangleF containerRect)
        {
            //EXAMPLE: 20x40 is the image
            //---------------------------
            //fill in 500x100
            //500/20=25, 100/40=2 1/2 - zoom to 500x1000
            //fit in 100x500
            //100/20=5, 500/40=12 1/2 - zoom to 250x500
            var factor = Math.Max(containerRect.Width / sourceRect.Width, containerRect.Height / sourceRect.Height);
            return new RectangleF(
                containerRect.X - Math.Abs((containerRect.Width - (sourceRect.Width * factor)) / 2f),
                containerRect.Y - Math.Abs((containerRect.Height - (sourceRect.Height * factor)) / 2f),
                sourceRect.Width * factor,
                sourceRect.Height * factor);
        }
    }
}
