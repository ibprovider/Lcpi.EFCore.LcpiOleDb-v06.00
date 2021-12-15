////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 10.11.2020.
using System;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__Multiply___Decimal__NullableDecimal

static class Op2_Code__Multiply___Decimal__NullableDecimal
{
 public static readonly System.Reflection.MethodInfo MethodInfo_V_V
  =typeof(Op2_Code__Multiply___Decimal__NullableDecimal)
    .GetTypeInfo()
    .GetDeclaredMethod(nameof(Exec_V_V));

 //-----------------------------------------------------------------------
 private static Nullable<Decimal> Exec_V_V(Decimal a,Nullable<Decimal> b)
 {
  if(!b.HasValue)
   return null;

  return MasterCode.Op2_MasterCode__Multiply___Decimal__Decimal.Exec
          (a,
           b.Value);
 }//Exec_V_V
};//class Op2_Code__Multiply___Decimal__NullableDecimal

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code
