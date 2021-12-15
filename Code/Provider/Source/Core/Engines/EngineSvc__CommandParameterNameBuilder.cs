////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines.
//                                      IBProvider and Contributors. 25.05.2018.
using System.Text;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines{
////////////////////////////////////////////////////////////////////////////////
//class EngineSvc__CommandParameterNameBuilder

interface EngineSvc__CommandParameterNameBuilder:Core_Svc
{
 /// <summary>
 ///  Creating of command parameter name
 /// </summary>
 /// <param name="invariantName">
 ///  Not null. Not Empty.
 /// </param>
 string GenParameterName(string invariantName);

 /// <summary>
 ///  Creating of command parameter name
 /// </summary>
 /// <param name="builder">
 ///  Not null.
 /// </param>
 /// <param name="invariantName">
 ///  Not null. Not Empty.
 /// </param>
 void GenParameterName(StringBuilder builder,
                       string        invariantName);

 /// <summary>
 ///  Creating of command parameter marker
 /// </summary>
 /// <param name="invariantName">
 ///  Not null. Not Empty.
 /// </param>
 string GenParameterMarker(string invariantName);

 /// <summary>
 ///  Creating of command parameter marker
 /// </summary>
 /// <param name="builder">
 ///  Not null.
 /// </param>
 /// <param name="invariantName">
 ///  Not null. Not Empty.
 /// </param>
 void GenParameterMarker(StringBuilder builder,
                           string        invariantName);

 /// <summary>
 ///  Extracting and invariant parameter name
 /// </summary>
 /// <param name="parameterName">
 ///  Not null. Not Empty.
 /// </param>
 string ExtractInvariantParameterName(string parameterName);
};//interface EngineSvc__CommandParameterNameBuilder

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines
