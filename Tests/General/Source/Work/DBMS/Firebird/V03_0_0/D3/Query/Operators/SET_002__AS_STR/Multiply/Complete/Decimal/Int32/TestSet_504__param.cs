////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 30.03.2021.
using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_002__AS_STR.Multiply.Complete.Decimal.Int32{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1   =System.Decimal;
using T_DATA2   =System.Int32;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_504__param

public static class TestSet_504__param
{
 private const string c_NameOf__TABLE            ="DUAL";

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
     T_DATA1 vv1=7;
     T_DATA2 vv2=4;

     var recs=db.testTable.Where(r => (string)(object)(vv1*vv2)=="28");

     int nRecs=0;

     foreach(var r in recs)
     {
      Assert.AreEqual
       (0,
        nRecs);

      ++nRecs;

      Assert.IsTrue
       (r.TEST_ID.HasValue);

      Assert.AreEqual
       (1,
        r.TEST_ID.Value);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_V_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_MM001__min_min()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1=T_DATA1.MinValue;
     T_DATA2 vv2=T_DATA2.MinValue;

     var recs=db.testTable.Where(r => (string)(object)(vv1*vv2)=="BLA-BLA-BLA");

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

      Assert.NotNull
       (e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (e.InnerException);

      var e2
       =(structure_lib.exceptions.t_overflow_exception)e.InnerException;

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__overflow_in_arithmetic_op2__5<decimal,decimal>
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op2_MasterCode__Multiply___Decimal__Decimal,
        System.Linq.Expressions.ExpressionType.Multiply,
        vv1,
        vv2);
     }//catch
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_MM001__min_min

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_MM002__max_max()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1=T_DATA1.MaxValue;
     T_DATA2 vv2=T_DATA2.MaxValue;

     var recs=db.testTable.Where(r => (string)(object)(vv1*vv2)=="BLA-BLA-BLA");

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

      Assert.NotNull
       (e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (e.InnerException);

      var e2
       =(structure_lib.exceptions.t_overflow_exception)e.InnerException;

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__overflow_in_arithmetic_op2__5<decimal,decimal>
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op2_MasterCode__Multiply___Decimal__Decimal,
        System.Linq.Expressions.ExpressionType.Multiply,
        vv1,
        vv2);
     }//catch
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_MM002__max_max

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_MM003__min_max()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1=T_DATA1.MinValue;
     T_DATA2 vv2=T_DATA2.MaxValue;

     var recs=db.testTable.Where(r => (string)(object)(vv1*vv2)=="BLA-BLA-BLA");

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

      Assert.NotNull
       (e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (e.InnerException);

      var e2
       =(structure_lib.exceptions.t_overflow_exception)e.InnerException;

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__overflow_in_arithmetic_op2__5<decimal,decimal>
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op2_MasterCode__Multiply___Decimal__Decimal,
        System.Linq.Expressions.ExpressionType.Multiply,
        vv1,
        vv2);
     }//catch
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_MM003__min_max

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_MM004__max_min()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1=T_DATA1.MaxValue;
     T_DATA2 vv2=T_DATA2.MinValue;

     var recs=db.testTable.Where(r => (string)(object)(vv1*vv2)=="BLA-BLA-BLA");

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

      Assert.NotNull
       (e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (e.InnerException);

      var e2
       =(structure_lib.exceptions.t_overflow_exception)e.InnerException;

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__overflow_in_arithmetic_op2__5<decimal,decimal>
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Op2_MasterCode__Multiply___Decimal__Decimal,
        System.Linq.Expressions.ExpressionType.Multiply,
        vv1,
        vv2);
     }//catch
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_MM004__max_min

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_Z01NV()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     string  vv1=null;
     T_DATA2 vv2=4;

     //translated vv1.Length returns Nullable<int>
     var recs=db.testTable.Where(r => (string)(object)((T_DATA1)vv1.Length*vv2)==null);

     int nRecs=0;

     foreach(var r in recs)
     {
      Assert.AreEqual
       (0,
        nRecs);

      ++nRecs;

      Assert.IsTrue
       (r.TEST_ID.HasValue);

      Assert.AreEqual
       (1,
        r.TEST_ID.Value);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_V_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_Z01NV

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_Z02VN()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1=7;
     string  vv2=null;

     //translated vv2.Length returns Nullable<int>
     var recs=db.testTable.Where(r => (string)(object)(vv1*(T_DATA2)vv2.Length)==null);

     int nRecs=0;

     foreach(var r in recs)
     {
      Assert.AreEqual
       (0,
        nRecs);

      ++nRecs;

      Assert.IsTrue
       (r.TEST_ID.HasValue);

      Assert.AreEqual
       (1,
        r.TEST_ID.Value);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_V_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_Z02VN

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_Z03NN()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     string vv1=null;
     string vv2=null;

     //translated vv1.Length returns Nullable<int>
     //translated vv2.Length returns Nullable<int>
     var recs=db.testTable.Where(r => (string)(object)((T_DATA1)vv1.Length*(T_DATA2)vv2.Length)==null);

     int nRecs=0;

     foreach(var r in recs)
     {
      Assert.AreEqual
       (0,
        nRecs);

      ++nRecs;

      Assert.IsTrue
       (r.TEST_ID.HasValue);

      Assert.AreEqual
       (1,
        r.TEST_ID.Value);
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_V_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_Z03NN
};//class TestSet_504__param

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_002__AS_STR.Multiply.Complete.Decimal.Int32
