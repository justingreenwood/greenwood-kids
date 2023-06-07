using GameToEarnLegos.Badguys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos
{
    public static class Utility
    {
        public static EightWayDirection Get8WayDirection(float hSpeed, float vSpeed, EightWayDirection currentDirection)
        {
            var west = (hSpeed < 0);
            var east = (hSpeed > 0);
            var north = (vSpeed < 0);
            var south = (vSpeed > 0);
            var stationary = (!west && !east && !north && !south);
            var horizontalDominant = Math.Abs(hSpeed) > Math.Abs(vSpeed);

            var directionRatio = Math.Min(Math.Abs(hSpeed), Math.Abs(vSpeed)) / Math.Max(Math.Abs(hSpeed), Math.Abs(vSpeed));
            var isDiagnal = directionRatio > 0.333f;


            if (stationary)
                return currentDirection;
            else
            {
                if (isDiagnal)
                {
                    if (west && north) return EightWayDirection.NorthWest;
                    else if (east && north) return EightWayDirection.NorthEast;
                    else if (west && south) return EightWayDirection.SouthWest;
                    else if (east && south) return EightWayDirection.SouthEast;
                }
                else
                {
                    if (north && !horizontalDominant) return EightWayDirection.North;
                    else if (south && !horizontalDominant) return EightWayDirection.South;
                    else if (east && horizontalDominant) return EightWayDirection.East;
                    else if (west && horizontalDominant) return EightWayDirection.West;
                }
            }
            return currentDirection;

        }

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

    public enum EightWayDirection
    {
        North, South, East, West, NorthEast, NorthWest, SouthEast, SouthWest
    }
}
