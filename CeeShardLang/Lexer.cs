namespace CeeShardLang;

public class Lexer
{
    private Dictionary<string, TokenType> KeywordType;

    public Lexer()
    {
        KeywordType = new();
        
        KeywordType.Add("var", TokenType.VarDeclaration);
        KeywordType.Add("=", TokenType.Equals);
        KeywordType.Add(";", TokenType.EndOfStmt);
    }
    
    public struct Token
    {
        public Token(TokenType type, string value)
        {
            this.Type = type;
            this.Value = value;
        }
        
        public TokenType Type;
        public string Value;
    }
    
    private List<Token> tokens = new();
    
    public List<Token> Tokenize(string str)
    {
        int i = 0;
        while(i < str.Length)
        {
            char c = str[i];
            
            // whitespace
            if(c == '\n' || c == '\r' || c == '\t' || c == ' ') continue;

            if (char.IsNumber(c))
            {
                string num = "";
                while (i < str.Length && char.IsNumber(str[i]))
                {
                    num += str[i];
                    i++;
                }
                tokens.Add(new Token(TokenType.Number, num.ToString()));
            }
            
            // this goes last
            // TODO: find a way to include symbols like = and letters/numbers but exclude whitespace
            if (char.IsSymbol(c) || char.IsLetterOrDigit(c))
            {
                string identifier = str[i].ToString();
                i++;
                while (i < str.Length && (char.IsLetterOrDigit(str[i]) || char.IsSymbol(str[i])))
                {
                    identifier += str[i];
                    i++;
                }

                if (KeywordType.TryGetValue(identifier, out TokenType t))
                {
                    tokens.Add(new Token(t, identifier));
                }
                else
                {
                    tokens.Add(new Token(TokenType.Identifier, identifier));
                }
            }

            i++;
        }
        
        return tokens;
    }
}