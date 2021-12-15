////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.11.2020.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE
 =System.Byte;

using T_TARGET
 =System.Nullable<System.Double>;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__Byte__NullableDouble

sealed class Convert_Code__Byte__NullableDouble
 :Core.Core_ValueCvt<T_SOURCE      ,T_TARGET>
 ,Core.Core_ValueCvt<System.Object ,T_TARGET>
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__Byte__NullableDouble)
     .Extension__BindToTypeMethod
       (nameof(Exec),
        typeof(T_TARGET),
        new System.Type[]{typeof(T_SOURCE)},
        BindingFlags.Static|BindingFlags.NonPublic);

 //-----------------------------------------------------------------------
 public static readonly Convert_Code__Byte__NullableDouble
  Instance
   =new Convert_Code__Byte__NullableDouble();

 //-----------------------------------------------------------------------
 private Convert_Code__Byte__NullableDouble()
 {
 }//Convert_Code__Byte__NullableDouble

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
  return MasterCode.Convert_MasterCode__Byte__Double.Exec
          (v);
 }//Exec - v
};//class Convert_Code__Byte__NullableDouble

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code
