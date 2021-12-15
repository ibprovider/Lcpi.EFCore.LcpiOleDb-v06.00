////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 24.11.2020.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__QueryOptimizingExpressionVisitor

sealed class LcpiOleDb__QueryOptimizingExpressionVisitor
 :EXT.Microsoft.EntityFrameworkCore.Query.Internal.QueryOptimizingExpressionVisitor
{
 public LcpiOleDb__QueryOptimizingExpressionVisitor()
 {
 }//LcpiOleDb__QueryOptimizingExpressionVisitor

 //protected interface ---------------------------------------------------
 protected override bool LCPI__GetPermissionForOptimization(LCPI__OptimizationRule optRule)
 {
  //
  // r.VARCHAR__8=null
  //
  // r.VARCHAR__8.EndsWith("")
  //
  // We expected NULL
  //
  // EF Core "optimized" to true
  //

  if(optRule==LCPI__OptimizationRule.VisitMethodCall__PreOpt_001)
   return false;

  return base.LCPI__GetPermissionForOptimization(optRule);
 }//LCPI__GetPermissionForOptimization
};//class LcpiOleDb__QueryOptimizingExpressionVisitor

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors
