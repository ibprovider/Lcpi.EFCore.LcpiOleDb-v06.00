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
 private static void Helper__Reg__LeftShift(tagOp2Set op2Set)
 {
  Debug.Assert(!Object.ReferenceEquals(op2Set,null));

  op2Set
   .Add(LcpiOleDb__ExpressionType.LeftShift    ,Structure_TypeCache.TypeOf__System_Int16   ,Structure_TypeCache.TypeOf__System_Int16   ,sm_TD__LeftShift)
   .Add(LcpiOleDb__ExpressionType.LeftShift    ,Structure_TypeCache.TypeOf__System_Int16   ,Structure_TypeCache.TypeOf__System_Int32   ,sm_TD__LeftShift)
   .Add(LcpiOleDb__ExpressionType.LeftShift    ,Structure_TypeCache.TypeOf__System_Int16   ,Structure_TypeCache.TypeOf__System_Int64   ,sm_TD__LeftShift)

   .Add(LcpiOleDb__ExpressionType.LeftShift    ,Structure_TypeCache.TypeOf__System_Int32   ,Structure_TypeCache.TypeOf__System_Int16   ,sm_TD__LeftShift)
   .Add(LcpiOleDb__ExpressionType.LeftShift    ,Structure_TypeCache.TypeOf__System_Int32   ,Structure_TypeCache.TypeOf__System_Int32   ,sm_TD__LeftShift)
   .Add(LcpiOleDb__ExpressionType.LeftShift    ,Structure_TypeCache.TypeOf__System_Int32   ,Structure_TypeCache.TypeOf__System_Int64   ,sm_TD__LeftShift)

   .Add(LcpiOleDb__ExpressionType.LeftShift    ,Structure_TypeCache.TypeOf__System_Int64   ,Structure_TypeCache.TypeOf__System_Int16   ,sm_TD__LeftShift)
   .Add(LcpiOleDb__ExpressionType.LeftShift    ,Structure_TypeCache.TypeOf__System_Int64   ,Structure_TypeCache.TypeOf__System_Int32   ,sm_TD__LeftShift)
   .Add(LcpiOleDb__ExpressionType.LeftShift    ,Structure_TypeCache.TypeOf__System_Int64   ,Structure_TypeCache.TypeOf__System_Int64   ,sm_TD__LeftShift)

  /*END*/
  ;
 }//Helper__Reg__LeftShift
};//class FB_V03_0_0__DataFor_BinaryOperatorTranslatorProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3
