namespace CeeShard;

public class PrettyPrint
{
    public string BinaryExpr(BinaryExpr expr)
    {
        // i love chatgpt code and garbage formatting cuz idk wtf this is
        var leftExpr = expr.Left is NumericLiteral left ? Convert.ToString(left.Value) : this.BinaryExpr(expr.Left as BinaryExpr);
        var rightExpr = expr.Right is NumericLiteral right ? Convert.ToString(right.Value) : this.BinaryExpr(expr.Right as BinaryExpr);

        return $"{leftExpr} {expr.Operator} {rightExpr}";
    }
}