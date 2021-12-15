////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 24.02.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//using

using T_NUMBER_SIGN
 =Structure.Structure_NumberSign;

using T_NUMBER_PARTS
 =Structure.Structure_NumberParts;

////////////////////////////////////////////////////////////////////////////////
//class Structure_NumberPartsParser

static class Structure_NumberPartsParser
{
 //typedefs --------------------------------------------------------------
 public enum ExecResultCode
 {
  Ok=0,

  Err__NoData              =1,
  Err__BadFormat           =2,
 };//enum ExecResultCode

 //-----------------------------------------------------------------------
 public struct ExecResult
 {
  public readonly ExecResultCode  Code;
  public readonly int             Offset;

  public ExecResult(ExecResultCode code,
                    int            offset)
  {
   this.Code   =code;
   this.Offset =offset;
  }//ExecResult
 };//struct ExecResult

 //Interface -------------------------------------------------------------
 public static ExecResult Exec(string             strValue,
                               int                offset,
                               out T_NUMBER_PARTS numberParts)
 {
  Debug.Assert(!Object.ReferenceEquals(strValue,null));
  Debug.Assert(offset>=0);
  Debug.Assert(offset<=strValue.Length);

  numberParts=default;

  //----------------------------------------
  Debug.Assert(numberParts.MantisseSign==T_NUMBER_SIGN.Undefined);

  Debug.Assert(numberParts.IntPartBeg==0);
  Debug.Assert(numberParts.IntPartEnd==0);

  Debug.Assert(numberParts.FloatPartBeg==0);
  Debug.Assert(numberParts.FloatPartEnd==0);

  Debug.Assert(numberParts.ScaleSign==T_NUMBER_SIGN.Undefined);

  Debug.Assert(numberParts.ScalePartBeg==0);
  Debug.Assert(numberParts.ScalePartEnd==0);

  //----------------------------------------
  const char c_ch_0     ='0';

  const char c_ch_point ='.';
  const char c_ch_plus  ='+';
  const char c_ch_minus ='-';

  //----------------------------------------
  numberParts.Text=strValue;

  offset
   =Structure_StrHelpers.Skip__SPACES
     (strValue,
      offset);

  if(offset==strValue.Length)
   return new ExecResult(ExecResultCode.Err__NoData,offset);

  if(strValue[offset]==c_ch_plus)
  {
   numberParts.MantisseSign=T_NUMBER_SIGN.Positive;

   ++offset;
  }
  else
  if(strValue[offset]==c_ch_minus)
  {
   numberParts.MantisseSign=T_NUMBER_SIGN.Negative;

   ++offset;
  }
#if DEBUG
  else
  {
   Debug.Assert(numberParts.MantisseSign==T_NUMBER_SIGN.Undefined);
  }
#endif

  //---------------------------------------- INT PART
  Debug.Assert(numberParts.IntPartBeg==0);
  Debug.Assert(numberParts.IntPartEnd==0);

  numberParts.IntPartBeg=offset;

  for(;offset!=strValue.Length;++offset)
  {
   if(!Structure_StrHelpers.IsDigit(strValue[offset]))
    break;
  }//for

  numberParts.IntPartEnd=offset;

  bool isFloat=false;

  if(offset!=strValue.Length && strValue[offset]==c_ch_point)
  {
   isFloat=true;

   ++offset;

   numberParts.FloatPartBeg=offset;

   for(;offset!=strValue.Length;++offset)
   {
    if(!Structure_StrHelpers.IsDigit(strValue[offset]))
     break;
   }//for

   numberParts.FloatPartEnd=offset;
  }//if

  if(numberParts.IntPartBeg==numberParts.IntPartEnd && numberParts.FloatPartBeg==numberParts.FloatPartEnd)
  {
   if(isFloat)
    return new ExecResult(ExecResultCode.Err__BadFormat,offset);

   return new ExecResult(ExecResultCode.Err__NoData,offset);
  }//if

  //----------------------------------------
  for(;;)
  {
   if(offset==strValue.Length)
    break;

   if(!Helper__Is_e_or_E(strValue[offset]))
    break; //No scale part

   ++offset;

   if(offset==strValue.Length)
    return new ExecResult(ExecResultCode.Err__BadFormat,offset);

   Debug.Assert(offset<strValue.Length);

   if(strValue[offset]==c_ch_plus)
   {
    numberParts.ScaleSign=T_NUMBER_SIGN.Positive;

    ++offset;
   }
   else
   if(strValue[offset]==c_ch_minus)
   {
    numberParts.ScaleSign=T_NUMBER_SIGN.Negative;

    ++offset;
   }
#if DEBUG
   else
   {
    Debug.Assert(numberParts.ScaleSign==T_NUMBER_SIGN.Undefined);
   }
#endif

   numberParts.ScalePartBeg=offset;

   for(;offset!=strValue.Length;++offset)
   {
    if(!Structure_StrHelpers.IsDigit(strValue[offset]))
     break;
   }//for

   numberParts.ScalePartEnd=offset;

   if(numberParts.ScalePartBeg==numberParts.ScalePartEnd)
    return new ExecResult(ExecResultCode.Err__BadFormat,offset);

   break;
  }//for[ever]

  //----------------------------------------

  //INT PART: ignore forward nulls
  for(;numberParts.IntPartBeg!=numberParts.IntPartEnd;++numberParts.IntPartBeg)
  {
   if(strValue[numberParts.IntPartBeg]!=c_ch_0)
    break;
  }//for

  //FLOAT PART: ignore tail nulls
  for(;numberParts.FloatPartEnd!=numberParts.FloatPartBeg;--numberParts.FloatPartEnd)
  {
   if(strValue[numberParts.FloatPartEnd-1]!=c_ch_0)
    break;
  }//for

  //SCALE PART: ignore forward nulls
  for(;numberParts.ScalePartBeg!=numberParts.ScalePartEnd;++numberParts.ScalePartBeg)
  {
   if(strValue[numberParts.ScalePartBeg]!=c_ch_0)
    break;
  }//for

  //----------------------------------------
  return new ExecResult(ExecResultCode.Ok,offset);
 }//Exec

 //Helper methods --------------------------------------------------------
 private static bool Helper__Is_e_or_E(char ch)
 {
  if(ch=='e')
   return true;

  if(ch=='E')
   return true;

  return false;
 }//Helper__Is_e_or_E
};//class Structure_NumberPartsParser

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
