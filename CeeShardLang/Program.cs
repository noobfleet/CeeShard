namespace CeeShardLang;

class Program
{
    static void Main(string[] args)
    {
        Lexer lexer = new Lexer();
        List<Lexer.Token> tokens = lexer.Tokenize("var testVariable = 5;");
        
        for(int i = 0; i < tokens.Count; i++)
        {
            Console.WriteLine($"[{tokens[i].Type}: {tokens[i].Value}]");
        }
    }
}