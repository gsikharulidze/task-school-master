using System;

namespace TodoInFileStorage
{
     class ListActiveCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Console.WriteLine();
            Console.WriteLine("id\tname\tCompleted");
            Console.WriteLine("==============================");
            Program.Logics.ListActive();
            Program.Logics.ActiveTasks();
        }
    }
}