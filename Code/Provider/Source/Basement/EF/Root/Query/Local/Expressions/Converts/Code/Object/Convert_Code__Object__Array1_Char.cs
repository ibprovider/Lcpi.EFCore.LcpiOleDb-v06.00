////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 16.09.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE
 =System.Object;

using T_TARGET_E
 =System.Char;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__Object__Array1_Char

static class Convert_Code__Object__Array1_Char
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Cvt_Code__Object__Array1_Char;

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__Object__Array1_Char)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_TARGET_E[] Exec(Core.Core_ValueCvtCtx cvtCtx,
                                  T_SOURCE              v)
 {
  Debug.Assert(!Object.ReferenceEquals(cvtCtx,null));

  const string c_bugcheck_src
   ="Convert_Code__Object__Array1_Char::Exec(cvtCtx,Object)";

  if(Object.ReferenceEquals(v,null))
   return null;

  var sourceType_u
   =v.GetType().Extension__SwitchToUnderlying();

  Debug.Assert(!Object.ReferenceEquals(sourceType_u,null));

  var cvt
   =cvtCtx.GetValueCvt
     (sourceType_u,
      typeof(T_TARGET_E[]));

  if(Object.ReferenceEquals(cvt,null))
  {
   ThrowError.UnsupportedDataTypesConversion
    (c_ErrSrcID,
     sourceType_u,
     typeof(T_TARGET_E[]));
  }//if

  Debug.Assert(!Object.ReferenceEquals(cvt,null));

  var cvt2
   =Check.BugCheck_Value_NotNullAndInstanceOf<Core.Core_ValueCvt<T_SOURCE,T_TARGET_E[]>,Core.Core_ValueCvt>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(cvt),
      cvt);

  Debug.Assert(!Object.ReferenceEquals(cvt2,null));

  T_TARGET_E[] resultValue;

  cvt2.Exec(cvtCtx,v,out resultValue); //throw

  return resultValue;
 }//Exec
};//class Convert_Code__Object__Array1_Char

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code
