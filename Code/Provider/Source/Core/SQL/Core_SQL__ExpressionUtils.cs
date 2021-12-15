////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 24.12.2020.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.SQL{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class Core_SQL__ExpressionUtils

static class Core_SQL__ExpressionUtils
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Core_SQL__ExpressionUtils;

 //-----------------------------------------------------------------------
 public static System.Type GetSqlType
                             (ErrSourceID   err_src,
                              string        bugcheckPlace,
                              string        bugcheckPoint,
                              SqlExpression expr)
 {
  Debug.Assert(!Object.ReferenceEquals(expr,null));
  Debug.Assert(!Object.ReferenceEquals(expr.Type,null));

  var t
   =Helper__GetClrType
     (err_src,
      bugcheckPlace,
      bugcheckPoint,
      expr);

  Debug.Assert(!Object.ReferenceEquals(t,null));

  Debug.Assert(t.Extension__UnwrapNullableType()==t);

  var r
   =t.Extension__UnwrapMappingClrType();

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//GetSqlType

 //-----------------------------------------------------------------------
 public static SqlExpression RemoveConvertToString(SqlExpression expr)
 {
  SqlExpression e=expr;

  for(;;)
  {
   Debug.Assert(!Object.ReferenceEquals(e,null));

   var unaryExpression=e as SqlUnaryExpression;

   if(Object.ReferenceEquals(unaryExpression,null))
    break;

   //[2020-12-26] Not expected
   Debug.Assert(unaryExpression.OperatorType!=ExpressionType.ConvertChecked);

   if(unaryExpression.OperatorType!=ExpressionType.Convert)
    break;

   if(unaryExpression.Type!=Structure_TypeCache.TypeOf__System_String)
   {
#if DEBUG
    Debug.Assert(DEBUG__GetSqlType(e)!=Structure_TypeCache.TypeOf__System_String);
#endif

    break;
   }//if

#if DEBUG
   Debug.Assert(unaryExpression.Type==Structure_TypeCache.TypeOf__System_String);

   Debug.Assert(DEBUG__GetSqlType(e)==Structure_TypeCache.TypeOf__System_String);

   Debug.Assert(!Object.ReferenceEquals(unaryExpression.Operand,null));
#endif

   e=unaryExpression.Operand;
  }//for[ever]

  Debug.Assert(!Object.ReferenceEquals(e,null));

  return e;
 }//RemoveConvertToString

 //Debug methods ---------------------------------------------------------
#if DEBUG
 public static void DEBUG__CheckSqlTypeMapping(SqlExpression expr)
 {
  Debug.Assert(!Object.ReferenceEquals(expr,null));
  Debug.Assert(!Object.ReferenceEquals(expr.Type,null));

  Debug.Assert(!Object.ReferenceEquals(expr.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(expr.TypeMapping.ClrType,null));
 }//DEBUG__CheckSqlTypeMapping

 //-----------------------------------------------------------------------
 public static void DEBUG__CheckSqlTypeMapping__IsExpected
                                           (SqlExpression expr,
                                            System.Type   expectedType)
 {
  Debug.Assert(!Object.ReferenceEquals(expectedType,null));
  Debug.Assert(expectedType.Extension__UnwrapMappingClrType()==expectedType);

  //----------------------------------------
  DEBUG__CheckSqlTypeMapping
   (expr);

  Debug.Assert(expr.Type.Extension__UnwrapMappingClrType()==expectedType);

  Debug.Assert(expr.TypeMapping.ClrType.Extension__UnwrapMappingClrType()==expectedType);
 }//DEBUG__CheckSqlTypeMapping__IsExpected

 //-----------------------------------------------------------------------
 public static void DEBUG__CheckSqlTypeMapping__IsExpected
                                           (SqlExpression         expr,
                                            RelationalTypeMapping expectedTypeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(expectedTypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(expectedTypeMapping.ClrType,null));

  //----------------------------------------
  DEBUG__CheckSqlTypeMapping__IsExpected
   (expr,
    expectedTypeMapping.ClrType);
 }//DEBUG__CheckSqlTypeMapping__IsExpected

 //-----------------------------------------------------------------------
 public static void DEBUG__CheckSqlType(SqlExpression expr)
 {
  DEBUG__GetSqlType(expr);
 }//DEBUG__CheckSqlType

 //-----------------------------------------------------------------------
 public static System.Type DEBUG__GetSqlType(SqlExpression expr)
 {
  Debug.Assert(!Object.ReferenceEquals(expr,null));
  Debug.Assert(!Object.ReferenceEquals(expr.Type,null));

  if(!Object.ReferenceEquals(expr.TypeMapping,null))
  {
   Debug.Assert(!Object.ReferenceEquals(expr.TypeMapping.ClrType,null));

   return expr.TypeMapping.ClrType;
  }//if

  Debug.Assert(Object.ReferenceEquals(expr.TypeMapping,null));

  if(expr.Type==Structure.Structure_TypeCache.TypeOf__System_Object)
  {
   if(expr is SqlConstantExpression exprConst)
   {
    Debug.Assert(Object.ReferenceEquals(exprConst.Value,null));

    return expr.Type;
   }//if

   if(expr is SqlParameterExpression)
   {
    //Somebody uses parameter with type System.Object.

    //Expected that parameter has NULL value, but it is not fact ...

    return expr.Type;
   }//if

   Debug.Assert(false);

   return null;
  }//if expr.Type==typeof(object)

  //
  // Enumeration of types, which must be with TypeMapping ...
  //
  Debug.Assert(expr.Type!=Structure_TypeCache.TypeOf__System_Int16);
  Debug.Assert(expr.Type!=Structure_TypeCache.TypeOf__System_Int32);
  Debug.Assert(expr.Type!=Structure_TypeCache.TypeOf__System_Int64);
  Debug.Assert(expr.Type!=Structure_TypeCache.TypeOf__System_Single);
  Debug.Assert(expr.Type!=Structure_TypeCache.TypeOf__System_Double);
  Debug.Assert(expr.Type!=Structure_TypeCache.TypeOf__System_TimeSpan);
  Debug.Assert(expr.Type!=Structure_TypeCache.TypeOf__System_DateTime);
  Debug.Assert(expr.Type!=Structure_TypeCache.TypeOf__System_DateTimeOffset);
  Debug.Assert(expr.Type!=Structure_TypeCache.TypeOf__System_Boolean);
  Debug.Assert(expr.Type!=Structure_TypeCache.TypeOf__System_String);
  Debug.Assert(expr.Type!=Structure_TypeCache.TypeOf__System_Char);
  Debug.Assert(expr.Type!=Structure_TypeCache.TypeOf__System_Array_Byte);

  return null;
 }//DEBUG__GetSqlType

 //-----------------------------------------------------------------------
 public static void DEBUG__CheckSqlType__Is_Expected_Or_NULL
                                           (SqlExpression expr,
                                            System.Type   expectedType)
 {
  var actualType=DEBUG__GetSqlType(expr);

  Debug.Assert(!Object.ReferenceEquals(actualType,null));

  if(actualType==expectedType)
   return;

  if(actualType==Structure_TypeCache.TypeOf__System_Object)
   return;

  Debug.Assert(false);

  return;
 }//ExpectedSqlExpressionClrType_Or_NULL

#endif //DEBUG

 //Helper methods --------------------------------------------------------
 private static System.Type Helper__GetClrType
                             (ErrSourceID   err_src,
                              string        bugcheckPlace,
                              string        bugcheckPoint,
                              SqlExpression expr)
 {
  Debug.Assert(!Object.ReferenceEquals(expr,null));
  Debug.Assert(!Object.ReferenceEquals(expr.Type,null));

  if(!Object.ReferenceEquals(expr.TypeMapping,null))
  {
   if(Object.ReferenceEquals(expr.TypeMapping.ClrType,null))
   {
    ThrowBugCheck.TypeMapping_ClrType_Is_Null
     (err_src,
      bugcheckPlace,
      bugcheckPoint);
   }//if

   Debug.Assert(!Object.ReferenceEquals(expr.TypeMapping.ClrType,null));

   return expr.TypeMapping.ClrType;
  }//if

  Debug.Assert(Object.ReferenceEquals(expr.TypeMapping,null));

  return expr.Type;
 }//Helper__GetClrType
};//class Core_SQL__ExpressionUtils

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.SQL
