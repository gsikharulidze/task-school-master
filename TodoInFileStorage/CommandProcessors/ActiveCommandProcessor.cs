using System;

namespace TodoInFileStorage
{
    class ActiveCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Console.Write("id: ");
            var id = Console.ReadLine();
            Tasks.Active(id);
        }
    }
}