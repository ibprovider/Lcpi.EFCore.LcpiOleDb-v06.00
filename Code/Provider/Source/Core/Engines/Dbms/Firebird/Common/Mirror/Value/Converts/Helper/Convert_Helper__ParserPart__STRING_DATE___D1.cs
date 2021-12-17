////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 20.02.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Helpers{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_StrHelpers
 =Structure.Structure_StrHelpers;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Helper__ParserPart__STRING_DATE___D1

/// <summary>
///  Parser of TIME parts in string.
/// </summary>
static class Convert_Helper__ParserPart__STRING_DATE___D1
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Core_Engines_Dbms_FB_Common_Mirror__Convert_Helper__ParserPart__STRING_DATE___D1;

 //typedefs --------------------------------------------------------------
 public enum ExecResultCode
 {
  Ok=0,

  Err__UnexpectedEndOfText =1,
  Err__SeparatorNotFound   =2,
  Err__UnknownSymbol       =3,
  Err__UnknownFormat       =4,

  Err__BadPart__Year       =5,
  Err__BadPart__Month      =6,
  Err__BadPart__Day        =7,
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

 //-----------------------------------------------------------------------
 private const int c_Format__YearWidth_Min__D1 =1;
 private const int c_Format__YearWidth_Min__D3 =4;
 private const int c_Format__YearWidth_Max     =4;

 private const int c_Format__MonthWidth_Min    =1;
 private const int c_Format__MonthWidth_Max    =2;

 private const int c_Format__DayWidth_Min      =1;
 private const int c_Format__DayWidth_Max      =2;

 //Interface -------------------------------------------------------------
 public static ExecResult Exec(string  strValue,
                               int     offset,
                               out int result__Year,
                               out int result__Month,
                               out int result__Day)
 {
  Debug.Assert(!Object.ReferenceEquals(strValue,null));
  Debug.Assert(offset>=0);
  Debug.Assert(offset<=strValue.Length);

  //----------------------------------------------------------------------
  const string c_bugcheck_src
   ="Convert_Helper__ParserPart__STRING_DATE___D1::Exec";

  //----------------------------------------------------------------------
  result__Year  =0;
  result__Month =0;
  result__Day   =0;

  //----------------------------------------------------------------------
  var components=new tagComponentData[3];

  var separators=new char[2];

  int cComponents=0;

  for(int iComponent=0;;++iComponent)
  {
   Debug.Assert(iComponent<components.Length);

   offset
    =Structure_StrHelpers.Skip__SPACES_TABS
      (strValue,
       offset);

   if(offset==strValue.Length)
   {
    // END OF TEXT.

    // Conversion error.
    return new ExecResult
            (ExecResultCode.Err__UnexpectedEndOfText,
             offset);
   }//if

   Debug.Assert(offset<strValue.Length);

   components[iComponent].Start=offset;

   if(Structure_StrHelpers.IsDigit(strValue[offset]))
   {
    ++offset;

    for(;offset!=strValue.Length;++offset)
    {
     if(!Structure_StrHelpers.IsDigit(strValue[offset]))
      break;
    }//for

    components[iComponent].End=offset;

    Debug.Assert(components[iComponent].Kind==ComponentKind.Digit);
   }
   else
   if(Structure_StrHelpers.IsChar7(strValue[offset]) && iComponent==1)
   {
    //Month name?
    ++offset;

    int n=1;

    Debug.Assert(0<c_MonthNameMinLength);
    Debug.Assert(c_MonthNameMinLength<c_MonthNameMaxLength);

    for(;;++n,++offset)
    {
     if(c_MonthNameMaxLength<n)
     {
      return new ExecResult
              (ExecResultCode.Err__BadPart__Month,
               components[iComponent].Start);
     }//if

     Debug.Assert(n<=c_MonthNameMaxLength);

     if(offset==strValue.Length)
      break;

     if(!Structure_StrHelpers.IsChar7(strValue[offset]))
      break;
    }//while

    Debug.Assert(n<=c_MonthNameMaxLength);

    if(n<c_MonthNameMinLength)
    {
     return new ExecResult
             (ExecResultCode.Err__BadPart__Month,
              components[iComponent].Start);
    }//if

    Debug.Assert(c_MonthNameMinLength<=n);

    components[iComponent].End=offset;

    components[iComponent].Kind=ComponentKind.Name;
   }
   else
   {
    // Conversion error.
    return new ExecResult
            (ExecResultCode.Err__UnknownSymbol,
             offset);
   }//else

   //------------------------------------------------
   ++cComponents;

   if(cComponents==components.Length)
   {
    // Processed all known components.

    // Go to verifications.
    break;
   }//if

   Debug.Assert(cComponents<components.Length);

   Debug.Assert(iComponent<sm_SeparatorRules.Length);

   offset
    =Structure_StrHelpers.Skip__SPACES_TABS
      (strValue,
       offset);

   if(offset==strValue.Length)
   {
    // END OF TEXT.

    // Conversion error - where a separator?
    return new ExecResult
            (ExecResultCode.Err__SeparatorNotFound,
             offset);
   }//if

   Debug.Assert(offset<strValue.Length);

   var sepChars=sm_SeparatorRules[iComponent].Chars;

   Debug.Assert(!Object.ReferenceEquals(sepChars,null));
   Debug.Assert(sepChars.Length>0);

   for(int iSep=0;;++iSep)
   {
    if(iSep==sepChars.Length)
    {
     // Conversion error - separator not found.
     return new ExecResult
             (ExecResultCode.Err__SeparatorNotFound,
              offset);
    }//if

    Debug.Assert(sepChars[iSep]!=0);

    if(sepChars[iSep]!=strValue[offset])
    {
     continue;
    }//if

    // OK. Found it.

    // Save separator.
    separators[iComponent]=strValue[offset];

    // Skeep separator.
    ++offset;

    break;
   }//for iSep

   Debug.Assert(separators[iComponent]!=0);
  }//for[ever]

  Debug.Assert(cComponents==3);

  //-------------------------------------------------------
  int positionOfYear  =-1;
  int positionOfMonth =-1;
  int positionOfDay   =-1;

  var dateFormatKind
   =Helper__DetectPartPositions
     (separators,
      components,
      out positionOfYear,
      out positionOfMonth,
      out positionOfDay);

  if(dateFormatKind==DateFormatKind.Unknown)
  {
   //Unexpected format

   return new ExecResult
           (ExecResultCode.Err__UnknownFormat,
            components[0].Start);
  }//else

  //-------------------------------------------------------
  int tmp__Year  =0;
  int tmp__Month =0;
  int tmp__Day   =0;

  //-------------------------------------------------------
  int minYearWidth
   =Helper__GetMinYearWidth(dateFormatKind);

  Debug.Assert(0<minYearWidth);
  Debug.Assert(minYearWidth<=c_Format__YearWidth_Max);

  if(!Helper__ProcessDigit(strValue,
                           components[positionOfYear],
                           minYearWidth,
                           c_Format__YearWidth_Max,
                           0,
                           9999,
                           out tmp__Year))
  {
   return new ExecResult
           (ExecResultCode.Err__BadPart__Year,
            components[positionOfYear].Start);
  }//if

  // if(Helper__CanCorrectY2K(components[positionOfYear],dateFormatKind))
  // {
  //  //Correction of problem 2k
  //
  //  if(!Helper__ConvertTwoDigitYear(System.DateTime.Today.Year,tmp__Year,out tmp__Year))
  //  {
  //   return new ExecResult
  //           (ExecResultCode.Err__BadPart__Year,
  //            components[positionOfYear].Start);
  //  }//if
  // }//if

  if(!Helper__ProcessMonth(strValue,
                           components[positionOfMonth],
                           out tmp__Month))
  {
   return new ExecResult
           (ExecResultCode.Err__BadPart__Month,
            components[positionOfMonth].Start);
  }//if

  if(!Helper__ProcessDigit(strValue,
                           components[positionOfDay],
                           c_Format__DayWidth_Min,
                           c_Format__DayWidth_Max,
                           1,
                           31,
                           out tmp__Day))
  {
   return new ExecResult
           (ExecResultCode.Err__BadPart__Day,
            components[positionOfDay].Start);
  }//if

  //-------------------------------------------------------
  var testDataResult
   =lcpi.lib.structure.DateTimeUtils.TestDateTimePart_Date
     (tmp__Year,
      tmp__Month,
      tmp__Day);

  switch(testDataResult)
  {
   case lcpi.lib.structure.DateTimeUtils.TestDateResult.Ok:
    break;

   case lcpi.lib.structure.DateTimeUtils.TestDateResult.BadYear:
   {
    return new ExecResult
            (ExecResultCode.Err__BadPart__Year,
             components[positionOfYear].Start);
   }//case - BadYear

   case lcpi.lib.structure.DateTimeUtils.TestDateResult.BadMonth:
   {
    return new ExecResult
            (ExecResultCode.Err__BadPart__Month,
             components[positionOfMonth].Start);
   }//case - BadMonth

   case lcpi.lib.structure.DateTimeUtils.TestDateResult.BadDay:
   {
    return new ExecResult
            (ExecResultCode.Err__BadPart__Day,
             components[positionOfDay].Start);
   }//case - BadDay

   default:
   {
    ThrowBugCheck.generic_error
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      "unexpected result code ["+testDataResult+"]");

    break;
   }//default
  }//switch

  //-------------------------------------------------------

  // OK!

  result__Year  =tmp__Year;
  result__Month =tmp__Month;
  result__Day   =tmp__Day;

  return new ExecResult(ExecResultCode.Ok,offset);
 }//Exec

 //Helper methods --------------------------------------------------------
 private static bool Helper__ProcessDigit(string              strValue,
                                          in tagComponentData componentData,
                                          int                 minWidth,
                                          int                 maxWidth,
                                          int                 minValue,
                                          int                 maxValue,
                                          out int             resultValue)
 {
  Debug.Assert(!Object.ReferenceEquals(strValue,null));

  Debug.Assert(componentData.Start<componentData.End);

  Debug.Assert(componentData.Start>=0);
  Debug.Assert(componentData.End<=strValue.Length);

  Debug.Assert(componentData.IsDigit());

  Debug.Assert(0<minWidth);
  Debug.Assert(minWidth<=maxWidth);

  return Convert_Helper__Utils__ProcessDigit.Exec
          (strValue,
           componentData.Start,
           componentData.End,
           minWidth,
           maxWidth,
           minValue,
           maxValue,
           out resultValue);
 }//Helper__ProcessDigit

 //------------------------------------------------------------------------
 private static bool Helper__ProcessMonth(string              strValue,
                                          in tagComponentData componentData,
                                          out int             resultValue)
 {
  Debug.Assert(!Object.ReferenceEquals(strValue,null));

  Debug.Assert(componentData.Start<componentData.End);

  Debug.Assert(componentData.Start>=0);
  Debug.Assert(componentData.End<=strValue.Length);

  if(componentData.IsDigit())
  {
   return Helper__ProcessDigit
           (strValue,
            componentData,
            c_Format__MonthWidth_Min,
            c_Format__MonthWidth_Max,
            1,
            12,
            out resultValue);
  }//if

  Debug.Assert(componentData.IsName());

  var monthNameSB
   =new System.Text.StringBuilder();

  for(int x=componentData.Start;x!=componentData.End;++x)
  {
   monthNameSB.Append(Structure_StrHelpers.MakeUpper7(strValue[x]));
  }//for

  return sm_MonthNames.TryGetValue
          (monthNameSB.ToString(),
           out resultValue);
 }//Helper__ProcessMonth

 //------------------------------------------------------------------------
 private enum DateFormatKind
 {
  Unknown                      =0,

  // DD.MM.YYYY
  DayNum_p_MonthNum_p_YearNum  =1,

  // YYYY-MM-DD
  YearNum_m_MonthNum_m_DayNum  =2,

  // DD-MM-YYYY
  DayNum_m_MonthName_m_YearNum =3,
 };//enum DateFormatKind

 //------------------------------------------------------------------------
 // private static bool Helper__CanCorrectY2K(in tagComponentData yearData,
 //                                           DateFormatKind      dateFormatKind)
 // {
 //  Debug.Assert(yearData.Start<yearData.End);
 //
 //  Debug.Assert(dateFormatKind!=DateFormatKind.Unknown);
 //
 //  if(2<(yearData.End-yearData.Start))
 //   return false;
 //
 //  if(dateFormatKind==DateFormatKind.DayNum_m_MonthName_m_YearNum)
 //   return false; // D1 native date format
 //
 //  return true;
 // }//Helper__CanCorrectY2K

 //------------------------------------------------------------------------
 private static int Helper__GetMinYearWidth(DateFormatKind dateFormatKind)
 {
  Debug.Assert(dateFormatKind!=DateFormatKind.Unknown);

  switch(dateFormatKind)
  {
   case DateFormatKind.DayNum_m_MonthName_m_YearNum:
    return c_Format__YearWidth_Min__D1; // D1 native date format

   default:
    return c_Format__YearWidth_Min__D3;
  }//switch
 }//Helper__GetMinYearWidth

 //------------------------------------------------------------------------
 private static DateFormatKind Helper__DetectPartPositions
                                           (char[]             separators,
                                            tagComponentData[] components,
                                            out int            result_iYear,
                                            out int            result_iMonth,
                                            out int            result_iDay)
 {
  Debug.Assert(!Object.ReferenceEquals(separators,null));
  Debug.Assert(!Object.ReferenceEquals(components,null));

  Debug.Assert(separators.Length==2);
  Debug.Assert(components.Length==3);

  for(;;)
  {
   if(separators[0]=='.' && separators[1]=='.')
   {
    if(components[0].IsDigit() && components[1].IsDigit() && components[2].IsDigit())
    {
     // DD.MM.YYYY
     result_iDay   =0;
     result_iMonth =1;
     result_iYear  =2;

     return DateFormatKind.DayNum_p_MonthNum_p_YearNum;
    }//if

    break;
   }//if

   if(separators[1]=='-' && separators[1]=='-')
   {
    if(components[0].IsDigit() && components[1].IsDigit() && components[2].IsDigit())
    {
     // YYYY-MM-DD

     result_iYear    =0;
     result_iMonth   =1;
     result_iDay     =2;

     return DateFormatKind.YearNum_m_MonthNum_m_DayNum;
    }//if

    if(components[0].IsDigit() && components[1].IsName() && components[2].IsDigit())
    {
     // DD-MM-YYYY

     result_iDay     =0;
     result_iMonth   =1;
     result_iYear    =2;

     return DateFormatKind.DayNum_m_MonthName_m_YearNum;
    }//if

    break;
   }//if

   break;
  }//for[ever]

  result_iDay   =-1;
  result_iMonth =-1;
  result_iYear  =-1;

  return DateFormatKind.Unknown;
 }//Helper__DetectPartPositions

 //------------------------------------------------------------------------
 // private static bool Helper__ConvertTwoDigitYear(int     CurrentYear,
 //                                                 int     TwoDigitYear,
 //                                                 out int resultValue)
 // {
 //  Debug.Assert(TwoDigitYear>=0);
 //  Debug.Assert(TwoDigitYear<=99);
 //
 //  resultValue=0;
 //
 //  if(CurrentYear<0)
 //   return false;
 //
 //  if(CurrentYear<50)
 //  {
 //   resultValue=TwoDigitYear;
 //
 //   return true;
 //  }//if
 //
 //  Debug.Assert(CurrentYear>=50);
 //
 //  const int c_MAX
 //   =int.MaxValue;
 //
 //  if((c_MAX-50)<CurrentYear)
 //   return false;
 //
 //  int year2000
 //   =((CurrentYear+50)/100)*100;
 //
 //  Debug.Assert(year2000>=100);
 //
 //  int year1900
 //   =year2000-100;
 //
 //  Debug.Assert(year1900<year2000);
 //  Debug.Assert(year1900>=0);
 //
 //  if(TwoDigitYear<(CurrentYear+50-year2000))
 //  {
 //   if((c_MAX-TwoDigitYear)<year2000)
 //    return false;
 //
 //   resultValue=TwoDigitYear+year2000;
 //  }
 //  else
 //  {
 //   resultValue=TwoDigitYear+year1900;
 //  }//else
 //
 //  return true;
 // }//Helper__ConvertTwoDigitYear

 //Helper structures -----------------------------------------------------
 enum ComponentKind
 {
  Digit=0,   //default!
  Name =1,
 };//enum ComponentKind

 //-----------------------------------------------------------------------
 private struct tagComponentData
 {
  public ComponentKind Kind;

  public int Start;
  public int End;

  //selectors ---------------------------------------------
  public bool IsDigit()
  {
   return this.Kind==ComponentKind.Digit;
  }//IsDigit

  public bool IsName()
  {
   return this.Kind==ComponentKind.Name;
  }//IsName
 };//struct tagComponentData

 //-----------------------------------------------------------------------
 private struct tagSeparatorRule
 {
  public char[] Chars;

  public tagSeparatorRule(char[] chars)
  {
   Debug.Assert(!Object.ReferenceEquals(chars,null));
   Debug.Assert(chars.Length>0);

   this.Chars=chars;
  }//tagSeparatorRule
 };//struct tagSeparatorRule

 //-----------------------------------------------------------------------
 private sealed class tagMonthNames:System.Collections.Generic.Dictionary<string,int>
 {
  public new tagMonthNames Add(string Name,int Number)
  {
   Debug.Assert(!Object.ReferenceEquals(Name,null));

   Debug.Assert(Name.Length>=c_MonthNameMinLength);
   Debug.Assert(Name.Length<=c_MonthNameMaxLength);

   Debug.Assert(Number>=1);
   Debug.Assert(Number<=12);

   Debug.Assert(!base.ContainsKey(Name));

   base.Add(Name,Number);

   return this;
  }//Add
 };//class tagMonthNames

 //private data ----------------------------------------------------------
 private static readonly char[]
  sm_Sep__minus_pt
   =new char[]{'-','.'};

 private static readonly tagSeparatorRule[]
  sm_SeparatorRules
   =new tagSeparatorRule[]
    {
     /* 0 */ new tagSeparatorRule(sm_Sep__minus_pt),
     /* 1 */ new tagSeparatorRule(sm_Sep__minus_pt),
    };//sm_SeparatorRules

 //Month names -----------------------------------------------------------
 private const int c_MonthNameMinLength
  =3;

 private const int c_MonthNameMaxLength
  =9; //SEPTEMBER

 private static readonly tagMonthNames
  sm_MonthNames
   =new tagMonthNames()
    .Add("JANUARY"    , 1  )
    .Add("FEBRUARY"   , 2  )
    .Add("MARCH"      , 3  )
    .Add("APRIL"      , 4  )
    .Add("MAY"        , 5  )
    .Add("JUNE"       , 6  )
    .Add("JULY"       , 7  )
    .Add("AUGUST"     , 8  )
    .Add("SEPTEMBER"  , 9  )
    .Add("OCTOBER"    , 10 )
    .Add("NOVEMBER"   , 11 )
    .Add("DECEMBER"   , 12 )

    //short names
    .Add("JAN"        , 1  )
    .Add("FEB"        , 2  )
    .Add("MAR"        , 3  )
    .Add("APR"        , 4  )
    //.Add("MAY"        , 5  )
    .Add("JUN"        , 6  )
    .Add("JUL"        , 7  )
    .Add("AUG"        , 8  )
    .Add("SEP"        , 9  )
    .Add("OCT"        , 10 )
    .Add("NOV"        , 11 )
    .Add("DEC"        , 12 )

   /*END*/
   ;//sm_MonthNames
};//class Convert_Helper__ParserPart__STRING_DATE___D1

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Helpers
