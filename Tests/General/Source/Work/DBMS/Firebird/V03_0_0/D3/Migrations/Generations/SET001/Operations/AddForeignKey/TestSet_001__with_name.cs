////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 03.11.2021.
using System;
using NUnit.Framework;

using EF_Mn
 =Microsoft.EntityFrameworkCore.Migrations;

using EF_MnOP
 =Microsoft.EntityFrameworkCore.Migrations.Operations;

using structure_lib
 =lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AddForeignKey{
////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__with_name

public static class TestSet_001__with_name
{
 private const string c_NameOf_MasterTable
  ="MASTER_TABLE";

 private const string c_NameOf_MasterTable_PkCol1
  ="ID";

 private const string c_NameOf_MasterTable_PkCol2
  ="CLASS";

 private const string c_NameOf_DetailTable
  ="DETAIL_TABLE";

 private const string c_NameOf_DetailTable_FkCol1
  ="MASTER_ID";

 private const string c_NameOf_DetailTable_FkCol2
  ="MASTER_CLASS";

 private const string c_NameOf_FK
  ="FK_DETAIL_MASTER";

 //-----------------------------------------------------------------------
 private static readonly System.Tuple<EF_Mn.ReferentialAction,string>[]
  sm_Actions
   =new []
    {
     new System.Tuple<EF_Mn.ReferentialAction,string>
      (EF_Mn.ReferentialAction.Restrict,
       null),

     new System.Tuple<EF_Mn.ReferentialAction,string>
      (EF_Mn.ReferentialAction.NoAction,
       "NO ACTION"),

     new System.Tuple<EF_Mn.ReferentialAction,string>
      (EF_Mn.ReferentialAction.Cascade,
       "CASCADE"),

     new System.Tuple<EF_Mn.ReferentialAction,string>
      (EF_Mn.ReferentialAction.SetNull,
       "SET NULL"),

     new System.Tuple<EF_Mn.ReferentialAction,string>
      (EF_Mn.ReferentialAction.SetDefault,
       "SET DEFAULT"),
    };//sm_Actions

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0001__one_column__complete()
 {
  var operation
   =new EF_MnOP.AddForeignKeyOperation
    {
     Table            = c_NameOf_DetailTable,
     Name             = c_NameOf_FK,
     Columns          = new[] { c_NameOf_DetailTable_FkCol1 },
     PrincipalTable   = c_NameOf_MasterTable,
     PrincipalColumns = new[] { c_NameOf_MasterTable_PkCol1 },
    };//operation

  //------------------------------------------------------------
  var it
   =new structure_lib.DimensionIterator
    (
     new structure_lib.DimensionBounds(0,sm_Actions.Length-1),
     new structure_lib.DimensionBounds(0,sm_Actions.Length-1)
    );

  int n=0;

  for(it.Restart();it.Ok;it.Next(),++n)
  {
   var onUpdate
    =sm_Actions[it.Point[0]];

   var onDelete
    =sm_Actions[it.Point[1]];

   Console.WriteLine("------------------------------------------- [{0}] {1}, {2}",n,onUpdate.Item1,onDelete.Item1);

   //---------------------------------------
   operation.OnUpdate
    =onUpdate.Item1;

   operation.OnDelete
    =onDelete.Item1;

   //---------------------------------------
   var expectedSQL
    =new TestSqlTemplate()
      .T("ALTER TABLE ").N(c_NameOf_DetailTable).T(" ADD CONSTRAINT ").N(c_NameOf_FK).T(" ")
      .T("FOREIGN KEY (").N(c_NameOf_DetailTable_FkCol1).T(") ")
      .T("REFERENCES ").N(c_NameOf_MasterTable).T(" (").N(c_NameOf_MasterTable_PkCol1).T(")");

   if(!Object.ReferenceEquals(onUpdate.Item2,null))
    expectedSQL=expectedSQL.T(" ON UPDATE "+onUpdate.Item2);

   if(!Object.ReferenceEquals(onDelete.Item2,null))
    expectedSQL=expectedSQL.T(" ON DELETE "+onDelete.Item2);

   expectedSQL
    =expectedSQL.T(";").CRLF();

   TestHelper.Exec
    (new[]{operation},
     new[]{expectedSQL});
  }//for it
 }//Test_0001__one_column__complete

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_0002__two_columns__complete()
 {
  var operation
   =new EF_MnOP.AddForeignKeyOperation
    {
     Table            = c_NameOf_DetailTable,
     Name             = c_NameOf_FK,
     Columns          = new[] { c_NameOf_DetailTable_FkCol1, c_NameOf_DetailTable_FkCol2 },
     PrincipalTable   = c_NameOf_MasterTable,
     PrincipalColumns = new[] { c_NameOf_MasterTable_PkCol1, c_NameOf_MasterTable_PkCol2 },
    };//operation

  //------------------------------------------------------------
  var it
   =new structure_lib.DimensionIterator
    (
     new structure_lib.DimensionBounds(0,sm_Actions.Length-1),
     new structure_lib.DimensionBounds(0,sm_Actions.Length-1)
    );

  int n=0;

  for(it.Restart();it.Ok;it.Next(),++n)
  {
   var onUpdate
    =sm_Actions[it.Point[0]];

   var onDelete
    =sm_Actions[it.Point[1]];

   Console.WriteLine("------------------------------------------- [{0}] {1}, {2}",n,onUpdate.Item1,onDelete.Item1);

   //---------------------------------------
   operation.OnUpdate
    =onUpdate.Item1;

   operation.OnDelete
    =onDelete.Item1;

   //---------------------------------------
   var expectedSQL
    =new TestSqlTemplate()
      .T("ALTER TABLE ").N(c_NameOf_DetailTable).T(" ADD CONSTRAINT ").N(c_NameOf_FK).T(" ")
      .T("FOREIGN KEY (").N(c_NameOf_DetailTable_FkCol1).T(", ").N(c_NameOf_DetailTable_FkCol2).T(") ")
      .T("REFERENCES ").N(c_NameOf_MasterTable).T(" (").N(c_NameOf_MasterTable_PkCol1).T(", ").N(c_NameOf_MasterTable_PkCol2).T(")");

   if(!Object.ReferenceEquals(onUpdate.Item2,null))
    expectedSQL=expectedSQL.T(" ON UPDATE "+onUpdate.Item2);

   if(!Object.ReferenceEquals(onDelete.Item2,null))
    expectedSQL=expectedSQL.T(" ON DELETE "+onDelete.Item2);

   expectedSQL
    =expectedSQL.T(";").CRLF();

   TestHelper.Exec
    (new[]{operation},
     new[]{expectedSQL});
  }//for it
 }//Test_0002__two_columns__complete
};//class TestSet_001__with_name

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D3.Migrations.Generations.SET001.Operations.AddForeignKey
