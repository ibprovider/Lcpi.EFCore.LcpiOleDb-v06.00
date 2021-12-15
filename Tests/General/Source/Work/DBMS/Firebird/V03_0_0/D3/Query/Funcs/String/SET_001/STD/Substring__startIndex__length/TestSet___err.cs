////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 11.09.2018.
//
// <field>.Substring(<expression with startIndex>,<expression length>)
//
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions;

using xdb=lcpi.data.oledb;

using exceptions_lib=lcpi.lib.structure.exceptions;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Substring__startIndex__length{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA=System.String;

////////////////////////////////////////////////////////////////////////////////
//class TestSet___err

public static class TestSet___err
{
 private sealed class MyContext:TestBaseDbContext
 {
  [Table("DUAL")]
  public sealed class DUAL
  {
   [Key]
   [Column("ID")]
   public System.Int32 ID { get; set; }
  };//class DUAL

  //----------------------------------------------------------------------
  public DbSet<DUAL> dualTable { get; set; }

  //----------------------------------------------------------------------
  public MyContext(xdb.OleDbTransaction tr)
   :base(tr)
  {
  }//MyContext
 };//class MyContext

 //-----------------------------------------------------------------------
 private static int? F(int? v)
 {
  return v;
 }//int

 //-----------------------------------------------------------------------
#if BUILD_CONF__UNSUPPORTED_TESTS

 [Test]
 public static void Test___ByEF___001__negative_startIndex()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,null,0);

     var recs=db.testTable.Where(r => r.DATA.Substring(F(r.COL_INTEGER-10),r.COL_INTEGER+3)==null && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(exceptions_lib.t_argument_out_of_range_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckException__ArgumentOutOfRange__negative_value
       (e,
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__String__Substring___nullableStartIndex__nullableLength,
        "Exec",
        "startIndex",
        -10);
     }//catch

     db.log.CheckTextOfLastExecutedCommand
      ("SELECT \"r\".\"TEST_ID\", \"r\".\"COL_INTEGER\", \"r\".\"COL_VARCHAR_10\"\n"
      +"FROM \"TEST_MODIFY_ROW\" AS \"r\"\n"
      +"WHERE \"r\".\"TEST_ID\" = :__testID_0");
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___ByEF___001__negative_startIndex

#endif //BUILD_CONF__UNSUPPORTED_TESTS

 //-----------------------------------------------------------------------
#if BUILD_CONF__UNSUPPORTED_TESTS

 [Test]
 public static void Test___ByEF___002__negative_length()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     System.Int64 testID=Helper__InsertRow(db,null,-13);

     var recs=db.testTable.Where(r => r.DATA.Substring(1,F(r.COL_INTEGER.Value))=="123" && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(exceptions_lib.t_argument_out_of_range_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckException__ArgumentOutOfRange__negative_value
       (e,
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__String__Substring___nullableStartIndex__nullableLength,
        "Exec",
        "length",
        -13);
     }//catch

     db.log.CheckTextOfLastExecutedCommand
      ("SELECT \"r\".\"TEST_ID\", \"r\".\"COL_INTEGER\", \"r\".\"COL_VARCHAR_10\"\n"
      +"FROM \"TEST_MODIFY_ROW\" AS \"r\"\n"
      +"WHERE \"r\".\"TEST_ID\" = :__testID_0");
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___ByEF___002__negative_length

#endif //BUILD_CONF__UNSUPPORTED_TESTS

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___ByEF___003__negative_startIndex()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA vvs=null;

     int? vv1=0;

     var recs=db.dualTable.Where(r => vvs.Substring(vv1-10,vv1+3)==null);

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

      Assert.IsInstanceOf<exceptions_lib.t_argument_out_of_range_exception>
       (e.InnerException);

      var e1=(exceptions_lib.t_argument_out_of_range_exception)e.InnerException;

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e1));

      CheckErrors.CheckException__ArgumentOutOfRange__negative_value
       (e1,
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__String__Substring___nullableStartIndex__nullableLength,
        "Exec",
        "startIndex",
        -10);
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___ByEF___003__negative_startIndex

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___ByEF___004__negative_length()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA vvs=null;

     int? vv1=-13;

     var recs=db.dualTable.Where(r => vvs.Substring(1,vv1)=="123");

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

      Assert.IsInstanceOf<exceptions_lib.t_argument_out_of_range_exception>
       (e.InnerException);

      var e1=(exceptions_lib.t_argument_out_of_range_exception)e.InnerException;

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e1));

      CheckErrors.CheckException__ArgumentOutOfRange__negative_value
       (e1,
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__String__Substring___nullableStartIndex__nullableLength,
        "Exec",
        "length",
        -13);
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___ByEF___004__negative_length
};//class TestSet___err

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Substring__startIndex__length
