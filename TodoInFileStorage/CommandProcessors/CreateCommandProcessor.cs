using System;
using TodoLogic;

namespace TodoInFileStorage
{
    class CreateCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Console.Write("name: ");
            var name = Console.ReadLine();
          //  Program.Logics.Create(new Task { Name = name,Completed=false });
        }
    }
}
