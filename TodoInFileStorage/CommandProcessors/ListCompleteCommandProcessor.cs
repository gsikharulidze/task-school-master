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
            Program.Logics.ListComplete();
            Program.Logics.ActiveTasks();
        }
    }
}