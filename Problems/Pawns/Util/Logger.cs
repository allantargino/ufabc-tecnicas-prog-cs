using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pawns
{
    static class Logger
    {
        public static bool consoleIsEnabled = false;
        public static bool txtIsEnabled = false;

        public static string path = "/mnt/c/temp/my_log.txt";

        static Logger()
        {
            File.Delete(path);
        }

        public static void WriteLine(string content)
        {
            if (!consoleIsEnabled)
                return;

            Console.WriteLine(content);
        }

        public static void LogLine(string content)
        {
            if (!txtIsEnabled)
                return;

            File.AppendAllText(path, content + "\n");
        }

        public static void DrawBoard(State currentState)
        {
            if (!consoleIsEnabled)
                return;

            Console.WriteLine($"Turn: {currentState.Player}");

            Console.WriteLine("");
            var matrix = new string[3, 5];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 5; j++)
                    matrix[i, j] = "o";

            matrix[0, currentState.Configuration.Column1.PositionPlayer1] = "1";
            matrix[0, currentState.Configuration.Column1.PositionPlayer2] = "2";
            matrix[1, currentState.Configuration.Column2.PositionPlayer1] = "1";
            matrix[1, currentState.Configuration.Column2.PositionPlayer2] = "2";
            matrix[2, currentState.Configuration.Column3.PositionPlayer1] = "1";
            matrix[2, currentState.Configuration.Column3.PositionPlayer2] = "2";

            for (int j = 4; j >= 0; j--)
            {
                for (int i = 2; i >= 0; i--)
                {
                    Console.Write(matrix[i, j] + "");
                }
                Console.WriteLine();
            }
        }
    }
}
