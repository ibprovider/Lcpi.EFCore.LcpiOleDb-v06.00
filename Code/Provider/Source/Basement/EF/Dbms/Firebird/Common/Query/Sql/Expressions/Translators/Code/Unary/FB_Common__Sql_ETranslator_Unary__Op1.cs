////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 22.05.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator_Unary__Op1

sealed class FB_Common__Sql_ETranslator_Unary__Op1
 :FB_Common__Sql_ETranslator_Unary
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ETranslator_Unary__Op1;

 //-----------------------------------------------------------------------
 public FB_Common__Sql_ETranslator_Unary__Op1()
 {
  m_Items=new tagItems();

#if DEBUG
  m_DEBUG__Complete=false;
#endif
 }//FB_Common__Sql_ETranslator_Unary__Op1

 //interface -------------------------------------------------------------
 public FB_Common__Sql_ETranslator_Unary__Op1 Add(System.Type                    operandType,
                                                  FB_Common__Sql_ETranslator_Op1 translator)
 {
  Debug.Assert(!Object.ReferenceEquals(operandType,null));
  Debug.Assert(!Object.ReferenceEquals(translator,null));

  Debug.Assert(!Object.ReferenceEquals(m_Items,null));

  Debug.Assert(!m_Items.ContainsKey(operandType));

#if DEBUG
  Debug.Assert(!m_DEBUG__Complete);
#endif

  m_Items.Add(operandType,translator);

  return this;
 }//Add

 //-----------------------------------------------------------------------
#if DEBUG
 public FB_Common__Sql_ETranslator_Unary__Op1 DEBUG__Complete()
 {
  Debug.Assert(!m_DEBUG__Complete);

  m_DEBUG__Complete=true;

  return this;
 }//DEBUG__Complete
#endif

 //interface FB_Common__Sql_ETranslator_Unary ----------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.ClrResultType,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlOperand,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlOperand.Type,null));

#if DEBUG
  Debug.Assert(m_DEBUG__Complete);
#endif

  //-------------------------------------------------------
  const string c_bugcheck_src
   ="FB_Common__Sql_ETranslator_Unary__Op1::Translate";

  //-------------------------------------------------------
  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#000",
    "opData.ClrResultType",
    opData.ClrResultType);

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

  //-------------------------------------------------------
  FB_Common__Sql_ETranslator_Op1 translator=null;

  if(!m_Items.TryGetValue(opData.SqlOperand.Type,out translator))
  {
   //ERROR - Op1 does supported.

   ThrowError.SqlTranslatorErr__UnsupportedUnaryOperatorType
    (c_ErrSrcID,
     opData.OperatorType,
     opData.SqlOperand.Type,
     opData.ClrResultType);
  }//if

  Debug.Assert(!Object.ReferenceEquals(translator,null));

  var opData2
   =new FB_Common__Sql_ETranslator_Op1.tagOpData
     (opData.OperatorType,
      opData.SqlOperand,
      null,
      opData.SqlExpressionFactory,
      opData.SqlTreeNodeBuilder);

  var r
   =translator.Translate
     (opData2);

  //Expected
  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Translate

 //private types ---------------------------------------------------------
 private sealed class tagItems:Dictionary<System.Type,FB_Common__Sql_ETranslator_Op1>{};

 //private data ----------------------------------------------------------
 private readonly tagItems m_Items;

#if DEBUG
 private bool m_DEBUG__Complete;
#endif
};//class FB_Common__Sql_ETranslator_Unary__Op1

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Code
