using System;

namespace TodoInFileStorage
{
    class ExitCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Environment.Exit(0);
        }
    }
}