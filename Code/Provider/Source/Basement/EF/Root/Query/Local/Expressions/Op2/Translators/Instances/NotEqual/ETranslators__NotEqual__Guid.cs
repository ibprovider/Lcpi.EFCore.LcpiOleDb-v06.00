////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 23.06.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Translators.Instances{
////////////////////////////////////////////////////////////////////////////////

using LOCAL_EVAL__Op2__ETranslator__Std__Simple
 =Root.Query.Local.Expressions.Op2.Translators.Std.ETranslator__Std__Simple;

using LOCAL_EVAL__Op2__ETranslator__Std__Simple__Descr
 =Root.Query.Local.LcpiOleDb__LocalEval_Op2__Descr<Root.Query.Local.Expressions.Op2.Translators.Std.ETranslator__Std__Simple>;

////////////////////////////////////////////////////////////////////////////////
//class ETranslators__NotEqual__Guid

static class ETranslators__NotEqual__Guid
{
 public static readonly LOCAL_EVAL__Op2__ETranslator__Std__Simple__Descr
  sm_Instance__Guid
   =new LOCAL_EVAL__Op2__ETranslator__Std__Simple__Descr
     (new LOCAL_EVAL__Op2__ETranslator__Std__Simple(Code.Op2_Code__NotEqual___Guid__Guid.MethodInfo_V_V),
      Code.Op2_Code__NotEqual___Guid__Guid.Instance);

 //-------------------------------------------------------- NULLABLE
 public static readonly LOCAL_EVAL__Op2__ETranslator__Std__Simple__Descr
  sm_Instance__NullableGuid
   =new LOCAL_EVAL__Op2__ETranslator__Std__Simple__Descr
     (new LOCAL_EVAL__Op2__ETranslator__Std__Simple(Code.Op2_Code__NotEqual___Guid__NullableGuid.MethodInfo_V_V),
      Code.Op2_Code__NotEqual___Guid__NullableGuid.Instance);
};//class ETranslators__NotEqual__Guid

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Translators.Instances
