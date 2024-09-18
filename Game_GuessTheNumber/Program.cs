using Game_GuessTheNumber.Models;
using System;

namespace Game_GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameBuilder = new GameRuleBuilder();
            var gameRule = gameBuilder.AskUserGame();

            var game = new GuessNumberGame(gameRule);
            game.Play();
        }
    }
}
