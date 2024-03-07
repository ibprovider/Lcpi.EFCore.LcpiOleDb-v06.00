////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 13.05.2021.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_001.GreaterThan.Complete.TimeOnly.TimeOnly{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1  =System.TimeOnly;
using T_DATA2  =System.TimeOnly;

using T_DATA1_U=System.TimeOnly;
using T_DATA2_U=System.TimeOnly;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__fields__01__VV

public static class TestSet_001__fields__01__VV
{
 private const string c_NameOf__TABLE            ="TEST_MODIFY_ROW2";
 private const string c_NameOf__COL_DATA1        ="COL_TIMESTAMP";
 private const string c_NameOf__COL_DATA2        ="COL2_TIMESTAMP";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA1)]
   public T_DATA1 COL_DATA1 { get; set; }

   [Column(c_NameOf__COL_DATA2)]
   public T_DATA2 COL_DATA2 { get; set; }
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
     T_DATA1 c_value1=new T_DATA1_U(12,14,34).Add(new System.TimeSpan(1000*1235)).Add(new System.TimeSpan(0));
     T_DATA2 c_value2=new T_DATA2_U(12,14,34).Add(new System.TimeSpan(1000*1234)).Add(new System.TimeSpan(900));

     try
     {
      var newRecord=new MyContext.TEST_RECORD();

      newRecord.COL_DATA1 =c_value1;
      newRecord.COL_DATA2 =c_value2;

      db.testTable.Add(newRecord);

      db.SaveChanges(); //throw!

      TestServices.ThrowWeWaitError();
     }
      catch(DbUpdateException e)
      {
       CheckErrors.PrintException_OK(e);

       Assert.NotNull
        (e.InnerException);

       Assert.IsInstanceOf
        (typeof(xdb.OleDbException),
         e.InnerException);

       var e2=e.InnerException as xdb.OleDbException;

       Assert.IsNull
        (e2.InnerException);

      Assert.AreEqual
       (lcpi.lib.com.HResultCode.DB_E_UNSUPPORTEDCONVERSION,
        e2.ErrorCode);

      Assert.AreEqual
       (3,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__IBP__FailedToBuildIbParamValue__CantConvert
       (TestUtils.GetRecord(e2,0),
        0,
        "DBTYPE_DBTIME2",
        "DBTYPE_DBTIMESTAMP",
        lcpi.lib.com.HResultCode.DB_E_UNSUPPORTEDCONVERSION);
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001
};//class TestSet_001__fields__01__VV

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_001.GreaterThan.Complete.TimeOnly.TimeOnly
