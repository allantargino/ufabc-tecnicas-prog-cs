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
            Logger.LogLine($"Args[0]:{args[0]}");

            GameFactory.Init();
            var gameAdvisor = GameFactory.GenerateGameAdvisor();

            int myPlayerNumber;
            State currentState;

            Logger.LogLine("Waiting to know who I am.");
            string myPlayer = Console.ReadLine();
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
                    var diff = GetDifferenceBetweenStates(lastState, currentState);
                    Logger.LogLine(diff);
                    Console.WriteLine(diff);
                }
                else
                {
                    var line = Console.ReadLine();
                    Logger.LogLine(line);
                    currentState = GetPossibleMoviment(lastState, line);
                }

                //Logger.DrawBoard(currentState);
            }

            Logger.LogLine("Game Over!");
        }



        private static State GetPossibleMoviment(State currentState, string line)
        {
            var chars = line.Split(' ');

            var column = int.Parse(chars[0]);
            var moviment = int.Parse(chars[1]);

            return GameFactory.GetPossibleState(column, moviment, currentState);
        }

        private static string GetDifferenceBetweenStates(State lastState, State currentState)
        {
            int column = -1;
            int moviment = -1;

            if (lastState.Configuration.Column1 != currentState.Configuration.Column1)
            {
                column = 1;
                if (currentState.Player == 1)
                    moviment = currentState.Configuration.Column1.PositionPlayer1;
                else
                    moviment = currentState.Configuration.Column1.PositionPlayer2;
            }
            else if (lastState.Configuration.Column2 != currentState.Configuration.Column2)
            {
                column = 2;
                if (currentState.Player == 1)
                    moviment = currentState.Configuration.Column2.PositionPlayer1;
                else
                    moviment = currentState.Configuration.Column2.PositionPlayer2;
            }
            else
            {
                column = 3;
                if (currentState.Player == 1)
                    moviment = currentState.Configuration.Column3.PositionPlayer1;
                else
                    moviment = currentState.Configuration.Column3.PositionPlayer2;

            }

            return $"{column} {moviment}";
        }
    }
}
