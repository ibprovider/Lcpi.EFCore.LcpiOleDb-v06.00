////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 30.04.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql{
////////////////////////////////////////////////////////////////////////////////
//using 

using FB_Common__Sql_ETranslator_Unary
 =Common.Query.Sql.Expressions.Translators.FB_Common__Sql_ETranslator_Unary;

////////////////////////////////////////////////////////////////////////////////
//struct FB_Common__UnaryOperatorTranslatorData

sealed class FB_Common__UnaryOperatorTranslatorData
{
 public readonly FB_Common__Sql_ETranslator_Unary Translator;

 //-------------------------------------------------------------
 public FB_Common__UnaryOperatorTranslatorData
                         (FB_Common__Sql_ETranslator_Unary translator)
 {
  Debug.Assert(!Object.ReferenceEquals(translator,null));

  //----------------------------------------
  this.Translator=translator;
 }//FB_Common__UnaryOperatorTranslatorData
};//struct FB_Common__UnaryOperatorTranslatorData

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql
