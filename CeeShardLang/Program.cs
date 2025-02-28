using System;
using System.IO;

namespace CeeShardLang;

class Program
{
    static void Main(string[] args)
    {
        // basic CLI
        while(true)
        {
            Console.Write("> ");
            
            Lexer lexer = new Lexer();
            List<Token> tokens = lexer.Tokenize(Console.ReadLine());

            for (int i = 0; i < tokens.Count; i++)
            {
                Console.WriteLine($"[{tokens[i].Type}: {tokens[i].Value}]");
            }
        }
    }
}