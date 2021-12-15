////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 01.03.2021.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.String.Int64{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE_VALUE=System.String;
using T_TARGET_VALUE=System.Int64;

////////////////////////////////////////////////////////////////////////////////
//class TestSet__ER004__param

public static class TestSet__ER004__param
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
 public static void Test_001__min_m1()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource="-9223372036854775809";
     const T_TARGET_VALUE c_valueTarget=-1;

     T_SOURCE_VALUE vv1=c_valueSource;
     T_TARGET_VALUE vv2=c_valueTarget;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)vv1==(T_TARGET_VALUE)vv2);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException exc)
     {
      CheckErrors.PrintException_OK(exc);      

      Assert.NotNull
       (exc.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (exc.InnerException);

      var e2=(structure_lib.exceptions.t_overflow_exception)exc.InnerException;

      Assert.NotNull
       (e2);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      Assert.NotNull
       (TestUtils.GetRecord(e2,0));

      CheckErrors.CheckErrorRecord__common_err__cant_convert_value_between_types_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableInt64,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW,
        "System.String",
        "System.Int64");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001__min_m1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__max_p1()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource="9223372036854775808";
     const T_TARGET_VALUE c_valueTarget=-1;

     T_SOURCE_VALUE vv1=c_valueSource;
     T_TARGET_VALUE vv2=c_valueTarget;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)vv1==(T_TARGET_VALUE)vv2);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException exc)
     {
      CheckErrors.PrintException_OK(exc);      

      Assert.NotNull
       (exc.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (exc.InnerException);

      var e2=(structure_lib.exceptions.t_overflow_exception)exc.InnerException;

      Assert.NotNull
       (e2);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      Assert.NotNull
       (TestUtils.GetRecord(e2,0));

      CheckErrors.CheckErrorRecord__common_err__cant_convert_value_between_types_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableInt64,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW,
        "System.String",
        "System.Int64");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__max_p1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__scale_overflow()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource="0E+2147483648";
     const T_TARGET_VALUE c_valueTarget=-1;

     T_SOURCE_VALUE vv1=c_valueSource;
     T_TARGET_VALUE vv2=c_valueTarget;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)vv1==(T_TARGET_VALUE)vv2);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException exc)
     {
      CheckErrors.PrintException_OK(exc);      

      Assert.NotNull
       (exc.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (exc.InnerException);

      var e2=(structure_lib.exceptions.t_overflow_exception)exc.InnerException;

      Assert.NotNull
       (e2);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      Assert.NotNull
       (TestUtils.GetRecord(e2,0));

      CheckErrors.CheckErrorRecord__common_err__cant_convert_value_between_types_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableInt64,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW,
        "System.String",
        "System.Int64");

      Assert.NotNull
       (e2.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (e2.InnerException);

      var e3=(structure_lib.exceptions.t_overflow_exception)e2.InnerException;

      Assert.NotNull
       (e3);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e3));

      Assert.NotNull
       (TestUtils.GetRecord(e3,0));

      CheckErrors.CheckErrorRecord__common_err__overflow_in_number_scale_calculation_0
       (TestUtils.GetRecord(e3,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableInt64,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW);
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_003__scale_overflow

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004__scale_overflow()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource="0.1E-2147483648";
     const T_TARGET_VALUE c_valueTarget=-1;

     T_SOURCE_VALUE vv1=c_valueSource;
     T_TARGET_VALUE vv2=c_valueTarget;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)vv1==(T_TARGET_VALUE)vv2);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException exc)
     {
      CheckErrors.PrintException_OK(exc);      

      Assert.NotNull
       (exc.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (exc.InnerException);

      var e2=(structure_lib.exceptions.t_overflow_exception)exc.InnerException;

      Assert.NotNull
       (e2);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      Assert.NotNull
       (TestUtils.GetRecord(e2,0));

      CheckErrors.CheckErrorRecord__common_err__cant_convert_value_between_types_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableInt64,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW,
        "System.String",
        "System.Int64");

      Assert.NotNull
       (e2.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (e2.InnerException);

      var e3=(structure_lib.exceptions.t_overflow_exception)e2.InnerException;

      Assert.NotNull
       (e3);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e3));

      Assert.NotNull
       (TestUtils.GetRecord(e3,0));

      CheckErrors.CheckErrorRecord__common_err__overflow_in_number_scale_calculation_0
       (TestUtils.GetRecord(e3,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableInt64,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW);
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_004__scale_overflow

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_005__scale_overflow()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource="0.01E-2147483647";
     const T_TARGET_VALUE c_valueTarget=-1;

     T_SOURCE_VALUE vv1=c_valueSource;
     T_TARGET_VALUE vv2=c_valueTarget;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)vv1==(T_TARGET_VALUE)vv2);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException exc)
     {
      CheckErrors.PrintException_OK(exc);      

      Assert.NotNull
       (exc.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (exc.InnerException);

      var e2=(structure_lib.exceptions.t_overflow_exception)exc.InnerException;

      Assert.NotNull
       (e2);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      Assert.NotNull
       (TestUtils.GetRecord(e2,0));

      CheckErrors.CheckErrorRecord__common_err__cant_convert_value_between_types_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableInt64,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW,
        "System.String",
        "System.Int64");

      Assert.NotNull
       (e2.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (e2.InnerException);

      var e3=(structure_lib.exceptions.t_overflow_exception)e2.InnerException;

      Assert.NotNull
       (e3);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e3));

      Assert.NotNull
       (TestUtils.GetRecord(e3,0));

      CheckErrors.CheckErrorRecord__common_err__overflow_in_number_scale_calculation_0
       (TestUtils.GetRecord(e3,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableInt64,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW);
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_005__scale_overflow

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_006__scale_overflow()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource="0.01E-2147483648";
     const T_TARGET_VALUE c_valueTarget=-1;

     T_SOURCE_VALUE vv1=c_valueSource;
     T_TARGET_VALUE vv2=c_valueTarget;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)vv1==(T_TARGET_VALUE)vv2);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException exc)
     {
      CheckErrors.PrintException_OK(exc);      

      Assert.NotNull
       (exc.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (exc.InnerException);

      var e2=(structure_lib.exceptions.t_overflow_exception)exc.InnerException;

      Assert.NotNull
       (e2);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      Assert.NotNull
       (TestUtils.GetRecord(e2,0));

      CheckErrors.CheckErrorRecord__common_err__cant_convert_value_between_types_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableInt64,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW,
        "System.String",
        "System.Int64");

      Assert.NotNull
       (e2.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (e2.InnerException);

      var e3=(structure_lib.exceptions.t_overflow_exception)e2.InnerException;

      Assert.NotNull
       (e3);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e3));

      Assert.NotNull
       (TestUtils.GetRecord(e3,0));

      CheckErrors.CheckErrorRecord__common_err__overflow_in_number_scale_calculation_0
       (TestUtils.GetRecord(e3,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableInt64,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW);
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_006__scale_overflow

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_007__scale_overflow()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_SOURCE_VALUE c_valueSource="10E+2147483647";
     const T_TARGET_VALUE c_valueTarget=-1;

     T_SOURCE_VALUE vv1=c_valueSource;
     T_TARGET_VALUE vv2=c_valueTarget;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)vv1==(T_TARGET_VALUE)vv2);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException exc)
     {
      CheckErrors.PrintException_OK(exc);      

      Assert.NotNull
       (exc.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (exc.InnerException);

      var e2=(structure_lib.exceptions.t_overflow_exception)exc.InnerException;

      Assert.NotNull
       (e2);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      Assert.NotNull
       (TestUtils.GetRecord(e2,0));

      CheckErrors.CheckErrorRecord__common_err__cant_convert_value_between_types_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableInt64,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW,
        "System.String",
        "System.Int64");

      Assert.NotNull
       (e2.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (e2.InnerException);

      var e3=(structure_lib.exceptions.t_overflow_exception)e2.InnerException;

      Assert.NotNull
       (e3);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e3));

      Assert.NotNull
       (TestUtils.GetRecord(e3,0));

      CheckErrors.CheckErrorRecord__common_err__overflow_in_number_scale_calculation_0
       (TestUtils.GetRecord(e3,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableInt64,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW);
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_007__scale_overflow
};//class TestSet__ER004__param

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.String.Int64
