using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos
{
    public static class Resources
    {
        public static MemoryStream Music_InMenu = new MemoryStream(File.ReadAllBytes(@"Resources\Audio\ButtmunchiansForGame.mp3"));
        public static MemoryStream Music_InGame = new MemoryStream(File.ReadAllBytes(@"Resources\Audio\Adventure Begins.mp3"));
        public static MemoryStream Music_InLastLevel = new MemoryStream(File.ReadAllBytes(@"Resources\Audio\Elwood - Dead lock.mp3"));
        //public static MemoryStream NotUsedMusic_InGame = new MemoryStream(File.ReadAllBytes(@"Resources\Audio\Purely Grey - KASTET.mp3"));
        public static MemoryStream Sound_Shoot = new MemoryStream(File.ReadAllBytes(@"Resources\Audio\shoot-sound-001.wav"));
        public static MemoryStream Sound_Bleah = new MemoryStream(File.ReadAllBytes(@"Resources\Audio\bleah.wav"));
        public static MemoryStream Sound_OhYeah = new MemoryStream(File.ReadAllBytes(@"Resources\Audio\ohyeabeautiful.wav"));
        public static MemoryStream Sound_Chl = new MemoryStream(File.ReadAllBytes(@"Resources\Audio\CHL.wav"));
        public static MemoryStream Sound_Wfff = new MemoryStream(File.ReadAllBytes(@"Resources\Audio\Wffff.wav"));
        public static MemoryStream Sound_RefillWater = new MemoryStream(File.ReadAllBytes(@"Resources\Audio\BOLS2.wav"));
        public static MemoryStream Sound_Errr = new MemoryStream(File.ReadAllBytes(@"Resources\Audio\Err.wav"));
        public static MemoryStream Sound_ChChh = new MemoryStream(File.ReadAllBytes(@"Resources\Audio\ChChh.wav"));
        public static MemoryStream Sound_JingleBells = new MemoryStream(File.ReadAllBytes(@"Resources\Audio\jingle-bells.mp3"));

        public static Bitmap Image_Wall = new Bitmap(@"Resources\Images\Building Blocks\Wall.png");
        public static Bitmap Image_Border = new Bitmap(@"Resources\Images\Building Blocks\PerrysArtBorder.png");
        public static Bitmap Image_Title = new Bitmap(@"Resources\Images\Menu Images\Title.png");
        public static Bitmap Image_Fire = new Bitmap(@"Resources\Images\Building Blocks\FirePlace.png");
        public static Bitmap Image_FireOut = new Bitmap(@"Resources\Images\Building Blocks\FirePlaceOut.png");

        public static Bitmap Image_Tree1 = new Bitmap(@"Resources\Images\Trees\PerrysArtTree1.png");
        public static Bitmap Image_TreeBurned = new Bitmap(@"Resources\Images\Trees\BurnedTree.png");
        public static Bitmap Image_TreeOnFire = new Bitmap(@"Resources\Images\Trees\TreeOnFire.png");
        public static Bitmap Image_Tree2 = new Bitmap(@"Resources\Images\Trees\PerrysArtChristmasTree.png");
        public static Bitmap Image_Tree2OnFire = new Bitmap(@"Resources\Images\Trees\ChristmasTreeOnFire.png");
        public static Bitmap Image_Tree2Burned = new Bitmap(@"Resources\Images\Trees\ChristmasTreeBurned.png");

        public static Bitmap Image_Ammo = new Bitmap(@"Resources\Images\Weapon.png");
        public static Bitmap Image_WaterAmmo = new Bitmap(@"Resources\Images\WaterAmmo.png");
        public static Bitmap Image_BadguyFireAmmo = new Bitmap(@"Resources\Images\BadguyFireAmmo.png");
        public static Bitmap Image_AmmoPack = new Bitmap(@"Resources\Images\Ammopack.png");

        public static Bitmap Image_MenuBackground = new Bitmap(@"Resources\Images\Menu Images\MenuBackground.png");
        public static Bitmap Image_MenuBackgroundSnow = new Bitmap(@"Resources\Images\Menu Images\MenuBackgroundSnow.png");

        public static Bitmap Image_DeadBadguy = new Bitmap(@"Resources\Images\Badguy\DeadBadguy.png");
        public static Bitmap Image_DeadTowerBadguy = new Bitmap(@"Resources\Images\Badguy\DeadTowerBadguy.png");
        public static Bitmap Image_TowerBadguy = new Bitmap(@"Resources\Images\Badguy\TowerBadguy.png");

        public static Bitmap Image_Sand = new Bitmap(@"Resources\Images\Sand.png");
        public static Bitmap Image_Grass = new Bitmap(@"Resources\Images\Grass\Grass.png");
        public static Bitmap Image_Grass2 = new Bitmap(@"Resources\Images\Grass\SnowGrass.png");
        public static Bitmap Image_Treasure = new Bitmap(@"Resources\Images\TreasureChest.png");

        public static Bitmap Image_ClosedDoor_Wide = new Bitmap(@"Resources\Images\Building Blocks\BlandDoor.png");
        public static Bitmap Image_OpenDoor_Wide = new Bitmap(@"Resources\Images\Building Blocks\BlandDoorOpen.png");

        public static Bitmap Image_ClosedDoor_Thin = new Bitmap(@"Resources\Images\Building Blocks\BlandDoorThin.png");
        public static Bitmap Image_OpenDoor_Thin = new Bitmap(@"Resources\Images\Building Blocks\BlandDoorThinOpen.png");

        public static Bitmap Image_Water = new Bitmap(@"Resources\Images\SmartWater\SmartWaterBase.png");
        public static Bitmap Image_DeepWater = new Bitmap(@"Resources\Images\SmartWater\DeepWater.png");


        public static Bitmap Image_WaterLeft = new Bitmap(@"Resources\Images\SmartWater\Grass\SmartWaterLeftGrass.png");
        public static Bitmap Image_WaterTop = new Bitmap(@"Resources\Images\SmartWater\Grass\SmartWaterTopGrass.png");
        public static Bitmap Image_WaterBottom = new Bitmap(@"Resources\Images\SmartWater\Grass\SmartWaterDownGrass.png");
        public static Bitmap Image_WaterLeftRight = new Bitmap(@"Resources\Images\SmartWater\Grass\SmartWaterLeftRightGrass.png");
        public static Bitmap Image_WaterTopLeftRight = new Bitmap(@"Resources\Images\SmartWater\Grass\SmartWaterTopLeftRightGrass.png");
        public static Bitmap Image_WaterBottomLeftRight = new Bitmap(@"Resources\Images\SmartWater\Grass\SmartWaterBottomLeftRightGrass.png");
        public static Bitmap Image_WaterTopBottom = new Bitmap(@"Resources\Images\SmartWater\Grass\SmartWaterTopBottomGrass.png");        
        public static Bitmap Image_WaterTopBottomLeft = new Bitmap(@"Resources\Images\SmartWater\Grass\SmartWaterTopBottomLeftGrass.png");
        public static Bitmap Image_WaterTopLeft = new Bitmap(@"Resources\Images\SmartWater\Grass\SmartWaterTopLeftGrass.png");
        public static Bitmap Image_WaterBottomLeft = new Bitmap(@"Resources\Images\SmartWater\Grass\SmartWaterBottomLeftGrass.png");
        public static Bitmap Image_WaterTopRight = FlipXImage(Image_WaterTopLeft);
        public static Bitmap Image_WaterBottomRight = FlipXImage(Image_WaterBottomLeft);
        public static Bitmap Image_WaterRight = FlipXImage(Image_WaterLeft);
        public static Bitmap Image_WaterTopBottomRight = FlipXImage(Image_WaterTopBottomLeft);

        public static Bitmap Image_WaterLeftBlank = new Bitmap(@"Resources\Images\SmartWater\Blank\SmartWaterLeft.png");
        public static Bitmap Image_WaterTopBlank = new Bitmap(@"Resources\Images\SmartWater\Blank\SmartWaterTop.png");
        public static Bitmap Image_WaterBottomBlank = new Bitmap(@"Resources\Images\SmartWater\Blank\SmartWaterBottom.png");
        public static Bitmap Image_WaterLeftRightBlank = new Bitmap(@"Resources\Images\SmartWater\Blank\SmartWaterLeftRight.png");
        public static Bitmap Image_WaterTopLeftRightBlank = new Bitmap(@"Resources\Images\SmartWater\Blank\SmartWaterTopLeftRight.png");
        public static Bitmap Image_WaterBottomLeftRightBlank = new Bitmap(@"Resources\Images\SmartWater\Blank\SmartWaterBottomLeftRight.png");
        public static Bitmap Image_WaterTopBottomBlank = new Bitmap(@"Resources\Images\SmartWater\Blank\SmartWaterTopBottom.png");
        public static Bitmap Image_WaterTopBottomLeftBlank = new Bitmap(@"Resources\Images\SmartWater\Blank\SmartWaterTopBottomLeft.png");
        public static Bitmap Image_WaterTopLeftBlank = new Bitmap(@"Resources\Images\SmartWater\Blank\SmartWaterTopLeft.png");
        public static Bitmap Image_WaterBottomLeftBlank = new Bitmap(@"Resources\Images\SmartWater\Blank\SmartWaterBottomLeft.png");
        public static Bitmap Image_WaterTopRightBlank = FlipXImage(Image_WaterTopLeftBlank);
        public static Bitmap Image_WaterBottomRightBlank = FlipXImage(Image_WaterBottomLeftBlank);
        public static Bitmap Image_WaterRightBlank = FlipXImage(Image_WaterLeftBlank);
        public static Bitmap Image_WaterTopBottomRightBlank = FlipXImage(Image_WaterTopBottomLeftBlank);

        public static Bitmap Image_WaterLeftSnow = new Bitmap(@"Resources\Images\SmartWater\Snow\SmartWaterLeftSnow.png");
        public static Bitmap Image_WaterTopSnow = new Bitmap(@"Resources\Images\SmartWater\Snow\SmartWaterTopSnow.png");
        public static Bitmap Image_WaterBottomSnow = new Bitmap(@"Resources\Images\SmartWater\Snow\SmartWaterBottomSnow.png");
        public static Bitmap Image_WaterLeftRightSnow = new Bitmap(@"Resources\Images\SmartWater\Snow\SmartWaterLeftRightSnow.png");
        public static Bitmap Image_WaterTopLeftRightSnow = new Bitmap(@"Resources\Images\SmartWater\Snow\SmartWaterTopLeftRightSnow.png");
        public static Bitmap Image_WaterBottomLeftRightSnow = new Bitmap(@"Resources\Images\SmartWater\Snow\SmartWaterBottomLeftRightSnow.png");
        public static Bitmap Image_WaterTopBottomSnow = new Bitmap(@"Resources\Images\SmartWater\Snow\SmartWaterTopBottomSnow.png");
        public static Bitmap Image_WaterTopBottomLeftSnow = new Bitmap(@"Resources\Images\SmartWater\Snow\SmartWaterTopBottomLeftSnow.png");
        public static Bitmap Image_WaterTopLeftSnow = new Bitmap(@"Resources\Images\SmartWater\Snow\SmartWaterTopLeftSnow.png");
        public static Bitmap Image_WaterBottomLeftSnow = new Bitmap(@"Resources\Images\SmartWater\Snow\SmartWaterBottomLeftSnow.png");
        public static Bitmap Image_WaterTopRightSnow = FlipXImage(Image_WaterTopLeftSnow);
        public static Bitmap Image_WaterBottomRightSnow = FlipXImage(Image_WaterBottomLeftSnow);
        public static Bitmap Image_WaterRightSnow = FlipXImage(Image_WaterLeftSnow);
        public static Bitmap Image_WaterTopBottomRightSnow = FlipXImage(Image_WaterTopBottomLeftSnow);

        //public static Bitmap Image_WaterLeftRightUpDown = new Bitmap(@"Resources\Images\SmartWater\SmartWaterTopBottomLeftRightGrass.png"); --TO BE ADDED--
        public static Bitmap Image_BridgeLeftRight = new Bitmap(@"Resources\Images\SmartWater\BridgeLToR.png");
        public static Bitmap Image_BridgeUpDown = new Bitmap(@"Resources\Images\SmartWater\BridgeUp.png");

        

        

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

        public static Bitmap Image_BadguyKing_Right_1 = new Bitmap(@"Resources\Images\Badguy\BadguyKing_1.png");
        public static Bitmap Image_BadguyKing_Right_2 = new Bitmap(@"Resources\Images\Badguy\BadguyKing_2.png");
        public static Bitmap Image_BadguyKing_Right_3 = new Bitmap(@"Resources\Images\Badguy\BadguyKing_3.png");
        public static Bitmap Image_BadguyKing_Right_4 = new Bitmap(@"Resources\Images\Badguy\BadguyKing_4.png");

        public static Bitmap Image_BadguyKing_Up_1 = new Bitmap(@"Resources\Images\Badguy\BadguyKingUp_1.png");
        public static Bitmap Image_BadguyKing_Up_2 = new Bitmap(@"Resources\Images\Badguy\BadguyKingUp_2.png");

        public static Bitmap Image_BadguyKing_Down_1 = new Bitmap(@"Resources\Images\Badguy\BadguyKingForward_1.png");
        public static Bitmap Image_BadguyKing_Down_2 = new Bitmap(@"Resources\Images\Badguy\BadguyKingForward_2.png");

        public static Bitmap Image_BadguyKing_Snow_Right_1 = new Bitmap(@"Resources\Images\Badguy\Snow\KingofDeerSnowRight_1.png");
        public static Bitmap Image_BadguyKing_Snow_Right_2 = new Bitmap(@"Resources\Images\Badguy\Snow\KingofDeerSnowRight_2.png");
        public static Bitmap Image_BadguyKing_Snow_Left_1 = new Bitmap(@"Resources\Images\Badguy\Snow\KingofDeerSnowLeft_1.png");
        public static Bitmap Image_BadguyKing_Snow_Left_2 = new Bitmap(@"Resources\Images\Badguy\Snow\KingofDeerSnowLeft_2.png");

        public static Bitmap Image_BadguyKing_Snow_Up_1 = new Bitmap(@"Resources\Images\Badguy\Snow\KingofDeerBackSnow_1.png");
        public static Bitmap Image_BadguyKing_Snow_Up_2 = new Bitmap(@"Resources\Images\Badguy\Snow\KingofDeerBackSnow_2.png");

        public static Bitmap Image_BadguyKing_Snow_Down_1 = new Bitmap(@"Resources\Images\Badguy\Snow\KingofDeerSnow.png");
        public static Bitmap Image_BadguyKing_Snow_Down_2 = new Bitmap(@"Resources\Images\Badguy\Snow\KingofDeerSnow2.png");
        public static Bitmap Image_Badguy_King_Snow_Dead = new Bitmap(@"Resources\Images\Badguy\Snow\KingofDeerSnowDead.png");

        public static Bitmap Image_DragonRight = new Bitmap(@"Resources\Images\Badguy\Dragon1.png");
        public static Bitmap Image_DragonStillRight = new Bitmap(@"Resources\Images\Badguy\DragonStill.png");
        public static Bitmap Image_DragonLeft = FlipXImage(Image_DragonRight);
        public static Bitmap Image_DragonStillLeft = FlipXImage(Image_DragonStillRight);
        public static Bitmap Image_DragonDown = RotateNinety(Image_DragonRight);
        public static Bitmap Image_DragonStillDown = RotateNinety(Image_DragonStillRight);
        public static Bitmap Image_DragonUp = FlipYImage(Image_DragonDown);
        public static Bitmap Image_DragonStillUp = FlipYImage(Image_DragonStillDown);

        public static Bitmap Image_DragonDownRight = new Bitmap(@"Resources\Images\Badguy\DragonDiagonal.png");
        public static Bitmap Image_DragonDownLeft = RotateNinety(Image_DragonDownRight);
        public static Bitmap Image_DragonUpLeft = RotateNinety(Image_DragonDownLeft);
        public static Bitmap Image_DragonUpRight = RotateNinety(Image_DragonUpLeft);

        public static Bitmap Image_DragonDead = new Bitmap(@"Resources\Images\Badguy\DeadDragon.png");

        public static Bitmap Image_A = new Bitmap(@"Resources\Images\Letters\Normal\LetterA.png");
        public static Bitmap Image_B = new Bitmap(@"Resources\Images\Letters\Normal\LetterB.png");
        public static Bitmap Image_C = new Bitmap(@"Resources\Images\Letters\Normal\LetterC.png");
        public static Bitmap Image_D = new Bitmap(@"Resources\Images\Letters\Normal\LetterD.png");
        public static Bitmap Image_E = new Bitmap(@"Resources\Images\Letters\Normal\LetterE.png");
        public static Bitmap Image_F = new Bitmap(@"Resources\Images\Letters\Normal\LetterF.png");
        public static Bitmap Image_G = new Bitmap(@"Resources\Images\Letters\Normal\LetterG.png");
        public static Bitmap Image_H = new Bitmap(@"Resources\Images\Letters\Normal\LetterH.png");
        public static Bitmap Image_I = new Bitmap(@"Resources\Images\Letters\Normal\LetterI.png");
        public static Bitmap Image_J = new Bitmap(@"Resources\Images\Letters\Normal\LetterJ.png");
        public static Bitmap Image_K = new Bitmap(@"Resources\Images\Letters\Normal\LetterK.png");
        public static Bitmap Image_L = new Bitmap(@"Resources\Images\Letters\Normal\LetterL.png");
        public static Bitmap Image_M = new Bitmap(@"Resources\Images\Letters\Normal\LetterM.png");
        public static Bitmap Image_N = new Bitmap(@"Resources\Images\Letters\Normal\LetterN.png");
        public static Bitmap Image_O = new Bitmap(@"Resources\Images\Letters\Normal\LetterO.png");
        public static Bitmap Image_P = new Bitmap(@"Resources\Images\Letters\Normal\LetterP.png");
        public static Bitmap Image_Q = new Bitmap(@"Resources\Images\Letters\Normal\LetterQ.png");
        public static Bitmap Image_R = new Bitmap(@"Resources\Images\Letters\Normal\LetterR.png");
        public static Bitmap Image_S = new Bitmap(@"Resources\Images\Letters\Normal\LetterS.png");
        public static Bitmap Image_T = new Bitmap(@"Resources\Images\Letters\Normal\LetterT.png");
        public static Bitmap Image_U = new Bitmap(@"Resources\Images\Letters\Normal\LetterU.png");
        public static Bitmap Image_V = new Bitmap(@"Resources\Images\Letters\Normal\LetterV.png");
        public static Bitmap Image_W = new Bitmap(@"Resources\Images\Letters\Normal\LetterW.png");
        public static Bitmap Image_X = new Bitmap(@"Resources\Images\Letters\Normal\LetterX.png");
        public static Bitmap Image_Y = new Bitmap(@"Resources\Images\Letters\Normal\LetterY.png");
        public static Bitmap Image_Z = new Bitmap(@"Resources\Images\Letters\Normal\LetterZ.png");







        public static Bitmap FlipXImage(Bitmap srcImage)
        {
            //Clone it to another bitmap
            Bitmap image2 = (Bitmap)srcImage.Clone();
            //Rotating
            image2.RotateFlip(RotateFlipType.RotateNoneFlipX);
            return image2;
        }
        public static Bitmap FlipYImage(Bitmap srcImage)
        {
            //Clone it to another bitmap
            Bitmap image2 = (Bitmap)srcImage.Clone();
            //Rotating
            image2.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return image2;
        }
        public static Bitmap RotateNinety(Bitmap srcImage)
        {
            //Clone it to another bitmap
            Bitmap image2 = (Bitmap)srcImage.Clone();
            //Rotating
            image2.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return image2;
        }
    }
}
