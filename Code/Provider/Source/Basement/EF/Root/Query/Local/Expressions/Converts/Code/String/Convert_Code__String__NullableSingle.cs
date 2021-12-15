////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 11.03.2021.
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
 =System.Nullable<System.Single>;

using T_TARGET_VALUE
 =System.Single;

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
//class Convert_Code__String__NullableSingle

sealed class Convert_Code__String__NullableSingle
 :Core.Core_ValueCvt<T_SOURCE      ,T_TARGET>
 ,Core.Core_ValueCvt<System.Object ,T_TARGET>
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Cvt_Code__String__NullableSingle;

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__String__NullableSingle)
     .Extension__BindToTypeMethod
       (nameof(Exec),
        /*result*/typeof(T_TARGET),
        new System.Type[]{typeof(T_SOURCE)},
        BindingFlags.Static|BindingFlags.NonPublic);

 //-----------------------------------------------------------------------
 public static readonly Convert_Code__String__NullableSingle
  Instance
   =new Convert_Code__String__NullableSingle();

 //-----------------------------------------------------------------------
 private Convert_Code__String__NullableSingle()
 {
 }//Convert_Code__String__NullableSingle

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
   if(numericDigits.MantisseSign==Structure.Structure_NumberSign.Negative)
    return -0.0F;

   return 0.0F;
  }//if

  Debug.Assert(numericDigits.Size>0);
  Debug.Assert(numericDigits.Size<=int.MaxValue);

  // Head digit is not zero!
  Debug.Assert(numericDigits.GetDigit(numericDigits.Size-1)!=0);

  //---------------------------------------- 4. TO UNSIGNED INT64 [SAFE OP]
  const int c_result_UI_precision=19;

  //
  // Ignore low zeros in actual digits
  //
  //  |--------- m a n t i s s e ------|
  //  |              ignore            |
  //  |               | |              |
  //  |----- actual ----|              |
  //  high............000............low

  int result_UI_actual_precision=c_result_UI_precision;

  if(numericDigits.Size<result_UI_actual_precision)
   result_UI_actual_precision=numericDigits.Size;

  for(;;--result_UI_actual_precision)
  {
   Debug.Assert(result_UI_actual_precision>0);

   int i=numericDigits.Size-result_UI_actual_precision;

   Debug.Assert(i>=0);
   Debug.Assert(i<numericDigits.Size);

   if(numericDigits.GetDigit(i)!=0)
    break;
  }//for

  Debug.Assert(result_UI_actual_precision>0);

  //----------------------------------------
  System.UInt64 result_UI=0;

  int iPos=numericDigits.Size;

  for(int n=0;iPos!=0 && n<result_UI_actual_precision;)
  {
   ++n;
   --iPos;

   var d=numericDigits.GetDigit(iPos);

   Debug.Assert(d<=structure_lib.NumericLimits.GetMaxValue(result_UI));

   Debug.Assert(d>=0);
   Debug.Assert(d<=9);

#if DEBUG
   if(n==1)
    Debug.Assert(d>0);
#endif

   Debug.Assert(result_UI<=(structure_lib.NumericLimits.GetMaxValue(result_UI)/10));

   result_UI=result_UI*10;

   Debug.Assert(result_UI<=(structure_lib.NumericLimits.GetMaxValue(result_UI)-d));

   result_UI+=d;
  }//for

  //
  // [2021-03-10] Not expected
  //
  Debug.Assert(result_UI!=0);

  //
  // iPos pointed to last digit, that was included into result_UI
  //
  //  |--------- m a n t i s s e ------|
  //  |                                |
  //  |                iPos            |
  //  |--- result_UI ---|              |
  //  high..............D............low

  Debug.Assert(iPos<numericDigits.Size);
  Debug.Assert(iPos>=0);

  //---------------------------------------- 5. LOOK TO SOURCE SCALE
  Debug.Assert(numericDigits.Scale.GetType()==Structure.Structure_TypeCache.TypeOf__System_Int32);

  int resultScale=0;

  if(numericDigits.Scale<0)
  {
   //
   // append a number of unprocessed mantisse digits
   //
   resultScale=numericDigits.Scale+iPos;
  }
  else
  if(numericDigits.Scale>0)
  {
   Debug.Assert(numericDigits.Scale<=System.Int32.MaxValue);

   if((Int32.MaxValue-numericDigits.Scale)<iPos)
    Helper__ThrowError__CantConvert_OverflowInCalcOfNumberScale();

   //
   // append a number of unprocessed mantisse digits
   //
   resultScale=numericDigits.Scale+iPos;
  }
  else
  {
   Debug.Assert(numericDigits.Scale==0);

   //
   // scale equal to number of unprocessed mantisse digits
   //
   resultScale=iPos;
  }//else

  //---------------------------------------- 6. BEGIN BUILD resultValue
  T_TARGET_VALUE resultValue=result_UI;

  Debug.Assert(resultValue!=0);

  //---------------------------------------- 7. LOOK TO resultScale
  Debug.Assert(!Object.ReferenceEquals(sm_FltPow10,null));
  Debug.Assert(sm_FltPow10.Length>1);

  if(resultScale<0)
  {
   var unsignedScale
    =structure_lib.RemoveNumericSign.Exec(resultScale);

   while(unsignedScale>0)
   {
    int x;

    if(unsignedScale<sm_FltPow10.Length)
    {
     x=(int)unsignedScale;
    }
    else
    {
     x=sm_FltPow10.Length-1; //max scale
    }//else

    Debug.Assert(x>=0);
    Debug.Assert(x<sm_FltPow10.Length);

    Debug.Assert(sm_FltPow10[x]>1);

    //
    // Overflow does not expected.
    //
    resultValue=resultValue/sm_FltPow10[x];

    if(T_TARGET_VALUE.IsNaN(resultScale))
     break;

    //----
    unsignedScale=(unsignedScale-structure_lib.RemoveNumericSign.Exec(x));
   }//while unsignedScale>0
  }
  else
  if(resultScale>0)
  {
   var unsignedScale
    =structure_lib.RemoveNumericSign.Exec(resultScale);

   while(unsignedScale>0)
   {
    int x;

    if(unsignedScale<sm_FltPow10.Length)
    {
     x=(int)unsignedScale;
    }
    else
    {
     x=sm_FltPow10.Length-1; //max scale
    }//else

    Debug.Assert(x>=0);
    Debug.Assert(x<sm_FltPow10.Length);
    Debug.Assert(x<sm_FltPow10.Length);

    Debug.Assert(sm_FltPow10[x]>1);

    if((T_TARGET_VALUE.MaxValue/sm_FltPow10[x])<resultValue)
     Helper__ThrowError__CantConvert_Overflow();

    //
    // Overflow does not expected.
    //
    resultValue=resultValue*sm_FltPow10[x];

    // [2021-03-10] Research...
    Debug.Assert(T_TARGET_VALUE.IsFinite(resultValue));

    //----
    unsignedScale=(unsignedScale-structure_lib.RemoveNumericSign.Exec(x));
   }//while unsignedScale>0

   Debug.Assert(unsignedScale==0);
  }
#if DEBUG
  else
  {
   Debug.Assert(resultScale==0);
  }//else
#endif

  //---------------------------------------- 8. LOOK TO MANTISSE SIGN
  if(numericDigits.MantisseSign==Structure.Structure_NumberSign.Negative)
  {
   resultValue=-resultValue;
  }//if

  //---------------------------------------- 9. GO HOME
  return resultValue;
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
   Helper__ThrowError__CantConvert_OverflowInCalcOfNumberScale();
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
   Helper__ThrowError__CantConvert_Overflow();
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

 //-----------------------------------------------------------------------
 private static void Helper__ThrowError__CantConvert_OverflowInCalcOfNumberScale()
 {
  ThrowError.FailedToConvertValueBetweenTypes__OverflowInCalcOfNumberScale
   (c_ErrSrcID,
    typeof(T_SOURCE),
    typeof(T_TARGET_VALUE));
 }//Helper__ThrowError__CantConvert_OverflowInCalcOfNumberScale

 //Private data ----------------------------------------------------------
 private static readonly T_TARGET_VALUE[] sm_FltPow10=
 {
  1E+00F ,1E+01F ,1E+02F ,1E+03F ,1E+04F ,1E+05F ,1E+06F ,1E+07F ,1E+08F ,1E+09F ,
  1E+10F ,1E+11F ,1E+12F ,1E+13F ,1E+14F ,1E+15F ,1E+16F ,1E+17F ,1E+18F ,1E+19F ,
  1E+20F ,1E+21F ,1E+22F ,1E+23F ,1E+24F ,1E+25F ,1E+26F ,1E+27F ,1E+28F ,1E+29F ,
  1E+30F ,1E+31F ,1E+32F ,1E+33F ,1E+34F ,1E+35F ,1E+36F ,1E+37F ,1E+38F
 };//sm_FltPow10
};//class Convert_Code__String__NullableSingle

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code
