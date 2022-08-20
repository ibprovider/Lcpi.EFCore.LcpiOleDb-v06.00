////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.07.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Translators.Instances{
////////////////////////////////////////////////////////////////////////////////

using LOCAL_EVAL__Op2__ETranslator__Std__Simple
 =Root.Query.Local.Expressions.Op2.Translators.Std.ETranslator__Std__Simple;

using LOCAL_EVAL__Op2__ETranslator__Std__Simple__Descr
 =Root.Query.Local.LcpiOleDb__LocalEval_Op2__Descr<Root.Query.Local.Expressions.Op2.Translators.Std.ETranslator__Std__Simple>;

////////////////////////////////////////////////////////////////////////////////
//class ETranslators__NotEqual__NullableDateOnly

static class ETranslators__NotEqual__NullableDateOnly
{
 public static readonly LOCAL_EVAL__Op2__ETranslator__Std__Simple__Descr
  sm_Instance__DateOnly
   =new LOCAL_EVAL__Op2__ETranslator__Std__Simple__Descr
     (new LOCAL_EVAL__Op2__ETranslator__Std__Simple(Code.Op2_Code__NotEqual___NullableDateOnly__DateOnly.MethodInfo_V_V),
      Code.Op2_Code__NotEqual___NullableDateOnly__DateOnly.Instance);

 //-------------------------------------------------------- NULLABLE
 public static readonly LOCAL_EVAL__Op2__ETranslator__Std__Simple__Descr
  sm_Instance__NullableDateOnly
   =new LOCAL_EVAL__Op2__ETranslator__Std__Simple__Descr
     (new LOCAL_EVAL__Op2__ETranslator__Std__Simple(Code.Op2_Code__NotEqual___NullableDateOnly__NullableDateOnly.MethodInfo_V_V),
      Code.Op2_Code__NotEqual___NullableDateOnly__NullableDateOnly.Instance);
};//class ETranslators__NotEqual__NullableDateOnly

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Translators.Instances
