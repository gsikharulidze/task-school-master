namespace TodoInFileStorage
{
    class AllActiveCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Tasks.AllActive();
        }
    }
}