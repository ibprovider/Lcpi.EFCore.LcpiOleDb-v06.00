////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.03.2021.
using System;
using System.Diagnostics;
using System.Reflection;

using structure_lib
 =lcpi.lib.structure;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_SOURCE
 =System.String;

using T_TARGET
 =System.Nullable<System.Decimal>;

using T_TARGET_VALUE
 =System.Decimal;

////////////////////////////////////////////////////////////////////////////////

using T_NUMBER_PARTS
 =Structure.Structure_NumberParts;

using T_NUMBER_PARTS_PARSER
 =Structure.Structure_NumberPartsParser;

using T_NUMBER_PARTS_TO_NUMERIC_DIGITS
 =Structure.Structure_NumberParts_To_NumericDigits;

using T_NUMERIC_DIGITS
 =Structure.Structure_NumericDigits;

using T_NUMERIC_DIGITS__PREPARE_FOR_PACK
 =Structure.Structure_NumericDigits__PrepareForPack;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__String__NullableDecimal

sealed class Convert_Code__String__NullableDecimal
 :Core.Core_ValueCvt<T_SOURCE      ,T_TARGET>
 ,Core.Core_ValueCvt<System.Object ,T_TARGET>
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Cvt_Code__String__NullableDecimal;

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__String__NullableDecimal)
     .Extension__BindToTypeMethod
       (nameof(Exec),
        /*result*/typeof(T_TARGET),
        new System.Type[]{typeof(T_SOURCE)},
        BindingFlags.Static|BindingFlags.NonPublic);

 //-----------------------------------------------------------------------
 public static readonly Convert_Code__String__NullableDecimal
  Instance
   =new Convert_Code__String__NullableDecimal();

 //-----------------------------------------------------------------------
 private Convert_Code__String__NullableDecimal()
 {
 }//Convert_Code__String__NullableDecimal

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
   return 0m;
  }//if

  Debug.Assert(numericDigits.Size>0);
  Debug.Assert(numericDigits.Size<=int.MaxValue);

  //---------------------------------------- 4. PREPARE FOR PACK
  {
   var r3
    =T_NUMERIC_DIGITS__PREPARE_FOR_PACK.AdjustPrecisionAndScale
      (numericDigits,
       Core.Core_Consts.MaxPrecision__Decimal,
       Core.Core_Consts.MaxScale__Decimal);

   Helper__Process_Result_From_NUMERIC_DIGITS__PREPARE_FOR_PACK(r3);

   Debug.Assert(r3.Code==T_NUMERIC_DIGITS__PREPARE_FOR_PACK.ExecResultCode.Ok);

   Debug.Assert(!Object.ReferenceEquals(r3.NumericDigits,null));

   numericDigits=r3.NumericDigits;

   Debug.Assert(!Object.ReferenceEquals(numericDigits,null));
  }//local

  if(numericDigits.Size==0)
  {
   return 0m;
  }//if

  Debug.Assert(!Object.ReferenceEquals(numericDigits,null));

  Debug.Assert(numericDigits.Size>0);
  Debug.Assert(numericDigits.Scale<=0);

  Debug.Assert(numericDigits.Size<=Core.Core_Consts.MaxPrecision__Decimal);
  Debug.Assert(numericDigits.Scale>=-Core.Core_Consts.MaxScale__Decimal);

  Debug.Assert(Core.Core_Consts.MaxScale__Decimal<byte.MaxValue);

  //---------------------------------------- 5. PACK
  System.Decimal resultDecimal=default;

  {
   var mpNum10
    =new structure_lib.MpNum10.RW();

   for(int i=0;i!=numericDigits.Size;++i)
   {
    mpNum10[i]=numericDigits.GetDigit(i);
   }

   byte decScale
    =(byte)-numericDigits.Scale;

   try
   {
    resultDecimal
     =structure_lib.DecimalUtils.ToDecimal
       (mpNum10,
        numericDigits.MantisseSign==Structure.Structure_NumberSign.Negative,
        decScale); //throw
   }
   catch(Exception e)
   {
    Helper__ThrowError__CantConvert(e);

    Debug.Assert(false);
   }//catch
  }//local

  //---------------------------------------- 6. GO HOME
  return resultDecimal;
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
 private static void Helper__Process_Result_From_NUMERIC_DIGITS__PREPARE_FOR_PACK
                                           (in T_NUMERIC_DIGITS__PREPARE_FOR_PACK.ExecResult result)
 {
  if(result.Code==T_NUMERIC_DIGITS__PREPARE_FOR_PACK.ExecResultCode.Ok)
  {
   return;
  }//if

  Debug.Assert(result.Code!=T_NUMERIC_DIGITS__PREPARE_FOR_PACK.ExecResultCode.Ok);

  if(result.Code==T_NUMERIC_DIGITS__PREPARE_FOR_PACK.ExecResultCode.Err__Overflow)
  {
   ThrowError.FailedToConvertValueBetweenTypes__overflow
    (c_ErrSrcID,
     typeof(T_SOURCE),
     typeof(T_TARGET_VALUE));
  }//if

  Debug.Assert(result.Code!=T_NUMERIC_DIGITS__PREPARE_FOR_PACK.ExecResultCode.Err__Overflow);

  //Unexpected code
  Debug.Assert(false);

  Helper__ThrowError__CantConvert();
 }//Helper__Process_Result_From_NUMERIC_DIGITS__PREPARE_FOR_PACK

 //-----------------------------------------------------------------------
 private static void Helper__ThrowError__CantConvert(Exception innerException)
 {
  ThrowError.FailedToConvertValueBetweenTypes
   (c_ErrSrcID,
    typeof(T_SOURCE),
    typeof(T_TARGET_VALUE),
    innerException);
 }//Helper__ThrowError__CantConvert

 //-----------------------------------------------------------------------
 private static void Helper__ThrowError__CantConvert()
 {
  Helper__ThrowError__CantConvert
   (/*innerException*/null);
 }//Helper__ThrowError__CantConvert

 //-----------------------------------------------------------------------
 private static void Helper__ThrowError__CantConvert_Overflow()
 {
  ThrowError.FailedToConvertValueBetweenTypes__overflow
   (c_ErrSrcID,
    typeof(T_SOURCE),
    typeof(T_TARGET_VALUE));
 }//Helper__ThrowError__CantConvert_Overflow
};//class Convert_Code__String__NullableDecimal

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code
