////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 03.09.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MethodParameterDescr
 =Structure.Structure_MethodParameterDescr;

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using T_TEST_RESULT
 =Structure.Structure_TestConversionResult;

////////////////////////////////////////////////////////////////////////////////
//class Core_TestSafeConversion

static class Core_TestSafeConversion
{
 public static T_TEST_RESULT Exec
                              (System.Type sourceValueType,
                               System.Type targetType)
 {
  Debug.Assert(!Object.ReferenceEquals(sourceValueType,null));
  Debug.Assert(!Object.ReferenceEquals(targetType,null));

  //-------------------------------------------------------
  bool sourceValueType_isNullable
   =sourceValueType.Extension__IsNullableValueType();

  bool targetType_isNullable
   =targetType.Extension__IsNullableValueType();

  //-------------------------------------------------------
  if(sourceValueType_isNullable)
  {
   if(targetType_isNullable)
   {
    // OK.
   }
   else
   if(targetType==Structure_TypeCache.TypeOf__System_Object)
   {
    //
    // [2021-12-08]
    //
    //  OK. Any type can be converted into System.Object.
    //
   }
   else
   {
    return T_TEST_RESULT.Create_NO();
   }//else
  }//if

  //-------------------------------------------------------
  var sourceValueType_u
   =sourceValueType.Extension__UnwrapNullableType();

  Debug.Assert(!Object.ReferenceEquals(sourceValueType_u,null));

  // [2021-09-03] Expected
  Debug.Assert(sourceValueType_u==sourceValueType_u.Extension__UnwrapMappingClrType());

  //-------------------------------------------------------
  var targetType_u
   =targetType.Extension__UnwrapNullableType();

  Debug.Assert(!Object.ReferenceEquals(targetType_u,null));

  // [2021-09-03] Expected
  Debug.Assert(targetType_u==targetType_u.Extension__UnwrapMappingClrType());

  //-------------------------------------------------------
  if(sourceValueType_u==targetType_u)
  {
   if(sourceValueType_isNullable==targetType_isNullable)
    return T_TEST_RESULT.Create_OK(0);

   return T_TEST_RESULT.Create_OK(c_Weight___to_nullable);
  }//if

  Debug.Assert(sourceValueType_u!=targetType_u);

  //-------------------------------------------------------
  if(targetType_u==Structure_TypeCache.TypeOf__System_Object)
   return T_TEST_RESULT.Create_OK(c_Weight___ANY_to_OBJECT);

  //-------------------------------------------------------
  if(targetType_u.IsInterface)
  {
   if(targetType_u.IsAssignableFrom(sourceValueType_u))
    return T_TEST_RESULT.Create_OK(c_Weight___cvt_to_interface);

   return T_TEST_RESULT.Create_NO();
  }//if

  //-------------------------------------------------------
  foreach(var rule in sm_RULES)
  {
   Debug.Assert(!Object.ReferenceEquals(rule.FromType,null));
   Debug.Assert(!Object.ReferenceEquals(rule.ToType,null));
   Debug.Assert(rule.Weight>0);

   if(rule.FromType!=sourceValueType_u)
    continue;

   if(rule.ToType!=targetType_u)
    continue;

   return T_TEST_RESULT.Create_OK(rule.Weight);
  }//foreach rule

  return T_TEST_RESULT.Create_NO();
 }//Exec

 //private types ---------------------------------------------------------
 private const int c_Weight___to_nullable       =1;
 private const int c_Weight___base              =10;

 private const int c_Weight___cvt_to_interface  =int.MaxValue;
 private const int c_Weight___ANY_to_OBJECT     =int.MaxValue;
 private const int c_Weight___ANY_TO_DECIMAL    =1000;

 //-----------------------------------------------------------------------
 private struct tagRule
 {
  public readonly System.Type  FromType;
  public readonly System.Type  ToType;
  public readonly int          Weight;

  public tagRule(System.Type fromType,System.Type toType,int weight)
  {
   Debug.Assert(!Object.ReferenceEquals(fromType,null));
   Debug.Assert(!Object.ReferenceEquals(toType,null));
   Debug.Assert(weight>0);

   this.FromType   =fromType;
   this.ToType     =toType;
   this.Weight     =weight;
  }//tagRule
 };//struct tagRule

 //private data ----------------------------------------------------------
 private static readonly tagRule[]
  sm_RULES
   =new tagRule[]
     {
      new tagRule(Structure_TypeCache.TypeOf__System_Byte    , Structure_TypeCache.TypeOf__System_Int16    , c_Weight___base+0),
      new tagRule(Structure_TypeCache.TypeOf__System_Byte    , Structure_TypeCache.TypeOf__System_Int32    , c_Weight___base+1),
      new tagRule(Structure_TypeCache.TypeOf__System_Byte    , Structure_TypeCache.TypeOf__System_Int64    , c_Weight___base+2),
      new tagRule(Structure_TypeCache.TypeOf__System_Byte    , Structure_TypeCache.TypeOf__System_Decimal  , c_Weight___ANY_TO_DECIMAL),

      new tagRule(Structure_TypeCache.TypeOf__System_SByte   , Structure_TypeCache.TypeOf__System_Int16    , c_Weight___base+0),
      new tagRule(Structure_TypeCache.TypeOf__System_SByte   , Structure_TypeCache.TypeOf__System_Int32    , c_Weight___base+1),
      new tagRule(Structure_TypeCache.TypeOf__System_SByte   , Structure_TypeCache.TypeOf__System_Int64    , c_Weight___base+2),
      new tagRule(Structure_TypeCache.TypeOf__System_SByte   , Structure_TypeCache.TypeOf__System_Decimal  , c_Weight___ANY_TO_DECIMAL),

      new tagRule(Structure_TypeCache.TypeOf__System_Int16   , Structure_TypeCache.TypeOf__System_Int32    , c_Weight___base+0),
      new tagRule(Structure_TypeCache.TypeOf__System_Int16   , Structure_TypeCache.TypeOf__System_Int64    , c_Weight___base+1),
      new tagRule(Structure_TypeCache.TypeOf__System_Int16   , Structure_TypeCache.TypeOf__System_Decimal  , c_Weight___ANY_TO_DECIMAL),

      new tagRule(Structure_TypeCache.TypeOf__System_Int32   , Structure_TypeCache.TypeOf__System_Int64    , c_Weight___base+0),
      new tagRule(Structure_TypeCache.TypeOf__System_Int32   , Structure_TypeCache.TypeOf__System_Decimal  , c_Weight___ANY_TO_DECIMAL),

      new tagRule(Structure_TypeCache.TypeOf__System_Int64   , Structure_TypeCache.TypeOf__System_Decimal  , c_Weight___ANY_TO_DECIMAL),

      new tagRule(Structure_TypeCache.TypeOf__System_Single  , Structure_TypeCache.TypeOf__System_Double   , c_Weight___base+0),
     };//sm_RULES
};//class Core_TestSafeConversion

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core
