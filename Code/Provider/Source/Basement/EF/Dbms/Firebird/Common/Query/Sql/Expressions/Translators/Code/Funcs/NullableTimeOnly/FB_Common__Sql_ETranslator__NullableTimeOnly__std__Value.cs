////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 13.07.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MemberIdCache
 =Structure.Structure_MemberIdCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__NullableTimeOnly__std__Value

static class FB_Common__Sql_ETranslator__NullableTimeOnly__std__Value
{
 public static readonly FB_Common__Sql_ETranslator_Member.tagDescr
  Instance_d1__not_supported
   =new FB_Common__Sql_ETranslator_Member.tagDescr
    (Structure_MemberIdCache.MemberIdOf__NullableTimeOnly__std__Value,
     Internal.FB_Common__Sql_ETranslator__Dummy__MemberNotSupportedInCurrentCnDialect.Instance);

 public static readonly FB_Common__Sql_ETranslator_Member.tagDescr
  Instance_d3
   =new FB_Common__Sql_ETranslator_Member.tagDescr
         (Structure_MemberIdCache.MemberIdOf__NullableTimeOnly__std__Value,
          new Internal.FB_Common__Sql_ETranslator__Nullable__std__Value
           (FB_Common__TypeMappingCache.TypeMapping_D3__TIME__as_TimeOnly));
};//class FB_Common__Sql_ETranslator__NullableTimeOnly__std__Value

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code
