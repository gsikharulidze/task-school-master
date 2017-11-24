namespace TodoInFileStorage
{
    class AllActiveCommandProcessor : CommandProcessor
    {
        public override void Process()
        {

            Program.Logics.AllActive();
        }
    }
}