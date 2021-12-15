////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 21.10.2021.
using System;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common{
////////////////////////////////////////////////////////////////////////////////
//struct FB_Common__DataTypeDescr

struct FB_Common__DataTypeDescr
{
 public Nullable<FB_Common__DataTypeID> DataTypeID;

 public string DataTypeNameBase;

 public Nullable<int> Length;

 public Nullable<int> Precision;

 public Nullable<int> Scale;

 public Nullable<FB_Common__BlobSubTypeID> BlobSubTypeID;

 public string CharSetName;

 public FB_Common__ArrayBound[] ArrayBounds;
}//struct FB_Common__DataTypeDescr

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common
