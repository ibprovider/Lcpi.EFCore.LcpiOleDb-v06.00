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
//class TestSet_002__params__01_V_V

public static class TestSet_002__params__01_V_V
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
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
    T_DATA1 vv1=new T_DATA1_U(T_DATA1_U.TicksPerSecond);
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
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001
};//class TestSet_002__params__01_V_V

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Concat__obj2.Complete.NullableTimeSpan.String
