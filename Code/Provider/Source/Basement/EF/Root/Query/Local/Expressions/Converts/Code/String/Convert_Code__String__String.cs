////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.01.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using T_SOURCE
 =System.String;

using T_TARGET
 =System.String;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__String__String

sealed class Convert_Code__String__String
 :Core.Core_ValueCvt<T_SOURCE      ,T_TARGET>
 ,Core.Core_ValueCvt<System.Object ,T_TARGET>
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__String__String)
     .Extension__BindToTypeMethod
       (nameof(Exec),
        /*result*/typeof(T_TARGET),
        new System.Type[]{typeof(T_SOURCE)},
        BindingFlags.Static|BindingFlags.NonPublic);

 //-----------------------------------------------------------------------
 public static readonly Convert_Code__String__String
  Instance
   =new Convert_Code__String__String();

 //-----------------------------------------------------------------------
 private Convert_Code__String__String()
 {
 }//Convert_Code__String__String

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

#if DEBUG
  if(!Object.ReferenceEquals(sourceValue,null))
  {
   Debug.Assert(sourceValue.GetType()==typeof(T_SOURCE));
  }//if
#endif

  targetValue=Exec((T_SOURCE)sourceValue);
 }//Exec

 //-----------------------------------------------------------------------
 private static T_TARGET Exec(T_SOURCE v)
 {
  return v;
 }//Exec
};//class Convert_Code__String__String

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Code
