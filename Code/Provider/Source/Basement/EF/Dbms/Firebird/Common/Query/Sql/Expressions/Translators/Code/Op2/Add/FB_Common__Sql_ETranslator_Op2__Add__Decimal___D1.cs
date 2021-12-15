////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 31.01.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using IscBase_Const
 =Core.Engines.Dbms.IscBase.IscBase_Const;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator_Op2__Add__Decimal___D1

//
// Two variants:
//
//  1. int16BasedType + int16BasedType -> int32Numeric
//
//  2. -> (DOUBLE)GenericDecimal
//

sealed class FB_Common__Sql_ETranslator_Op2__Add__Decimal___D1
 :FB_Common__Sql_ETranslator_Op2
{
 public static readonly FB_Common__Sql_ETranslator_Op2
  Instance
   =new FB_Common__Sql_ETranslator_Op2__Add__Decimal___D1();

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator_Op2__Add__Decimal___D1()
 {
 }//FB_Common__Sql_ETranslator_Op2__Add__Decimal___D1

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(opData.OperationType==LcpiOleDb__ExpressionType.Add);

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight,null));
  //Debug.Assert(!Object.ReferenceEquals(opData.SqlResultTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlExpressionFactory,null));

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft.Type,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight.Type,null));

#if DEBUG
  Debug.Assert
   (Core.SQL.Core_SQL__ExpressionUtils.DEBUG__GetSqlType(opData.SqlLeft)  ==Structure_TypeCache.TypeOf__System_Decimal ||
    Core.SQL.Core_SQL__ExpressionUtils.DEBUG__GetSqlType(opData.SqlRight) ==Structure_TypeCache.TypeOf__System_Decimal);

  Debug.Assert
   (Core.SQL.Core_SQL__ExpressionUtils.DEBUG__GetSqlType(opData.SqlLeft)!=Structure_TypeCache.TypeOf__System_Double);

  Debug.Assert
   (Core.SQL.Core_SQL__ExpressionUtils.DEBUG__GetSqlType(opData.SqlRight)!=Structure_TypeCache.TypeOf__System_Double);
#endif

  //------------------------------------------------------------

  //
  // [2021-01-02] No idea how to send here the arguments without TypeMapping.
  //

  //------------------------------------------------------------
#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (opData.SqlLeft);

  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (opData.SqlRight);
#endif

  //------------------------------------------------------------
  var r
   =Helper__BuildResult
     (opData);

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (r);
#endif

  return r;
 }//Translate

 //-----------------------------------------------------------------------
 private static SqlExpression Helper__BuildResult(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight,null));

  if(!FB_Common__SqlExpressionUtils.TypeIsBasedOnInt16(opData.SqlLeft))
   return Helper__BuildResult__DecimalAsDouble(opData);

  if(!FB_Common__SqlExpressionUtils.TypeIsBasedOnInt16(opData.SqlRight))
   return Helper__BuildResult__DecimalAsDouble(opData);

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight.TypeMapping,null));

  int scaleLeft
   =opData.SqlLeft.TypeMapping.Scale.GetValueOrDefault(0);

  Debug.Assert(scaleLeft>=0);
  Debug.Assert(scaleLeft<=IscBase_Const.c_SqlPrecision__NUMERIC__Int16);

  int scaleRight
   =opData.SqlLeft.TypeMapping.Scale.GetValueOrDefault(0);

  Debug.Assert(scaleRight>=0);
  Debug.Assert(scaleRight<=IscBase_Const.c_SqlPrecision__NUMERIC__Int16);

  int resultScale
   =Math.Min(scaleLeft,scaleRight);

  //
  // [2021-02-04] Save Decimal
  //
  //if(resultScale==0)
  // return Storage.Mapping.FB_Common__TypeMapping__INTEGER.Create();
  //
  //Debug.Assert(resultScale>0);

  var resultTypeMapping
   =Storage.Mapping.FB_Common__TypeMapping__NUMERIC.Create
     (IscBase_Const.c_SqlPrecision__NUMERIC__Int32,
      resultScale);

  return Helper__BuildOperation
          (opData.SqlLeft,
           opData.SqlRight,
           resultTypeMapping);
 }//Helper__BuildResult

 //-----------------------------------------------------------------------
 private static SqlExpression Helper__BuildResult__DecimalAsDouble(in tagOpData opData)
 {
  var expr1
   =Helper__BuildOperation
     (opData.SqlLeft,
      opData.SqlRight,
      FB_Common__TypeMappingCache.TypeMapping__DECIMAL);

  var expr2
   =opData.SqlTreeNodeBuilder.MakeUnary
     (LcpiOleDb__ExpressionType.Convert,
      expr1,
      Structure_TypeCache.TypeOf__System_Double); //throw

  return expr2;
 }//Helper__BuildResult__DecimalAsDouble

 //-----------------------------------------------------------------------
 private static SqlExpression Helper__BuildOperation
                                           (SqlExpression         exprLeft,
                                            SqlExpression         exprRight,
                                            RelationalTypeMapping resultTypeMapping)
 {
  return Nodes.FB_Common__Sql_ENode_Binary__Add.Create
         (exprLeft,
          exprRight,
          resultTypeMapping);
 }//Helper__BuildOperation
};//class FB_Common__Sql_ETranslator_Op2__Add__Decimal___D1

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code
