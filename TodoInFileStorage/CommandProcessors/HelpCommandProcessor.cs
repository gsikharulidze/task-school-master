using System;

namespace TodoInFileStorage
{
    class HelpCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Console.WriteLine("Collor guide:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Yellow:\t- Command");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Red:\t- Error ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Green:\t- Result (After success command)");
            Console.WriteLine();
            Console.WriteLine("avaliable commands");
            Console.WriteLine("------------------------------");
            Tasks.Help();

        }
    }
}