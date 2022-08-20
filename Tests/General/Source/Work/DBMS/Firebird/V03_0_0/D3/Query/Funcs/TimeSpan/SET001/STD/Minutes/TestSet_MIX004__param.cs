////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 01.06.2021.
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.TimeSpan.SET001.STD.Minutes{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA  =System.String;

using T_TEST  =System.TimeSpan;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_MIX004__param

public static class TestSet_MIX004__param
{
 private const string c_NameOf__TABLE            ="DUAL";

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
 public static void Test_001__value()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA vv_src="09:12:34.1234";

     var recs=db.testTable.Where(r => ((T_TEST)(object)vv_src).Minutes==12);

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

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_001__value

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002__null()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA vv_src=null;

     var recs=db.testTable.Where(r => ((T_TEST)(object)vv_src).Minutes==12);

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

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_002__null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_E01__bad_src()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA vv_src="BLA-BLA-BLA";

     var recs=db.testTable.Where(r => ((T_TEST)(object)vv_src).Minutes==12);

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

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_E01__bad_src
};//class TestSet_MIX004__param

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.TimeSpan.SET001.STD.Minutes
