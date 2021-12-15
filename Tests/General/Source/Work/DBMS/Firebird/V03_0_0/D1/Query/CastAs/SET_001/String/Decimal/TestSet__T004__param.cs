////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 03.03.2021.
//
// (bool)string_column==bool_column
//
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.CastAs.SET_001.String.Decimal{
////////////////////////////////////////////////////////////////////////////////

using T_SOURCE_VALUE=System.String;
using T_TARGET_VALUE=System.Decimal;

////////////////////////////////////////////////////////////////////////////////
//class TestSet__T004__param

public static class TestSet__T004__param
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
 private struct tagData001
 {
  public readonly T_SOURCE_VALUE  SourceValue;
  public readonly T_TARGET_VALUE TargetValue;

  public tagData001(T_SOURCE_VALUE  sourceValue,
                    T_TARGET_VALUE targetValue)
  {
   this.SourceValue=sourceValue;
   this.TargetValue=targetValue;
  }//tagData001
 };//struct tagData001

 //-----------------------------------------------------------------------
 private static readonly tagData001[]
  sm_Data001
   =new tagData001[]
     {
      new tagData001(".1"         ,0.1m),

      new tagData001("1"          ,1),
      new tagData001("-1"         ,-1),
      new tagData001("+1"         ,1),

      new tagData001(".12E2"      ,12),
      new tagData001(".12E+2"     ,12),
      new tagData001(".12E-2"     ,0.0012m),

      new tagData001("123E-2"     ,1.23m),
      new tagData001("123.E-2"    ,1.23m),

      new tagData001("0.0000000000E-1024"  ,0),
      //new tagData001("0.0000000000E+1024"  ,0),
      new tagData001("0.0000000000E1024"  ,0.0000000000E1024m),

      new tagData001("   1   "     ,1),
      new tagData001("   -1  "     ,-1),
      new tagData001("   +1  "     ,1),

      new tagData001("1000000000000000000000000000000E-30"     ,1),
      new tagData001("1000000000000000000000000000001E-30"     ,1),
      new tagData001("1000000000000000000000000000009E-30"     ,1),
      new tagData001("00000000000000000000000000000.000000001" ,0.000000001m),
      new tagData001("1.00000000000000000000000000000000000000000000000000000000000" ,1),

      new tagData001(".1E-2147483647"  ,0),
      new tagData001("1E-2147483648"   ,0),
      new tagData001("1.E-2147483648"  ,0),
      new tagData001("10.E-2147483648" ,0),

      new tagData001("0.E2147483647"   ,0),
      new tagData001("0.E+2147483647"  ,0),
      new tagData001("0.E-2147483647"  ,0),
      new tagData001("0.E-2147483648"  ,0),
     };//sm_Data001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_001__OK()
 {
  using(var cn=LocalCnHelper.CreateCn__UTF8())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     for(int iData=0;iData!=sm_Data001.Length;++iData)
     {
      var testData=sm_Data001[iData];

      try
      {
       T_SOURCE_VALUE vv=testData.SourceValue;

       T_TARGET_VALUE vv2=testData.TargetValue;
       
       var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)vv==vv2);
       
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
         (1,
          r.TEST_ID.Value);
       }//foreach r
       
     db.CheckTextOfLastExecutedCommand
      (new TestSqlTemplate()
        .T("SELECT ").N("d","ID").EOL()
        .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
        .T("WHERE ").P_BOOL("__Exec_V_V_0"));
       
       Assert.AreEqual
        (1,
         nRecs);
      }
      catch(Exception e)
      {
       var msg
        =string.Format
          ("Failed to process test data [{0}] - \"{1}\".",
           iData,
           testData.SourceValue);

       throw new System.ApplicationException(msg,e);
      }//catch

      tr.RollbackRetaining();
     }//for iData
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001__OK

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__ERR()
 {
  string[] testDataArray
   =new string[]
    {
     "",
     " ",
     "\t",
     "\r",
     "\n",
     "\0",
     " 1.1.1 ",

     "1\0",
     "\t1",
     "1\t",
     "\r1",
     "1\r",
     "\n1",
     "1\n",
     "1E--",
     "1E-",
     "1-",
     "+",
     "-",
     ".E+1",
     "11..",

     "😚",      // <----- !!!
    }; //testDataArray

  //------------------------------------------------------------
  using(var cn=LocalCnHelper.CreateCn__UTF8())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     for(int iData=0;iData!=testDataArray.Length;++iData)
     {
      var testData=testDataArray[iData];

      Console.WriteLine("------------------------------------- [{0}]", iData);

      T_SOURCE_VALUE vv=testData;

      try
      {
       var recs=db.testTable.Where(r => (T_TARGET_VALUE)(object)vv==0);
       
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

       Assert.IsInstanceOf<lcpi.lib.structure.exceptions.t_invalid_operation_exception>
        (e.InnerException);

       var e2=(lcpi.lib.structure.exceptions.t_invalid_operation_exception)(e.InnerException);

       Assert.AreEqual
        (1,
         TestUtils.GetRecordCount(e2));

       CheckErrors.CheckErrorRecord__common_err__cant_convert_value_between_types_2
        (TestUtils.GetRecord(e2,0),
         CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Cvt_Code__String__NullableDecimal,
         lcpi.lib.com.HResultCode.DB_E_CANTCONVERTVALUE,
         typeof(string),
         typeof(decimal));
      }//catch

      tr.RollbackRetaining();
     }//for iData
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_002__ERR
};//class TestSet__T004__param

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.CastAs.SET_001.String.Decimal
