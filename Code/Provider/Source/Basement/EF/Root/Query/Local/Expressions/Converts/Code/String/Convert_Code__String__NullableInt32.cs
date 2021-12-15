////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 28.02.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_SOURCE
 =System.String;

using T_TARGET
 =System.Nullable<System.Int32>;

using T_TARGET_VALUE
 =System.Int32;

using T_TARGET_VALUE__UNSIGNED
 =System.UInt32;

////////////////////////////////////////////////////////////////////////////////

using T_NUMBER_PARTS
 =Structure.Structure_NumberParts;

using T_NUMBER_PARTS_PARSER
 =Structure.Structure_NumberPartsParser;

using T_NUMBER_PARTS_TO_NUMERIC_DIGITS
 =Structure.Structure_NumberParts_To_NumericDigits;

using T_NUMERIC_DIGITS
 =Structure.Structure_NumericDigits;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__String__NullableInt32

sealed class Convert_Code__String__NullableInt32
 :Core.Core_ValueCvt<T_SOURCE      ,T_TARGET>
 ,Core.Core_ValueCvt<System.Object ,T_TARGET>
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Cvt_Code__String__NullableInt32;

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__String__NullableInt32)
     .Extension__BindToTypeMethod
       (nameof(Exec),
        /*result*/typeof(T_TARGET),
        new System.Type[]{typeof(T_SOURCE)},
        BindingFlags.Static|BindingFlags.NonPublic);

 //-----------------------------------------------------------------------
 public static readonly Convert_Code__String__NullableInt32
  Instance
   =new Convert_Code__String__NullableInt32();

 //-----------------------------------------------------------------------
 private Convert_Code__String__NullableInt32()
 {
 }//Convert_Code__String__NullableInt32

 //interface -------------------------------------------------------------
 public void Exec(Core.Core_ValueCvtCtx context,
                  T_SOURCE              sourceValue,
                  out T_TARGET          targetValue)
 {
  Debug.Assert(!Object.ReferenceEquals(context,null));

  targetValue=Exec(sourceValue);
 }//Exec

 //-----------------------------------------------------------------------
 public void Exec(Core.Core_ValueCvtCtx context,
                  System.Object         sourceValue,
                  out T_TARGET          targetValue)
 {
  Debug.Assert(!Object.ReferenceEquals(context,null));

#if DEBUG
  if(!Object.ReferenceEquals(sourceValue,null))
  {
   Debug.Assert(sourceValue.GetType()==typeof(T_SOURCE));
  }//if
#endif

  targetValue=Exec((T_SOURCE)sourceValue);
 }//Exec

 //-----------------------------------------------------------------------
 private static T_TARGET Exec(T_SOURCE sourceValue)
 {
  //
  // TARGET_VALUE = TRUNC(SOURCE_VALUE)
  //

  //
  // [2021-03-01]
  //
  // Translation from HEX not implemented. May be in future, as optional feature.
  //

  if(Object.ReferenceEquals(sourceValue,null))
   return null;

  //---------------------------------------- 1. PARSER STAGE
  T_NUMBER_PARTS numberParts;

  {
   var r1
    =T_NUMBER_PARTS_PARSER.Exec
      (sourceValue,
       /*offset*/0,
       out numberParts);

   if(r1.Code!=T_NUMBER_PARTS_PARSER.ExecResultCode.Ok)
   {
    Helper__ThrowError__CantConvert();
   }//if

   Debug.Assert(r1.Code==T_NUMBER_PARTS_PARSER.ExecResultCode.Ok);

   //--------------------------------------- 1.1 LOOK TO TAIL

   int offset
    =Structure.Structure_StrHelpers.Skip__SPACES
      (sourceValue,
       r1.Offset);

   if(offset!=sourceValue.Length)
   {
    Helper__ThrowError__CantConvert();
   }//if
  }//local

  //---------------------------------------- 2. TO NUMERIC DIGITS
  T_NUMERIC_DIGITS numericDigits;

  {
   var r2
    =T_NUMBER_PARTS_TO_NUMERIC_DIGITS.Exec
      (numberParts,
       out numericDigits);

   Helper__Process_Result_From_NUMBER_PARTS_TO_NUMERIC_DIGITS(r2);

   Debug.Assert(r2.Code==T_NUMBER_PARTS_TO_NUMERIC_DIGITS.ExecResultCode.Ok);
  }//local

  Debug.Assert(!Object.ReferenceEquals(numericDigits,null));

  Debug.Assert(numericDigits.Size>=0);

  //---------------------------------------- 3. SPECIAL CASE - ZERO VALUE
  if(numericDigits.Size==0)
  {
   return 0;
  }//if

  Debug.Assert(numericDigits.Size>0);
  Debug.Assert(numericDigits.Size<=int.MaxValue);

  //---------------------------------------- 4. LOOK TO SCALE
  int nActualDigits=0;
  int nMult10=0;

  if(numericDigits.Scale<0)
  {
   nActualDigits=numericDigits.Size+numericDigits.Scale;

   if(nActualDigits<=0)
   {
    //
    // VALUE WILL BE LESS THAN 1.
    //
    // AFTER TRUNCATION VALUE WILL BE 0.

    return 0;
   }//if
  }
  else
  {
   Debug.Assert(numericDigits.Scale>=0);

   nActualDigits=numericDigits.Size;

   nMult10=numericDigits.Scale;
  }//else

  Debug.Assert(nActualDigits>0);
  Debug.Assert(nActualDigits<=numericDigits.Size);

  //---------------------------------------- 5. PROCESS MANTISSE
  const T_TARGET_VALUE__UNSIGNED
   c_max_unsignedResult
    =T_TARGET_VALUE__UNSIGNED.MaxValue;

  const T_TARGET_VALUE__UNSIGNED
   c_max_unsignedResultDiv10
    =T_TARGET_VALUE__UNSIGNED.MaxValue/10;

  T_TARGET_VALUE__UNSIGNED
   unsignedResult
    =0;

  for(int i=numericDigits.Size,e=numericDigits.Size-nActualDigits;i!=e;)
  {
   --i;

   if(c_max_unsignedResultDiv10<unsignedResult)
    Helper__ThrowError__CantConvert_Overflow();

   unsignedResult=(T_TARGET_VALUE__UNSIGNED)(unsignedResult*10);

   var x=numericDigits.GetDigit(i);

   if((c_max_unsignedResult-unsignedResult)<x)
    Helper__ThrowError__CantConvert_Overflow();

   unsignedResult=(T_TARGET_VALUE__UNSIGNED)(unsignedResult+x);
  }//for

  //---------------------------------------- 6. PROCESS SCALE
  Debug.Assert(nMult10>=0);

  for(int n=0;n!=nMult10;++n)
  {
   if(c_max_unsignedResultDiv10<unsignedResult)
    Helper__ThrowError__CantConvert_Overflow();

   unsignedResult=(T_TARGET_VALUE__UNSIGNED)(unsignedResult*10);
  }//for n

  //---------------------------------------- 7. TRANSFORM TO SIGNED VALUE
  T_TARGET_VALUE signedResult=0;

  if(numericDigits.MantisseSign==Structure.Structure_NumberSign.Negative)
  {
   const T_TARGET_VALUE__UNSIGNED
    c_max_moduleOfNegativeValue
     =((T_TARGET_VALUE__UNSIGNED)T_TARGET_VALUE.MaxValue)+1;

   if(c_max_moduleOfNegativeValue<unsignedResult)
    Helper__ThrowError__CantConvert_Overflow();

   if(unsignedResult==c_max_moduleOfNegativeValue)
   {
    signedResult=T_TARGET_VALUE.MinValue;
   }
   else
   {
    signedResult=(T_TARGET_VALUE)(0-((T_TARGET_VALUE)unsignedResult));
   }
  }
  else
  {
   Debug.Assert(numericDigits.MantisseSign!=Structure.Structure_NumberSign.Negative);

   const T_TARGET_VALUE__UNSIGNED
    c_max_moduleOfPositiveValue
     =((T_TARGET_VALUE__UNSIGNED)T_TARGET_VALUE.MaxValue);

   if(c_max_moduleOfPositiveValue<unsignedResult)
    Helper__ThrowError__CantConvert_Overflow();

   signedResult=(T_TARGET_VALUE)unsignedResult;
  }//else

  //---------------------------------------- 8. GO HOME
  return signedResult;
 }//Exec

 //Helper methods --------------------------------------------------------
 private static void Helper__Process_Result_From_NUMBER_PARTS_TO_NUMERIC_DIGITS
                                           (in T_NUMBER_PARTS_TO_NUMERIC_DIGITS.ExecResult result)
 {
  if(result.Code==T_NUMBER_PARTS_TO_NUMERIC_DIGITS.ExecResultCode.Ok)
  {
   return;
  }//if

  Debug.Assert(result.Code!=T_NUMBER_PARTS_TO_NUMERIC_DIGITS.ExecResultCode.Ok);

  if(result.Code==T_NUMBER_PARTS_TO_NUMERIC_DIGITS.ExecResultCode.Err__ScaleOverflow)
  {
   ThrowError.FailedToConvertValueBetweenTypes__OverflowInCalcOfNumberScale
    (c_ErrSrcID,
     typeof(T_SOURCE),
     typeof(T_TARGET_VALUE));
  }//if

  Debug.Assert(result.Code!=T_NUMBER_PARTS_TO_NUMERIC_DIGITS.ExecResultCode.Err__ScaleOverflow);

  //Unexpected code
  Debug.Assert(false);

  Helper__ThrowError__CantConvert();
 }//Helper__Process_Result_From_NUMBER_PARTS_TO_NUMERIC_DIGITS

 //-----------------------------------------------------------------------
 private static void Helper__ThrowError__CantConvert()
 {
  ThrowError.FailedToConvertValueBetweenTypes
   (c_ErrSrcID,
    typeof(T_SOURCE),
    typeof(T_TARGET_VALUE));
 }//Helper__ThrowError__CantConvert

 //-----------------------------------------------------------------------
 private static void Helper__ThrowError__CantConvert_Overflow()
 {
  ThrowError.FailedToConvertValueBetweenTypes__overflow
   (c_ErrSrcID,
    typeof(T_SOURCE),
    typeof(T_TARGET_VALUE));
 }//Helper__ThrowError__CantConvert_Overflow
};//class Convert_Code__String__NullableInt32

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code
