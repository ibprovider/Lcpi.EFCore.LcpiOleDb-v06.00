////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 20.10.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.V03_0_0{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_StrHelpers
 =Structure.Structure_StrHelpers;

////////////////////////////////////////////////////////////////////////////////
//class FB_DataTypeParser

static partial class FB_DataTypeParser
{
 private static class tagUtils
 {
  public static int SkipEmptySpace(string sourceStr,
                                   int    offset)
  {
   Debug.Assert(!Object.ReferenceEquals(sourceStr,null));
   Debug.Assert(offset>=0);
   Debug.Assert(offset<=sourceStr.Length);

   return Structure_StrHelpers.Skip__SPACES_TABS
           (sourceStr,
            offset);
  }//SkipEmptySpace

  //----------------------------------------------------------------------
  public static int SkipTypeName(string sourceStr,
                                 int    offset)
  {
   Debug.Assert(!Object.ReferenceEquals(sourceStr,null));
   Debug.Assert(offset>=0);
   Debug.Assert(offset<=sourceStr.Length);

   if(offset==sourceStr.Length)
    return offset;

   if(!Helper__IsValidSymbolOfTypeName_1(sourceStr[offset]))
    return offset;

   ++offset;

   for(;offset!=sourceStr.Length;++offset)
   {
    if(!Helper__IsValidSymbolOfTypeName_2(sourceStr[offset]))
     break;
   }//for

   return offset;
  }//SkipTypeName

  //----------------------------------------------------------------------
  public static int SkipKeyword(string sourceStr,
                                int    offset)
  {
   Debug.Assert(!Object.ReferenceEquals(sourceStr,null));
   Debug.Assert(offset>=0);
   Debug.Assert(offset<=sourceStr.Length);

   if(offset==sourceStr.Length)
    return offset;

   if(!Helper__IsValidSymbolOfKeyword_1(sourceStr[offset]))
    return offset;

   ++offset;

   for(;offset!=sourceStr.Length;++offset)
   {
    if(!Helper__IsValidSymbolOfKeyword_2(sourceStr[offset]))
     break;
   }//for

   return offset;
  }//SkipKeyword

  //----------------------------------------------------------------------
  public static int SkipCharSetName(string sourceStr,
                                    int    offset)
  {
   Debug.Assert(!Object.ReferenceEquals(sourceStr,null));
   Debug.Assert(offset>=0);
   Debug.Assert(offset<=sourceStr.Length);

   if(offset==sourceStr.Length)
    return offset;

   if(!Helper__IsValidSymbolOfCharSetName_1(sourceStr[offset]))
    return offset;

   ++offset;

   for(;offset!=sourceStr.Length;++offset)
   {
    if(!Helper__IsValidSymbolOfCharSetName_2(sourceStr[offset]))
     break;
   }//for

   return offset;
  }//SkipCharSetName

  //----------------------------------------------------------------------
  public static int SkipSubTypeName(string sourceStr,
                                    int    offset)
  {
   Debug.Assert(!Object.ReferenceEquals(sourceStr,null));
   Debug.Assert(offset>=0);
   Debug.Assert(offset<=sourceStr.Length);

   if(offset==sourceStr.Length)
    return offset;

   if(!Helper__IsValidSymbolOfSubTypeName_1(sourceStr[offset]))
    return offset;

   ++offset;

   for(;offset!=sourceStr.Length;++offset)
   {
    if(!Helper__IsValidSymbolOfSubTypeName_2(sourceStr[offset]))
     break;
   }//for

   return offset;
  }//SkipSubTypeName

  //----------------------------------------------------------------------
  public static string MakeCharSetNameFromStrRange
                        (ReadOnlySpan<char> sourceStr)
  {
   var chars=new char[sourceStr.Length];

   for(int i=0;i!=sourceStr.Length;++i)
   {
    chars[i]=Structure_StrHelpers.MakeUpper7(sourceStr[i]);
   }//for

   return new string(chars);
  }//MakeCharSetNameFromStrRange

  //----------------------------------------------------------------------
  public static string MakeSubTypeNameFromStrRange
                        (ReadOnlySpan<char> sourceStr)
  {
   var chars=new char[sourceStr.Length];

   for(int i=0;i!=sourceStr.Length;++i)
   {
    chars[i]=Structure_StrHelpers.MakeUpper7(sourceStr[i]);
   }//for

   return new string(chars);
  }//MakeSubTypeNameFromStrRange

