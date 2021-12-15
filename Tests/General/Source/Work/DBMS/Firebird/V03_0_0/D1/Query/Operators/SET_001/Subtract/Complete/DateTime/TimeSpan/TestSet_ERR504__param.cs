////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 25.03.2021.
using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_001.Subtract.Complete.DateTime.TimeSpan{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1   =System.DateTime;
using T_DATA2   =System.TimeSpan;
using T_RESULT  =System.DateTime;

using T_DATA1_U =System.DateTime;
using T_DATA2_U =System.TimeSpan;
using T_RESULT_U=System.DateTime;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_ERR504__param

public static class TestSet_ERR504__param
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
 public static void Test_001__down()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1=new T_DATA1_U(1,1,1,12,10,11);
     T_DATA2 vv2=new T_DATA2_U(12,10,11)+new T_DATA2_U(1000);

     T_DATA1 vr=new T_DATA1(2021,2,1,20,30,33).AddTicks(4321000);

     var recs=db.testTable.Where(r => (vv1-vv2)==vr);

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
     
      Assert.IsNotNull
       (exc.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (exc.InnerException);

      structure_lib.exceptions.t_overflow_exception
       e2
        =(structure_lib.exceptions.t_overflow_exception)exc.InnerException;

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__out_of_range_in_arithmetic_op2__5<System.DateTime,System.TimeSpan>
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Subtract___DateTime__TimeSpan,
        System.Linq.Expressions.ExpressionType.Subtract,
        "01.01.0001 12:10:11",
        "12:10:11.0001000");

      Assert.IsNull
       (e2.InnerException);
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001__down

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__up()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1=T_DATA1_U.MaxValue;
     T_DATA2 vv2=new T_DATA2_U()-new T_DATA2_U(1000);

     T_DATA1 vr=new T_DATA1(2021,2,1,20,30,33).AddTicks(4321000);

     var recs=db.testTable.Where(r => (vv1-vv2)==vr);

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
     
      Assert.IsNotNull
       (exc.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_overflow_exception>
       (exc.InnerException);

      structure_lib.exceptions.t_overflow_exception
       e2
        =(structure_lib.exceptions.t_overflow_exception)exc.InnerException;

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__out_of_range_in_arithmetic_op2__5<System.DateTime,System.TimeSpan>
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Subtract___DateTime__TimeSpan,
        System.Linq.Expressions.ExpressionType.Subtract,
        "31.12.9999 23:59:59",
        "-00:00:00.0001000");

      Assert.IsNull
       (e2.InnerException);
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__up
};//class TestSet_ERR504__param

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_001.Subtract.Complete.DateTime.TimeSpan
