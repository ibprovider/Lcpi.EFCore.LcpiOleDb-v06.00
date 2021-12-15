////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.05.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Local.Expressions.Converts.Translators.Instances{
////////////////////////////////////////////////////////////////////////////////

using LOCAL_EVAL__Convert__Descr
 =Root.Query.Local.LcpiOleDb__LocalEval_Convert__Descr;

using LOCAL_EVAL__Convert__ETranslator__STD__WITH_CVT_CTX
 =Root.Query.Local.Expressions.Converts.Translators.Std.ETranslator__Std__WithCvtCtx;

using LOCAL_EVAL__Convert__ETranslator__STD__SIMPLE
 =Root.Query.Local.Expressions.Converts.Translators.Std.ETranslator__Std__Simple;

////////////////////////////////////////////////////////////////////////////////
//class ETranslators__From_String

static class ETranslators__From_String
{
 public static readonly LOCAL_EVAL__Convert__Descr
  sm_TO__NullableBoolean
   =new LOCAL_EVAL__Convert__Descr
     (new LOCAL_EVAL__Convert__ETranslator__STD__WITH_CVT_CTX(Code.Convert_Code__String__NullableBoolean.MethodInfo),
      Code.Convert_Code__String__NullableBoolean.Instance);

 public static readonly LOCAL_EVAL__Convert__Descr
  sm_TO__NullableDateOnly
   =new LOCAL_EVAL__Convert__Descr
     (new LOCAL_EVAL__Convert__ETranslator__STD__SIMPLE(Code.Convert_Code__String__NullableDateOnly.MethodInfo),
      Code.Convert_Code__String__NullableDateOnly.Instance);

 public static readonly LOCAL_EVAL__Convert__Descr
  sm_TO__NullableTimeOnly
   =new LOCAL_EVAL__Convert__Descr
     (new LOCAL_EVAL__Convert__ETranslator__STD__SIMPLE(Code.Convert_Code__String__NullableTimeOnly.MethodInfo),
      Code.Convert_Code__String__NullableTimeOnly.Instance);
};//class ETranslators__From_String

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Local.Expressions.Converts.Translators.Instances
