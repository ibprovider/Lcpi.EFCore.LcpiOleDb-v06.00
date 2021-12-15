////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.02.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_TestConversionResult

struct Structure_TestConversionResult
{
 public readonly bool OK;

 public readonly int Weight;

 //-------------------------------------------------------
 private Structure_TestConversionResult(bool ok,int weight)
 {
  this.OK=ok;
  this.Weight=weight;
 }//Structure_TestConversionResult

 //-------------------------------------------------------
 public static Structure_TestConversionResult Create_OK(int weight)
 {
  Debug.Assert(weight>=0);

  return new Structure_TestConversionResult(true,weight);
 }//Create_OK

 //-------------------------------------------------------
 public static Structure_TestConversionResult Create_NO()
 {
  return new Structure_TestConversionResult(false,/*weight*/0);
 }//Create_NO
};//struct Structure_TestConversionResult

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
