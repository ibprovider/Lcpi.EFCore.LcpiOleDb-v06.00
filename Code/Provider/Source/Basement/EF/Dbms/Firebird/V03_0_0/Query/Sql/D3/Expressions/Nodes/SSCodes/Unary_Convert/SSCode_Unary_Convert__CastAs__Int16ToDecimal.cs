////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.10.2021.
using System;
using System.Diagnostics;
using System.Data;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Nodes.SSCodes.Unary_Convert{
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

////////////////////////////////////////////////////////////////////////////////
//class SSCode_Unary_Convert__CastAs__Int16ToDecimal

sealed class SSCode_Unary_Convert__CastAs__Int16ToDecimal
 :FB_Common__Sql_ENode_Unary__Convert.SSCode
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_V03_0_0_D3__Sql_ENode__SSCode_Unary_Convert__CastAs__Int16ToDecimal;

 //-----------------------------------------------------------------------
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance
   =new SSCode_Unary_Convert__CastAs__Int16ToDecimal();

 //-----------------------------------------------------------------------
 private SSCode_Unary_Convert__CastAs__Int16ToDecimal()
 {
 }//SSCode_Unary_Convert__CastAs__Int16ToDecimal

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
  Debug.Assert(sqlNode.Operand.TypeMapping.DbType==DbType.Int16);

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

  if(IscBase_Const.c_SqlPrecision__NUMERIC__Int64<sqlNode.TypeMapping.Precision.Value)
  {
   //ERROR - required precision does not supported in current (3) dialect

   ThrowError.SqlGenErr__DecimalPrecisionNotSupportedInCurrentCnDialect
    (c_ErrSrcID,
     IscBase_Utils.GetConnectionDialect(sqlGenerator.CnOptions),
     sqlNode.TypeMapping.StoreTypeNameBase,
     sqlNode.TypeMapping.Precision.Value);

   Debug.Assert(false);
  }//if

  Debug.Assert(sqlNode.TypeMapping.Precision.Value<=IscBase_Const.c_SqlPrecision__NUMERIC__Int64);

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
};//class SSCode_Unary_Convert__CastAs__Int16ToDecimal

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Nodes.SSCodes.Unary_Convert
