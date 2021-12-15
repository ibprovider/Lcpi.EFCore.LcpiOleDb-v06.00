////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 07.12.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3{
////////////////////////////////////////////////////////////////////////////////

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__DataFor_BinaryOperatorTranslatorProvider

sealed partial class FB_V03_0_0__DataFor_BinaryOperatorTranslatorProvider
{
 private static void Helper__Reg__Add(tagOp2Set op2Set)
 {
  Debug.Assert(!Object.ReferenceEquals(op2Set,null));

  op2Set
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Byte      ,Structure_TypeCache.TypeOf__System_String    ,sm_TD__Concat)

   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int16     ,Structure_TypeCache.TypeOf__System_Int16     ,sm_TD__Add__Int64)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int16     ,Structure_TypeCache.TypeOf__System_Int32     ,sm_TD__Add__Int64)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int16     ,Structure_TypeCache.TypeOf__System_Int64     ,sm_TD__Add__Int64)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int16     ,Structure_TypeCache.TypeOf__System_Decimal   ,sm_TD__Add__Decimal)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int16     ,Structure_TypeCache.TypeOf__System_Single    ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int16     ,Structure_TypeCache.TypeOf__System_Double    ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int16     ,Structure_TypeCache.TypeOf__System_String    ,sm_TD__Concat)

   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int32     ,Structure_TypeCache.TypeOf__System_Int16     ,sm_TD__Add__Int64)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int32     ,Structure_TypeCache.TypeOf__System_Int32     ,sm_TD__Add__Int64)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int32     ,Structure_TypeCache.TypeOf__System_Int64     ,sm_TD__Add__Int64)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int32     ,Structure_TypeCache.TypeOf__System_Decimal   ,sm_TD__Add__Decimal)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int32     ,Structure_TypeCache.TypeOf__System_Single    ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int32     ,Structure_TypeCache.TypeOf__System_Double    ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int32     ,Structure_TypeCache.TypeOf__System_String    ,sm_TD__Concat)

   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int64     ,Structure_TypeCache.TypeOf__System_Int16     ,sm_TD__Add__Int64)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int64     ,Structure_TypeCache.TypeOf__System_Int32     ,sm_TD__Add__Int64)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int64     ,Structure_TypeCache.TypeOf__System_Int64     ,sm_TD__Add__Int64)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int64     ,Structure_TypeCache.TypeOf__System_Decimal   ,sm_TD__Add__Decimal)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int64     ,Structure_TypeCache.TypeOf__System_Single    ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int64     ,Structure_TypeCache.TypeOf__System_Double    ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Int64     ,Structure_TypeCache.TypeOf__System_String    ,sm_TD__Concat)

   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Single    ,Structure_TypeCache.TypeOf__System_Int16     ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Single    ,Structure_TypeCache.TypeOf__System_Int32     ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Single    ,Structure_TypeCache.TypeOf__System_Int64     ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Single    ,Structure_TypeCache.TypeOf__System_Decimal   ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Single    ,Structure_TypeCache.TypeOf__System_Single    ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Single    ,Structure_TypeCache.TypeOf__System_Double    ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Single    ,Structure_TypeCache.TypeOf__System_String    ,sm_TD__Concat)

   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Double    ,Structure_TypeCache.TypeOf__System_Int16     ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Double    ,Structure_TypeCache.TypeOf__System_Int32     ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Double    ,Structure_TypeCache.TypeOf__System_Int64     ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Double    ,Structure_TypeCache.TypeOf__System_Decimal   ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Double    ,Structure_TypeCache.TypeOf__System_Single    ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Double    ,Structure_TypeCache.TypeOf__System_Double    ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Double    ,Structure_TypeCache.TypeOf__System_String    ,sm_TD__Concat)

   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Decimal   ,Structure_TypeCache.TypeOf__System_Int16     ,sm_TD__Add__Decimal)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Decimal   ,Structure_TypeCache.TypeOf__System_Int32     ,sm_TD__Add__Decimal)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Decimal   ,Structure_TypeCache.TypeOf__System_Int64     ,sm_TD__Add__Decimal)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Decimal   ,Structure_TypeCache.TypeOf__System_Decimal   ,sm_TD__Add__Decimal)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Decimal   ,Structure_TypeCache.TypeOf__System_Single    ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Decimal   ,Structure_TypeCache.TypeOf__System_Double    ,sm_TD__Add__Double)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Decimal   ,Structure_TypeCache.TypeOf__System_String    ,sm_TD__Concat)

   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_String    ,Structure_TypeCache.TypeOf__System_String    ,sm_TD__Concat)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_String    ,Structure_TypeCache.TypeOf__System_Char      ,sm_TD__Concat)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_String    ,Structure_TypeCache.TypeOf__System_Byte      ,sm_TD__Concat)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_String    ,Structure_TypeCache.TypeOf__System_Int16     ,sm_TD__Concat)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_String    ,Structure_TypeCache.TypeOf__System_Int32     ,sm_TD__Concat)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_String    ,Structure_TypeCache.TypeOf__System_Int64     ,sm_TD__Concat)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_String    ,Structure_TypeCache.TypeOf__System_Single    ,sm_TD__Concat)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_String    ,Structure_TypeCache.TypeOf__System_Double    ,sm_TD__Concat)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_String    ,Structure_TypeCache.TypeOf__System_Decimal   ,sm_TD__Concat)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_String    ,Structure_TypeCache.TypeOf__System_DateTime  ,sm_TD__Concat)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_String    ,Structure_TypeCache.TypeOf__System_Boolean   ,sm_TD__Concat)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_String    ,Structure_TypeCache.TypeOf__System_DateOnly  ,sm_TD__Concat)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_String    ,Structure_TypeCache.TypeOf__System_TimeOnly  ,sm_TD__Concat)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_String    ,Structure_TypeCache.TypeOf__System_Object    ,sm_TD__Concat)

   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Char      ,Structure_TypeCache.TypeOf__System_String    ,sm_TD__Concat)

   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_DateTime  ,Structure_TypeCache.TypeOf__System_TimeSpan  ,sm_TD__Add__DateTime__TimeSpan)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_DateTime  ,Structure_TypeCache.TypeOf__System_String    ,sm_TD__Concat)

   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_TimeSpan  ,Structure_TypeCache.TypeOf__System_TimeSpan  ,sm_TD__Add__TimeSpan)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_TimeSpan  ,Structure_TypeCache.TypeOf__System_TimeOnly  ,sm_TD__Add__TimeOnly) // [NEW] [2021-09-29]

   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_DateOnly  ,Structure_TypeCache.TypeOf__System_String    ,sm_TD__Concat)

   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_TimeOnly  ,Structure_TypeCache.TypeOf__System_TimeSpan  ,sm_TD__Add__TimeOnly)
   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_TimeOnly  ,Structure_TypeCache.TypeOf__System_String    ,sm_TD__Concat)

   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Boolean   ,Structure_TypeCache.TypeOf__System_String    ,sm_TD__Concat)

   .Add(LcpiOleDb__ExpressionType.Add          ,Structure_TypeCache.TypeOf__System_Object    ,Structure_TypeCache.TypeOf__System_String    ,sm_TD__Concat)

  /*END*/
  ;
 }//Helper__Reg__Add
};//class FB_V03_0_0__DataFor_BinaryOperatorTranslatorProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3
