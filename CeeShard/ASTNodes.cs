namespace CeeShard;

public class Stmt
{
    public NodeType Kind;
}

public class Expr : Stmt
{
    
}

/*
 *
 * STATEMENTS
 * 
 */

public class LangProgram : Stmt
{
    public NodeType Kind = NodeType.Program;
    public List<Stmt> Body = new();
}

public class VarDeclaration : Stmt
{
    public NodeType Kind = NodeType.VarDeclaration;
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
    public NodeType Kind = NodeType.AssignmentExpr;
    public Expr Assignee;
    public Expr Value;
}

public class BinaryExpr : Expr
{
    public NodeType Kind = NodeType.BinaryExpr;
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
    public NodeType Kind = NodeType.Identifier;
    public string Symbol;
}

public class NumericLiteral : Expr
{
    public NodeType Kind = NodeType.NumericLiteral;
    public double Value;
}