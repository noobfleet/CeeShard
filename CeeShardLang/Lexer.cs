namespace CeeShardLang;

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

public class Lexer
{
    private Dictionary<string, TokenType> KeywordType;

    public Lexer()
    {
        KeywordType = new();
        
        KeywordType.Add("var", TokenType.VarDeclaration);
        KeywordType.Add("const", TokenType.ConstantDeclaration);
    }

    private List<Token> tokens = new();
    
    public Token[] Tokenize(string str)
    {
        int i = 0;
        char c;
        while(i < str.Length)
        {
            c = str[i];
            
            // whitespace
            if(c == '\n' || c == '\r' || c == '\t' || c == ' ')
            {
                i++; continue; }
            // keyword symbols
            if(c == '='){ tokens.Add(new Token(TokenType.Equals, "=")); i++; continue; }
            if(c == ';'){ tokens.Add(new Token(TokenType.EndOfStmt, ";")); i++; continue; }
            if(c == '-' || c == '+' || c == '*' || c == '/' || c == '%' || c == '^')
            {
                tokens.Add(new Token(TokenType.Operator, c.ToString()));
                i++;
                continue;
            }

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
            if (char.IsAsciiLetter(c))
            {
                string identifier = str[i].ToString();
                i++;
                while (i < str.Length && char.IsAsciiLetter(str[i]))
                {
                    identifier += str[i];
                    i++;
                }

                if(KeywordType.TryGetValue(identifier, out TokenType t))
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
        
        tokens.Add(new Token(TokenType.EndOfStmt, "EOF"));
        
        return tokens.ToArray();
    }
}