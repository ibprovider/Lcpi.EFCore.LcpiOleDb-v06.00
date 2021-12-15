////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 30.06.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Converters{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class Core_ValueCvt__TimeSpan__TimeOnly

sealed class Core_ValueCvt__TimeSpan__TimeOnly
 :Core_ValueCvt<object,object>
{
 public static readonly Core_ValueCvt__TimeSpan__TimeOnly
  Instance
   =new Core_ValueCvt__TimeSpan__TimeOnly();

 //Core_ValueCvt interface -----------------------------------------------
 public void Exec(Core_ValueCvtCtx context,
                  object           sourceValue,
                  out object       targetValue)
 {
  Debug.Assert(!Object.ReferenceEquals(context,null));
  Debug.Assert(!Object.ReferenceEquals(sourceValue,null));
  Debug.Assert(sourceValue.GetType()==Structure_TypeCache.TypeOf__System_TimeSpan);

  System.TimeSpan typedSourceValue=(System.TimeSpan)sourceValue;

  targetValue=System.TimeOnly.FromTimeSpan(typedSourceValue);

  Debug.Assert(!Object.ReferenceEquals(targetValue,null));
  Debug.Assert(targetValue.GetType()==Structure_TypeCache.TypeOf__System_TimeOnly);
 }//Exec
};//class Core_ValueCvt__TimeSpan__TimeOnly

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Converters
