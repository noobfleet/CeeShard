using System.Reflection.Metadata.Ecma335;

namespace CeeShardLang;

public partial class Parser
{
    private Token[] tokens;
    // you could just shift the entire array by one every time you call advance() but thats bad for performance
    private int currentTokenIndex = 0;

    private Token at()
    {
        return tokens[currentTokenIndex];
    }
    
    private Token advance()
    {
        return tokens[currentTokenIndex++];
    }
    
    private Token expect(TokenType expectedType)
    {
        Token previousToken = advance();

        if(previousToken.Type != expectedType)
        {
            throw new Exception($"Expected {Enum.GetName(typeof(TokenType), expectedType)} but got {previousToken.Value}");
        }
        
        return previousToken;
    }

    public Stmt[] produceAST(Token[] tokens)
    {
        this.tokens = tokens;
        currentTokenIndex = 0;
        
        List<Stmt> tree = new();

        while(currentTokenIndex < tokens.Length)
        {
            tree.Add(ParseStmt());
        }
        
        return tree.ToArray();
    }
}