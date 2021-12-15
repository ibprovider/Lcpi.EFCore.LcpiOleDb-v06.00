////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 11.10.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using FB_Common__Sql_ETranslator_Op1
 =Common.Query.Sql.Expressions.Translators.FB_Common__Sql_ETranslator_Op1;

using FB_Common__Sql_ENode_Unary__SQL__NEGATE
 =Common.Query.Sql.Expressions.Nodes.FB_Common__Sql_ENode_Unary__SQL__NEGATE;

using FB_Common__TypeMappingCache
 =Common.FB_Common__TypeMappingCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0_D3__Sql_ETranslator_Op1__Negate__STD

sealed class FB_V03_0_0_D3__Sql_ETranslator_Op1__Negate__STD
 :FB_Common__Sql_ETranslator_Op1
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_V03_0_0_D3__Sql_ETranslator_Op1__Negate__STD;

 //-----------------------------------------------------------------------
 public static readonly FB_Common__Sql_ETranslator_Op1
  Instance
   =new FB_V03_0_0_D3__Sql_ETranslator_Op1__Negate__STD();

 //-----------------------------------------------------------------------
 private FB_V03_0_0_D3__Sql_ETranslator_Op1__Negate__STD()
 {
 }//FB_V03_0_0_D3__Sql_ETranslator_Op1__Negate__STD

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(opData.OperatorType==LcpiOleDb__ExpressionType.Negate);

  Debug.Assert(!Object.ReferenceEquals(opData.SqlOperand,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  //------------------------------------------------------------
  var sqlOperand
   =opData.SqlOperand;

  Debug.Assert(!Object.ReferenceEquals(sqlOperand,null));
  Debug.Assert(!Object.ReferenceEquals(sqlOperand.Type,null));

  //------------------------------------------------------------
  var r
   =FB_Common__Sql_ENode_Unary__SQL__NEGATE.Create
     (sqlOperand,
      sm_GetResultTypeMapping);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (r);
#endif

  return r;
 }//Translate

 //Helper methods --------------------------------------------------------
 private static RelationalTypeMapping Helper__GetResultTypeMapping(SqlExpression sqlSource)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlSource,null));

  const string c_bugcheck_src
   ="FB_V03_0_0_D3__Sql_ETranslator_Op1__Negate__STD::Helper__GetResultTypeMapping";

  var sqlSourceType
   =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      sqlSource);

  Debug.Assert(!Object.ReferenceEquals(sqlSourceType,null));

  if(sqlSourceType==Structure_TypeCache.TypeOf__System_Int64)
   return FB_Common__TypeMappingCache.TypeMapping__INT64;

  if(sqlSourceType==Structure_TypeCache.TypeOf__System_Single)
   return FB_Common__TypeMappingCache.TypeMapping__FLOAT;

  if(sqlSourceType==Structure_TypeCache.TypeOf__System_Double)
   return FB_Common__TypeMappingCache.TypeMapping__DOUBLE;

  if(sqlSourceType==Structure_TypeCache.TypeOf__System_Decimal)
  {
   //[2021-10-11] Expected
   Debug.Assert(!Object.ReferenceEquals(sqlSource.TypeMapping,null));

   //Protection
   if(Object.ReferenceEquals(sqlSource.TypeMapping,null))
    return FB_Common__TypeMappingCache.TypeMapping__DECIMAL;

   Debug.Assert(!Object.ReferenceEquals(sqlSource.TypeMapping,null));

   return sqlSource.TypeMapping;
  }//if Decimal

  if(sqlSourceType==Structure_TypeCache.TypeOf__System_TimeSpan)   // <--- D3!!!
  {
   //[2021-10-11] Expected
   Debug.Assert(!Object.ReferenceEquals(sqlSource.TypeMapping,null));
   Debug.Assert(Object.ReferenceEquals(sqlSource.TypeMapping,FB_Common__TypeMappingCache.TypeMapping__TimeSpan__as_Decimal18_4));

   return FB_Common__TypeMappingCache.TypeMapping__TimeSpan__as_Decimal18_4;
  }//if TimeSpan

  Debug.Assert(!Object.ReferenceEquals(sqlSourceType,null));

  ThrowBugCheck.SqlENode__UnsupportedArgTypes
   (c_ErrSrcID,
    "NEGATE_D3",
    sqlSourceType);

  Debug.Assert(false);

  return null;
 }//Helper__GetResultTypeMapping

 //private data ----------------------------------------------------------
 private static readonly FB_Common__Sql_ENode_Unary__SQL__NEGATE.TGetResultTypeMapping
  sm_GetResultTypeMapping
   =Helper__GetResultTypeMapping;
};//class FB_V03_0_0_D3__Sql_ETranslator_Op1__Negate__STD

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Translators.Code
