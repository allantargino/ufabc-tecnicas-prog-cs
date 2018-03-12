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
                var lastState = currentState;
                if (lastState.Player == myPlayer)
                {
                    currentState = gameAdvisor.GetNextMoviment(lastState);
                    Console.WriteLine(GetDifferenceBetweenStates(lastState, currentState));
                }
                else
                {
                    var line = Console.ReadLine();
                    currentState = GetPossibleMoviment(lastState, line);
                }

                DrawBoard(currentState);
            }

            Console.WriteLine("Game Over!");
            Console.ReadLine();
        }

        private static void DrawBoard(State currentState)
        {
            Console.WriteLine($"Turn: {currentState.Player}");

            Console.WriteLine("");
            var matrix = new string[3,5];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 5; j++)
                    matrix[i, j] = "o";

            matrix[0, currentState.Configuration.Column1.PositionPlayer1] = "1";
            matrix[0, currentState.Configuration.Column1.PositionPlayer2] = "2";
            matrix[1, currentState.Configuration.Column2.PositionPlayer1] = "1";
            matrix[1, currentState.Configuration.Column2.PositionPlayer2] = "2";
            matrix[2, currentState.Configuration.Column3.PositionPlayer1] = "1";
            matrix[2, currentState.Configuration.Column3.PositionPlayer2] = "2";

            for (int j = 4; j >=0; j--)
            {
                for (int i = 2; i >=0; i--)
                {
                    Console.Write(matrix[i,j] + "");
                }
                Console.WriteLine();
            }
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
                if(currentState.Player==1)
                    moviment = currentState.Configuration.Column1.PositionPlayer1;
                else
                    moviment = currentState.Configuration.Column1.PositionPlayer2;
            }
            else if(lastState.Configuration.Column2 != currentState.Configuration.Column2){
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
