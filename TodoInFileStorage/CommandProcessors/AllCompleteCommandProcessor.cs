namespace TodoInFileStorage
{
     class AllCompleteCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            Tasks.AllComplete();
        }
    }
}