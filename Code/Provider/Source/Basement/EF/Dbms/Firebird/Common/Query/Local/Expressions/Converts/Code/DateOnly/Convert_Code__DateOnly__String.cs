////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.07.2021.
using System;
using System.Reflection;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE
 =System.DateOnly;

using T_TARGET
 =System.String;

////////////////////////////////////////////////////////////////////////////////

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using FB_CVT_CODE
 =Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__DateOnly__String

sealed class Convert_Code__DateOnly__String
 :Core.Core_ValueCvt<T_SOURCE      ,T_TARGET>
 ,Core.Core_ValueCvt<System.Object ,T_TARGET>
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__DateOnly__String)
     .Extension__BindToTypeMethod
       (nameof(Exec),
        /*result*/Structure_TypeCache.TypeOf__System_String,
        new System.Type[]{typeof(T_SOURCE)},
        BindingFlags.Static|BindingFlags.NonPublic);

 //-----------------------------------------------------------------------
 public static readonly Convert_Code__DateOnly__String
  Instance
   =new Convert_Code__DateOnly__String();

 //-----------------------------------------------------------------------
 private Convert_Code__DateOnly__String()
 {
 }//Convert_Code__DateOnly__String

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
  return FB_CVT_CODE.Convert_Code__TYPE_DATE__STRING.Exec(v);
 }//Exec
};//class Convert_Code__DateOnly__String

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Local.Expressions.Converts.Code
