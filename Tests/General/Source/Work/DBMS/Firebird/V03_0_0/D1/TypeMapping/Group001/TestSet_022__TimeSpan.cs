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

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.TypeMapping.Group001{
////////////////////////////////////////////////////////////////////////////////

using T_DATA  =System.TimeSpan;
using T_DATA_U=System.TimeSpan;

using DB_TABLE=LocalDbObjNames.TEST_MODIFY_ROW_WD;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_022__TimeSpan

public static class TestSet_022__TimeSpan
{
 private const string c_NameOf__TABLE            =DB_TABLE.Name;
 private const string c_NameOf__COL_DATA         =DB_TABLE.Columns.COL_for_TimeSpan;
 
 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public class TEST_MODIFY_ROW_WD
  {
   [Key]
   [Column("TEST_ID")]
   public System.Int64 TEST_ID { get; set; }

   [Column(c_NameOf__COL_DATA)]
   public T_DATA COL_DATA { get; set; }
  };//class TEST_MODIFY_ROW_WD

  //----------------------------------------------------------------------
  public DbSet<TEST_MODIFY_ROW_WD> testTable { get; set; }

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
    object recID;

    using(var cmd=new xdb.OleDbCommand())
    {
     cmd.Connection=cn;
     cmd.Transaction=tr;

     cmd.CommandText
      ="insert into "+c_NameOf__TABLE+" ("+c_NameOf__COL_DATA+") values (3605.1234)\n"
      +"returning TEST_ID\n"
      +"INTO :TEST_ID";

     cmd.Parameters.Refresh();

     cmd.ExecuteNonQuery();

     recID=cmd["TEST_ID"].Value;
    }//using cmd

    using(var db=new MyContext(tr))
    {
     int nRecs=0;

     foreach(var rec in db.testTable.Where(r=>object.Equals(r.TEST_ID,recID)))
     {
      Assert.AreEqual(0,nRecs);

      ++nRecs;

      Assert.AreEqual(recID,rec.TEST_ID);
      Assert.AreEqual(new T_DATA_U(36051234L*1000),rec.COL_DATA);
     }//foreach

     Assert.AreEqual(1,nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__negative_value()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    object recID;

    using(var cmd=new xdb.OleDbCommand())
    {
     cmd.Connection=cn;
     cmd.Transaction=tr;

     cmd.CommandText
      ="insert into "+c_NameOf__TABLE+" ("+c_NameOf__COL_DATA+") values (-3605.1234)\n"
      +"returning TEST_ID\n"
      +"INTO :TEST_ID";

     cmd.Parameters.Refresh();

     cmd.ExecuteNonQuery();

     recID=cmd["TEST_ID"].Value;
    }//using cmd

    using(var db=new MyContext(tr))
    {
     int nRecs=0;

     foreach(var rec in db.testTable.Where(r=>object.Equals(r.TEST_ID,recID)))
     {
      Assert.AreEqual(0,nRecs);

      ++nRecs;

      Assert.AreEqual(recID,rec.TEST_ID);
      Assert.AreEqual(new T_DATA_U(-36051234L*1000),rec.COL_DATA);
     }//foreach

     Assert.AreEqual(1,nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_02__negative_value

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__min_valid_value()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    object recID;

    using(var cmd=new xdb.OleDbCommand())
    {
     cmd.Connection=cn;
     cmd.Transaction=tr;

     cmd.CommandText
      ="insert into "+c_NameOf__TABLE+" ("+c_NameOf__COL_DATA+")\n"
               //12345 6789
      +"values (-99999.9999)\n"
      +"returning TEST_ID\n"
      +"INTO :TEST_ID";

     cmd.Parameters.Refresh();

     cmd.ExecuteNonQuery();

     recID=cmd["TEST_ID"].Value;
    }//using cmd

    using(var db=new MyContext(tr))
    {
     int nRecs=0;

     foreach(var rec in db.testTable.Where(r=>object.Equals(r.TEST_ID,recID)))
     {
      Assert.AreEqual(0,nRecs);

      ++nRecs;

      Assert.AreEqual(recID,rec.TEST_ID);
                                  //123456789
      Assert.AreEqual(new T_DATA_U(-999999999L*1000),rec.COL_DATA);
     }//foreach

     Assert.AreEqual(1,nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_03__min_valid_value

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__max_valid_value()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    object recID;

    using(var cmd=new xdb.OleDbCommand())
    {
     cmd.Connection=cn;
     cmd.Transaction=tr;

     cmd.CommandText
      ="insert into "+c_NameOf__TABLE+" ("+c_NameOf__COL_DATA+")\n"
               //12345 6789
      +"values (+99999.9999)\n"
      +"returning TEST_ID\n"
      +"INTO :TEST_ID";

     cmd.Parameters.Refresh();

     cmd.ExecuteNonQuery();

     recID=cmd["TEST_ID"].Value;
    }//using cmd

    using(var db=new MyContext(tr))
    {
     int nRecs=0;

     foreach(var rec in db.testTable.Where(r=>object.Equals(r.TEST_ID,recID)))
     {
      Assert.AreEqual(0,nRecs);

      ++nRecs;

      Assert.AreEqual(recID,rec.TEST_ID);
                                  //123456789
      Assert.AreEqual(new T_DATA_U(+999999999L*1000),rec.COL_DATA);
     }//foreach

     Assert.AreEqual(1,nRecs);
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_04__max_valid_value

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ERR01__MAX_NEGATIVE_invalid_value()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    object recID;

    using(var cmd=new xdb.OleDbCommand())
    {
     cmd.Connection=cn;
     cmd.Transaction=tr;

     cmd.CommandText
      ="insert into "+c_NameOf__TABLE+" ("+c_NameOf__COL_DATA+")\n"
                //12345 6789
      +"values (-100000.0000)\n"
      +"returning TEST_ID\n"
      +"INTO :TEST_ID";

     cmd.Parameters.Refresh();

     cmd.ExecuteNonQuery();

     recID=cmd["TEST_ID"].Value;
    }//using cmd

    using(var db=new MyContext(tr))
    {
     try
     {
      foreach(var rec in db.testTable.Where(r=>object.Equals(r.TEST_ID,recID)))
      {
       TestServices.ThrowSelectedRow();
      }

      TestServices.ThrowWeWaitError();
     }
     catch(xEFCore.LcpiOleDb__DataToolException e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__type_mapping_err__cant_convert_database_value_to_TimeSpan__out_of_range__4
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_Common__ValueConversion__TimeSpanToDecimal9_4,
        "-100000.0000",
        "NUMERIC(9,4)",
        "-99999.9999",
        "99999.9999");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_ERR01__MAX_NEGATIVE_invalid_value

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ERR02__MIN_POSITIVE_invalid_value()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    object recID;

    using(var cmd=new xdb.OleDbCommand())
    {
     cmd.Connection=cn;
     cmd.Transaction=tr;

     cmd.CommandText
      ="insert into "+c_NameOf__TABLE+" ("+c_NameOf__COL_DATA+")\n"
                //12345 6789
      +"values (+100000.0000)\n"
      +"returning TEST_ID\n"
      +"INTO :TEST_ID";

     cmd.Parameters.Refresh();

     cmd.ExecuteNonQuery();

     recID=cmd["TEST_ID"].Value;
    }//using cmd

    using(var db=new MyContext(tr))
    {
     try
     {
      foreach(var rec in db.testTable.Where(r=>object.Equals(r.TEST_ID,recID)))
      {
       TestServices.ThrowSelectedRow();
      }

      TestServices.ThrowWeWaitError();
     }
     catch(xEFCore.LcpiOleDb__DataToolException e)
     {
      CheckErrors.PrintException_OK(e);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));

      CheckErrors.CheckErrorRecord__type_mapping_err__cant_convert_database_value_to_TimeSpan__out_of_range__4
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__FB_Common__ValueConversion__TimeSpanToDecimal9_4,
        "100000.0000",
        "NUMERIC(9,4)",
        "-99999.9999",
        "99999.9999");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_ERR02__MIN_POSITIVE_invalid_value
};//class TestSet_022__TimeSpan

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.TypeMapping.Group001
