////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 15.05.2018.
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Design;

using Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

////////////////////////////////////////////////////////////////////////////////

[assembly: AssemblyTitle(AssemblyInfoData.Title)]
[assembly: AssemblyDescription(AssemblyInfoData.Descr)]
[assembly: AssemblyConfiguration(AssemblyInfoData.Cfg)]

[assembly: AssemblyProduct(AssemblyInfoData.Product)]

[assembly: AssemblyInformationalVersion(ProductState.Version)]

[assembly: ComVisible(false)]

[assembly: DesignTimeProviderServices("Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Design.Internal.LcpiOleDb__DesignTimeServices")]

[assembly: System.Runtime.Versioning.SupportedOSPlatform("windows")]

////////////////////////////////////////////////////////////////////////////////
//Support for Tests

[assembly: InternalsVisibleTo
  (AssemblyInfoData.TestAssembly__General+", PublicKey="
   +"002400000480000094000000060200000024000052534131000400000100010031585520470334"
   +"64ce90aec77287bc095f857b499eb5ca5ecfb8a6aaa74c1d1e46cd19f22a92180c33eff2fa5440"
   +"69998755360dbb067548b42857da0c6292b5a64eda7c358c212424f04793b39e0dc48eaa1b01ce"
   +"617f6ef741782d0e05595ddb0068e266e547eff0ca7a09f0c484260005a27fe2bb2b07ac359f15"
   +"e4b3a7b7")]

////////////////////////////////////////////////////////////////////////////////
