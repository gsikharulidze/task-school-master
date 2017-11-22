namespace TodoInFileStorage
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}", Id, Name, Completed);
        }

    }
}
