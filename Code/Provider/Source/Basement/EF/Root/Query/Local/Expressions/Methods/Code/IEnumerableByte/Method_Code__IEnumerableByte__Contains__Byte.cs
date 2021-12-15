////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 15.06.2021.
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Collections.Generic.IEnumerable<System.Byte>;

using T_ARG2
 =System.Byte;

using T_RESULT
 =System.Nullable<System.Boolean>;

////////////////////////////////////////////////////////////////////////////////
//class Method_Code__IEnumerableByte__Contains__Byte

static class Method_Code__IEnumerableByte__Contains__Byte
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__IEnumerableByte__Contains__Byte)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec(Core.Core_OperationCtx opCtx,
                              T_ARG1                 collection,
                              T_ARG2                 testValue)
 {
  return MasterCode.Method_MasterCode__IEnumerable_generic__Contains.Exec
          (opCtx,
           collection,
           testValue);
 }//Exec
};//class Method_Code__IEnumerableByte__Contains__Byte

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code
