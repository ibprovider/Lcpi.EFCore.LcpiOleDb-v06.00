////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.10.2021.
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__TypeMappingCache

static class FB_Common__TypeMappingCache
{
 public static readonly RelationalTypeMapping
  TypeMapping__BOOLEAN
   =Storage.Mapping.FB_Common__TypeMapping__BOOLEAN.Create
     ();

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__TIMESTAMP
   =Storage.Mapping.FB_Common__TypeMapping__TIMESTAMP.Create
     ();

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping_D1__TIME__as_TimeOnly
   =Storage.Mapping.D1.FB_Common__TypeMapping__TYPE_TIME__as_TimeOnly.Create
     ();

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping_D3__TIME__as_TimeOnly
   =Storage.Mapping.D3.FB_Common__TypeMapping__TYPE_TIME__as_TimeOnly.Create
     ();

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping_D1__TYPE_DATE__as_DateOnly
   =Storage.Mapping.D1.FB_Common__TypeMapping__TYPE_DATE__as_DateOnly.Create
     ();

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping_D3__TYPE_DATE__as_DateOnly
   =Storage.Mapping.D3.FB_Common__TypeMapping__TYPE_DATE__as_DateOnly.Create
     ();

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__TEXT
   =Storage.Mapping.FB_Common__TypeMapping__BLOB_TEXT.Create
     (/*charsetName*/null);

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__BINARY16
   =Storage.Mapping.FB_Common__TypeMapping__BINARY.Create
     (/*length*/16);

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__VARBINARY1
   =Storage.Mapping.FB_Common__TypeMapping__VARBINARY.Create
     (/*length*/1);

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__INT16
   =Storage.Mapping.FB_Common__TypeMapping__SMALLINT.Create
     ();

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__INT32
   =Storage.Mapping.FB_Common__TypeMapping__INTEGER.Create
     ();

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__INT64
   =Storage.Mapping.FB_Common__TypeMapping__BIGINT.Create
     ();

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__DECIMAL
   =Storage.Mapping.FB_Common__TypeMapping__DECIMAL.Create_Default
     ();

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__FLOAT
   =Storage.Mapping.FB_Common__TypeMapping__FLOAT.Create
     ();

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__DOUBLE
   =Storage.Mapping.FB_Common__TypeMapping__DOUBLE.Create
     ();

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__NUMERIC_4_3
   =Storage.Mapping.FB_Common__TypeMapping__NUMERIC.Create
     (/*precision*/4,
      /*scale*/3);

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__NUMERIC_9_4
   =Storage.Mapping.FB_Common__TypeMapping__NUMERIC.Create
     (/*precision*/9,
      /*scale*/4);

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__NUMERIC_18_1
   =Storage.Mapping.FB_Common__TypeMapping__NUMERIC.Create
     (/*precision*/18,
      /*scale*/1);

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__NUMERIC_18_4
   =Storage.Mapping.FB_Common__TypeMapping__NUMERIC.Create
     (/*precision*/18,
      /*scale*/4);

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__TimePart__Second
   =Storage.Mapping.FB_Common__TypeMapping__NUMERIC.Create
     (/*precision*/9,
      /*scale*/4);

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__TimePart__Millisecond
   =Storage.Mapping.FB_Common__TypeMapping__NUMERIC.Create
     (/*precision*/9,
      /*scale*/1);

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__TimeSpan__as_Decimal9_4
   =Storage.Mapping.FB_Common__TypeMapping__TimeSpan__as_Decimal9_4.Create
     ();

 //-----------------------------------------------------------------------
 public static readonly RelationalTypeMapping
  TypeMapping__TimeSpan__as_Decimal18_4
   =Storage.Mapping.FB_Common__TypeMapping__TimeSpan__as_Decimal18_4.Create
     ();
};//class FB_Common__TypeMappingCache

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common
