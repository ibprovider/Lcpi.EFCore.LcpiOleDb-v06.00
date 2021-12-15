////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.02.2021.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_ADP
 =Structure.Structure_ADP;

using IscBase_Const
 =Core.Engines.Dbms.IscBase.IscBase_Const;

using FB_Common__SqlDataTypeNames
 =Core.Engines.Dbms.Firebird.Common.FB_Common__SqlDataTypeNames;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__SqlExpressionUtils

static class FB_Common__SqlExpressionUtils
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__SqlExpressionUtils;

 //-----------------------------------------------------------------------
 public static bool TypeIsBasedOnInt16(SqlExpression exprValue)
 {
  const string c_bugcheck_Src
   ="FB_Common__SqlExpressionUtils::TypeIsBasedOnInt16";

#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (exprValue);
#endif

  var sqlType
   =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
     (c_ErrSrcID,
      c_bugcheck_Src,
      "#001",
      exprValue);

  Debug.Assert(!Object.ReferenceEquals(sqlType,null));

  if(sqlType==Structure_TypeCache.TypeOf__System_Int16)
   return true;

  if(sqlType==Structure_TypeCache.TypeOf__System_Decimal)
  {
   //
   // No TypeMapping - no information for correct decision.
   //  
   if(Object.ReferenceEquals(exprValue.TypeMapping,null))
    return false;

   Debug.Assert(!string.IsNullOrEmpty(exprValue.TypeMapping.StoreTypeNameBase));

   if(Structure_ADP.EqualDatabaseTypeName(exprValue.TypeMapping.StoreTypeNameBase,FB_Common__SqlDataTypeNames.NUMERIC))
   {
    // NUMERIC(4-) based on SMALLINT

    Debug.Assert(!Object.ReferenceEquals(exprValue.TypeMapping.ClrType,null));
    Debug.Assert(exprValue.TypeMapping.ClrType==Structure_TypeCache.TypeOf__System_Decimal);

    //
    // No precision? It is generic NUMERIC.
    //
    if(!exprValue.TypeMapping.Precision.HasValue)
     return false;

    Debug.Assert(exprValue.TypeMapping.Precision.Value>0);

    //Hint
    Debug.Assert(IscBase_Const.c_SqlPrecision__NUMERIC__Int16==4);

    if(IscBase_Const.c_SqlPrecision__NUMERIC__Int16<exprValue.TypeMapping.Precision)
    {
     // NUMERIC based on INTEGER+

     return false;
    }//if

    Debug.Assert(exprValue.TypeMapping.Precision<=IscBase_Const.c_SqlPrecision__NUMERIC__Int16);

#if DEBUG
    //
    // Check another information.
    //
    if(exprValue.TypeMapping.Scale.HasValue)
    {
     Debug.Assert(exprValue.TypeMapping.Scale.Value>=0);
     Debug.Assert(exprValue.TypeMapping.Scale.Value<=exprValue.TypeMapping.Precision.Value);
    }//if
#endif

    // OK. It is NUMERIC based on SMALLINT.

    return true;
   }//if name of NUMERIC

   // Is not NUMERIC

   //
   // [2021-02-04] Expected DECIMAL only.
   //
   Debug.Assert(Structure_ADP.EqualDatabaseTypeName(exprValue.TypeMapping.StoreTypeNameBase,FB_Common__SqlDataTypeNames.DECIMAL));

   return false;
  }//if sqlType==System.Decimal

  // Another types.

  return false;
 }//TypeIsBasedOnInt16
};//class FB_Common__SqlExpressionUtils

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql
