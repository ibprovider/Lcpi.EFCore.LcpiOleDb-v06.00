////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 20.08.2022.
using NUnit.Framework;
using System.Linq.Expressions;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP{
////////////////////////////////////////////////////////////////////////////////
//class Structure_ExpressionUtils

public static class Structure_ExpressionUtils
{
 [Test]
 public static void Test_00()
 {
  var e1=Expression.Constant(1);

  var r=xEFCore.Structure.Structure_ExpressionUtils.RemoveConvertToObject(e1);

  Assert.AreSame
   (e1,
    r);
 }//Test_00

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01()
 {
  var e1=Expression.Constant(1);
  var e2=Expression.Convert(e1,typeof(long));

  var r=xEFCore.Structure.Structure_ExpressionUtils.RemoveConvertToObject(e2);

  Assert.AreSame
   (e2,
    r);
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02()
 {
  var e1=Expression.Constant(1);
  var e2=Expression.Convert(e1,typeof(object));

  var r=xEFCore.Structure.Structure_ExpressionUtils.RemoveConvertToObject(e2);

  Assert.AreSame
   (e1,
    r);
 }//Test_02

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03()
 {
  var e1=Expression.Constant(1);
  var e2=Expression.Convert(e1,typeof(object));
  var e3=Expression.Convert(e2,typeof(object));

  var r=xEFCore.Structure.Structure_ExpressionUtils.RemoveConvertToObject(e3);

  Assert.AreSame
   (e1,
    r);
 }//Test_03
};//class Structure_ExpressionUtils

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP
