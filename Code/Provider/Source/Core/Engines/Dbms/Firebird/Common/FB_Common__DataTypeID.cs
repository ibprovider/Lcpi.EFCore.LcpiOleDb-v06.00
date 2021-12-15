////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 20.10.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common{
////////////////////////////////////////////////////////////////////////////////
//enum FB_Common__DataTypeID

enum FB_Common__DataTypeID
{
 VARCHAR                 = 1,
 CHAR                    = 2,

 DECIMAL                 = 3,
 NUMERIC                 = 4,

 INTEGER                 = 5,
 SMALLINT                = 6,
 BIGINT                  = 7,

 FLOAT                   = 8,
 DOUBLE                  = 9,

 BOOLEAN                 = 10,

 TIMESTAMP               = 11,
 DATE                    = 12,
 TIME                    = 13,

 BLOB                    = 14,

 VARBINARY               = 20,
 BINARY                  = 21,
};//enum FB_Common__DataTypeID

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common
