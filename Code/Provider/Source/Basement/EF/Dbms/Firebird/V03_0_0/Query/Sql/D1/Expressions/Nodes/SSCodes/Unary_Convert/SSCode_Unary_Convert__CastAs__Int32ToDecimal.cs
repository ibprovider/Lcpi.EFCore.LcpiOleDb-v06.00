////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.10.2021.
using System;
using System.Diagnostics;
using System.Data;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1.Expressions.Nodes.SSCodes.Unary_Convert{
////////////////////////////////////////////////////////////////////////////////
//using

using FB_Common__Sql_ENode_Unary__Convert
 =Common.Query.Sql.Expressions.Nodes.FB_Common__Sql_ENode_Unary__Convert;

using FB_Common__QuerySqlGenerator
 =Common.Query.Sql.FB_Common__QuerySqlGenerator;

using IscBase_Const
 =Core.Engines.Dbms.IscBase.IscBase_Const;

using IscBase_Utils
 =Core.Engines.Dbms.IscBase.IscBase_Utils;

using FB_Common__SqlDataTypeNames
 =Core.Engines.Dbms.Firebird.Common.FB_Common__SqlDataTypeNames;

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class SSCode_Unary_Convert__CastAs__Int32ToDecimal

sealed class SSCode_Unary_Convert__CastAs__Int32ToDecimal
 :FB_Common__Sql_ENode_Unary__Convert.SSCode
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_V03_0_0_D1__Sql_ENode__SSCode_Unary_Convert__CastAs__Int32ToDecimal;

 //-----------------------------------------------------------------------
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance
   =new SSCode_Unary_Convert__CastAs__Int32ToDecimal();

 //-----------------------------------------------------------------------
 private SSCode_Unary_Convert__CastAs__Int32ToDecimal()
 {
 }//SSCode_Unary_Convert__CastAs__Int32ToDecimal

 //interface -------------------------------------------------------------
 public override void GenerateSQL(FB_Common__QuerySqlGenerator        sqlGenerator,
                                  FB_Common__Sql_ENode_Unary__Convert sqlNode)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlGenerator,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode.Type,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode.TypeMapping.StoreType,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode.Operand,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode.Operand.Type,null));

  Debug.Assert(sqlNode.TypeMapping.DbType.HasValue);
  Debug.Assert(sqlNode.Operand.TypeMapping.DbType.HasValue);

  Debug.Assert(sqlNode.TypeMapping.DbType==DbType.Decimal);
  Debug.Assert(sqlNode.Operand.TypeMapping.DbType==DbType.Int32);

  Debug.Assert(sqlNode.TypeMapping.StoreType.Length>0);
  Debug.Assert(sqlNode.TypeMapping.StoreType.Trim()==sqlNode.TypeMapping.StoreType);

  //----------------------------------------
  if(Helper__UseArgumentAsIs(sqlNode))
  {
   //Just use argument AS IS.

   sqlGenerator.VisitAndWrapIntoBrackets(sqlNode.Operand,/*Parent*/null);

   return;
  }//if

  Debug.Assert(sqlNode.TypeMapping.Precision.HasValue);
  Debug.Assert(sqlNode.TypeMapping.Precision.Value>0);

  if(IscBase_Const.c_SqlPrecision__NUMERIC__Int32<sqlNode.TypeMapping.Precision.Value)
  {
   //ERROR - required precision isn't supported by the current (1) dialect

   ThrowError.SqlGenErr__DecimalPrecisionNotSupportedInCurrentCnDialect
    (c_ErrSrcID,
     IscBase_Utils.GetConnectionDialect(sqlGenerator.CnOptions),
     sqlNode.TypeMapping.StoreTypeNameBase,
     sqlNode.TypeMapping.Precision.Value);

   Debug.Assert(false);
  }//if

  Debug.Assert(sqlNode.TypeMapping.Precision.Value<=IscBase_Const.c_SqlPrecision__NUMERIC__Int32);

  sqlGenerator.Sql.Append("CAST(");

  sqlGenerator.VisitAndWrapIntoBrackets(sqlNode.Operand,/*Parent*/null);

  sqlGenerator.Sql.Append(" AS ");

  sqlGenerator.Sql.Append(sqlNode.TypeMapping.StoreType);
 }//Generate

 //Helper methods --------------------------------------------------------
 private static bool Helper__UseArgumentAsIs(SqlUnaryExpression sqlNode)
 {
  if(!sqlNode.TypeMapping.Precision.HasValue)
  {
   //No precision --> no scale!
   Debug.Assert(!sqlNode.TypeMapping.Scale.HasValue);

   return true;
  }//if

  Debug.Assert(sqlNode.TypeMapping.Precision.HasValue);
  Debug.Assert(sqlNode.TypeMapping.Precision.Value>0);

  //------------------------------------------------------------
  Debug.Assert(!string.IsNullOrEmpty(sqlNode.TypeMapping.StoreTypeNameBase));

  if(Structure_ADP.EqualDatabaseTypeName(sqlNode.TypeMapping.StoreTypeNameBase,FB_Common__SqlDataTypeNames.NUMERIC))
  {
   //
   // Special processing for NUMERIC
   //
   // NUMERIC(4-) based on SMALLINT
   // NUMERIC(5+) based on INTEGER+
   //

   Debug.Assert(IscBase_Const.c_SqlPrecision__NUMERIC__Int16==4);

   if(IscBase_Const.c_SqlPrecision__NUMERIC__Int16<sqlNode.TypeMapping.Precision.Value)
   {
    //TARGET based on INTEGER. Can Ignore
   }
   else
   {
    //INTEGER -> NUMERIC_BASED_ON_SMALLINT

    return false;
   }//if
  }//if
#if DEBUG
  else
  {
   //
   // [2021-02-04] Expected
   //
   Debug.Assert(Structure_ADP.EqualDatabaseTypeName(sqlNode.TypeMapping.StoreTypeNameBase,FB_Common__SqlDataTypeNames.DECIMAL));
  }//else
#endif

  //------------------------------------------------------------
  if(!sqlNode.TypeMapping.Scale.HasValue)
  {
   //No scale. Ignore.

   return true;
  }//if

  Debug.Assert(sqlNode.TypeMapping.Scale.HasValue);
  Debug.Assert(sqlNode.TypeMapping.Scale.Value>=0);
  Debug.Assert(sqlNode.TypeMapping.Scale.Value<=sqlNode.TypeMapping.Precision);

  //------------------------------------------------------------
  if(sqlNode.TypeMapping.Scale.Value==0)
  {
   //Zero scale. Ignore.

   return true;
  }//if

  Debug.Assert(sqlNode.TypeMapping.Scale.Value>0);

  //------------------------------------------------------------
  return false;
 }//Helper__UseArgumentAsIs
};//class SSCode_Unary_Convert__CastAs__Int32ToDecimal

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1.Expressions.Nodes.SSCodes.Unary_Convert
