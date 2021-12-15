////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 12.10.2018.
//
// <field>.Substring(<expression with startIndex>)
//
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.DataTypes.Extensions;

using xdb=lcpi.data.oledb;

using exceptions_lib=lcpi.lib.structure.exceptions;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Substring__startIndex{
////////////////////////////////////////////////////////////////////////////////
//using

using T_DATA=System.String;

////////////////////////////////////////////////////////////////////////////////
//class TestSet___err

public static class TestSet___err
{
 private sealed class MyContext:TestBaseDbContext
 {
  [Table("DUAL")]
  public sealed class DUAL
  {
   [Key]
   [Column("ID")]
   public System.Int32 ID { get; set; }
  };//class DUAL

  //----------------------------------------------------------------------
  public DbSet<DUAL> dualTable { get; set; }

  //----------------------------------------------------------------------
  public MyContext(xdb.OleDbTransaction tr)
   :base(tr)
  {
  }//MyContext
 };//class MyContext

 //-----------------------------------------------------------------------
 [Test]
 public static void Test___ByEF___002__negative_startIndex()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     T_DATA vvs=null;

     int? vv_startIndex=-1;

     var recs=db.dualTable.Where(r => vvs.Substring(vv_startIndex)=="SDFGH");

     try
     {
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

      Assert.IsInstanceOf<exceptions_lib.t_argument_out_of_range_exception>
       (e.InnerException);

      var e1=(exceptions_lib.t_argument_out_of_range_exception)e.InnerException;

      Assert.AreEqual
       (1,
        TestUtils.GetRecordCount(e1));

      CheckErrors.CheckException__ArgumentOutOfRange__negative_value
       (e1,
        CheckErrors.c_src__EFCoreDataProvider__Root_Query_Local_Expressions__Method_Code__String__Substring___nullableStartIndex,
        "Exec",
        "startIndex",
        -1);
     }//catch
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test___ByEF___001__negative_startIndex

};//class TestSet___err

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Funcs.String.SET_001.STD.Substring__startIndex
