////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.10.2018.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D3.Expressions{
////////////////////////////////////////////////////////////////////////////////
//using

using Common_ETRS
 =Root.Query.Local.Expressions.Converts.Translators.Instances;

using FB_CMN_ETRS
 =Firebird.Common.Query.Local.Expressions.Converts.Translators.Instances;

using FB_D3_ETRS
 =Firebird.V03_0_0.Query.Local.D3.Expressions.Converts.Translators.Instances;

////////////////////////////////////////////////////////////////////////////////
//class FB_Data__Expressions_Local__Converts

static class FB_Data__Expressions_Local__Converts
{
 public static readonly Root.Query.Local.LcpiOleDb__LocalEval_Convert__Map
  Data
   =new Root.Query.Local.LcpiOleDb__LocalEval_Convert__Map()
          .Add(Common_ETRS.ETranslators__From_Array1_Char.sm_TO__Object)

          .Add(Common_ETRS.ETranslators__From_Array1_DateTime.sm_TO__IEnumerable_DateTime)

          .Add(Common_ETRS.ETranslators__From_Array1_Int16.sm_TO__IEnumerable_Int16)

          .Add(Common_ETRS.ETranslators__From_Array1_Int32.sm_TO__IEnumerable_Int32)

          .Add(Common_ETRS.ETranslators__From_Array1_Int64.sm_TO__IEnumerable_Int64)

          .Add(Common_ETRS.ETranslators__From_Array1_NullableDateTime.sm_TO__IEnumerable_NullableDateTime)

          .Add(Common_ETRS.ETranslators__From_Array1_NullableInt16.sm_TO__IEnumerable_NullableInt16)

          .Add(Common_ETRS.ETranslators__From_Array1_NullableInt32.sm_TO__IEnumerable_NullableInt32)

          .Add(Common_ETRS.ETranslators__From_Array1_NullableInt64.sm_TO__IEnumerable_NullableInt64)

          .Add(FB_CMN_ETRS.ETranslators__From_Boolean.sm_TO__String)
          .Add(Common_ETRS.ETranslators__From_Boolean.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_Boolean.sm_TO__NullableBoolean)

