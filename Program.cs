using System;

namespace snakes_and_ladders
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor[] colours = { ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Gray };

            Console.Write("How many players? ");
            int numberOfPlayers = int.Parse(Console.ReadLine());
            Player[] players = new Player[numberOfPlayers];

            for (int p = 1; p <= numberOfPlayers; p++)
            {
                Console.Write($"Enter the name of player {p}: ");
                string name = Console.ReadLine();
                Console.Write($"Enter the colour for player {p}: ");
                ConsoleColor colour = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Console.ReadLine(), true);
                players[p - 1] = new Player(name, colour);
            }

            Narrator narrator = new Narrator();
            Game game = new Game(players, narrator);

            while (true)
            {
                game.SelectFirstPlayer();

                while (true)
                {
                    Console.ReadLine();

                    game.CurrentPlayer.TakeTurn(game.Board, game.Dice, narrator);

                    if (game.Winner != null)
                        break;

                    game.SelectNextPlayer();
                }

                narrator.SayWinner(game.Winner);

                Console.WriteLine();
                Console.Write("Play again? (y/n) ");
                bool playAgain = Console.ReadLine().ToLower() == "y";

                if (playAgain == false)
                    break;

                game.Reset();
            }
        }
    }
}
