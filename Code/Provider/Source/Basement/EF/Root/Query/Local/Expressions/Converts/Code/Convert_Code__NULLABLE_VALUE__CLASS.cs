////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.08.2022.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__NULLABLE_VALUE__CLASS

static class Convert_Code__NULLABLE_VALUE__CLASS<T_SOURCE_V,T_TARGET>
 where T_SOURCE_V:struct
 where T_TARGET  :class
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Cvt_Code__NULLABLE_VALUE__CLASS;

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__NULLABLE_VALUE__CLASS<T_SOURCE_V,T_TARGET>)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static T_TARGET Exec(Core.Core_ValueCvtCtx       cvtCtx,
                              System.Nullable<T_SOURCE_V> v)
 {
  Debug.Assert(!Object.ReferenceEquals(cvtCtx,null));

  const string c_bugcheck_src
   ="Convert_Code__NULLABLE_VALUE__CLASS::Exec(cvtCtx,v)";

  if(!v.HasValue)
   return null;

  var cvt
   =cvtCtx.GetValueCvt
     (typeof(T_SOURCE_V),
      typeof(T_TARGET));

  if(Object.ReferenceEquals(cvt,null))
  {
   ThrowError.UnsupportedDataTypesConversion
    (c_ErrSrcID,
     typeof(T_SOURCE_V),
     typeof(T_TARGET));
  }//if

  Debug.Assert(!Object.ReferenceEquals(cvt,null));

  var cvt2
   =Check.BugCheck_Value_NotNullAndInstanceOf<Core.Core_ValueCvt<T_SOURCE_V,T_TARGET>,Core.Core_ValueCvt>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(cvt),
      cvt);

  Debug.Assert(!Object.ReferenceEquals(cvt2,null));

  T_TARGET resultValue;

  cvt2.Exec(cvtCtx,v.Value,out resultValue); //throw

  return resultValue;
 }//Exec
};//class Convert_Code__NULLABLE_VALUE__CLASS

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code
