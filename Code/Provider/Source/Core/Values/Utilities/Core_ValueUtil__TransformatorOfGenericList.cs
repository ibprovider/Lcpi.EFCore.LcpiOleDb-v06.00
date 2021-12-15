////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 17.06.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Utilities{
////////////////////////////////////////////////////////////////////////////////
//class Core_ValueUtil__TransformatorOfGenericList

static class Core_ValueUtil__TransformatorOfGenericList<T_SOURCE_VALUE,T_TARGET_VALUE>
 where T_SOURCE_VALUE: struct
 where T_TARGET_VALUE: struct
{
 public static List<T_TARGET_VALUE> Exec(List<T_SOURCE_VALUE> sourceList)
 {
  if(Object.ReferenceEquals(sourceList,null))
   return null;

  var resultList
   =new List<T_TARGET_VALUE>(sourceList.Count);

  for(int i=0,_c=sourceList.Count;i!=_c;++i)
  {
   var targetElement_obj
    =System.Convert.ChangeType(sourceList[i],typeof(T_TARGET_VALUE));

   resultList.Add((T_TARGET_VALUE)targetElement_obj);
  }//for i

  return resultList;
 }//Exec
};//class Core_ValueUtil__TransformatorOfGenericList

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Values.Utilities
