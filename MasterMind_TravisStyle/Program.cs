using MasterMind_TravisStyle.Models;

namespace MasterMind_TravisStyle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MasterMindModel model = new MasterMindModel();
            GuessModel guesses = new GuessModel();
            Console.WriteLine("Welcome to MasterMind!  This game is with Travis's style so be prepared to guess!");
            Console.WriteLine("The Number has been generated XXXX, each digit is between 1 and 6.  Please guess appropriately");
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
                                //restart logic
                                model = new MasterMindModel();
                                guesses = new GuessModel();
                                Console.Clear();
                                Console.WriteLine("Welcome to MasterMind!  This game is with Travis's style so be prepared to guess!");
                                Console.WriteLine("The Number has been generated XXXX, each digit is between 1 and 6.  Please guess appropriately");
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
                            if (doesGuessCharacterExistInAnswer)
                            {
                                int integerGuessCharacter = Convert.ToInt32(guessCharacter.ToString());
                                if (position == 0)
                                {
                                    if (integerGuessCharacter == model.Number1)
                                    {
                                        charsForHints[position] = '+';
                                    }
                                    else
                                    {
                                        charsForHints[position] = '-';
                                    }
                                }
                                else if (position == 1)
                                {
                                    if (integerGuessCharacter == model.Number2)
                                    {
                                        charsForHints[position] = '+';
                                    }
                                    else
                                    {
                                        charsForHints[position] = '-';
                                    }
                                }
                                else if (position == 2)
                                {
                                    if (integerGuessCharacter == model.Number3)
                                    {
                                        charsForHints[position] = '+';
                                    }
                                    else
                                    {
                                        charsForHints[position] = '-';
                                    }
                                }
                                else if (position == 3)
                                {
                                    if (integerGuessCharacter == model.Number4)
                                    {
                                        charsForHints[position] = '+';
                                    }
                                    else
                                    {
                                        charsForHints[position] = '-';
                                    }
                                }
                            }
                            ++position;
                        }
                        string hintResults = new string(charsForHints.OrderBy(x => x));
                        Console.WriteLine($"{hintResults}");
                    }


                    guesses.IncrementGuesses();
                    string totalGuessesLeft = (guesses.MaxGuesses - guesses.NumberOfGuesses).ToString();
                    Console.WriteLine($"Number of guesses left: {totalGuessesLeft}");
                }
            }
            while (guesses.MaxGuesses > guesses.NumberOfGuesses);
        }
    }
}
