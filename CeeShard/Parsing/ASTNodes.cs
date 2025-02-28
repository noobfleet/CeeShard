namespace CeeShard;

// these are for organization
public class Stmt
{
    public NodeType Kind;
}
public class Expr : Stmt { }

/*
 *
 * STATEMENTS
 * 
 */

public class LangProgram : Stmt
{
    public LangProgram()
    {
        Kind = NodeType.Program;
    }

    public List<Stmt> Body = new();
}

public class VarDeclaration : Stmt
{
    public VarDeclaration()
    {
        Kind = NodeType.VarDeclaration;
    }
    public bool IsConstant;
    public string Identifier;
    public Expr Value;
}

/*
 *
 * EXPRESSIONS
 * 
*/

public class AssignmentExpr : Expr
{
    public AssignmentExpr()
    {
        Kind = NodeType.AssignmentExpr;
    }
    public Expr Assignee;
    public Expr Value;
}

public class BinaryExpr : Expr
{
    public BinaryExpr()
    {
        Kind = NodeType.BinaryExpr;
    }
    public Expr Left;
    public Expr Right;
    public string Operator;
}

/*
 *
 * LITERALS
 * 
*/

public class Identifier : Expr
{
    public Identifier()
    {
        Kind = NodeType.Identifier;
    }
    public string Symbol;
}

public class NumericLiteral : Expr
{
    public NumericLiteral()
    {
        Kind = NodeType.NumericLiteral;
    }
    public double Value;
}