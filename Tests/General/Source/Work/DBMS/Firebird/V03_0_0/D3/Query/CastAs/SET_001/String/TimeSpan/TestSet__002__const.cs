////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 17.02.2021.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.String.TimeSpan{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE_VALUE=System.String;
using T_TARGET_VALUE=System.TimeSpan;

using DB_TABLE=LocalDbObjNames.TEST_MODIFY_ROW2;

////////////////////////////////////////////////////////////////////////////////
//class TestSet__002__const

public static class TestSet__002__const
{
 private const string c_NameOf__TABLE=DB_TABLE.Name;

 private const string c_NameOf__COL_SOURCE="COL_VARCHAR_32";
 private const string c_NameOf__COL_TARGET=DB_TABLE.Columns.COL2_for_TimeSpan;

 private const string c_NameOf__TARGET_SQL_TYPE="TIME";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_SOURCE,TypeName="VARCHAR(32)")]
   public T_SOURCE_VALUE COL_SOURCE { get; set; }

   [Column(c_NameOf__COL_TARGET)]
   public T_TARGET_VALUE COL_TARGET { get; set; }
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
     const long c_TicksInMicroSec=1000;
     const long c_TicksInSec     =c_TicksInMicroSec*10*1000;
     const long c_TicksInMin     =c_TicksInSec*60;
     const long c_TicksInHour    =c_TicksInMin*60;

     const long c_srcTicks=c_TicksInHour*1+c_TicksInMin*2+c_TicksInSec*3+c_TicksInMicroSec*4321;

     const T_SOURCE_VALUE c_valueSource="01:02:03.4321";
           T_TARGET_VALUE c_valueTarget=new System.TimeSpan(c_srcTicks);

     System.Int64? testID=Helper__InsertRow(db,c_valueSource,c_valueTarget);

     var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)c_valueSource==r.COL_TARGET && r.TEST_ID==testID);

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

      CheckErrors.CheckErrorRecord__BugCheck__LocalEvalErr__unsupported_conversion
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__Basement_EF_Root_Query_Local_Expressions_Unary_Translators_ETranslator__Convert,
        "ETranslator__Convert::Translate",
        "#002",
        "System.String",
        "Nullable<System.TimeSpan>");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext      db,
                                               T_SOURCE_VALUE valueForColSource,
                                               T_TARGET_VALUE valueForColTarget)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.COL_SOURCE =valueForColSource;
  newRecord.COL_TARGET =valueForColTarget;

  db.testTable.Add(newRecord);

  db.SaveChanges();

  db.CheckTextOfLastExecutedCommand
   (new TestSqlTemplate()
     .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_SOURCE).T(", ").N(c_NameOf__COL_TARGET).T(")").EOL()
     .T("VALUES (").P("p0").T(", ").P("p1").T(")").EOL()
     .T("RETURNING ").N("TEST_ID").EOL()
     .T("INTO ").P("p2").T(";"));

  Assert.IsTrue
   (newRecord.TEST_ID.HasValue);

  Console.WriteLine("TEST_ID: {0}",newRecord.TEST_ID.Value);

  return newRecord.TEST_ID.Value;
 }//Helper__InsertRow
};//class TestSet__002__const

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.CastAs.SET_001.String.TimeSpan
