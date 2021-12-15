////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 02.06.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MemberIdCache
 =Structure.Structure_MemberIdCache;

using FB_Common__Sql_ETranslator_Member
 =Common.Query.Sql.Expressions.Translators.FB_Common__Sql_ETranslator_Member;

using FB_Common__Sql_ETranslator__Dummy__MemberNotSupportedInCurrentCnDialect
 =Common.Query.Sql.Expressions.Translators.Internal.FB_Common__Sql_ETranslator__Dummy__MemberNotSupportedInCurrentCnDialect;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Seconds

static class FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Seconds
{
 public static readonly FB_Common__Sql_ETranslator_Member.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_Member.tagDescr
     (Structure_MemberIdCache.MemberIdOf__TimeSpan__std__Seconds,
      FB_Common__Sql_ETranslator__Dummy__MemberNotSupportedInCurrentCnDialect.Instance);
  };//class FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Seconds

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1.Expressions.Translators.Code
