using System;

namespace TodoInFileStorage
{
    class ListCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Console.WriteLine("id\tname\tCompleted");
            Console.WriteLine("==============================");
            foreach (var task in Tasks.List())
            {
                Console.WriteLine(task);
            }
            Tasks.Lists();
        }
    }
}
