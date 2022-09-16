using System;
using System.IO;
using System.Text;

namespace HexDump
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (!File.Exists("textdata.txt"))
            //    File.WriteAllText("textdata.txt", "this is a test and the things and poop and stuff");

            var position = 0;
            //using (var reader = new StreamReader("textdata.txt"))
            //using (Stream input = File.OpenRead(args[0]))
            using (Stream input = GetInputStream(args))
            {
                var buffer = new byte[16];
                int bytesRead;
                //while (!reader.EndOfStream)
                while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    //var bytesRead = input.Read(buffer, 0, buffer.Length);
                    //var buffer = new char[16];
                    //var bytesRead = reader.ReadBlock(buffer, 0, 16);

                    Console.Write("{0:x4}: ", position);
                    position += bytesRead;

                    for (var i = 0; i < 16; i++)
                    {
                        if (i < bytesRead)
                        {
                            Console.Write("{0:x2} ", (byte)buffer[i]);
                        }
                        else
                        {
                            Console.Write("   ");
                        }
                        if (i == 7)
                        {
                            Console.Write("-- ");
                        }
                        if (buffer[i] < 0x20 || buffer[i] > 0x7F)
                        {
                            buffer[i] = (byte)'.';
                        }
                    }

                    //var bufferContents = new string(buffer);
                    var bufferContents = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine("  {0}", bufferContents.Substring(0, bytesRead));

                }

            }

        }

        static Stream GetInputStream(string[] args)
        {
            if((args.Length != 1) || !File.Exists(args[0]))
            {
                return Console.OpenStandardInput();
            }
            else
            {
                try
                {
                    return File.OpenRead(args[0]);
                }
                catch(UnauthorizedAccessException ex)
                {
                    Console.Error.WriteLine("Unable to read {0}, dumbing from stdin: {1}", args[0], ex.Message);
                    return Console.OpenStandardInput();
                }
            }
        }
    }
}
