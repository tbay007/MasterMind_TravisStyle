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
        public List<HintGuessModel> hintGuessModels { get; set; }
        public GuessModel() 
        { 
            NumberOfGuesses = 0;
            MaxGuesses = 10;
            hintGuessModels = new List<HintGuessModel>();
        }

        public void IncrementGuesses()
        {
            ++NumberOfGuesses;
        }
    }

    public class HintGuessModel
    {
        public int NumberGuess { get; set; }
        public string HintGuess { get; set; } = string.Empty;
    }
}
