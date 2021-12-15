////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.05.2018.
using System;
using System.Resources;
using System.Linq;
using System.Globalization;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Resources{
////////////////////////////////////////////////////////////////////////////////
//class TestErrorResourceIDs

public class TestErrorResourceIDs
{
 //-----------------------------------------------------------------------
 [Test]
 public void Test_ErrMessages()
 {
  Helper__TestIDs<xEFCore.ErrMessageID>
   ((x,ci)=>(xEFCore.ErrResourceUtils.GetLoader_for_messages().GetString(ci,x)),
    CultureInfo.InvariantCulture);
 }//Test_ErrMessages

 //-----------------------------------------------------------------------
 [Test]
 public void Test_ErrMessages_RU()
 {
  Helper__TestIDs<xEFCore.ErrMessageID>
   ((x,ci)=>(xEFCore.ErrResourceUtils.GetLoader_for_messages().GetString(ci,x)),
    new CultureInfo("ru"));
 }//Test_ErrMessages_RU

 //-----------------------------------------------------------------------
 [Test]
 public void Test_ErrSources()
 {
  Helper__TestIDs<xEFCore.ErrSourceID>
   ((x,ci)=>(xEFCore.ErrResourceUtils.GetLoader_for_sources().GetString(ci,x)),
    CultureInfo.InvariantCulture);
 }//Test_ErrSources

  //-----------------------------------------------------------------------
 private void Helper__TestIDs<T>(Func<T,CultureInfo,string> loader,CultureInfo ci)
 {
  var Values=Enum.GetValues(typeof(T)).Cast<T>();

  int n=0;

  foreach(var x in Values)
  {
   ++n;

   try
   {
    string msg=loader(x,ci);

    Assert.That(msg,Is.Not.EqualTo(null));
    Assert.That(msg,Is.Not.EqualTo(""));
   }
   catch
   {
    Console.WriteLine("testID: {0}",x.ToString());

    throw;
   }//for
  }//for x

  Console.WriteLine("Test the {0} ids",n);

  Assert.That(n>0);
 }//Helper__TestIDs
};//class TestErrorResourceIDs

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Resources
