////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 30.04.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__UnaryOperatorTranslatorKey

sealed class FB_Common__UnaryOperatorTranslatorKey
{
 public readonly LcpiOleDb__ExpressionType OperatorType;

 //-------------------------------------------------------------
 public FB_Common__UnaryOperatorTranslatorKey(LcpiOleDb__ExpressionType operatorType)
 {
  this.OperatorType=operatorType;
 }//FB_Common__UnaryOperatorTranslatorKey
};//struct FB_Common__UnaryOperatorTranslatorKey

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql
