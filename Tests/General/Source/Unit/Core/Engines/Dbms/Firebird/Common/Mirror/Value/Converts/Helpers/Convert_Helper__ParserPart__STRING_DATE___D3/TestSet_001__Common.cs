////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 01.09.2023.
using NUnit.Framework;
using System;
using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Helper.Convert_Helper__ParserPart__STRING_DATE___D3{
////////////////////////////////////////////////////////////////////////////////

using TPARSER
 =xEFCore.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Helpers.Convert_Helper__ParserPart__STRING_DATE___D3;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_001__Common

public static class TestSet_001__Common
{
 private struct tagData001
 { 
  public string Text;
  public int    Offset;

  public int    Year;
  public int    Month;
  public int    Day;

  public TPARSER.ExecResult ExecResult;

  public tagData001(string                 text,
                    int                    offset,
                    TPARSER.ExecResult     execResult,
                    int                    year,
                    int                    month,
                    int                    day)
  {
   this.Text           =text;
   this.Offset         =offset;
   this.ExecResult     =execResult;
  
   this.Year   =year;
   this.Month  =month;
   this.Day    =day;
  }
 };//struct tagData001

 //-----------------------------------------------------------------------
 private static readonly tagData001[] sm_Data001=
 {
  new tagData001
   ("2023-01.01",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__UnknownFormat,0),0,0,0),

  new tagData001
   ("2023.01-01",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__UnknownFormat,0),0,0,0),

  //--------------------------------------------------
  // \todo: [2023-09-01] It must be an error BadYear!

  new tagData001
   ("a0000-01-01",
    1,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),0,1,1),

  //--------------------------------------------------
  new tagData001
   ("2023-00-01",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Month,5),0,0,0),

  new tagData001
   ("2023-13-01",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Month,5),0,0,0),

  //--------------------------------------------------
  new tagData001
   ("2023-01-00",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  new tagData001
   ("2023-01-32",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  //--------------------------------------------------
  new tagData001
   ("2023-02-00",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  new tagData001
   ("2023-02-29",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  //--------------------------------------------------
  new tagData001
   ("2023-03-00",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  new tagData001
   ("2023-03-32",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  //--------------------------------------------------
  new tagData001
   ("2023-04-00",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  new tagData001
   ("2023-04-31",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  //--------------------------------------------------
  new tagData001
   ("2023-05-00",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  new tagData001
   ("2023-05-32",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  //--------------------------------------------------
  new tagData001
   ("2023-06-00",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  new tagData001
   ("2023-06-31",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  //--------------------------------------------------
  new tagData001
   ("2023-07-00",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  new tagData001
   ("2023-07-32",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  //--------------------------------------------------
  new tagData001
   ("2023-08-00",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  new tagData001
   ("2023-08-32",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  //--------------------------------------------------
  new tagData001
   ("2023-09-00",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  new tagData001
   ("2023-09-31",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  //--------------------------------------------------
  new tagData001
   ("2023-10-00",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  new tagData001
   ("2023-10-32",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  //--------------------------------------------------
  new tagData001
   ("2023-11-00",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  new tagData001
   ("2023-11-31",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  //--------------------------------------------------
  new tagData001
   ("2023-12-00",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  new tagData001
   ("2023-12-32",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Err__BadPart__Day,8),0,0,0),

  //--------------------------------------------------
  new tagData001
   ("2023-09-01",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,10),2023,9,1),

  new tagData001
   ("01.09.2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,10),2023,9,1),

  //--------------------------------------------------
  new tagData001
   ("01-jan-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,1,1),
  new tagData001
   ("01-feb-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,2,1),
  new tagData001
   ("01-mar-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,3,1),
  new tagData001
   ("01-apr-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,4,1),
  new tagData001
   ("01-may-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,5,1),
  new tagData001
   ("01-jun-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,6,1),
  new tagData001
   ("01-jul-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,7,1),
  new tagData001
   ("01-aug-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,8,1),
  new tagData001
   ("01-sep-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,9,1),
  new tagData001
   ("01-oct-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,10,1),
  new tagData001
   ("01-nov-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,11,1),
  new tagData001
   ("01-dec-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,12,1),

  //--------------------------------------------------
  new tagData001
   ("01-JAN-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,1,1),
  new tagData001
   ("01-FEB-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,2,1),
  new tagData001
   ("01-MAR-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,3,1),
  new tagData001
   ("01-APR-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,4,1),
  new tagData001
   ("01-MAY-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,5,1),
  new tagData001
   ("01-JUN-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,6,1),
  new tagData001
   ("01-JUL-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,7,1),
  new tagData001
   ("01-AUG-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,8,1),
  new tagData001
   ("01-SEP-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,9,1),
  new tagData001
   ("01-OCT-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,10,1),
  new tagData001
   ("01-NOV-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,11,1),
  new tagData001
   ("01-DEC-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,12,1),

  //--------------------------------------------------
  new tagData001
   ("01-january-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,15),2023,1,1),
  new tagData001
   ("01-february-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,16),2023,2,1),
  new tagData001
   ("01-march-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,13),2023,3,1),
  new tagData001
   ("01-april-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,13),2023,4,1),
  new tagData001
   ("01-may-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,5,1),
  new tagData001
   ("01-june-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,12),2023,6,1),
  new tagData001
   ("01-july-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,12),2023,7,1),
  new tagData001
   ("01-august-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,14),2023,8,1),
  new tagData001
   ("01-september-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,17),2023,9,1),
  new tagData001
   ("01-october-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,15),2023,10,1),
  new tagData001
   ("01-november-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,16),2023,11,1),
  new tagData001
   ("01-december-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,16),2023,12,1),

  //--------------------------------------------------
  new tagData001
   ("01-JANUARY-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,15),2023,1,1),
  new tagData001
   ("01-FEBRUARY-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,16),2023,2,1),
  new tagData001
   ("01-MARCH-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,13),2023,3,1),
  new tagData001
   ("01-APRIL-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,13),2023,4,1),
  new tagData001
   ("01-MAY-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,11),2023,5,1),
  new tagData001
   ("01-JUNE-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,12),2023,6,1),
  new tagData001
   ("01-JULY-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,12),2023,7,1),
  new tagData001
   ("01-AUGUST-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,14),2023,8,1),
  new tagData001
   ("01-SEPTEMBER-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,17),2023,9,1),
  new tagData001
   ("01-OCTOBER-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,15),2023,10,1),
  new tagData001
   ("01-NOVEMBER-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,16),2023,11,1),
  new tagData001
   ("01-DECEMBER-2023",
    0,
    new TPARSER.ExecResult(TPARSER.ExecResultCode.Ok,16),2023,12,1),
 };//sm_Data001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_001()
 {
  for(int i=0;i!=sm_Data001.Length;++i)
  {
   var data=sm_Data001[i];

   Console.WriteLine("--------------------------- [{0}]",i);
   Console.WriteLine("Text: [{0}]",data.Text);

   int year;
   int month;
   int day;

   var r
    =TPARSER.Exec
      (data.Text,
       data.Offset,
       out year,
       out month,
       out day);

   Assert.AreEqual
    (data.ExecResult.Code,
     r.Code);

   Assert.AreEqual
    (data.ExecResult.Offset,
     r.Offset);

   Assert.AreEqual
    (data.Year,
     year);

   Assert.AreEqual
    (data.Month,
     month);

   Assert.AreEqual
    (data.Day,
     day);
  }//for
 }//Test_001
};//class TestSet_001__Common

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Helper.Convert_Helper__ParserPart__STRING_DATE___D3
