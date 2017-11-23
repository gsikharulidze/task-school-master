using System;

namespace TodoInFileStorage
{
    class HelpCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("avaliable commands");
            Console.WriteLine("==============================");
            Tasks.Help();
            Console.WriteLine();

        }
    }
}