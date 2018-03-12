using System;
using System.Collections.Generic;
using System.Linq;

namespace Pawns
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Logger.isEnabled = false;
            Console.WriteLine("Game has been started!");

            GameFactory.Init();
            var gameAdvisor = GameFactory.GenerateGameAdvisor();

            int myPlayer = 0;
            State currentState = GameFactory.GetInitialState(myPlayer);
            while (!currentState.IsTerminal())
            {
                if(currentState.Player == myPlayer)
                {
                    currentState = gameAdvisor.GetNextMoviment(currentState);
                    Console.WriteLine("Jogada");
                }
                else
                {
                    var line = Console.ReadLine();
                    currentState = GetPossibleMoviment(line);
                }
            }


            Console.WriteLine("Game Over!");
            Console.ReadLine();
        }


        private static State GetPossibleMoviment(string line)
        {
            var chars = line.Split(' ');

            var column = int.Parse(chars[0]);
            var moviment = int.Parse(chars[1]);


        }
    }
}
