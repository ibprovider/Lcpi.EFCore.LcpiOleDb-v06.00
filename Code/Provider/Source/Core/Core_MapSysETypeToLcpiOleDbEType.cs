////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 26.12.2020.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////
//class Core_MapSysETypeToLcpiOleDbEType

static class Core_MapSysETypeToLcpiOleDbEType
{
 public static bool TryMap(ExpressionType                srcEType,
                           out LcpiOleDb__ExpressionType targetEType)
 {
  Debug.Assert(!Object.ReferenceEquals(sm_Items,null));

  if(!sm_Items.TryGetValue(srcEType,out targetEType))
   return false;

  return true;
 }//TryMap

 //private types ---------------------------------------------------------
 private sealed class tagItems:Dictionary<ExpressionType,LcpiOleDb__ExpressionType>
 {
  public new tagItems Add(ExpressionType            fromEType,
                          LcpiOleDb__ExpressionType toEType)
  {
   Debug.Assert(!this.ContainsKey(fromEType));

   base.Add(fromEType,toEType);

   return this;
  }//Add
 };//class tagItems

 //private data ----------------------------------------------------------
 private static readonly tagItems
  sm_Items
   =new tagItems()
     .Add(ExpressionType.Add               ,LcpiOleDb__ExpressionType.Add)
     .Add(ExpressionType.Subtract          ,LcpiOleDb__ExpressionType.Subtract)
     .Add(ExpressionType.Multiply          ,LcpiOleDb__ExpressionType.Multiply)
     .Add(ExpressionType.Divide            ,LcpiOleDb__ExpressionType.Divide)
     .Add(ExpressionType.Equal             ,LcpiOleDb__ExpressionType.Equal)
     .Add(ExpressionType.NotEqual          ,LcpiOleDb__ExpressionType.NotEqual)
     .Add(ExpressionType.ExclusiveOr       ,LcpiOleDb__ExpressionType.ExclusiveOr)
     .Add(ExpressionType.And               ,LcpiOleDb__ExpressionType.And)
     .Add(ExpressionType.Or                ,LcpiOleDb__ExpressionType.Or)
     .Add(ExpressionType.Modulo            ,LcpiOleDb__ExpressionType.Modulo)
     .Add(ExpressionType.AndAlso           ,LcpiOleDb__ExpressionType.AndAlso)
     .Add(ExpressionType.OrElse            ,LcpiOleDb__ExpressionType.OrElse)
     .Add(ExpressionType.LeftShift         ,LcpiOleDb__ExpressionType.LeftShift)
     .Add(ExpressionType.RightShift        ,LcpiOleDb__ExpressionType.RightShift)
     .Add(ExpressionType.LessThan          ,LcpiOleDb__ExpressionType.LessThan)
     .Add(ExpressionType.LessThanOrEqual   ,LcpiOleDb__ExpressionType.LessThanOrEqual)
     .Add(ExpressionType.GreaterThan       ,LcpiOleDb__ExpressionType.GreaterThan)
     .Add(ExpressionType.GreaterThanOrEqual,LcpiOleDb__ExpressionType.GreaterThanOrEqual)
     .Add(ExpressionType.ArrayLength       ,LcpiOleDb__ExpressionType.ArrayLength)
     .Add(ExpressionType.ArrayIndex        ,LcpiOleDb__ExpressionType.ArrayIndex)
     .Add(ExpressionType.Coalesce          ,LcpiOleDb__ExpressionType.Coalesce)
     .Add(ExpressionType.Convert           ,LcpiOleDb__ExpressionType.Convert)
     .Add(ExpressionType.ConvertChecked    ,LcpiOleDb__ExpressionType.Convert)
     .Add(ExpressionType.TypeAs            ,LcpiOleDb__ExpressionType.Convert)
     .Add(ExpressionType.Not               ,LcpiOleDb__ExpressionType.Not)
     .Add(ExpressionType.Negate            ,LcpiOleDb__ExpressionType.Negate)
     .Add(ExpressionType.NegateChecked     ,LcpiOleDb__ExpressionType.Negate)
     
     /*END*/
     ;
};//class Core_MapSysETypeToLcpiOleDbEType

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core
