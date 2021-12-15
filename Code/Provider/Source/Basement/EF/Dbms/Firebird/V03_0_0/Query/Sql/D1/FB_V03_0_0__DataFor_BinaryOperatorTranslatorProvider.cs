////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 21.11.2020.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using FB_Common__TypeMappingCache
 =Common.FB_Common__TypeMappingCache;

using FB_Common__BinaryOperatorTranslatorKey
 =Common.Query.Sql.FB_Common__BinaryOperatorTranslatorKey;

using FB_Common__BinaryOperatorTranslatorData
 =Common.Query.Sql.FB_Common__BinaryOperatorTranslatorData;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__DataFor_BinaryOperatorTranslatorProvider

sealed partial class FB_V03_0_0__DataFor_BinaryOperatorTranslatorProvider
 :Structure.Structure_IGetDataByKey
   <FB_Common__BinaryOperatorTranslatorKey,
    FB_Common__BinaryOperatorTranslatorData>
{
 //Structure_IGetDataByKey interface -------------------------------------
 public bool TryGetData(FB_Common__BinaryOperatorTranslatorKey      key,
                        out FB_Common__BinaryOperatorTranslatorData translatorData)
 {
  Debug.Assert(!Object.ReferenceEquals(key.LeftType,null));
  Debug.Assert(!Object.ReferenceEquals(key.RightType,null));

  //
  // [2020-11-27] By designe ...
  //
  Debug.Assert(key.LeftType==key.LeftType.Extension__UnwrapNullableType());
  Debug.Assert(key.RightType==key.RightType.Extension__UnwrapNullableType());

  //
  // [2020-12-18] key contains base types.
  //
  Debug.Assert(key.LeftType==key.LeftType.Extension__UnwrapMappingClrType());
  Debug.Assert(key.RightType==key.RightType.Extension__UnwrapMappingClrType());

  Debug.Assert(!Object.ReferenceEquals(sm_Items,null));

  if(sm_Items.TryGetValue(key,out translatorData))
  {
   Debug.Assert(!Object.ReferenceEquals(translatorData.Translator,null));

   return true;
  }//if

  //Debug.Assert(!sm_Items.ContainsKey(key.OperationType));

  return false;
 }//TryGetData

 //Helper types ----------------------------------------------------------
 private sealed class tagRightTypes:Dictionary<Type,FB_Common__BinaryOperatorTranslatorData>
 {
 };//class tagRightTypes

 //-----------------------------------------------------------------------
 private sealed class tagLeftRightTypes:Dictionary<Type,tagRightTypes>
 {
  public tagLeftRightTypes Add(System.Type                                left,
                               System.Type                                right,
                               in FB_Common__BinaryOperatorTranslatorData translatorData)
  {
   Debug.Assert(!Object.ReferenceEquals(left,null));
   Debug.Assert(!Object.ReferenceEquals(right,null));

   tagRightTypes rTypes=null;

   if(!base.TryGetValue(left,out rTypes))
   {
    rTypes=new tagRightTypes();

    base.Add(left,rTypes);
   }//if

   Debug.Assert(!Object.ReferenceEquals(rTypes,null));

   Debug.Assert(!rTypes.ContainsKey(right));

   rTypes.Add(right,translatorData);

   return this;
  }//Add

  //----------------------------------------------------------------------
  public bool TryGetValue(System.Type                                 left,
                          System.Type                                 right,
                          out FB_Common__BinaryOperatorTranslatorData translatorData)
  {
   tagRightTypes rTypes=null;

   if(base.TryGetValue(left,out rTypes))
   {
    Debug.Assert(!Object.ReferenceEquals(rTypes,null));

    return rTypes.TryGetValue(right,out translatorData);
   }//if

   translatorData=default;

   return false;
  }//TryGetValue
 };//class tagLeftRightTypes

 //-----------------------------------------------------------------------
 private sealed class tagOp2Set:Dictionary<LcpiOleDb__ExpressionType,tagLeftRightTypes>
 {
  public tagOp2Set Add(LcpiOleDb__ExpressionType                  operationType,
                       System.Type                                left,
                       System.Type                                right,
                       in FB_Common__BinaryOperatorTranslatorData translatorData)
  {
   Debug.Assert(!Object.ReferenceEquals(left,null));
   Debug.Assert(!Object.ReferenceEquals(right,null));

   tagLeftRightTypes lrTypes=null;

   if(!base.TryGetValue(operationType,out lrTypes))
   {
    lrTypes=new tagLeftRightTypes();

    base.Add(operationType,lrTypes);
   }//if

   Debug.Assert(!Object.ReferenceEquals(lrTypes,null));

   lrTypes.Add(left,right,translatorData);

   return this;
  }//Add

  //----------------------------------------------------------------------
  public bool TryGetValue(in FB_Common__BinaryOperatorTranslatorKey   key,
                          out FB_Common__BinaryOperatorTranslatorData translatorData)
  {
   tagLeftRightTypes lrTypes=null;

   if(base.TryGetValue(key.OperationType,out lrTypes))
   {
    Debug.Assert(!Object.ReferenceEquals(lrTypes,null));

    return lrTypes.TryGetValue
            (key.LeftType,
             key.RightType,
             out translatorData);
   }//if

   translatorData=default;

   return false;
  }//TryGetValue
 };//class tagOp2Set

 //Helper methods --------------------------------------------------------
 private static tagOp2Set Helper__BuidOp2Set()
 {
  var op2Set
   =new tagOp2Set();

  Helper__Reg__Equal              (op2Set);
  Helper__Reg__NotEqual           (op2Set);
  Helper__Reg__LessThan           (op2Set);
  Helper__Reg__LessThanOrEqual    (op2Set);
  Helper__Reg__GreaterThan        (op2Set);
  Helper__Reg__GreaterThanOrEqual (op2Set);
  Helper__Reg__ExclusiveOr        (op2Set);
  Helper__Reg__And                (op2Set);
  Helper__Reg__Or                 (op2Set);
  Helper__Reg__LeftShift          (op2Set);
  Helper__Reg__RightShift         (op2Set);
  Helper__Reg__Modulo             (op2Set);
  Helper__Reg__AndAlso            (op2Set);
  Helper__Reg__OrElse             (op2Set);
  Helper__Reg__Concat             (op2Set);
  Helper__Reg__Add                (op2Set);
  Helper__Reg__Subtract           (op2Set);
  Helper__Reg__Multiply           (op2Set);
  Helper__Reg__Divide             (op2Set);
  Helper__Reg__ArrayIndex         (op2Set);
  Helper__Reg__Coalesce           (op2Set);

  return op2Set;
 }//Helper__BuidOp2Set

 //private data ----------------------------------------------------------
 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__Equal
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__Equal.Instance,
      /*sqlMapping*/null);

 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__NotEqual
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__NotEqual.Instance,
      /*sqlMapping*/null);

 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__LessThan
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__LessThan.Instance,
      /*sqlMapping*/null);

 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__LessThanOrEqual
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__LessThanOrEqual.Instance,
      /*sqlMapping*/null);

 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__GreaterThan
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__GreaterThan.Instance,
      /*sqlMapping*/null);

 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__GreaterThanOrEqual
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__GreaterThanOrEqual.Instance,
      /*sqlMapping*/null);

 //------------------------------------------------------------- ExclusiveOr
 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__ExclusiveOr
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__ExclusiveOr.Instance,
      /*sqlMapping*/null);

 //------------------------------------------------------------- And
 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__And
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__And.Instance,
      /*sqlMapping*/null);

 //------------------------------------------------------------- Or
 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__Or
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__Or.Instance,
      /*sqlMapping*/null);

 //------------------------------------------------------------- LeftShift
 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__LeftShift
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__LeftShift.Instance,
      /*sqlMapping*/null);

 //------------------------------------------------------------- RightShift
 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__RightShift
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__RightShift.Instance,
      /*sqlMapping*/null);

 //------------------------------------------------------------- Modulo
 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__Modulo
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__Modulo.Instance,
      /*sqlMapping*/null);

 //----------------------------------------------------------------------- AndAlso
 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__AndAlso__Boolean
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__AndAlso.Instance,
      FB_Common__TypeMappingCache.TypeMapping__BOOLEAN);

 //----------------------------------------------------------------------- OrElse
 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__OrElse__Boolean
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__OrElse.Instance,
      FB_Common__TypeMappingCache.TypeMapping__BOOLEAN);

 //----------------------------------------------------------------------- Concat
 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__Concat
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__Concat.Instance,
      /*sqlMapping*/null);

 //----------------------------------------------------------------------- Add
 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__Add__Int32
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__Add.Instance,
      FB_Common__TypeMappingCache.TypeMapping__INT32);

 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__Add__Decimal___D1
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__Add__Decimal___D1.Instance,
      /*sqlMapping*/null);

 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__Add__Double
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__Add.Instance,
      FB_Common__TypeMappingCache.TypeMapping__DOUBLE);

 //----------------------------------------------------------------------- Subtract
 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__Subtract__Int32
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__Subtract.Instance,
      FB_Common__TypeMappingCache.TypeMapping__INT32);

 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__Subtract__Decimal___D1
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__Subtract__Decimal___D1.Instance,
      /*sqlMapping*/null);

 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__Subtract__Double
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__Subtract.Instance,
      FB_Common__TypeMappingCache.TypeMapping__DOUBLE);

 //----------------------------------------------------------------------- Multiply
 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__Multiply__Int32
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__Multiply.Instance,
      FB_Common__TypeMappingCache.TypeMapping__INT32);

 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__Multiply__Double___ByForce
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__Multiply__Double___ByForce.Instance,
      /*sqlMapping*/null);

 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__Multiply__Double
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__Multiply.Instance,
      FB_Common__TypeMappingCache.TypeMapping__DOUBLE);

 //----------------------------------------------------------------------- Divide
 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__Divide__Double___ByForce
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__Divide__Double___ByForce.Instance,
      /*sqlMapping*/null);

 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__Divide__Double
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__Divide.Instance,
      FB_Common__TypeMappingCache.TypeMapping__DOUBLE);

 //----------------------------------------------------------------------- ArrayIndex
 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__ArrayIndex__Array_Byte
   =new FB_Common__BinaryOperatorTranslatorData
     (Common.Query.Sql.Expressions.Translators.Code.FB_Common__Sql_ETranslator_Op2__ArrayIndex__Array_Byte.Instance,
      /*sqlMapping*/null);

 //----------------------------------------------------------------------- Coalesce
 private static readonly FB_Common__BinaryOperatorTranslatorData
  sm_TD__Coalesce
   =new FB_Common__BinaryOperatorTranslatorData
     (D1.Expressions.Translators.Code.FB_V03_0_0__Sql_ETranslator_Op2__Coalesce.Instance,
      /*sqlMapping*/null);

 //-----------------------------------------------------------------------
 private static readonly tagOp2Set
  sm_Items
   =Helper__BuidOp2Set();
};//class FB_V03_0_0__DataFor_BinaryOperatorTranslatorProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1
