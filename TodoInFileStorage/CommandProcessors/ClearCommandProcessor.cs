using System;

namespace TodoInFileStorage
{
    class ClearCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Console.Clear();
        }
    }
}