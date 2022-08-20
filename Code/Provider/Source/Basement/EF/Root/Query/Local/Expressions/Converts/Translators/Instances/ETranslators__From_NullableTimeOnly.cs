////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.07.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Translators.Instances{
////////////////////////////////////////////////////////////////////////////////

using LOCAL_EVAL__Convert__Descr
 =Root.Query.Local.LcpiOleDb__LocalEval_Convert__Descr;

using LOCAL_EVAL__Convert__ETranslator__STD__SIMPLE
 =Root.Query.Local.Expressions.Converts.Translators.Std.ETranslator__Std__Simple;

using LOCAL_EVAL__Convert__ETranslator__STD__WITH_CVT_CTX
 =Translators.Std.ETranslator__Std__WithCvtCtx;

////////////////////////////////////////////////////////////////////////////////
//class ETranslators__From_NullableTimeOnly

static class ETranslators__From_NullableTimeOnly
{
 public static readonly LOCAL_EVAL__Convert__Descr
  sm_TO__Object
   =new LOCAL_EVAL__Convert__Descr
     (new LOCAL_EVAL__Convert__ETranslator__STD__SIMPLE(Code.Convert_Code__NullableTimeOnly__Object.MethodInfo),
      null);

 public static readonly LOCAL_EVAL__Convert__Descr
  sm_TO__String
   =new LOCAL_EVAL__Convert__Descr
     (new LOCAL_EVAL__Convert__ETranslator__STD__WITH_CVT_CTX(Code.Convert_Code__NullableTimeOnly__String.MethodInfo),
      null);
};//class ETranslators__From_NullableTimeOnly

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Converts.Translators.Instances
