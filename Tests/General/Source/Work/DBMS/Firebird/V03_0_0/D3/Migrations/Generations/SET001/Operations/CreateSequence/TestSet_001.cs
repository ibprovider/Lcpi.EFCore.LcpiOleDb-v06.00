////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 05.11.2021.
using NUnit.Framework;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.CreateSequence{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001

public static class TestSet_001
{
 private const string c_NameOf_Sequence
  ="TEST_SEQ";

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001__no_params()
 {
  var operation
   =new EF_MnOP.CreateSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     IsCyclic         = true,
     ClrType          = typeof(long),
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("CREATE SEQUENCE ").N(c_NameOf_Sequence).T(";").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0001__no_params

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__start1()
 {
  var operation
   =new EF_MnOP.CreateSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     IsCyclic         = true,
     ClrType          = typeof(long),
     StartValue       = 1,
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("CREATE SEQUENCE ").N(c_NameOf_Sequence).T(";").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0002__start1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0003__start0()
 {
  var operation
   =new EF_MnOP.CreateSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     IsCyclic         = true,
     ClrType          = typeof(long),
     StartValue       = 0,
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("CREATE SEQUENCE ").N(c_NameOf_Sequence).T(" START WITH -1;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0003__start0

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0004__start2()
 {
  var operation
   =new EF_MnOP.CreateSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     IsCyclic         = true,
     ClrType          = typeof(long),
     StartValue       = 2,
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("CREATE SEQUENCE ").N(c_NameOf_Sequence).T(" START WITH 1;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_0004__start2

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_1001__incM1()
 {
  var operation
   =new EF_MnOP.CreateSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     IsCyclic         = true,
     ClrType          = typeof(long),
     IncrementBy      = -1,
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("CREATE SEQUENCE ").N(c_NameOf_Sequence).T(" START WITH 2 INCREMENT BY -1;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_1001__incM1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_1002__inc0()
 {
  var operation
   =new EF_MnOP.CreateSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     IsCyclic         = true,
     ClrType          = typeof(long),
     IncrementBy      = 0,
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("CREATE SEQUENCE ").N(c_NameOf_Sequence).T(" START WITH 1 INCREMENT BY 0;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_01002__inc0

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_1003__inc1()
 {
  var operation
   =new EF_MnOP.CreateSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     IsCyclic         = true,
     ClrType          = typeof(long),
     IncrementBy      = 1,
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("CREATE SEQUENCE ").N(c_NameOf_Sequence).T(";").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_1003__inc1

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_1004__inc2()
 {
  var operation
   =new EF_MnOP.CreateSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     IsCyclic         = true,
     ClrType          = typeof(long),
     IncrementBy      = 2,
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("CREATE SEQUENCE ").N(c_NameOf_Sequence).T(" START WITH -1 INCREMENT BY 2;").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_1004__inc2

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_2001__allowed_MinValue()
 {
  var operation
   =new EF_MnOP.CreateSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     IsCyclic         = true,
     ClrType          = typeof(long),
     MinValue         = long.MinValue,
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("CREATE SEQUENCE ").N(c_NameOf_Sequence).T(";").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_2001__allowed_MinValue

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_2002__allowed_MaxValue()
 {
  var operation
   =new EF_MnOP.CreateSequenceOperation
    {
     Name             = c_NameOf_Sequence,
     IsCyclic         = true,
     ClrType          = typeof(long),
     MaxValue         = long.MaxValue,
    };//operation

  //----------------------------------------
  var expectedSQL
   =new TestSqlTemplate()
     .T("CREATE SEQUENCE ").N(c_NameOf_Sequence).T(";").CRLF();

  TestHelper.Exec
   (new[]{operation},
    new[]{expectedSQL});
 }//Test_2002__allowed_MaxValue
};//class TestSet_001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.CreateSequence
