////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.06.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_EBuilder__ExtractMillisecond

static class FB_Common__Sql_EBuilder__ExtractMillisecond
{
 public static SqlExpression Exec(SqlExpression exprSource)
 {
  Debug.Assert(!Object.ReferenceEquals(exprSource,null));

  var nodeExtract
   =Nodes.FB_Common__Sql_ENode_Function__SQL__EXTRACT.Create__Millisecond
     (exprSource);

  Debug.Assert(!Object.ReferenceEquals(nodeExtract,null));
  Debug.Assert(!Object.ReferenceEquals(nodeExtract.Type,null));
  Debug.Assert(!Object.ReferenceEquals(nodeExtract.TypeMapping,null));

  var nodeTrunc
   =Nodes.FB_Common__Sql_ENode_Function__SQL__TRUNC.Create
     (nodeExtract);

  Debug.Assert(!Object.ReferenceEquals(nodeTrunc,null));
  Debug.Assert(!Object.ReferenceEquals(nodeTrunc.Type,null));
  Debug.Assert(!Object.ReferenceEquals(nodeTrunc.TypeMapping,null));

  var nodeResult
   =Nodes.FB_Common__Sql_ENode_Function__SQL__CAST_AS.Create
     (nodeTrunc,
      FB_Common__TypeMappingCache.TypeMapping__INT32);

  Debug.Assert(!Object.ReferenceEquals(nodeResult,null));
  Debug.Assert(!Object.ReferenceEquals(nodeResult.Type,null));
  Debug.Assert(!Object.ReferenceEquals(nodeResult.TypeMapping,null));

  return nodeResult;
 }//Exec
};//class FB_Common__Sql_EBuilder__ExtractMillisecond

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal
