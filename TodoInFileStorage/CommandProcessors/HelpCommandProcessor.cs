using System;

namespace TodoInFileStorage
{
    class HelpCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Console.WriteLine("Collor guide:");
            Console.WriteLine();
            Color.Yellow();
            Console.WriteLine("Yellow:\t- Command");
            Color.Red();
            Console.WriteLine("Red:\t- Error ");
            Color.Green();
            Console.WriteLine("Green:\t- Result (After success command)");
            Console.WriteLine();
            Console.WriteLine("avaliable commands");
            Console.WriteLine("------------------------------");
            Program.Logics.Help();

        }
    }
}