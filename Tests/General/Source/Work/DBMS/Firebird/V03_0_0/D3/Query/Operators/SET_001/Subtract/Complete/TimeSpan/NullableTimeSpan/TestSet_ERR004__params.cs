////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 29.11.2020.
using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.Subtract.Complete.TimeSpan.NullableTimeSpan{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1   =System.TimeSpan;
using T_DATA2   =System.Nullable<System.TimeSpan>;
using T_RESULT  =System.Nullable<System.TimeSpan>;

using T_DATA1_U =System.TimeSpan;
using T_DATA2_U =System.TimeSpan;
using T_RESULT_U=System.TimeSpan;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_ERR004__params

public static class TestSet_ERR004__params
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
     T_DATA1 c_value1=T_DATA1_U.MinValue;
     T_DATA2 c_value2=T_DATA2_U.MaxValue;

     T_DATA1 vv1=c_value1;
     T_DATA2 vv2=c_value2;

     var recs=db.testTable.Where(r => (vv1-vv2)==(T_RESULT)(new T_RESULT_U(7,6,9)));

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

      CheckErrors.CheckErrorRecord__common_err__overflow_in_arithmetic_op2__5<T_DATA1_U,T_DATA2_U>
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Subtract___TimeSpan__TimeSpan,
        System.Linq.Expressions.ExpressionType.Subtract,
        "-10675199.02:48:05.4775000",     // Ohoho!!!
         "10675199.02:48:05.4775000");
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
     T_DATA1 c_value1=T_DATA1_U.MaxValue;
     T_DATA2 c_value2=T_DATA2_U.MinValue;

     T_DATA1 vv1=c_value1;
     T_DATA2 vv2=c_value2;

     var recs=db.testTable.Where(r => (vv1-vv2)==(T_RESULT)(new T_RESULT_U(7,6,9)));

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

      CheckErrors.CheckErrorRecord__common_err__overflow_in_arithmetic_op2__5<T_DATA1_U,T_DATA2_U>
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_V03_0_0__Query_Local_D0_Expressions__Op2_MasterCode__Subtract___TimeSpan__TimeSpan,
        System.Linq.Expressions.ExpressionType.Subtract,
         "10675199.02:48:05.4775000",
        "-10675199.02:48:05.4775000");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__up
};//class TestSet_ERR004__params

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_001.Subtract.Complete.TimeSpan.NullableTimeSpan
