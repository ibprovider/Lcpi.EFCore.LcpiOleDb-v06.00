////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.05.2018.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_MethodInfoCache

static class Structure_MethodInfoCache
{
 //Object ----------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Object__std__ToString
  =Structure_TypeCache
   .TypeOf__System_Object
   .Extension__GetRuntimeMethod
     (nameof(Object.ToString),
      Structure_ConstData.Array_SystemType__EMPTY);

 public static readonly MethodInfo MethodInfoOf__Object__std__Equals__object
  =Structure_TypeCache
   .TypeOf__System_Object
   .Extension__GetRuntimeMethod
     (nameof(Object.Equals),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Object
      });

 public static readonly MethodInfo MethodInfoOf__Object__std__Equals__object_object
  =Structure_TypeCache
   .TypeOf__System_Object
   .Extension__GetRuntimeMethod
     (nameof(Object.Equals),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Object,
       Structure_TypeCache.TypeOf__System_Object
      });

 //Int16 -----------------------------------------------------------------

 //Int32 -----------------------------------------------------------------

 //Int64 -----------------------------------------------------------------

 //NullableInt16 ---------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableInt16__std__GetValueOrDefault
  =Structure_TypeCache
   .TypeOf__System_NullableInt16
   .Extension__GetRuntimeMethod
     (nameof(System.Nullable<System.Int16>.GetValueOrDefault),
      Structure_ConstData.Array_SystemType__EMPTY);

 //NullableInt32 ---------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableInt32__std__GetValueOrDefault
  =Structure_TypeCache
   .TypeOf__System_NullableInt32
   .Extension__GetRuntimeMethod
     (nameof(System.Nullable<System.Int32>.GetValueOrDefault),
      Structure_ConstData.Array_SystemType__EMPTY);

 //NullableInt64 ---------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableInt64__std__GetValueOrDefault
  =Structure_TypeCache
   .TypeOf__System_NullableInt64
   .Extension__GetRuntimeMethod
     (nameof(System.Nullable<System.Int64>.GetValueOrDefault),
      Structure_ConstData.Array_SystemType__EMPTY);

 //NullableBoolean -------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableBoolean__std__GetValueOrDefault__Boolean
  =Structure_TypeCache
   .TypeOf__System_NullableBoolean
   .Extension__GetRuntimeMethod
     (nameof(System.Nullable<System.Boolean>.GetValueOrDefault),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Boolean
      });

 //String ----------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__Contains
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.Contains),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_String
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__IndexOf__str
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.IndexOf),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_String
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__Trim
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.Trim),
      Structure_ConstData.Array_SystemType__EMPTY);

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__Trim__chars
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.Trim),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Array_Char
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__TrimEnd
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.TrimEnd),
      Structure_ConstData.Array_SystemType__EMPTY);

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__TrimEnd__chars
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.TrimEnd),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Array_Char
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__TrimStart
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.TrimStart),
      Structure_ConstData.Array_SystemType__EMPTY);

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__TrimStart__chars
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.TrimStart),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Array_Char
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__ToUpper
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.ToUpper),
      Structure_ConstData.Array_SystemType__EMPTY);

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__ToLower
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.ToLower),
      Structure_ConstData.Array_SystemType__EMPTY);

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__IsNullOrEmpty
  =Structure_TypeCache.TypeOf__System_String
    .Extension__GetRuntimeMethod
     (nameof(string.IsNullOrEmpty),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_String
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__IsNullOrWhiteSpace
  =Structure_TypeCache.TypeOf__System_String
    .Extension__GetRuntimeMethod
     (nameof(string.IsNullOrWhiteSpace),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_String
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__Replace__str_str
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.Replace),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_String,
       Structure_TypeCache.TypeOf__System_String
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__Replace__char_char
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.Replace),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Char,
       Structure_TypeCache.TypeOf__System_Char
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__Substring__from
  =Structure_TypeCache
    .TypeOf__System_String
    .Extension__GetRuntimeMethod
      (nameof(string.Substring),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Int32
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__Substring__from_for
  =Structure_TypeCache
    .TypeOf__System_String
    .Extension__GetRuntimeMethod
      (nameof(string.Substring),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Int32,
        Structure_TypeCache.TypeOf__System_Int32
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__StartsWith__char
   =Structure_TypeCache
    .TypeOf__System_String
    .Extension__GetRuntimeMethod
      (nameof(string.StartsWith),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Char
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__StartsWith__str
   =Structure_TypeCache
    .TypeOf__System_String
    .Extension__GetRuntimeMethod
      (nameof(string.StartsWith),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_String
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__EndsWith__char
   =Structure_TypeCache
    .TypeOf__System_String
    .Extension__GetRuntimeMethod
      (nameof(string.EndsWith),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Char,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__EndsWith__str
   =Structure_TypeCache
    .TypeOf__System_String
    .Extension__GetRuntimeMethod
      (nameof(string.EndsWith),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_String,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__Concat__str2
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.Concat),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_String,
       Structure_TypeCache.TypeOf__System_String,
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__Concat__str3
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.Concat),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_String,
       Structure_TypeCache.TypeOf__System_String,
       Structure_TypeCache.TypeOf__System_String,
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__Concat__str4
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.Concat),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_String,
       Structure_TypeCache.TypeOf__System_String,
       Structure_TypeCache.TypeOf__System_String,
       Structure_TypeCache.TypeOf__System_String,
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__Concat__obj1
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.Concat),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Object,
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__Concat__obj2
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.Concat),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Object,
       Structure_TypeCache.TypeOf__System_Object,
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__Concat__obj3
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.Concat),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Object,
       Structure_TypeCache.TypeOf__System_Object,
       Structure_TypeCache.TypeOf__System_Object,
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__std__CompareTo__str
  =Structure_TypeCache
   .TypeOf__System_String
   .Extension__GetRuntimeMethod
     (nameof(string.CompareTo),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_String,
      });

 //DateTime --------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__std__AddYears
   =Structure_TypeCache
    .TypeOf__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(System.DateTime.AddYears),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Int32,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__std__AddMonths
   =Structure_TypeCache
    .TypeOf__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(System.DateTime.AddMonths),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Int32,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__std__AddDays
   =Structure_TypeCache
    .TypeOf__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(System.DateTime.AddDays),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Double,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__std__AddHours
   =Structure_TypeCache
    .TypeOf__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(System.DateTime.AddHours),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Double,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__std__AddMinutes
   =Structure_TypeCache
    .TypeOf__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(System.DateTime.AddMinutes),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Double,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__std__AddSeconds
   =Structure_TypeCache
    .TypeOf__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(System.DateTime.AddSeconds),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Double,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__std__AddMilliseconds
   =Structure_TypeCache
    .TypeOf__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(System.DateTime.AddMilliseconds),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Double,
       });

 //NullableDateTime ------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__std__Equals__object
  =Structure_TypeCache
   .TypeOf__System_NullableDateTime
   .Extension__GetRuntimeMethod
     (nameof(string.Equals),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Object
      });

 //DateOnly --------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateOnly__std__AddYears
   =Structure_TypeCache
    .TypeOf__System_DateOnly
    .Extension__GetRuntimeMethod
      (nameof(System.DateOnly.AddYears),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Int32,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateOnly__std__AddMonths
   =Structure_TypeCache
    .TypeOf__System_DateOnly
    .Extension__GetRuntimeMethod
      (nameof(System.DateOnly.AddMonths),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Int32,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateOnly__std__AddDays
   =Structure_TypeCache
    .TypeOf__System_DateOnly
    .Extension__GetRuntimeMethod
      (nameof(System.DateOnly.AddDays),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Int32,
       });

 //TimeOnly --------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__TimeOnly__std__Add___TimeSpan
   =Structure_TypeCache
    .TypeOf__System_TimeOnly
    .Extension__GetRuntimeMethod
      (nameof(System.TimeOnly.Add),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_TimeSpan,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__TimeOnly__std__AddHours
   =Structure_TypeCache
    .TypeOf__System_TimeOnly
    .Extension__GetRuntimeMethod
      (nameof(System.TimeOnly.AddHours),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Double,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__TimeOnly__std__AddMinutes
   =Structure_TypeCache
    .TypeOf__System_TimeOnly
    .Extension__GetRuntimeMethod
      (nameof(System.TimeOnly.AddMinutes),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Double,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__TimeOnly__std__IsBetween
   =Structure_TypeCache
    .TypeOf__System_TimeOnly
    .Extension__GetRuntimeMethod
      (nameof(System.TimeOnly.IsBetween),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_TimeOnly,
        Structure_TypeCache.TypeOf__System_TimeOnly
       });

 //Math ------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Truncate__Decimal
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Truncate),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Decimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Truncate__Double
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Truncate),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Double
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Round__Decimal
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Round),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Decimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Round__Decimal_Int32
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Round),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Decimal,
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Round__Double
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Round),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Double
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Round__Double_Int32
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Round),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Double,
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Floor__Decimal
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Floor),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Decimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Floor__Double
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Floor),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Double
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Ceiling__Decimal
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Ceiling),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Decimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Ceiling__Double
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Ceiling),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Double
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Abs__SByte
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_SByte
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Abs__Int16
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int16
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Abs__Int32
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Abs__Int64
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int64
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Abs__Decimal
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Decimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Abs__Single
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Single
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Abs__Double
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Double
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Sign__SByte
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_SByte
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Sign__Int16
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int16
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Sign__Int32
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Sign__Int64
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int64
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Sign__Decimal
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Decimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Sign__Single
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Single
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__Math__std__Sign__Double
  =Structure_TypeCache
   .TypeOf__System_Math
   .Extension__GetRuntimeMethod
     (nameof(System.Math.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Double
      });

 //DbMath ------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Truncate__Decimal
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Truncate),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Decimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Truncate__Double
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Truncate),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Double
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Round__Decimal
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Round),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Decimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Round__Decimal_Int32
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Round),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Decimal,
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Round__Double
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Round),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Double
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Round__Double_Int32
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Round),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Double,
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Floor__Decimal
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Floor),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Decimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Floor__Double
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Floor),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Double
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Ceiling__Decimal
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Ceiling),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Decimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Ceiling__Double
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Ceiling),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Double
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Abs__SByte
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_SByte
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Abs__Int16
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int16
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Abs__Int32
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Abs__Int64
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int64
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Abs__Decimal
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Decimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Abs__Single
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Single
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Abs__Double
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Double
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Sign__SByte
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_SByte
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Sign__Int16
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int16
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Sign__Int32
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Sign__Int64
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int64
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Sign__Decimal
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Decimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Sign__Single
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Single
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Sign__Double
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Double
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Truncate__NullableDecimal
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Truncate),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableDecimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Truncate__NullableDouble
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Truncate),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableDouble
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Round__NullableDecimal
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Round),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableDecimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Round__NullableDecimal_NullableInt32
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Round),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableDecimal,
       Structure_TypeCache.TypeOf__System_NullableInt32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Round__NullableDouble
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Round),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableDouble
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Round__NullableDouble_NullableInt32
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Round),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableDouble,
       Structure_TypeCache.TypeOf__System_NullableInt32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Floor__NullableDecimal
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Floor),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableDecimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Floor__NullableDouble
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Floor),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableDouble
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Ceiling__NullableDecimal
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Ceiling),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableDecimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Ceiling__NullableDouble
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Ceiling),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableDouble
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Abs__NullableSByte
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableSByte
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Abs__NullableInt16
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableInt16
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Abs__NullableInt32
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableInt32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Abs__NullableInt64
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableInt64
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Abs__NullableDecimal
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableDecimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Abs__NullableSingle
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableSingle
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Abs__NullableDouble
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Abs),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableDouble
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Sign__NullableSByte
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableSByte
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Sign__NullableInt16
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableInt16
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Sign__NullableInt32
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableInt32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Sign__NullableInt64
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableInt64
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Sign__NullableDecimal
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableDecimal
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Sign__NullableSingle
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableSingle
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbMath__std__Sign__NullableDouble
  =Structure_TypeCache
   .TypeOf__LcpiEF__DbFunction__DbMath
   .Extension__GetRuntimeMethod
     (nameof(DbFunctions.DbMath.Sign),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_NullableDouble
      });

 //DbCast ----------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbCast__std__AsInteger
   =Structure_TypeCache
    .TypeOf__LcpiEF__DbFunction__DbCast
    .Extension__GetRuntimeMethod
      (nameof(DbFunctions.DbCast.AsInteger),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Object,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbCast__std__AsBigInt
   =Structure_TypeCache
    .TypeOf__LcpiEF__DbFunction__DbCast
    .Extension__GetRuntimeMethod
      (nameof(DbFunctions.DbCast.AsBigInt),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Object,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DbCast__std__AsDouble
   =Structure_TypeCache
    .TypeOf__LcpiEF__DbFunction__DbCast
    .Extension__GetRuntimeMethod
      (nameof(DbFunctions.DbCast.AsDouble),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Object,
       });

 //String extensions -----------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__ext__Substring__from
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_String
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_String.Substring),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_String,
        Structure_TypeCache.TypeOf__System_NullableInt64,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__String__ext__Substring__from_for
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_String
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_String.Substring),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_String,
        Structure_TypeCache.TypeOf__System_NullableInt64,
        Structure_TypeCache.TypeOf__System_NullableInt64,
       });

 //DateTime extensions ---------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__AddYears
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.AddYears),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime,
        Structure_TypeCache.TypeOf__System_NullableInt32,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__AddMonths
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.AddMonths),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime,
        Structure_TypeCache.TypeOf__System_NullableInt32,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__AddDays
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.AddDays),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime,
        Structure_TypeCache.TypeOf__System_NullableDouble,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__AddHours
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.AddHours),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime,
        Structure_TypeCache.TypeOf__System_NullableDouble,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__AddMinutes
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.AddMinutes),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime,
        Structure_TypeCache.TypeOf__System_NullableDouble,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__AddSeconds
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.AddSeconds),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime,
        Structure_TypeCache.TypeOf__System_NullableDouble,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__AddMilliseconds
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.AddMilliseconds),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime,
        Structure_TypeCache.TypeOf__System_NullableDouble,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__ExtractDate
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.ExtractDate),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__ExtractYear
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.ExtractYear),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__ExtractMonth
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.ExtractMonth),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__ExtractDay
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.ExtractDay),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__ExtractHour
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.ExtractHour),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__ExtractMinute
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.ExtractMinute),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__ExtractSecond
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.ExtractSecond),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__ExtractMillisecond
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.ExtractMillisecond),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__ExtractDayOfWeek
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.ExtractDayOfWeek),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateTime__ext__ExtractDayOfYear
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateTime.ExtractDayOfYear),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateTime
       });

 //NullableDateTime extensions -------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__AddYears
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.AddYears),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime,
        Structure_TypeCache.TypeOf__System_NullableInt32,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__AddMonths
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.AddMonths),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime,
        Structure_TypeCache.TypeOf__System_NullableInt32,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__AddDays
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.AddDays),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime,
        Structure_TypeCache.TypeOf__System_NullableDouble,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__AddHours
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.AddHours),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime,
        Structure_TypeCache.TypeOf__System_NullableDouble,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__AddMinutes
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.AddMinutes),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime,
        Structure_TypeCache.TypeOf__System_NullableDouble,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__AddSeconds
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.AddSeconds),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime,
        Structure_TypeCache.TypeOf__System_NullableDouble,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__AddMilliseconds
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.AddMilliseconds),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime,
        Structure_TypeCache.TypeOf__System_NullableDouble,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__ExtractDate
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.ExtractDate),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__ExtractYear
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.ExtractYear),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__ExtractMonth
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.ExtractMonth),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__ExtractDay
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.ExtractDay),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__ExtractHour
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.ExtractHour),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__ExtractMinute
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.ExtractMinute),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__ExtractSecond
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.ExtractSecond),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__ExtractMillisecond
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.ExtractMillisecond),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__ExtractDayOfWeek
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.ExtractDayOfWeek),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateTime__ext__ExtractDayOfYear
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateTime
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateTime.ExtractDayOfYear),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateTime
       });

 //DateOnly extensions ---------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateOnly__ext__AddYears
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateOnly.AddYears),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateOnly,
        Structure_TypeCache.TypeOf__System_NullableInt32,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateOnly__ext__AddMonths
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateOnly.AddMonths),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateOnly,
        Structure_TypeCache.TypeOf__System_NullableInt32,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateOnly__ext__AddDays
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateOnly.AddDays),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateOnly,
        Structure_TypeCache.TypeOf__System_NullableInt32,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateOnly__ext__ExtractYear
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateOnly.ExtractYear),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateOnly
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateOnly__ext__ExtractMonth
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateOnly.ExtractMonth),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateOnly
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateOnly__ext__ExtractDay
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateOnly.ExtractDay),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateOnly
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateOnly__ext__ExtractDayOfWeek
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateOnly.ExtractDayOfWeek),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateOnly
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__DateOnly__ext__ExtractDayOfYear
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_DateOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_DateOnly.ExtractDayOfYear),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_DateOnly
       });

 //NullableDateOnly extensions -------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateOnly__ext__AddYears
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateOnly.AddYears),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateOnly,
        Structure_TypeCache.TypeOf__System_NullableInt32,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateOnly__ext__AddMonths
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateOnly.AddMonths),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateOnly,
        Structure_TypeCache.TypeOf__System_NullableInt32,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateOnly__ext__AddDays
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateOnly.AddDays),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateOnly,
        Structure_TypeCache.TypeOf__System_NullableInt32,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateOnly__ext__ExtractYear
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateOnly.ExtractYear),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateOnly
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateOnly__ext__ExtractMonth
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateOnly.ExtractMonth),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateOnly
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateOnly__ext__ExtractDay
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateOnly.ExtractDay),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateOnly
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateOnly__ext__ExtractDayOfWeek
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateOnly.ExtractDayOfWeek),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateOnly
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableDateOnly__ext__ExtractDayOfYear
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableDateOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableDateOnly.ExtractDayOfYear),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableDateOnly
       });

 //TimeOnly extension ----------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__TimeOnly__ext__Add___NullableTimeSpan
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_TimeOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_TimeOnly.Add),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_TimeOnly,
        Structure_TypeCache.TypeOf__System_NullableTimeSpan,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__TimeOnly__ext__AddHours
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_TimeOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_TimeOnly.AddHours),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_TimeOnly,
        Structure_TypeCache.TypeOf__System_NullableDouble,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__TimeOnly__ext__AddMinutes
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_TimeOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_TimeOnly.AddMinutes),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_TimeOnly,
        Structure_TypeCache.TypeOf__System_NullableDouble,
       });

 //NullableTimeOnly extension --------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableTimeOnly__ext__Add___NullableTimeSpan
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableTimeOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableTimeOnly.Add),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableTimeOnly,
        Structure_TypeCache.TypeOf__System_NullableTimeSpan,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableTimeOnly__ext__AddHours
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableTimeOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableTimeOnly.AddHours),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableTimeOnly,
        Structure_TypeCache.TypeOf__System_NullableDouble,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__NullableTimeOnly__ext__AddMinutes
   =Structure_TypeCache
    .TypeOf__LcpiEF__DataType_Extension__System_NullableTimeOnly
    .Extension__GetRuntimeMethod
      (nameof(DataTypes.Extensions.System_NullableTimeOnly.AddMinutes),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_NullableTimeOnly,
        Structure_TypeCache.TypeOf__System_NullableDouble,
       });

 //-----------------------------------------------------------------------
 // private bool TryRewriteEntityEquality
 //   (ExpressionType                         nodeType,
 //    [CanBeNull] Expression                 left,
 //    [CanBeNull] Expression                 right,
 //    bool                                   equalsMethod,
 //    [CA.NotNullWhen(true)] out Expression? result)

 //
 // [2020-11-25] From Russia With Love...
 //

 public static readonly MethodInfo Hack__MethodInfoOf__RelationalSqlTranslatingExpressionVisitor__TryRewriteEntityEquality
  =Structure_TypeCache
    .TypeOf__MS_EFCore_Query__RelationalSqlTranslatingExpressionVisitor
    .Extension__BindToTypeMethod
      ("TryRewriteEntityEquality",
       Structure_TypeCache.TypeOf__System_Boolean,
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__SystemLinqExpressions_ExpressionType,
        Structure_TypeCache.TypeOf__SystemLinqExpressions_Expression,
        Structure_TypeCache.TypeOf__SystemLinqExpressions_Expression,
        Structure_TypeCache.TypeOf__System_Boolean,
        Structure_TypeCache.TypeOf__SystemLinqExpressions_Expression.MakeByRefType()
       },
       BindingFlags.NonPublic|BindingFlags.Instance);

 //-----------------------------------------------------------------------
 //
 // RelationalTypeMappingSource
 //
 // private RelationalTypeMapping? FindMappingWithConversion
 //   (in RelationalTypeMappingInfo mappingInfo,
 //    IReadOnlyList<IProperty>?    principals)
 //

 //
 // [2021-09-24] Again...
 // 

 public static readonly MethodInfo Hack__MethodInfoOf__RelationalTypeMappingSource__FindMappingWithConversion
  =Structure_TypeCache
   .TypeOf__MS_EFCore_Storage__RelationalTypeMappingSource
   .Extension__BindToTypeMethod
    ("FindMappingWithConversion",
     Structure_TypeCache.TypeOf__MS_EFCore_Storage__RelationalTypeMapping,
     new System.Type[]
     {
      typeof(Microsoft.EntityFrameworkCore.Storage.RelationalTypeMappingInfo).MakeByRefType(),
      typeof(System.Collections.Generic.IReadOnlyList<Microsoft.EntityFrameworkCore.Metadata.IProperty>)
     },
     BindingFlags.NonPublic|BindingFlags.Instance);

 //-----------------------------------------------------------------------

 //
 // RelationalSqlTranslatingExpressionVisitor.EntityReferenceExpression
 //
 // public Expression Convert(Type type)
 //

 public static readonly MethodInfo Hack__MethodInfoOf__RelationalSqlTranslatingExpressionVisitor_EntityReferenceExpression__Convert
  =Structure_TypeCache
    .TypeOf__MS_EFCore_Query__RelationalSqlTranslatingExpressionVisitor___EntityReferenceExpression
    .Extension__BindToTypeMethod
      ("Convert",
       Structure_TypeCache.TypeOf__SystemLinqExpressions_Expression,
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__System_Type
       },
       BindingFlags.Public|BindingFlags.Instance);

 //MS.EFCore DbFunctions -------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__MS_EFCore__DbFunctions__ext__Like__match_pattern
   =Structure_TypeCache
    .TypeOf__MS_EFCore__DbFunctionsExtensions
    .Extension__GetRuntimeMethod
      (nameof(Microsoft.EntityFrameworkCore.DbFunctionsExtensions.Like),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__MS_EFCore__DbFunctions,
        Structure_TypeCache.TypeOf__System_String,
        Structure_TypeCache.TypeOf__System_String
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__MS_EFCore__DbFunctions__ext__Like__match_pattern_escape
   =Structure_TypeCache
    .TypeOf__MS_EFCore__DbFunctionsExtensions
    .Extension__GetRuntimeMethod
      (nameof(Microsoft.EntityFrameworkCore.DbFunctionsExtensions.Like),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__MS_EFCore__DbFunctions,
        Structure_TypeCache.TypeOf__System_String,
        Structure_TypeCache.TypeOf__System_String,
        Structure_TypeCache.TypeOf__System_String,
       });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__MS_EFCore__DbFunctions__ext__Random
   =Structure_TypeCache
    .TypeOf__MS_EFCore__DbFunctionsExtensions
    .Extension__GetRuntimeMethod
      (nameof(Microsoft.EntityFrameworkCore.DbFunctionsExtensions.Random),
       new System.Type[]
       {
        Structure_TypeCache.TypeOf__MS_EFCore__DbFunctions,
       });

 //System.Data.Common.DbDataReader ---------------------------------------
 public static readonly MethodInfo MethodInfoOf__SystemDataCommon__DbDataReader__GetDateTime
  =Structure_TypeCache
   .TypeOf__SystemDataCommon__DbDataReader
   .GetRuntimeMethod
     (nameof(System.Data.Common.DbDataReader.GetDateTime),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__SystemDataCommon__DbDataReader__GetChar
  =Structure_TypeCache
   .TypeOf__SystemDataCommon__DbDataReader
   .GetRuntimeMethod
     (nameof(System.Data.Common.DbDataReader.GetChar),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__SystemDataCommon__DbDataReader__GetString
  =Structure_TypeCache
   .TypeOf__SystemDataCommon__DbDataReader
   .GetRuntimeMethod
     (nameof(System.Data.Common.DbDataReader.GetString),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__SystemDataCommon__DbDataReader__GetBoolean
  =Structure_TypeCache
   .TypeOf__SystemDataCommon__DbDataReader
   .GetRuntimeMethod
     (nameof(System.Data.Common.DbDataReader.GetBoolean),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__SystemDataCommon__DbDataReader__GetGuid
  =Structure_TypeCache
   .TypeOf__SystemDataCommon__DbDataReader
   .GetRuntimeMethod
     (nameof(System.Data.Common.DbDataReader.GetGuid),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__SystemDataCommon__DbDataReader__GetInt16
  =Structure_TypeCache
   .TypeOf__SystemDataCommon__DbDataReader
   .GetRuntimeMethod
     (nameof(System.Data.Common.DbDataReader.GetInt16),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__SystemDataCommon__DbDataReader__GetInt32
  =Structure_TypeCache
   .TypeOf__SystemDataCommon__DbDataReader
   .GetRuntimeMethod
     (nameof(System.Data.Common.DbDataReader.GetInt32),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__SystemDataCommon__DbDataReader__GetInt64
  =Structure_TypeCache
   .TypeOf__SystemDataCommon__DbDataReader
   .GetRuntimeMethod
     (nameof(System.Data.Common.DbDataReader.GetInt64),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__SystemDataCommon__DbDataReader__GetDecimal
  =Structure_TypeCache
   .TypeOf__SystemDataCommon__DbDataReader
   .GetRuntimeMethod
     (nameof(System.Data.Common.DbDataReader.GetDecimal),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__SystemDataCommon__DbDataReader__GetFloat
  =Structure_TypeCache
   .TypeOf__SystemDataCommon__DbDataReader
   .GetRuntimeMethod
     (nameof(System.Data.Common.DbDataReader.GetFloat),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__SystemDataCommon__DbDataReader__GetDouble
  =Structure_TypeCache
   .TypeOf__SystemDataCommon__DbDataReader
   .GetRuntimeMethod
     (nameof(System.Data.Common.DbDataReader.GetDouble),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //lcpi.data.oledb.OleDbDataReader ---------------------------------------
 public static readonly MethodInfo MethodInfoOf__LcpiDataOleDb__OleDbDataReader__GetDateOnly
  =Structure_TypeCache
   .TypeOf__LcpiDataOleDb__OleDbDataReader
   .GetRuntimeMethod
     (nameof(lcpi.data.oledb.OleDbDataReader.GetDateOnly),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__LcpiDataOleDb__OleDbDataReader__GetTimeOnly
  =Structure_TypeCache
   .TypeOf__LcpiDataOleDb__OleDbDataReader
   .GetRuntimeMethod
     (nameof(lcpi.data.oledb.OleDbDataReader.GetTimeOnly),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__LcpiDataOleDb__OleDbDataReader__GetTimeSpan
  =Structure_TypeCache
   .TypeOf__LcpiDataOleDb__OleDbDataReader
   .GetRuntimeMethod
     (nameof(lcpi.data.oledb.OleDbDataReader.GetTimeSpan),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__LcpiDataOleDb__OleDbDataReader__GetChars
  =Structure_TypeCache
   .TypeOf__LcpiDataOleDb__OleDbDataReader
   .GetRuntimeMethod
     (nameof(lcpi.data.oledb.OleDbDataReader.GetChars),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });

 //-----------------------------------------------------------------------
 public static readonly MethodInfo MethodInfoOf__LcpiDataOleDb__OleDbDataReader__GetBytes
  =Structure_TypeCache
   .TypeOf__LcpiDataOleDb__OleDbDataReader
   .GetRuntimeMethod
     (nameof(lcpi.data.oledb.OleDbDataReader.GetBytes),
      new System.Type[]
      {
       Structure_TypeCache.TypeOf__System_Int32
      });
};//class Structure_MethodInfoCache

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
