////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.11.2020.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE
 =System.Boolean;

using T_TARGET
 =System.Nullable<System.Boolean>;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__Boolean__NullableBoolean

sealed class Convert_Code__Boolean__NullableBoolean
 :Core.Core_ValueCvt<T_SOURCE      ,T_TARGET>
 ,Core.Core_ValueCvt<System.Object ,T_TARGET>
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__Boolean__NullableBoolean)
     .Extension__BindToTypeMethod
       (nameof(Exec),
        typeof(T_TARGET),
        new System.Type[]{typeof(T_SOURCE)},
        BindingFlags.Static|BindingFlags.NonPublic);

 //-----------------------------------------------------------------------
 public static readonly Convert_Code__Boolean__NullableBoolean
  Instance
   =new Convert_Code__Boolean__NullableBoolean();

 //-----------------------------------------------------------------------
 private Convert_Code__Boolean__NullableBoolean()
 {
 }//Convert_Code__Boolean__NullableBoolean

 //interface -------------------------------------------------------------
 public void Exec(Core.Core_ValueCvtCtx cvtCtx,
                  T_SOURCE              sourceValue,
                  out T_TARGET          targetValue)
 {
  Debug.Assert(!Object.ReferenceEquals(cvtCtx,null));

  targetValue=Exec(sourceValue);
 }//Exec - cvtCtx, Boolean, out Boolean?

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

  Debug.Assert(sourceValue.GetType()==typeof(T_SOURCE));

  var sourceValue_t=(T_SOURCE)sourceValue;

  targetValue=Exec(sourceValue_t);
 }//Exec - cvtCtx, Object, out Boolean?

 //-----------------------------------------------------------------------
 private static T_TARGET Exec(T_SOURCE v)
 {
  return v;
 }//Exec - v
};//class Convert_Code__Boolean__NullableBoolean

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code
