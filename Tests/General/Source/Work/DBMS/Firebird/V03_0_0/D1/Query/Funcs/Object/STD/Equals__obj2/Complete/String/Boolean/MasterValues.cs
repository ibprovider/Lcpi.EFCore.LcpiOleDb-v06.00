////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 23.04.2021.
using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.Object.SET_001.STD.Equals__obj2.Complete.String.Boolean{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1=System.String;
using T_DATA2=System.Boolean;

static class MasterValues
{
 public struct tagTestData
 {
  public readonly T_DATA1  arg1;
  public readonly T_DATA2? arg2;

  public readonly bool result;

  public tagTestData(T_DATA1 _arg1,T_DATA2? _arg2,bool _result)
  {
   this.arg1   = _arg1;
   this.arg2   = _arg2;
   this.result = _result;
  }//tagTestData
 };//class tagTestData

 //-----------------------------------------------------------------------
 public static readonly tagTestData[]
  sm_Data100
   =new tagTestData[]
    {
     new tagTestData
      ("false",
       false,
       true),

     new tagTestData
      ("true",
       true,
       true),

     new tagTestData
      ("false",
       true,
       false),

     new tagTestData
      ("true",
       false,
       false),

     new tagTestData
      (null,
       true,
       false),

     new tagTestData
      ("true",
       null,
       false),

     new tagTestData
      (null,
       false,
       false),

     new tagTestData
      ("false",
       null,
       false),

     new tagTestData
      (null,
       null,
       true),

     //---------------------------------------------------- mix
     new tagTestData
      ("TRUE",
       true,
       true),

     new tagTestData
      (" TRuE ",
       true,
       true),
    };//sm_Data100
};//class MasterValues

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.Object.SET_001.STD.Equals__obj2.Complete.String.Boolean
