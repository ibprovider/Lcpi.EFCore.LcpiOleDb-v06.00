////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 05.09.2018.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Converters{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class Core_ValueCvt__Int64__Int32

sealed class Core_ValueCvt__Int64__Int32
 :Core_ValueCvt<object,object>
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Core_ValueCvt__Int64__Int32;

 //-----------------------------------------------------------------------
 public static readonly Core_ValueCvt__Int64__Int32
  Instance
   =new Core_ValueCvt__Int64__Int32();

 //Core_ValueCvt interface -----------------------------------------------
 public void Exec(Core_ValueCvtCtx context,
                  object           sourceValue,
                  out object       targetValue)
 {
  // [2020-10-17] Tested.

  Debug.Assert(!Object.ReferenceEquals(context,null));
  Debug.Assert(!Object.ReferenceEquals(sourceValue,null));
  Debug.Assert(sourceValue.GetType()==Structure_TypeCache.TypeOf__System_Int64);

  System.Int64 typedSourceValue=(System.Int64)sourceValue;

  if(typedSourceValue<Int32.MinValue || typedSourceValue>Int32.MaxValue)
  {
   //ERROR - can't convert Int64 value into Int32 value

   ThrowError.FailedToConvertValueBetweenTypes__overflow
    (c_ErrSrcID,
     Structure_TypeCache.TypeOf__System_Int64,
     Structure_TypeCache.TypeOf__System_Int32);

   Debug.Assert(false);
  }//if

  targetValue=(Int32)typedSourceValue;

  Debug.Assert(!Object.ReferenceEquals(targetValue,null));
  Debug.Assert(targetValue.GetType()==Structure_TypeCache.TypeOf__System_Int32);
 }//Exec
};//class Core_ValueCvt__Int64__Int32

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Converters
