////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 24.11.2020.
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__QueryTranslationPreprocessor

//Replacement for RelationalQueryCompilationContext

sealed class LcpiOleDb__QueryTranslationPreprocessor:QueryTranslationPreprocessor
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__QueryTranslationPreprocessor;

 //-----------------------------------------------------------------------
 public LcpiOleDb__QueryTranslationPreprocessor
         (QueryTranslationPreprocessorDependencies dependencies,
          QueryCompilationContext                  queryCompilationContext)
  :base(dependencies,queryCompilationContext)
 {
  m_relationalQueryCompilationContext = (RelationalQueryCompilationContext)queryCompilationContext;
 }//LcpiOleDb__QueryTranslationPreprocessor

 //-----------------------------------------------------------------------
 public override Expression NormalizeQueryableMethod(Expression expression)
 {
  expression = new RelationalQueryMetadataExtractingExpressionVisitor(m_relationalQueryCompilationContext).Visit(expression);

  expression = base.NormalizeQueryableMethod(expression);

  expression = new TableValuedFunctionToQueryRootConvertingExpressionVisitor(QueryCompilationContext.Model).Visit(expression);

  return expression;
 }//NormalizeQueryableMethod

 //-----------------------------------------------------------------------
 public override Expression Process(Expression query)
 {
  //query = base.Process(query);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Process),
    nameof(query),
    query);

  query = new InvocationExpressionRemovingExpressionVisitor().Visit(query);

  query = this.NormalizeQueryableMethod(query);

  query = new NullCheckRemovingExpressionVisitor().Visit(query);

  query = new SubqueryMemberPushdownExpressionVisitor(QueryCompilationContext.Model).Visit(query);

  query = new NavigationExpandingExpressionVisitor
            (this,
             QueryCompilationContext,
             Dependencies.EvaluatableExpressionFilter,
             Dependencies.NavigationExpansionExtensibilityHelper).Expand(query);

  query = new ExpressionVisitors.LcpiOleDb__QueryOptimizingExpressionVisitor().Visit(query);

  query = new NullCheckRemovingExpressionVisitor().Visit(query);

  return query;
 }//Process

 //private data ----------------------------------------------------------
 private readonly RelationalQueryCompilationContext m_relationalQueryCompilationContext;
};//class LcpiOleDb__QueryTranslationPreprocessor

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query
