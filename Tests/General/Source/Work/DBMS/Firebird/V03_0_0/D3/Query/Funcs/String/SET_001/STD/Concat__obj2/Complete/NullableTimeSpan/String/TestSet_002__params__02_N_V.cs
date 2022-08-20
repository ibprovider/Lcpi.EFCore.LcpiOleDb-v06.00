////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 06.12.2021.
using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Concat__obj2.Complete.NullableTimeSpan.String{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1  =System.Nullable<System.TimeSpan>;
using T_DATA2  =System.String;

using T_DATA1_U=System.TimeSpan;
using T_DATA2_U=System.String;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_002__params__02_N_V

public static class TestSet_002__params__02_N_V
{
 private const string c_NameOf__TABLE="DUAL";

 //-----------------------------------------------------------------------
 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("ID")]
   public System.Int64? TEST_ID { get; set; }
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
  //
  // [2021-12-12]
  //
  //  The problem with this test will be resolved when we will remove/ignore
  //  cast to object in local evaluation.
  //
  //  Without this provider losts information about type (T_DATA1) of null.
  //
  //  Will be fixed in future :-)
  //
  // [2022-08-20]
  //
  //  Fixed.
  //

  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA1 vv1=null;
     T_DATA2 vv2="";

     var recs=db.testTable.Where(r => string.Concat(vv1,vv2)=="DOES NOT MATTER");

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowWeWaitError();
      }

      TestServices.ThrowWeWaitError();
     }
     catch(structure_lib.exceptions.t_invalid_operation_exception e)
     {
      CheckErrors.PrintException_OK(e);
   
      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e));
   
      CheckErrors.CheckErrorRecord__local_eval_err__binary_operator_not_supported_3
       (TestUtils.GetRecord(e,0),
        CheckErrors.c_src__EFCoreDataProvider__LcpiOleDb__LocalEval_Services__Extensions,
        xEFCore.LcpiOleDb__ExpressionType.Concat,
        "Nullable<System.TimeSpan>",
        "System.String");
   
      return;
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001
};//class TestSet_002__params__02_N_V

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Concat__obj2.Complete.NullableTimeSpan.String
