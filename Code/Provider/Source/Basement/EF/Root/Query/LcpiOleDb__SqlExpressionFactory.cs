////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.11.2020.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider
 =Query.Sql.Svcs.LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__SqlExpressionFactory

sealed partial class LcpiOleDb__SqlExpressionFactory
 :SqlExpressionFactory
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__SqlExpressionFactory;

 //-----------------------------------------------------------------------
 public LcpiOleDb__SqlExpressionFactory
                        (SqlExpressionFactoryDependencies             dependencies,
                         LcpiOleDb__IUnaryOperatorTranslatorProvider  unaryOperatorTranslator,
                         LcpiOleDb__IBinaryOperatorTranslatorProvider binaryOperatorTranslator,
                         Core.Core_ConnectionOptions                  cnOptions)
  :base(dependencies)
 {
  m_TypeMappingSource=dependencies.TypeMappingSource;

  Debug.Assert(!Object.ReferenceEquals(unaryOperatorTranslator,null));
  Debug.Assert(!Object.ReferenceEquals(binaryOperatorTranslator,null));
  Debug.Assert(!Object.ReferenceEquals(cnOptions,null));

  //--------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(unaryOperatorTranslator),
    unaryOperatorTranslator);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(binaryOperatorTranslator),
    binaryOperatorTranslator);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(cnOptions),
    cnOptions);

  //--------------------------
  m_UnaryOperatorTranslator
   =unaryOperatorTranslator;

  m_BinaryOperatorTranslator
   =binaryOperatorTranslator;

  m_CnOptions
   =cnOptions;

  //--------------------------
  m_DataFor_MethodCallTranslation
   =Core.Core_SvcUtils.QuerySvc<LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider>
     (cnOptions,
      LcpiOleDb__SvcIDs.LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider);

  Debug.Assert(!Object.ReferenceEquals(m_DataFor_MethodCallTranslation,null));

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(m_TypeMappingSource,null));
 }//LcpiOleDb__SqlExpressionFactory

 //Own interface ---------------------------------------------------------
 public SqlExpression ApplyTypeMapping2(SqlExpression         expr,
                                        RelationalTypeMapping typeMapping1,
                                        RelationalTypeMapping typeMapping2)
 {
  Debug.Assert(!Object.ReferenceEquals(expr,null));

  //----------------------------------------
  const string c_bugcheck_src
   ="LcpiOleDb__SqlExpressionFactory::ApplyTypeMapping2";

  //----------------------------------------
#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlType(expr);
#endif

  //----------------------------------------
  if(!Object.ReferenceEquals(expr.TypeMapping,null))
  {
   return expr;
  }//if

  Debug.Assert(Object.ReferenceEquals(expr.TypeMapping,null));

  //----------------------------------------
  if(!Object.ReferenceEquals(typeMapping1,null))
  {
   var r
    =this.ApplyTypeMapping(expr,typeMapping1);

   Check.BugCheck_Value_NotNull
    (c_ErrSrcID,
     c_bugcheck_src,
     "#001",
     nameof(r),
     r);

   if(!Object.ReferenceEquals(r.TypeMapping,null))
    return r;

   // [2020-01-03] What?
   Debug.Assert(false);
  }//if

  Debug.Assert(Object.ReferenceEquals(expr.TypeMapping,null));

  Debug.Assert(!Object.ReferenceEquals(typeMapping2,null));

  {
   var r
    =this.ApplyTypeMapping(expr,typeMapping2);

   Check.BugCheck_Value_NotNull
    (c_ErrSrcID,
     c_bugcheck_src,
     "#002",
     nameof(r),
     r);

   if(!Object.ReferenceEquals(r.TypeMapping,null))
    return r;

   // [2020-01-03] What?
   Debug.Assert(false);
  }//if

  Debug.Assert(Object.ReferenceEquals(expr.TypeMapping,null));

  return expr;
 }//ApplyTypeMapping2

 //-----------------------------------------------------------------------
 public RelationalTypeMapping GetTypeMapping__Throw(System.Type clrType)
 {
  Debug.Assert(!Object.ReferenceEquals(clrType,null));

  var r
   =m_TypeMappingSource.FindMapping
     (clrType);

  if(Object.ReferenceEquals(r,null))
  {
   ThrowError.TypeMappingErr__CantMapClrTypeToProviderDatatype
    (c_ErrSrcID,
     clrType);
  }//if

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//GetTypeMapping__Throw

 //SqlExpressionFactory interface ----------------------------------------
 public override SqlExpression ApplyDefaultTypeMapping(SqlExpression sqlExpression)
 {
  if(Object.ReferenceEquals(sqlExpression,null))
   return sqlExpression;

  if(!Object.ReferenceEquals(sqlExpression.TypeMapping,null))
   return sqlExpression;

  var tm=m_TypeMappingSource.FindMapping(sqlExpression.Type);

  if(Object.ReferenceEquals(tm,null))
   return sqlExpression;

  var r=this.ApplyTypeMapping(sqlExpression, tm);

  return r;
 }//ApplyDefaultTypeMapping

 //-----------------------------------------------------------------------
 public override SqlUnaryExpression MakeUnary(ExpressionType        operatorType,
                                              SqlExpression         operand,
                                              System.Type           type,
                                              RelationalTypeMapping typeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(operand,null));
  Debug.Assert(!Object.ReferenceEquals(operand.Type,null));
  Debug.Assert(!Object.ReferenceEquals(type,null));

  //
  // Gateway to LcpiOleDb__ISqlTreeNodeBuilder.MakeUnary
  //
  // May Fail. Don't cry. It is by design.
  //

  //------------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(MakeUnary),
    nameof(operand),
    operand);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(MakeUnary),
    nameof(type),
    type);

  //------------------------------------------------------------
  LcpiOleDb__ExpressionType operatorType2;

  if(!Core.Core_MapSysETypeToLcpiOleDbEType.TryMap
       (operatorType,
        out operatorType2))
  {
   // [2020-12-28] Throw error instead return null.

   ThrowError.SqlTranslatorErr__UnsupportedUnaryOperatorType
    (c_ErrSrcID,
     operatorType);
  }//if

  var unaryOp_e
   =((LcpiOleDb__ISqlTreeNodeBuilder)this).MakeUnary
     (operatorType2,
      operand,
      type);

  if(Object.ReferenceEquals(unaryOp_e,null))
  {
   ThrowError.SqlTranslatorErr__UnsupportedUnaryOperatorType
    (c_ErrSrcID,
     operatorType2,
     operand.Type,
     type);
  }//if

  Debug.Assert(!Object.ReferenceEquals(unaryOp_e, null));

  Debug.Assert(!Object.ReferenceEquals(unaryOp_e,null));

  var unaryOp_t
   =unaryOp_e as SqlUnaryExpression;

  if(Object.ReferenceEquals(unaryOp_t,null))
  {
   ThrowError.SqlTranslatorErr__CantPresentSqlUnaryOperationAsSqlUnaryExpression
    (c_ErrSrcID,
     operatorType,
     operand.Type,
     type);
  }//if

  Debug.Assert(!Object.ReferenceEquals(unaryOp_t,null));

  return unaryOp_t;
 }//MakeUnary

 //-----------------------------------------------------------------------
 public override SqlBinaryExpression MakeBinary(ExpressionType        operatorType,
                                                SqlExpression         left,
                                                SqlExpression         right,
                                                RelationalTypeMapping typeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(left.Type,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));
  Debug.Assert(!Object.ReferenceEquals(right.Type,null));

  //
  // Gateway to LcpiOleDb__ISqlTreeNodeBuilder.MakeBinary
  //
  // May Fail. Don't cry. It is by design.
  //

  //------------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(MakeBinary),
    nameof(left),
    left);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(MakeBinary),
    nameof(right),
    right);

  //------------------------------------------------------------
  LcpiOleDb__ExpressionType operatorType2;

  if(!Core.Core_MapSysETypeToLcpiOleDbEType.TryMap
       (operatorType,
        out operatorType2))
  {
   // [2020-12-28] Throw error instead return null.

   ThrowError.SqlTranslatorErr__UnsupportedBinaryOperatorType
    (c_ErrSrcID,
     operatorType);
  }//if

  var binaryOp_e
   =((LcpiOleDb__ISqlTreeNodeBuilder)this).MakeBinary
     (operatorType2,
      left,
      right);

  if(Object.ReferenceEquals(binaryOp_e,null))
  {
   ThrowError.SqlTranslatorErr__UnsupportedBinaryOperatorType
    (c_ErrSrcID,
     operatorType2,
     left.Type,
     right.Type);
  }//if

  Debug.Assert(!Object.ReferenceEquals(binaryOp_e,null));

  var binaryOp_t
   =binaryOp_e as SqlBinaryExpression;

  if(Object.ReferenceEquals(binaryOp_t,null))
  {
   ThrowError.SqlTranslatorErr__CantPresentSqlBinaryOperationAsSqlBinaryExpression
    (c_ErrSrcID,
     operatorType,
     left.Type,
     right.Type);
  }//if

  Debug.Assert(!Object.ReferenceEquals(binaryOp_t,null));

  return binaryOp_t;
 }//MakeBinary

 //-----------------------------------------------------------------------
 public override SqlFunctionExpression Coalesce(SqlExpression         left,
                                                SqlExpression         right,
                                                RelationalTypeMapping typeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(left,null));
  Debug.Assert(!Object.ReferenceEquals(left.Type,null));
  Debug.Assert(!Object.ReferenceEquals(right,null));
  Debug.Assert(!Object.ReferenceEquals(right.Type,null));

  //
  // Gateway to LcpiOleDb__ISqlTreeNodeBuilder.MakeBinary(Coalesce,...)
  //
  // May Fail. Don't cry. It is by design.
  //

  //------------------------------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Coalesce),
    nameof(left),
    left);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Coalesce),
    nameof(right),
    right);

  //------------------------------------------------------------
  var result_e
   =((LcpiOleDb__ISqlTreeNodeBuilder)this).MakeBinary
     (LcpiOleDb__ExpressionType.Coalesce,
      left,
      right);

  if(Object.ReferenceEquals(result_e,null))
  {
   ThrowError.SqlTranslatorErr__UnsupportedBinaryOperatorType
    (c_ErrSrcID,
     LcpiOleDb__ExpressionType.Coalesce,
     left.Type,
     right.Type);
  }//if

  Debug.Assert(!Object.ReferenceEquals(result_e,null));

  var result_t
   =result_e as SqlFunctionExpression;

  if(Object.ReferenceEquals(result_t,null))
  {
   ThrowError.SqlTranslatorErr__CantPresentSqlFunctionAsSqlFunctionExpression
    (c_ErrSrcID,
     "COALESCE");
  }//if

  Debug.Assert(!Object.ReferenceEquals(result_t,null));

  return result_t;
 }//Coalesce

 //-----------------------------------------------------------------------
 public override SqlConstantExpression Constant(object                value,
                                                RelationalTypeMapping typeMapping)
 {
  //
  // [2021-09-06]
  //
  //  Verification of external code work.
  //
  //  Have a problem? Try to improve a Helper__ExtractValueBaseType code.
  //

  const string c_bugcheck_src
   ="LcpiOleDb__SqlExpressionFactory::Constant";

  for(;;)
  {
   if(Object.ReferenceEquals(value,null))
    break;

   if(Object.ReferenceEquals(typeMapping,null))
    break;

   Check.Arg_NotNull
    (c_ErrSrcID,
     nameof(value),
     "typeMapping.ClrType",
     typeMapping.ClrType);

   var valueBaseType
    =Helper__ExtractValueBaseType
      (value);

   Debug.Assert(!Object.ReferenceEquals(valueBaseType,null));

   if(valueBaseType==typeMapping.ClrType.Extension__SwitchToUnderlying())
   {
    break;
   }//if

   if(valueBaseType==Structure_TypeCache.TypeOf__System_Object)
   {
    //
    // Known cases:
    //
    //  [2021-09-06] IList<object>
    //

    break;
   }//if Object

   //ERROR - wrong value type

   ThrowError.ArgErr__BadValueType
     (c_ErrSrcID,
      nameof(Constant),
      nameof(value),
      value.GetType(),
      typeMapping.ClrType);

   Debug.Assert(false);
  }//for[ever]

  var r
   =base.Constant
     (value,
      typeMapping);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#001",
    nameof(r),
    r);

  var r2_e
   =this.ApplyDefaultTypeMapping
     (r);

  Debug.Assert(!Object.ReferenceEquals(r2_e,null));

  var r2_t
   =Check.BugCheck_Value_NotNullAndInstanceOf<SqlConstantExpression,SqlExpression>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#002",
      nameof(r2_e),
      r2_e);

  return r2_t;
 }//Constant

 //Helper methods --------------------------------------------------------
 private static System.Type Helper__ExtractValueBaseType(object value)
 {
  Debug.Assert(!Object.ReferenceEquals(value,null));

  var valueType
   =value.GetType();

  Debug.Assert(!Object.ReferenceEquals(valueType,null));

  if(valueType.Extension__IsInstanceOfGenericList())
  {
   var valueType_Args
    =valueType.GetGenericArguments();

   Debug.Assert(!Object.ReferenceEquals(valueType_Args,null));

   Debug.Assert(valueType_Args.Length==1);

   Debug.Assert(!Object.ReferenceEquals(valueType_Args[0],null));

   var valueElementType
    =valueType_Args[0];

   Debug.Assert(!Object.ReferenceEquals(valueElementType,null));

   return valueElementType;
  }//if is IList<>

  return valueType;
 }//Helper__ExtractValueBaseType

 //private data ----------------------------------------------------------
 private readonly IRelationalTypeMappingSource
  m_TypeMappingSource;

 private readonly LcpiOleDb__IUnaryOperatorTranslatorProvider
  m_UnaryOperatorTranslator;

 private readonly LcpiOleDb__IBinaryOperatorTranslatorProvider
  m_BinaryOperatorTranslator;

 private readonly Core.Core_ConnectionOptions
  m_CnOptions;

 //--------------------------------------------------------
 private readonly LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider
  m_DataFor_MethodCallTranslation;
}
////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query
