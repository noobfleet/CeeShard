namespace CeeShardLang;

public class Stmt
{
    NodeType Kind;
}

public class Expr
{
    NodeType Kind;
}

/*
 *
 * STATEMENTS
 * 
 */

public class LangProgram : Stmt
{
    NodeType Kind = NodeType.Program;
    Stmt[] Body;
}

public class VarDeclaration : Stmt
{
    NodeType Kind = NodeType.VarDeclaration;
    bool IsConstant;
    string Identifier;
    Expr Value;
}

/*
 *
 * EXPRESSIONS
 * 
*/

public class AssignmentExpr : Expr
{
    NodeType Kind = NodeType.AssignmentExpr;
    Expr Assignee;
    Expr Value;
}

/*
 *
 * LITERALS
 * 
*/