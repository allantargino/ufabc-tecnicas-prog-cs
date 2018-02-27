using System;
using System.Collections.Generic;
using System.Text;

namespace Proj1_Peoes
{
    static class Logger
    {
        public static bool isEnabled = false;

        public static void WriteLine(string content)
        {
            if (isEnabled)
                Console.WriteLine(content);
        }
    }
}