          .Add(Common_ETRS.ETranslators__From_Guid.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_Guid.sm_TO__NullableGuid)

          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__Byte)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__Decimal)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__Double)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__Int16)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__Int32)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__Int64)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__SByte)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__Single)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__String)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__NullableByte)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__NullableDecimal)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__NullableDouble)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__NullableInt16)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__NullableInt32)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__NullableInt64)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__NullableSByte)
          .Add(Common_ETRS.ETranslators__From_Byte.sm_TO__NullableSingle)

          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__Byte)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__Decimal)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__Double)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__Int16)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__Int32)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__Int64)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__SByte)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__Single)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__String)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__NullableByte)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__NullableDecimal)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__NullableDouble)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__NullableInt16)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__NullableInt32)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__NullableInt64)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__NullableSByte)
          .Add(Common_ETRS.ETranslators__From_SByte.sm_TO__NullableSingle)

          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__Byte)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__Decimal)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__Double)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__Int16)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__Int32)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__Int64)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__SByte)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__Single)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__String)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__NullableByte)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__NullableDecimal)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__NullableDouble)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__NullableInt16)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__NullableInt32)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__NullableInt64)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__NullableSByte)
          .Add(Common_ETRS.ETranslators__From_Int16.sm_TO__NullableSingle)

          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__Byte)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__SByte)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__Int16)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__Int32)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__Int64)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__Decimal)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__Single)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__Double)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__String)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__NullableByte)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__NullableDecimal)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__NullableDouble)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__NullableInt16)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__NullableInt32)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__NullableInt64)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__NullableSByte)
          .Add(Common_ETRS.ETranslators__From_Int32.sm_TO__NullableSingle)

          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__Byte)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__Decimal)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__Double)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__Int16)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__Int32)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__Int64)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__SByte)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__Single)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__String)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__NullableByte)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__NullableDecimal)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__NullableDouble)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__NullableInt16)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__NullableInt32)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__NullableInt64)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__NullableSByte)
          .Add(Common_ETRS.ETranslators__From_Int64.sm_TO__NullableSingle)

          .Add(Common_ETRS.ETranslators__From_Decimal.sm_TO__Byte)
          .Add(Common_ETRS.ETranslators__From_Decimal.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_Decimal.sm_TO__String)
          .Add(Common_ETRS.ETranslators__From_Decimal.sm_TO__NullableDecimal)

          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__Byte)
          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__Decimal)
          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__Double)
          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__Int16)
          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__Int32)
          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__Int64)
          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__SByte)
          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__Single)
          .Add(FB_CMN_ETRS.ETranslators__From_Single.sm_TO__String)
          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__NullableByte)
          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__NullableDecimal)
          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__NullableDouble)
          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__NullableInt16)
          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__NullableInt32)
          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__NullableInt64)
          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__NullableSByte)
          .Add(Common_ETRS.ETranslators__From_Single.sm_TO__NullableSingle)

          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__Byte)
          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__Decimal)
          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__Double)
          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__Int16)
          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__Int32)
          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__Int64)
          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__SByte)
          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__Single)
          .Add(FB_CMN_ETRS.ETranslators__From_Double.sm_TO__String)
          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__NullableByte)
          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__NullableDecimal)
          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__NullableDouble)
          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__NullableInt16)
          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__NullableInt32)
          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__NullableInt64)
          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__NullableSByte)
          .Add(Common_ETRS.ETranslators__From_Double.sm_TO__NullableSingle)

          .Add(Common_ETRS.ETranslators__From_String.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_String.sm_TO__String)
          .Add(Common_ETRS.ETranslators__From_String.sm_TO__NullableInt16)
          .Add(Common_ETRS.ETranslators__From_String.sm_TO__NullableInt32)
          .Add(Common_ETRS.ETranslators__From_String.sm_TO__NullableInt64)
          .Add(Common_ETRS.ETranslators__From_String.sm_TO__NullableDecimal)
          .Add(Common_ETRS.ETranslators__From_String.sm_TO__NullableSingle)
          .Add(Common_ETRS.ETranslators__From_String.sm_TO__NullableDouble)
          .Add(FB_CMN_ETRS.ETranslators__From_String.sm_TO__NullableBoolean)
   /*D3*/ .Add(FB_D3_ETRS .ETranslators__From_String.sm_TO__NullableDateTime)
          .Add(FB_CMN_ETRS.ETranslators__From_String.sm_TO__NullableDateOnly)
          .Add(FB_CMN_ETRS.ETranslators__From_String.sm_TO__NullableTimeOnly)

          .Add(Common_ETRS.ETranslators__From_DateOnly.sm_TO__Object)
          .Add(FB_CMN_ETRS.ETranslators__From_DateOnly.sm_TO__String)
          .Add(Common_ETRS.ETranslators__From_DateOnly.sm_TO__NullableDateOnly)

          .Add(Common_ETRS.ETranslators__From_DateTime.sm_TO__Object)
   /*D3*/ .Add(FB_D3_ETRS .ETranslators__From_DateTime.sm_TO__String)
          .Add(Common_ETRS.ETranslators__From_DateTime.sm_TO__NullableDateTime)

          .Add(Common_ETRS.ETranslators__From_TimeOnly.sm_TO__Object)
          .Add(FB_CMN_ETRS.ETranslators__From_TimeOnly.sm_TO__String)
          .Add(Common_ETRS.ETranslators__From_TimeOnly.sm_TO__NullableTimeOnly)

          .Add(Common_ETRS.ETranslators__From_TimeSpan.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_TimeSpan.sm_TO__NullableTimeSpan)

          .Add(Common_ETRS.ETranslators__From_NullableBoolean.sm_TO__Object)

          .Add(Common_ETRS.ETranslators__From_NullableGuid.sm_TO__Object)

          .Add(Common_ETRS.ETranslators__From_NullableByte.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_NullableByte.sm_TO__NullableByte)
          .Add(Common_ETRS.ETranslators__From_NullableByte.sm_TO__NullableDecimal)
          .Add(Common_ETRS.ETranslators__From_NullableByte.sm_TO__NullableDouble)
          .Add(Common_ETRS.ETranslators__From_NullableByte.sm_TO__NullableInt16)
          .Add(Common_ETRS.ETranslators__From_NullableByte.sm_TO__NullableInt32)
          .Add(Common_ETRS.ETranslators__From_NullableByte.sm_TO__NullableInt64)
          .Add(Common_ETRS.ETranslators__From_NullableByte.sm_TO__NullableSByte)
          .Add(Common_ETRS.ETranslators__From_NullableByte.sm_TO__NullableSingle)

          .Add(Common_ETRS.ETranslators__From_NullableSByte.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_NullableSByte.sm_TO__NullableByte)
          .Add(Common_ETRS.ETranslators__From_NullableSByte.sm_TO__NullableDecimal)
          .Add(Common_ETRS.ETranslators__From_NullableSByte.sm_TO__NullableDouble)
          .Add(Common_ETRS.ETranslators__From_NullableSByte.sm_TO__NullableInt16)
          .Add(Common_ETRS.ETranslators__From_NullableSByte.sm_TO__NullableInt32)
          .Add(Common_ETRS.ETranslators__From_NullableSByte.sm_TO__NullableInt64)
          .Add(Common_ETRS.ETranslators__From_NullableSByte.sm_TO__NullableSByte)
          .Add(Common_ETRS.ETranslators__From_NullableSByte.sm_TO__NullableSingle)

          .Add(Common_ETRS.ETranslators__From_NullableInt16.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_NullableInt16.sm_TO__NullableByte)
          .Add(Common_ETRS.ETranslators__From_NullableInt16.sm_TO__NullableDecimal)
          .Add(Common_ETRS.ETranslators__From_NullableInt16.sm_TO__NullableDouble)
          .Add(Common_ETRS.ETranslators__From_NullableInt16.sm_TO__NullableInt32)
          .Add(Common_ETRS.ETranslators__From_NullableInt16.sm_TO__NullableInt64)
          .Add(Common_ETRS.ETranslators__From_NullableInt16.sm_TO__NullableSByte)
          .Add(Common_ETRS.ETranslators__From_NullableInt16.sm_TO__NullableSingle)

          .Add(Common_ETRS.ETranslators__From_NullableInt32.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_NullableInt32.sm_TO__NullableByte)
          .Add(Common_ETRS.ETranslators__From_NullableInt32.sm_TO__NullableSByte)
          .Add(Common_ETRS.ETranslators__From_NullableInt32.sm_TO__NullableInt16)
          .Add(Common_ETRS.ETranslators__From_NullableInt32.sm_TO__NullableInt64)
          .Add(Common_ETRS.ETranslators__From_NullableInt32.sm_TO__NullableDecimal)
          .Add(Common_ETRS.ETranslators__From_NullableInt32.sm_TO__NullableSingle)
          .Add(Common_ETRS.ETranslators__From_NullableInt32.sm_TO__NullableDouble)

          .Add(Common_ETRS.ETranslators__From_NullableInt64.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_NullableInt64.sm_TO__NullableByte)
          .Add(Common_ETRS.ETranslators__From_NullableInt64.sm_TO__NullableDecimal)
          .Add(Common_ETRS.ETranslators__From_NullableInt64.sm_TO__NullableDouble)
          .Add(Common_ETRS.ETranslators__From_NullableInt64.sm_TO__NullableInt16)
          .Add(Common_ETRS.ETranslators__From_NullableInt64.sm_TO__NullableInt32)
          .Add(Common_ETRS.ETranslators__From_NullableInt64.sm_TO__NullableSByte)
          .Add(Common_ETRS.ETranslators__From_NullableInt64.sm_TO__NullableSingle)

          .Add(Common_ETRS.ETranslators__From_NullableSingle.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_NullableSingle.sm_TO__NullableByte)
          .Add(Common_ETRS.ETranslators__From_NullableSingle.sm_TO__NullableDecimal)
          .Add(Common_ETRS.ETranslators__From_NullableSingle.sm_TO__NullableDouble)
          .Add(Common_ETRS.ETranslators__From_NullableSingle.sm_TO__NullableInt16)
          .Add(Common_ETRS.ETranslators__From_NullableSingle.sm_TO__NullableInt32)
          .Add(Common_ETRS.ETranslators__From_NullableSingle.sm_TO__NullableInt64)
          .Add(Common_ETRS.ETranslators__From_NullableSingle.sm_TO__NullableSByte)

          .Add(Common_ETRS.ETranslators__From_NullableDouble.sm_TO__Object)
          .Add(Common_ETRS.ETranslators__From_NullableDouble.sm_TO__NullableByte)
          .Add(Common_ETRS.ETranslators__From_NullableDouble.sm_TO__NullableDecimal)
          .Add(Common_ETRS.ETranslators__From_NullableDouble.sm_TO__NullableInt16)
          .Add(Common_ETRS.ETranslators__From_NullableDouble.sm_TO__NullableInt32)
          .Add(Common_ETRS.ETranslators__From_NullableDouble.sm_TO__NullableInt64)
          .Add(Common_ETRS.ETranslators__From_NullableDouble.sm_TO__NullableSByte)
          .Add(Common_ETRS.ETranslators__From_NullableDouble.sm_TO__NullableSingle)

          .Add(Common_ETRS.ETranslators__From_NullableDecimal.sm_TO__Object)

          .Add(Common_ETRS.ETranslators__From_NullableDateOnly.sm_TO__Object)

          .Add(Common_ETRS.ETranslators__From_NullableDateTime.sm_TO__Object)

          .Add(Common_ETRS.ETranslators__From_NullableTimeOnly.sm_TO__Object)

          .Add(Common_ETRS.ETranslators__From_NullableTimeSpan.sm_TO__Object)

          .Add(Common_ETRS.ETranslators__From_Object.sm_TO__Array1_Char)
          .Add(Common_ETRS.ETranslators__From_Object.sm_TO__String)
          .Add(Common_ETRS.ETranslators__From_Object.sm_TO__NullableBoolean)
          .Add(Common_ETRS.ETranslators__From_Object.sm_TO__NullableByte)
          .Add(Common_ETRS.ETranslators__From_Object.sm_TO__NullableDateOnly)
          .Add(Common_ETRS.ETranslators__From_Object.sm_TO__NullableDateTime)
          .Add(Common_ETRS.ETranslators__From_Object.sm_TO__NullableDecimal)
          .Add(Common_ETRS.ETranslators__From_Object.sm_TO__NullableDouble)
          .Add(Common_ETRS.ETranslators__From_Object.sm_TO__NullableGuid)
          .Add(Common_ETRS.ETranslators__From_Object.sm_TO__NullableInt16)
          .Add(Common_ETRS.ETranslators__From_Object.sm_TO__NullableInt32)
          .Add(Common_ETRS.ETranslators__From_Object.sm_TO__NullableInt64)
          .Add(Common_ETRS.ETranslators__From_Object.sm_TO__NullableSByte)
          .Add(Common_ETRS.ETranslators__From_Object.sm_TO__NullableSingle)
          .Add(Common_ETRS.ETranslators__From_Object.sm_TO__NullableTimeOnly)
          .Add(Common_ETRS.ETranslators__From_Object.sm_TO__NullableTimeSpan)

  /*END*/
  ;
};//class FB_Data__Expressions_Local__Converts

///////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D3.Expressions
