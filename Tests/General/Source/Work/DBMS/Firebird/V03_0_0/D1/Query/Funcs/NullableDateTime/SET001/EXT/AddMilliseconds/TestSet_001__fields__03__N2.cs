////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 26.07.2021.
//
// <field>.AddMilliseconds(...)
//
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.NullableDateTime.SET001.EXT.AddMilliseconds{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA  =System.Nullable<System.DateTime>;
using T_DATA_U=System.DateTime;

using T_AMOUNT=System.Nullable<System.Double>;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__fields__03__N2

public static class TestSet_001__fields__03__N2
{
 private const string c_NameOf__TABLE="TEST_MODIFY_ROW";

 private const string c_NameOf__COL_DATA="COL_TIMESTAMP";

 private const string c_NameOf__COL_AMOUNT="COL_DOUBLE";

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

   [Column(c_NameOf__COL_AMOUNT)]
   public T_AMOUNT AMOUNT { get; set; }
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
     T_DATA c_data=new T_DATA_U(2021,7,26,14,27,53).AddTicks(1000+1);

     System.Int64? testID=Helper__InsertRow(db,c_data,null);

     //var c_ticks2
     // =new T_DATA_U(2021,7,27,14,27,53).AddTicks(1000).Ticks;

     const long c_ticks
      =637629928730001000+2;

     var recs=db.testTable.Where(r => r.DATA.AddMilliseconds((T_AMOUNT)r.AMOUNT)==new T_DATA_U(c_ticks) && r.TEST_ID==testID);

     foreach(var r in recs)
     {
      TestServices.ThrowSelectedRow();
     }//foreach r

     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("t","TEST_ID").T(", ").N("t",c_NameOf__COL_AMOUNT).T(", ").N("t",c_NameOf__COL_DATA).EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("t").EOL()
        .T("WHERE (DATEADD(MILLISECOND,").N("t",c_NameOf__COL_AMOUNT).T(",").N("t",c_NameOf__COL_DATA).T(") = timestamp '2021-07-27 14:27:53.0001') AND (").N("t","TEST_ID").T(" = ").P_ID("__testID_0").T(")"));
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_01

 //-----------------------------------------------------------------------
 private static System.Int64 Helper__InsertRow(MyContext db,
                                               T_DATA    valueOfData,
                                               T_AMOUNT  valueOfAmount)
 {
  var newRecord=new MyContext.TEST_RECORD();

  newRecord.DATA=valueOfData;

  newRecord.AMOUNT=valueOfAmount;

  db.testTable.Add(newRecord);

  db.SaveChanges();

  db.CheckTextOfLastExecutedCommand
   (new TestSqlTemplate()
     .T("INSERT INTO ").N(c_NameOf__TABLE).T(" (").N(c_NameOf__COL_AMOUNT).T(", ").N(c_NameOf__COL_DATA).T(")").EOL()
     .T("VALUES (").P("p0").T(", ").P("p1").T(")").EOL()
     .T("RETURNING ").N("TEST_ID").EOL()
     .T("INTO ").P("p2").T(";"));

  Assert.IsTrue
   (newRecord.TEST_ID.HasValue);

  Console.WriteLine("TEST_ID: {0}",newRecord.TEST_ID.Value);

  return newRecord.TEST_ID.Value;
 }//Helper__InsertRow
};//class TestSet_001__fields__03__N2

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.NullableDateTime.SET001.EXT.AddMilliseconds
