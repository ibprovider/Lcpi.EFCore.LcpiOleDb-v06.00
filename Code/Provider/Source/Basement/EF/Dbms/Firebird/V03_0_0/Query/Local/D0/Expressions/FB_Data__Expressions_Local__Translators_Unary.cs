////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 08.10.2018.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions{
////////////////////////////////////////////////////////////////////////////////

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using T_UNARY_MAP
 =Root.Query.Local.LcpiOleDb__LocalEval_Op1__Map;

////////////////////////////////////////////////////////////////////////////////
//class FB_Data__Expressions_Local__Translators_Unary

static class FB_Data__Expressions_Local__Translators_Unary
{
 public static T_UNARY_MAP
  Data
   =new T_UNARY_MAP()
    .Reg__Convert()
    .Reg__ArrayLength()
    .Reg__Not()
    .Reg__Negate()

    /*END*/
    ;

 //Helper methods --------------------------------------------------------
 private static T_UNARY_MAP Reg__Convert(this T_UNARY_MAP Map)
 {
  Debug.Assert(!Object.ReferenceEquals(Map,null));

  Map
   .Reg(ExpressionType.Convert)

   .Add(Root.Query.Local.Expressions.Unary.Translators.ETranslator__Convert.Instance)

   /*END*/
   .Done();

  return Map;
 }//Reg__Convert

 //-----------------------------------------------------------------------
 private static T_UNARY_MAP Reg__ArrayLength(this T_UNARY_MAP Map)
 {
  Debug.Assert(!Object.ReferenceEquals(Map,null));

  Map
   .Reg(ExpressionType.ArrayLength)

   .Add(Structure_TypeCache.TypeOf__System_Array_Byte,
        Root.Query.Local.Expressions.Op1.Translators.Instances.ETranslator__ArrayLength__Array1_Byte.Instance)

   /*END*/
   .Done();

  return Map;
 }//Reg__ArrayLength

 //-----------------------------------------------------------------------
 private static T_UNARY_MAP Reg__Not(this T_UNARY_MAP Map)
 {
  Debug.Assert(!Object.ReferenceEquals(Map,null));

  Map
   .Reg(ExpressionType.Not)

   .Add(Structure_TypeCache.TypeOf__System_Boolean,
        Root.Query.Local.Expressions.Op1.Translators.Instances.ETranslator__Not__Boolean.Instance)

   .Add(Structure_TypeCache.TypeOf__System_NullableBoolean,
        Root.Query.Local.Expressions.Op1.Translators.Instances.ETranslator__Not__NullableBoolean.Instance)

   /*END*/
   .Done();

  return Map;
 }//Reg__Not

 //-----------------------------------------------------------------------
 private static T_UNARY_MAP Reg__Negate(this T_UNARY_MAP Map)
 {
  Debug.Assert(!Object.ReferenceEquals(Map,null));

  Map
   .Reg(ExpressionType.Negate)

   .Add(Structure_TypeCache.TypeOf__System_Int16,
        D0.Expressions.Op1.Translators.Spec.ETranslator__Negate__Int16.Instance)

   .Add(Structure_TypeCache.TypeOf__System_Int32,
        D0.Expressions.Op1.Translators.Spec.ETranslator__Negate__Int32.Instance)

   .Add(Structure_TypeCache.TypeOf__System_Int64,
        Root.Query.Local.Expressions.Op1.Translators.Instances.ETranslator__Negate__Int64.Instance)

   .Add(Structure_TypeCache.TypeOf__System_Decimal,
        Root.Query.Local.Expressions.Op1.Translators.Instances.ETranslator__Negate__Decimal.Instance)

   .Add(Structure_TypeCache.TypeOf__System_Single,
        Root.Query.Local.Expressions.Op1.Translators.Instances.ETranslator__Negate__Single.Instance)

   .Add(Structure_TypeCache.TypeOf__System_Double,
        Root.Query.Local.Expressions.Op1.Translators.Instances.ETranslator__Negate__Double.Instance)

   .Add(Structure_TypeCache.TypeOf__System_TimeSpan,
        D0.Expressions.Op1.Translators.Instances.ETranslator__Negate__TimeSpan.Instance)

   //--------------------------------------- NULLABLE

   .Add(Structure_TypeCache.TypeOf__System_NullableInt16,
        D0.Expressions.Op1.Translators.Spec.ETranslator__Negate__NullableInt16.Instance)

   .Add(Structure_TypeCache.TypeOf__System_NullableInt32,
        D0.Expressions.Op1.Translators.Spec.ETranslator__Negate__NullableInt32.Instance)

   .Add(Structure_TypeCache.TypeOf__System_NullableInt64,
        Root.Query.Local.Expressions.Op1.Translators.Instances.ETranslator__Negate__NullableInt64.Instance)

   .Add(Structure_TypeCache.TypeOf__System_NullableDecimal,
        Root.Query.Local.Expressions.Op1.Translators.Instances.ETranslator__Negate__NullableDecimal.Instance)

   .Add(Structure_TypeCache.TypeOf__System_NullableSingle,
        Root.Query.Local.Expressions.Op1.Translators.Instances.ETranslator__Negate__NullableSingle.Instance)

   .Add(Structure_TypeCache.TypeOf__System_NullableDouble,
        Root.Query.Local.Expressions.Op1.Translators.Instances.ETranslator__Negate__NullableDouble.Instance)

   .Add(Structure_TypeCache.TypeOf__System_NullableTimeSpan,
        D0.Expressions.Op1.Translators.Instances.ETranslator__Negate__NullableTimeSpan.Instance)

   /*END*/
   .Done();

  return Map;
 }//Reg__Negate
};//class FB_Data__Expressions_Local__Translators_Unary

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions
