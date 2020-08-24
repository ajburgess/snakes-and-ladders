namespace snakes_and_ladders
{
    public class Snake
    {
        private int from;
        private int to;

        public Snake(int from, int to)
        {
            this.from = from;
            this.to = to;
        }

        public int From
        {
            get { return this.from; }
        }

        public int To
        {
            get { return this.to; }
        }
    }
}