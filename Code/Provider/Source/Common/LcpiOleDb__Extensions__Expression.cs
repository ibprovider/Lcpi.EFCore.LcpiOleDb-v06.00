////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 15.10.2020.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__Extensions__Expression

static class LcpiOleDb__Extensions__Expression
{
 public static bool Extension__IsConvert2(this ExpressionType operationID)
 {
  if(operationID==ExpressionType.Convert)
   return true;

  if(operationID==ExpressionType.ConvertChecked)
   return true;

  // [2021-10-02] I'm not sure that it is good idea
  if(operationID==ExpressionType.TypeAs)
   return true;

  return false;
 }//Extension__IsConvert2 - ExpressionType

 //-----------------------------------------------------------------------
 public static bool Extension__IsConvert2(this UnaryExpression expression)
 {
  Debug.Assert(!Object.Equals(expression,null));

  if(Extension__IsConvert2(expression.NodeType))
   return true;

  return false;
 }//Extension__IsConvert2 - UnaryExpression
};//class LcpiOleDb__Extensions__Expression

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb
