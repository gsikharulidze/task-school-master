﻿using System;

namespace TodoInFileStorage
{
    class CompleteCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Console.Write("id: ");
            var id = Console.ReadLine();
            Tasks.Complete(id);
        }
    }
}