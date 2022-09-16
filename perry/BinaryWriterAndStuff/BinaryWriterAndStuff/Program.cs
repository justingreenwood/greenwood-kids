using System;
using System.IO;

namespace BinaryWriterAndStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            int intValue = 48769414;
            string stringValue = "Hello!";
            byte[] byteArray = { 47, 129, 0, 116, };
            float floatValue = 491.695F;
            char charValue = 'E';
            using (var output = File.Create("binarydata.dat"))
                using(var writer = new BinaryWriter(output))
            {
                writer.Write(intValue);
                writer.Write(stringValue);
                writer.Write(byteArray);
                writer.Write(floatValue);
                writer.Write(charValue);

            }

            byte[] dataWritten = File.ReadAllBytes("binarydata.dat");
            foreach(byte b in dataWritten)
            {
                Console.Write("{0:x2} ", b);
            }
            Console.WriteLine();

        }
    }
}
