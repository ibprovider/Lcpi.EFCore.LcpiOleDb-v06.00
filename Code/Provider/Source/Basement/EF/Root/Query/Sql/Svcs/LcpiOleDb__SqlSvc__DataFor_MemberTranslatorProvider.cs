////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 13.09.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Sql.Svcs{
////////////////////////////////////////////////////////////////////////////////
//using

using LcpiOleDb__Sql_ETranslator_Member
 =Expressions.Translators.LcpiOleDb__Sql_ETranslator_Member;

using Structure_MemberId
 =Structure.Structure_MemberId;

////////////////////////////////////////////////////////////////////////////////
//interface LcpiOleDb__SqlSvc__DataFor_MemberTranslatorProvider

interface LcpiOleDb__SqlSvc__DataFor_MemberTranslatorProvider
 :Core.Core_Svc
 ,Structure.Structure_IGetDataByKey
   <Structure_MemberId,
    LcpiOleDb__Sql_ETranslator_Member>
{
};//interface LcpiOleDb__SqlSvc__DataFor_MemberTranslatorProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Sql.Svcs
