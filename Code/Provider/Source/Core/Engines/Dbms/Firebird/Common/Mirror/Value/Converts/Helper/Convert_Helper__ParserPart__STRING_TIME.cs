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
//class Convert_Helper__ParserPart__STRING_TIME

/// <summary>
///  Parser of TIME parts in string.
/// </summary>
static class Convert_Helper__ParserPart__STRING_TIME
{
 public enum ExecResultCode
 {
  Ok=0,

  Err__NoData                =3,
  Err__BadFormat             =4,

  Err__BadPart__Hours        =5,
  Err__BadPart__Minutes      =6,
  Err__BadPart__Seconds      =7,
  Err__BadPart__MicroSeconds =8,
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
 public static ExecResult Exec(string  strValue,
                               int     offset,
                               out int result_Hours,
                               out int result_Minutes,
                               out int result_Seconds,
                               out int result_MicroSeconds)
 {
  Debug.Assert(!Object.ReferenceEquals(strValue,null));
  Debug.Assert(offset>=0);
  Debug.Assert(offset<=strValue.Length);

  //----------------------------------------------------------------------
  result_Hours=0;
  result_Minutes=0;
  result_Seconds=0;
  result_MicroSeconds=0;

  Debug.Assert(sm_SeparatorRules.Length==3);

  var components=new tagComponentData[sm_SeparatorRules.Length+1];

  var separators=new char[sm_SeparatorRules.Length];

  int cComponents=0;

  int result_EndOfData=offset;

  for(int iComponent=0;;++iComponent)
  {
   Debug.Assert(iComponent<components.Length);

   offset
    =Structure_StrHelpers.Skip__SPACES_TABS
      (strValue,
       offset);

   if(offset==strValue.Length)
    break;

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
   }
   else
   {
    break;
   }//else

   //------------------------------------------------
   result_EndOfData=offset;

   ++cComponents;

   if(cComponents==components.Length)
   {
    //Processed all components

    break;
   }//if

   Debug.Assert(cComponents<components.Length);

   offset
    =Structure_StrHelpers.Skip__SPACES_TABS
      (strValue,
       offset);

   if(offset==strValue.Length)
    break;

   Debug.Assert(offset<strValue.Length);

   // Continue a process of parsing

   Debug.Assert(iComponent<sm_SeparatorRules.Length);

   // All separators have a definition.
   Debug.Assert(sm_SeparatorRules[iComponent].Char!=0);

   if(sm_SeparatorRules[iComponent].Char!=strValue[offset])
   {
    // Expected separator not found.

    break;
   }//if

   // OK. Found it.

   // Save separator.
   separators[iComponent]=strValue[offset];

   // Skeep separator.
   ++offset;

   result_EndOfData=offset;
  }//for[ever]

  Debug.Assert(cComponents<=components.Length);

  if(cComponents==0)
  {
   //NO COMPONENTS - conversion errors.

   return new ExecResult(ExecResultCode.Err__NoData,result_EndOfData);
  }//if

  Debug.Assert(cComponents>0);

  if(cComponents<components.Length)
  {
   // Processed not all components

   Debug.Assert(cComponents<=sm_SeparatorRules.Length);
   Debug.Assert(cComponents<=separators.Length);

   if(separators[cComponents-1]!=0)
   {
    // Value was ended by separator.

    if(!sm_SeparatorRules[cComponents-1].CanTerminate)
    {
     // UNEXPECTED END - conversion error.

     return new ExecResult(ExecResultCode.Err__BadFormat,result_EndOfData);
    }//if
   }//if
  }//if cComponents<components.Length

  //Hours and minutes - are required!
  if(cComponents<2)
  {
   return new ExecResult(ExecResultCode.Err__BadFormat,result_EndOfData);
  }//if

  //----------------------------------------
  Debug.Assert(cComponents>=2);

  int tmp__Hours       =0;
  int tmp__Minutes     =0;
  int tmp__Seconds     =0;
  int tmp__MicroSeconds=0;

  if(!Helper__ProcessDigit(strValue,components[0],
                           /*minWidth*/1,
                           /*maxWidth*/2,
                           0,
                           23,
                           out tmp__Hours))
  {
   //Problem with hours component.

   return new ExecResult(ExecResultCode.Err__BadPart__Hours,components[0].Start);
  }//if

  if(!Helper__ProcessDigit(strValue,
                           components[1],
                           /*minWidth*/1,
                           /*maxWidth*/2,
                           0,
                           59,
                           out tmp__Minutes))
  {
   //Problem with minutes component.

   return new ExecResult(ExecResultCode.Err__BadPart__Minutes,components[1].Start);
  }//if

  if(cComponents>=3 && !Helper__ProcessDigit(strValue,
                                             components[2],
                                             /*minWidth*/1,
                                             /*maxWidth*/2,
                                             0,
                                             59,
                                             out tmp__Seconds))
  {
   //Problem with seconds component.

   return new ExecResult(ExecResultCode.Err__BadPart__Seconds,components[2].Start);
  }//if

  if(cComponents==4)
  {
   if(!Helper__ProcessDigit(strValue,
                            components[3],
                            /*minWidth*/1,
                            /*maxWidth*/4,
                            0,
                            9999,
                            out tmp__MicroSeconds))
   {
    //Problem with microseconds component.

    return new ExecResult(ExecResultCode.Err__BadPart__MicroSeconds,components[3].Start);
   }//if

   //Adjust microseconds
   for(int n=components[3].End-components[3].Start;n!=4;++n)
   {
    tmp__MicroSeconds=tmp__MicroSeconds*10;
   }
  }//if cComponents==4

  //----------------------------------------

  // OK!

  result_Hours        = tmp__Hours;
  result_Minutes      = tmp__Minutes;
  result_Seconds      = tmp__Seconds;
  result_MicroSeconds = tmp__MicroSeconds;

  return new ExecResult(ExecResultCode.Ok,result_EndOfData);
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

 //Helper structures -----------------------------------------------------
 private struct tagComponentData
 {
  public int Start;
  public int End;
 };//struct tagComponentData

 //-----------------------------------------------------------------------
 private struct tagSeparatorRule
 {
  public bool   CanTerminate;
  public char   Char;

  public tagSeparatorRule(bool canTerminate,Char ch)
  {
   this.CanTerminate=canTerminate;
   this.Char        =ch;
  }//tagSeparatorRule
 };//struct tagSeparatorRule

 //private data ----------------------------------------------------------
 private static readonly tagSeparatorRule[]
  sm_SeparatorRules
   =new tagSeparatorRule[]
    {
     /* 0 */ new tagSeparatorRule(false, ':' ),
     /* 1 */ new tagSeparatorRule(false, ':' ),
     /* 2 */ new tagSeparatorRule(true , '.' ),
    };//sm_SeparatorRules
};//Convert_Helper__ParserPart__STRING_TIME

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Helpers