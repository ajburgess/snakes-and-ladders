using System;
using System.Collections.Generic;

namespace snakes_and_ladders
{
    public class Game
    {
        private Board board;
        private Dice dice;
        private Player[] players;
        private Player currentPlayer;
        private Narrator narrator;

        public Game(Player[] players, Narrator narrator)
        {
            this.players = players;
            this.narrator = narrator;

            board = new Board();
            dice = new Dice();
        }

        public void Reset()
        {
            foreach (Player player in players)
            {
                player.Position = 0;
            }

            currentPlayer = null;
        }

        public Player CurrentPlayer
        {
            get { return currentPlayer; }
        }

        public Board Board
        {
            get { return board; }
        }

        public Dice Dice
        {
            get { return dice; }
        }

        public Player Winner
        {
            get
            {
                foreach (Player player in players)
                {
                    if (player.Position == board.Size)
                    {
                        return player;
                    }
                }

                return null;
            }
        }

        public void SelectFirstPlayer()
        {
            // Each player rolls the dice
            // Whoever gets highest roll goes first
            // If two or more players both roll same same highest roll, they roll again
            // Until just one player got the highest roll

            narrator.SaySelectingFirstPlayer();
            Player[] candidates = players;

            while (candidates.Length > 1)
            {
                int highestRoll = 0;
                List<Player> highestRollingPlayers = new List<Player>();

                foreach (Player player in candidates)
                {
                    int roll = dice.Roll();
                    narrator.SayRoll(player, roll);

                    if (roll > highestRoll)
                    {
                        highestRoll = roll;
                        highestRollingPlayers.Clear();
                        highestRollingPlayers.Add(player);
                    }
                    else if (roll == highestRoll)
                    {
                        highestRollingPlayers.Add(player);
                    }
                }

                candidates = highestRollingPlayers.ToArray();
            }

            // We only have one candidate remaining, so they are the single highest rolling player
            // and will be the player to go first
            currentPlayer = candidates[0];
            narrator.SayFirstPlayer(currentPlayer);
        }

        public void SelectNextPlayer()
        {
            // If it's the first go, pick the first player based on highest roll
            if (currentPlayer == null)
            {
                SelectFirstPlayer();
                return;
            }

            // Find position of current player in player list
            int index = Array.IndexOf(players, currentPlayer);

            // Bump up the index, but wrap round if reach end of list
            index++;
            if (index >= players.Length)
            {
                index = 0;
            }

            // Select the player based on new index
            currentPlayer = players[index];
        }
    }
}