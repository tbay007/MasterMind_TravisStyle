using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_TravisStyle.Models
{
    public class GuessModel
    {
        public int NumberOfGuesses { get; set; }
        public int MaxGuesses { get; set; }
        public GuessModel() 
        { 
            NumberOfGuesses = 0;
            MaxGuesses = 10;
        }

        public void IncrementGuesses()
        {
            ++NumberOfGuesses;
        }

        public int Number1Guess { get; set; }
        public string Hint1Guess { get; set; }
        public int Number2Guess { get; set; }
        public string Hint2Guess { get; set; }
        public int Number3Guess { get; set; }
        public string Hint3Guess { get; set; }
        public int Number4Guess { get; set; }
        public string Hint4Guess { get; set; }
    }
}
