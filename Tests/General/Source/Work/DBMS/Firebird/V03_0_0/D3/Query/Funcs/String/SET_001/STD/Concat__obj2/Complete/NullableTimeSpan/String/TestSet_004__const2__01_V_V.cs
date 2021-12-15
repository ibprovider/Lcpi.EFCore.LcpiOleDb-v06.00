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

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Concat__obj2.Complete.NullableTimeSpan.String{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1  =System.Nullable<System.TimeSpan>;
using T_DATA2  =System.String;

using T_DATA1_U=System.TimeSpan;
using T_DATA2_U=System.String;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_004__const2__01_V_V

public static class TestSet_004__const2__01_V_V
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
     var recs=db.testTable.Where(r => string.Concat(new T_DATA1(new T_DATA1_U(T_DATA1_U.TicksPerSecond)),(T_DATA2)"")=="DOES NOT MATTER");

     try
     {
      foreach(var r in recs)
      {
       TestServices.ThrowWeWaitError();
      }

      TestServices.ThrowWeWaitError();
     }
     catch(InvalidOperationException e)
     {
      CheckErrors.PrintException_OK
       (e);

      Assert.NotNull
       (e.InnerException);

      Assert.IsInstanceOf<structure_lib.exceptions.t_invalid_operation_exception>
       (e.InnerException);

      var e2
       =(structure_lib.exceptions.t_invalid_operation_exception)e.InnerException;

      Assert.NotNull
       (e2);

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e2));

      CheckErrors.CheckErrorRecord__common_err__unsupported_datatypes_conversion_2
       (TestUtils.GetRecord(e2,0),
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_MasterCode__Object__ToString,
        "System.TimeSpan",
        "System.String");
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001
};//class TestSet_004__const2__01_V_V

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Concat__obj2.Complete.NullableTimeSpan.String
