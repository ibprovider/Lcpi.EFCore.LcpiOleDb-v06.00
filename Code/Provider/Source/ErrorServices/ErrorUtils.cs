////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 06.10.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//class ErrorUtils

static class ErrorUtils
{
 public static void Add(ref List<Core.Core_ExceptionRecord> errorRecords,
                        Core.Core_ExceptionRecord           errorRecord)
 {
  Debug.Assert(!Object.ReferenceEquals(errorRecord,null));

  if(Object.ReferenceEquals(errorRecords,null))
   errorRecords=new List<Core.Core_ExceptionRecord>();

  Debug.Assert(!Object.ReferenceEquals(errorRecord,null));

  errorRecords.Add(errorRecord);
 }//Add

 //-----------------------------------------------------------------------
 public static void ThrowIfNotEmpty(IReadOnlyCollection<Core.Core_ExceptionRecord> errorRecords)
 {
  if(Object.ReferenceEquals(errorRecords, null))
   return;

  if(errorRecords.Count==0)
   return;

  var exc
   =new LcpiOleDb__DataToolException
     (lcpi.lib.com.HResultCode.E_FAIL);

  foreach(var x in errorRecords)
   exc.add(x);

  exc.raise();
 }//ThrowIfNotEmpty
};//class ErrorUtils

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb
