using System;
using System.IO;

namespace ObjectvilleTwo
{
    class Program
    {
        static void Main(string[] args)
        {

            var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var reader = new StreamReader($"{folder}{Path.DirectorySeparatorChar}secret_plan.txt");
            var writer = new StreamWriter($"{folder}{Path.DirectorySeparatorChar}emailToGoodguy.txt");
            writer.WriteLine("To: Goodguy@objectville.net");
            writer.WriteLine("From: Commissioner@objectville.net");
            writer.WriteLine("Subject: Can you save the day again?");
            writer.WriteLine();
            writer.WriteLine("We have discovered the Badguy's plan:");

            while (!reader.EndOfStream)
            {
                var lineFromThePlan = reader.ReadLine();
                writer.WriteLine($"The plan -> {lineFromThePlan}");
            }

            writer.WriteLine();
            writer.WriteLine("Can you help us?");

            writer.Close();
            reader.Close();

        }
    }
}
