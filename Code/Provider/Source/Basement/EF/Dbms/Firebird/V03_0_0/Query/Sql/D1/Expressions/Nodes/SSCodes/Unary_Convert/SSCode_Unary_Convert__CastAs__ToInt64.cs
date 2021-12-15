///////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.10.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1.Expressions.Nodes.SSCodes.Unary_Convert{
////////////////////////////////////////////////////////////////////////////////
//using

using FB_Common__Sql_ENode_Unary__Convert
 =Common.Query.Sql.Expressions.Nodes.FB_Common__Sql_ENode_Unary__Convert;

using FB_Common__QuerySqlGenerator
 =Common.Query.Sql.FB_Common__QuerySqlGenerator;

////////////////////////////////////////////////////////////////////////////////
//class SSCode_Unary_Convert__CastAs__ToInt64

// [2020-12-22] At current time, there is no way to execute the code of this class.

sealed class SSCode_Unary_Convert__CastAs__ToInt64
 :FB_Common__Sql_ENode_Unary__Convert.SSCode
{
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance
   =new SSCode_Unary_Convert__CastAs__ToInt64();

 //-----------------------------------------------------------------------
 private SSCode_Unary_Convert__CastAs__ToInt64()
 {
 }//SSCode_Unary_Convert__CastAs__ToInt64

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

  sqlGenerator.Sql.Append(FB_V03_0_0__Consts.c_TypeOf_BIGINT_D1);

  sqlGenerator.Sql.Append(")");
 }//Generate
};//class SSCode_Unary_Convert__CastAs__ToInt64

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D1.Expressions.Nodes.SSCodes.Unary_Convert
