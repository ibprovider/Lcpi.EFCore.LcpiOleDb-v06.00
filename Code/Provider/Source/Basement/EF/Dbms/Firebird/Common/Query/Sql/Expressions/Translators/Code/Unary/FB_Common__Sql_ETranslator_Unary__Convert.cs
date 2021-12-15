////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 02.10.2021.
using System;
using System.Diagnostics;
using System.Linq;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator_Unary__Convert

sealed partial class FB_Common__Sql_ETranslator_Unary__Convert
 :FB_Common__Sql_ETranslator_Unary
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ETranslator_Unary__Convert;

 //-----------------------------------------------------------------------
 public FB_Common__Sql_ETranslator_Unary__Convert()
 {
  m_SSCodes
   =new Nodes.FB_Common__Sql_ENode_Unary__Convert.SSCodes();

#if DEBUG
  m_DEBUG__IsCompleted=false;
#endif
 }//FB_Common__Sql_ETranslator_Unary__Convert

 //own interface ---------------------------------------------------------
 public FB_Common__Sql_ETranslator_Unary__Convert Reg
                        (System.Type                                      fromType,
                         System.Type                                      toType,
                         bool                                             canIgnore,
                         Nodes.FB_Common__Sql_ENode_Unary__Convert.SSCode ssCode)
 {
  Debug.Assert(!Object.ReferenceEquals(fromType,null));
  Debug.Assert(!Object.ReferenceEquals(toType,null));
  Debug.Assert(!Object.ReferenceEquals(ssCode,null));

  Debug.Assert(!Object.ReferenceEquals(m_SSCodes,null));

  //----------------------------------------
#if DEBUG
  Debug.Assert(!m_DEBUG__IsCompleted);
#endif

  m_SSCodes.Add
   (fromType,
    toType,
    canIgnore,
    ssCode);

  return this;
 }//Reg

 //-----------------------------------------------------------------------
#if DEBUG
 public FB_Common__Sql_ETranslator_Unary__Convert DEBUG__Complete()
 {
  Debug.Assert(!Object.ReferenceEquals(m_SSCodes,null));

  m_SSCodes.DEBUG__Complete();

  return this;
 }//DEBUG__Complete
#endif

 //interface FB_Common__Sql_ETranslator_Unary ----------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.SqlOperand,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlOperand.Type,null));
  Debug.Assert(!Object.ReferenceEquals(opData.ClrResultType,null));

  Debug.Assert(opData.OperatorType==LcpiOleDb__ExpressionType.Convert);

  // [2021-10-02] EXPECTED THAT!
  Debug.Assert(opData.ClrResultType!=Structure_TypeCache.TypeOf__System_Object);

  Debug.Assert(!Object.ReferenceEquals(m_SSCodes,null));

#if DEBUG
  Debug.Assert(!m_DEBUG__IsCompleted);
#endif

  //-------------------------------------------------------
  const string c_bugcheck_src
   ="FB_Common__Sql_ETranslator_Unary__Convert::Translate";

  //-------------------------------------------------------
  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#001",
    "opData.SqlOperand",
    opData.SqlOperand);

  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#002",
    "opData.SqlOperand.Type",
    opData.SqlOperand.Type);

  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#003",
    "opData.SqlResultType",
    opData.ClrResultType);

  //-------------------------------------------------------
  var exprOperand
   =opData.SqlExpressionFactory.ApplyDefaultTypeMapping
     (opData.SqlOperand);

  Debug.Assert(!Object.ReferenceEquals(exprOperand,null));

  //-------------------------------------------------------
  if(opData.ClrResultType==Structure_TypeCache.TypeOf__System_Enum)
   return exprOperand;

  //-------------------------------------------------------
  var resultTypeMapping
   =opData.SqlExpressionFactory.GetTypeMapping__Throw
     (opData.ClrResultType);

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  //-------------------------------------------------------
  var exprOperandSqlType
   =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      exprOperand);

  Debug.Assert(!Object.ReferenceEquals(exprOperandSqlType,null));

  var resultSqlType
   =resultTypeMapping.ClrType.Extension__UnwrapMappingClrType();

  Debug.Assert(!Object.ReferenceEquals(resultSqlType,null));

  //-------------------------------------------------------
  //EXPECTED!
  Debug.Assert(exprOperand.Type==exprOperand.Type.Extension__UnwrapNullableType());

  if(resultSqlType==exprOperandSqlType)
   return exprOperand;

  //-------------------------------------------------------
  // Object convert needs to be converted to explicit cast when mismatching types
  if(exprOperandSqlType.IsInterface && resultSqlType.GetInterfaces().Any(e =>(e==exprOperandSqlType)))
   return exprOperand;

  //-------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  var r
   =Nodes.FB_Common__Sql_ENode_Unary__Convert.Create
     (exprOperand,
      resultTypeMapping,
      m_SSCodes); //throw

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Translate

 //private data ----------------------------------------------------------
 private readonly Nodes.FB_Common__Sql_ENode_Unary__Convert.SSCodes
  m_SSCodes;

#if DEBUG
  private bool m_DEBUG__IsCompleted;
#endif
};//class FB_Common__Sql_ETranslator_Unary__Convert

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code
