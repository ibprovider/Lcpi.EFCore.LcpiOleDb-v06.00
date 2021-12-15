////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 04.12.2020.

namespace EFCore_LcpiOleDb_Tests.General.TestTypes.Enums{
////////////////////////////////////////////////////////////////////////////////
//enum EnumInt16

enum EnumInt16:System.Int16
{
 negative__MAX   =System.Int16.MinValue,

 negative__FOUR = -4,
 negative__THREE =-3,
 negative__TWO   =-2,
 negative__ONE   =-1,

 ZERO            =0,

 positive__ONE   =1,
 positive__TWO   =2,
 positive__THREE =3,

 positive__SEVEN =7,

 positive__MAX   =System.Int16.MaxValue,
};//enum EnumInt16

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.TestTypes.Enums
