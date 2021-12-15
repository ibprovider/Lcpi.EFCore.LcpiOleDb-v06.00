////////////////////////////////////////////////////////////////////////////////
//EF.Core Provider for LCPI OLE DB and Firebird.
//                                      IBProvider and Contributors. 07.10.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.ValueConversion{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__ValueConversion__GuidToBytes

sealed class FB_Common__ValueConversion__GuidToBytes
{
 public static readonly ValueConverter
  Instance
   =new Microsoft.EntityFrameworkCore.Storage.ValueConversion.GuidToBytesConverter();
};//class FB_Common__ValueConversion__GuidToBytes

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Storage.ValueConversion
