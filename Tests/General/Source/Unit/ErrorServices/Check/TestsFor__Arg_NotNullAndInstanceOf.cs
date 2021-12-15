////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 14.10.2020.
using NUnit.Framework;

using structure_lib=lcpi.lib.structure;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__Arg_NotNullAndInstanceOf

public static class TestsFor__Arg_NotNullAndInstanceOf
{
 class TBase
 {
 };//class TBase

 //-----------------------------------------------------------------------
 class TObj:TBase
 {
 };//class TObj

 //-----------------------------------------------------------------------
 class TObj2:TBase
 {
 };//class TObj2

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01__ok()
 {
  TBase b=new TObj();

  TObj x
   =xEFCore.Check.Arg_NotNullAndInstanceOf<TObj,TBase>
     (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
      "y1",
      "y2",
      b);

  Assert.NotNull(x);
  Assert.AreSame(b,x);
 }//Test_01__ok

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__err__null()
 {
  try
  {
   xEFCore.Check.Arg_NotNullAndInstanceOf<TObj,TBase>
    (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
     "y1",
     "y2",
     null);
  }
  catch(structure_lib.exceptions.t_argument_null_exception e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__ArgumentNullException
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Core_ConnectionOptionsInitializer,
     "y1",
     "y2");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_02__err__null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__err__bad()
 {
  TBase b=new TObj2();

  try
  {
   xEFCore.Check.Arg_NotNullAndInstanceOf<TObj,TBase>
    (xEFCore.ErrSourceID.Core_ConnectionOptionsInitializer,
     "y1",
     "y2",
     b);
  }
  catch(structure_lib.exceptions.t_argument_exception e)
  {
   CheckErrors.PrintException_OK(e);

   CheckErrors.CheckException__BadArgumentValueType
    (e,
     CheckErrors.c_src__EFCoreDataProvider__Core_ConnectionOptionsInitializer,
     "y1",
     "y2",
     b.GetType(),
     typeof(TObj));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_03__err__bad
};//class TestsFor__Arg_NotNullAndInstanceOf

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.ErrorServices.Check
