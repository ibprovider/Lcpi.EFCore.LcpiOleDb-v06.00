////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.08.2022.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_ExpressionUtils

static class Structure_ExpressionUtils
{
 public static Expression RemoveConvertToObject(Expression expr)
 {
  Expression e=expr;

  for(;;)
  {
   Debug.Assert(!Object.ReferenceEquals(e,null));

   var unaryExpression=e as UnaryExpression;

   if(Object.ReferenceEquals(unaryExpression,null))
    break;

   if(!unaryExpression.NodeType.Extension__IsConvert2())
    break;

   Debug.Assert(!Object.ReferenceEquals(unaryExpression.Operand,null));
   Debug.Assert(!Object.ReferenceEquals(unaryExpression.Operand.Type,null));

   if(unaryExpression.Type==Structure_TypeCache.TypeOf__System_Object)
   {
    e=unaryExpression.Operand;

    continue;
   }//if

   break;
  }//for[ever]

  Debug.Assert(!Object.ReferenceEquals(e,null));

  return e;
 }//RemoveConvertToObject
};//class Structure_ExpressionUtils

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
