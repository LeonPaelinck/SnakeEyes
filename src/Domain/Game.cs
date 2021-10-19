using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Game
    {
        private Dice _dice1, _dice2;
        private List<int> _highscores = new();


        public int Eye1 => _dice1.Dots;
        public int Eye2 => _dice2.Dots;
        public bool HasSnakeEyes => Eye1 == Eye2 && Eye2 == 1;
        public IReadOnlyList<int> HighScores => _highscores.AsReadOnly();
        public int Total { get; private set; }

        public Game()
        {
            Initialize();
        }

        public void Initialize()
        {
            Total = 0;
            _dice1 = new Dice();
            _dice2 = new Dice();
        }
        public void Play()
        {
            if(HasSnakeEyes)
            {
                throw new InvalidOperationException("You cannot roll anymore!");
            }
            _dice1.Roll();
            _dice2.Roll();
            if(HasSnakeEyes)
            {
                _highscores.Add(Total);
                Total = 0;
            }
            Total += Eye1 + Eye2;
        }
        public void Restart()
        {
            Initialize();
        }
    }
}
