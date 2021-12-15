////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 13.10.2020.

#if   BUILD_CONF__NET5_0_0
//# define LOCAL_BUILD_CONF__support_bin_serialization
#elif BUILD_CONF__NET6_0_0
//# define LOCAL_BUILD_CONF__support_bin_serialization
#else
# error "Unexpected Target Platform!"
#endif

using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

using NUnit.Framework;

using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

using xdb=lcpi.data.oledb;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General{
////////////////////////////////////////////////////////////////////////////////

using TraceMsgBuilderUtils
 =lcpi.lib.structure.TraceMsgBuilderUtils;

////////////////////////////////////////////////////////////////////////////////
//class TestServices

static class TestServices
{
 public const string c_conf__cn_str
  ="cn_str";

 //-----------------------------------------------------------------------
 public static void ThrowWeWaitError()
 {
  throw new ApplicationException("We wait the error!");
 }//ThrowWeWaitError

 //-----------------------------------------------------------------------
 public static void ThrowSelectedRow()
 {
  throw new ApplicationException("SELECTED ROW!");
 }//ThrowSelectedRow

 //-----------------------------------------------------------------------
 private static string Helper__ReadConfValue(string PropName)
 {
  var a=System.Reflection.Assembly.GetExecutingAssembly();

  var l=a.Location;

  var c=ConfigurationManager.OpenExeConfiguration(l);

  var s=c.AppSettings.Settings;

  var k=s[PropName];

  if(Object.ReferenceEquals(k,null))
  {
   string msg
    =string.Format("Configuration property {0} not defined",PropName);

   throw new ApplicationException(msg);
  }//if

  string v=k.Value;

  if(Object.ReferenceEquals(k,null))
  {
   string msg
    =string.Format("Configuration property {0} exists, but without value",PropName);

   throw new ApplicationException(msg);
  }//if

  return v;
 }//Helper__ReadConfValue

 //-----------------------------------------------------------------------
 public static string Conf__GetCnStr()
 {
  return Helper__ReadConfValue(c_conf__cn_str);
 }//Conf__GetCnStr

 //-----------------------------------------------------------------------
 public static object GenID(xdb.OleDbTransaction tr,
                            string               generatorName,
                            int                  n)
 {
  var sql
   =string.Format
     ("select GEN_ID({0},{1}) from DUAL",
       generatorName,
       n);

  using(var cmd=new xdb.OleDbCommand(sql,tr.Connection,tr))
  {
   return cmd.ExecuteScalar();
  }//using cmd
 }//GenID

 //-----------------------------------------------------------------------
#if LOCAL_BUILD_CONF__support_bin_serialization

 public static object CloneThroughSerialization_bin(object obj)
 {
  //----------------------------------------
  var ms=new MemoryStream();

  var bf=new BinaryFormatter();

  //----------------------------------------
  Console.WriteLine("Serialize");

  bf.Serialize(ms,obj);

  //----------------------------------------
  Console.WriteLine("Deserialize");

  ms.Position=0;

  var obj2=bf.Deserialize(ms);

  Assert.AreEqual
   (obj==null,obj2==null);

  ms.Dispose();

  return obj2;
 }//CloneThroughSerialization_bin

#endif //LOCAL_BUILD_CONF__support_bin_serialization

 //-----------------------------------------------------------------------
#if LOCAL_BUILD_CONF__support_bin_serialization

 public static void Exception__TestSerialization_bin(Exception exc)
 {
  Console.WriteLine("Test Exception Clone");

  Assert.IsNotNull(exc);

  var exc2=(Exception)TestServices.CloneThroughSerialization_bin(exc);

  Assert.IsNotNull(exc2);

  Assert.AreNotSame(exc,exc2);

  CheckErrors.Exception__CheckEqual(exc,exc2,true); //throw
 }//Exception__TestSerialization_bin

#endif //LOCAL_BUILD_CONF__support_bin_serialization

 //-----------------------------------------------------------------------
 public static void UnsupportedSQL__DataTypeUnknown
                                       (xdb.OleDbTransaction tr,
                                        string               sql)
 {
  Console.WriteLine
   ("Check unsupported SQL:\n{0}\n",
    sql);

  using(var cmd=new xdb.OleDbCommand(sql,tr.Connection,tr))
  {
   try
   {
    cmd.Prepare();
   }
   catch(xdb.OleDbException e)
   {
    Assert.AreEqual
     (3,
      TestUtils.GetRecordCount(e));

    CheckErrors.CheckOleDbError__Firebird__DataTypeUnknown
     (e.Errors[0]);

    return;
   }//catch
  }//using cmd

  ThrowWeWaitError();
 }//UnsupportedSQL__DataTypeUnknown

 //-----------------------------------------------------------------------
 public static void UnsupportedSQL__ExpressionEvaluationNotSupported
                                       (xdb.OleDbTransaction tr,
                                        string               sql)
 {
  Console.WriteLine
   ("Check unsupported SQL:\n{0}\n",
    sql);

  using(var cmd=new xdb.OleDbCommand(sql,tr.Connection,tr))
  {
   try
   {
    cmd.Prepare();
   }
   catch(xdb.OleDbException e)
   {
    Assert.AreEqual
     (3,
      TestUtils.GetRecordCount(e));

    CheckErrors.CheckOleDbError__Firebird__ExpressionEvaluationNotSupported
     (e.Errors[0]);

    return;
   }//catch
  }//using cmd

  ThrowWeWaitError();
 }//UnsupportedSQL__ExpressionEvaluationNotSupported

 //Structure_NumericDigits -----------------------------------------------
 public static xEFCore.Structure.Structure_NumericDigits.RW
                 Structure_NumericDigits___Create
                             (byte[]                                    digits,
                              int                                       scale,
                              xEFCore.Structure.Structure_NumberSign    mantisseSign)
 {
  Debug.Assert(!Object.ReferenceEquals(digits,null));

  var resultNumericDigits
   =new xEFCore.Structure.Structure_NumericDigits.RW
     (digits.Length);

  for(int i=0;i!=digits.Length;++i)
   resultNumericDigits.SetDigit(i,digits[i]);

  resultNumericDigits
   .SetMantisseSign(mantisseSign);

  resultNumericDigits
   .SetScale(scale);

  return resultNumericDigits;
 }//Structure_NumericDigits___Create

 //-----------------------------------------------------------------------
 public static void Structure_NumericDigits___CheckEqual
                             (xEFCore.Structure.Structure_NumericDigits expectedNumericDigits,
                              xEFCore.Structure.Structure_NumericDigits actualNumericDigits)
 {
  Assert.IsNotNull
   (expectedNumericDigits);

  Assert.IsNotNull
   (actualNumericDigits);

  Assert.AreEqual
   (expectedNumericDigits.Size,
    actualNumericDigits.Size);

  Assert.AreEqual
   (expectedNumericDigits.Scale,
    actualNumericDigits.Scale);

  Assert.AreEqual
   (expectedNumericDigits.MantisseSign,
    actualNumericDigits.MantisseSign);

  for(int i=0,_c=expectedNumericDigits.Size;i!=_c;++i)
  {
   var v1=expectedNumericDigits.GetDigit(i);
   var v2=actualNumericDigits.GetDigit(i);

   if(v1==v2)
    continue;

   string msg
    =string.Format
      ("Wrong digit[{0}]: {2}. Expected {1}.",
       i,
       v1,
       v2);

   throw new ApplicationException(msg);
  }//for i
 }//Structure_NumericDigits___CheckEqual

 //-----------------------------------------------------------------------
 public static void Structure_NumericDigits___CheckState
                             (xEFCore.Structure.Structure_NumericDigits numericDigits,
                              int                                       expected_size,
                              int                                       expected_scale,
                              xEFCore.Structure.Structure_NumberSign    expected_mantisseSign)
 {
  Assert.IsNotNull
   (numericDigits);

  Assert.AreEqual
   (expected_size,
    numericDigits.Size);

  Assert.AreEqual
   (expected_scale,
    numericDigits.Scale);

  Assert.AreEqual
   (expected_mantisseSign,
    numericDigits.MantisseSign);
 }//Structure_NumericDigits___CheckState

 //-----------------------------------------------------------------------
 public static void Structure_NumericDigits___CheckState
                             (xEFCore.Structure.Structure_NumericDigits numericDigits,
                              byte[]                                    expected_digits,
                              int                                       expected_scale,
                              xEFCore.Structure.Structure_NumberSign    expected_mantisseSign)
 {
  Assert.IsNotNull
   (numericDigits);

  Structure_NumericDigits___CheckState
   (numericDigits,
    expected_digits.Length,
    expected_scale,
    expected_mantisseSign);

  for(int i=0;i!=expected_digits.Length;++i)
  {
   Assert.AreEqual
    (expected_digits[i],
     numericDigits.GetDigit(i));
  }//for i
 }//Structure_NumericDigits___CheckState

 //-----------------------------------------------------------------------
 public static void CheckMigrationSQLs(TestBaseDbContext              db,
                                       IReadOnlyList<TestSqlTemplate> expectedSQLs)
 {
  var differ
   =db.GetService<IMigrationsModelDiffer>();
     
  Assert.NotNull
   (differ);

  //----------------------
  var model
   =db.GetService<IDesignTimeModel>().Model;

  Assert.NotNull
   (model);

  //----------------------
  var ops
   =differ.GetDifferences(null,model.GetRelationalModel());

  Assert.NotNull
   (ops);

  //----------------------
  CheckMigrationSQLs
   (db,
    ops,
    expectedSQLs);
 }//CheckMigrationSQLs

 //-----------------------------------------------------------------------
 public static void CheckMigrationSQLs(TestBaseDbContext                 db,
                                       IReadOnlyList<MigrationOperation> operations,
                                       IReadOnlyList<TestSqlTemplate>    expectedSQLs)
 {
  var generator
   =db.GetService<IMigrationsSqlGenerator>();
  
  var options
   =MigrationsSqlGenerationOptions.Default;

  var migrationCommands
   =generator.Generate
     (operations,
      db.Model,
      options);

  Assert.NotNull
   (migrationCommands);

  db.ExecConnectionOperation
  (
   cn =>
   {
    TestServices.CheckMigrationSQLs
     (cn,
      expectedSQLs,
      migrationCommands); //throw;
   });
 }//CheckMigrationSQLs

 //-----------------------------------------------------------------------
 public static void CheckMigrationSQLs(xdb.OleDbConnection             cn,
                                       IReadOnlyList<TestSqlTemplate>  expectedSQLs,
                                       IReadOnlyList<MigrationCommand> migrationCommands)
 {
  Debug.Assert(!Object.ReferenceEquals(cn,null));
  Debug.Assert(!Object.ReferenceEquals(expectedSQLs,null));

  Assert.NotNull
   (migrationCommands);

  var errList
   =new List<string>();

  int iSQL
   =0;

  for(;;++iSQL)
  {
   if(iSQL==expectedSQLs.Count)
    break;

   if(iSQL==migrationCommands.Count)
    break;

   var generatedSQL
    =migrationCommands[iSQL].CommandText;

   Assert.NotNull
    (generatedSQL);

   Console.WriteLine("---------------------------- {0}",iSQL);
   Console.WriteLine("Generated SQL:\n{0}",generatedSQL);

   //------------------------------------
   var expectedSQL
    =expectedSQLs[iSQL].BuildSql(cn);

   if(expectedSQL!=generatedSQL)
   {
    Console.WriteLine();
    Console.WriteLine("ERROR! ExpectedSQL:");
    Console.WriteLine("{0}",expectedSQL);

    var errMsg
     =string.Format
       ("EXPECTED SQL:\n"
       +"{0}\n"
       +"ACTUAL SQL:\n"
       +"{1}\n",
        TraceMsgBuilderUtils.WrapArg(expectedSQL),
        TraceMsgBuilderUtils.WrapArg(generatedSQL));

    errList.Add(errMsg);
   }//if
  }//for iSQL

  //---------------------------------------------------------
  for(int iUnk=iSQL;iUnk!=migrationCommands.Count;++iUnk)
  {
   var generatedSQL
    =migrationCommands[iUnk].CommandText;

   Console.WriteLine("---------------------------- {0}",iSQL);
   Console.WriteLine("UNEXPECTED SQL:\n{0}",generatedSQL);

   var errMsg
    =string.Format
      ("Unexpected migration command:\n{0}",
       TraceMsgBuilderUtils.WrapArg(generatedSQL));

   errList.Add
    (errMsg);
  }//for iUnk

  //---------------------------------------------------------
  for(int iUnk=iSQL;iUnk!=expectedSQLs.Count;++iUnk)
  {
   var expectedSQL
    =expectedSQLs[iUnk].BuildSql(cn);

   Console.WriteLine("---------------------------- {0}",iSQL);
   Console.WriteLine("NOT FOUND SQL:\n{0}",expectedSQL);

   var errMsg
    =string.Format
      ("NOT FOUND migration command:\n{0}",
       TraceMsgBuilderUtils.WrapArg(expectedSQL));

   errList.Add
    (errMsg);
  }//for iUnk

  if(errList.Count>0)
  {
   var sb=new StringBuilder();

   sb.Append("FAILED OPERATIONS:");

   errList
    .Aggregate
      (sb,(current,next)=>current.Append(Environment.NewLine).Append(next))
    .ToString();

   throw new ApplicationException(sb.ToString());
  }//if
 }//CheckMigrationSQLs
};//class TestServices

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General
