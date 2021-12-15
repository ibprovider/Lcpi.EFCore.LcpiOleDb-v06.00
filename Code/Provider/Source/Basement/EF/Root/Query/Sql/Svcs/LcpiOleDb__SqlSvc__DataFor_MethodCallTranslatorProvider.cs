////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 11.09.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Sql.Svcs{
////////////////////////////////////////////////////////////////////////////////
//using

using LcpiOleDb__Sql_ETranslator_MethodCall
 =Expressions.Translators.LcpiOleDb__Sql_ETranslator_MethodCall;

using Structure_MethodId
 =Structure.Structure_MethodId;

////////////////////////////////////////////////////////////////////////////////
//interface LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider

interface LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider
 :Core.Core_Svc
 ,Structure.Structure_IGetDataByKey2
   <Structure_MethodId,
    LcpiOleDb__Sql_ETranslator_MethodCall>
{
};//interface LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Sql.Svcs
