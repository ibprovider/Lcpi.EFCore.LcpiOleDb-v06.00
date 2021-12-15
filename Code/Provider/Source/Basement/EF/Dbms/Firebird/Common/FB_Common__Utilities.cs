////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.09.2018.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common{
////////////////////////////////////////////////////////////////////////////////

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Utilities

static class FB_Common__Utilities
{
 public static string TextToSqlLiteral(char charValue)
 {
  // [2020-10-18] Tested.

  if(charValue>='\0' && charValue<' ')
  {
   byte b=(byte)charValue;

   var stringBuilder=new System.Text.StringBuilder(5);

   stringBuilder.Append("_utf8 x'");

   Helper__AppendByteAsHEX
    (stringBuilder,
     b);

   stringBuilder.Append("'");

   return stringBuilder.ToString();
  }//if

  if(charValue=='\'')
  {
   return "_utf8 ''''";
  }//if

  {
   var stringBuilder=new System.Text.StringBuilder(3);

   stringBuilder.Append("_utf8 '");
   stringBuilder.Append(charValue);
   stringBuilder.Append("'");

   return stringBuilder.ToString();
  }//local
 }//TextToSqlLiteral

 //-----------------------------------------------------------------------
 public static string TextToSqlLiteral(string stringValue)
 {
  // [2020-10-18] Tested.

  Debug.Assert(!Object.ReferenceEquals(stringValue,null));

  var stringBuilder=new System.Text.StringBuilder();

  TextToSqlLiteral_Mode mode=TextToSqlLiteral_Mode.none;

  foreach(var ch in stringValue)
  {
   if(ch>='\0' && ch<' ')
   {
    Helper__TextToSqlLiteral__AddCode
     (stringBuilder,
      ref mode,
      (byte)ch);
   }
   else
   if(ch=='\'')
   {
    Helper__TextToSqlLiteral__AddStr
     (stringBuilder,
      ref mode,
      "''");
   }
   else
   {
    Helper__TextToSqlLiteral__AddChar
     (stringBuilder,
      ref mode,
      ch);
   }//else
  }//foreach ch

  switch(mode)
  {
   case TextToSqlLiteral_Mode.none:
    stringBuilder.Append("_utf8 ''");
    break;

   case TextToSqlLiteral_Mode.text:
   case TextToSqlLiteral_Mode.code:
    stringBuilder.Append("'");
    break;

   default:
    Debug.Assert(false);
    break;
  }//switch mode

  return stringBuilder.ToString();
 }//TextToSqlLiteral

 //-----------------------------------------------------------------------
 public static string TextToSqlLiteral(char[] charsValue)
 {
  // [2020-10-18] Tested.

  Debug.Assert(!Object.ReferenceEquals(charsValue,null));

  var stringBuilder=new System.Text.StringBuilder();

  TextToSqlLiteral_Mode mode=TextToSqlLiteral_Mode.none;

  foreach(var ch in charsValue)
  {
   if(ch>='\0' && ch<' ')
   {
    Helper__TextToSqlLiteral__AddCode
     (stringBuilder,
      ref mode,
      (byte)ch);
   }
   else
   if(ch=='\'')
   {
    Helper__TextToSqlLiteral__AddStr
     (stringBuilder,
      ref mode,
      "''");
   }
   else
   {
    Helper__TextToSqlLiteral__AddChar
     (stringBuilder,
      ref mode,
      ch);
   }//else
  }//foreach ch

  switch(mode)
  {
   case TextToSqlLiteral_Mode.none:
    stringBuilder.Append("_utf8 ''");
    break;

   case TextToSqlLiteral_Mode.text:
   case TextToSqlLiteral_Mode.code:
    stringBuilder.Append("'");
    break;

   default:
    Debug.Assert(false);
    break;
  }//switch mode

  return stringBuilder.ToString();
 }//TextToSqlLiteral

