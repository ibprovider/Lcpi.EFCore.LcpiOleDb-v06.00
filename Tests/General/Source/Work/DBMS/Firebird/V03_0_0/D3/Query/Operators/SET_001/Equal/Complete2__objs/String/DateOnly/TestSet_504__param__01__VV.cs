﻿////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 05.07.2021.
using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.Equal.Complete2__objs.String.DateOnly{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1  =System.String;
using T_DATA2  =System.DateOnly;

using T_DATA1_U=System.String;
using T_DATA2_U=System.DateOnly;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_504__param__01__VV

public static class TestSet_504__param__01__VV
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
 public static void Test_001__less()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1="11.05.2021";
     T_DATA2 vv2=new T_DATA2_U(2021,05,12);

     var recs=db.testTable.Where(r => ((object)vv1) /*OP{*/ == /*}OP*/ ((object)vv2));

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_V_0"));
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_001__less

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__equal()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1="11.05.2021";
     T_DATA2 vv2=new T_DATA2_U(2021,05,11);

     var recs=db.testTable.Where(r => ((object)vv1) /*OP{*/ == /*}OP*/ ((object)vv2));

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
 }//Test_002__equal

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003__greater()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1="12.05.2021";
     T_DATA2 vv2=new T_DATA2_U(2021,05,11);

     var recs=db.testTable.Where(r => ((object)vv1) /*OP{*/ == /*}OP*/ ((object)vv2));

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_V_0"));
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_003__greater

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ZA01NV()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     object  vv1__null_obj=null;
     T_DATA2 vv2=new T_DATA2_U(2021,05,11);

     var recs=db.testTable.Where(r => ((object)(T_DATA1)(System.Object)vv1__null_obj) /*OP{*/ == /*}OP*/ ((object)vv2));

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_V_0"));
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_ZA01NV

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ZA02VN()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1="11.05.2021 12:14:34.1233";
     object  vv2__null_obj=null;

     var recs=db.testTable.Where(r => ((object)vv1) /*OP{*/ == /*}OP*/ ((object)(T_DATA2)(System.Object)vv2__null_obj));

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

      Assert.IsNotNull(e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_invalid_operation_exception>(e.InnerException);

      var e2=(structure_lib.exceptions.t_invalid_operation_exception)e.InnerException;

      Assert.AreEqual
       (TestUtils.GetRecordCount(e2),
        1);

      CheckErrors.CheckErrorRecord__common_err__cant_convert_value_between_types_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__Core_Engines_Dbms_FB_Common_Mirror__Convert_Code__STRING__TYPE_DATE,
        lcpi.lib.com.HResultCode.DB_E_CANTCONVERTVALUE,
        typeof(System.String),
        typeof(System.DateOnly));
     }//catch
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_ZA02VN

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ZA02VN__OK()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1="11.05.2021";
     object  vv2__null_obj=null;

     var recs=db.testTable.Where(r => ((object)vv1) /*OP{*/ == /*}OP*/ ((object)(T_DATA2)(System.Object)vv2__null_obj));

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_V_0"));
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_ZA02VN__OK

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ZA03NN()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     object vv1__null_obj=null;
     object vv2__null_obj=null;

     var recs=db.testTable.Where(r => ((object)(T_DATA1)(System.Object)vv1__null_obj) /*OP{*/ == /*}OP*/ ((object)(T_DATA2)(System.Object)vv2__null_obj));

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
 }//Test_ZA03NN

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ZB01NV()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     object  vv1__null_obj=null;
     T_DATA2 vv2=new T_DATA2_U(2021,05,11);

     var recs=db.testTable.Where(r => !(((object)(T_DATA1)(System.Object)vv1__null_obj) /*OP{*/ == /*}OP*/ ((object)vv2)));

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
        .T("WHERE ").P_BOOL("__Exec_V_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_ZB01NV

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ZB02VN()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1="11.05.2021";
     object  vv2__null_obj=null;

     var recs=db.testTable.Where(r => !(((object)vv1) /*OP{*/ == /*}OP*/ ((object)(T_DATA2)(System.Object)vv2__null_obj)));

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
        .T("WHERE ").P_BOOL("__Exec_V_0"));

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_ZB02VN

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ZB03NN()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     object vv1__null_obj=null;
     object vv2__null_obj=null;

     var recs=db.testTable.Where(r => !(((object)(T_DATA1)(System.Object)vv1__null_obj) /*OP{*/ == /*}OP*/ ((object)(T_DATA2)(System.Object)vv2__null_obj)));

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_0"));
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_ZB03NN
};//class TestSet_504__param__01__VV

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.Equal.Complete2__objs.String.DateOnly
