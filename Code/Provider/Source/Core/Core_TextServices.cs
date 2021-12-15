////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 16.02.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////
//interface Core_TextServices

/// <summary>
///  Interface for text processing support.
/// </summary>
interface Core_TextServices:Core_Svc
{
 /// <summary>
 ///  Test empty symbol.
 /// </summary>
 /// <param name="text">
 ///  Not null.
 /// </param>
 /// <param name="offer">
 ///  Offset within text.
 /// </param>
 /// <returns>
 ///  0, if symbol is not empty (space). Otherwise, number of chars in this "empty" symbol.
 /// </returns>
 int Test_Empty_Symbol(string text,int offset);
};//interface Core_TextServices

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core
