////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.01.2021.
using System;
using System.Reflection;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D3.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////

using FB_CVT_CODE
 =Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code;

////////////////////////////////////////////////////////////////////////////////
//using

using T_SOURCE
 =System.DateTime;

using T_TARGET
 =System.String;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__DateTime__String

sealed class Convert_Code__DateTime__String
 :Core.Core_ValueCvt<System.DateTime,T_TARGET>
 ,Core.Core_ValueCvt<System.Object  ,T_TARGET>
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__DateTime__String)
     .Extension__BindToTypeMethod
       (nameof(Exec),
        /*result*/typeof(T_TARGET),
        new System.Type[]{typeof(T_SOURCE)},
        BindingFlags.Static|BindingFlags.NonPublic);

 //-----------------------------------------------------------------------
 public static readonly Convert_Code__DateTime__String
  Instance
   =new Convert_Code__DateTime__String();

 //-----------------------------------------------------------------------
 private Convert_Code__DateTime__String()
 {
 }//Convert_Code__DateTime__String

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

  if(Object.ReferenceEquals(sourceValue,null))
  {
   targetValue=null;

   return;
  }//if

  Debug.Assert(sourceValue.GetType()==typeof(T_SOURCE));

  var sourceValue_t=(T_SOURCE)sourceValue;

  targetValue=Exec(sourceValue_t);
 }//Exec

 //-----------------------------------------------------------------------
 private static T_TARGET Exec(T_SOURCE v)
 {
  return FB_CVT_CODE.Convert_Code__TIMESTAMP__STRING___D3.Exec(v);
 }//Exec
};//class Convert_Code__DateTime__String

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D3.Expressions.Converts.Code
