////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 14.10.2020.
using System.Data;
using NUnit.Framework;

using xEFCore  =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;
using xEFCore_s=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__IndexOf__DataColumn

public static class TestsFor__IndexOf__DataColumn
{
 [Test]
 public static void Test_01()
 {
  var names=new string[]{"col4","col1","col2","col0"};

  var table=new DataTable();

  foreach(var n in names)
  {
   table.Columns.Add(n);
  }//foreach

  for(int i=0,_c=names.Length;i!=_c;++i)
  {
   var r=xEFCore_s.Structure_ADP.IndexOf
          (xEFCore.ErrSourceID.common,
           table,
           names[i]);

   Assert.AreEqual(i,r);
  }//for i
 }//Test_01

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_02__unk_name()
 {
  var table=new DataTable("ttt");

  table.Columns.Add("aaaa");

  const string c_test_col_name="bbbb";

  try
  {
   xEFCore_s.Structure_ADP.IndexOf
    (xEFCore.ErrSourceID.common,
     table,
     c_test_col_name);
  }
  catch(xEFCore.LcpiOleDb__DataToolException exc)
  {
   Assert.AreEqual
    (1,
     TestUtils.GetRecordCount(exc));

   CheckErrors.CheckErrorRecord__common_err__unk_column_name__2
    (TestUtils.GetRecord(exc,0),
     CheckErrors.c_src__EFCoreDataProvider__common,
     table.TableName,
     c_test_col_name);

   return;
  }//catch

  TestServices.ThrowWeWaitError();
 }//Test_02__unk_name
};//class TestsFor__IndexOf__DataColumn

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP
