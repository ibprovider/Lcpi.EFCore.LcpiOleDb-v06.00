////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 10.12.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1
 =System.Object;

using T_ARG2
 =System.Object;

using T_RESULT
 =System.String;

////////////////////////////////////////////////////////////////////////////////
//class Op2_Code__Concat___Object__Object

static class Op2_Code__Concat___Object__Object
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Op2_Code__Concat___Object__Object)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_RESULT Exec(Core.Core_OperationCtx opCtx,
                              T_ARG1                 arg0,
                              T_ARG2                 arg1)
 {
  Debug.Assert(!Object.ReferenceEquals(opCtx,null));

  Debug.Assert(!Object.ReferenceEquals(string.Concat((T_ARG1)null ,(T_ARG2)null),null));
  Debug.Assert(!Object.ReferenceEquals(string.Concat((T_ARG1)""   ,(T_ARG2)null),null));
  Debug.Assert(!Object.ReferenceEquals(string.Concat((T_ARG1)null ,(T_ARG2)""  ),null));

  //--------------------------
  Core.Core_ValueCvtCtx
   cvtCtx
    =Core.Core_SvcUtils.QuerySvc<Core.Core_ValueCvtCtx>
      (opCtx,
       Core.Core_SvcID.Core_ValueCvtCtx);

  Debug.Assert(!Object.ReferenceEquals(cvtCtx,null));

  //--------------------------
  string s1
   =Methods.MasterCode.Method_MasterCode__Object__ToString.Exec
     (cvtCtx,
      arg0);

  string s2
   =Methods.MasterCode.Method_MasterCode__Object__ToString.Exec
     (cvtCtx,
      arg1);

  var r=string.Concat(s1,s2);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Exec
};//class Op2_Code__Concat___Object__Object

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Code
