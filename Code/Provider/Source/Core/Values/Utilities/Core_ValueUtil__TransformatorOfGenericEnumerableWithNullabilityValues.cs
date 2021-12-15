////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 02.09.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Utilities{
////////////////////////////////////////////////////////////////////////////////
//class Core_ValueUtil__TransformatorOfGenericEnumerableWithNullabilityValues

static class Core_ValueUtil__TransformatorOfGenericEnumerableWithNullabilityValues<T_SOURCE_VALUE,T_TARGET_VALUE>
 where T_SOURCE_VALUE: struct
 where T_TARGET_VALUE: struct
{
 public static IEnumerable<System.Nullable<T_TARGET_VALUE>> Exec(IEnumerable<System.Nullable<T_SOURCE_VALUE>> sourceList)
 {
  if(Object.ReferenceEquals(sourceList,null))
   return null;

  var resultList
   =new List<System.Nullable<T_TARGET_VALUE>>();

  foreach(var sourceElement in sourceList)
  {
   if(!sourceElement.HasValue)
   {
    resultList.Add(null);
   }
   else
   {
    var targetElement_obj
     =System.Convert.ChangeType
       (sourceElement,
        typeof(T_TARGET_VALUE));

    resultList.Add((T_TARGET_VALUE)targetElement_obj);
   }//else
  }//for i

  return resultList;
 }//Exec
};//class Core_ValueUtil__TransformatorOfGenericEnumerableWithNullabilityValues

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Utilities
