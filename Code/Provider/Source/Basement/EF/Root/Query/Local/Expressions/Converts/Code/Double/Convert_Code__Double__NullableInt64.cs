////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.01.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE
 =System.Double;

using T_TARGET
 =System.Nullable<System.Int64>;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__Double__NullableInt64

sealed class Convert_Code__Double__NullableInt64
 :Core.Core_ValueCvt<T_SOURCE      ,T_TARGET>
 ,Core.Core_ValueCvt<System.Object ,T_TARGET>
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__Double__NullableInt64)
     .Extension__BindToTypeMethod
       (nameof(Exec),
        typeof(T_TARGET),
        new System.Type[]{typeof(T_SOURCE)},
        BindingFlags.Static|BindingFlags.NonPublic);

 //-----------------------------------------------------------------------
 public static readonly Convert_Code__Double__NullableInt64
  Instance
   =new Convert_Code__Double__NullableInt64();

 //-----------------------------------------------------------------------
 private Convert_Code__Double__NullableInt64()
 {
 }//Convert_Code__Double__NullableInt64

 //interface -------------------------------------------------------------
 public void Exec(Core.Core_ValueCvtCtx cvtCtx,
                  T_SOURCE              sourceValue,
                  out T_TARGET          targetValue)
 {
  Debug.Assert(!Object.ReferenceEquals(cvtCtx,null));

  targetValue=Exec(sourceValue);
 }//Exec - cvtCtx, Source, out Target

 //-----------------------------------------------------------------------
 public void Exec(Core.Core_ValueCvtCtx cvtCtx,
                  System.Object         sourceValue,
                  out T_TARGET          targetValue)
 {
  Debug.Assert(!Object.ReferenceEquals(cvtCtx,null));

  if(Object.ReferenceEquals(sourceValue,null))
  {
   targetValue=null;

   return;
  }//if

  Debug.Assert(!Object.ReferenceEquals(sourceValue,null));

  Debug.Assert(System.Type.GetTypeCode(sourceValue.GetType())==System.Type.GetTypeCode(typeof(T_SOURCE)));

  var sourceValue_t=(T_SOURCE)sourceValue;

  targetValue=Exec(sourceValue_t);
 }//Exec - cvtCtx, Object, out Target

 //-----------------------------------------------------------------------
 private static T_TARGET Exec(T_SOURCE v)
 {
  return MasterCode.Convert_MasterCode__Double__Int64.Exec
          (v);
 }//Exec - v
};//class Convert_Code__Double__NullableInt64

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code
