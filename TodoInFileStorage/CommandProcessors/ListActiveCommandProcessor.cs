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
            Tasks.ListActive();
            Tasks.ActiveTasks();
        }
    }
}