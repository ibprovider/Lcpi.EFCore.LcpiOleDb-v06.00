////////////////////////////////////////////////////////////////////////////////
//EF.Core Provider for LCPI OLE DB and Firebird.
//                                      IBProvider and Contributors. 29.09.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.ValueConversion{
////////////////////////////////////////////////////////////////////////////////

using T_MODEL_DATA
 =System.TimeSpan;

using T_PROVIDER_DATA
 =System.Decimal;

 using ISC
  =Core.Engines.Dbms.IscBase.IscBase_Const;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__ValueConversion__TimeSpanToDecimal18_4

sealed class FB_Common__ValueConversion__TimeSpanToDecimal18_4
 :ValueConverter<T_MODEL_DATA,T_PROVIDER_DATA>
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__ValueConversion__TimeSpanToDecimal18_4;

 //-----------------------------------------------------------------------
 public static readonly FB_Common__ValueConversion__TimeSpanToDecimal18_4
  Instance
   =new FB_Common__ValueConversion__TimeSpanToDecimal18_4();

 //-----------------------------------------------------------------------
 private const string
  c_DATABASE_STORE_TYPE
   ="NUMERIC(18,4)";

 //-----------------------------------------------------------------------
 //
 // Valid range of stored (database) values.
 //
 // These values will be multiplied to 10000 and to 1000.
 // 

 private const decimal
  c_MinDbValue
   //12345678901 2345  +678
   =-99999999999.9999m;

 private const decimal
  c_MaxDbValue
   //12345678901 2345  +678
   =+99999999999.9999m;

 //-----------------------------------------------------------------------
 private FB_Common__ValueConversion__TimeSpanToDecimal18_4()
  :this(null)
 {
 }//FB_Common__ValueConversion__TimeSpanToDecimal18_4

 //-----------------------------------------------------------------------
 private FB_Common__ValueConversion__TimeSpanToDecimal18_4(ConverterMappingHints mappingHints)
  :base(/*ToProvider*/   v => Helper__ToProvider(v),
        /*FromProvider*/ v => Helper__FromProvider(v),
        mappingHints)
 {
 }//FB_Common__ValueConversion__TimeSpanToDecimal18_4 - mappingHints

 //-----------------------------------------------------------------------
 public static ValueConverterInfo DefaultInfo
 {
  get
  {
   return new ValueConverterInfo
           (typeof(T_MODEL_DATA),
            typeof(T_PROVIDER_DATA),
            i => new FB_Common__ValueConversion__TimeSpanToDecimal18_4(i.MappingHints));
  }//get
 }//DefaultInfo

 //-----------------------------------------------------------------------
 private static T_MODEL_DATA Helper__FromProvider(T_PROVIDER_DATA providerData)
 {
  if(providerData<c_MinDbValue || c_MaxDbValue<providerData)
  {
   //ERROR - can't convert provider data to TimeSpan value. Overflow.

   ThrowError.TypeMappingErr__CantConvertDatabaseValueToTimeSpan__OutOfRange
    (c_ErrSrcID,
     providerData,
     c_DATABASE_STORE_TYPE,
     c_MinDbValue,
     c_MaxDbValue);
  }//if

  decimal srcValue
   =providerData*ISC.c_TIME_FRACTION_PRECISION;

  decimal srcValue2
   =Math.Truncate(srcValue);

  decimal srcValue3
   =srcValue2*ISC.c_TICKS_IN_TIME_FRACTION;

  T_MODEL_DATA result
   =new T_MODEL_DATA((long)(srcValue3));

  return result;
 }//Helper__FromProvider

 //-----------------------------------------------------------------------
 private static T_PROVIDER_DATA Helper__ToProvider(T_MODEL_DATA modelData)
 {
  long ticks
   =modelData.Ticks;

  long ticks2
   =ticks/ISC.c_TICKS_IN_TIME_FRACTION;

  T_PROVIDER_DATA result
   =Structure.Structure_ADP.ConstructDecimalFromLongValue
     (ticks2,
      ISC.c_TIME_FRACTION_SCALE);

  return result;
 }//Helper__ToProvider
};//class FB_Common__ValueConversion__TimeSpanToDecimal18_4

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.ValueConversion
