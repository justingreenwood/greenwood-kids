using System;

namespace BallsAndEvents
{
    class Program
    {
        static readonly Ball ball = new Ball();
        static readonly Pitcher pitcher = new Pitcher(ball);
        static readonly Fan fan = new Fan(ball);

        static void Main(string[] args)
        {
            bool isPlaying = true;
            while (isPlaying)
            {
                Console.WriteLine("Enter a number for the angle. (Or anything else to quit.)");
                string angleString = Console.ReadLine();
                if(int.TryParse(angleString, out int angle))
                {
                    Console.WriteLine("Enter a number for the distance. (Or anything else to quit.)");
                    if(int.TryParse(Console.ReadLine(), out int distance))
                    {
                        BallEventArgs ballEventArgs = new BallEventArgs(angle, distance);
                        var bat = ball.GetNewBat();
                        bat.HitTheBall(ballEventArgs);
                    }
                    else
                    {
                        isPlaying = false;
                    }

                }
                else
                {
                    isPlaying = false;
                }


            }


        }
    }
}
