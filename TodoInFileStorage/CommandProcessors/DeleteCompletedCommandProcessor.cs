namespace TodoInFileStorage
{
    class DeleteCompletedCommandProcessor : CommandProcessor
    {
        public override void Process()
        {
            //throw new System.NotImplementedException();
            Program.Logics.DeleceComplete();
        }
    }
}