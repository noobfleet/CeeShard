namespace CeeShardLang;

public class AST
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
    
    private Token? expect(TokenType expectedType)
    {
        Token previousToken = advance();

        if(previousToken.Type != expectedType)
        {
            throw new Exception($"Expected {Enum.GetName(typeof(TokenType), expectedType)} but got {previousToken.Value}");
        }
        
        return previousToken;
    }
}