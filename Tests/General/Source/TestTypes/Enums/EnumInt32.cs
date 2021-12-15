////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 04.12.2020.

namespace EFCore_LcpiOleDb_Tests.General.TestTypes.Enums{
////////////////////////////////////////////////////////////////////////////////
//enum EnumInt32

enum EnumInt32:System.Int32
{
 negative__MAX   =System.Int32.MinValue,

 negative__FOUR  =-4,
 negative__THREE =-3,
 negative__TWO   =-2,
 negative__ONE   =-1,

 ZERO            =0,

 positive__ONE   =1,
 positive__TWO   =2,
 positive__THREE =3,
 positive__FOUR  =4,
 positive__SEVEN =7,

 positive__MAX   =System.Int32.MaxValue,
};//enum EnumInt32

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.TestTypes.Enums
