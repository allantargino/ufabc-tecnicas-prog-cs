using System;
using System.IO;
using System.Text;

namespace Grammars
{
    class Program
    {
        enum TokenType
        {
            EOF = -1,
            EOL = 0,
            FLECHA,
            LETRAMAISCULA,
            SINALMENOR,
            SINALMAIOR,
            TERMINAL,
            VAZIO,
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

            token.position = pos;
            token.length = 1;

            if (pos >= n)
                return token.ttype = TokenType.EOF;

            if (token.ttype == TokenType.FLECHA && c == '\n')
            {
                token.position--;
                return token.ttype = TokenType.VAZIO;
            }

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

            if (pos + 4 < n)
            {
                if (c == '-' && input[pos + 1] == '-' && input[pos + 2] == '-' && input[pos + 3] == '-' && input[pos + 4] == '>')
                {
                    pos += 4;
                    token.length += 4;
                    return token.ttype = TokenType.FLECHA;
                }
            }

            if(pos +2 < n)
            {
                if (c == '-' && input[pos + 1] == '-' && input[pos + 2] == '>')
                {
                    pos += 2;
                    token.length += 2;
                    return token.ttype = TokenType.FLECHA;
                }
            }

            return token.ttype = TokenType.TERMINAL;
        }


        static int linha = 1;
        static void gramatica()
        {
            if (result == -1)
                return;

            regra();
            TOKEN t = token;

            if (t.ttype == TokenType.EOF)
                return;

            linha++;
            gramatica();
        }

        static void regra()
        {
            if (result == -1)
                return;

            sentenca1();

            TOKEN t = token;

            if (t.ttype != TokenType.FLECHA)
            {
                result = -1;
                return;
            }

            next_token();

            sentenca2();

            if (token.ttype != TokenType.EOL)
                result = -1;
            else
                next_token();
            return;
        }

        static void sentenca1()
        {
            if (result == -1)
                return;

            elemento();

            //sentenca2();
        }

        static void sentenca2()
        {
            if (result == -1)
                return;

            TOKEN t = token;

            if (t.ttype == TokenType.VAZIO)
            {
                next_token();
                return;
            }

            if (t.ttype == TokenType.EOL)
                return;

            elemento();

            sentenca2();
        }

        static void elemento()
        {
            if (result == -1)
                return;

            if (token.ttype == TokenType.TERMINAL)
            {
                next_token();
                return;
            }

            variavel();
        }

        static void variavel()
        {
            if (result == -1)
                return;

            if (token.ttype == TokenType.LETRAMAISCULA)
            {
                next_token();
                return;
            }

            if (token.ttype != TokenType.SINALMENOR)
            {
                result = -1;
                return;
            }

            next_token();

            id();

            if (token.ttype != TokenType.SINALMAIOR)
                result = -1;
            else
                next_token();
            return;
        }

        static void id()
        {
            if (result == -1)
                return;

            TOKEN t = token;

            if (t.ttype != TokenType.TERMINAL)
            {
                result = -1;
                return;
            }

            next_token();

            id_linha();
        }

        static void id_linha()
        {
            if (result == -1)
                return;

            TOKEN t = token;

            if (t.ttype == TokenType.SINALMAIOR)
                return;

            if (t.ttype != TokenType.TERMINAL)
            {
                result = -1;
                return;
            }

            next_token();

            id_linha();
        }

        static void Main()
        {
            try
            {
                //input = File.ReadAllText(@"C:\Users\altargin\Downloads\grammar\in\file29");
                input = ReadInput();
                n = input.Length;

                token.position = -token.length;
                next_token();

                gramatica();
            }
            catch (Exception)
            {
                result = -1;
            }

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
