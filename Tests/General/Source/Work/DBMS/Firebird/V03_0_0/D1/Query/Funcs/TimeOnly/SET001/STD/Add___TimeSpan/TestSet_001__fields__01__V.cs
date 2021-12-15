////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 19.07.2021.
//
// <field>.Add___TimeSpan
//
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.TimeOnly.SET001.STD.Add___TimeSpan{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA  =System.TimeOnly;
using T_DATA_U=System.TimeOnly;

using T_AMOUNT=System.TimeSpan;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__fields__01__V

public static class TestSet_001__fields__01__V
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW";

 private const string c_NameOf__COL_DATA="COL_TYPE_TIME";

 //-----------------------------------------------------------------------
 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA)]
   public T_DATA DATA { get; set; }
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
 public static void Test_01()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA c_data=new T_DATA_U(14,27,53);

     System.Int64? testID=Helper__InsertRow(db,c_data);

     var recs=db.testTable.Where(r => r.DATA.Add((T_AMOUNT)new System.TimeSpan(1,2,3))==new T_DATA_U(15,29,56) && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(structure_lib.exceptions.t_not_supported_exception exc)
     {
      CheckErrors.PrintException_OK(exc);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(exc));

      CheckErrors.CheckErrorRecord__sql_gen_err__translation_of_member_not_supported_in_current_cn_dialect_2
       (TestUtils.GetRecord(exc,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_Common__Sql_ETranslator__Dummy__MethodNotSupportedInCurrentCnDialect,
        1,
        "System.TimeOnly.Add(System.TimeSpan)");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const long
      c_ticks1
       =14*System.TimeSpan.TicksPerHour
       +27*System.TimeSpan.TicksPerMinute
       +53*System.TimeSpan.TicksPerSecond
       +1234*1000
       +999;

     T_DATA c_data=new T_DATA_U(c_ticks1);

     System.Int64? testID=Helper__InsertRow(db,c_data);

     const long
      c_ticks2
       =15*System.TimeSpan.TicksPerHour
       +29*System.TimeSpan.TicksPerMinute
       +56*System.TimeSpan.TicksPerSecond
       +1234*1000;

     var recs=db.testTable.Where(r => r.DATA.Add((T_AMOUNT)new System.TimeSpan(1,2,3))==new T_DATA_U(c_ticks2) && r.TEST_ID==testID);

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowSelectedRow();
      }//foreach r

      TestServices.ThrowWeWaitError();
     }
     catch(structure_lib.exceptions.t_not_supported_exception exc)
     {
      CheckErrors.PrintException_OK(exc);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(exc));

      CheckErrors.CheckErrorRecord__sql_gen_err__translation_of_member_not_supported_in_current_cn_dialect_2
       (TestUtils.GetRecord(exc,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_Common__Sql_ETranslator__Dummy__MethodNotSupportedInCurrentCnDialect,
        1,
        "System.TimeOnly.Add(System.TimeSpan)");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_02

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext db,
                                               T_DATA    valueOfData)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.DATA=valueOfData;

  db.testTable.Add(newRecord);

  db.SaveChanges();

  db.CheckTextOfLastExecutedCommand
   (new TestSqlTemplate()
     .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_DATA).T(")").EOL()
     .T("VALUES (").P("p0").T(")").EOL()
     .T("RETURNING ").N("TEST_ID").EOL()
     .T("INTO ").P("p1").T(";"));

  Assert.IsTrue
   (newRecord.TEST_ID.HasValue);

  Console.WriteLine("TEST_ID: {0}",newRecord.TEST_ID.Value);

  return newRecord.TEST_ID.Value;
 }//Helper__InsertRow
};//class TestSet_001__fields__01__V

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.TimeOnly.SET001.STD.Add___TimeSpan
