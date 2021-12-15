////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 21.05.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using FB_Common__Sql_ETranslator_Unary
 =Common.Query.Sql.Expressions.Translators.FB_Common__Sql_ETranslator_Unary;

using FB_Common__UnaryOperatorTranslatorKey
 =Common.Query.Sql.FB_Common__UnaryOperatorTranslatorKey;

using FB_Common__UnaryOperatorTranslatorData
 =Common.Query.Sql.FB_Common__UnaryOperatorTranslatorData;

using FB_COMMON_ETRS_CODE
 =Common.Query.Sql.Expressions.Translators.Code;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__DataFor_UnaryOperatorTranslatorProvider

sealed partial class FB_V03_0_0__DataFor_UnaryOperatorTranslatorProvider
 :Structure.Structure_IGetDataByKey
   <FB_Common__UnaryOperatorTranslatorKey,
    FB_Common__UnaryOperatorTranslatorData>
{
 //Structure_IGetDataByKey interface -------------------------------------
 public bool TryGetData(FB_Common__UnaryOperatorTranslatorKey      key,
                        out FB_Common__UnaryOperatorTranslatorData translatorData)
 {
  Debug.Assert(!Object.ReferenceEquals(sm_ERTS,null));

  if(!sm_ERTS.TryGetValue(key.OperatorType,out translatorData))
   return false;

  Debug.Assert(!Object.ReferenceEquals(translatorData.Translator,null));

  return true;
 }//TryGetData

 //private types ---------------------------------------------------------
 private sealed class tagLevel0:Dictionary<LcpiOleDb__ExpressionType,FB_Common__UnaryOperatorTranslatorData>
 {
  public tagLevel0 Add(LcpiOleDb__ExpressionType expressionID,in FB_Common__UnaryOperatorTranslatorData translatorData)
  {
   Debug.Assert(!base.ContainsKey(expressionID));

   base.Add
    (expressionID,
     translatorData);

   return this;
  }//Add
 };//class tagLevel0

 //-------------------------------------------------------- OP1: ARRAY LENGTH
 private readonly static FB_Common__Sql_ETranslator_Unary
  sm_ETR__ArrayLength
   =new FB_COMMON_ETRS_CODE.FB_Common__Sql_ETranslator_Unary__Op1()
     .Add(Structure_TypeCache.TypeOf__System_Array_Byte,
          FB_COMMON_ETRS_CODE.FB_Common__Sql_ETranslator_Op1__ArrayLength__Array_Byte.Instance)
#if DEBUG
     .DEBUG__Complete()
#endif
    /*END*/
    ;

 private readonly static FB_Common__UnaryOperatorTranslatorData
  sm_TD__ArrayLength
   =new FB_Common__UnaryOperatorTranslatorData
     (sm_ETR__ArrayLength);

 //-------------------------------------------------------- CONVERT
 private readonly static FB_Common__UnaryOperatorTranslatorData
  sm_TD__Convert
   =new FB_Common__UnaryOperatorTranslatorData
     (Helper__Create_ETR_Convert());

 //-------------------------------------------------------- OP1: NOT
 private readonly static FB_Common__Sql_ETranslator_Unary
  sm_ETR__Not
   =new FB_COMMON_ETRS_CODE.FB_Common__Sql_ETranslator_Unary__Op1()
     .Add(Structure_TypeCache.TypeOf__System_Boolean,
          FB_COMMON_ETRS_CODE.FB_Common__Sql_ETranslator_Op1__Not.Instance)
#if DEBUG
     .DEBUG__Complete()
#endif
    /*END*/
    ;

 private readonly static FB_Common__UnaryOperatorTranslatorData
  sm_TD__Not
   =new FB_Common__UnaryOperatorTranslatorData
     (sm_ETR__Not);

 //-------------------------------------------------------- OP1: NEGATE
 private readonly static FB_Common__Sql_ETranslator_Unary
  sm_ETR__Negate
   =new FB_COMMON_ETRS_CODE.FB_Common__Sql_ETranslator_Unary__Op1()
     .Add(Structure_TypeCache.TypeOf__System_Int64,
          D1.Expressions.Translators.Code.FB_V03_0_0_D1__Sql_ETranslator_Op1__Negate__STD.Instance)
     .Add(Structure_TypeCache.TypeOf__System_Decimal,
          D1.Expressions.Translators.Code.FB_V03_0_0_D1__Sql_ETranslator_Op1__Negate__STD.Instance)
     .Add(Structure_TypeCache.TypeOf__System_Single,
          D1.Expressions.Translators.Code.FB_V03_0_0_D1__Sql_ETranslator_Op1__Negate__STD.Instance)
     .Add(Structure_TypeCache.TypeOf__System_Double,
          D1.Expressions.Translators.Code.FB_V03_0_0_D1__Sql_ETranslator_Op1__Negate__STD.Instance)
     .Add(Structure_TypeCache.TypeOf__System_TimeSpan,
          D1.Expressions.Translators.Code.FB_V03_0_0_D1__Sql_ETranslator_Op1__Negate__STD.Instance)

     .Add(Structure_TypeCache.TypeOf__System_Int32,
          D0.Expressions.Translators.Code.FB_V03_0_0_D0__Sql_ETranslator_Op1__Negate__Int32.Instance)
     .Add(Structure_TypeCache.TypeOf__System_Int16,
          D0.Expressions.Translators.Code.FB_V03_0_0_D0__Sql_ETranslator_Op1__Negate__Int16.Instance)

#if DEBUG
     .DEBUG__Complete()
#endif
    /*END*/
    ;

 private readonly static FB_Common__UnaryOperatorTranslatorData
  sm_TD__Negate
   =new FB_Common__UnaryOperatorTranslatorData
     (sm_ETR__Negate);

 //-------------------------------------------------------- EQUAL (IS NULL)
 private readonly static FB_Common__UnaryOperatorTranslatorData
  sm_TD__Equal
   =new FB_Common__UnaryOperatorTranslatorData
     (FB_COMMON_ETRS_CODE.FB_Common__Sql_ETranslator_Unary__Equal.Instance);

 //-------------------------------------------------------- NOT_EQUAL (IS NOT NULL)
 private readonly static FB_Common__UnaryOperatorTranslatorData
  sm_TD__NotEqual
   =new FB_Common__UnaryOperatorTranslatorData
     (FB_COMMON_ETRS_CODE.FB_Common__Sql_ETranslator_Unary__NotEqual.Instance);

 //-------------------------------------------------------- UNARY OPS
 private readonly static tagLevel0
  sm_ERTS
   =new tagLevel0()
     .Add(LcpiOleDb__ExpressionType.ArrayLength,
          sm_TD__ArrayLength)
     .Add(LcpiOleDb__ExpressionType.Convert,
          sm_TD__Convert)
     .Add(LcpiOleDb__ExpressionType.Not,
          sm_TD__Not)
     .Add(LcpiOleDb__ExpressionType.Equal,
          sm_TD__Equal)
     .Add(LcpiOleDb__ExpressionType.NotEqual,
          sm_TD__NotEqual)
     .Add(LcpiOleDb__ExpressionType.Negate,
          sm_TD__Negate)
    /*END*/
    ;
};//class FB_V03_0_0__DataFor_UnaryOperatorTranslatorProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1
