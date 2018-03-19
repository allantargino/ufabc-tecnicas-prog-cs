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

        public static string Path
        {
            get
            {
                if (Environment.OSVersion.Platform == PlatformID.Unix)
                    return "/mnt/c/temp/my_log.txt";
                else
                    return "c:/temp/my_log.txt";
            }
        }


        static Logger()
        {
            File.Delete(Path);
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

            File.AppendAllText(Path, content + Environment.NewLine);
        }

        public static void DrawBoard(State currentState)
        {
            Console.WriteLine("");
            Console.WriteLine($"Turn: {currentState.Player}");
            Console.WriteLine("Board:");

            var matrix = new string[3, 5];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 5; j++)
                    matrix[i, j] = ".";

            matrix[0, currentState.Configuration.Column1.PositionPlayer1] = "O";
            matrix[0, currentState.Configuration.Column1.PositionPlayer2] = "X";
            matrix[1, currentState.Configuration.Column2.PositionPlayer1] = "O";
            matrix[1, currentState.Configuration.Column2.PositionPlayer2] = "X";
            matrix[2, currentState.Configuration.Column3.PositionPlayer1] = "O";
            matrix[2, currentState.Configuration.Column3.PositionPlayer2] = "X";

            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    Console.Write(matrix[i, j] + "");
                }
                Console.WriteLine();
            }
            
            Console.WriteLine();
        }
    }
}
