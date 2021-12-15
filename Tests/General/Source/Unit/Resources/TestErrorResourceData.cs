////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 15.05.2018.
using System;
using System.Linq;
using System.Globalization;
using System.Resources;
using System.Collections.Generic;
using NUnit.Framework;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General.Unit.Resources{
////////////////////////////////////////////////////////////////////////////////
//class TestErrorResourceData

public static class TestErrorResourceData
{
 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ErrMessages__CheckEqLangData()
 {
  Helper__CheckEqLangData
   (xEFCore.ErrResourceUtils.GetLoader_for_messages().GetResourceManager());
 }//Test_ErrMessages__CheckEqLangData

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ErrMessages_EN()
 {
  Helper__TestResource<xEFCore.ErrMessageID>
   (xEFCore.ErrResourceUtils.GetLoader_for_messages().GetResourceManager,
    CultureInfo.InvariantCulture);
 }//Test_ErrMessages_EN

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ErrMessages_RU()
 {
  Helper__TestResource<xEFCore.ErrMessageID>
   (xEFCore.ErrResourceUtils.GetLoader_for_messages().GetResourceManager,
    new CultureInfo("ru"));
 }//Test_ErrMessages_RU

 //-----------------------------------------------------------------------
 [Test]
 public static void Test_ErrSources_EN()
 {
  Helper__TestResource<xEFCore.ErrSourceID>
   (xEFCore.ErrResourceUtils.GetLoader_for_sources().GetResourceManager,
    CultureInfo.InvariantCulture);
 }//Test_ErrSources_EN

 //helper methods --------------------------------------------------------
 private static void Helper__CheckEqLangData(string resID)
 {
  var rm=new ResourceManager(resID,
                             xEFCore.Resources.ResourceFileID.Assembly);

  Helper__CheckEqLangData(rm);
 }//Helper__CheckEqLangData

 //-----------------------------------------------------------------------
 private static void Helper__CheckEqLangData(ResourceManager rm)
 {
  var ru=Helper__GetResourceElementNames
          (()=>rm,
           new CultureInfo("ru"));

  var en=Helper__GetResourceElementNames
          (()=>rm,
           CultureInfo.InvariantCulture);

  Assert.AreEqual(ru,en);
 }//Helper__CheckEqLangData

 //-----------------------------------------------------------------------
 private static ICollection<string> Helper__GetResourceElementNames
                                           (Func<ResourceManager> GetRM,
                                            CultureInfo           ci)
 {
  var rm=GetRM();

  Assert.That(rm,Is.Not.EqualTo(null));

  var resource_set=rm.GetResourceSet(ci,/*createIfNotExists*/true,/*tryParents*/false);

  Assert.That(resource_set,Is.Not.EqualTo(null));

  var data=resource_set.GetEnumerator();

  Assert.That(data,Is.Not.EqualTo(null));

  var resultSet=new List<string>();

  while(data.MoveNext())
  {
   Assert.That(data.Key,Is.Not.EqualTo(null));
   Assert.That(data.Key,Is.Not.EqualTo(""));

   var s=(string)data.Key;

   var x=lcpi.lib.structure.LowerSearch.Exec
          (resultSet,
           s,
           StringComparer.Ordinal);

   Assert.False(x.result);

   resultSet.Insert(x.position,s);
  }//while

  Console.WriteLine("{0} [{1}] - {2}",rm.BaseName,ci.Name,resultSet.Count);

  return resultSet;
 }//Helper__GetResourceElementNames

 //-----------------------------------------------------------------------
 private static void Helper__TestResource<T>(Func<ResourceManager> GetRM,
                                             CultureInfo           ci)
 {
  var IdNames=new List<string>();

  foreach(var x in Enum.GetValues(typeof(T)).Cast<T>())
   IdNames.Add(x.ToString());

  //----------------------------------------
  var rm=GetRM();

  Assert.That(rm,Is.Not.EqualTo(null));

  var resource_set=rm.GetResourceSet(ci,/*createIfNotExists*/true,/*tryParents*/false);

  Assert.That(resource_set,Is.Not.EqualTo(null));

  var data=resource_set.GetEnumerator();

  Assert.That(data,Is.Not.EqualTo(null));

  int n=0;

  while(data.MoveNext())
  {
   ++n;

   Assert.That(data.Key,Is.Not.EqualTo(null));
   Assert.That(data.Key,Is.Not.EqualTo(""));

   try
   {
    Assert.That(data.Value,Is.Not.EqualTo(null));
    Assert.That(data.Value,Is.Not.EqualTo(""));

    Assert.That(Enum.IsDefined(typeof(T),data.Key));
   }
   catch
   {
    Console.WriteLine("TestKey: \"{0}\"",data.Key);
    throw;
   }//catch

   Assert.That(IdNames.Remove((string)data.Key),Is.EqualTo(true));
  }//while

  Console.WriteLine("Test the {0} elements",n);

  Assert.That(n>0);

  //----------------------------------------
  if(IdNames.Count!=0)
  {
   var sb=new System.Text.StringBuilder();

   sb.Append("No resources for ids: ");

   for(int i=0,_c=IdNames.Count;i!=_c;++i)
   {
    if(i!=0)
     sb.AppendFormat(", ");

    sb.AppendFormat("[{0}]",IdNames[i]);
   }//for

   throw new ApplicationException(sb.ToString());
  }//if
 }//Helper__TestResource
};//class TestErrorResourceData

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Unit.Resources
