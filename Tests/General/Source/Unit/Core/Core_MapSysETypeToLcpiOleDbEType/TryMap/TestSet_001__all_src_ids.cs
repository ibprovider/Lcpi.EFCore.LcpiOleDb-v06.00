////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 28.12.2020.
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Collections.Generic;

using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Core_MapSysETypeToLcpiOleDbEType.TryMap{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__all_src_ids

public static class TestSet_001__all_src_ids
{
 [Test]
 public static void Test_0000()
 {
  foreach (var x in sm_Items)
  {
   xEFCore.LcpiOleDb__ExpressionType toEType;

   Console.WriteLine("Process {0} ...",x.Key);

   Assert.IsTrue
    (xEFCore.Core.Core_MapSysETypeToLcpiOleDbEType.TryMap
      (x.Key,
       out toEType));

   Assert.AreEqual
    (x.Value,
     toEType);
  }//for
 }//Test_0000

 //private types ---------------------------------------------------------
 private sealed class tagItems:Dictionary<ExpressionType,xEFCore.LcpiOleDb__ExpressionType>
 {
  public new tagItems Add(ExpressionType                    fromEType,
                          xEFCore.LcpiOleDb__ExpressionType toEType)
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
     .Add(ExpressionType.Add               ,xEFCore.LcpiOleDb__ExpressionType.Add)
     .Add(ExpressionType.Subtract          ,xEFCore.LcpiOleDb__ExpressionType.Subtract)
     .Add(ExpressionType.Multiply          ,xEFCore.LcpiOleDb__ExpressionType.Multiply)
     .Add(ExpressionType.Divide            ,xEFCore.LcpiOleDb__ExpressionType.Divide)
     .Add(ExpressionType.Equal             ,xEFCore.LcpiOleDb__ExpressionType.Equal)
     .Add(ExpressionType.NotEqual          ,xEFCore.LcpiOleDb__ExpressionType.NotEqual)
     .Add(ExpressionType.ExclusiveOr       ,xEFCore.LcpiOleDb__ExpressionType.ExclusiveOr)
     .Add(ExpressionType.And               ,xEFCore.LcpiOleDb__ExpressionType.And)
     .Add(ExpressionType.Or                ,xEFCore.LcpiOleDb__ExpressionType.Or)
     .Add(ExpressionType.Modulo            ,xEFCore.LcpiOleDb__ExpressionType.Modulo)
     .Add(ExpressionType.AndAlso           ,xEFCore.LcpiOleDb__ExpressionType.AndAlso)
     .Add(ExpressionType.OrElse            ,xEFCore.LcpiOleDb__ExpressionType.OrElse)
     .Add(ExpressionType.LeftShift         ,xEFCore.LcpiOleDb__ExpressionType.LeftShift)
     .Add(ExpressionType.RightShift        ,xEFCore.LcpiOleDb__ExpressionType.RightShift)
     .Add(ExpressionType.LessThan          ,xEFCore.LcpiOleDb__ExpressionType.LessThan)
     .Add(ExpressionType.LessThanOrEqual   ,xEFCore.LcpiOleDb__ExpressionType.LessThanOrEqual)
     .Add(ExpressionType.GreaterThan       ,xEFCore.LcpiOleDb__ExpressionType.GreaterThan)
     .Add(ExpressionType.GreaterThanOrEqual,xEFCore.LcpiOleDb__ExpressionType.GreaterThanOrEqual)
     .Add(ExpressionType.ArrayLength       ,xEFCore.LcpiOleDb__ExpressionType.ArrayLength)
     .Add(ExpressionType.ArrayIndex        ,xEFCore.LcpiOleDb__ExpressionType.ArrayIndex)

     /*END*/
     ;
};//class TestSet_001__all_src_ids

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Core_MapSysETypeToLcpiOleDbEType.TryMap
