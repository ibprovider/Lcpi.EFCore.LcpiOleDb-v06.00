////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.10.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D0.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

using FB_Common__Sql_ETranslator_MethodCall
 =Common.Query.Sql.Expressions.Translators.FB_Common__Sql_ETranslator_MethodCall;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0_D0__Sql_ETranslator__QUERABLE__AVG

sealed class FB_V03_0_0_D0__Sql_ETranslator__QUERABLE__AVG
 :FB_Common__Sql_ETranslator_MethodCall
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_V03_0_0_D0__Sql_ETranslator__QUERABLE__AVG;

 //-----------------------------------------------------------------------
 public static readonly FB_Common__Sql_ETranslator_MethodCall.tagDescr
  Instance
   =new FB_Common__Sql_ETranslator_MethodCall.tagDescr
     (Structure_MethodIdCache.MethodIdOf__QUERABLE__AVG,
      new FB_V03_0_0_D0__Sql_ETranslator__QUERABLE__AVG());

 //-----------------------------------------------------------------------
 private FB_V03_0_0_D0__Sql_ETranslator__QUERABLE__AVG()
 {
 }//FB_V03_0_0_D0__Sql_ETranslator__QUERABLE__AVG

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  const string c_bugcheck_src
   ="FB_V03_0_0_D0__Sql_ETranslator__QUERABLE__AVG::Translate";

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  Debug.Assert(opData.MethodId.Equals(Structure_MethodIdCache.MethodIdOf__QUERABLE__AVG));

  //----------------------------------------
  Debug.Assert(Object.ReferenceEquals(opData.Instance,null));

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==1);

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0],null));
  Debug.Assert(!Object.ReferenceEquals(opData.Arguments[0].Type,null));

  //----------------------------------------
  var exprOperand
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping(opData.Arguments[0]);

  Debug.Assert(!Object.ReferenceEquals(exprOperand,null));
  Debug.Assert(!Object.ReferenceEquals(exprOperand.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprOperand.TypeMapping,null));

  //------------------------------------------------------------
  var exprOperand__sqlType
   =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
    (c_ErrSrcID,
     c_bugcheck_src,
     "#001",
     exprOperand);

  Debug.Assert(!Object.ReferenceEquals(exprOperand,null));

  //------------------------------------------------------------
  if(exprOperand__sqlType!=Structure_TypeCache.TypeOf__System_Double)
  {
   //
   // Always translate to double for avoid lost of precision.
   //
   // Firebird: AVG(DECIMAL(x,0)) -> DECIMAL(y,0)
   //

   exprOperand
    =Helper__AdjustOperandToDouble
      (opData,
       exprOperand);
  }//if

  //------------------------------------------------------------
  SqlExpression
   exprResult
    =opData.SqlTreeNodeBuilder.MakeCall
      (Structure_MethodIdCache.MethodIdOf__BUILTIN_SQL__AVG,
       /*instance*/null,
       new[]{exprOperand});

  Debug.Assert(!Object.ReferenceEquals(exprResult,null));

  //------------------------------------------------------------
  if(exprOperand__sqlType==Structure_TypeCache.TypeOf__System_Single)
  {
   //
   // adjust to variant:
   //  public static float Average(this IQueryable<float> source)
   //

   exprResult
    =opData.SqlTreeNodeBuilder.MakeUnary
      (LcpiOleDb__ExpressionType.Convert,
       exprResult,
       Structure_TypeCache.TypeOf__System_Single);
       
   Debug.Assert(!Object.ReferenceEquals(exprResult,null));
  }//if

  //------------------------------------------------------------
  return exprResult;
 }//Translate

 //Helper methods --------------------------------------------------------
 private static SqlExpression Helper__AdjustOperandToDouble
                                           (in tagOpData  opData,
                                            SqlExpression exprOperand)
 {
  Debug.Assert(!Object.ReferenceEquals(exprOperand,null));
  Debug.Assert(!Object.ReferenceEquals(exprOperand.Type,null));
  Debug.Assert(!Object.ReferenceEquals(exprOperand.TypeMapping,null));

  //----------------------------------------
  if(exprOperand is DistinctExpression distinctExpression)
  {
   Debug.Assert(!Object.ReferenceEquals(distinctExpression.Operand,null));

   var expr1
    =opData.SqlTreeNodeBuilder.MakeUnary
      (LcpiOleDb__ExpressionType.Convert,
       distinctExpression.Operand,
       Structure_TypeCache.TypeOf__System_Double);
       
   Debug.Assert(!Object.ReferenceEquals(expr1,null));

   var expr2
    =distinctExpression.Update(expr1);

   Debug.Assert(!Object.ReferenceEquals(expr2,null));

   return expr2;
  }//if

  {
   var expr1
    =opData.SqlTreeNodeBuilder.MakeUnary
      (LcpiOleDb__ExpressionType.Convert,
       exprOperand,
       Structure_TypeCache.TypeOf__System_Double);

   Debug.Assert(!Object.ReferenceEquals(expr1,null));

   return expr1;
  }//local
 }//Helper__AdjustOperand

 //-----------------------------------------------------------------------
 private static bool Helper__AdjustOperand__NeedCvtToDouble(SqlExpression exprOperand)
 {
  Debug.Assert(!Object.ReferenceEquals(exprOperand,null));

  const string c_bugcheck_src
   ="FB_V03_0_0_D0__Sql_ETranslator__QUERABLE__AVG::Helper__AdjustOperand__NeedCvtToDouble";

  var sqlType
   =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
    (c_ErrSrcID,
     c_bugcheck_src,
     "#001",
     exprOperand);

  Debug.Assert(!Object.ReferenceEquals(exprOperand,null));

  if(sqlType.Extension__IsInteger__Exact())
   return true;

  return false;
 }//Helper__AdjustOperand__NeedCvtToDouble
};//class FB_V03_0_0_D0__Sql_ETranslator__QUERABLE__AVG

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D0.Expressions.Translators.Code
