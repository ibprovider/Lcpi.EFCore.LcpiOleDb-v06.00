////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 10.03.2021.
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
 =System.Nullable<System.Double>;

using T_TARGET_VALUE
 =System.Double;

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
//class Convert_Code__String__NullableDouble

sealed class Convert_Code__String__NullableDouble
 :Core.Core_ValueCvt<T_SOURCE      ,T_TARGET>
 ,Core.Core_ValueCvt<System.Object ,T_TARGET>
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Cvt_Code__String__NullableDouble;

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__String__NullableDouble)
     .Extension__BindToTypeMethod
       (nameof(Exec),
        /*result*/typeof(T_TARGET),
        new System.Type[]{typeof(T_SOURCE)},
        BindingFlags.Static|BindingFlags.NonPublic);

 //-----------------------------------------------------------------------
 public static readonly Convert_Code__String__NullableDouble
  Instance
   =new Convert_Code__String__NullableDouble();

 //-----------------------------------------------------------------------
 private Convert_Code__String__NullableDouble()
 {
 }//Convert_Code__String__NullableDouble

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
    return -0.0;

   return 0.0;
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
  Debug.Assert(!Object.ReferenceEquals(sm_DblPow10,null));
  Debug.Assert(sm_DblPow10.Length>1);

  if(resultScale<0)
  {
   var unsignedScale
    =structure_lib.RemoveNumericSign.Exec(resultScale);

   while(unsignedScale>0)
   {
    int x;

    if(unsignedScale<sm_DblPow10.Length)
    {
     x=(int)unsignedScale;
    }
    else
    {
     x=sm_DblPow10.Length-1; //max scale
    }//else

    Debug.Assert(x>=0);
    Debug.Assert(x<sm_DblPow10.Length);

    Debug.Assert(sm_DblPow10[x]>1);

    //
    // Overflow does not expected.
    //
    resultValue=resultValue/sm_DblPow10[x];

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

    if(unsignedScale<sm_DblPow10.Length)
    {
     x=(int)unsignedScale;
    }
    else
    {
     x=sm_DblPow10.Length-1; //max scale
    }//else

    Debug.Assert(x>=0);
    Debug.Assert(x<sm_DblPow10.Length);
    Debug.Assert(x<sm_DblPow10.Length);

    Debug.Assert(sm_DblPow10[x]>1);

    if((T_TARGET_VALUE.MaxValue/sm_DblPow10[x])<resultValue)
     Helper__ThrowError__CantConvert_Overflow();

    //
    // Overflow does not expected.
    //
    resultValue=resultValue*sm_DblPow10[x];

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
 private static readonly T_TARGET_VALUE[] sm_DblPow10=
 {
  1E+000 ,1E+001 ,1E+002 ,1E+003 ,1E+004 ,1E+005 ,1E+006 ,1E+007 ,1E+008 ,1E+009 ,
  1E+010 ,1E+011 ,1E+012 ,1E+013 ,1E+014 ,1E+015 ,1E+016 ,1E+017 ,1E+018 ,1E+019 ,
  1E+020 ,1E+021 ,1E+022 ,1E+023 ,1E+024 ,1E+025 ,1E+026 ,1E+027 ,1E+028 ,1E+029 ,
  1E+030 ,1E+031 ,1E+032 ,1E+033 ,1E+034 ,1E+035 ,1E+036 ,1E+037 ,1E+038 ,1E+039 ,
  1E+040 ,1E+041 ,1E+042 ,1E+043 ,1E+044 ,1E+045 ,1E+046 ,1E+047 ,1E+048 ,1E+049 ,
  1E+050 ,1E+051 ,1E+052 ,1E+053 ,1E+054 ,1E+055 ,1E+056 ,1E+057 ,1E+058 ,1E+059 ,
  1E+060 ,1E+061 ,1E+062 ,1E+063 ,1E+064 ,1E+065 ,1E+066 ,1E+067 ,1E+068 ,1E+069 ,
  1E+070 ,1E+071 ,1E+072 ,1E+073 ,1E+074 ,1E+075 ,1E+076 ,1E+077 ,1E+078 ,1E+079 ,
  1E+080 ,1E+081 ,1E+082 ,1E+083 ,1E+084 ,1E+085 ,1E+086 ,1E+087 ,1E+088 ,1E+089 ,
  1E+090 ,1E+091 ,1E+092 ,1E+093 ,1E+094 ,1E+095 ,1E+096 ,1E+097 ,1E+098 ,1E+099 ,
  1E+100 ,1E+101 ,1E+102 ,1E+103 ,1E+104 ,1E+105 ,1E+106 ,1E+107 ,1E+108 ,1E+109 ,
  1E+110 ,1E+111 ,1E+112 ,1E+113 ,1E+114 ,1E+115 ,1E+116 ,1E+117 ,1E+118 ,1E+119 ,
  1E+120 ,1E+121 ,1E+122 ,1E+123 ,1E+124 ,1E+125 ,1E+126 ,1E+127 ,1E+128 ,1E+129 ,
  1E+130 ,1E+131 ,1E+132 ,1E+133 ,1E+134 ,1E+135 ,1E+136 ,1E+137 ,1E+138 ,1E+139 ,
  1E+140 ,1E+141 ,1E+142 ,1E+143 ,1E+144 ,1E+145 ,1E+146 ,1E+147 ,1E+148 ,1E+149 ,
  1E+150 ,1E+151 ,1E+152 ,1E+153 ,1E+154 ,1E+155 ,1E+156 ,1E+157 ,1E+158 ,1E+159 ,
  1E+160 ,1E+161 ,1E+162 ,1E+163 ,1E+164 ,1E+165 ,1E+166 ,1E+167 ,1E+168 ,1E+169 ,
  1E+170 ,1E+171 ,1E+172 ,1E+173 ,1E+174 ,1E+175 ,1E+176 ,1E+177 ,1E+178 ,1E+179 ,
  1E+180 ,1E+181 ,1E+182 ,1E+183 ,1E+184 ,1E+185 ,1E+186 ,1E+187 ,1E+188 ,1E+189 ,
  1E+190 ,1E+191 ,1E+192 ,1E+193 ,1E+194 ,1E+195 ,1E+196 ,1E+197 ,1E+198 ,1E+199 ,
  1E+200 ,1E+201 ,1E+202 ,1E+203 ,1E+204 ,1E+205 ,1E+206 ,1E+207 ,1E+208 ,1E+209 ,
  1E+210 ,1E+211 ,1E+212 ,1E+213 ,1E+214 ,1E+215 ,1E+216 ,1E+217 ,1E+218 ,1E+219 ,
  1E+220 ,1E+221 ,1E+222 ,1E+223 ,1E+224 ,1E+225 ,1E+226 ,1E+227 ,1E+228 ,1E+229 ,
  1E+230 ,1E+231 ,1E+232 ,1E+233 ,1E+234 ,1E+235 ,1E+236 ,1E+237 ,1E+238 ,1E+239 ,
  1E+240 ,1E+241 ,1E+242 ,1E+243 ,1E+244 ,1E+245 ,1E+246 ,1E+247 ,1E+248 ,1E+249 ,
  1E+250 ,1E+251 ,1E+252 ,1E+253 ,1E+254 ,1E+255 ,1E+256 ,1E+257 ,1E+258 ,1E+259 ,
  1E+260 ,1E+261 ,1E+262 ,1E+263 ,1E+264 ,1E+265 ,1E+266 ,1E+267 ,1E+268 ,1E+269 ,
  1E+270 ,1E+271 ,1E+272 ,1E+273 ,1E+274 ,1E+275 ,1E+276 ,1E+277 ,1E+278 ,1E+279 ,
  1E+280 ,1E+281 ,1E+282 ,1E+283 ,1E+284 ,1E+285 ,1E+286 ,1E+287 ,1E+288 ,1E+289 ,
  1E+290 ,1E+291 ,1E+292 ,1E+293 ,1E+294 ,1E+295 ,1E+296 ,1E+297 ,1E+298 ,1E+299 ,
  1E+300 ,1E+301 ,1E+302 ,1E+303 ,1E+304 ,1E+305 ,1E+306 ,1E+307 ,1E+308
 };//sm_DblPow10
};//class Convert_Code__String__NullableDouble

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code
