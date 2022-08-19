////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.08.2022.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE
 =System.Object;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__Object__NULLABLE_VALUE

static class Convert_Code__Object__NULLABLE_VALUE<T_TARGET_V>
 where T_TARGET_V:struct
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Cvt_Code__Object__NULLABLE_VALUE;

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__Object__NULLABLE_VALUE<T_TARGET_V>)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static System.Nullable<T_TARGET_V> Exec(Core.Core_ValueCvtCtx cvtCtx,
                                                 T_SOURCE              v)
 {
  Debug.Assert(!Object.ReferenceEquals(cvtCtx,null));

  const string c_bugcheck_src
   ="Convert_Code__Object__NULLABLE_VALUE::Exec(cvtCtx,v)";

  if(Object.ReferenceEquals(v,null))
   return null;

  var sourceType_u
   =v.GetType().Extension__SwitchToUnderlying();

  Debug.Assert(!Object.ReferenceEquals(sourceType_u,null));

  var cvt
   =cvtCtx.GetValueCvt
     (sourceType_u,
      typeof(System.Nullable<T_TARGET_V>));

  if(Object.ReferenceEquals(cvt,null))
  {
   ThrowError.UnsupportedDataTypesConversion
    (c_ErrSrcID,
     sourceType_u,
     typeof(System.Nullable<T_TARGET_V>));
  }//if

  Debug.Assert(!Object.ReferenceEquals(cvt,null));

  var cvt2
   =Check.BugCheck_Value_NotNullAndInstanceOf<Core.Core_ValueCvt<T_SOURCE,System.Nullable<T_TARGET_V>>,Core.Core_ValueCvt>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(cvt),
      cvt);

  Debug.Assert(!Object.ReferenceEquals(cvt2,null));

  System.Nullable<T_TARGET_V> resultValue;

  cvt2.Exec(cvtCtx,v,out resultValue); //throw

  return resultValue;
 }//Exec
};//class Convert_Code__Object__NULLABLE_VALUE

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code
