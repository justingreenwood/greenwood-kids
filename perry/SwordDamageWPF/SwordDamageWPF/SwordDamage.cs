using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SwordDamageWPF
{
    class SwordDamage
    {

        private const int BaseDamage = 3;
        private const int FlameDamage = 2;
        private int roll;
        public int Roll
        {
            get { return roll; }
            set
            {
                roll = value;
                CalculateDamage();
            }
        }
        public int Damage { get; private set; }

        private void CalculateDamage()
        {

            decimal magicMultiplier = 1M;
            if (Magic)
            {
                magicMultiplier = 1.75M;
            }
            Damage = BaseDamage;
            Damage = (int)(Roll * magicMultiplier) + BaseDamage;
            if (flaming)
            {
                Damage += FlameDamage;
            }


        }
        private bool magic;
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
        }

        public SwordDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }


    }
}
