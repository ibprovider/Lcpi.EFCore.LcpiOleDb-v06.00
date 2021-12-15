////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.10.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op1.Translators.Instances{
////////////////////////////////////////////////////////////////////////////////

using LOCAL_EVAL__Op1__ETranslator__Std__Simple
 =Root.Query.Local.Expressions.Op1.Translators.Std.ETranslator__Std__Simple;

using LOCAL_EVAL__Op1__ETranslator__Std__Simple__Descr
 =Root.Query.Local.LcpiOleDb__LocalEval_Op1__Descr<Root.Query.Local.Expressions.Op1.Translators.Std.ETranslator__Std__Simple>;

////////////////////////////////////////////////////////////////////////////////
//class ETranslator__Negate__Decimal

static class ETranslator__Negate__Decimal
{
 public static readonly LOCAL_EVAL__Op1__ETranslator__Std__Simple__Descr
  Instance
   =new LOCAL_EVAL__Op1__ETranslator__Std__Simple__Descr
     (new LOCAL_EVAL__Op1__ETranslator__Std__Simple(Code.Op1_Code__Negate___Decimal.MethodInfo_V));
};//class ETranslator__Negate__Decimal

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.Translators.Instances
