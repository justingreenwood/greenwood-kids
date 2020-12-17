using System;

namespace complicated
{
    class Program
    {
        static void Main(string[] args)
        {
            var pcidntity = new Identity();
            pcidntity.name = "Princess";
            pcidntity.hair = "green";
            pcidntity.eye = "yellow";
            pcidntity.species = "magical being";
            pcidntity.outfit = "school uniform and steel toe high heels";
            pcidntity.loveintrest = "?";
            pcidntity.age = 14;

            var ecidntity = new Identity();
            ecidntity.name = "Eve";
            ecidntity.hair = "straberry blond";
            ecidntity.eye = "green";
            ecidntity.species = "human";
            ecidntity.outfit = "casual";
            ecidntity.loveintrest = "Kilian";
            ecidntity.age = 27;

            var ziidntity = new Identity();
            ziidntity.name = "Zack";
            ziidntity.hair = "black";
            ziidntity.eye = "green";
            ziidntity.species = "dragon";
            ziidntity.outfit = "black shoe and navy blue school uniform";
            ziidntity.loveintrest = "Mya";
            ziidntity.age = 100000016;
            
            var sbidntity = new Identity();
            sbidntity.name = "Starry";
            sbidntity.hair = "blond";
            sbidntity.eye = "green";
            sbidntity.species = "sorceress";
            sbidntity.outfit = "school uniform and flats";
            sbidntity.loveintrest = "Vincent";
            sbidntity.age = 16;

            var wbidntity = new Identity();
            wbidntity.name = "Winter";
            wbidntity.hair = "white blond";
            wbidntity.eye = "blue";
            wbidntity.species = "shape shifter";
            wbidntity.outfit = "suit";
            wbidntity.loveintrest = "Princess/Summer";
            wbidntity.age = 15;

            var vmidntity = new Identity();
            vmidntity.name = "Vincent";
            vmidntity.hair = "strawberry blond";
            vmidntity.eye = "blue";
            vmidntity.species = "were butterfly";
            vmidntity.outfit = "business casual";
            vmidntity.loveintrest = "Princess/Star";
            vmidntity.age = 15;

            var simidntity = new Identity();
           simidntity.name = "Simon";
            simidntity.hair = "?";
            simidntity.eye = "?";
            simidntity.species = "were dragon";
            simidntity.outfit = "?";
            simidntity.loveintrest = "Princess";
           simidntity.age = 16;

            var sumidntity = new Identity();
            sumidntity.name = "Summer";
            sumidntity.hair = "?";
            sumidntity.eye = "?";
            sumidntity.species = "were wolf";
           sumidntity.outfit = "?";
            sumidntity.loveintrest = "Winter";
            sumidntity.age = 14;

            var kidntity = new Identity();
            kidntity.name = "Killian";
            kidntity.hair = "?";
            kidntity.eye = "?";
            kidntity.species = "human";
            kidntity.outfit = "?";
           kidntity.loveintrest = "Eve";
            kidntity.age = 36;

            var midntity = new Identity();
            midntity.name = "Mya";
            midntity.hair = "?";
            midntity.eye = "?";
            midntity.species = "magical being";
            midntity.outfit = "?";
            midntity.loveintrest = "Zack";
            midntity.age = 30;

            var allIdentities = new Identity[] {pcidntity, ecidntity, ziidntity, sbidntity, wbidntity, vmidntity, simidntity, sumidntity, kidntity, midntity};
            foreach (var myId in allIdentities)
            {
                Console.WriteLine(myId.description);
            }


            Console.WriteLine("Welcome, how many people in your party");
            amount:
            var people = Console.ReadLine();
            if (!int.TryParse(people, out int chairs )) 
            {
                Console.WriteLine($"{people} is not a valid integer - MORON!");
                goto amount;
            }

            switch (chairs)
            {
                case 1:
                    Console.WriteLine($"{chairs} single person");
                    break;
                case 2:
                    Console.WriteLine($"{chairs} is couple");
                    break;
                case 3:
                case 4:
                    Console.WriteLine($"{chairs} single table");
                    break;
                case 5:
                case 6:
                    Console.WriteLine($"{chairs} single family");
                    break;
                default:
                    Console.WriteLine($"{chairs} party");
                    break;
            }
            Console.WriteLine($"thank you {chairs} for coming");


            Console.ReadKey();

        }

        static void Printidentity(Identity identity)
        {
            Console.WriteLine(identity.description);
        }
    }
}  

   
    