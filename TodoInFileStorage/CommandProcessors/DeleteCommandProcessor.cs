﻿using System;

namespace TodoInFileStorage
{
    class DeleteCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Console.Write("id: ");
            var id = Console.ReadLine();
            Program.Logics.Delete(id);
        }
    }
}
