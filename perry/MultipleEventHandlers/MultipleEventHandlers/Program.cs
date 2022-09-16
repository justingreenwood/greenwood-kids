using System;

namespace MultipleEventHandlers
{
    class Program
    {
        static int count;

        static void SaySomething(object sender, TalkEventsArgs e)
        {
            Console.WriteLine($"Call #{count++}: I said something : {e.Message}");
        }

        static void SaySomethingElse(object sender, TalkEventsArgs e)
        {
            Console.WriteLine($"Call #{count++}: I said something else : {e.Message}");
        }

        static void Main(string[] args)
        {

            var myEvent = new Talker();
            while (true)
            {
                Console.WriteLine("1 to chain something, 2 to chain something else, or message: ");
                var line = Console.ReadLine();
                switch (line)
                {
                    case "1":
                        Console.WriteLine("Adding say something.");
                        myEvent.TalkToMe += SaySomething;
                        break;
                    case "2":
                        Console.WriteLine("Adding say something else.");
                        myEvent.TalkToMe += SaySomethingElse;
                        break;
                    case "":
                        return;
                    default:
                        count = 1;
                        Console.WriteLine("Raising the talk to me event.");
                        myEvent.OnTalkToMe(line);
                        break;
                }
                    

            }

        }
    }



    class TalkEventsArgs: EventArgs
    {

        public string Message { get; private set; }
        public TalkEventsArgs(string message) => Message = message;

    }

    class Talker
    {
        public EventHandler<TalkEventsArgs> TalkToMe;
        public void OnTalkToMe(string message) => TalkToMe?.Invoke(this, new TalkEventsArgs(message));
    }

}
