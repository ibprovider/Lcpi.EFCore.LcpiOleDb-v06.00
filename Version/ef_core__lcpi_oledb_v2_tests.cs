////////////////////////////////////////////////////////////////////////////////

using System.Reflection;

[assembly: AssemblyVersion("6.0.1.26944")]
[assembly: AssemblyFileVersion("6.0.1.26944")]

#if    (BUILD_CONF__NET6_0_0)
[assembly: AssemblyMetadata("ProductState.Name",ProductState.Name)]
#else
# error Unknown Target Platform!
#endif

/**/
