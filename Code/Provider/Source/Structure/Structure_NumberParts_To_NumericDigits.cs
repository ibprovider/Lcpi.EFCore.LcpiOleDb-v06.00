////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.02.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////

using T_NUMBER_PARTS
 =Structure.Structure_NumberParts;

using T_NUMBER_SIGN
 =Structure.Structure_NumberSign;

using T_NUMERIC_DIGITS
 =Structure.Structure_NumericDigits;

////////////////////////////////////////////////////////////////////////////////
//class Structure_NumberParts_To_NumericDigits

static class Structure_NumberParts_To_NumericDigits
{
 //typedefs --------------------------------------------------------------
 public enum ExecResultCode
 {
  Ok=0,

  Err__ScaleOverflow=1,
 };//enum ExecResultCode

 //-----------------------------------------------------------------------
 public struct ExecResult
 {
  public readonly ExecResultCode Code;

  public ExecResult(ExecResultCode code)
  {
   this.Code=code;
  }//ExecResult
 };//struct ExecResult

 //Interface -------------------------------------------------------------

 //
 //                0    ...      8 <- indexes
 // "12345670" -> {0,7,6,5,4,3,2,1}
 //

 public static ExecResult Exec(in T_NUMBER_PARTS    numberParts,
                               out T_NUMERIC_DIGITS numericDigits)
 {
  Debug.Assert(!Object.ReferenceEquals(numberParts.Text,null));

  Debug.Assert(numberParts.IntPartBeg   >=0);
  Debug.Assert(numberParts.FloatPartBeg >=0);
  Debug.Assert(numberParts.ScalePartBeg >=0);

  Debug.Assert(numberParts.IntPartBeg   <=numberParts.IntPartEnd);
  Debug.Assert(numberParts.FloatPartBeg <=numberParts.FloatPartEnd);
  Debug.Assert(numberParts.ScalePartBeg <=numberParts.ScalePartEnd);

  Debug.Assert(numberParts.IntPartEnd   <= numberParts.Text.Length);
  Debug.Assert(numberParts.FloatPartEnd <= numberParts.Text.Length);
  Debug.Assert(numberParts.ScalePartEnd <= numberParts.Text.Length);

  numericDigits=null;

  //----------------------------------------
  const char c_ch_0='0';
  const char c_ch_9='9';

  //----------------------------------------
  int iscale=0; //scale of whole part       *10^scale
  int fscale=0; //scale of fractional part  /10^scale

  //----------------------------------------
  int IntPartBeg=numberParts.IntPartBeg;

  //skip forward 0
  for(;IntPartBeg!=numberParts.IntPartEnd;++IntPartBeg)
  {
   if(numberParts.Text[IntPartBeg]!=c_ch_0)
    break;
  }//if

  //----------------------------------------
  int FloatPartEnd=numberParts.FloatPartEnd;

  //skip tail 0
  for(;FloatPartEnd!=numberParts.FloatPartBeg;--FloatPartEnd)
  {
   if(numberParts.Text[FloatPartEnd-1]!=c_ch_0)
    break;
  }//for

  //----------------------------------------
  int FloatPartBeg=numberParts.FloatPartBeg;

  if(IntPartBeg==numberParts.IntPartEnd)
  {
   // No whole part
   //
   // Skip forward 0 in float part
   //
   //             FloatPartBeg         FloatPartEnd
   //                  |                    |
   // empty_whole_part.00000000000float_part

   for(;FloatPartBeg!=FloatPartEnd;++FloatPartBeg,++fscale)
   {
    if(numberParts.Text[FloatPartBeg]!=c_ch_0)
     break;
   }//for
  }//if

  //----------------------------------------
  int IntPartEnd=numberParts.IntPartEnd;

  if(FloatPartBeg==FloatPartEnd)
  {
   // No float part!
   Debug.Assert(fscale==0);

   // Skip tail 0 in while part
   //
   // IntPartBeg              IntPartEnd
   // |                       |
   // whole_part00000000000000.empty_float_part

   for(;IntPartEnd!=IntPartBeg;--IntPartEnd,++iscale)
   {
    if(numberParts.Text[IntPartEnd-1]!=c_ch_0)
     break;
   }//for
  }//if

  //----------------------------------------
  Debug.Assert(iscale==0 || fscale==0);

  Debug.Assert(IntPartBeg   >= numberParts.IntPartBeg);
  Debug.Assert(FloatPartBeg >= numberParts.FloatPartBeg);

  Debug.Assert(IntPartBeg   <= IntPartEnd);
  Debug.Assert(FloatPartBeg <= FloatPartEnd);

  Debug.Assert(IntPartEnd   <= numberParts.IntPartEnd);
  Debug.Assert(FloatPartEnd <= numberParts.FloatPartEnd);

  //----------------------------------------
  int fscale2=FloatPartEnd-FloatPartBeg;

  //---------------------------------------- PROCESSING OF WHOLE AND FLOAT PARTS
  T_NUMERIC_DIGITS.RW tempNumericDigits;

  {
   int w1=IntPartEnd-IntPartBeg;
   int w2=fscale2;

   Debug.Assert(w1<=int.MaxValue);
   Debug.Assert(w2<=(int.MaxValue-w1));

   int w=w1+w2;

   tempNumericDigits
    =new T_NUMERIC_DIGITS.RW
      (w);

   Debug.Assert(tempNumericDigits.IsEmpty);

   //process whole part
   for(int i=IntPartBeg;i!=IntPartEnd;++i)
   {
    char ch=numberParts.Text[i];

    Debug.Assert(ch>=c_ch_0);
    Debug.Assert(ch<=c_ch_9);

    Debug.Assert(w>0);

    --w;

    tempNumericDigits.SetDigit(w,(byte)(ch-c_ch_0));
   }//for i

   //process float part
   for(int i=FloatPartBeg;i!=FloatPartEnd;++i)
   {
    char ch=numberParts.Text[i];

    Debug.Assert(ch>=c_ch_0);
    Debug.Assert(ch<=c_ch_9);

    Debug.Assert(w>0);

    --w;

    tempNumericDigits.SetDigit(w,(byte)(ch-c_ch_0));
   }//for i

   Debug.Assert(w==0);
  }//local

  //---------------------------------------- LOOK TO ESCALE PART
  uint escale_u=0;

  {
   uint c_MaxScale
    =(numberParts.ScaleSign==T_NUMBER_SIGN.Negative)
      ?2147483648u
      :2147483647u;

   uint c_MaxScaleDiv10
    =c_MaxScale/10;

   for(int i=numberParts.ScalePartBeg;i!=numberParts.ScalePartEnd;++i)
   {
    char ch=numberParts.Text[i];

    Debug.Assert(ch>=c_ch_0);
    Debug.Assert(ch<=c_ch_9);

    if(ch==c_ch_0 && escale_u==0)
     continue;

    if(escale_u>c_MaxScaleDiv10)
     return new ExecResult(ExecResultCode.Err__ScaleOverflow);

    escale_u=10*escale_u;

    var x=(byte)(ch-c_ch_0);

    Debug.Assert(x>=0);
    Debug.Assert(x<=9);

    if(c_MaxScale-escale_u<x)
     return new ExecResult(ExecResultCode.Err__ScaleOverflow);

    escale_u+=x;
   }//for i
  }//local

  //---------------------------------------- PROCESS xSCALE values
  int finalScale=0;

  if(numberParts.ScaleSign!=T_NUMBER_SIGN.Negative)
  {
   Debug.Assert(escale_u<=2147483647u);

   finalScale=(int)escale_u;
  }
  else
  if(escale_u==2147483648u)
  {
   finalScale=int.MinValue;
  }
  else
  {
   Debug.Assert(escale_u<2147483648u);

   finalScale=-(int)escale_u;
  }//else

  //--------------------------
  if(!Helper__CanAdd(finalScale,iscale))
   return new ExecResult(ExecResultCode.Err__ScaleOverflow);

  finalScale+=iscale;

  //--------------------------
  if(!Helper__CanSubtract(finalScale,fscale))
   return new ExecResult(ExecResultCode.Err__ScaleOverflow);

  finalScale-=fscale;

  //--------------------------
  if(!Helper__CanSubtract(finalScale,fscale2))
   return new ExecResult(ExecResultCode.Err__ScaleOverflow);

  finalScale-=fscale2;

  //--------------------------
  tempNumericDigits.SetScale(finalScale);

  //----------------------------------------
  tempNumericDigits.SetMantisseSign(numberParts.MantisseSign);

  //----------------------------------------
  numericDigits=tempNumericDigits;

  return new ExecResult(ExecResultCode.Ok);
 }//Exec

 //Helper methods --------------------------------------------------------
 private static bool Helper__CanSubtract(int a,int positiveB)
 {
  Debug.Assert(positiveB>=0);

  if(a>=0)
   return true;

  if(a>=int.MinValue+positiveB)
   return true;

  return false;
 }//Helper__CanSubtract

 //-----------------------------------------------------------------------
 private static bool Helper__CanAdd(int a,int positiveB)
 {
  Debug.Assert(positiveB>=0);

  if(a<=0)
   return true;

  if(a<=int.MaxValue-positiveB)
   return true;

  return false;
 }//Helper__CanAdd
};//class Structure_NumberParts_To_NumericDigits

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
