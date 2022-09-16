using System;
using System.Collections.Generic;
using System.Text;

namespace BallsAndEvents
{
    class Ball
    {

        public event EventHandler<BallEventArgs> BallInPlay;

        protected void OnBallInPlay(BallEventArgs e) => BallInPlay?.Invoke(this, e);
        public Bat GetNewBat() => new Bat(new BatCallBack(OnBallInPlay));

    }

    class BallEventArgs : EventArgs
    {
        public int Angle { get; private set; }
        public int Distance { get; private set; }

        public BallEventArgs(int angle, int distance)
        {
            this.Angle = angle;
            this.Distance = distance;
        }
    }

    class Pitcher
    {
        public Pitcher(Ball ball) => ball.BallInPlay += BallInPlayEventHandler;
        private int pitchNumber = 0;
        void BallInPlayEventHandler(object sender,BallEventArgs e)
        {
            pitchNumber++;
                if((e.Distance>95)&& (e.Angle < 60))
                {
                    Console.WriteLine($"Pitchnumber #{pitchNumber} : I caught the ball.");
                }
                else
                {
                    Console.WriteLine($"Pitchnumber #{pitchNumber} : I covered first base.");
                }
        }

    }
    class Fan
    {
        public Fan(Ball ball) => ball.BallInPlay += BallInPlayEventHandler;
        private int pitchNumber = 0;
        void BallInPlayEventHandler(object sender, EventArgs e)
        {
            pitchNumber++;
            if (e is BallEventArgs ballEventArgs)
            {
                if ((ballEventArgs.Distance > 400) && (ballEventArgs.Angle > 30))
                {
                    Console.WriteLine($"Pitchnumber #{pitchNumber} : Home Run! I am going for the ball!");
                }
                else
                {
                    Console.WriteLine($"Pitchnumber #{pitchNumber} : Woo hoo! Yeah!");
                }
            }
        }
    }

}
