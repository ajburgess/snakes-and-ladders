namespace snakes_and_ladders
{
    public class Board
    {
        private int size;
        private Snake[] snakes;
        private Ladder[] ladders;

        public Board()
        {
            size = 100;
            snakes = new Snake[] {
                new Snake(98, 60),
                new Snake(79, 56),
                new Snake(55, 45),
                new Snake(39, 18),
                new Snake(96, 33),
                new Snake(70, 49),
                new Snake(28, 10)
            };
            ladders = new Ladder[] {
                new Ladder(4, 23),
                new Ladder(15, 72),
                new Ladder(30, 52),
                new Ladder(90, 93),
                new Ladder(66, 77),
                new Ladder(61, 82),
                new Ladder(36, 41),
                new Ladder(7, 12)
            };
        }

        public int Size
        {
            get { return size; }
        }

        public bool PlayerIsOnFinalSquare(Player player)
        {
            return (player.Position == size);
        }

        public bool PlayerIsOnSnake(Player player, out Snake snake)
        {
            foreach (Snake s in snakes)
            {
                if (s.From == player.Position)
                {
                    snake = s;
                    return true;
                }
            }

            snake = null;
            return false;
        }

        public bool PlayerIsOnLadder(Player player, out Ladder ladder)
        {
            foreach (Ladder l in ladders)
            {
                if (l.From == player.Position)
                {
                    ladder = l;
                    return true;
                }
            }

            ladder = null;
            return false;
        }
    }
}