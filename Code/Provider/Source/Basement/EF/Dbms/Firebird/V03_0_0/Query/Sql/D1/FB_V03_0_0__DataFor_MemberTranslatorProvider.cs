////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.03.2019.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1{
////////////////////////////////////////////////////////////////////////////////
//using

using LcpiOleDb__Sql_ETranslator_Member
 =Root.Query.Sql.Expressions.Translators.LcpiOleDb__Sql_ETranslator_Member;

using LcpiOleDb__SqlSvc__DataFor_MemberTranslatorProvider
 =Root.Query.Sql.Svcs.LcpiOleDb__SqlSvc__DataFor_MemberTranslatorProvider;

using Structure_MemberId
 =Structure.Structure_MemberId;

using FB_Common_SqlTranslators
 =Common.Query.Sql.Expressions.Translators;

using FB_V03_0_0__SqlTranslators__D1
 =V03_0_0.Query.Sql.D1.Expressions.Translators;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__DataFor_MemberTranslatorProvider

sealed class FB_V03_0_0__DataFor_MemberTranslatorProvider
 :LcpiOleDb__SqlSvc__DataFor_MemberTranslatorProvider
{
 public static readonly FB_V03_0_0__DataFor_MemberTranslatorProvider
  Instance
   =new FB_V03_0_0__DataFor_MemberTranslatorProvider();

 //-----------------------------------------------------------------------
 private FB_V03_0_0__DataFor_MemberTranslatorProvider()
 {
 }//FB_V03_0_0__DataFor_MemberTranslatorProvider

 //Structure_IGetDataByKey interface -------------------------------------
 public bool TryGetData(Structure_MemberId                    memberId,
                        out LcpiOleDb__Sql_ETranslator_Member translator)
 {
  Debug.Assert(!Object.ReferenceEquals(memberId,null));

  Debug.Assert(!Object.ReferenceEquals(sm_Items,null));

  if(!sm_Items.TryGetValue(memberId,out translator))
   return false;

  Debug.Assert(!Object.ReferenceEquals(translator,null));

  return true;
 }//TryGetData

 //private types ---------------------------------------------------------
 private sealed class tagItems
  :Dictionary
    <Structure_MemberId,
     LcpiOleDb__Sql_ETranslator_Member>
 {
  public tagItems Add(in FB_Common_SqlTranslators.FB_Common__Sql_ETranslator_Member.tagDescr x)
  {
   Debug.Assert(!Object.ReferenceEquals(x.MemberId,null));
   Debug.Assert(!Object.ReferenceEquals(x.Translator,null));

   Debug.Assert(!base.ContainsKey(x.MemberId));

   base.Add(x.MemberId,x.Translator);

   return this;
  }//Add
 };//class tagItems

 //private data ----------------------------------------------------------
 private static readonly tagItems
  sm_Items
   =new tagItems()

     /*String*/
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__String__std__Length.Instance)

     /*DateTime*/
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__Now__through_CURRENT_TIMESTAMP.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__Today_d1.Instance)

     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__Date.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__Year.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__Month.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__Day.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__Hour.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__Minute.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__Second.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__Millisecond.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__DayOfYear.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateTime__std__DayOfWeek.Instance)

     /*TimeSpan*/
     .Add(FB_V03_0_0__SqlTranslators__D1.Code.FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Hours.Instance)
     .Add(FB_V03_0_0__SqlTranslators__D1.Code.FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Minutes.Instance)
     .Add(FB_V03_0_0__SqlTranslators__D1.Code.FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Seconds.Instance)
     .Add(FB_V03_0_0__SqlTranslators__D1.Code.FB_V03_0_0__Sql_ETranslator__TimeSpan__std__Milliseconds.Instance)

     /*DateOnly*/
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateOnly__std__Year.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateOnly__std__Month.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateOnly__std__Day.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateOnly__std__DayOfWeek.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__DateOnly__std__DayOfYear.Instance)

     /*TimeOnly*/
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__TimeOnly__std__Hour.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__TimeOnly__std__Minute.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__TimeOnly__std__Second.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__TimeOnly__std__Millisecond.Instance)

     /*NullableInt16*/
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableInt16__std__Value.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableInt16__std__HasValue.Instance)

     /*NullableInt32*/
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableInt32__std__Value.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableInt32__std__HasValue.Instance)

     /*NullableInt64*/
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableInt64__std__Value.Instance_d1)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableInt64__std__HasValue.Instance)

     /*NullableDecimal*/
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableDecimal__std__Value.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableDecimal__std__HasValue.Instance)

     /*NullableSingle*/
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableSingle__std__Value.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableSingle__std__HasValue.Instance)

     /*NullableDouble*/
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableDouble__std__Value.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableDouble__std__HasValue.Instance)

     /*NullableDateTime*/
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableDateTime__std__Value.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableDateTime__std__HasValue.Instance)

     /*NullableTimeSpan*/
/*!*/.Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableTimeSpan__std__Value.Instance_d1)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableTimeSpan__std__HasValue.Instance)

     /*NullableTimeOnly*/
/*!*/.Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableTimeOnly__std__Value.Instance_d1__not_supported)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableTimeOnly__std__HasValue.Instance)

     /*NullableDateOnly*/
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableDateOnly__std__Value.Instance_d1__not_supported)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableDateOnly__std__HasValue.Instance)

     /*NullableBoolean*/
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableBoolean__std__Value.Instance)
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__NullableBoolean__std__HasValue.Instance)

     /*Byte[]*/
     .Add(FB_Common_SqlTranslators.Code.FB_Common__Sql_ETranslator__Array_Byte__std__LongLength.Instance)

     /*END*/
     ;
};//class FB_V03_0_0__DataFor_MemberTranslatorProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1
