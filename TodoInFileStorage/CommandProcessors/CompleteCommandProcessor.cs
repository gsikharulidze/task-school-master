using System;

namespace TodoInFileStorage
{
    class CompleteCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Console.Write("id: ");
            var id = Console.ReadLine();
            Program.Logics.Complete(id);
        }
    }
}