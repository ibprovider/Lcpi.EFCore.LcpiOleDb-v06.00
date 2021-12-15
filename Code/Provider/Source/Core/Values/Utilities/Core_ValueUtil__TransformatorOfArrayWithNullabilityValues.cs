////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 11.06.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Utilities{
////////////////////////////////////////////////////////////////////////////////
//class Core_ValueUtil__TransformatorOfArrayWithNullabilityValues

static class Core_ValueUtil__TransformatorOfArrayWithNullabilityValues<T_SOURCE_VALUE,T_TARGET_VALUE>
 where T_SOURCE_VALUE: struct
 where T_TARGET_VALUE: struct
{
 public static System.Nullable<T_TARGET_VALUE>[] Exec(System.Nullable<T_SOURCE_VALUE>[] sourceArray)
 {
  if(Object.ReferenceEquals(sourceArray,null))
   return null;

  var resultArray
   =new System.Nullable<T_TARGET_VALUE>[sourceArray.Length];

  for(int i=0,_c=sourceArray.Length;i!=_c;++i)
  {
   var sourceElement
    =sourceArray[i];

   if(!sourceArray[i].HasValue)
   {
    resultArray[i]=null;
   }
   else
   {
    var targetElement_obj
     =System.Convert.ChangeType(sourceElement,typeof(T_TARGET_VALUE));

    resultArray[i]=(T_TARGET_VALUE)targetElement_obj;
   }//else
  }//for i

  return resultArray;
 }//Exec
};//class Core_ValueUtil__TransformatorOfArrayWithNullabilityValues

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Utilities
