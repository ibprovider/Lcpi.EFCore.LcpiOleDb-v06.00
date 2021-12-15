////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 07.11.2021.
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AlterSequence{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001

public static class TestSet_001
{
 private const string c_NameOf_Sequence
  ="TEST_SEQ";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001()
 {
  var operation
   =new EF_MnOP.AlterSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     IsCyclic         = true,
     IncrementBy      = 2
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER SEQUENCE ").N(c_NameOf_Sequence).T(" INCREMENT BY 2;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_2001__allowed_MinValue()
 {
  var operation
   =new EF_MnOP.AlterSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     IsCyclic         = true,
     IncrementBy      = 2,
     MinValue         = long.MinValue,
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER SEQUENCE ").N(c_NameOf_Sequence).T(" INCREMENT BY 2;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_2001__allowed_MinValue

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_2002__allowed_MaxValue()
 {
  var operation
   =new EF_MnOP.AlterSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     IsCyclic         = true,
     IncrementBy      = 2,
     MaxValue         = long.MaxValue,
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER SEQUENCE ").N(c_NameOf_Sequence).T(" INCREMENT BY 2;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_2002__allowed_MaxValue
};//class TestSet_001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AlterSequence
