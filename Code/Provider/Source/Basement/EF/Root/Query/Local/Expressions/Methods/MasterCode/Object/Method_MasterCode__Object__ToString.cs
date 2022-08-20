////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 05.12.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.MasterCode{
////////////////////////////////////////////////////////////////////////////////

using T_RESULT
 =System.String;

using T_ARG1
 =System.Object;

////////////////////////////////////////////////////////////////////////////////
//class Method_MasterCode__Object__ToString

static class Method_MasterCode__Object__ToString
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Method_MasterCode__Object__ToString;

 //-----------------------------------------------------------------------
 public static T_RESULT Exec(Core.Core_ValueCvtCtx cvtCtx,
                             T_ARG1                value)
 {
  Debug.Assert(!Object.ReferenceEquals(cvtCtx,null));

  //--------------------------
  const string c_bugcheck_src
   ="Method_MasterCode__Object__ToString::Exec";

  //--------------------------
  if(Object.ReferenceEquals(value,null))
   return null;

  var valueType
   =value.GetType();

  var cvt
   =cvtCtx.GetValueCvt
     (valueType,
      Structure.Structure_TypeCache.TypeOf__System_String);
 
  if(Object.ReferenceEquals(cvt,null))
  {
   ThrowError.UnsupportedDataTypesConversion
    (c_ErrSrcID,
     valueType,
     Structure.Structure_TypeCache.TypeOf__System_String);

   Debug.Assert(false);
  }//if

  var cvt_t
   =Check.BugCheck_Value_NotNullAndInstanceOf<Core.Core_ValueCvt<object,string>,Core.Core_ValueCvt>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(cvt),
      cvt);

  string result=null;

  cvt_t.Exec
   (cvtCtx,
    value,
    out result); //throw

  return result;
 }//Exec
};//class Method_MasterCode__Object__ToString

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.MasterCode
