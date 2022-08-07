using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    static class HoneyVault
    {

        public const float NectarConversionRatio = .19f;
        public const float LowLevelWarning = 10f;
        private static float honey = 25f;
        private static float nectar = 100f;


        public static void CollectNectar(float amount)
        {
            if(amount>=0f)nectar += amount;
        }

        public static void ConvertNectarToHoney(float amount)
        {
            if (amount > nectar)
            {
                amount = nectar;
            }
            nectar -= amount;
            honey += amount * NectarConversionRatio;

        }

        public static bool ConsumeHoney(float amount)
        {

            if (amount <= honey)
            {
                honey -= amount;
                return true;
            }
                return false;
 

        }

        public static string StatusReport
        {

            get
            {
                string status = $"{honey:0.0} units of honey\n" +
                                $"{nectar:0.0} units of nectar";
                string warnings = "";
                if (honey < LowLevelWarning) warnings += "\nLOW HONEY - ADD A HONEY MANUFACTURER";
                if (nectar < LowLevelWarning) warnings += "\nLOW NECTAR - ADD A NECTAR COLLECTOR";
                return status + warnings;

            }

        }

    }
}
