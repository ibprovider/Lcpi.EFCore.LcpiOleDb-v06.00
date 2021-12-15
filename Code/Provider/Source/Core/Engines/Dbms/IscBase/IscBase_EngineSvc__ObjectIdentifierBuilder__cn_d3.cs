////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines.
//                                      IBProvider and Contributors. 24.05.2018.
using System;
using System.Diagnostics;

using com_lib=lcpi.lib.com;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.IscBase{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3

sealed class IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3
 :EngineSvc__ObjectIdentifierBuilder
{
 private const ErrSourceID
 c_ErrSrcID
   =ErrSourceID.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3;

 private const char c_chIdQuote='"';

 //constructor -----------------------------------------------------------
 private IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3()
 {
 }

 //factory ---------------------------------------------------------------
 public static EngineSvc__ObjectIdentifierBuilder Create()
 {
  // [2020-10-15] Tested.

  Debug.Assert(!Object.ReferenceEquals(sm_Instance,null));

  return sm_Instance;
 }//Create

 //EngineSvc__ObjectIdentifierBuilder interface --------------------------
 public string QuoteIdentifier(string unquotedIdentifier)
 {
  // [2020-10-15] Tested.

  Debug.Assert(!Object.ReferenceEquals(unquotedIdentifier,null));
  //Debug.Assert(unquotedIdentifier.Length>0);

  //----------------------------------------
  int cQuotes=Helper__Validate_and_CalcQuotes(unquotedIdentifier); //throw

  var builder=new System.Text.StringBuilder(2+cQuotes+unquotedIdentifier.Length);

  Helper__QuoteIdentifier
   (builder,
    unquotedIdentifier,
    cQuotes);

  //----------------------------------------
  return builder.ToString();
 }//QuoteIdentifier

 //-----------------------------------------------------------------------
 public void QuoteIdentifier(System.Text.StringBuilder builder,
                             string                    unquotedIdentifier)
 {
  // [2020-10-15] Tested.

  Debug.Assert(!Object.ReferenceEquals(unquotedIdentifier,null));
  //Debug.Assert(unquotedIdentifier.Length>0);

  //----------------------------------------
  int cQuotes=Helper__Validate_and_CalcQuotes(unquotedIdentifier); //throw

  Helper__QuoteIdentifier
   (builder,
    unquotedIdentifier,
    cQuotes);
 }//QuoteIdentifier

 //-----------------------------------------------------------------------
 private static int Helper__Validate_and_CalcQuotes(string text)
 {
  // [2020-10-15] Tested.

  Debug.Assert(!Object.ReferenceEquals(text,null));

  if(text.Length==0)
  {
   ThrowError.EmptyObjectName
    (c_ErrSrcID);
  }//if

  Debug.Assert(text.Length>0);

  //! \todo Detect and process as error the spaces at end of name

  int cQuotes=0;

  for(int i=0,_c=text.Length;i!=_c;++i)
  {
   char ch=text[i];

   switch(ch)
   {
    case c_chIdQuote:
    {
     ++cQuotes;
     break;
    }

    default:
    {
     if(!Structure_ADP.IsValidSymbolOfQuotedObjectName(ch))
     {
      ThrowError.BadSymbolInQuotedObjectName
       (c_ErrSrcID,
        text,
        i);
     }//if

     break;
    }//default
   }//switch ch
  }//for i

  return cQuotes;
 }//Helper__Validate_and_CalcQuotes

 //-----------------------------------------------------------------------
 private static void Helper__QuoteIdentifier(System.Text.StringBuilder builder,
                                             string                    identifier,
                                             int                       cQuotes)
 {
  // [2020-10-15] Tested.

  Debug.Assert(!Object.ReferenceEquals(builder,null));
  Debug.Assert(!Object.ReferenceEquals(identifier,null));
  Debug.Assert(cQuotes<=identifier.Length);

  builder.Append(c_chIdQuote);

  if(cQuotes==0)
  {
   builder.Append(identifier);
  }
  else
  {
   for(int i=0,_c=identifier.Length;i!=_c;++i)
   {
    char ch=identifier[i];

    if(ch==c_chIdQuote)
     builder.Append(ch);

    builder.Append(ch);
   }//for
  }//else

  builder.Append(c_chIdQuote);
 }//Helper__QuoteIdentifier

 //private data ----------------------------------------------------------
 /// <summary>
 ///  Single instance of class.
 /// </summary>
 private static readonly EngineSvc__ObjectIdentifierBuilder
  sm_Instance=new IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3();
};//class IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.IscBase
