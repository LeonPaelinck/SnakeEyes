using System;

namespace Domain
{
    public class Dice
    {
        private static readonly Random _randomizer = new Random();
        public int Dots { get; private set; }

        public Dice()
        {
            Dots = 6;
        }

        public void Roll()
        {
            Dots = _randomizer.Next(1, 7);
        }
    }
}