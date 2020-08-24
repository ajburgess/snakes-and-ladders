using System;

namespace snakes_and_ladders
{
    public class Player
    {
        private string name;
        private int position;
        private ConsoleColor colour;

        public Player(string name, ConsoleColor colour)
        {
            this.name = name;
            this.colour = colour;
            this.position = 0;
        }

        public string Name
        {
            get { return name; }
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        public ConsoleColor Colour
        {
            get { return colour; }
        }

        public void TakeTurn(Board board, Dice dice, Narrator narrator)
        {
            int roll;
            bool playerGetsAnotherGo;

            do
            {
                // Roll the dice
                roll = dice.Roll();
                narrator.SayRoll(this, roll);

                // Move the player that many spaces forward on the board
                // Take into account bounce-back
                position += roll;

                // If player over-shoots the final square, they bounce backwards
                if (position > board.Size)
                {
                    int bounce = position - board.Size;
                    position = board.Size - bounce;
                    narrator.SayBounce(this);
                }

                narrator.SaySquareLandedOn(this);

                // Landed on ladder?
                if (board.PlayerIsOnLadder(this, out Ladder ladder))
                {
                    narrator.SayLandedOnLadder(this);
                    position = ladder.To;
                    narrator.SaySquareLandedOn(this);
                }

                // Landed on snake?
                if (board.PlayerIsOnSnake(this, out Snake snake))
                {
                    narrator.SayLandedOnSnake(this);
                    position = snake.To;
                    narrator.SaySquareLandedOn(this);
                }

                // Player ends if they have landed on the final square of the board
                if (board.PlayerIsOnFinalSquare(this))
                {
                    break;
                }

                // Player will get another go if they rolled a six
                playerGetsAnotherGo = false;
                if (roll == 6)
                {
                    narrator.SayAnotherGo(this);
                    playerGetsAnotherGo = true;
                }
            }
            while (playerGetsAnotherGo);
        }
    }
}