////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.10.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes.SSCodes.Unary__Convert{
////////////////////////////////////////////////////////////////////////////////
//using

using FB_Common__Sql_ENode_Unary__Convert
 =Nodes.FB_Common__Sql_ENode_Unary__Convert;

////////////////////////////////////////////////////////////////////////////////
//class SSCode_Unary_Convert__CastAs__Std

sealed class SSCode_Unary_Convert__CastAs__Std
 :FB_Common__Sql_ENode_Unary__Convert.SSCode
{
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance
   =new SSCode_Unary_Convert__CastAs__Std();

 //-----------------------------------------------------------------------
 private SSCode_Unary_Convert__CastAs__Std()
 {
 }//SSCode_Unary_Convert__CastAs__Std

 //interface -------------------------------------------------------------
 public override void GenerateSQL(FB_Common__QuerySqlGenerator        sqlGenerator,
                                  FB_Common__Sql_ENode_Unary__Convert sqlNode)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlGenerator,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode.TypeMapping.StoreType,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode.Operand,null));

  Debug.Assert(sqlNode.TypeMapping.StoreType.Length>0);
  Debug.Assert(sqlNode.TypeMapping.StoreType.Trim()==sqlNode.TypeMapping.StoreType);

  //----------------------------------------
  sqlGenerator.Sql.Append("CAST(");

  sqlGenerator.VisitAndWrapIntoBrackets(sqlNode.Operand,/*Parent*/null);

  sqlGenerator.Sql.Append(" AS ");

  sqlGenerator.Sql.Append(sqlNode.TypeMapping.StoreType);

  sqlGenerator.Sql.Append(")");
 }//Generate
};//class SSCode_Unary_Convert__CastAs__Std

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes.SSCodes.Unary__Convert
