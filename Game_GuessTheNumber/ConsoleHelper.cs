using System;

namespace Game_GuessTheNumber
{
    public class ConsoleHelper
    {
        public static int GetNumberFromUser()
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

            } while (!isUserGood);
            return userGuess;
        }
    }
}
