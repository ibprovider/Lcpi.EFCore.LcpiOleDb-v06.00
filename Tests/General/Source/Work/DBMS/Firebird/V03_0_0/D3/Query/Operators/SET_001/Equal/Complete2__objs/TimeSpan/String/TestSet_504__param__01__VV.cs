////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 11.05.2021.
using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.Equal.Complete2__objs.TimeSpan.String{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1  =System.TimeSpan;
using T_DATA2  =System.String;

using T_DATA1_U=System.TimeSpan;
using T_DATA2_U=System.String;

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
     T_DATA1 vv1=new T_DATA1_U(12,14,34).Add(new System.TimeSpan(1000*1233)).Add(new System.TimeSpan(900));
     T_DATA2 vv2="12:14:34.1234";

     var recs=db.testTable.Where(r => ((object)vv1) /*OP{*/ == /*}OP*/ ((object)vv2));

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(structure_lib.exceptions.t_invalid_operation_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.IsNull
       (e.InnerException);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__local_eval_err__binary_operator_not_supported_3
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
        System.Linq.Expressions.ExpressionType.Equal,
        "Nullable<System.TimeSpan>",
        "System.String");
     }//catch
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
     T_DATA1 vv1=new T_DATA1_U(12,14,34).Add(new System.TimeSpan(1000*1234)).Add(new System.TimeSpan(900));
     T_DATA2 vv2="12:14:34.1234";

     var recs=db.testTable.Where(r => ((object)vv1) /*OP{*/ == /*}OP*/ ((object)vv2));

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(structure_lib.exceptions.t_invalid_operation_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.IsNull
       (e.InnerException);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__local_eval_err__binary_operator_not_supported_3
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
        System.Linq.Expressions.ExpressionType.Equal,
        "Nullable<System.TimeSpan>",
        "System.String");
     }//catch
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
     T_DATA1 vv1=new T_DATA1_U(12,14,34).Add(new System.TimeSpan(1000*1235)).Add(new System.TimeSpan(900));
     T_DATA2 vv2="12:14:34.1234";

     var recs=db.testTable.Where(r => ((object)vv1) /*OP{*/ == /*}OP*/ ((object)vv2));

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(structure_lib.exceptions.t_invalid_operation_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.IsNull
       (e.InnerException);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__local_eval_err__binary_operator_not_supported_3
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
        System.Linq.Expressions.ExpressionType.Equal,
        "Nullable<System.TimeSpan>",
        "System.String");
     }//catch
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
     T_DATA2 vv2="12:14:34.1234";

     var recs=db.testTable.Where(r => ((object)(T_DATA1)(System.Object)vv1__null_obj) /*OP{*/ == /*}OP*/ ((object)vv2));

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(structure_lib.exceptions.t_invalid_operation_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.IsNull
       (e.InnerException);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__local_eval_err__binary_operator_not_supported_3
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
        System.Linq.Expressions.ExpressionType.Equal,
        "Nullable<System.TimeSpan>",
        "System.String");
     }//catch
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
     T_DATA1 vv1=new T_DATA1_U(12,14,34).Add(new System.TimeSpan(1000*1233));
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
     catch(structure_lib.exceptions.t_invalid_operation_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.IsNull
       (e.InnerException);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__local_eval_err__binary_operator_not_supported_3
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
        System.Linq.Expressions.ExpressionType.Equal,
        "Nullable<System.TimeSpan>",
        "System.String");
     }//catch
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_ZA02VN

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

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(structure_lib.exceptions.t_invalid_operation_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.IsNull
       (e.InnerException);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__local_eval_err__binary_operator_not_supported_3
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
        System.Linq.Expressions.ExpressionType.Equal,
        "Nullable<System.TimeSpan>",
        "System.String");
     }//catch
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
     T_DATA2 vv2="12:14:34.1234";

     var recs=db.testTable.Where(r => !(((object)(T_DATA1)(System.Object)vv1__null_obj) /*OP{*/ == /*}OP*/ ((object)vv2)));

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(structure_lib.exceptions.t_invalid_operation_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.IsNull
       (e.InnerException);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__local_eval_err__binary_operator_not_supported_3
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
        System.Linq.Expressions.ExpressionType.Equal,
        "Nullable<System.TimeSpan>",
        "System.String");
     }//catch
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
     T_DATA1 vv1=new T_DATA1_U(12,14,34).Add(new System.TimeSpan(1000*1233));
     object  vv2__null_obj=null;

     var recs=db.testTable.Where(r => !(((object)vv1) /*OP{*/ == /*}OP*/ ((object)(T_DATA2)(System.Object)vv2__null_obj)));

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(structure_lib.exceptions.t_invalid_operation_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.IsNull
       (e.InnerException);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__local_eval_err__binary_operator_not_supported_3
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
        System.Linq.Expressions.ExpressionType.Equal,
        "Nullable<System.TimeSpan>",
        "System.String");
     }//catch
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

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(structure_lib.exceptions.t_invalid_operation_exception e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.IsNull
       (e.InnerException);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__local_eval_err__binary_operator_not_supported_3
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalSvc__PrepareForLocalEvaluation,
        System.Linq.Expressions.ExpressionType.Equal,
        "Nullable<System.TimeSpan>",
        "System.String");
     }//catch
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_ZB03NN
};//class TestSet_504__param__01__VV

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.Equal.Complete2__objs.TimeSpan.String
