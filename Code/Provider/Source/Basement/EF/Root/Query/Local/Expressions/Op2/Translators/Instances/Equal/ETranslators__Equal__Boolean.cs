////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.01.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Translators.Instances{
////////////////////////////////////////////////////////////////////////////////

using LOCAL_EVAL__Op2__ETranslator__Std__Simple
 =Root.Query.Local.Expressions.Op2.Translators.Std.ETranslator__Std__Simple;

using LOCAL_EVAL__Op2__ETranslator__Std__Simple__Descr
 =Root.Query.Local.LcpiOleDb__LocalEval_Op2__Descr<Root.Query.Local.Expressions.Op2.Translators.Std.ETranslator__Std__Simple>;

using LOCAL_EVAL__Op2__ETranslator__Std__WithOpCtx
 =Root.Query.Local.Expressions.Op2.Translators.Std.ETranslator__Std__WithOpCtx;

using LOCAL_EVAL__Op2__ETranslator__Std__WithOpCtx__Descr
 =Root.Query.Local.LcpiOleDb__LocalEval_Op2__Descr<Root.Query.Local.Expressions.Op2.Translators.Std.ETranslator__Std__WithOpCtx>;

////////////////////////////////////////////////////////////////////////////////
//class ETranslators__Equal__Boolean

static class ETranslators__Equal__Boolean
{
 public static readonly LOCAL_EVAL__Op2__ETranslator__Std__Simple__Descr
  sm_Instance__Boolean
   =new LOCAL_EVAL__Op2__ETranslator__Std__Simple__Descr
     (new LOCAL_EVAL__Op2__ETranslator__Std__Simple(Code.Op2_Code__Equal___Boolean__Boolean.MethodInfo_V_V),
      Code.Op2_Code__Equal___Boolean__Boolean.Instance);

 public static readonly LOCAL_EVAL__Op2__ETranslator__Std__WithOpCtx__Descr
  sm_Instance__String
   =new LOCAL_EVAL__Op2__ETranslator__Std__WithOpCtx__Descr
     (new LOCAL_EVAL__Op2__ETranslator__Std__WithOpCtx(Code.Op2_Code__Equal___Boolean__String.MethodInfo_V_V),
      Code.Op2_Code__Equal___Boolean__String.Instance);

 //-------------------------------------------------------- NULLABLE
 public static readonly LOCAL_EVAL__Op2__ETranslator__Std__Simple__Descr
  sm_Instance__NullableBoolean
   =new LOCAL_EVAL__Op2__ETranslator__Std__Simple__Descr
     (new LOCAL_EVAL__Op2__ETranslator__Std__Simple(Code.Op2_Code__Equal___Boolean__NullableBoolean.MethodInfo_V_V),
      Code.Op2_Code__Equal___Boolean__NullableBoolean.Instance);
};//class ETranslators__Equal__Boolean

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Translators.Instances
