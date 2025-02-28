// BIG TO DO: ADD THIS PACKAGE!!!!!!! https://github.com/nrother/dynamiclua

namespace CeeShard;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CeeShard CLI (v0.02)");
        
        // basic CLI
        while(true)
        {
            Console.Write("> ");
            
            Lexer lexer = new Lexer();
            Parser parser = new Parser();
            Token[] tokens = lexer.Tokenize(Console.ReadLine());
            Stmt[] stmts = parser.produceAST(tokens);

            VarDeclaration stmt = stmts[0] as VarDeclaration;
            
            PrettyPrint pretty = new();
            
            Console.WriteLine("Variable name: " + stmt.Identifier);
            Console.WriteLine("Value: " + pretty.ParseExpression(stmt.Value));
        }
    }
}