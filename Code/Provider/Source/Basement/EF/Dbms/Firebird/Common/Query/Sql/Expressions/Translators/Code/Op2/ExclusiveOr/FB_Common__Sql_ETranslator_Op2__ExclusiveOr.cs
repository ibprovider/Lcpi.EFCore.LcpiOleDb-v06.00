////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 21.11.2020.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator_Op2__ExclusiveOr

sealed class FB_Common__Sql_ETranslator_Op2__ExclusiveOr
 :FB_Common__Sql_ETranslator_Op2
{
 public static readonly FB_Common__Sql_ETranslator_Op2
  Instance
   =new FB_Common__Sql_ETranslator_Op2__ExclusiveOr();

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator_Op2__ExclusiveOr()
 {
 }//FB_Common__Sql_ETranslator_Op2__ExclusiveOr

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(opData.OperationType==LcpiOleDb__ExpressionType.ExclusiveOr);

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight,null));
  //Debug.Assert(!Object.ReferenceEquals(opData.SqlResultTypeMapping,null));

  //------------------------------------------------------------ BUG CHECKs
#if DEBUG
 {
  var unwrapLeftType  =opData.SqlLeft.Type.Extension__UnwrapMappingClrType();
  var unwrapRightType =opData.SqlLeft.Type.Extension__UnwrapMappingClrType();

  Debug.Assert(!Object.ReferenceEquals(unwrapLeftType,null));
  Debug.Assert(!Object.ReferenceEquals(unwrapRightType,null));

  //No expected here
  Debug.Assert(unwrapLeftType  !=Structure_TypeCache.TypeOf__System_Boolean);
  Debug.Assert(unwrapRightType !=Structure_TypeCache.TypeOf__System_Boolean);
 }//local
#endif

  //------------------------------------------------------------
  var r
   =Nodes.FB_Common__Sql_ENode_Function__SQL__BIN_XOR.Create
     (opData.SqlLeft,
      opData.SqlRight);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Translate
};//class FB_Common__Sql_ETranslator_Op2__ExclusiveOr

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code
