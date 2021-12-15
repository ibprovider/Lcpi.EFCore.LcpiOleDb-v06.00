////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.11.2018.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class Method_Code__DbCast__AsInteger

static class Method_Code__DbCast__AsInteger
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Query_Local_Expressions__Method_Code__DbCast__AsInteger;

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__DbCast__AsInteger)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Nullable<Int32> Exec(object sourceValue)
 {
  const string c_bugcheck_src
   ="Method_Code__DbCast__AsInteger::Exec";

  if(Object.ReferenceEquals(sourceValue,null))
   return null;

  var ctx=new DbCast.Converters.DbCast_CvtCtx_Std();

  var cvt=ctx.GetValueCvt(sourceValue.GetType(),Structure_TypeCache.TypeOf__System_Int32);

  if(Object.ReferenceEquals(cvt,null))
  {
   ThrowError.UnsupportedDataTypesConversion
    (c_ErrSrcID,
     sourceValue.GetType(),
     Structure_TypeCache.TypeOf__System_Int32);
  }//if

  var cvt_obj_to_obj
   =Check.BugCheck_Value_NotNullAndInstanceOf<Core.Core_ValueCvt<object,object>,Core.Core_ValueCvt>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(cvt),
      cvt);

  Debug.Assert(!Object.ReferenceEquals(cvt_obj_to_obj,null));

  object r;

  cvt_obj_to_obj.Exec
   (ctx,
    sourceValue,
    out r); //throw

  Debug.Assert(!Object.ReferenceEquals(r,null));

  Debug.Assert(r.GetType()==Structure_TypeCache.TypeOf__System_Int32);

  return (Int32)r;
 }//Exec
};//class Method_Code__DbCast__AsInteger

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Local.Expressions.Methods.Code
