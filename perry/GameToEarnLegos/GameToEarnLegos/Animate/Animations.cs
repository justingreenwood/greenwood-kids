using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameToEarnLegos.Animate
{

    public static class Animations
    {
        public static Animation PlayerDown = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame
                {
                    Image = Resources.Image_Player_Forward_1,
                    Duration = 4
                },
                new AnimationFrame
                {
                    Image = Resources.Image_Player_Forward_2,
                    Duration = 4
                },
            }
        };
        public static Animation PlayerDownFire = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame
                {
                    Image = Resources.Image_Player_Forward_Fire_1,
                    Duration = 4
                },
                new AnimationFrame
                {
                    Image = Resources.Image_Player_Forward_Fire_2,
                    Duration = 4
                },
            }
        };
        public static Animation PlayerUp = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame
                {
                    Image = Resources.Image_Player_Back_1,
                    Duration = 4
                },
                new AnimationFrame
                {
                    Image = Resources.Image_Player_Back_2,
                    Duration = 4
                },
            }
        };
        public static Animation PlayerUpFire = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame
                {
                    Image = Resources.Image_Player_Back_Fire_1,
                    Duration = 4
                },
                new AnimationFrame
                {
                    Image = Resources.Image_Player_Back_Fire_2,
                    Duration = 4
                },
            }
        };
        public static Animation PlayerIdle = new Animation
        {
            Repeat = false,
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame { Image = Resources.Image_Player_Idle_1, Duration = 1 },
                new AnimationFrame { Image = Resources.Image_Player_Idle_2, Duration = 3 },
                new AnimationFrame { Image = Resources.Image_Player_Idle_3, Duration = 3 },
                new AnimationFrame { Image = Resources.Image_Player_Idle_4, Duration = 3 },
                new AnimationFrame { Image = Resources.Image_Player_Idle_5, Duration = 3 },
                new AnimationFrame { Image = Resources.Image_Player_Idle_6, Duration = 3 },
                new AnimationFrame { Image = Resources.Image_Player_Idle_7, Duration = 3 },
                new AnimationFrame { Image = Resources.Image_Player_Idle_8, Duration = 3 },
            }
        };
        public static Animation PlayerRight = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame { Image = Resources.Image_Player_Right_1, Duration = 1 },
                new AnimationFrame { Image = Resources.Image_Player_Right_2, Duration = 1 },
                new AnimationFrame { Image = Resources.Image_Player_Right_3, Duration = 1 },
                new AnimationFrame { Image = Resources.Image_Player_Right_4, Duration = 1 },
                new AnimationFrame { Image = Resources.Image_Player_Right_5, Duration = 1 },
                new AnimationFrame { Image = Resources.Image_Player_Right_6, Duration = 1 },
                new AnimationFrame { Image = Resources.Image_Player_Right_7, Duration = 1 },
                new AnimationFrame { Image = Resources.Image_Player_Right_8, Duration = 1 },
            }
        };
        public static Animation PlayerRightFire = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame { Image = Resources.Image_Player_Right_Fire_1, Duration = 1 },
                new AnimationFrame { Image = Resources.Image_Player_Right_Fire_2, Duration = 1 },
                new AnimationFrame { Image = Resources.Image_Player_Right_Fire_3, Duration = 1 },
                new AnimationFrame { Image = Resources.Image_Player_Right_Fire_4, Duration = 1 },
                new AnimationFrame { Image = Resources.Image_Player_Right_Fire_5, Duration = 1 },
                new AnimationFrame { Image = Resources.Image_Player_Right_Fire_6, Duration = 1 },
                new AnimationFrame { Image = Resources.Image_Player_Right_Fire_7, Duration = 1 },
                new AnimationFrame { Image = Resources.Image_Player_Right_Fire_8, Duration = 1 },
            }
        };
        public static Animation PlayerLeftFire = AnimationHelper.FlipX(PlayerRightFire);
        public static Animation PlayerLeft = AnimationHelper.FlipX(PlayerRight);
        public static Animation BadguyRight = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame { Image = Resources.Image_Badguy_Right_1, Duration = 2 },
                new AnimationFrame { Image = Resources.Image_Badguy_Right_2, Duration = 2 },
                new AnimationFrame { Image = Resources.Image_Badguy_Right_3, Duration = 2 },
                new AnimationFrame { Image = Resources.Image_Badguy_Right_4, Duration = 2 },
            }
        };
        public static Animation BadguyLeft = AnimationHelper.FlipX(BadguyRight);
        public static Animation BadguyDown = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame{ Image = Resources.Image_Badguy_Down_1, Duration = 4 },
                new AnimationFrame{ Image = Resources.Image_Badguy_Down_2, Duration = 4 },
            }
        };
        public static Animation BadguyUp = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame{ Image = Resources.Image_Badguy_Up_1, Duration = 4 },
                new AnimationFrame{ Image = Resources.Image_Badguy_Up_2, Duration = 4 },
            }
        };
        public static Animation BadguyKingRight = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame { Image = Resources.Image_BadguyKing_Right_1, Duration = 2 },
                new AnimationFrame { Image = Resources.Image_BadguyKing_Right_2, Duration = 2 },
                new AnimationFrame { Image = Resources.Image_BadguyKing_Right_3, Duration = 2 },
                new AnimationFrame { Image = Resources.Image_BadguyKing_Right_4, Duration = 2 },
            }
        };
        public static Animation BadguyKingLeft = AnimationHelper.FlipX(BadguyKingRight);
        public static Animation BadguyKingDown = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame{ Image = Resources.Image_BadguyKing_Down_1, Duration = 4 },
                new AnimationFrame{ Image = Resources.Image_BadguyKing_Down_2, Duration = 4 },
            }
        };
        public static Animation BadguyKingUp = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame{ Image = Resources.Image_BadguyKing_Up_1, Duration = 4 },
                new AnimationFrame{ Image = Resources.Image_BadguyKing_Up_2, Duration = 4 },
            }
        };

        public static Animation DragonRight = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame { Image = Resources.Image_DragonRight, Duration = 8 },

            }
        };
        public static Animation DragonLeft = AnimationHelper.FlipX(DragonRight);
        public static Animation DragonDown = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame{ Image = Resources.Image_DragonDown, Duration = 8 },
            }
        };
        public static Animation DragonUp = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame{ Image = Resources.Image_DragonUp, Duration = 8 },
            }
        };
        public static Animation DragonUpRight = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame { Image = Resources.Image_DragonUpRight, Duration = 8 },

            }
        };
        public static Animation DragonUpLeft = AnimationHelper.FlipX(DragonUpRight);
        public static Animation DragonDownRight = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame{ Image = Resources.Image_DragonDownRight, Duration = 8 },
            }
        };
        public static Animation DragonDownLeft = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame{ Image = Resources.Image_DragonDownLeft, Duration = 8 },
            }
        };

        public static Animation BadguyKingSnowRight = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame { Image = Resources.Image_BadguyKing_Snow_Right_1, Duration = 4 },
                new AnimationFrame { Image = Resources.Image_BadguyKing_Snow_Right_2, Duration = 4 },
            }
        };
        public static Animation BadguyKingSnowLeft = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame { Image = Resources.Image_BadguyKing_Snow_Left_1, Duration = 4 },
                new AnimationFrame { Image = Resources.Image_BadguyKing_Snow_Left_2, Duration = 4 },
            }
        };
        public static Animation BadguyKingSnowDown = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame{ Image = Resources.Image_BadguyKing_Snow_Down_1, Duration = 4 },
                new AnimationFrame{ Image = Resources.Image_BadguyKing_Snow_Down_2, Duration = 4 },
            }
        };
        public static Animation BadguyKingSnowUp = new Animation
        {
            Frames = new List<AnimationFrame>
            {
                new AnimationFrame{ Image = Resources.Image_BadguyKing_Snow_Up_1, Duration = 4 },
                new AnimationFrame{ Image = Resources.Image_BadguyKing_Snow_Up_2, Duration = 4 },
            }
        };







    }

    public static class AnimationHelper
    {
        public static Animation FlipX(Animation source)
        {
            var dest = new Animation
            {
                Frames = new List<AnimationFrame>()
            };
            foreach (var srcframe in source.Frames)
            {
                dest.Frames.Add(new AnimationFrame
                {
                    Duration = srcframe.Duration,
                    Image = FlipImageX(srcframe.Image)
                });
            }
            return dest;
        }

        public static Bitmap FlipImageX(Bitmap srcImage)
        {
            //Clone it to another bitmap
            Bitmap image2 = (Bitmap)srcImage.Clone();
            //Mirroring
            image2.RotateFlip(RotateFlipType.RotateNoneFlipX);
            return image2;
        }
    }
}
