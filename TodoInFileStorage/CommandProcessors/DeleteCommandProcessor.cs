using System;

namespace TodoInFileStorage
{
    class DeleteCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Console.Write("id: ");
            var id = Console.ReadLine();
            Tasks.Delete(id);
        }
    }
}
