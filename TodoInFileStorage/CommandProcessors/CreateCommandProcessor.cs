using System;

namespace TodoInFileStorage
{
    class CreateCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Console.Write("name: ");
            var name = Console.ReadLine();
            Tasks.Create(new Task { Name = name,Completed=false });
        }
    }
}
