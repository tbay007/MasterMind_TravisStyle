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
            NumberOfGuesses++;
        }
    }
}
