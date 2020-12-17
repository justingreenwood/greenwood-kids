using System;
using System.Runtime.InteropServices;

namespace FreeAndProud
{
    public class Program
    {
        public static object Stuff { get; private set; }

        static void Main(string[] args)
        {


            //Console.Beep(262, 800);
            //Console.Beep(262, 888);
            //Console.Beep(294, 500);
            //Console.Beep(262, 88);
            //Console.Beep(330, 600);
            //Console.Beep(262, 8);
            //Console.Beep(349, 20);
            //Console.Beep(262, 834);
            //Console.Beep(330, 253);
            //Console.Beep(262, 23);
            //Console.Beep(294, 228);
            //Console.Beep(262, 228);
            //Console.Beep(262, 4300);
            //Console.Beep(262, 85);
            //Console.Beep(294, 134);
            //Console.Beep(262, 83);


            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("I slopped my dripper! No oh! Shateth whall I do?");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Fanks thor the input! Have a antastically fawful day!");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("My sister, Andramaqueen, wants me to tell you that you are a banana nose! Oh, and your presence is bad for her belly button!");

            Console.ForegroundColor = ConsoleColor.DarkBlue;

            var ThisVariable = Console.ReadKey();

            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.DarkRed;

            switch ((ThisVariable.Key))
            {
                case ConsoleKey.Enter:
                    if (ThisVariable.Modifiers == ConsoleModifiers.Shift)
                    {
                        Console.WriteLine("You are a big fat jerk.");
                    }
                    else
                    {
                        Console.WriteLine("You don't have a life.");
                    }
                    break;
                case ConsoleKey.Tab:
                    Console.WriteLine("Your last shower was three days ago.");
                    break;
                case ConsoleKey.A:
                    Console.WriteLine("You forgot to give me a birthday gift last year.");
                    break;
                case ConsoleKey.F5:
                    Console.WriteLine("Your last girlfriend dumped you for your favorite co-worker!");
                    break;
                case ConsoleKey.C:
                    Console.WriteLine("When did you last bathe?");
                    break;
                case ConsoleKey.M:
                    Console.WriteLine("It's a beautiful night! We're looking for something dumb to do. Hey, baby, I think I want to marry you!");
                    break;
                case ConsoleKey.LeftWindows:
                    Console.WriteLine("I threw a rock through your left windows!");
                    break;
                case ConsoleKey.RightWindows:
                    Console.WriteLine(" You need to use the Wright Windex when you clean your Wright windows.");
                    break;
                case ConsoleKey.F:
                    Console.WriteLine("For flavorful fullness, forget the flour.");
                    Console.WriteLine(" Actually, please don't. I like my cookies baked correctly!");
                    break;
                case ConsoleKey.D8:
                    Console.WriteLine("I love the number eight! It is my very very very very favorite number.");
                    break;
                case ConsoleKey.R:
                    Console.WriteLine(" What is a pirate's favorite letter? Ye may think it is R, but it is the C we truly love.");
                    break;
                case ConsoleKey.Z:
                    Console.WriteLine("I want you to realize that Z is the loneliest letter that there'll ever be!");
                    break;
                case ConsoleKey.D1:
                    Console.WriteLine("One is the lonesliest number that there ever will be, but if you turn it to TWO, everything will be better.");
                    break;
                case ConsoleKey.F11:
                    Console.WriteLine("Why did you press that? It is the least expected thing for you to press at any given time.");
                    break;
                case ConsoleKey.NumPad8:
                    Console.WriteLine(" I love the number eight! I really like the number eight. I'm so glad you chose the eight.");
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine("You know, it would be really funny (not) if I stopped having my liver checked, then it went and rotted away without us knowing it was dying.");
                    break;
                case ConsoleKey.E:
                    Console.WriteLine("You will die in the future. I see.........drowning. Oh, and I wouldn't trust Aurora with that frying pan. It may have something to do with the drowning.");
                    break;
                case ConsoleKey.Spacebar:
                    Console.WriteLine("Give me some SPACE! I'm trying to code, and I can't focus with you so close.");
                    break;
                case ConsoleKey.F8:
                    Console.WriteLine("Ooooooooooooooooooooooooooh! Ooooooh Ooh Ooooooh! Oooooooooooh! Oooooh! Oh, her eyes, her eyes make the stars look like they're not shining. Her hair, her hair, falls perfectly without her trying. She's so beautiful, and I tell her everyday. Oh, I know, I know if I compliment her, she won't believe me. And it's so, it's so sad that she don't she what I see, but everytime she asks me,'Do I look ok?' You know I'll saaaaay!");
                    Console.WriteLine(" When I see your face, there's not a thing that I would change. 'cause your amazing!");
                    Console.WriteLine("JUST THE WAY YOU ARE!");
                    break;
                case ConsoleKey.Attention:
                    Console.WriteLine("You just want attention! You don't want my heart! Maybe you just hate the thought of me with someone new!");
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine(" How many fingers do you have on one hand? I sure hope your answer is five.");
                    break;
                case ConsoleKey.D6:
                    Console.WriteLine("THOU ART THE SIX FINGERED MAN?! Hello, my name is Aurora Greenwood. You killed Benita. Prepare to die!");
                    break;
                case ConsoleKey.P:
                    Console.WriteLine("If you are not Perry, do not read the following message:");
                    Console.WriteLine(" You are the most annoyingly adorable booger that I have ever met. I also want to apologize for not buying you a milkshake last time. If you are not Perry and you are reading this, DIE A PAINFUL DEATH!");
                    break;
                case ConsoleKey.B:
                    Console.WriteLine("You are a dumby!");
                        break;
                case ConsoleKey.D:
                    Console.WriteLine(" That is the default choice. I love you!");
                    break;
                default:
                    Console.WriteLine("You are a fantastic human being! I would marry you, but I'm fourteen, we're related, AND you probably aren't interested.");
                    break;

            }
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                double JumbleberryPie = 8, RaspberryPie = 16;

                Console.WriteLine($"Perry's age is 23-10={23 - 10}.");
                Console.WriteLine($"My favorite number is {JumbleberryPie}. {RaspberryPie}-{JumbleberryPie}={JumbleberryPie}, which is nice, because I would hate to lose the {JumbleberryPie}!");

                Console.WriteLine($"My age is half of 28. That would be {.5 * 28}.");
                Console.WriteLine($"1+1={1 + 1}!");

            }


