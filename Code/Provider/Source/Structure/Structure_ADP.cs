////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.05.2018.

//------------------------------------------------------------------------
#if   BUILD_CONF__NET5_0_0
// CER is deprecated
//# define LOCAL_BUILD_CONF__Use_CER
#elif BUILD_CONF__NET6_0_0
// CER is deprecated
//# define LOCAL_BUILD_CONF__Use_CER
#else
# error "Unexpected Target Platform!"
#endif

//------------------------------------------------------------------------
using System;
using System.Diagnostics;
using System.Data;
using System.Data.Common;

#if LOCAL_BUILD_CONF__Use_CER
using System.Runtime.CompilerServices;
#endif

using com_lib=lcpi.lib.com;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_ADP

static class Structure_ADP
{
 public static bool TestConnectionState__IsOpen(ErrSourceID  errSrcID,
                                                DbConnection cn)
 {
  //! \todo NOT TESTED!

  Debug.Assert(!Object.ReferenceEquals(cn,null));

  ConnectionState cnState=cn.State;

  switch(cnState)
  {
   case ConnectionState.Open:
    return true;

   case ConnectionState.Closed:
   case ConnectionState.Broken:
    return false;
  }//switch cnState

  var errRec
   =new Core.Core_ExceptionRecord
     (lcpi.lib.com.HResultCode.E_FAIL,
      errSrcID,
      ErrMessageID.common_err__unexpected_connection_state_1);

  errRec.push(cnState);

  ThrowSysError.invalid_operation(errRec);

  Debug.Assert(false);

  return false;
 }//TestConnectionState__IsOpen

 //-----------------------------------------------------------------------
 public static void OpenConnectionIfClosed(ErrSourceID  errSrcID,
                                           DbConnection cn,
                                           ref bool     flag)
 {
   //! \todo NOT TESTED!

  Debug.Assert(!Object.ReferenceEquals(cn,null));
  Debug.Assert(!flag);

  if(TestConnectionState__IsOpen(errSrcID,cn))
   return;

#if LOCAL_BUILD_CONF__Use_CER
  RuntimeHelpers.PrepareConstrainedRegions();            //--------------- CER
#endif

  try
  {
  }
  finally
  {
   cn.Open(); //throw

   flag=true;
  }//finally                                             //---------------/CER
 }//OpenConnectionIfClosed

 //-----------------------------------------------------------------------
 public static bool IsValidSymbolOfUnquotedObjectName_1(char ch)
 {
  // [2020-10-14] Tested

  if(ch>='A' && ch<='Z')
   return true;

  if(ch>='a' && ch<='z')
   return true;

  //
  // [2020-10-17] Surprise. Server does not support these symbols in begin of name.
  //
  // if(ch=='$')
  //  return true;
  // 
  // if(ch=='_')
  //  return true;

  return false;
 }//IsValidSymbolOfUnquotedObjectName_1

 //-----------------------------------------------------------------------
 public static bool IsValidSymbolOfUnquotedObjectName_2(char ch)
 {
  // [2020-10-14] Tested

  if(ch>='0' && ch<='9')
   return true;

  if(ch=='$')
   return true;

  if(ch=='_')
   return true;

  return IsValidSymbolOfUnquotedObjectName_1(ch);
 }//IsValidSymbolOfUnquotedObjectName_2

 //-----------------------------------------------------------------------
 public static bool IsValidSymbolOfQuotedObjectName(char ch)
 {
  // [2020-10-14] Tested

  if(ch=='\0')
   return false;

  return true;
 }//IsValidSymbolOfUnquotedObjectName_1

 //-----------------------------------------------------------------------
 private static readonly char[]
  sm_HEX={'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'};

 public static char FourBitsToHEX(byte fourBits)
 {
  // [2020-10-14] Tested

  Debug.Assert(fourBits<16);

  return sm_HEX[fourBits];
 }//FourBitsToHEX

