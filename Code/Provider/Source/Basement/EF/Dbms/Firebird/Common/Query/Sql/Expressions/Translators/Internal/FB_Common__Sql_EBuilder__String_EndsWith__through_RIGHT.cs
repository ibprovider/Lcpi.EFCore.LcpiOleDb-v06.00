////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.06.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_EBuilder__String_EndsWith__through_RIGHT

static class FB_Common__Sql_EBuilder__String_EndsWith__through_RIGHT
{
 public static SqlExpression Exec(SqlExpression valueExpression,
                                  SqlExpression lengthExpression,
                                  SqlExpression patternExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(valueExpression,null));
  Debug.Assert(!Object.ReferenceEquals(valueExpression.Type,null));
  Debug.Assert(!Object.ReferenceEquals(valueExpression.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(valueExpression.TypeMapping.ClrType,null));

  Debug.Assert(!Object.ReferenceEquals(lengthExpression,null));
  Debug.Assert(!Object.ReferenceEquals(lengthExpression.Type,null));
  Debug.Assert(!Object.ReferenceEquals(lengthExpression.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(lengthExpression.TypeMapping.ClrType,null));

  Debug.Assert(!Object.ReferenceEquals(patternExpression,null));
  Debug.Assert(!Object.ReferenceEquals(patternExpression.Type,null));
  Debug.Assert(!Object.ReferenceEquals(patternExpression.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(patternExpression.TypeMapping.ClrType,null));

  var exprRight
   =Nodes.FB_Common__Sql_ENode_Function__SQL__RIGHT.Create
     (valueExpression,
      lengthExpression,
      FB_Common__TypeMappingCache.TypeMapping__TEXT);

  Debug.Assert(!Object.ReferenceEquals(exprRight,null));

  var exprResult
   =Nodes.FB_Common__Sql_ENode_Function__SQL__OP_EQUAL.Create
     (exprRight,
      patternExpression);

  Debug.Assert(!Object.ReferenceEquals(exprResult,null));

  return exprResult;
 }//Exec
};//class FB_Common__Sql_EBuilder__String_EndsWith__through_RIGHT

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal
