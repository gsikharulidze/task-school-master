using System;

namespace TodoInFileStorage
{
     class ListCompleteCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Console.WriteLine();
            Console.WriteLine("id\tname\tCompleted");
            Console.WriteLine("==============================");
            Tasks.ListComplete();
            Tasks.ActiveTasks();
        }
    }
}