  //----------------------------------------------------------------------
  public static bool TestStrRange__IsDataType(ReadOnlySpan<char> sourceStr,
                                              string             upperAsciiName)
  {
   return Structure_StrHelpers.TestStrRange__ASCII_UPPER
           (sourceStr,
            upperAsciiName);
  }//TestStrRange__IsDataType

  //----------------------------------------------------------------------
  public static bool TestStrRange__IsKeyword(ReadOnlySpan<char> sourceStr,
                                             string             upperAsciiName)
  {
   return Structure_StrHelpers.TestStrRange__ASCII_UPPER
           (sourceStr,
            upperAsciiName);
  }//TestStrRange__IsKeyword

  //----------------------------------------------------------------------
  public static bool TestStrRange__IsBlobSubType(ReadOnlySpan<char> sourceStr,
                                                 string             upperAsciiName)
  {
   return Structure_StrHelpers.TestStrRange__ASCII_UPPER
           (sourceStr,
            upperAsciiName);
  }//TestStrRange__IsBlobSubType

  //----------------------------------------------------------------------
  public static bool IsDigit(char ch)
  {
   return Structure_StrHelpers.IsDigit(ch);
  }//IsDigit

  //----------------------------------------------------------------------
  public static bool TryCvtStrRangeToInt(ReadOnlySpan<char> sourceStr,
                                         out int            resultValue)
  {
   Debug.Assert(sourceStr.Length>0); // <------------- NOTE THAT!!!

   resultValue=0;

   const int c_max_int_div10=int.MaxValue/10;

   for(int i=0;i!=sourceStr.Length;++i)
   {
    var ch=sourceStr[i];

    Debug.Assert(IsDigit(ch));

    var x=(int)(ch-'0');

    Debug.Assert(x>=0);
    Debug.Assert(x<=9);

    if(resultValue>c_max_int_div10)
     return false;

    resultValue=resultValue*10;

    if((int.MaxValue-resultValue)<x)
     return false;

    resultValue+=x;
   }//for i

   return true;
  }//TryCvtStrRangeToInt

  //----------------------------------------------------------------------
  private static bool Helper__IsValidSymbolOfKeyword_1(char ch)
  {
   return Structure_StrHelpers.IsChar7(ch);
  }//Helper__IsValidSymbolOfKeyword_1

  //----------------------------------------------------------------------
  private static bool Helper__IsValidSymbolOfKeyword_2(char ch)
  {
   if(ch=='_')
    return true;

   return Helper__IsValidSymbolOfKeyword_1(ch);
  }//Helper__IsValidSymbolOfKeyword_2

  //----------------------------------------------------------------------
  private static bool Helper__IsValidSymbolOfTypeName_1(char ch)
  {
   return Structure_StrHelpers.IsChar7(ch);
  }//Helper__IsValidSymbolOfTypeName_1

  //----------------------------------------------------------------------
  private static bool Helper__IsValidSymbolOfTypeName_2(char ch)
  {
   return Helper__IsValidSymbolOfTypeName_1(ch);
  }//Helper__IsValidSymbolOfTypeName_2

  //----------------------------------------------------------------------
  private static bool Helper__IsValidSymbolOfCharSetName_1(char ch)
  {
   return Structure_StrHelpers.IsChar7(ch);
  }//Helper__IsValidSymbolOfCharSetName_1

  //----------------------------------------------------------------------
  private static bool Helper__IsValidSymbolOfCharSetName_2(char ch)
  {
   if(ch=='_')
    return true;

   if(Structure_StrHelpers.IsDigit(ch))
    return true;

   return Helper__IsValidSymbolOfCharSetName_1(ch);
  }//Helper__IsValidSymbolOfCharSetName_2

  //----------------------------------------------------------------------
  private static bool Helper__IsValidSymbolOfSubTypeName_1(char ch)
  {
   return Structure_StrHelpers.IsChar7(ch);
  }//Helper__IsValidSymbolOfSubTypeName_1

  //----------------------------------------------------------------------
  private static bool Helper__IsValidSymbolOfSubTypeName_2(char ch)
  {
   return Helper__IsValidSymbolOfSubTypeName_1(ch);
  }//Helper__IsValidSymbolOfSubTypeName_2
 };//class tagUtils
};//class FB_DataTypeParser

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.V03_0_0
