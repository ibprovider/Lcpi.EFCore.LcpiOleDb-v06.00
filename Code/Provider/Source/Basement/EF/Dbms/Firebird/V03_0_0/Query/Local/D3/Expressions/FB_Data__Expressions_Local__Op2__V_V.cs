////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.03.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D3.Expressions{
////////////////////////////////////////////////////////////////////////////////
//using

using Common_ETRS
 =Root.Query.Local.Expressions.Op2.Translators.Instances;

using Common_ETR_STD
 =Root.Query.Local.Expressions.Op2.Translators.Std;

using FB3_D0_ETRS
 =Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.Translators.Instances;

using FB3_D3_ETRS
 =Firebird.V03_0_0.Query.Local.D3.Expressions.Op2.Translators.Instances;

using LcpiOleDb__LocalEval_Op2__Map
 =Root.Query.Local.LcpiOleDb__LocalEval_Op2__Map;

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Data__Expressions_Local__Op2__V_V

static partial class FB_Data__Expressions_Local__Op2__V_V
{
 public static readonly LcpiOleDb__LocalEval_Op2__Map
  Data
   =Helper__BuildOp2Map();

 //helper methods --------------------------------------------------------
 private static LcpiOleDb__LocalEval_Op2__Map Helper__BuildOp2Map()
 {
  var op2Map
   =new LcpiOleDb__LocalEval_Op2__Map();

  Helper__Reg__Concat(op2Map);
  Helper__Reg__Add(op2Map);
  Helper__Reg__Subtract(op2Map);
  Helper__Reg__Multiply(op2Map);
  Helper__Reg__Divide(op2Map);
  Helper__Reg__Equal(op2Map);
  Helper__Reg__NotEqual(op2Map);
  Helper__Reg__LessThan(op2Map);
  Helper__Reg__LessThanOrEqual(op2Map);
  Helper__Reg__GreaterThan(op2Map);
  Helper__Reg__GreaterThanOrEqual(op2Map);
  Helper__Reg__OrElse(op2Map);
  Helper__Reg__AndAlso(op2Map);
  Helper__Reg__Or(op2Map);
  Helper__Reg__Coalesce(op2Map);
  Helper__Reg__ArrayIndex(op2Map);

  return op2Map;;
 }//Helper__BuildOp2Map

 //-----------------------------------------------------------------------
 private static LcpiOleDb__LocalEval_Op2__Map.tagRegOperator
  Add(this LcpiOleDb__LocalEval_Op2__Map.tagRegOperator                                         regOp,
      Root.Query.Local.LcpiOleDb__LocalEval_Op2__Descr<Common_ETR_STD.ETranslator__Std__Simple> op2Descr)
 {
  Debug.Assert(!Object.ReferenceEquals(op2Descr.Translator,null));
  Debug.Assert(!Object.ReferenceEquals(op2Descr.Translator.LeftType,null));
  Debug.Assert(!Object.ReferenceEquals(op2Descr.Translator.RightType,null));

  return regOp.Add
           (op2Descr.Translator.LeftType,
            op2Descr.Translator.RightType,
            op2Descr);
 }//Add

 //-----------------------------------------------------------------------
 private static LcpiOleDb__LocalEval_Op2__Map.tagRegOperator
  Add(this LcpiOleDb__LocalEval_Op2__Map.tagRegOperator                                            regOp,
      Root.Query.Local.LcpiOleDb__LocalEval_Op2__Descr<Common_ETR_STD.ETranslator__Std__WithOpCtx> op2Descr)
 {
  Debug.Assert(!Object.ReferenceEquals(op2Descr.Translator,null));
  Debug.Assert(!Object.ReferenceEquals(op2Descr.Translator.LeftType,null));
  Debug.Assert(!Object.ReferenceEquals(op2Descr.Translator.RightType,null));

  return regOp.Add
           (op2Descr.Translator.LeftType,
            op2Descr.Translator.RightType,
            op2Descr);
 }//Add

 //-----------------------------------------------------------------------
 private static LcpiOleDb__LocalEval_Op2__Map.tagRegOperator
  Add_Concat(this LcpiOleDb__LocalEval_Op2__Map.tagRegOperator regOp,
             System.Type                                       typeLeft,
             System.Type                                       typeRight)
 {
  Debug.Assert(!Object.ReferenceEquals(typeLeft,null));
  Debug.Assert(!Object.ReferenceEquals(typeRight,null));

  return regOp.Add
           (typeLeft,
            typeRight,
            Common_ETR_STD.ETranslator__Std__Concat_obj.InstanceDescr);
 }//Add_Concat
};//class FB_Data__Expressions_Local__Op2__V_V

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D3.Expressions
