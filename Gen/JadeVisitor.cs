//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Jade.g4 by ANTLR 4.11.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="JadeParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public interface IJadeVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.parse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParse([NotNull] JadeParser.ParseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock([NotNull] JadeParser.BlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStmt([NotNull] JadeParser.StmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.caseList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCaseList([NotNull] JadeParser.CaseListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.switchStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSwitchStmt([NotNull] JadeParser.SwitchStmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.importStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitImportStmt([NotNull] JadeParser.ImportStmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.repeatStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRepeatStmt([NotNull] JadeParser.RepeatStmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.ifStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStmt([NotNull] JadeParser.IfStmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.whileStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileStmt([NotNull] JadeParser.WhileStmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCondition([NotNull] JadeParser.ConditionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.tryStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTryStmt([NotNull] JadeParser.TryStmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.undefineStmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUndefineStmt([NotNull] JadeParser.UndefineStmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.inheritList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInheritList([NotNull] JadeParser.InheritListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.classdef"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassdef([NotNull] JadeParser.ClassdefContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.args"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgs([NotNull] JadeParser.ArgsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.params"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParams([NotNull] JadeParser.ParamsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCall([NotNull] JadeParser.CallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.varAssign"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVarAssign([NotNull] JadeParser.VarAssignContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.funcAssign"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFuncAssign([NotNull] JadeParser.FuncAssignContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.getAttributes"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGetAttributes([NotNull] JadeParser.GetAttributesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.indexing"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndexing([NotNull] JadeParser.IndexingContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.funcExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFuncExpr([NotNull] JadeParser.FuncExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr([NotNull] JadeParser.ExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitList([NotNull] JadeParser.ListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JadeParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAtom([NotNull] JadeParser.AtomContext context);
}