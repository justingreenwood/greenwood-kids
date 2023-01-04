using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Animate
{
    public class Animation
    {
        public bool Repeat { get; set; } = true;
        public int NextIndex(int currentIndex)
        {
            if (currentIndex < Frames.Count - 1) return currentIndex + 1;
            
            return Repeat ? 0 : currentIndex;
        }
        public List<AnimationFrame> Frames { get; set; }
    }
}
