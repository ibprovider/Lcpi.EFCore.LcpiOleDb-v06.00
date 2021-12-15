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
//class SSCode_Unary_Convert__CastAs__None

sealed class SSCode_Unary_Convert__CastAs__None
 :FB_Common__Sql_ENode_Unary__Convert.SSCode
{
 //
 //! \todo [2020-12-22] Need remove this class (and case) AS IS.
 //
 //  SQL Tree generator must exclude all cases, when this class is need.
 //

 //-----------------------------------------------------------------------
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance
   =new SSCode_Unary_Convert__CastAs__None();

 //-----------------------------------------------------------------------
 private SSCode_Unary_Convert__CastAs__None()
 {
 }//SSCode_Unary_Convert__CastAs__None

 //interface -------------------------------------------------------------
 public override void GenerateSQL(FB_Common__QuerySqlGenerator        sqlGenerator,
                                  FB_Common__Sql_ENode_Unary__Convert sqlNode)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlGenerator,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode,null));
  Debug.Assert(!Object.ReferenceEquals(sqlNode.Operand,null));

  //----------------------------------------
  sqlGenerator.VisitAndWrapIntoBrackets(sqlNode.Operand,/*Parent*/null);
 }//Generate
};//class SSCode_Unary_Convert__CastAs__None

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes.SSCodes.Unary__Convert
