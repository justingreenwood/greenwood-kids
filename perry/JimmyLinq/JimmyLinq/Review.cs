using System;
using System.Collections.Generic;
using System.Text;

namespace JimmyLinq
{
    class Review
    {
        public int Issue;
        public Critics Critic;
        public double Score;
    }

    enum Critics
    {
        MuddyCritic,
        RottenTornadoes,
    }

    enum PriceRange
    {
        Cheap,
        Expensive,
    }


}
