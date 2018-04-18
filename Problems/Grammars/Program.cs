using System;
using System.Text;

namespace Grammars
{
    class Program
    {
        enum TokenType
        {
            EOF=-1,
            EOL=0,
            FLECHA,
            LETRAMAISCULA,
            SINALMENOR,
            SINALMAIOR,
            TERMINAL,
            UNKNOWN
        };

        struct TOKEN
        {
            public TokenType ttype;
            public double tvalue;
            public int position;
            public int length;
        };

        static TOKEN token;

        static string input = null;
        static int n = 0;

        static int result = 0;

        static TokenType next_token()
        {
            int pos = token.position + token.length;

            char c = (char)0;

            while (pos < n && ((c = input[pos]) == ' ' || c == '\t' || c == '\r'))
                pos++;

            if (c > 0)
                Console.Write("pos: {0},", pos);

            token.position = pos;
            token.length = 1;

            if (pos >= n)
                return token.ttype = TokenType.EOF;

            switch (c)
            {
                case '<':
                    return token.ttype = TokenType.SINALMENOR;

                case '>':
                    return token.ttype = TokenType.SINALMAIOR;

                case '\0':
                case '\n':
                    return token.ttype = TokenType.EOL;
            }

            if (c >= 'A' && c <= 'Z')
            {
                return token.ttype = TokenType.LETRAMAISCULA;
            }

            if (c == '-' && input[pos + 1] == '-' && input[pos + 2] == '>')
            {
                pos += 2;
                token.length += 2;
                return token.ttype = TokenType.FLECHA;
            }

            return token.ttype = TokenType.TERMINAL;
        }


        static void Main()
        {
            input = ReadInput();
            n = input.Length;

            Console.WriteLine("Eu li:");
            Console.Write(input);

            Console.WriteLine("Eu reconheci");

            token.position = -token.length;
            next_token();

            //gramatica();

            if (result == 0)
                Console.WriteLine("CORRETO");
            else
                Console.WriteLine("ERRO");
        }

        private static string ReadInput()
        {
            var sb = new StringBuilder();
            string line = null;
            do
            {
                line = Console.ReadLine();
                if (line == null)
                    break;
                sb.AppendLine(line);
            } while (true);

            return sb.ToString();
        }
    }
}
