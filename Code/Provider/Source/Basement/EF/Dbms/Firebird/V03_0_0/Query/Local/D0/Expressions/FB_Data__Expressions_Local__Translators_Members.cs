////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 06.10.2018.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions{
////////////////////////////////////////////////////////////////////////////////
//class FB_Data__Expressions_Local__Translators_Members

static class FB_Data__Expressions_Local__Translators_Members
{
 public static readonly Root.Query.Local.LcpiOleDb__LocalEval_MemberTranslators
  Data
   =new Root.Query.Local.LcpiOleDb__LocalEval_MemberTranslators()

     /*EF*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__EF__std__Functions.Instance)

     /*String*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__String__std__Length.Instance)

     /*DateTime*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__DateTime__std__Date.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__DateTime__std__Year.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__DateTime__std__Month.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__DateTime__std__Day.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__DateTime__std__Hour.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__DateTime__std__Minute.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__DateTime__std__Second.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__DateTime__std__Millisecond.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__DateTime__std__DayOfYear.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__DateTime__std__DayOfWeek.Instance)

     /*TimeSpan*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__TimeSpan__std__Hours.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__TimeSpan__std__Minutes.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__TimeSpan__std__Seconds.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__TimeSpan__std__Milliseconds.Instance)

     /*DateOnly*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__DateOnly__std__Year.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__DateOnly__std__Month.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__DateOnly__std__Day.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__DateOnly__std__DayOfWeek.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__DateOnly__std__DayOfYear.Instance)

     /*TimeOnly*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__TimeOnly__std__Hour.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__TimeOnly__std__Minute.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__TimeOnly__std__Second.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__TimeOnly__std__Millisecond.Instance)

     /*NullableBoolean*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableBoolean__std__HasValue.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableBoolean__std__Value.Instance)

     /*NullableDateTime*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateTime__std__HasValue.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateTime__std__Value.Instance)

     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateTime__vrt__Date.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateTime__vrt__Year.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateTime__vrt__Month.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateTime__vrt__Day.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateTime__vrt__DayOfYear.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateTime__vrt__DayOfWeek.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateTime__vrt__Hour.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateTime__vrt__Minute.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateTime__vrt__Second.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateTime__vrt__Millisecond.Instance)

     /*NullableTimeSpan*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableTimeSpan__std__HasValue.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableTimeSpan__std__Value.Instance)

     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableTimeSpan__vrt__Hours.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableTimeSpan__vrt__Minutes.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableTimeSpan__vrt__Seconds.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableTimeSpan__vrt__Milliseconds.Instance)

     /*NullableTimeOnly*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableTimeOnly__std__HasValue.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableTimeOnly__std__Value.Instance)

     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableTimeOnly__vrt__Hour.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableTimeOnly__vrt__Minute.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableTimeOnly__vrt__Second.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableTimeOnly__vrt__Millisecond.Instance)

     /*NullableDateOnly*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateOnly__std__HasValue.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateOnly__std__Value.Instance)

     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateOnly__vrt__Year.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateOnly__vrt__Month.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateOnly__vrt__Day.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateOnly__vrt__DayOfWeek.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDateOnly__vrt__DayOfYear.Instance)

     /*NullableInt16*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableInt16__std__HasValue.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableInt16__std__Value.Instance)

     /*NullableInt32*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableInt32__std__HasValue.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableInt32__std__Value.Instance)

     /*NullableInt64*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableInt64__std__HasValue.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableInt64__std__Value.Instance)

     /*NullableDecimal*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDecimal__std__HasValue.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDecimal__std__Value.Instance)

     /*NullableSingle*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableSingle__std__HasValue.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableSingle__std__Value.Instance)

     /*NullableDouble*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDouble__std__HasValue.Instance)
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__NullableDouble__std__Value.Instance)

     /*Byte[]*/
     .Add(Root.Query.Local.Expressions.Methods.Translators.ETranslator__Array_Byte__std__LongLength.Instance)

     /*END*/
     ;
};//class FB_Data__Expressions_Local__Translators_Members

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions
