using System;

namespace snakes_and_ladders
{
    public class Dice
    {
        private Random randomNumberGenerator;

        public Dice()
        {
            randomNumberGenerator = new Random();
        }

        public int Roll()
        {
            // Return random number between 1 - 6
            return randomNumberGenerator.Next(1, 6 + 1);
        }
    }
}

