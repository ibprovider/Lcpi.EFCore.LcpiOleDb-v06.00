////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.01.2021.
using System;
using System.Reflection;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_SOURCE
 =System.Single;

using T_TARGET
 =System.String;

////////////////////////////////////////////////////////////////////////////////

using FB_CVT_CODE
 =Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__Single__String

sealed class Convert_Code__Single__String
 :Core.Core_ValueCvt<T_SOURCE      ,T_TARGET>
 ,Core.Core_ValueCvt<System.Object ,T_TARGET>
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__Single__String)
     .Extension__BindToTypeMethod
       (nameof(Exec),
        /*result*/typeof(T_TARGET),
        new System.Type[]{typeof(T_SOURCE)},
        BindingFlags.Static|BindingFlags.NonPublic);

 //-----------------------------------------------------------------------
 public static readonly Convert_Code__Single__String
  Instance
   =new Convert_Code__Single__String();

 //-----------------------------------------------------------------------
 private Convert_Code__Single__String()
 {
 }//Convert_Code__Single__String

 //interface -------------------------------------------------------------
 public void Exec(Core.Core_ValueCvtCtx context,
                  T_SOURCE              sourceValue,
                  out T_TARGET          targetValue)
 {
  Debug.Assert(!Object.ReferenceEquals(context,null));

  targetValue=Exec(sourceValue);
 }//Exec

 //-----------------------------------------------------------------------
 public void Exec(Core.Core_ValueCvtCtx context,
                  System.Object         sourceValue,
                  out T_TARGET          targetValue)
 {
  Debug.Assert(!Object.ReferenceEquals(context,null));

  // [2021-07-02] Expected!
  Debug.Assert(!Object.ReferenceEquals(sourceValue,null));

  Debug.Assert(sourceValue.GetType()==typeof(T_SOURCE));

  var sourceValue_t=(T_SOURCE)sourceValue;

  targetValue=Exec(sourceValue_t);
 }//Exec

 //-----------------------------------------------------------------------
 private static T_TARGET Exec(T_SOURCE v)
 {
  return FB_CVT_CODE.Convert_Code__FLOAT__STRING.Exec(v);
 }//Exec
};//class Convert_Code__Single__String

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Local.Expressions.Converts.Code
