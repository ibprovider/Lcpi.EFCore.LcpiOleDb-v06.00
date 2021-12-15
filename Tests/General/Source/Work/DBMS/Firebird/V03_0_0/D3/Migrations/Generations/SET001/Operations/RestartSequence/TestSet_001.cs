////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 07.11.2021.
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.RestartSequence{
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
   =new EF_MnOP.RestartSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     StartValue       = 2
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER SEQUENCE ").N(c_NameOf_Sequence).T(" RESTART WITH 2;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__minValue()
 {
  var operation
   =new EF_MnOP.RestartSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     StartValue       = long.MinValue
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER SEQUENCE ").N(c_NameOf_Sequence).T(" RESTART WITH -9223372036854775808;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0002__minValue

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0003__maxValue()
 {
  var operation
   =new EF_MnOP.RestartSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     StartValue       = long.MaxValue
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("ALTER SEQUENCE ").N(c_NameOf_Sequence).T(" RESTART WITH 9223372036854775807;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0003__maxValue
};//class TestSet_001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.RestartSequence