 //-----------------------------------------------------------------------
 public static bool StrHasFloatValueAttrs(float v,string s)
 {
  // [2020-11-18] Tested.

  Debug.Assert(!string.IsNullOrEmpty(s));

  if(s.Contains("E"))
   return true;

  if(s.Contains("e"))
   return true;

  if(s.Contains("."))
   return true;

  if(float.IsNaN(v))
   return true;

  if(float.IsInfinity(v))
   return true;

  return false;
 }//StrHasFloatValueAttrs

 //-----------------------------------------------------------------------
 public static bool StrHasDoubleValueAttrs(double v,string s)
 {
  // [2020-11-18] Tested.

  Debug.Assert(!string.IsNullOrEmpty(s));

  if(s.Contains("E"))
   return true;

  if(s.Contains("e"))
   return true;

  if(s.Contains("."))
   return true;

  if(double.IsNaN(v))
   return true;

  if(double.IsInfinity(v))
   return true;

  return false;
 }//StrHasDoubleValueAttrs

 //-----------------------------------------------------------------------
 public static bool EqualDbmsName(string name1,
                                  string name2)
 {
  // [2020-10-14] Tested

  Debug.Assert(!Object.ReferenceEquals(name1,null));
  Debug.Assert(!Object.ReferenceEquals(name2,null));

  return StringComparer.OrdinalIgnoreCase.Compare(name1,name2)==0;
 }//EqualDbmsName

 //-----------------------------------------------------------------------
 public static bool EqualDatabaseTypeName(string name1,
                                          string name2)
 {
  // [2020-10-14] Tested

  Debug.Assert(!Object.ReferenceEquals(name1,null));
  Debug.Assert(!Object.ReferenceEquals(name2,null));

  return StringComparer.OrdinalIgnoreCase.Compare(name1,name2)==0;
 }//EqualDatabaseTypeName

 //-----------------------------------------------------------------------
 public static int IndexOf(ErrSourceID           SrcID,
                           System.Data.DataTable Table,
                           string                ColumnName)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(Table,null));
  Debug.Assert(!Object.ReferenceEquals(Table.Columns,null));

  int resultValue=Table.Columns.IndexOf(ColumnName);

  if(resultValue<0)
  {
   //ERROR - BUG CHECK. Column Not Found!

   ThrowError.UnkColumnName
    (SrcID,
     Table,
     ColumnName);
  }//if

  Debug.Assert(resultValue>=0);
  Debug.Assert(resultValue<Table.Columns.Count);

  return resultValue;
 }//IndexOf

 //-----------------------------------------------------------------------
 /// <summary>
 ///  Read string column value, Generate exception for NULL or null values
 ///  and wrong column type.
 /// </summary>
 //! \param[in] SrcID
 //!  ID of caller. Used in exceptions.
 //! \param[in] Row
 //!  Not null.
 //! \param[in] ColumnIndex
 //!  Valid column index
 //! \return
 //!  Column's value.
 public static string GetString2_NN(ErrSourceID         SrcID,
                                    System.Data.DataRow Row,
                                    int                 ColumnIndex)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(Row,null));
  Debug.Assert(!Object.ReferenceEquals(Row.Table,null));
  Debug.Assert(!Object.ReferenceEquals(Row.Table.Columns,null));
  Debug.Assert(ColumnIndex>=0);
  Debug.Assert(ColumnIndex<Row.Table.Columns.Count);

  object ColumnValue=Row[ColumnIndex];

  if(Object.ReferenceEquals(ColumnValue,null))
  {
   //ERROR - column contains a null value

   ThrowError.InvalidColumnValue
    (SrcID,
     Row,
     ColumnIndex);
  }//if

  if(DBNull.Value.Equals(ColumnValue))
  {
   //ERROR - column contains a NULL value

   ThrowError.InvalidColumnValue
    (SrcID,
     Row,
     ColumnIndex);
  }//if

  var strColumnValue=ColumnValue as string;

  if(Object.ReferenceEquals(strColumnValue,null))
  {
   //ERROR - incorrect column value type

   ThrowError.InvalidColumnValueType
    (SrcID,
     Row,
     ColumnIndex,
     Structure_TypeCache.TypeOf__System_String);
  }//if

  return strColumnValue;
 }//GetString2_NN

 //-----------------------------------------------------------------------
 public static Structure_ValueWithNull<string>
  GetString2_AsValueWithNull(ErrSourceID         SrcID,
                             System.Data.DataRow Row,
                             int                 ColumnIndex)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(Row,null));
  Debug.Assert(!Object.ReferenceEquals(Row.Table,null));
  Debug.Assert(!Object.ReferenceEquals(Row.Table.Columns,null));
  Debug.Assert(ColumnIndex>=0);
  Debug.Assert(ColumnIndex<Row.Table.Columns.Count);

  object ColumnValue=Row[ColumnIndex];

  if(Object.ReferenceEquals(ColumnValue,null))   //<------------- !!!!
  {
   //ERROR - column contains a null value

   ThrowError.InvalidColumnValue
    (SrcID,
     Row,
     ColumnIndex);
  }//if

  if(DBNull.Value.Equals(ColumnValue))
  {
   //column contains a NULL value

   return new Structure_ValueWithNull<string>();
  }//if

  var strColumnValue=ColumnValue as string;

  if(Object.ReferenceEquals(strColumnValue,null))
  {
   //ERROR - incorrect column value type

   ThrowError.InvalidColumnValueType
    (SrcID,
     Row,
     ColumnIndex,
     Structure_TypeCache.TypeOf__System_String);
  }//if

  return new Structure_ValueWithNull<string>(strColumnValue);
 }//GetString2_AsValueWithNull

