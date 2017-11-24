using System;
using System.Collections.Generic;

namespace TodoInFileStorage
{
    class RenameCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Console.Write("id: ");
            var id = Console.ReadLine();
            //if (task == null)
            //{
            //    Console.WriteLine("task not found");
            //    return;
            //}

            Console.Write("new name: ");
            var name = Console.ReadLine();
            Program.Logics.Rename(id,name);
        }
    }
}