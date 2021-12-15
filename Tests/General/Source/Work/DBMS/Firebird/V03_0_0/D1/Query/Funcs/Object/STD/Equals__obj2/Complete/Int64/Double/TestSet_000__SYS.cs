////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 28.12.2020.
using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.Object.SET_001.STD.Equals__obj2.Complete.Int64.Double{
////////////////////////////////////////////////////////////////////////////////

using T_DATA1=System.Int64;
using T_DATA2=System.Double;

////////////////////////////////////////////////////////////////////////////////
//class TestSet_000__SYS

public static class TestSet_000__SYS
{
 [Test]
 public static void Test_001()
 {
  Assert.IsFalse
   (object.Equals(1L,1.0D));

  Assert.IsTrue
   (1L==1.0D);
 }//Test_001

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_002___17976931348623157()
 {
  //public const Double Epsilon = 4.94065645841247E-324;
  //public const Double MaxValue = 1.7976931348623157E+308;
  //public const Double MinValue = -1.7976931348623157E+308;

  T_DATA1 v01L=17976931348623157L;
  T_DATA2 v01D=17976931348623157D;

  Assert.IsFalse
   (object.Equals(v01L,v01D));

  Assert.IsTrue
   (v01L==v01D);
 }//Test_002___17976931348623157

 //-----------------------------------------------------------------------
 private struct tagData003
 {
  public T_DATA1         data1;
  public T_DATA2         data2;
  public System.Boolean  isEqual;

  public tagData003(T_DATA1 v1,T_DATA2 v2,bool equal)
  {
   this.data1   =v1;
   this.data2   =v2;
   this.isEqual =equal;
  }//tagData003
 };//struct tagData003

 //-----------------------------------------------------------------------
 private static readonly tagData003[]
  sm_Data003
   =new[]
    {
     //             123456789012345678
     new tagData003(179769313486231571L       ,179769313486231571D     , true),

     new tagData003(1797693134862315711L      ,1797693134862315710D    , true),
     new tagData003(1797693134862315712L      ,1797693134862315710D    , true),
     new tagData003(1797693134862315713L      ,1797693134862315710D    , true),
     new tagData003(1797693134862315714L      ,1797693134862315710D    , true),
     new tagData003(1797693134862315715L      ,1797693134862315710D    , true),
     new tagData003(1797693134862315716L      ,1797693134862315710D    , true),
     new tagData003(1797693134862315717L      ,1797693134862315710D    , true),
     new tagData003(1797693134862315718L      ,1797693134862315710D    , true),
     new tagData003(1797693134862315719L      ,1797693134862315710D    , true),
    };//sm_Data003

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_003()
 {
  var errList=new List<string>();

  for(int i=0;i!=sm_Data003.Length;++i)
  {
   var data=sm_Data003[i];

   bool eq=(data.data1==data.data2);

   if(eq!=data.isEqual)
   {
    string err
      =string.Format
        ("[{0}]. {1} == {2} : {3}. Expected {4}.",
         i,
         data.data1,
         data.data2,
         eq,
         data.isEqual);

    errList.Add(err);
   }
   else
   {
    Console.WriteLine
      ("OK. [{0}]. {1} == {2} : {3}.",
       i,
       data.data1,
       data.data2,
       eq);
   }//else
  }//for i

  if(errList.Count>0)
  {
   var sb=new System.Text.StringBuilder();

   sb.Append("FAILED OPERATIONS:");

   errList
    .Aggregate
      (sb,(current,next)=>current.Append(Environment.NewLine).Append(next))
    .ToString();

   throw new ApplicationException(sb.ToString());
  }//if
 }//Test_003

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_004()
 {
 }//Test_004
};//TestSet_000__SYS

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.Object.SET_001.STD.Equals__obj2.Complete.Int64.Double
