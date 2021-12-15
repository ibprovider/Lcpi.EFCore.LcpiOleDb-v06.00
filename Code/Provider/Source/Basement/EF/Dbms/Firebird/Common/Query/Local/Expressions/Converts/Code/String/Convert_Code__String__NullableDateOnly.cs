////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.07.2021.
using System;
using System.Reflection;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Local.Expressions.Converts.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using FB_CVT_CODE
 =Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Code;

////////////////////////////////////////////////////////////////////////////////

using T_SOURCE
 =System.String;

using T_TARGET
 =System.Nullable<System.DateOnly>;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Code__String__NullableDateOnly

sealed class Convert_Code__String__NullableDateOnly
 :Core.Core_ValueCvt<T_SOURCE       ,T_TARGET>
 ,Core.Core_ValueCvt<System.Object  ,T_TARGET>
{
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Convert_Code__String__NullableDateOnly)
     .Extension__BindToTypeMethod
       (nameof(Exec),
        /*result*/typeof(T_TARGET),
        new System.Type[]
         {
          typeof(T_SOURCE)
         },
        BindingFlags.Static|BindingFlags.NonPublic);

 //-----------------------------------------------------------------------
 public static readonly Convert_Code__String__NullableDateOnly
  Instance
   =new Convert_Code__String__NullableDateOnly();

 //-----------------------------------------------------------------------
 private Convert_Code__String__NullableDateOnly()
 {
 }//Convert_Code__String__NullableDateOnly

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
  }
#endif //DEBUG

  var sourceValue_t=(T_SOURCE)sourceValue;

  targetValue=Exec(sourceValue_t);
 }//Exec

 //-----------------------------------------------------------------------
 private static T_TARGET Exec(T_SOURCE v)
 {
  if(Object.ReferenceEquals(v,null))
   return null;

  return FB_CVT_CODE.Convert_Code__STRING__TYPE_DATE.Exec(v);
 }//Exec
};//class Convert_Code__String__NullableDateOnly

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Local.Expressions.Converts.Code
