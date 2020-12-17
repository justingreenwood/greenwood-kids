using System;
using System.Runtime.Versioning;
using System.Threading;

namespace andromeda_s_asignments
{
    class Program
    {
        static void Main(string[] args)
        {
           Reset:
            Console.WriteLine("                                                Welcome to Mad Libs");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Write a female first name.");
            var fname = Console.ReadLine();
            Console.WriteLine("Write a last female name.");
            var lname = Console.ReadLine();
            Console.WriteLine("Write an adjective.");
            var adj1 = Console.ReadLine();
            Console.WriteLine("Pick a nationality.");
            var r1 = Console.ReadLine();
            Console.WriteLine("kind of fabric");
            var fab = Console.ReadLine();
            Console.WriteLine(" pair of clothing item");
            var clothes = Console.ReadLine();
            Console.WriteLine("amount of time (hundred, million, decade,etc......)"); 
            var at = Console.ReadLine();
            Console.WriteLine("span of time (day, minute, month, year, etc......)");
            var st = Console.ReadLine();
            Console.WriteLine("Pick a noun."); 
            var noun1 = Console.ReadLine();
            Console.WriteLine("Pick an adverb."); 
            var adv = Console.ReadLine();
            Console.WriteLine("Pick another noun.");
            var noun2 = Console.ReadLine();
            Console.WriteLine("Pick another adjective."); 
            var adj2 = Console.ReadLine();
            Console.WriteLine("Pick yet another adjective.");
            var adj3 = Console.ReadLine();
            Console.WriteLine("Pick another nationality."); 
            var r2 = Console.ReadLine();
            Console.WriteLine("Pick another adjective.");
            var adj4 = Console.ReadLine();
            Console.WriteLine("Pick yet another noun."); 
            var noun3 = Console.ReadLine();
            Console.WriteLine("Pick yet another adjective."); 
            var adj5 = Console.ReadLine();
            Console.WriteLine("Pick another adjective."); 
            var adj6 = Console.ReadLine();
            Console.WriteLine("Pick another noun."); 
            var noun4 = Console.ReadLine();


            Thread.Sleep(1000);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($" {fname} {lname} has entered a contest to solve an {adj1} mystery, the disappearance of a {r1} nobleman, a pair of {fab} {clothes}, and a priceless treasure.");
            Console.WriteLine($" It happened nearly a {at} {st} ago. But when {fname}'s contest entry is missing, {fname} knows the mystery is far from {noun1}");
            Console.WriteLine($" It is {adv} too, she discovers, as she and her friends search for {noun2} in the {adj2} tunnels and {adj3} canals of ancient {r2} town, pursued by {adj4} fortune hunters who will stop at nothing to get the {noun3}.");
            Console.WriteLine(" ");
            Console.WriteLine($"A {adj5} {adj6} mystery shadowes by a romance of the {noun4}.");
            Console.WriteLine(" ");
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            TA:
            Console.WriteLine("Would you like to play again? (y/n)");
            var m = Console.ReadLine();
            if (m == "y")
            { goto Reset;
            
            }
            else if  (m == "n") 
            {
                Console.WriteLine("Bye-Bye");
            }
            else 
            {   Console.WriteLine("Stupid, you're so stupid.");
                goto TA;
            }


        }
    }
}
