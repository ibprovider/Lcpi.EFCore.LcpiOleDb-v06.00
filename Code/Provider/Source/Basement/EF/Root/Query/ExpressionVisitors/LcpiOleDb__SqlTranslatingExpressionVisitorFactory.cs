////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.05.2018.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__SqlTranslatingExpressionVisitorFactory

sealed class LcpiOleDb__SqlTranslatingExpressionVisitorFactory:IRelationalSqlTranslatingExpressionVisitorFactory
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__SqlTranslatingExpressionVisitorFactory;

 //-----------------------------------------------------------------------
 public LcpiOleDb__SqlTranslatingExpressionVisitorFactory
                             (RelationalSqlTranslatingExpressionVisitorDependencies dependencies,
                              LcpiOleDb__ISqlTreeNodeBuilder                        sqlTreeNodeBuilder)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(dependencies),
    dependencies);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(sqlTreeNodeBuilder),
    sqlTreeNodeBuilder);

  //----------------------------------------
  m_Dependencies=dependencies;

  m_SqlTreeNodeBuilder=sqlTreeNodeBuilder;
 }//LcpiOleDb__SqlTranslatingExpressionVisitorFactory

 //ISqlTranslatingExpressionVisitorFactory interface --------------------
 public RelationalSqlTranslatingExpressionVisitor
          Create(QueryCompilationContext                     queryCompilationContext,
                 QueryableMethodTranslatingExpressionVisitor queryableMethodTranslatingExpressionVisitor)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Create),
    nameof(queryCompilationContext),
    queryCompilationContext);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Create),
    nameof(queryableMethodTranslatingExpressionVisitor),
    queryableMethodTranslatingExpressionVisitor);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(m_Dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(m_SqlTreeNodeBuilder,null));

  return new LcpiOleDb__SqlTranslatingExpressionVisitor
              (m_Dependencies,
               m_SqlTreeNodeBuilder,
               queryCompilationContext,
               queryableMethodTranslatingExpressionVisitor);
 }//Create

 //private data ----------------------------------------------------------
 private readonly RelationalSqlTranslatingExpressionVisitorDependencies m_Dependencies;
 private readonly LcpiOleDb__ISqlTreeNodeBuilder                        m_SqlTreeNodeBuilder;
};//class LcpiOleDb__SqlTranslatingExpressionVisitorFactory

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors
