////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 16.11.2021.
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Model.Validation.SET_001{
////////////////////////////////////////////////////////////////////////////////

using T_ID  =System.Int64;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__FB_does_not_support_schemas

public static class TestSet_001__FB_does_not_support_schemas
{
 private const string c_NameOf__Table                 = "DUMMY_TEST_TABLE";
 private const string c_NameOf__Schema                = "DUMMY_TEST_SCHEMA";

 private const string c_NameOf__COL__ID               = "TEST_ID";

 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__Table, Schema=c_NameOf__Schema)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column(c_NameOf__COL__ID)]
   public T_ID TEST_ID { get; set; }
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
    try
    {
     using(var db=new MyContext(tr))
     {
      TestServices.ThrowWeWaitError();
     }
    }
    catch(xEFCore.LcpiOleDb__DataToolException e)
    {
     CheckErrors.PrintException_OK(e);

     Assert.AreEqual
      (2,
       TestUtils.GetRecordCount(e));

     CheckErrors.CheckErrorRecord__dbms_err__fb__firebird_does_not_support_schemas__0
      (TestUtils.GetRecord(e,0),
       CheckErrors.c_src__EFCoreDataProvider__Basement_EF_Dbms_Firebird_V03_0_0_Infrastructure___FB_V03_0_0__ModelValidator);

     CheckErrors.CheckErrorRecord__validation_err__failed_to_entity_validation_1
      (TestUtils.GetRecord(e,1),
       CheckErrors.c_src__EFCoreDataProvider__Basement_EF_Dbms_Firebird_V03_0_0_Infrastructure___FB_V03_0_0__ModelValidator,
       "TEST_RECORD");
    }//catch

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_001
};//class TestSet_001__FB_does_not_support_schemas

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Model.Validation.SET_001
