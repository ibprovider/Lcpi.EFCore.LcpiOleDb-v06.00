////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.11.2020.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_CS_UTF16

static class Structure_CS_UTF16
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Structure_CS_UTF16;

 //-----------------------------------------------------------------------
 public static int GetCharCount(string s)
 {
  // [2020-10-19] Tested.

  Debug.Assert(!Object.ReferenceEquals(s,null));

  var s_Length=s.Length;

  int n=0;

  for(int i=0;;++n)
  {
   if(i==s_Length)
    return n;                               // <----- EXIT

   char ch=s[i];

   if(!Helper__IsSurrogate_High(ch))
   {
    if(!Helper__IsSurrogate_Low(ch))
    {
     ++i;

     continue;
    }//if

    //ERROR - bad UTF16 sequential

    Helper__ThrowErr__BadSequential
     ("#GCC.001",
      /*offset*/i);
   }//if

   ++i;

   if(i==s_Length)
   {
    Helper__ThrowErr__BadSequential
     ("#GCC.002",
      /*offset*/i);
   }//if

   ch=s[i];

   if(!Helper__IsSurrogate_Low(ch))
   {
    Helper__ThrowErr__BadSequential
     ("#GCC.003",
      /*offset*/i);
   }//if

   ++i;
  }//for[ever]
 }//GetCharCount

 //-----------------------------------------------------------------------
 public static int GetOffset(string  s,
                             int     initialOffset,
                             long    symbolIndex,
                             out int nChars)
 {
  // [2020-10-19] Tested.

  Debug.Assert(!Object.ReferenceEquals(s,null));
  Debug.Assert(initialOffset<=s.Length);

  Debug.Assert(symbolIndex>=0);

  nChars=0;

  var s_Length=s.Length;

  int n=0;

  var i=initialOffset;

  for(;;++n)
  {
   if(n==symbolIndex)
    break;

   if(i==s_Length)
    break;

   Debug.Assert(i<s_Length);
   Debug.Assert(i>=0);

   char ch=s[i];

   if(!Helper__IsSurrogate_High(ch))
   {
    if(!Helper__IsSurrogate_Low(ch))
    {
     ++i;

     continue;
    }//if

    //ERROR - bad UTF16 sequential

    Helper__ThrowErr__BadSequential
     ("#GO.001",
      /*offset*/i);
   }//if

   ++i;

   if(i==s_Length)
   {
    Helper__ThrowErr__BadSequential
     ("#GO.002",
      /*offset*/i);
   }//if

   Debug.Assert(i<s_Length);
   Debug.Assert(i>=0);

   ch=s[i];

   if(!Helper__IsSurrogate_Low(ch))
   {
    Helper__ThrowErr__BadSequential
     ("#GO.003",
      /*offset*/i);
   }//if

   ++i;
  }//for[ever]

  nChars=n;

  Debug.Assert(i<=s_Length);

  return i;
 }//GetOffset

 //-----------------------------------------------------------------------
 public static bool IsSingleUnicodeChar(char[] chars)
 {
  // [2020-10-19] Tested.

  Debug.Assert(!Object.ReferenceEquals(chars,null));

  var chars_Length=chars.Length;

  if(chars_Length==0)
   return false;

  Debug.Assert(chars_Length>0);

  if(!Helper__IsSurrogate_High(chars[0]))
  {
   if(!Helper__IsSurrogate_Low(chars[0]))
   {
    if(chars_Length==1)
     return true;

    Debug.Assert(chars_Length>1);

    return false;
   }//if

   Debug.Assert(Helper__IsSurrogate_Low(chars[0]));

   //ERROR - bad UTF16 sequential

   Helper__ThrowErr__BadSequential
    ("#ISUC.001",
      /*offset*/0);
  }//if

  Debug.Assert(Helper__IsSurrogate_High(chars[0]));

  if(chars_Length==1)
  {
   //ERROR - bad UTF16 sequential

   Helper__ThrowErr__BadSequential
    ("#ISUC.002",
      /*offset*/1);
  }//if

  Debug.Assert(chars_Length>1);

  if(!Helper__IsSurrogate_Low(chars[1]))
  {
   //ERROR - bad UTF16 sequential

   Helper__ThrowErr__BadSequential
    ("#ISUC.003",
      /*offset*/1);
  }//if

  if(chars_Length==2)
   return true;

  Debug.Assert(chars_Length>2);

  return false;
 }//IsSingleUnicodeChar

 //Helper methods --------------------------------------------------------
 private const System.UInt16 c_SurrogateHighStart = 0xD800;
 private const System.UInt16 c_SurrogateHighEnd   = 0xDBFF;
 private const System.UInt16 c_SurrogateLowStart  = 0xDC00;
 private const System.UInt16 c_SurrogateLowEnd    = 0xDFFF;

 //-----------------------------------------------------------------------
 private static bool Helper__IsSurrogate_High(char ch)
 {
  if(((System.UInt16)ch)<c_SurrogateHighStart)
   return false;

  if(c_SurrogateHighEnd<((System.UInt16)ch))
   return false;

  return true;
 }//Helper__IsSurrogate_High

 //-----------------------------------------------------------------------
 private static bool Helper__IsSurrogate_Low(char ch)
 {
  if(((System.UInt16)ch)<c_SurrogateLowStart)
   return false;

  if(c_SurrogateLowEnd<((System.UInt16)ch))
   return false;

  return true;
 }//Helper__IsSurrogate_Low

 //-----------------------------------------------------------------------
 private static void Helper__ThrowErr__BadSequential(string checkPoint,
                                                     int    offset)
 {
  ThrowError.CsUtf16Err__BadSequence
   (c_ErrSrcID,
    checkPoint,
    offset);
 }//Helper__ThrowErr__BadSequential
};//class Structure_CS_UTF16

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
