using System;

namespace Game_GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var isWin = false;
            var minNumber = 0;
            var maxNumber = 1000;
            var totalAttemptCount = CalculateAttemptCount(minNumber, maxNumber);
            var random = new Random();
            var theNumber = random.Next(minNumber, maxNumber);

            Console.WriteLine("It's game: Guess the number");
            


            for (int attempt = 0; attempt < totalAttemptCount; attempt++)
            {
                Console.WriteLine($"Attempt: {attempt + 1}/{totalAttemptCount} " +
                    $"\t Range [{minNumber}, {maxNumber}]." +
                    $"\t Enter any number");

                int userGuess = GetUserGuess(maxNumber, minNumber);

                if (userGuess == theNumber)
                {
                    isWin = true;
                    break;
                }
                else
                {
                    Console.WriteLine();
                    if (theNumber > userGuess)
                    {
                        minNumber = userGuess;
                        Console.WriteLine("more");
                    }
                    else if (theNumber < userGuess)
                    {
                        maxNumber = userGuess - 1;
                        Console.WriteLine("less");
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

        private static int CalculateAttemptCount(int minNumber, int maxNumber)
        {
            var numberCount = maxNumber - minNumber + 1;
            var totalAttemptCount = 1;
            var number = 1;

            while (number < numberCount)
            {
                totalAttemptCount++;
                number = number * 2;
            }

            return totalAttemptCount;
        }

        private static int GetUserGuess(int maxNumber, int minNumber)
        {
            int userGuess;
            bool isUserGood;

            do
            {
                var userNumberString = Console.ReadLine();
                isUserGood = int.TryParse(userNumberString, out userGuess);

                if (!isUserGood)
                {
                    Console.WriteLine("It's not a number, enter number!");
                }
                if (userGuess < minNumber)
                {
                    Console.WriteLine($"Can't be less then {minNumber}");
                    isUserGood= false;
                }
                if (userGuess > maxNumber)
                {
                    Console.WriteLine($"Can't be more then {maxNumber}");
                    isUserGood = false;
                }
                return userGuess;

            } while (!isUserGood);
        }
    }
}