 //-----------------------------------------------------------------------
 public static string BytesToSqlLiteral(byte[] bytesValue)
 {
  // [2020-10-18] Tested.

  Debug.Assert(!Object.ReferenceEquals(bytesValue,null));

  var stringBuilder=new System.Text.StringBuilder(3+2*bytesValue.Length);

  stringBuilder.Append("x'");

  foreach(var b in bytesValue)
  {
   Helper__AppendByteAsHEX
    (stringBuilder,
     b);
  }//foreach b

  stringBuilder.Append("'");

  return stringBuilder.ToString();
 }//BytesToSqlLiteral

 //Helper methods --------------------------------------------------------
 private enum TextToSqlLiteral_Mode
 {
  none=0,
  text=1,
  code=2,
 };//enum TextToSqlLiteral_Mode

 //-----------------------------------------------------------------------
 private static void Helper__TextToSqlLiteral__AddChar
                       (System.Text.StringBuilder sb,
                        ref TextToSqlLiteral_Mode mode,
                        char                      ch)
 {
  // [2020-10-18] Tested.

  Debug.Assert(!Object.ReferenceEquals(sb,null));

  switch(mode)
  {
   case TextToSqlLiteral_Mode.none:
    sb.Append("_utf8 '");
    sb.Append(ch);
    break;

   case TextToSqlLiteral_Mode.text:
    sb.Append(ch);
    break;

   case TextToSqlLiteral_Mode.code:
    sb.Append("'||_utf8 '");
    sb.Append(ch);
    break;

   default:
    Debug.Assert(false);
    break;
  }//switch mode

  mode=TextToSqlLiteral_Mode.text;
 }//Helper__TextToSqlLiteral__AddChar

 //-----------------------------------------------------------------------
 private static void Helper__TextToSqlLiteral__AddStr
                       (System.Text.StringBuilder sb,
                        ref TextToSqlLiteral_Mode mode,
                        string                    str)
 {
  // [2020-10-18] Tested.

  Debug.Assert(!Object.ReferenceEquals(sb,null));

  switch(mode)
  {
   case TextToSqlLiteral_Mode.none:
    sb.Append("_utf8 '");
    sb.Append(str);
    break;

   case TextToSqlLiteral_Mode.text:
    sb.Append(str);
    break;

   case TextToSqlLiteral_Mode.code:
    sb.Append("'||_utf8 '");
    sb.Append(str);
    break;

   default:
    Debug.Assert(false);
    break;
  }//switch mode

  mode=TextToSqlLiteral_Mode.text;
 }//Helper__TextToSqlLiteral__AddStr

 //-----------------------------------------------------------------------
 private static void Helper__TextToSqlLiteral__AddCode
                       (System.Text.StringBuilder sb,
                        ref TextToSqlLiteral_Mode mode,
                        byte                      b)
 {
  // [2020-10-18] Tested.

  Debug.Assert(!Object.ReferenceEquals(sb,null));

  switch(mode)
  {
   case TextToSqlLiteral_Mode.none:
    sb.Append("_utf8 x'");
    break;

   case TextToSqlLiteral_Mode.text:
    sb.Append("'||_utf8 x'");
    break;

   case TextToSqlLiteral_Mode.code:
    break;

   default:
    Debug.Assert(false);
    break;
  }//switch mode

  Helper__AppendByteAsHEX
   (sb,
    b);

  mode=TextToSqlLiteral_Mode.code;
 }//Helper__TextToSqlLiteral__AddCode

 //-----------------------------------------------------------------------
 private static void Helper__AppendByteAsHEX(System.Text.StringBuilder sb,
                                             byte                      b)
 {
  // [2020-10-18] Tested.

  Debug.Assert(!Object.ReferenceEquals(sb,null));

  sb.Append(Structure_ADP.FourBitsToHEX((byte)((b>>4)&0x0F)));
  sb.Append(Structure_ADP.FourBitsToHEX((byte)(b&0x0F)));
 }//Helper__AppendByteAsHEX
};//class FB_Common__Utilities

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common