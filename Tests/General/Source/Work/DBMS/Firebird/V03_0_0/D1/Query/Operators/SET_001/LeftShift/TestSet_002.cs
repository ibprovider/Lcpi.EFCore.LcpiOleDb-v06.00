////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 20.11.2020.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_001.LeftShift{
////////////////////////////////////////////////////////////////////////////////

/*******************************************************************************

FIREBIRD RULES FOR BIN_SHL(value,count):
 - check: count>=0
 - count=count mod 64
 - return value<<count;

EXECUTE BLOCK
RETURNS (N INTEGER, SHL BIGINT)
AS
DECLARE VARIABLE I INTEGER;
BEGIN
 N=0;
 WHILE(N<256)DO
 BEGIN
  SHL=BIN_SHL(1,N);
  SUSPEND;
  N=N+1;
 END
END

*******************************************************************************/

////////////////////////////////////////////////////////////////////////////////

using T_DATA1=System.Int32;
using T_DATA2=System.Int32;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_002

public static class TestSet_002
{
 private const string c_NameOf__TABLE       ="TEST_MODIFY_ROW2";
 private const string c_NameOf__COL_DATA1   ="COL_INTEGER";
 private const string c_NameOf__COL_DATA2   ="COL2_INTEGER";

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
 public static void Test_001__positive_shift()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1 c_value1=5;
     const T_DATA2 c_value2=3;

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     // 0x00000101<<3 == 0x00101000 == 8+32 == 40

     Assert.AreEqual
      (40,
       c_value1<<c_value2);

     var recs=db.testTable.Where(r => (r.COL_DATA1<<r.COL_DATA2)==40 && r.TEST_ID==testID);

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
       (testID,
        r.TEST_ID.Value);

      Assert.AreEqual
       (c_value1,
        r.COL_DATA1);

      Assert.AreEqual
       (c_value2,
        r.COL_DATA2);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
       .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
       .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
       .T("WHERE (BIN_SHL(").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).T(") = 40) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001__positive_shift

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__p128p48()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     const T_DATA1 c_value1=1;
     const T_DATA2 c_value2=128+48;

     System.Int64? testID=Helper__InsertRow(db,c_value1,c_value2);

     Assert.AreEqual
      (0x10000,               // <--- ACHTUNG!
       c_value1<<c_value2);

#pragma warning disable CS0652
     var recs=db.testTable.Where(r => (r.COL_DATA1<<r.COL_DATA2)==281474976710656L && r.TEST_ID==testID); // <--- ACHTUNG!
#pragma warning restore CS0652

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
       (testID,
        r.TEST_ID.Value);

      Assert.AreEqual
       (c_value1,
        r.COL_DATA1);

      Assert.AreEqual
       (c_value2,
        r.COL_DATA2);
     }//foreach r

     var sqlt
      =new TestSqlTemplate()
       .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).EOL()
       .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
       .T("WHERE (BIN_SHL(").N("t",c_NameOf__COL_DATA1).T(", ").N("t",c_NameOf__COL_DATA2).T(") = 281474976710656) AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")");

     db.CheckTextOfLastExecutedCommand
      (sqlt);

     Assert.AreEqual
      (1,
       nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__p128p48

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext db,
                                               T_DATA1   valueForColData1,
                                               T_DATA2   valueForColData2)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.COL_DATA1 =valueForColData1;
  newRecord.COL_DATA2 =valueForColData2;

  db.testTable.Add(newRecord);

  db.SaveChanges();

  db.CheckTextOfLastExecutedCommand
   (new TestSqlTemplate()
     .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_DATA1).T(", ").N(c_NameOf__COL_DATA2).T(")").EOL()
     .T("VALUES (").P("p0").T(", ").P("p1").T(")").EOL()
     .T("RETURNING ").N("TEST_ID").EOL()
     .T("INTO ").P("p2").T(";"));

  Assert.IsTrue
   (newRecord.TEST_ID.HasValue);

  Console.WriteLine("TEST_ID: {0}",newRecord.TEST_ID.Value);

  return newRecord.TEST_ID.Value;
 }//Helper__InsertRow
};//class TestSet_002

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Operators.SET_001.LeftShift
