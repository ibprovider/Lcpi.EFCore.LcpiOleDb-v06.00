////////////////////////////////////////////////////////////////////////////////

using System.Reflection;

[assembly: AssemblyVersion(ProductState.Version)]
[assembly: AssemblyFileVersion(ProductState.Version)]

[assembly: AssemblyCulture("")]

#if    (BUILD_CONF__NET6_0_0)
[assembly: AssemblyMetadata("ProductState.Name",ProductState.Name)]
#else
# error Unknown Target Platform!
#endif

////////////////////////////////////////////////////////////////////////////////
//class ProductState

static class ProductState
{
 public const string Version="6.0.1.9504";

 //-----------------------------------------
 public const string Name=""; //RC2

 //-----------------------------------------
 public const string NamePart=""; //[RC2]
};//class ProductState

////////////////////////////////////////////////////////////////////////////////
/**/
