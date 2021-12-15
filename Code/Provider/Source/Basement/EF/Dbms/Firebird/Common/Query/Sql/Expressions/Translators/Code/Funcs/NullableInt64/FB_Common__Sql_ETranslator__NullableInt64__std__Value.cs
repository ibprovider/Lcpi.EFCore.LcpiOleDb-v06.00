////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.11.2020.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MemberIdCache
 =Structure.Structure_MemberIdCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__NullableInt64__std__Value

static class FB_Common__Sql_ETranslator__NullableInt64__std__Value
{
 //Special variant for connection with 1 dialect
 public static readonly FB_Common__Sql_ETranslator_Member.tagDescr
  Instance_d1
   =new FB_Common__Sql_ETranslator_Member.tagDescr
     (Structure_MemberIdCache.MemberIdOf__NullableInt64__std__Value,
      new Internal.FB_Common__Sql_ETranslator__Nullable__std__Value
       (FB_Common__TypeMappingCache.TypeMapping__INT32));

 public static readonly FB_Common__Sql_ETranslator_Member.tagDescr
  Instance_d3
   =new FB_Common__Sql_ETranslator_Member.tagDescr
     (Structure_MemberIdCache.MemberIdOf__NullableInt64__std__Value,
      new Internal.FB_Common__Sql_ETranslator__Nullable__std__Value
       (FB_Common__TypeMappingCache.TypeMapping__INT64));
};//class FB_Common__Sql_ETranslator__NullableInt64__std__Value

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code
