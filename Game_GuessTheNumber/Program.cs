using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = 42;

            Console.WriteLine("It's game: Guess the number");
            Console.WriteLine("Enter any number");

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

            if (userGuess==number)
            {
                Console.WriteLine("Win!");
            }
            else
            {
                Console.WriteLine("Loose!");
            }

        }
    }
}
