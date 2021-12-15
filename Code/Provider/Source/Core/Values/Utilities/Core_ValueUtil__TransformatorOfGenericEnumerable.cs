////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 02.09.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Utilities{
////////////////////////////////////////////////////////////////////////////////
//class Core_ValueUtil__TransformatorOfGenericEnumerable

static class Core_ValueUtil__TransformatorOfGenericEnumerable<T_SOURCE_VALUE,T_TARGET_VALUE>
 where T_SOURCE_VALUE: struct
 where T_TARGET_VALUE: struct
{
 public static IEnumerable<T_TARGET_VALUE> Exec(IEnumerable<T_SOURCE_VALUE> sourceList)
 {
  if(Object.ReferenceEquals(sourceList,null))
   return null;

  var resultList
   =new List<T_TARGET_VALUE>();

  foreach(var sourceElement in sourceList)
  {
   var targetElement_obj
    =System.Convert.ChangeType
      (sourceElement,
       typeof(T_TARGET_VALUE));

   resultList.Add((T_TARGET_VALUE)targetElement_obj);
  }//for i

  return resultList;
 }//Exec
};//class Core_ValueUtil__TransformatorOfGenericEnumerable

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Utilities
