////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 27.01.2021.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.CastAs.SET_001.TimeSpan.String{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE_VALUE=System.TimeSpan;
using T_TARGET_VALUE=System.String;

using T_SOURCE_VALUE_U=System.TimeSpan;

////////////////////////////////////////////////////////////////////////////////
//class TestSet__005__paramObj

public static class TestSet__005__paramObj
{
 private const string c_NameOf__TABLE="DUAL";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("ID")]
   public System.Int32? TEST_ID { get; set; }
  };//class TEST_RECORD

  //----------------------------------------------------------------------
  public DbSet<TEST_RECORD> testTable { get; set; }

  //----------------------------------------------------------------------
  public MyContext(xdb.OleDbTransaction tr)
   :base(tr)
  {
  }//MyContext
 };//class MyContext

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_001()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     object vv=(T_SOURCE_VALUE)new T_SOURCE_VALUE_U(0,19,31,53,321);

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)vv=="19:31:53.3210");

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.IsNotNull
       (e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_invalid_operation_exception>
       (e.InnerException);

      var e2=(structure_lib.exceptions.t_invalid_operation_exception)(e.InnerException);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__unsupported_datatypes_conversion_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__Object__String,
        "System.TimeSpan",
        "System.String");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     object vv=(T_SOURCE_VALUE)new T_SOURCE_VALUE_U(0,19,31,53,0);

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)vv=="19:31:53.0000");

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.IsNotNull
       (e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_invalid_operation_exception>
       (e.InnerException);

      var e2=(structure_lib.exceptions.t_invalid_operation_exception)(e.InnerException);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__unsupported_datatypes_conversion_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__Object__String,
        "System.TimeSpan",
        "System.String");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const long c_TicksInMicroSec=1000;

     const long c_TicksInSec     =c_TicksInMicroSec*10*1000;
     const long c_TicksInMin     =c_TicksInSec*60;
     const long c_TicksInHour    =c_TicksInMin*60;

     const long c_srcTicks=c_TicksInHour*19+c_TicksInMin*31+c_TicksInSec*53+c_TicksInMicroSec*4321;

     object vv=(T_SOURCE_VALUE)new T_SOURCE_VALUE_U(c_srcTicks);

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)vv=="19:31:53.4321");

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.IsNotNull
       (e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_invalid_operation_exception>
       (e.InnerException);

      var e2=(structure_lib.exceptions.t_invalid_operation_exception)(e.InnerException);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__unsupported_datatypes_conversion_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__Object__String,
        "System.TimeSpan",
        "System.String");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_003

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ERR1__001__neg_tick1()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     object vv=(T_SOURCE_VALUE)new T_SOURCE_VALUE_U(-1);

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)vv=="19:31:53.4321");

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.IsNotNull
       (e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_invalid_operation_exception>
       (e.InnerException);

      var e2=(structure_lib.exceptions.t_invalid_operation_exception)(e.InnerException);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__unsupported_datatypes_conversion_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__Object__String,
        "System.TimeSpan",
        "System.String");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_ERR1__001__neg_tick1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ERR1__002__neg_value()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const long c_TicksInMicroSec=1000;

     const long c_TicksInSec     =c_TicksInMicroSec*10*1000;
     const long c_TicksInMin     =c_TicksInSec*60;
     const long c_TicksInHour    =c_TicksInMin*60;

     const long c_srcTicks=c_TicksInHour*19+c_TicksInMin*31+c_TicksInSec*53+c_TicksInMicroSec*4326;

     object vv=(T_SOURCE_VALUE)new T_SOURCE_VALUE_U(-c_srcTicks);

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)vv=="19:31:53.4321");

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.IsNotNull
       (e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_invalid_operation_exception>
       (e.InnerException);

      var e2=(structure_lib.exceptions.t_invalid_operation_exception)(e.InnerException);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__unsupported_datatypes_conversion_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__Object__String,
        "System.TimeSpan",
        "System.String");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_ERR1__002__neg_value

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ERR2__001__day1()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     object vv=(T_SOURCE_VALUE)new T_SOURCE_VALUE_U(1,0,0,0,0);

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)vv=="19:31:53.4321");

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.IsNotNull
       (e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_invalid_operation_exception>
       (e.InnerException);

      var e2=(structure_lib.exceptions.t_invalid_operation_exception)(e.InnerException);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__unsupported_datatypes_conversion_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__Object__String,
        "System.TimeSpan",
        "System.String");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_ERR2__001__day1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ERR2__002__non_zero_days()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const long c_TicksInMicroSec=1000;

     const long c_TicksInSec     =c_TicksInMicroSec*10*1000;
     const long c_TicksInMin     =c_TicksInSec*60;
     const long c_TicksInHour    =c_TicksInMin*60;
     const long c_TicksInDay     =c_TicksInHour*24;

     const long c_srcTicks=c_TicksInDay*21+c_TicksInHour*19+c_TicksInMin*31+c_TicksInSec*53+c_TicksInMicroSec*4326;

     object vv=(T_SOURCE_VALUE)new T_SOURCE_VALUE_U(c_srcTicks);

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)vv=="19:31:53.4321");

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.IsNotNull
       (e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_invalid_operation_exception>
       (e.InnerException);

      var e2=(structure_lib.exceptions.t_invalid_operation_exception)(e.InnerException);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__unsupported_datatypes_conversion_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__Object__String,
        "System.TimeSpan",
        "System.String");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_ERR2__002__non_zero_days
};//class TestSet__005__paramObj

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.CastAs.SET_001.TimeSpan.String
