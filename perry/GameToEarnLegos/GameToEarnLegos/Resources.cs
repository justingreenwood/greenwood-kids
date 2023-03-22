using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos
{
    public static class Resources
    {
        public static Bitmap Image_Wall = new Bitmap(@"Resources\Images\Wall.png");
        public static Bitmap Image_IntroBackground = new Bitmap(@"Resources\Images\BackGround.png");
        public static Bitmap Image_Border = new Bitmap(@"Resources\Images\PerrysArtBorder.png");

        public static Bitmap Image_Tree1 = new Bitmap(@"Resources\Images\PerrysArtTree1.png");
        public static Bitmap Image_Tree2 = new Bitmap(@"Resources\Images\PerrysArtChristmasTree.png");
        public static Bitmap Image_TreeBurned = new Bitmap(@"Resources\Images\BurnedTree.png");
        public static Bitmap Image_TreeOnFire = new Bitmap(@"Resources\Images\TreeOnFire.png");


        public static Bitmap Image_Ammo = new Bitmap(@"Resources\Images\Weapon.png");
        public static Bitmap Image_WaterAmmo = new Bitmap(@"Resources\Images\WaterAmmo.png");
        public static Bitmap Image_BadguyFireAmmo = new Bitmap(@"Resources\Images\BadguyFireAmmo.png");
        public static Bitmap Image_AmmoPack = new Bitmap(@"Resources\Images\Ammopack.png");

        public static Bitmap Image_MenuBackground = new Bitmap(@"Resources\Images\MenuBackground.png");

        public static Bitmap Image_DeadBadguy = new Bitmap(@"Resources\Images\Badguy\DeadBadguy.png");
        public static Bitmap Image_DeadTowerBadguy = new Bitmap(@"Resources\Images\Badguy\DeadTowerBadguy.png");
        public static Bitmap Image_TowerBadguy = new Bitmap(@"Resources\Images\Badguy\TowerBadguy.png");

        public static Bitmap Image_NormalWater = new Bitmap(@"Resources\Images\NormalWater.png");
        public static Bitmap Image_Sand = new Bitmap(@"Resources\Images\Sand.png");
        public static Bitmap Image_Grass = new Bitmap(@"Resources\Images\Grass\Grass.png");
        public static Bitmap Image_Treasure = new Bitmap(@"Resources\Images\TreasureChest.png");

        public static Bitmap Image_ClosedDoor_Wide = new Bitmap(@"Resources\Images\BlandDoor.png");
        public static Bitmap Image_OpenDoor_Wide = new Bitmap(@"Resources\Images\BlandDoorOpen.png");

        public static Bitmap Image_ClosedDoor_Thin = new Bitmap(@"Resources\Images\BlandDoorThin.png");
        public static Bitmap Image_OpenDoor_Thin = new Bitmap(@"Resources\Images\BlandDoorThinOpen.png");

        public static Bitmap Image_Water = new Bitmap(@"Resources\Images\SmartWater\SmartWaterBase.png");
        public static Bitmap Image_DeepWater = new Bitmap(@"Resources\Images\SmartWater\DeepWater.png");


        public static Bitmap Image_WaterLeft = new Bitmap(@"Resources\Images\SmartWater\SmartWaterLeftGrass.png");
        public static Bitmap Image_WaterTop = new Bitmap(@"Resources\Images\SmartWater\SmartWaterTopGrass.png");
        public static Bitmap Image_WaterBottom = new Bitmap(@"Resources\Images\SmartWater\SmartWaterDownGrass.png");
        public static Bitmap Image_WaterLeftRight = new Bitmap(@"Resources\Images\SmartWater\SmartWaterLeftRightGrass.png");
        public static Bitmap Image_WaterTopLeftRight = new Bitmap(@"Resources\Images\SmartWater\SmartWaterTopLeftRightGrass.png");
        public static Bitmap Image_WaterBottomLeftRight = new Bitmap(@"Resources\Images\SmartWater\SmartWaterBottomLeftRightGrass.png");
        public static Bitmap Image_WaterTopBottom = new Bitmap(@"Resources\Images\SmartWater\SmartWaterTopBottomGrass.png");
        
        public static Bitmap Image_WaterTopBottomLeft = new Bitmap(@"Resources\Images\SmartWater\SmartWaterTopBottomLeftGrass.png");
        public static Bitmap Image_WaterTopLeft = new Bitmap(@"Resources\Images\SmartWater\SmartWaterTopLeftGrass.png");
        public static Bitmap Image_WaterBottomLeft = new Bitmap(@"Resources\Images\SmartWater\SmartWaterBottomLeftGrass.png");


        //public static Bitmap Image_WaterLeftRightUpDown = new Bitmap(@"Resources\Images\SmartWater\SmartWaterTopBottomLeftRightGrass.png");


        public static Bitmap Image_WaterTopRight = RotateImage(Image_WaterTopLeft);
        public static Bitmap Image_WaterBottomRight = RotateImage(Image_WaterBottomLeft);
        public static Bitmap Image_WaterRight = RotateImage(Image_WaterLeft);
        public static Bitmap Image_WaterTopBottomRight = RotateImage(Image_WaterTopBottomLeft);


        public static Bitmap Image_Player = new Bitmap(@"Resources\Images\Player\Idle\Player_1.png");

        public static Bitmap Image_Player_Fire = new Bitmap(@"Resources\Images\Player\Fire\PlayerOnFire.png");


        public static Bitmap Image_Player_Idle_1 = new Bitmap(@"Resources\Images\Player\Idle\Player_1.png");
        public static Bitmap Image_Player_Idle_2 = new Bitmap(@"Resources\Images\Player\Idle\Player_2.png");
        public static Bitmap Image_Player_Idle_3 = new Bitmap(@"Resources\Images\Player\Idle\Player_3.png");
        public static Bitmap Image_Player_Idle_4 = new Bitmap(@"Resources\Images\Player\Idle\Player_4.png");
        public static Bitmap Image_Player_Idle_5 = new Bitmap(@"Resources\Images\Player\Idle\Player_5.png");
        public static Bitmap Image_Player_Idle_6 = new Bitmap(@"Resources\Images\Player\Idle\Player_6.png");
        public static Bitmap Image_Player_Idle_7 = new Bitmap(@"Resources\Images\Player\Idle\Player_7.png");
        public static Bitmap Image_Player_Idle_8 = new Bitmap(@"Resources\Images\Player\Idle\Player_8.png");

        public static Bitmap Image_Player_Right_1 = new Bitmap(@"Resources\Images\Player\Player_Right_1.png");
        public static Bitmap Image_Player_Right_2 = new Bitmap(@"Resources\Images\Player\Player_Right_2.png");
        public static Bitmap Image_Player_Right_3 = new Bitmap(@"Resources\Images\Player\Player_Right_3.png");
        public static Bitmap Image_Player_Right_4 = new Bitmap(@"Resources\Images\Player\Player_Right_4.png");
        public static Bitmap Image_Player_Right_5 = new Bitmap(@"Resources\Images\Player\Player_Right_5.png");
        public static Bitmap Image_Player_Right_6 = new Bitmap(@"Resources\Images\Player\Player_Right_6.png");
        public static Bitmap Image_Player_Right_7 = new Bitmap(@"Resources\Images\Player\Player_Right_7.png");
        public static Bitmap Image_Player_Right_8 = new Bitmap(@"Resources\Images\Player\Player_Right_8.png");

        public static Bitmap Image_Player_Right_Fire_1 = new Bitmap(@"Resources\Images\Player\Fire\Player_Right_Fire_1.png");
        public static Bitmap Image_Player_Right_Fire_2 = new Bitmap(@"Resources\Images\Player\Fire\Player_Right_Fire_2.png");
        public static Bitmap Image_Player_Right_Fire_3 = new Bitmap(@"Resources\Images\Player\Fire\Player_Right_Fire_3.png");
        public static Bitmap Image_Player_Right_Fire_4 = new Bitmap(@"Resources\Images\Player\Fire\Player_Right_Fire_4.png");
        public static Bitmap Image_Player_Right_Fire_5 = new Bitmap(@"Resources\Images\Player\Fire\Player_Right_Fire_5.png");
        public static Bitmap Image_Player_Right_Fire_6 = new Bitmap(@"Resources\Images\Player\Fire\Player_Right_Fire_6.png");
        public static Bitmap Image_Player_Right_Fire_7 = new Bitmap(@"Resources\Images\Player\Fire\Player_Right_Fire_7.png");
        public static Bitmap Image_Player_Right_Fire_8 = new Bitmap(@"Resources\Images\Player\Fire\Player_Right_Fire_8.png");

        public static Bitmap Image_Player_Back_1 = new Bitmap(@"Resources\Images\Player\Player_Back_1.png");
        public static Bitmap Image_Player_Back_2 = new Bitmap(@"Resources\Images\Player\Player_Back_2.png");

        public static Bitmap Image_Player_Back_Fire_1 = new Bitmap(@"Resources\Images\Player\Fire\Player_Back_Fire_1.png");
        public static Bitmap Image_Player_Back_Fire_2 = new Bitmap(@"Resources\Images\Player\Fire\Player_Back_Fire_2.png");

        public static Bitmap Image_Player_Forward_1 = new Bitmap(@"Resources\Images\Player\Player_Forward_1.png");
        public static Bitmap Image_Player_Forward_2 = new Bitmap(@"Resources\Images\Player\Player_Forward_2.png");

        public static Bitmap Image_Player_Forward_Fire_1 = new Bitmap(@"Resources\Images\Player\Fire\Player_Forward_Fire_1.png");
        public static Bitmap Image_Player_Forward_Fire_2 = new Bitmap(@"Resources\Images\Player\Fire\Player_Forward_Fire_2.png");

        public static Bitmap Image_Badguy = new Bitmap(@"Resources\Images\Badguy\BadguyUpgraded2.png");

        public static Bitmap Image_Badguy_Right_1 = new Bitmap(@"Resources\Images\Badguy\Badguy2_1.png");
        public static Bitmap Image_Badguy_Right_2 = new Bitmap(@"Resources\Images\Badguy\Badguy2_2.png");
        public static Bitmap Image_Badguy_Right_3 = new Bitmap(@"Resources\Images\Badguy\Badguy2_3.png");
        public static Bitmap Image_Badguy_Right_4 = new Bitmap(@"Resources\Images\Badguy\Badguy2_4.png");

        public static Bitmap Image_Badguy_Up_1 = new Bitmap(@"Resources\Images\Badguy\BadguyUp_1.png");
        public static Bitmap Image_Badguy_Up_2 = new Bitmap(@"Resources\Images\Badguy\BadguyUp_2.png");

        public static Bitmap Image_Badguy_Down_1 = new Bitmap(@"Resources\Images\Badguy\BadguyForward_1.png");
        public static Bitmap Image_Badguy_Down_2 = new Bitmap(@"Resources\Images\Badguy\BadguyForward_2.png");

        public static Bitmap RotateImage(Bitmap srcImage)
        {
            //Clone it to another bitmap
            Bitmap image2 = (Bitmap)srcImage.Clone();
            //Rotating
            image2.RotateFlip(RotateFlipType.RotateNoneFlipX);
            return image2;
        }

    }
}
