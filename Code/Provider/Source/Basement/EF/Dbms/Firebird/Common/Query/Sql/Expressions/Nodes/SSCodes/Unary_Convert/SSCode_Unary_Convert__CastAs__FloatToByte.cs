////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.11.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes.SSCodes.Unary__Convert{
////////////////////////////////////////////////////////////////////////////////
//using

using FB_Common__Sql_ENode_Unary__Convert
 =Nodes.FB_Common__Sql_ENode_Unary__Convert;

////////////////////////////////////////////////////////////////////////////////
//class SSCode_Unary_Convert__CastAs__FloatToByte

sealed class SSCode_Unary_Convert__CastAs__FloatToByte
 :FB_Common__Sql_ENode_Unary__Convert.SSCode
{
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance
   =new SSCode_Unary_Convert__CastAs__FloatToByte();

 //-----------------------------------------------------------------------
 private SSCode_Unary_Convert__CastAs__FloatToByte()
 {
 }//SSCode_Unary_Convert__CastAs__FloatToByte

 //interface -------------------------------------------------------------
 public override void GenerateSQL(FB_Common__QuerySqlGenerator        sqlGenerator,
                                  FB_Common__Sql_ENode_Unary__Convert sqlNode)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlGenerator,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode.TypeMapping.StoreType,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode.Operand,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode.Operand.Type,null));

  Debug.Assert(sqlNode.TypeMapping.StoreType.Length>0);
  Debug.Assert(sqlNode.TypeMapping.StoreType.Trim()==sqlNode.TypeMapping.StoreType);

  if(sqlNode.Operand is Common.Query.Sql.Expressions.Tags.FB_Common__Sql_ETag__ReturnsIntegerNumber)
  {
   sqlGenerator.Sql.Append("CASE WHEN COALESCE(");

   sqlGenerator.VisitAndWrapIntoBrackets(sqlNode.Operand,/*Parent*/null);

   sqlGenerator.Sql.Append(" BETWEEN 0 AND 255, TRUE) THEN CAST(");

   sqlGenerator.VisitAndWrapIntoBrackets(sqlNode.Operand,/*Parent*/null);

   sqlGenerator.Sql.Append(" AS SMALLINT) ELSE CAST('CANNOT CONVERT VALUE TO BYTE. OVERFLOW ERROR.' AS SMALLINT) END");
  }
  else
  {
   sqlGenerator.Sql.Append("CASE WHEN COALESCE(TRUNC(");

   sqlGenerator.VisitAndWrapIntoBrackets(sqlNode.Operand,/*Parent*/null);

   sqlGenerator.Sql.Append(") BETWEEN 0 AND 255, TRUE) THEN CAST(TRUNC(");

   sqlGenerator.Visit(sqlNode.Operand);

   sqlGenerator.Sql.Append(") AS SMALLINT) ELSE CAST('CANNOT CONVERT VALUE TO BYTE. OVERFLOW ERROR.' AS SMALLINT) END");
  }//else
 }//Generate
};//class SSCode_Unary_Convert__CastAs__FloatToByte

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes.SSCodes.Unary__Convert
