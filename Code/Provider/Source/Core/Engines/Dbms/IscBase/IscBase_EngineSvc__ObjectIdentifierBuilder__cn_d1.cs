////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines.
//                                      IBProvider and Contributors. 02.09.2018.
using System;
using System.Diagnostics;

using com_lib=lcpi.lib.com;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.IscBase{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1

sealed class IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1
 :EngineSvc__ObjectIdentifierBuilder
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1;

 //constructor -----------------------------------------------------------
 private IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1()
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
  Helper__Validate(unquotedIdentifier); //throw

  return unquotedIdentifier;
 }//QuoteIdentifier

 //-----------------------------------------------------------------------
 public void QuoteIdentifier(System.Text.StringBuilder builder,
                             string                    unquotedIdentifier)
 {
  // [2020-10-15] Tested.

  Debug.Assert(!Object.ReferenceEquals(builder,null));
  Debug.Assert(!Object.ReferenceEquals(unquotedIdentifier,null));
  //Debug.Assert(unquotedIdentifier.Length>0);

  //----------------------------------------
  Helper__Validate(unquotedIdentifier); //throw

  builder.Append(unquotedIdentifier);
 }//QuoteIdentifier

 //Helper methods --------------------------------------------------------
 private static void Helper__Validate(string unquotedIdentifier)
 {
  // [2020-10-15] Tested.

  Debug.Assert(!Object.ReferenceEquals(unquotedIdentifier,null));

  if(unquotedIdentifier.Length==0)
  {
   ThrowError.EmptyObjectName
    (c_ErrSrcID);
  }//if

  Debug.Assert(unquotedIdentifier.Length>0);

  if(!Structure_ADP.IsValidSymbolOfUnquotedObjectName_1(unquotedIdentifier[0]))
  {
   ThrowError.BadSymbolInUnquotedObjectName
     (c_ErrSrcID,
      unquotedIdentifier,
      0);
  }//if

  for(int i=1;i!=unquotedIdentifier.Length;++i)
  {
   char ch=unquotedIdentifier[i];

   if(!Structure_ADP.IsValidSymbolOfUnquotedObjectName_2(ch))
   {
    ThrowError.BadSymbolInUnquotedObjectName
     (c_ErrSrcID,
      unquotedIdentifier,
      i);
   }//if
  }//for i
 }//Helper__Validate

 //private data ----------------------------------------------------------
 /// <summary>
 ///  Single instance of class.
 /// </summary>
 private static readonly EngineSvc__ObjectIdentifierBuilder
  sm_Instance=new IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1();
};//class IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.IscBase