//-----------------------------------------------------------------------
 public static string GetString_Safe(ErrSourceID         SrcID,
                                     System.Data.DataRow Row,
                                     int                 ColumnIndex)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(Row,null));
  Debug.Assert(!Object.ReferenceEquals(Row.Table,null));
  Debug.Assert(!Object.ReferenceEquals(Row.Table.Columns,null));
  Debug.Assert(ColumnIndex>=0);
  Debug.Assert(ColumnIndex<Row.Table.Columns.Count);

  object ColumnValue=Row[ColumnIndex];

  if(Object.ReferenceEquals(ColumnValue,null))
   return null;

  if(DBNull.Value.Equals(ColumnValue))
   return null;

  var strColumnValue=ColumnValue as string;

  if(Object.ReferenceEquals(strColumnValue,null))
  {
   //ERROR - incorrect column value type

   ThrowError.InvalidColumnValueType
    (SrcID,
     Row,
     ColumnIndex,
     Structure_TypeCache.TypeOf__System_String);
  }//if

  return strColumnValue;
 }//GetString_Safe

 //-----------------------------------------------------------------------
 public static bool GetBoolean_NN(ErrSourceID         SrcID,
                                  System.Data.DataRow Row,
                                  int                 ColumnIndex)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(Row,null));
  Debug.Assert(!Object.ReferenceEquals(Row.Table,null));
  Debug.Assert(!Object.ReferenceEquals(Row.Table.Columns,null));
  Debug.Assert(ColumnIndex>=0);
  Debug.Assert(ColumnIndex<Row.Table.Columns.Count);

  object ColumnValue=Row[ColumnIndex];

  if(Object.ReferenceEquals(ColumnValue,null))
  {
   //ERROR - column contains a null value

   ThrowError.InvalidColumnValue
    (SrcID,
     Row,
     ColumnIndex);
  }//if

  if(DBNull.Value.Equals(ColumnValue))
  {
   //ERROR - column contains a NULL value

   ThrowError.InvalidColumnValue
    (SrcID,
     Row,
     ColumnIndex);
  }//if

  if(!ColumnValue.GetType().Equals(Structure_TypeCache.TypeOf__System_Boolean))
  {
   //ERROR - incorrect column value type

   ThrowError.InvalidColumnValueType
    (SrcID,
     Row,
     ColumnIndex,
     Structure_TypeCache.TypeOf__System_Boolean);
  }//if

  return (System.Boolean)ColumnValue;
 }//GetBoolean_NN

 //-----------------------------------------------------------------------
 public static System.Int32 GetInt32_NN(ErrSourceID         SrcID,
                                        System.Data.DataRow Row,
                                        int                 ColumnIndex)
 {
  // [2020-10-14] Tested.

  Debug.Assert(!Object.ReferenceEquals(Row,null));
  Debug.Assert(!Object.ReferenceEquals(Row.Table,null));
  Debug.Assert(!Object.ReferenceEquals(Row.Table.Columns,null));
  Debug.Assert(ColumnIndex>=0);
  Debug.Assert(ColumnIndex<Row.Table.Columns.Count);

  object ColumnValue=Row[ColumnIndex];

  if(Object.ReferenceEquals(ColumnValue,null))
  {
   //ERROR - column contains a null value

   ThrowError.InvalidColumnValue
    (SrcID,
     Row,
     ColumnIndex);
  }//if

  if(DBNull.Value.Equals(ColumnValue))
  {
   //ERROR - column contains a NULL value

   ThrowError.InvalidColumnValue
    (SrcID,
     Row,
     ColumnIndex);
  }//if

  if(!ColumnValue.GetType().Equals(Structure_TypeCache.TypeOf__System_Int32))
  {
   //ERROR - incorrect column value type

   ThrowError.InvalidColumnValueType
    (SrcID,
     Row,
     ColumnIndex,
     Structure_TypeCache.TypeOf__System_Int32);
  }//if

  return (System.Int32)ColumnValue;
 }//GetInt32_NN

 //-----------------------------------------------------------------------
 public static T Exchange<T>(ref T location,T newValue)
 {
  // [2020-12-10] Tested.

  T prevValue=location;

  location=newValue;

  return prevValue;
 }//Exchange

 //-----------------------------------------------------------------------
