////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 28.05.2018.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.TypeMapping.Group002.TimeSpan{
////////////////////////////////////////////////////////////////////////////////

using TEST_COL_TYPE  =System.Nullable<System.TimeSpan>;
using TEST_COL_TYPE_U=System.TimeSpan;

using DB_TABLE=LocalDbObjNames.TEST_MODIFY_ROW_WD;

////////////////////////////////////////////////////////////////////////////////
//class TestSet__TimeSpan

public static class TestSet__TimeSpan
{
 private const string c_NameOf__TABLE            =DB_TABLE.Name;
 private const string c_NameOf__COL_DATA         =DB_TABLE.Columns.COL_for_TimeSpan;
 
 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("TEST_ID")]
   public Int64? TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA)]
   public TEST_COL_TYPE TEST_COL { get; set; }
  };//class TEST_RECORD

  //----------------------------------------------------------------------
  public DbSet<TEST_RECORD> testTable { get; set; }

  //----------------------------------------------------------------------
  public MyContext(xdb.OleDbTransaction tr)
   :base(tr)
  {
  }//MyContext

  //----------------------------------------------------------------------
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
   modelBuilder
    .Entity<TEST_RECORD>()
    .Property(b => b.TEST_COL)
    .HasDefaultValue();
  }//OnModelCreating
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
                                     //12345 1234
    const decimal c_columnDefaultValue=99999.9999m;

    Int64 recID;
                                            //123451234
    TEST_COL_TYPE recData=new TEST_COL_TYPE_U((long)(c_columnDefaultValue*10000*1000));

    var cmd=new xdb.OleDbCommand("",cn,tr);

    using(var db=new MyContext(tr))
    {
     var newRec=new MyContext.TEST_RECORD();

     db.testTable.Add(newRec);

     var nChanges=db.SaveChanges();

     Assert.AreEqual(1,nChanges);

     Assert.NotNull(newRec.TEST_ID);

     Assert.NotNull(newRec.TEST_COL);

     Assert.AreEqual(recData,newRec.TEST_COL);

     recID=newRec.TEST_ID.Value;
    }//using db

    //------------------
    cmd.CommandText="select "+c_NameOf__COL_DATA+" from "+c_NameOf__TABLE+" where TEST_ID="+recID.ToString();

    var rd=cmd.ExecuteReader();

    Assert.IsTrue(rd.Read());

    Assert.AreEqual(c_columnDefaultValue,rd.GetDecimal(0));

    Assert.IsFalse(rd.Read());

    using(var db=new MyContext(tr))
    {
     var recs=db.testTable.Where(r => r.TEST_ID==recID && r.TEST_COL==recData);

     int nRecs=0;

     foreach(var rec in recs)
     {
      Assert.AreEqual(0,nRecs);

      ++nRecs;

      Assert.AreEqual(recID,rec.TEST_ID);

      Assert.AreEqual(recData,rec.TEST_COL);
     }//foreach

     Assert.AreEqual(1,nRecs);
    }//using
   }//using tr
  }//using cn
 }//Test_01
};//class TestSet__TimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.TypeMapping.Group002.TimeSpan
