using System;

namespace snakes_and_ladders
{
    public class Narrator
    {
        public void SaySelectingFirstPlayer()
        {
            Console.WriteLine();
            Console.WriteLine($"Selecting the first player...");
        }

        public void SayFirstPlayer(Player player)
        {
            Console.WriteLine($"{player.Name} will be the first player");
        }

        public void Gap()
        {
            Console.WriteLine();
        }

        public void SayRoll(Player player, int roll)
        {
            Console.ForegroundColor = player.Colour;
            Console.WriteLine($"{player.Name} rolled a {roll}");
            Console.ResetColor();
        }

        public void SaySquareLandedOn(Player player)
        {
            Console.ForegroundColor = player.Colour;
            Console.WriteLine($"{player.Name} is now on square {player.Position}");
            Console.ResetColor();
        }

        public void SayLandedOnLadder(Player player)
        {
            Console.ForegroundColor = player.Colour;
            Console.WriteLine($"{player.Name} has landed on a LADDER");
            Console.ResetColor();
        }

        public void SayLandedOnSnake(Player player)
        {
            Console.ForegroundColor = player.Colour;
            Console.WriteLine($"{player.Name} has landed on a SNAKE");
            Console.ResetColor();
        }

        public void SayWinner(Player player)
        {
            Console.WriteLine();
            Console.WriteLine($"GAME OVER - {player.Name} is the winner!");
        }

        public void SayBounce(Player player)
        {
            Console.ForegroundColor = player.Colour;
            Console.WriteLine($"{player.Name} bounced backwards at the end of the board");
            Console.ResetColor();
        }

        public void SayAnotherGo(Player player)
        {
            Console.ForegroundColor = player.Colour;
            Console.WriteLine($"{player.Name} gets another go, because of rolling a six");
            Console.ResetColor();
        }
    }
}