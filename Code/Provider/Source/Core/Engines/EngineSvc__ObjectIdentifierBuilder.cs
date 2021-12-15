////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines.
//                                      IBProvider and Contributors. 24.05.2018.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines{
////////////////////////////////////////////////////////////////////////////////
//interface EngineSvc__ObjectIdentifierBuilder

/// <summary>
///  Interface for support of command builder
/// </summary>
interface EngineSvc__ObjectIdentifierBuilder:Core_Svc
{
 /// <summary>
 ///  Creating of quoted identifier
 /// </summary>
 /// <param name="unquotedIdentifier">
 ///  Not null. Not Empty.
 /// </param>
 string QuoteIdentifier(string unquotedIdentifier);

 /// <summary>
 ///  Creating of quoted identifier
 /// </summary>
 /// <param name="builder">
 ///  Not null.
 /// </param>
 /// <param name="unquotedIdentifier">
 ///  Not null. Not Empty.
 /// </param>
 void QuoteIdentifier(System.Text.StringBuilder builder,
                      string                    unquotedIdentifier);
};//interface EngineSvc__ObjectIdentifierBuilder

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines
