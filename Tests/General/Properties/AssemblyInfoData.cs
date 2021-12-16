////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 20.11.2020.

namespace EFCore_LcpiOleDb_Tests.General{
////////////////////////////////////////////////////////////////////////////////
//class AssemblyInfoData

static class AssemblyInfoData
{
 private const string c_BaseDescr_Str="General Tests for EF Core LcpOleDb DataProvider";

#if   BUILD_CONF__NET6_0_0
 private const string c_BaseDescr_TargetPlatformPart="[NET6.0.0]";
#else
# error "Unknown target platform!"
#endif

 //-----------------------------------------------------------------------
#if DEBUG
 private const string c_CfgName="Debug";

 private const string c_BaseDescr_CfgPart="["+c_CfgName+"]";
#else
 private const string c_CfgName="Release";

 private const string c_BaseDescr_CfgPart="";
#endif

 //-----------------------------------------------------------------------
 public const string Title
  =c_BaseDescr_Str+" "+c_BaseDescr_TargetPlatformPart+c_BaseDescr_CfgPart;

 public const string Descr
  =Title;

 public const string Cfg
  =c_CfgName;
};//class AssemblyInfoData

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General
