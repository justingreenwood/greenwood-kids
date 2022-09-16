using System;
using System.Collections.Generic;
using System.Text;

namespace BallsAndEvents
{
    delegate void BatCallBack(BallEventArgs e);
    class Bat
    {

        private BatCallBack hitBallCallBack;
        public Bat(BatCallBack callBackDelegate) => this.hitBallCallBack = callBackDelegate;
        public void HitTheBall(BallEventArgs e) => hitBallCallBack?.Invoke(e);

    }
}
