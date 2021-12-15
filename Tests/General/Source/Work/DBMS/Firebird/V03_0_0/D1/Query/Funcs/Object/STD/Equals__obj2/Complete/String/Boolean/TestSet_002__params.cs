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

////////////////////////////////////////////////////////////////////////////////
//class TestSet_002__params

public static class TestSet_002__params
{
 private const string c_NameOf__TABLE="DUAL";

 //-----------------------------------------------------------------------
 private sealed class MyContext:TestBaseDbContext
 {
  [Table(c_NameOf__TABLE)]
  public sealed class TEST_RECORD
  {
   [Key]
   [Column("ID")]
   public System.Int64? TEST_ID { get; set; }
  };//class TEST_RECORD

  //----------------------------------------------------------------------
  public DbSet<TEST_RECORD> testTable { get; set; }

  //----------------------------------------------------------------------
  public MyContext(xdb.OleDbTransaction tr)
   :base(tr)
  {
  }//MyContext
 };//class MyContext

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_100()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     var Errors=new List<int>();

     for(int iData=0;iData!=MasterValues.sm_Data100.Length;++iData)
     {
      Console.WriteLine("------------------------------ [{0}]",iData);

      T_DATA1  vv1=MasterValues.sm_Data100[iData].arg1;
      T_DATA2? vv2=MasterValues.sm_Data100[iData].arg2;

      var recs=db.testTable.Where(r => object.Equals(vv1,vv2));

      try
      {
       if(MasterValues.sm_Data100[iData].result)
       {
        int nRecs=0;

        foreach(var r in recs)
        {
         Assert.AreEqual
          (0,
           nRecs);

         ++nRecs;

         Assert.IsTrue
          (r.TEST_ID.HasValue);

         Assert.AreEqual
          (1,
           r.TEST_ID.Value);
        }//foreach r

        Assert.AreEqual
         (1,
          nRecs);
       }
       else
       {
        foreach(var r in recs)
        {
         TestServices.ThrowSelectedRow();
        }//foreach r
       }//else

       Console.WriteLine("OK!");

       db.CheckTextOfLastExecutedCommand
        (new TestSqlTemplate()
          .T("SELECT ").N("d","ID").EOL()
          .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
          .T("WHERE ").P_BOOL("__Exec_V_V_0"));
      }
      catch(Exception e)
      {
       Errors.Add(iData);

       Console.WriteLine("FAILED!");

       CheckErrors.PrintException(e);
      }//catch
     }//for iData

     if(Errors.Count!=0)
     {
      var ids
       =string.Join(", ", Errors.Select(p => p.ToString()));

      var msg
       =string.Format
         ("Some subtests [{0}] was finished with errors!",
          ids);

      throw new ApplicationException(msg);
     }//if Errors.Count!=0
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_100

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_101__ParamObjs()
 {
  using(var cn=LocalCnHelper.CreateCn())
  {
   cn.Open();

   using(var tr=cn.BeginTransaction())
   {
    //insert new record in external transaction
    using(var db=new MyContext(tr))
    {
     var Errors=new List<int>();

     for(int iData=0;iData!=MasterValues.sm_Data100.Length;++iData)
     {
      Console.WriteLine("------------------------------ [{0}]",iData);

      object vv1=MasterValues.sm_Data100[iData].arg1;
      object vv2=MasterValues.sm_Data100[iData].arg2;

      var recs=db.testTable.Where(r => object.Equals(vv1,vv2));

      try
      {
       if(MasterValues.sm_Data100[iData].result)
       {
        int nRecs=0;

        foreach(var r in recs)
        {
         Assert.AreEqual
          (0,
           nRecs);

         ++nRecs;

         Assert.IsTrue
          (r.TEST_ID.HasValue);

         Assert.AreEqual
          (1,
           r.TEST_ID.Value);
        }//foreach r

        Assert.AreEqual
         (1,
          nRecs);
       }
       else
       {
        foreach(var r in recs)
        {
         TestServices.ThrowSelectedRow();
        }//foreach r
       }//else

       Console.WriteLine("OK!");

       db.CheckTextOfLastExecutedCommand
        (new TestSqlTemplate()
          .T("SELECT ").N("d","ID").EOL()
          .T("FROM ").N(c_NameOf__TABLE).T(" AS ").N("d").EOL()
          .T("WHERE ").P_BOOL("__Exec_V_V_0"));
      }
      catch(Exception e)
      {
       Errors.Add(iData);

       Console.WriteLine("FAILED!");

       CheckErrors.PrintException(e);
      }//catch
     }//for iData

     if(Errors.Count!=0)
     {
      var ids
       =string.Join(", ", Errors.Select(p => p.ToString()));

      var msg
       =string.Format
         ("Some subtests [{0}] was finished with errors!",
          ids);

      throw new ApplicationException(msg);
     }//if Errors.Count!=0
    }//using db

    tr.Rollback();
   }//using tr
  }//using cn
 }//Test_101__ParamObjs
};//class TestSet_002__params

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.Object.SET_001.STD.Equals__obj2.Complete.String.Boolean
