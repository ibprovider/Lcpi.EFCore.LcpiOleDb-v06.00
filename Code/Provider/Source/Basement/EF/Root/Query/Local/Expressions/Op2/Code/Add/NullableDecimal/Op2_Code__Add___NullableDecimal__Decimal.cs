////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 25.04.2019.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__Add___NullableDecimal__Decimal

static class Op2_Code__Add___NullableDecimal__Decimal
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo_V_V
   =typeof(Op2_Code__Add___NullableDecimal__Decimal)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 private static Nullable<Decimal> Exec_V_V(Nullable<Decimal> a,Decimal b)
 {
  if(!a.HasValue)
   return null;

  return MasterCode.Op2_MasterCode__Add___Decimal__Decimal.Exec
          (a.Value,
           b);
 }//Exec_V_V
};//class Op2_Code__Add___NullableDecimal__Decimal

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code
