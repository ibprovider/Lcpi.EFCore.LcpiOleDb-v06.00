////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.05.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3{
////////////////////////////////////////////////////////////////////////////////
//using

using LcpiOleDb__Sql_ETranslator_MethodCall
 =Root.Query.Sql.Expressions.Translators.LcpiOleDb__Sql_ETranslator_MethodCall;

using FB_Common__SqlTranslators
 =Common.Query.Sql.Expressions.Translators;

using FB_V03_0_0__SqlTranslators__D0
 =V03_0_0.Query.Sql.D0.Expressions.Translators;

using FB_V03_0_0__SqlTranslators__D3
 =V03_0_0.Query.Sql.D3.Expressions.Translators;

using Structure_MethodId
 =Structure.Structure_MethodId;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__DataFor_MethodCallTranslatorProvider

sealed partial class FB_V03_0_0__DataFor_MethodCallTranslatorProvider
{
 //private types ---------------------------------------------------------
 private sealed class tagContainer_for_DataByKey
  :Dictionary<Structure_MethodId,LcpiOleDb__Sql_ETranslator_MethodCall>
 {
  public tagContainer_for_DataByKey Add(in FB_Common__SqlTranslators.FB_Common__Sql_ETranslator_MethodCall.tagDescr x)
  {
   Debug.Assert(!Object.ReferenceEquals(x.MethodId,null));
   Debug.Assert(!Object.ReferenceEquals(x.Translator,null));

   Debug.Assert(!base.ContainsKey(x.MethodId));

   base.Add(x.MethodId,x.Translator);

   return this;
  }//Add
 };//class tagContainer_for_DataByKey

 //private data ----------------------------------------------------------
 private static class tagDataByKey
 {
  public static readonly tagContainer_for_DataByKey
   sm_Items
    =new tagContainer_for_DataByKey()

     /*Object methods*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Object__std__Equals__object.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Object__std__ToString.Instance)

     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Object__std__Equals__object_object.Instance)

     /*Int16 methods*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Int16__vrt__HasFlag.Instance)

     /*Int32 methods*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Int32__vrt__HasFlag.Instance)

     /*Int64 methods*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Int64__vrt__HasFlag.Instance)

     /*NullableInt16 methods*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableInt16__std__GetValueOrDefault.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableInt16__vrt__GetValueOrDefault__Int64.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableInt16__vrt__GetValueOrDefault__Double.Instance)

     /*NullableInt32 methods*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableInt32__std__GetValueOrDefault.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableInt32__vrt__GetValueOrDefault__Int64.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableInt32__vrt__GetValueOrDefault__Double.Instance)

     /*NullableInt64 methods*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableInt64__std__GetValueOrDefault.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableInt64__vrt__GetValueOrDefault__Int64.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableInt64__vrt__GetValueOrDefault__Double.Instance)

     /*NullableBoolean methods*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableBoolean__std__GetValueOrDefault__Boolean.Instance)

     /*String methods*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__CompareTo__str.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__Substring__from.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__Substring__from__for.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__Replace__char.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__Replace__str.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__ToLower.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__ToUpper.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__Trim.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__Trim__chars.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__TrimStart.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__TrimStart__chars.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__TrimEnd.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__TrimEnd__chars.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__Contains.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__IsNullOrEmpty.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__IsNullOrWhiteSpace.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__StartsWith__char.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__StartsWith__str.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__EndsWith__char___through_RIGHT.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__EndsWith__str___through_RIGHT.Instance)

     .Add(FB_V03_0_0__SqlTranslators__D3.Code.FB_V03_0_0__Sql_ETranslator__String__std__IndexOf__str.Instance)

     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__Concat__str2.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__Concat__str3.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__Concat__str4.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__Concat__obj1.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__Concat__obj2.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__Concat__obj3.Instance)

     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__ext__Substring__from.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__String__ext__Substring__from__for.Instance)

     /*DateTime methods*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__AddYears.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__AddMonths.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__AddDays.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__AddHours.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__AddMinutes.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__AddSeconds.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__AddMilliseconds.Instance)

     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__ext__ExtractDate_d3.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__ext__ExtractYear.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__ext__ExtractMonth.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__ext__ExtractDay.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__ext__ExtractHour.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__ext__ExtractMinute.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__ext__ExtractSecond.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__ext__ExtractMillisecond.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__ext__ExtractDayOfWeek.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__ext__ExtractDayOfYear.Instance)

     /*DateOnly methods*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateOnly__std__AddYears.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateOnly__std__AddMonths.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateOnly__std__AddDays.Instance)

     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateOnly__ext__ExtractYear.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateOnly__ext__ExtractMonth.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateOnly__ext__ExtractDay.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateOnly__ext__ExtractDayOfWeek.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__DateOnly__ext__ExtractDayOfYear.Instance)

     /*TimeOnly methods*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__TimeOnly__std__AddHours.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__TimeOnly__std__AddMinutes.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__TimeOnly__std__IsBetween.Instance)

     .Add(FB_V03_0_0__SqlTranslators__D3.Code.FB_V03_0_0__Sql_ETranslator__TimeOnly__std__Add___TimeSpan.Instance)

     /*Math*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Truncate__Decimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Truncate__Double.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Round__Decimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Round__Decimal_Int32.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Round__Double.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Round__Double_Int32.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Floor__Decimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Floor__Double.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Ceiling__Decimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Ceiling__Double.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Abs__Int16.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Abs__Int32.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Abs__Int64.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Abs__Decimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Abs__Single.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Abs__Double.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Sign__Int16.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Sign__Int32.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Sign__Int64.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Sign__Decimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Sign__Single.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__Math__std__Sign__Double.Instance)

     /*IEnumerable<Object>*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__IEnumerableObject__vrt__Contains.Instance)

     /*IEnumerable<Byte>*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__IEnumerableByte__vrt__Contains.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__IEnumerableByte__vrt__First.Instance)
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__IEnumerableByte__vrt__SequenceEqual.Instance)

     /*IEnumerable<Int16>*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__IEnumerableInt16__vrt__Contains.Instance)

     /*IEnumerable<Int32>*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__IEnumerableInt32__vrt__Contains.Instance)

     /*IEnumerable<Int64>*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__IEnumerableInt64__vrt__Contains.Instance)

     /*IEnumerable<String>*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__IEnumerableString__vrt__Contains.Instance)

     /*IEnumerable<Guid>*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__IEnumerableGuid__vrt__Contains.Instance)

     /*IEnumerable<DateTime>*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__IEnumerableDateTime__vrt__Contains.Instance)

     /*IEnumerable<NullableInt16>*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__IEnumerableNullableInt16__vrt__Contains.Instance)

     /*IEnumerable<NullableInt32>*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__IEnumerableNullableInt32__vrt__Contains.Instance)

     /*IEnumerable<NullableInt64>*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__IEnumerableNullableInt64__vrt__Contains.Instance)

     /*IEnumerable<NullableGuid>*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__IEnumerableNullableGuid__vrt__Contains.Instance)

     /*IEnumerable<NullableDateTime>*/
     .Add(FB_Common__SqlTranslators.Code.FB_Common__Sql_ETranslator__IEnumerableNullableDateTime__vrt__Contains.Instance)

     /*DbMath*/
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Truncate__Decimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Truncate__Double.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Round__Decimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Round__Decimal_Int32.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Round__Double.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Round__Double_Int32.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Floor__Decimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Floor__Double.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Ceiling__Decimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Ceiling__Double.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Abs__Int16.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Abs__Int32.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Abs__Int64.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Abs__Decimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Abs__Single.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Abs__Double.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Sign__Int16.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Sign__Int32.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Sign__Int64.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Sign__Decimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Sign__Single.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Sign__Double.Instance)

     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Truncate__NullableDecimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Truncate__NullableDouble.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Round__NullableDecimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Round__NullableDecimal_NullableInt32.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Round__NullableDouble.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Round__NullableDouble_NullableInt32.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Floor__NullableDecimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Floor__NullableDouble.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Ceiling__NullableDecimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Ceiling__NullableDouble.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Abs__NullableInt16.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Abs__NullableInt32.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Abs__NullableInt64.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Abs__NullableDecimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Abs__NullableSingle.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Abs__NullableDouble.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Sign__NullableInt16.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Sign__NullableInt32.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Sign__NullableInt64.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Sign__NullableDecimal.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Sign__NullableSingle.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbMath__std__Sign__NullableDouble.Instance)

     /*DbCast methods*/
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbCast__std__AsInteger.Instance)
     .Add(FB_Common__SqlTranslators.Code.LCPI_EFCore.FB_Common__Sql_ETranslator__DbCast__std__AsDouble.Instance)

     .Add(FB_V03_0_0__SqlTranslators__D3.Code.LCPI_EFCore.FB_V03_0_0__Sql_ETranslator__DbCast__std__AsBigInt.Instance)

     /*MS.EFCore DbFunctions*/
     .Add(FB_Common__SqlTranslators.Code.MS_EFCore.FB_Common__Sql_ETranslator__DbFunctions__ext__Like__str2.Instance)
     .Add(FB_Common__SqlTranslators.Code.MS_EFCore.FB_Common__Sql_ETranslator__DbFunctions__ext__Like__str3.Instance)
     .Add(FB_Common__SqlTranslators.Code.MS_EFCore.FB_Common__Sql_ETranslator__DbFunctions__ext__Random.Instance)

     /*QUERABLE Functions*/
     .Add(FB_V03_0_0__SqlTranslators__D0.Code.FB_V03_0_0_D0__Sql_ETranslator__QUERABLE__AVG.Instance)
     .Add(FB_V03_0_0__SqlTranslators__D0.Code.FB_V03_0_0_D0__Sql_ETranslator__QUERABLE__SUM.Instance)

     /*BUILTIN.SQL Functions*/
     .Add(FB_Common__SqlTranslators     .Code.FB_Common__Sql_ETranslator__BUILTIN_SQL__CHARACTER_LENGTH.Instance)
     .Add(FB_Common__SqlTranslators     .Code.FB_Common__Sql_ETranslator__BUILTIN_SQL__OCTET_LENGTH.Instance)
     .Add(FB_Common__SqlTranslators     .Code.FB_Common__Sql_ETranslator__BUILTIN_SQL__POSITION.Instance)
     .Add(FB_V03_0_0__SqlTranslators__D3.Code.FB_V03_0_0_D3__Sql_ETranslator__BUILTIN_SQL__AVG.Instance)
     .Add(FB_V03_0_0__SqlTranslators__D3.Code.FB_V03_0_0_D3__Sql_ETranslator__BUILTIN_SQL__SUM.Instance)

     /*END*/
     ;
 };//class tagDataByKey
};//class FB_V03_0_0__DataFor_MethodCallTranslatorProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3
