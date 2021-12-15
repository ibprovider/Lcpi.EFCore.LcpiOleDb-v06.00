////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 06.01.2021.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.Int64.Int16{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE_VALUE=System.Int64;
using T_TARGET_VALUE=System.Int16;

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
     const T_SOURCE_VALUE c_valueSource=((T_SOURCE_VALUE)T_TARGET_VALUE.MinValue)-1;
     const T_TARGET_VALUE c_valueTarget=-1;

     T_SOURCE_VALUE vv1=c_valueSource;
     T_TARGET_VALUE vv2=c_valueTarget;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)vv1==(T_TARGET_VALUE)vv2);

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
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Int64__Int16,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW,
        typeof(T_SOURCE_VALUE),
        typeof(T_TARGET_VALUE));
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
     const T_SOURCE_VALUE c_valueSource=((T_SOURCE_VALUE)T_TARGET_VALUE.MaxValue)+1;
     const T_TARGET_VALUE c_valueTarget=-1;

     T_SOURCE_VALUE vv1=c_valueSource;
     T_TARGET_VALUE vv2=c_valueTarget;

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)vv1==(T_TARGET_VALUE)vv2);

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
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_MasterCode__Int64__Int16,
        lcpi.lib.com.HResultCode.DB_E_DATAOVERFLOW,
        typeof(T_SOURCE_VALUE),
        typeof(T_TARGET_VALUE));
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__max_p1
};//class TestSet__ER004__param

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.Int64.Int16
