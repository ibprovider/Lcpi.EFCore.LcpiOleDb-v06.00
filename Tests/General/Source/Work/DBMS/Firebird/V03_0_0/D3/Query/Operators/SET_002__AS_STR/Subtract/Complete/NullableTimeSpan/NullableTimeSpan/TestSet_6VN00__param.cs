////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 23.03.2021.
using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_002__AS_STR.Subtract.Complete.NullableTimeSpan.NullableTimeSpan{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1   =System.Nullable<System.TimeSpan>;
using T_DATA2   =System.Nullable<System.TimeSpan>;

using T_DATA1_U =System.TimeSpan;
using T_DATA2_U =System.TimeSpan;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_6VN00__param

public static class TestSet_6VN00__param
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
     T_DATA1 vv1=new T_DATA1_U(0,18,27,32).Add(new System.TimeSpan(1000));
     T_DATA2 vv2=null;

     var recs=db.testTable.Where(r => (string)(object)(vv1-vv2)==null);

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
        "Nullable<System.TimeSpan>",
        "System.String");
     }//catch
    }//using db

    tr.Commit();
   }//using tr
  }//using cn
 }//Test_001

};//class TestSet_6VN00__param

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Query.Operators.SET_002__AS_STR.Subtract.Complete.NullableTimeSpan.NullableTimeSpan
