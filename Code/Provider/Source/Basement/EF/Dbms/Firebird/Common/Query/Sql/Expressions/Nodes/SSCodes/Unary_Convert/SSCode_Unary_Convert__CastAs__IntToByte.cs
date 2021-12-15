////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 25.11.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes.SSCodes.Unary__Convert{
////////////////////////////////////////////////////////////////////////////////
//using

using FB_Common__Sql_ENode_Unary__Convert
 =Nodes.FB_Common__Sql_ENode_Unary__Convert;

////////////////////////////////////////////////////////////////////////////////
//class SSCode_Unary_Convert__CastAs__IntToByte

sealed class SSCode_Unary_Convert__CastAs__IntToByte
 :FB_Common__Sql_ENode_Unary__Convert.SSCode
{
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance
   =new SSCode_Unary_Convert__CastAs__IntToByte();

 //-----------------------------------------------------------------------
 private SSCode_Unary_Convert__CastAs__IntToByte()
 {
 }//SSCode_Unary_Convert__CastAs__IntToByte

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

  //----------------------------------------
#if DEBUG
  {
   var debug__operandType
    =sqlNode.Operand.Type;

   Debug.Assert(!Object.ReferenceEquals(debug__operandType,null));

   var debug__operandType_u
    =debug__operandType.Extension__GetUnderlyingValueType();

   Debug.Assert(!Object.ReferenceEquals(debug__operandType_u,null));

   Debug.Assert(debug__operandType_u.Extension__IsInteger__Exact());
  }//local
#endif

  sqlGenerator.Sql.Append("CASE WHEN COALESCE(");

  sqlGenerator.VisitAndWrapIntoBrackets(sqlNode.Operand,/*Parent*/null);

  sqlGenerator.Sql.Append(" BETWEEN 0 AND 255, TRUE) THEN CAST(");

  sqlGenerator.VisitAndWrapIntoBrackets(sqlNode.Operand,/*Parent*/null);

  sqlGenerator.Sql.Append(" AS SMALLINT) ELSE CAST('CANNOT CONVERT VALUE TO BYTE. OVERFLOW ERROR.' AS SMALLINT) END");
 }//Generate
};//class SSCode_Unary_Convert__CastAs__IntToByte

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes.SSCodes.Unary__Convert
