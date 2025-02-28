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
            Parser parser = new Parser();
            Token[] tokens = lexer.Tokenize(Console.ReadLine());
            Stmt[] stmts = parser.produceAST(tokens);

            VarDeclaration stmt = stmts[0] as VarDeclaration;
            Console.WriteLine(stmt.Identifier);
            // print value as if it were a binary expr
        }
    }
}