            {

                var PerrysFavorites = new MyFavoriteThings();
                PerrysFavorites.Chocolate = "Doesn't have one.";
                PerrysFavorites.Perry = "Himself, duh!";
                PerrysFavorites.AddictiveChips = "SunChips";

                var AndisFavorites = new MyFavoriteThings();
                AndisFavorites.Chocolate = "Toblerone";
                AndisFavorites.Perry = "Baby-bunny-butterfly!";
                AndisFavorites.AddictiveChips = "SunChips";

                var MeMyselfAndI = new MyFavoriteThings();
                MeMyselfAndI.Chocolate = "I just love chocolate. Not sure which is my favorite.";
                MeMyselfAndI.Perry = "My baby brother.";
                MeMyselfAndI.AddictiveChips = "Fritos. Honey Barbecue Frito Twists.";

                var answer = MyFunctions.AddThreeNumbers(-23, 234234, 2343);
                Console.WriteLine($"Answer = {answer}");


                var Choose = new MyFavoriteThings[] { PerrysFavorites, AndisFavorites, MeMyselfAndI };
                foreach (var Stuff in Choose)
                {
                    Stuff.PrintMyFavoriteThings();
                }
                
            
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Thank you for the input!");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" You just arrived back from a party. Were there more boys or girls? ( B=boys, G=girls, and E=sameish amount )");
            Console.ForegroundColor = ConsoleColor.Black;
            var ItTakesMoreTimeIfDadExplainsWhatIAlreadyKnow = Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.DarkRed;
            switch ((ItTakesMoreTimeIfDadExplainsWhatIAlreadyKnow))
            {
                case "B":
                    Console.WriteLine(" Ugh! Why did they invite boys?!");
                    break;
                case "G":
                    Console.WriteLine("There are too many girls at this party! I'm going to hide from them!");
                    break;
                case "E":
                    Console.WriteLine(" That is amazing. Balance is nice.");
                    break;
                default:
                    Console.WriteLine("You are so dumb! That was not an acceptable answer! Try something else.");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Type the first thing that comes to mind!");
            Console.ForegroundColor = ConsoleColor.Magenta;
            var PerryIsHereToo = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            switch ((PerryIsHereToo))
            {
                case "Graphing of quadratic equations are a pain in the @$$!":
                    Console.WriteLine(" I know! What is up with that!");
                    break;
                case "The first thing that comes to mind!":
                    Console.WriteLine(" Oh, a little smartiepants, are you? I HATE YOU! GO TAKE A LONG WALK OFF A SHORT PIER!");
                    break;
                case "I hate geometry!":
                    Console.WriteLine("Hey! Me, too!");
                    break;
                case "I don't know why I come back. I do every time.":
                    Console.WriteLine("Get close to the end. It's the finish line.");
                    Console.WriteLine("Sing these words for the girl I've been dreaming of....");
                    Console.WriteLine("Is this just another song about love????");
                    Console.WriteLine(" My reaction EVERY SINGLE TIME that I hear that part: IT IS, YOU DUMB BOY! Go tell her that, and don't do it in your usual dumb song form!");
                    break;
                case " I'm a banana!":
                    Console.WriteLine(" Not that again!");
                    break;
                case " I'm blue!":
                    Console.WriteLine("Da ba dee, da ba die, a da ba dee, daba die, daba dee daba die.");
                    break;
                case "All ze ladies love Leo!":
                    Console.WriteLine(" Leo wishes that were true. But, no, none of the ladies unrelated to him love him. Until the second to last book of the series when Calypso finally starts to mildly like him, and by the end of the last book, they had fallen in love.");
                    break;
                case ("On the first page of our story, the future seemed so bright."):
                    Console.WriteLine(" Then the saint turned out so evil. Don't know why I'm still surprised.... 'Cause even angels have their wicked schemes, and you take yours to new extremes. But you'll always be my hero, even though you've lost your mind.");
                    Console.WriteLine(" Just gonna stand there and watch me burn!");
                    Console.WriteLine(" Well, that's alright because I love the way it hurts.");
                    Console.WriteLine(" Just gonna stand there and hear me cry?");
                    Console.WriteLine(" Well, that's alright because I love the way you lie.");
                    Console.WriteLine(" I love the way you lie.");
                    break;
                case "Now there's gravel in our voices.":
                    Console.WriteLine(" Glasses shattered from the fight. In this tug of war you always win, even when I'm right.'Cause you feed me fables from your head, with violent words and empty threats. And it's sick that all these battles are what keeps me satisfied..");
                    Console.WriteLine(" Just gonna stand there and watch me burn!");
                    Console.WriteLine(" Well, that's alright because I love the way it hurts.");
                    Console.WriteLine(" Just gonna stand there and hear me cry?");
                    Console.WriteLine(" Well, that's alright because I love the way you lie.");
                    Console.WriteLine(" I love the way you lie.");
                    Console.WriteLine(" I love the way you lie.");
                    break;
                case "So, maybe I'm a masochist.":
                    Console.WriteLine("I try to run but I don't wanna ever leave.");
                    Console.WriteLine("Til the walls are going up!");
                    Console.WriteLine("In smoke with all our memories.......");
                    Console.WriteLine(" Just gonna stand there and watch me burn!");
                    Console.WriteLine(" Well, that's alright because I love the way it hurts.");
                    Console.WriteLine(" Just gonna stand there and hear me cry?");
                    Console.WriteLine(" Well, that's alright because I love the way you lie.");
                    Console.WriteLine(" I love the way you lie.");
                    Console.WriteLine(" I love the way you lie.");
                    Console.WriteLine(" I love the way you lie.");
                    break;
                case " What the-":
                    Console.WriteLine(" And that is when Aurora realized that she had no idea where this was going.");
                    break;
                case " I like case statements.":
                    Console.WriteLine(" You do?");
                    break;
                default:
                    Console.WriteLine(" That is a good choice of a thing to type! I'm so proud of you!");
                    break;
            }
        }

    }

}