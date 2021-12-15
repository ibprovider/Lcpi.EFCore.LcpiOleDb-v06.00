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

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.NullableTimeSpan.String{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE_VALUE=System.Nullable<System.TimeSpan>;
using T_TARGET_VALUE=System.String;

using T_SOURCE_VALUE_U=System.TimeSpan;

////////////////////////////////////////////////////////////////////////////////
//class TestSet__003__const2

public static class TestSet__003__const2
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
     var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)new T_SOURCE_VALUE(new T_SOURCE_VALUE_U(0,19,31,53,321))=="19:31:53.3210");

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
     var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)new T_SOURCE_VALUE(new T_SOURCE_VALUE_U(0,19,31,53,0))=="19:31:53.0000");

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
};//class TestSet__003__const2

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.NullableTimeSpan.String
