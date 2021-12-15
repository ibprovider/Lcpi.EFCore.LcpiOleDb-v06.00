////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.02.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_StrHelpers

static class Structure_StrHelpers
{
 public static bool IsDigit(char ch)
 {
  return ch>='0' && ch<='9';
 }//IsDigit

 //-----------------------------------------------------------------------
 public static bool IsChar7(char ch)
 {
  if(Helper__IS_UPPER7(ch))
   return true;

  if(Helper__IS_LOWER7(ch))
   return true;

  return false;
 }//IsChar7

 //-----------------------------------------------------------------------
 public static bool IsSpaceOrTab(char ch)
 {
  switch(ch)
  {
   case ' ' :
   case '\t':
   {
    return true;
   }//case
  }//switch

  return false;
 }//IsSpaceOrTab

 //-----------------------------------------------------------------------
 public static bool IsSpace(char ch)
 {
  if(ch==' ')
   return true;

  return false;
 }//IsSpace

 //-----------------------------------------------------------------------
 public static char MakeUpper7(char ch)
 {
  return Helper__UPPER7(ch);
 }//MakeUpper7

 //-----------------------------------------------------------------------
 public static int Skip__SPACES_TABS(string text,
                                     int    offset)
 {
  Debug.Assert(!Object.ReferenceEquals(text,null));

  Debug.Assert(offset>=0);
  Debug.Assert(offset<=text.Length);

  while(offset<text.Length)
  {
   if(!IsSpaceOrTab(text[offset]))
    break;

   ++offset;
  }//while offset<text.Length

  return offset;
 }//Skip__SPACES_TABS

 //-----------------------------------------------------------------------
 public static int Skip__SPACES(string text,
                                int    offset)
 {
  Debug.Assert(!Object.ReferenceEquals(text,null));

  Debug.Assert(offset>=0);
  Debug.Assert(offset<=text.Length);

  while(offset<text.Length)
  {
   if(!IsSpace(text[offset]))
    break;

   ++offset;
  }//while offset<text.Length

  return offset;
 }//Skip__SPACES

 //-----------------------------------------------------------------------
 public static bool TestStrPrefix__ASCII_UPPER(string source,
                                               int    offset,
                                               string upperAsciiPattern)   //upper
 {
  Debug.Assert(!Object.ReferenceEquals(source,null));
  Debug.Assert(!Object.ReferenceEquals(upperAsciiPattern,null));

  Debug.Assert(upperAsciiPattern.Length>0);

  Debug.Assert(offset>=0);
  Debug.Assert(offset<=source.Length);

  int iSource=offset;
  int iPattern=0;

  int cSource  =source.Length;
  int cPattern =upperAsciiPattern.Length;

  for(;;++iSource,++iPattern)
  {
   if(iPattern==cPattern)
   {
    return true;
   }//if

   Debug.Assert(iPattern<cPattern);

   if(iSource==cSource)
   {
    return false;
   }//if

   Debug.Assert(iSource<cSource);

   Debug.Assert(!Helper__IS_LOWER7(upperAsciiPattern[iPattern]));

   var ch=Helper__UPPER7(source[iSource]);

   if(ch==upperAsciiPattern[iPattern])
    continue;

   return false;
  }//for[ever]
 }//TestStrPrefix__ASCII_UPPER

 //-----------------------------------------------------------------------
 public static bool TestStrRange__ASCII_UPPER(ReadOnlySpan<char> source,
                                              string             upperAsciiPattern)
 {
  Debug.Assert(!Object.ReferenceEquals(upperAsciiPattern,null));

  Debug.Assert(upperAsciiPattern.Length>0);

  if(source.Length!=upperAsciiPattern.Length)
   return false;

  for(int i=0,_c=upperAsciiPattern.Length;i!=_c;++i)
  {
   Debug.Assert(!Helper__IS_LOWER7(upperAsciiPattern[i]));

   var ch=Helper__UPPER7(source[i]);

   if(ch==upperAsciiPattern[i])
    continue;

   return false;
  }//for[ever]

  return true;
 }//TestStrRange__ASCII_UPPER - span

 //Helper methods --------------------------------------------------------
 private static bool Helper__IS_LOWER7(char ch)
 {
  return ch>='a' && ch<='z';
 }//Helper__IS_LOWER7

 //-----------------------------------------------------------------------
 private static bool Helper__IS_UPPER7(char ch)
 {
  return ch>='A' && ch<='Z';
 }//Helper__IS_UPPER7

 //-----------------------------------------------------------------------
 private static char Helper__UPPER7(char ch)
 {
  if(Helper__IS_LOWER7(ch))
   return (char)(ch-('a'-'A'));

  return ch;
 }//Helper__UPPER7
};//class Structure_StrHelpers

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
