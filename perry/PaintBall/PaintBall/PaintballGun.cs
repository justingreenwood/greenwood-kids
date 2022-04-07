using System;
using System.Collections.Generic;
using System.Text;

namespace PaintBall
{
    class PaintballGun
    {



        public int magazineSize { get; private set; } = 16;
        private int balls = 0;
        public int ballsLoaded { get;private set; }

        public bool IsEmpty() { return ballsLoaded == 0; }

        public PaintballGun(int balls, int MagazineSize, bool loaded)
        {
            this.balls = balls;
            magazineSize = MagazineSize;
            if (!loaded) Reload();
        }

        public int Balls
        {
            get { return balls; }
            set
            {
                if (value > 0)
                {
                    balls = value;
                }
                Reload();
            }
        }

        public void Reload()
        {

            if (balls > magazineSize)
            {
                ballsLoaded = magazineSize;
            }
            else
            {
                ballsLoaded = balls;
            }

        }

        public bool Shoot()
        {
            if(ballsLoaded == 0)
            {
                return false;
            }
            balls--;
            ballsLoaded--;
            return true;
        }



    }
}
