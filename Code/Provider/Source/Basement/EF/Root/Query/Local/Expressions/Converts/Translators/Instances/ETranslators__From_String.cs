////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.05.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Translators.Instances{
////////////////////////////////////////////////////////////////////////////////

using LOCAL_EVAL__Convert__Descr
 =Root.Query.Local.LcpiOleDb__LocalEval_Convert__Descr;

using LOCAL_EVAL__Convert__ETranslator__STD__SIMPLE
 =Root.Query.Local.Expressions.Converts.Translators.Std.ETranslator__Std__Simple;

////////////////////////////////////////////////////////////////////////////////
//class ETranslators__From_String

static class ETranslators__From_String
{
 public static readonly LOCAL_EVAL__Convert__Descr
  sm_TO__Object
   =new LOCAL_EVAL__Convert__Descr
     (new LOCAL_EVAL__Convert__ETranslator__STD__SIMPLE(Code.Convert_Code__String__Object.MethodInfo),
      null);

 public static readonly LOCAL_EVAL__Convert__Descr
  sm_TO__String
   =new LOCAL_EVAL__Convert__Descr
     (new LOCAL_EVAL__Convert__ETranslator__STD__SIMPLE(Code.Convert_Code__String__String.MethodInfo),
      Code.Convert_Code__String__String.Instance);

 //-------------------------------------------------------- NULLABLE
 public static readonly LOCAL_EVAL__Convert__Descr
  sm_TO__NullableDecimal
   =new LOCAL_EVAL__Convert__Descr
     (new LOCAL_EVAL__Convert__ETranslator__STD__SIMPLE(Code.Convert_Code__String__NullableDecimal.MethodInfo),
      Code.Convert_Code__String__NullableDecimal.Instance);

 public static readonly LOCAL_EVAL__Convert__Descr
  sm_TO__NullableDouble
   =new LOCAL_EVAL__Convert__Descr
     (new LOCAL_EVAL__Convert__ETranslator__STD__SIMPLE(Code.Convert_Code__String__NullableDouble.MethodInfo),
      Code.Convert_Code__String__NullableDouble.Instance);

 public static readonly LOCAL_EVAL__Convert__Descr
  sm_TO__NullableInt16
   =new LOCAL_EVAL__Convert__Descr
     (new LOCAL_EVAL__Convert__ETranslator__STD__SIMPLE(Code.Convert_Code__String__NullableInt16.MethodInfo),
      Code.Convert_Code__String__NullableInt16.Instance);

 public static readonly LOCAL_EVAL__Convert__Descr
  sm_TO__NullableInt32
   =new LOCAL_EVAL__Convert__Descr
     (new LOCAL_EVAL__Convert__ETranslator__STD__SIMPLE(Code.Convert_Code__String__NullableInt32.MethodInfo),
      Code.Convert_Code__String__NullableInt32.Instance);

 public static readonly LOCAL_EVAL__Convert__Descr
  sm_TO__NullableInt64
   =new LOCAL_EVAL__Convert__Descr
     (new LOCAL_EVAL__Convert__ETranslator__STD__SIMPLE(Code.Convert_Code__String__NullableInt64.MethodInfo),
      Code.Convert_Code__String__NullableInt64.Instance);

 public static readonly LOCAL_EVAL__Convert__Descr
  sm_TO__NullableSingle
   =new LOCAL_EVAL__Convert__Descr
     (new LOCAL_EVAL__Convert__ETranslator__STD__SIMPLE(Code.Convert_Code__String__NullableSingle.MethodInfo),
      Code.Convert_Code__String__NullableSingle.Instance);
};//class ETranslators__From_String

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Translators.Instances
