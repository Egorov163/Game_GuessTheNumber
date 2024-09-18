using Game_GuessTheNumber.Models;
using System;

namespace Game_GuessTheNumber
{
    public class GuessNumberGame
    {
        public GuessNumberGame(GameRule gameRule)
        {
            GameRule = gameRule;
        }
        private GameRule GameRule { get; set; }
        public void Play()
        {
            var isWin = false;

            Console.WriteLine("It's game: Guess the number");

            for (int attempt = 0; attempt < GameRule.MaxAttemptCount; attempt++)
            {
                int userGuess;

                Console.WriteLine($"Attempt: {attempt + 1}/{GameRule.MaxAttemptCount} " +
                    $"\t Range [{GameRule.MinNumber}, {GameRule.MaxNumber}]." +
                    $"\t Enter any number");

                userGuess = GetUserGuess();

                if (GameRule.TheNumber == userGuess)
                {
                    isWin = true;
                    break;
                }
                else
                {
                    if (GameRule.TheNumber < userGuess)
                    {
                        GameRule.MaxNumber = userGuess - 1;
                        Console.WriteLine("Less");
                    }
                    else
                    {
                        GameRule.MinNumber = userGuess + 1;
                        Console.WriteLine("More");
                    }
                }
            }

            if (isWin)
            {
                Console.WriteLine("Win!");
            }
            else
            {
                Console.WriteLine("Loose");
            }
            Console.WriteLine("The end");
        }
        private int GetUserGuess()
        {
            int userGuess;
            bool isUserGood = true;
            do
            {
                userGuess = ConsoleHelper.GetNumberFromUser();

                if (userGuess < GameRule.MinNumber)
                {
                    Console.WriteLine($"Can't be less then {GameRule.MinNumber}");
                    isUserGood = false;
                }
                else if (userGuess > GameRule.MaxNumber)
                {
                    Console.WriteLine($"Can't be more then {GameRule.MaxNumber}");
                    isUserGood = false;
                }
                else
                {
                    isUserGood = true;
                }

            } while (!isUserGood);

            return userGuess;
        }
    }
}
