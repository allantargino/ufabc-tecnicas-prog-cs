using System;
using System.Collections.Generic;
using System.Linq;

namespace Pawns
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Logger.consoleIsEnabled = false;
            Logger.txtIsEnabled = true;

            Logger.LogLine("Game has been started!");

            GameFactory.Init();
            var gameAdvisor = GameFactory.GenerateGameAdvisor();

            int myPlayerNumber;
            State currentState;

            if (args.Length == 0) throw new ArgumentNullException(nameof(args));
            string myPlayer = args[0];

            Logger.LogLine(myPlayer);

            if (myPlayer == "primeiro")
            {
                myPlayerNumber = 0;
            }
            else if (myPlayer == "segundo")
            {
                myPlayerNumber = 1;
            }
            else
            {
                throw new InvalidOperationException("Não pode escolher esse jogador!");
            }

            currentState = GameFactory.GetInitialState(0);

            while (!currentState.IsGameOver())
            {
                var lastState = currentState;
                if (currentState.Player == myPlayerNumber)
                {
                    currentState = gameAdvisor.GetNextMoviment(lastState);
                    var diff = GameRules.GetDifferenceBetweenStates(lastState, currentState);
                    Logger.LogLine(diff);
                    Console.WriteLine(diff);
                }
                else
                {
                    var line = Console.ReadLine();
                    Logger.LogLine(line);
                    currentState = GameRules.GetPossibleMoviment(lastState, line);
                }

                //Logger.DrawBoard(currentState);
            }

            Logger.LogLine("Game Over!");
        }
        
    }
}
