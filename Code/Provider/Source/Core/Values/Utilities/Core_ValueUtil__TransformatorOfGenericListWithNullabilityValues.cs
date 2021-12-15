////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 22.06.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Utilities{
////////////////////////////////////////////////////////////////////////////////
//class Core_ValueUtil__TransformatorOfGenericListWithNullabilityValues

static class Core_ValueUtil__TransformatorOfGenericListWithNullabilityValues<T_SOURCE_VALUE,T_TARGET_VALUE>
 where T_SOURCE_VALUE: struct
 where T_TARGET_VALUE: struct
{
 public static List<System.Nullable<T_TARGET_VALUE>> Exec(List<System.Nullable<T_SOURCE_VALUE>> sourceList)
 {
  if(Object.ReferenceEquals(sourceList,null))
   return null;

  var resultList
   =new List<System.Nullable<T_TARGET_VALUE>>(sourceList.Count);

  for(int i=0,_c=sourceList.Count;i!=_c;++i)
  {
   var sourceElement
    =sourceList[i];

   if(!sourceElement.HasValue)
   {
    resultList.Add(null);
   }
   else
   {
    var targetElement_obj
     =System.Convert.ChangeType(sourceElement,typeof(T_TARGET_VALUE));

    resultList.Add((T_TARGET_VALUE)targetElement_obj);
   }//else
  }//for i

  return resultList;
 }//Exec
};//class Core_ValueUtil__TransformatorOfGenericListWithNullabilityValues

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Utilities
