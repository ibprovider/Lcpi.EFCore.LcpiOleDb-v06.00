////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 14.10.2020.
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP{
////////////////////////////////////////////////////////////////////////////////
//class TestsFor__FourBitsToHEX

public static class TestsFor__FourBitsToHEX
{
 private static readonly char[]
  sm_HEX={'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'};

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_01()
 {
  for(byte i=0;i!=15;++i)
  {
   Assert.AreEqual
    (sm_HEX[i],
     xEFCore.Structure.Structure_ADP.FourBitsToHEX(i));
  }//foreach ch
 }//Test_01__yes
};//class TestsFor__FourBitsToHEX

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Structure.Structure_ADP
