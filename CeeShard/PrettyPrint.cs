namespace CeeShard;

public class PrettyPrint
{
    private string binaryExpr(BinaryExpr expr)
    {
        // i love chatgpt code and garbage formatting cuz idk wtf this is
        var leftExpr = expr.Left is NumericLiteral left ? Convert.ToString(left.Value) : this.binaryExpr(expr.Left as BinaryExpr);
        var rightExpr = expr.Right is NumericLiteral right ? Convert.ToString(right.Value) : this.binaryExpr(expr.Right as BinaryExpr);

        return $"{leftExpr} {expr.Operator} {rightExpr}";
    }

    public string ParseExpression(Expr expr)
    {
        switch(expr.Kind)
        {
            case NodeType.BinaryExpr: return binaryExpr(expr as BinaryExpr);
            case NodeType.NumericLiteral: return (expr as NumericLiteral).Value.ToString();
            case NodeType.Identifier: return (expr as Identifier).Symbol + " (variable)";
            
            default: throw new Exception($"PrettyPrint: Unknown expression type: {expr.Kind}");
        }
    }
    
}