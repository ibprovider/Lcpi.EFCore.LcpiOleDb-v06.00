////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 20.11.2020.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//class AssemblyInfoData

static class AssemblyInfoData
{
 private const string c_BaseDescr_Str="LCPI EFCore DataProvider for LcpiOleDb";

#if   BUILD_CONF__NET5_0_0
 private const string c_BaseDescr_TargetPlatformPart="[NET5.0.0]";

 private const string c_TargetPlatform_FileSuffix="net5_0_0";
#elif BUILD_CONF__NET6_0_0
 private const string c_BaseDescr_TargetPlatformPart="[NET6.0.0]";

 private const string c_TargetPlatform_FileSuffix="net6_0_0";
#else
# error "Unknown target platform!"
#endif

 //-----------------------------------------------------------------------
#if DEBUG
 private const string c_CfgName="Debug";

 private const string c_Cfg_FileSiffix=".debug";

 private const string c_BaseDescr_CfgPart="["+c_CfgName+"]";
#else
 private const string c_CfgName="Release";

 private const string c_Cfg_FileSiffix="";

 private const string c_BaseDescr_CfgPart="";
#endif

 //-----------------------------------------------------------------------
 public const string Title
  =c_BaseDescr_Str+" "+c_BaseDescr_TargetPlatformPart+ProductState.NamePart+c_BaseDescr_CfgPart;

 public const string Descr
  =Title;

 public const string Cfg
  =c_CfgName;

 public const string Product
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb";

 //-----------------------------------------------------------------------
 public const string TestAssembly__General
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Tests.General-"+c_TargetPlatform_FileSuffix+c_Cfg_FileSiffix;
};//class AssemblyInfoData

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb
