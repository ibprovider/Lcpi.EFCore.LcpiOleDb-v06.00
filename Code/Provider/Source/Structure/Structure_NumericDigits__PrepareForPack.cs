////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.03.2021.
using System;
using System.Diagnostics;

using structure_lib=lcpi.lib.structure;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_NumericDigits__PrepareForPack

static class Structure_NumericDigits__PrepareForPack
{
 public enum ExecResultCode
 {
  Ok=0,

  Err__Overflow=1,
 };//enum ExecResultCode

 //-----------------------------------------------------------------------
 public struct ExecResult
 {
  public ExecResultCode Code;

  public Structure_NumericDigits NumericDigits;

  public ExecResult(ExecResultCode          code,
                    Structure_NumericDigits numericDigits)
  {
   this.Code          =code;
   this.NumericDigits =numericDigits;
  }//ExecResult
 };//struct ExecResult

 //Interface -------------------------------------------------------------
 public static ExecResult AdjustPrecisionAndScale
                             (Structure_NumericDigits sourceNumericDigits,
                              uint                    maxPrecision,
                              uint                    maxNegativeScale)
 {
  Debug.Assert(!Object.ReferenceEquals(sourceNumericDigits,null));

  Debug.Assert(maxPrecision>0);

  Debug.Assert(maxNegativeScale<=maxPrecision);

  //------------------------------------------------------------
  var resultNumericDigits
   =sourceNumericDigits.Clone();

  Debug.Assert(!Object.ReferenceEquals(resultNumericDigits,null));

  Debug.Assert(resultNumericDigits.Size         == sourceNumericDigits.Size);
  Debug.Assert(resultNumericDigits.Scale        == sourceNumericDigits.Scale);
  Debug.Assert(resultNumericDigits.MantisseSign == sourceNumericDigits.MantisseSign);

  //------------------------------------------------------------
  resultNumericDigits.Clamp();

  if(resultNumericDigits.Size==0)
  {
   resultNumericDigits.Reset();

   return new ExecResult(ExecResultCode.Ok,resultNumericDigits);
  }//if

  //------------------------------------------------------------
  {
   var r1
    =Helper__AdjustPrecision
      (resultNumericDigits,
       maxPrecision);

   if(r1.Code!=ExecResultCode.Ok)
    return r1;
  }//local

  Debug.Assert(resultNumericDigits.Size<=maxPrecision);

  Debug.Assert(resultNumericDigits.Scale<=0);

  var eScale_u // 0...2147483648
   =structure_lib.RemoveNumericSign.Exec(resultNumericDigits.Scale);

  if(eScale_u>maxNegativeScale)
  {
   Debug.Assert(resultNumericDigits.Scale<0);

   uint n_shift
    =(uint)structure_lib.RemoveNumericSign.Exec(eScale_u-maxNegativeScale);

   Debug.Assert(n_shift>0);

   resultNumericDigits.ShiftOnNegativeScale
    (n_shift,
     true); // without any problems

   if(resultNumericDigits.IsEmpty)
   {
    resultNumericDigits.Reset();

    return new ExecResult(ExecResultCode.Ok,resultNumericDigits);
   }//if

   eScale_u=(uint)(eScale_u-n_shift);
  }//if

  //eScale_u - NEGATIVE SCALE!

  Helper__SetupNegativeScale
   (resultNumericDigits,
    eScale_u);

  return new ExecResult(ExecResultCode.Ok,resultNumericDigits);
 }//AdjustPrecisionAndScale

 //Helper methods --------------------------------------------------------
 private static ExecResult Helper__AdjustPrecision(Structure_NumericDigits.RW numericDigits,
                                                   uint                       maxPrecision)
 {
  Debug.Assert(!Object.ReferenceEquals(numericDigits,null));
  Debug.Assert(numericDigits.Size>0);
  Debug.Assert(numericDigits.GetDigit(numericDigits.Size-1)!=0); // <--- !!!

  Debug.Assert(maxPrecision>0);

  //------------------------------------------------------------
  if(numericDigits.Scale<0)
  {
   //NEGATIVE SCALE

   return Helper__AdjustPrecision__NegativeScale
           (numericDigits,
            maxPrecision);
  }//if

  Debug.Assert(numericDigits.Scale>=0);

  return Helper__AdjustPrecision__PositiveScale
          (numericDigits,
           maxPrecision);
 }//Helper__AdjustPrecision

 //-----------------------------------------------------------------------
 private static ExecResult Helper__AdjustPrecision__NegativeScale
                                           (Structure_NumericDigits.RW numericDigits,
                                            uint                       maxPrecision)
 {
  // [2021-03-03] Tested.

  Debug.Assert(!Object.ReferenceEquals(numericDigits,null));

  Debug.Assert(numericDigits.Scale<0);

  Debug.Assert(numericDigits.Size>0);
  Debug.Assert(numericDigits.GetDigit(numericDigits.Size-1)!=0); // <--- !!!

  Debug.Assert(maxPrecision>0);

  //------------------------------------------------------------
  var eScale_u // 0...2147483648
   =structure_lib.RemoveNumericSign.Exec(numericDigits.Scale);

  Debug.Assert(eScale_u>0);
  Debug.Assert(eScale_u<=2147483648);

  {
   uint n_shift=0;

   //        |remove nulls in fractional tail
   //mantisse00000000000000000
   //
   for(;/*n_shift<numericDigits.Size && */n_shift<eScale_u;++n_shift)
   {
    Debug.Assert(n_shift<numericDigits.Size);

    if(numericDigits.GetDigit((int)n_shift)!=0)
     break;
   }//for

   Debug.Assert(n_shift<numericDigits.Size);
   Debug.Assert(n_shift<=eScale_u);

   int Size2=(int)(numericDigits.Size-n_shift);

   if(maxPrecision<Size2)
   {
    //Need additional shift to negative scale

    {
     //Prevent truncation of whole part

     uint eScale2_u=eScale_u-n_shift;

     int Size2OfWholePart;

     if(Size2<=eScale2_u)
      Size2OfWholePart=0;
     else
      Size2OfWholePart=(int)(Size2-eScale2_u);

     Debug.Assert(Size2OfWholePart>=0);
     Debug.Assert(Size2OfWholePart<=Size2);

     if(maxPrecision<Size2OfWholePart)
     {
      //Can't adjust. Whole part will be truncated!

      return new ExecResult(ExecResultCode.Err__Overflow,null);
     }//if

     Debug.Assert(Size2OfWholePart<=maxPrecision);
    }//local

    Debug.Assert(Size2>maxPrecision); //hint

    uint d=(uint)(Size2-maxPrecision);

    n_shift=n_shift+d;
   }//if maxPrecision<Size2

   Debug.Assert(n_shift<=numericDigits.Size);
   Debug.Assert(n_shift<=eScale_u);

   //truncation with round
   numericDigits.ShiftOnNegativeScale
    (n_shift,
     /*round*/true);

   Debug.Assert(numericDigits.Size<=maxPrecision);

   // [2021-03-03] No way
   Debug.Assert(!numericDigits.IsEmpty);

   // if(numericDigits.IsEmpty)
   // {
   //  numericDigits.Reset();
   //
   //  return new ExecResult(ExecResultCode.Ok,numericDigits);
   // }//if

   Debug.Assert(n_shift<=eScale_u);

   eScale_u-=n_shift;
  }//local

  //eScale_u - NEGATIVE SCALE!

  Helper__SetupNegativeScale
   (numericDigits,
    eScale_u);

  return new ExecResult(ExecResultCode.Ok,numericDigits);
 }//Helper__AdjustPrecision__NegativeScale

 //-----------------------------------------------------------------------
 private static ExecResult Helper__AdjustPrecision__PositiveScale
                                           (Structure_NumericDigits.RW numericDigits,
                                            uint                       maxPrecision)
 {
  // [2021-03-03] Tested.

  Debug.Assert(!Object.ReferenceEquals(numericDigits,null));

  Debug.Assert(numericDigits.Scale>=0);

  Debug.Assert(numericDigits.Size>0);
  Debug.Assert(numericDigits.GetDigit(numericDigits.Size-1)!=0); // <--- !!!

  Debug.Assert(maxPrecision>0);

  //------------------------------------------------------------

  //
  // Positive scale not supported (emulation through multiplication on 10^eScale_u)
  //

  //------------------------------------------------------------
  var eScale_u // 0...2147483647
   =structure_lib.RemoveNumericSign.Exec(numericDigits.Scale);

  if(maxPrecision<numericDigits.Size)
   return new ExecResult(ExecResultCode.Err__Overflow,null);

  Debug.Assert(numericDigits.Size<=maxPrecision);

  var reserve_u
   =structure_lib.RemoveNumericSign.Exec(maxPrecision-numericDigits.Size);

  if(reserve_u<eScale_u)
   return new ExecResult(ExecResultCode.Err__Overflow,null);

  Debug.Assert(eScale_u<=reserve_u);

  numericDigits.ShiftOnPositiveScale(eScale_u); //throw OOM

  numericDigits.SetScale(0);

  return new ExecResult(ExecResultCode.Ok,numericDigits);
 }//Helper__AdjustPrecision__PositiveScale

 //-----------------------------------------------------------------------
 private static void Helper__SetupNegativeScale(Structure_NumericDigits.RW numericDigits,
                                                uint                       unsignedNegativeScale)
 {
  var c_signedMinScale
   =structure_lib.NumericLimits.GetMinValue(numericDigits.Scale);

  Debug.Assert(c_signedMinScale<0);

  var c_unsignedMinScale
   =structure_lib.RemoveNumericSign.Exec(c_signedMinScale);

  Debug.Assert(c_unsignedMinScale>0);

  Debug.Assert(unsignedNegativeScale<=c_unsignedMinScale);

  if(unsignedNegativeScale==c_unsignedMinScale)
  {
   numericDigits.SetScale(c_signedMinScale);
  }
  else
  {
   numericDigits.SetScale(0-(int)unsignedNegativeScale);
  }//else
 }//Helper__SetupNegativeScale
};//class Structure_NumericDigits__PrepareForPack

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
