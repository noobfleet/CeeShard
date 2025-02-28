namespace CeeShardLang;

public partial class Parser
{
    private Expr parsePrimaryExpr()
    {
        switch(at().Type)
        {
            case TokenType.Identifier:
                Identifier ident = new();
                ident.Symbol = advance().Value;
                return ident;
            case TokenType.Number:
                NumericLiteral num = new();
                num.Value = Convert.ToDouble(advance().Value);
                return num;
            default: throw new Exception($"Expected expression but got {at().Value}");
        }
    }
    
    private Expr parseMultiplicativeExpr()
    {
        Expr left = parsePrimaryExpr();

        while(at().Value == "*" || at().Value == "/" || at().Value == "%")
        {
            string op = advance().Value;
            Expr right = parsePrimaryExpr();
            
            BinaryExpr binaryExpr = new BinaryExpr();
            binaryExpr.Operator = op;
            binaryExpr.Left = left;
            binaryExpr.Right = right;
            return binaryExpr;
        }
        
        return left;
    }
    
    private Expr parseAdditiveExpr()
    {
        Expr left = parseMultiplicativeExpr();

        while(at().Value == "+" || at().Value == "-")
        {
            string op = advance().Value;
            Expr right = parseMultiplicativeExpr();
            
            BinaryExpr binaryExpr = new BinaryExpr();
            binaryExpr.Operator = op;
            binaryExpr.Left = left;
            binaryExpr.Right = right;
            return binaryExpr;
        }
        
        return left;
    }
    
    private Expr ParseExpr()
    {
        return parseAdditiveExpr();
    }
}