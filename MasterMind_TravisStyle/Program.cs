using MasterMind_TravisStyle.Models;
using System.Reflection;

namespace MasterMind_TravisStyle
{
    internal class Program
    {

        static void Main(string[] args)
        {
            MasterMindModel model = new MasterMindModel();
            GuessModel guesses = new GuessModel();
            Console.WriteLine("Welcome to MasterMind!  This game is with Travis's style so be prepared to guess!");
            Console.WriteLine("The current hints are as follows: 'Number:-' means the number exists but is not in the right position");
            Console.WriteLine("The current hints are as follows: 'Number:+' means the number is in the correct position and correct number");
            Console.WriteLine("The Number has been generated XXXX, each digit is between 1 and 6.  Please guess appropriately");
            ProcessGameLogic(ref model, ref guesses);
        }

        private static void ResetGameLogic(ref MasterMindModel model, ref GuessModel guesses)
        {
            //restart logic
            model = new MasterMindModel();
            guesses = new GuessModel();
            Console.Clear();
            Console.WriteLine("Welcome to MasterMind!  This game is with Travis's style so be prepared to guess!");
            Console.WriteLine("The current hints are as follows: 'Number:-' means the number exists but is not in the right position");
            Console.WriteLine("The current hints are as follows: 'Number:+' means the number is in the correct position and correct number");
            Console.WriteLine("The Number has been generated XXXX, each digit is between 1 and 6.  Please guess appropriately");
        }

        /// <summary>
        /// Figures out the guesses
        /// </summary>
        /// <param name="model"></param>
        /// <param name="guesses"></param>
        private static void ProcessGameLogic(ref MasterMindModel model, ref GuessModel guesses)
        {
            do
            {
                Console.WriteLine("Please guess the number: ");
                string? lineRead = Console.ReadLine();
                int typedInNumber = 0;
                bool isNumber = int.TryParse(lineRead, out typedInNumber);
                if (string.IsNullOrEmpty(lineRead)) //checks to make sure lineread is not null or empty
                {
                    Console.WriteLine("Nothing was typed in for guessing.  Please try again.");
                }
                else if (!isNumber && !lineRead.Equals(string.Format("cheat", StringComparison.InvariantCultureIgnoreCase))) //checks to make sure it is not a number and also teh word not cheat
                {
                    Console.WriteLine("You did not type in a number.  Please type in a number");
                }
                else if (lineRead.Equals(string.Format("cheat", StringComparison.InvariantCultureIgnoreCase)))  //provides a cheat for debugging purposes
                {
                    //If you want to cheat, it is a simple term
                    Console.WriteLine($"The number is: {model.FullNumber}");
                }
                else
                {
                    if (model.FullNumber.Equals(lineRead))
                    {
                        Console.WriteLine("Congratulations!  You won!");
                        Console.WriteLine("Press 'q' to quit or press 'r' to restart");
                        string? restartOrQuit = Console.ReadLine();
                        if (!string.IsNullOrEmpty(restartOrQuit))
                        {
                            if (restartOrQuit.Equals("q", StringComparison.InvariantCultureIgnoreCase))
                            {
                                break;
                            }
                            else if (restartOrQuit.Equals("r", StringComparison.InvariantCultureIgnoreCase))
                            {
                                ResetGameLogic(ref model, ref guesses);
                            }
                        }
                    }
                    else
                    {
                        char[] individualGuessCharacters = lineRead.ToArray();
                        char[] charsForHints = new char[individualGuessCharacters.Length];
                        int position = 0;
                        foreach (char guessCharacter in individualGuessCharacters)
                        {
                            bool doesGuessCharacterExistInAnswer = model.FullNumber.Contains(guessCharacter);
                            int integerGuessCharacter = Convert.ToInt32(guessCharacter.ToString());
                            if (doesGuessCharacterExistInAnswer)
                            {
                                if (position == 0)
                                {
                                    if (integerGuessCharacter == model.Number1)
                                    {
                                        guesses.hintGuessModels.Add(new HintGuessModel() { HintGuess = "+", NumberGuess = integerGuessCharacter });
                                    }
                                    else
                                    {
                                        guesses.hintGuessModels.Add(new HintGuessModel() { HintGuess = "-", NumberGuess = integerGuessCharacter });
                                    }
                                }
                                else if (position == 1)
                                {
                                    if (integerGuessCharacter == model.Number2)
                                    {
                                        guesses.hintGuessModels.Add(new HintGuessModel() { HintGuess = "+", NumberGuess = integerGuessCharacter });
                                    }
                                    else
                                    {
                                        guesses.hintGuessModels.Add(new HintGuessModel() { HintGuess = "-", NumberGuess = integerGuessCharacter });
                                    }
                                }
                                else if (position == 2)
                                {
                                    if (integerGuessCharacter == model.Number3)
                                    {
                                        guesses.hintGuessModels.Add(new HintGuessModel() { HintGuess = "+", NumberGuess = integerGuessCharacter });
                                    }
                                    else
                                    {
                                        guesses.hintGuessModels.Add(new HintGuessModel() { HintGuess = "-", NumberGuess = integerGuessCharacter });
                                    }
                                }
                                else if (position == 3)
                                {
                                    if (integerGuessCharacter == model.Number4)
                                    {
                                        guesses.hintGuessModels.Add(new HintGuessModel() { HintGuess = "+", NumberGuess = integerGuessCharacter });
                                    }
                                    else
                                    {
                                        guesses.hintGuessModels.Add(new HintGuessModel() { HintGuess = "-", NumberGuess = integerGuessCharacter });
                                    }
                                }
                            }
                            else
                            {
                                guesses.hintGuessModels.Add(new HintGuessModel() { HintGuess = "", NumberGuess = integerGuessCharacter });
                            }
                            ++position;
                        }
                        guesses.hintGuessModels.OrderByDescending(x => x.HintGuess).ToList();
                        foreach (var hintGuess in guesses.hintGuessModels)
                        {
                            Console.WriteLine($"{hintGuess.NumberGuess}:{hintGuess.HintGuess}");
                        }
                        guesses.hintGuessModels = new List<HintGuessModel>();
                    }

                    guesses.IncrementGuesses();
                    string totalGuessesLeft = (guesses.MaxGuesses - guesses.NumberOfGuesses).ToString();
                    Console.WriteLine($"Number of guesses left: {totalGuessesLeft}");
                }
            }
            while (guesses.MaxGuesses > guesses.NumberOfGuesses);

            if (guesses.NumberOfGuesses == guesses.MaxGuesses)
            {
                Console.WriteLine("You lose, please try again.");
                Console.WriteLine("Press 'q' to quit or press 'r' to restart");
                string? restartOrQuit = Console.ReadLine();
                if (!string.IsNullOrEmpty(restartOrQuit))
                {
                    if (restartOrQuit.Equals("q", StringComparison.InvariantCultureIgnoreCase))
                    {
                    }
                    else if (restartOrQuit.Equals("r", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ResetGameLogic(ref model, ref guesses);
                        ProcessGameLogic(ref model, ref guesses);
                    }
                }
            }
        }
    }
}