#if DEBUG
 public static bool DEBUG__TimeOnlyContainsValidSqlTime
                             (in System.TimeOnly timeOnly)
 {
  if(timeOnly.Ticks<0)
   return false;

  if(Core.Core_Consts.TimeSpan___TicksInDay<=timeOnly.Ticks)
   return false;

  return true;
 }//DEBUG__TimeOnlyContainsValidSqlTime
#endif

 //-----------------------------------------------------------------------
 public static string BuildParamsSign(System.Type[] parameters)
 {
  if(Object.ReferenceEquals(parameters,null))
  {
   return "<NONE>";
  }//if

  if(parameters.Length==0)
  {
   return "<EMPTY LIST>";
  }//if

  var sb=new System.Text.StringBuilder();

  var s=string.Empty;

  foreach(var p in parameters)
  {
   sb.Append(s);

   Debug.Assert(!Object.ReferenceEquals(p,null));

   sb.Append(p.Extension__BuildHumanName());

   s=", ";
  }//foreach p

  return sb.ToString();
 }//Helper__BindToTypeMethod__BuildParamsSign

 //-----------------------------------------------------------------------
 public static System.Decimal ConstructDecimalFromLongValue(long longValue,byte scale)
 {
  Debug.Assert(scale<=28);

  bool isNegative;
  int  lo;
  int  mid;

  if(longValue>=0)
  {
   isNegative=false;
  }
  else
  {
   isNegative=true;
   longValue =-longValue;
  }//else

  lo  = (int)longValue;
  mid = (int)(longValue >> 32);

  var resultValue
   =new System.Decimal
     (lo,
      mid,
      /*hi*/0,
      isNegative,
      scale);

  return resultValue;
 }//ConstructDecimalFromLongValue

 //-----------------------------------------------------------------------
 public static bool AssignOnceIfNotNull<T>
                        (ref System.Nullable<T> target,
                         System.Nullable<T>     value)
  where T:struct,IComparable<T>
 {
  if(!value.HasValue)
   return true;

  Debug.Assert(value.HasValue);

  //---------------------
  if(!target.HasValue)
  {
   target=value;

   return true;
  }//if

  Debug.Assert(target.HasValue);

  //---------------------
  if(target.Value.Equals(value.Value))
   return true;

  return false;
 }//AssignOnceIfNotNull<T>
};//class Structure_ADP

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
