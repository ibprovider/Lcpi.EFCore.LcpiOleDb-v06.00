////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.10.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op1.Translators.Spec{
////////////////////////////////////////////////////////////////////////////////

using FB_Common__Data
 =Common.FB_Common__Data;

using Root.Query.Local.Extensions.LcpiOleDb__LocalEval_Services__Extensions;

////////////////////////////////////////////////////////////////////////////////
//class ETranslator__Negate__Int32

sealed class ETranslator__Negate__Int32
 :Root.Query.Local.LcpiOleDb__LocalEval_UnaryTranslator
{
 public static readonly Root.Query.Local.LcpiOleDb__LocalEval_Op1__Descr<ETranslator__Negate__Int32>
  Instance
   =new Root.Query.Local.LcpiOleDb__LocalEval_Op1__Descr<ETranslator__Negate__Int32>
     (new ETranslator__Negate__Int32());

 //-----------------------------------------------------------------------
 private ETranslator__Negate__Int32()
 {
 }//ETranslator__Negate__Int32

 //LcpiOleDb__LocalEval_UnaryTranslator interface ------------------------
 public override Expression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Operand,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Operand.Type,null));

  Debug.Assert(opData.Operand.Type==Structure.Structure_TypeCache.TypeOf__System_Int32);

  //----------------------------------------
  var exprResult
   =opData.ExpressionServices.Extension__MakeBinary__Subtract__Throw
     (FB_Common__Data.sm_ConstantExpression__Int32__ZERO,
      opData.Operand);

  Debug.Assert(!Object.ReferenceEquals(exprResult,null));

  //----------------------------------------
  return exprResult;
 }//Translate
};//class ETranslator__Negate__Int32

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D0.Expressions.Op1.Translators.Spec
