////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 13.10.2020.
using System;

namespace EFCore_LcpiOleDb_Tests.General{
////////////////////////////////////////////////////////////////////////////////
//class TestTracer

static class TestTracer
{
 public static void Trace(string format,params object[] args)
 {
  Helper__Trace_WriteLine(string.Format(format,args));
 }//Trace

 //-----------------------------------------------------------------------
 private static void Helper__Trace_WriteLine(string s)
 {
  Console.WriteLine(s);
 }//Helper__Trace_WriteLine
};//class TestTracer

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General
