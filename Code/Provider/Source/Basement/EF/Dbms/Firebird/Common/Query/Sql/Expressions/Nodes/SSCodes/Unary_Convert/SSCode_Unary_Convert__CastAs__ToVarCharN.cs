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
//class SSCode_Unary_Convert__CastAs__ToVarCharN

sealed class SSCode_Unary_Convert__CastAs__ToVarCharN
 :FB_Common__Sql_ENode_Unary__Convert.SSCode
{
 //  ----123456----
 // MIN: 0
 // MAX: 255
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance__FromByte
   =new SSCode_Unary_Convert__CastAs__ToVarCharN(3);

 //-----------------------------------------------------------------------
 //  ----123456----
 // MIN: -32768
 // MAX: 32767
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance__FromInt16
   =new SSCode_Unary_Convert__CastAs__ToVarCharN(6);

 //-----------------------------------------------------------------------
 //  ----12345678901----
 // MIN: -2147483648
 // MAX: 2147483647
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance__FromInt32
   =new SSCode_Unary_Convert__CastAs__ToVarCharN(11);

 //-----------------------------------------------------------------------
 //  ----12345678901234567890----
 // MIN: -9223372036854775808
 // MAX: 9223372036854775807
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance__FromInt64
   =new SSCode_Unary_Convert__CastAs__ToVarCharN(20);

 //-----------------------------------------------------------------------
 private static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance__32
   =new SSCode_Unary_Convert__CastAs__ToVarCharN(32);

 //-----------------------------------------------------------------------
 //  ----12345678901234567890123----
 // MIN: -1.797693134862316e+308
 // MAX: 1.797693134862316e+308
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance__FromDouble
   =Instance__32;

 //-----------------------------------------------------------------------
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance__FromDecimal
   =Instance__32;

 //-----------------------------------------------------------------------
 //  1234567890123456789012345
 //  27-JAN-2021 19:31:53.3210
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance__FromTS__D1
   =new SSCode_Unary_Convert__CastAs__ToVarCharN(25);

 //-----------------------------------------------------------------------
 //  123456789012345678901234
 //  2021-01-27 19:31:53.3210
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance__FromTS__D3
   =new SSCode_Unary_Convert__CastAs__ToVarCharN(24);

 //-----------------------------------------------------------------------
 //  123456789012345678901234
 //  19:31:53.3210
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance__FromTIME
   =new SSCode_Unary_Convert__CastAs__ToVarCharN(13);

 //-----------------------------------------------------------------------
 //  123456789012345678901234
 //  2021-07-03
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance__FromTypeDate
   =new SSCode_Unary_Convert__CastAs__ToVarCharN(10);

 //-----------------------------------------------------------------------
 //  123456789012345678901234
 //  FALSE
 //  TRUE
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance__FromBOOLEAN
   =new SSCode_Unary_Convert__CastAs__ToVarCharN(5);

 //-----------------------------------------------------------------------
 //UTF8
 public static readonly FB_Common__Sql_ENode_Unary__Convert.SSCode
  Instance__FromChar
   =new SSCode_Unary_Convert__CastAs__ToVarCharN(4);

 //-----------------------------------------------------------------------
 private SSCode_Unary_Convert__CastAs__ToVarCharN(int N)
 {
  Debug.Assert(N>0);

  m_SqlPart2=" AS VARCHAR("+N+"))";
 }//SSCode_Unary_Convert__CastAs__ToVarCharN

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

  sqlGenerator.Sql.Append(m_SqlPart2);
 }//Generate

 //private data ----------------------------------------------------------
 private readonly string m_SqlPart2;
};//class SSCode_Unary_Convert__CastAs__ToVarCharN

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes.SSCodes.Unary__Convert
