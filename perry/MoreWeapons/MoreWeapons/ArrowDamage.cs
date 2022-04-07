using System;
using System.Collections.Generic;
using System.Text;

namespace MoreWeapons
{
    class ArrowDamage:WeaponDamage
    {

        private const decimal BaseMultiplier = 0.35M;
        private const decimal MagicMultiplier = 2.5M;
        private const decimal FlameDamage = 1.25M;
        /*private int roll;
        public int Roll
        {
            get { return roll; }
            set
            {
                roll = value;
                CalculateDamage();
            }
        }
        public int Damage { get; private set; }*/

        protected override void CalculateDamage()
        {

            decimal baseDamage = Roll*BaseMultiplier;
            if (Magic)
            {
                baseDamage *= MagicMultiplier;
            }
            if (Flaming)
            {
                Damage = (int)Math.Ceiling(baseDamage+FlameDamage);
            }
            else
            {
                Damage = (int)Math.Ceiling(baseDamage);
            }

        }
        /*private bool magic;
        public bool Magic
        {
            get
            {
                return magic;
            }
            set
            {
                magic = value;
                CalculateDamage();

            }
        }

        private bool flaming;
        public bool Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();
            }
        }*/

        public ArrowDamage(int startingRoll):base (startingRoll)
        {
            
        }


    }
}
