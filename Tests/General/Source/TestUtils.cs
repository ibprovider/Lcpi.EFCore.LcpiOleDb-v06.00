////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 13.10.2020.
using System;
using System.Diagnostics;

using structure_lib=lcpi.lib.structure;

namespace EFCore_LcpiOleDb_Tests.General{
////////////////////////////////////////////////////////////////////////////////
//class TestUtils

static class TestUtils
{
 public static string CStrSN(object value)
 {
  if(Object.ReferenceEquals(value,null))
   return "#NULL";

  if(value==DBNull.Value)
   return "#DBNULL";

  return value.ToString();
 }//CStrSN

 //-----------------------------------------------------------------------
 public static string ToString(bool v)
 {
  if(v)
   return "true";
 
  return "false";
 }//ToString

 //-----------------------------------------------------------------------
 public static int GetRecordCount(structure_lib.IErrorRecords x)
 {
  Debug.Assert(!Object.ReferenceEquals(x,null));

  return x.GetRecordCount();
 }//GetRecordCount

 //-----------------------------------------------------------------------
 public static structure_lib.IErrorRecord GetRecord(structure_lib.IErrorRecords x,int i)
 {
  Debug.Assert(!Object.ReferenceEquals(x,null));

  return x.GetRecord(i);
 }//GetRecord
};//class TestUtils

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General
