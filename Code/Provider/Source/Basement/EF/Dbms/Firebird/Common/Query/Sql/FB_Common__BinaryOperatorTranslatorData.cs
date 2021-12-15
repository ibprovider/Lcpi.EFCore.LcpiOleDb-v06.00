////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 23.11.2020.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql{
////////////////////////////////////////////////////////////////////////////////
//using 

using FB_Common__Sql_ETranslator_Op2
 =Common.Query.Sql.Expressions.Translators.FB_Common__Sql_ETranslator_Op2;

////////////////////////////////////////////////////////////////////////////////
//struct FB_Common__BinaryOperatorTranslatorData

sealed class FB_Common__BinaryOperatorTranslatorData
{
 public readonly FB_Common__Sql_ETranslator_Op2 Translator;

 public readonly RelationalTypeMapping SqlResultTypeMapping;

 //-------------------------------------------------------------
 public FB_Common__BinaryOperatorTranslatorData
                         (FB_Common__Sql_ETranslator_Op2 translator,
                          RelationalTypeMapping          sqlResultTypeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(translator,null));
  //Debug.Assert(!Object.ReferenceEquals(sqlResultTypeMapping,null));

  //----------------------------------------
  this.Translator=translator;

  this.SqlResultTypeMapping=sqlResultTypeMapping;
 }//FB_Common__BinaryOperatorTranslatorData
};//struct FB_Common__BinaryOperatorTranslatorData

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql
