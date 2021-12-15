////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 09.12.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////

using T_ARG0    = System.Object;
using T_RESULT  = System.String;

////////////////////////////////////////////////////////////////////////////////
//class Method_Code__Object__ToString

static class Method_Code__Object__ToString
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__Object__ToString)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec(Core.Core_OperationCtx opCtx,
                              T_ARG0                 obj)
 {
  //--------------------------
  Core.Core_ValueCvtCtx
   cvtCtx
    =Core.Core_SvcUtils.QuerySvc<Core.Core_ValueCvtCtx>
      (opCtx,
       Core.Core_SvcID.Core_ValueCvtCtx);

  Debug.Assert(!Object.ReferenceEquals(cvtCtx,null));

  //--------------------------
  var r
   =MasterCode.Method_MasterCode__Object__ToString.Exec
     (cvtCtx,
      obj);

  return r;
 }//Exec
};//class Method_Code__Object__ToString

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code
