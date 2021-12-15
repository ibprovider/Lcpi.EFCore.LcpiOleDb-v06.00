////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 14.10.2020.
using System;
using System.Data;
using NUnit.Framework;

using xEFCore  =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;
using xEFCore_s=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__GetInt32_NN

public static class TestsFor__GetInt32_NN
{
 [Test]
 public static void Test_01()
 {
  var table=new DataTable("rrrr");

  var col=table.Columns.Add("ccc",typeof(int));

  var row=table.NewRow();

  const int c_test_value=-123;

  row[0]=c_test_value;

  table.Rows.Add(row);

  Assert.AreEqual
   (c_test_value,
    xEFCore_s.Structure_ADP.GetInt32_NN
      (xEFCore.ErrSourceID.common,
       row,
       0));
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__null()
 {
  var table=new DataTable("rrrr");

  var col=table.Columns.Add("ccc",typeof(object));

  var row=table.NewRow();

  row[0]=null; //will saved as DBNull

  table.Rows.Add(row);

  try
  {
   var x
    =xEFCore_s.Structure_ADP.GetInt32_NN
       (xEFCore.ErrSourceID.common,
        row,
        0);
  }
  catch(xEFCore.LcpiOleDb__DataToolException exc)
  {
   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(exc));

   CheckErrors.CheckErrorRecord__common_err__invalid_column_value__4
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     table.TableName,
     0,
     col.ColumnName,
     "#DBNULL");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_02__null

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_03__DBNull()
 {
  var table=new DataTable("rrrr");

  var col=table.Columns.Add("ccc",typeof(object));

  var row=table.NewRow();

  row[0]=DBNull.Value;

  table.Rows.Add(row);

  try
  {
   var x
    =xEFCore_s.Structure_ADP.GetInt32_NN
       (xEFCore.ErrSourceID.common,
        row,
        0);
  }
  catch(xEFCore.LcpiOleDb__DataToolException exc)
  {
   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(exc));

   CheckErrors.CheckErrorRecord__common_err__invalid_column_value__4
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     table.TableName,
     0,
     col.ColumnName,
     "#DBNULL");

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_03__DBNull

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_04__String()
 {
  var table=new DataTable("rrrr");

  var col=table.Columns.Add("ccc",typeof(object));

  var row=table.NewRow();

  row[0]="123123";

  table.Rows.Add(row);

  try
  {
   var x
    =xEFCore_s.Structure_ADP.GetInt32_NN
       (xEFCore.ErrSourceID.common,
        row,
        0);
  }
  catch(xEFCore.LcpiOleDb__DataToolException exc)
  {
   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(exc));

   CheckErrors.CheckErrorRecord__common_err__invalid_column_value_type__5
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     table.TableName,
     0,
     col.ColumnName,
     typeof(string),
     typeof(int));

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_04__String
};//TestsFor__GetInt32_NN

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP
