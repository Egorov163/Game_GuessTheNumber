using Game_GuessTheNumber.Models;
using System;

namespace Game_GuessTheNumber
{
    public class GameRuleBuilder
    {
        public GameRule AskUserGame()
        {
            Console.WriteLine("This is a game Guess the number");
            Console.WriteLine("If you want to play with [B]ot enter B");
            Console.WriteLine("If you want to play with [U]ser enter U");


            bool IsUserGood = false;
            do
            {
                var userAnswer = Console.ReadLine().ToUpper();

                switch (userAnswer)
                {
                    case "B":
                        IsUserGood = true;
                        return BuildDefaultRule();

                    case "U":
                        IsUserGood = true;
                        return BuildRuleByUser();

                    default:
                        IsUserGood = false;
                        Console.WriteLine("Invalid data.Try again");
                        break;
                }
            } while (!IsUserGood);
            return null;

        }
        private GameRule BuildRuleByUser()
        {
            var rule = new GameRule();
            Console.WriteLine("Enter min number");
            rule.MinNumber = ConsoleHelper.GetNumberFromUser();

            Console.WriteLine("Enter max number");
            rule.MaxNumber = ConsoleHelper.GetNumberFromUser();

            Console.WriteLine("Enter the number");
            rule.TheNumber = ConsoleHelper.GetNumberFromUser();

            Console.Clear();

            rule.MaxAttemptCount = CalculateAttemptCount(rule.MinNumber, rule.MaxNumber);
            return rule;
        }
        private GameRule BuildDefaultRule()
        {
            var rule = new GameRule();

            rule.MinNumber = 1;
            rule.MaxNumber = 100;
            rule.MaxAttemptCount = CalculateAttemptCount(rule.MinNumber, rule.MaxNumber);
            var random = new Random();
            rule.TheNumber = random.Next(rule.MinNumber, rule.MaxNumber);

            return rule;
        }
        private int CalculateAttemptCount(int minNumber, int maxNumber)
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
    }
}
