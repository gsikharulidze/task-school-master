namespace TodoInFileStorage
{
    class AllCompleteCommandProcessor : CommandProcessor
    {
        public override void Process()
        {

            Program.Logics.AllComplete();
        }
    }
}