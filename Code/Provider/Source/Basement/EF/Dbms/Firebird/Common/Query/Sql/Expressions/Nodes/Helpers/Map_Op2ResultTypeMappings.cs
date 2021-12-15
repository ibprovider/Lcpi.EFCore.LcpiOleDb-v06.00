////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.11.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes.Helpers{
////////////////////////////////////////////////////////////////////////////////
//class Map_Op2ResultTypeMappings

sealed class Map_Op2ResultTypeMappings
{
 public Map_Op2ResultTypeMappings()
 {
 }

 //interface -------------------------------------------------------------
 public Map_Op2ResultTypeMappings Add(Type                  leftType,
                                      Type                  rightType,
                                      RelationalTypeMapping resultTypeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(leftType,null));
  Debug.Assert(!Object.ReferenceEquals(rightType,null));
  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  Debug.Assert(leftType.Extension__UnwrapMappingClrType()==leftType);
  Debug.Assert(rightType.Extension__UnwrapMappingClrType()==rightType);

  Debug.Assert(!Object.ReferenceEquals(m_Items,null));

  tagLevel2 level2=null;

  if(!m_Items.TryGetValue(leftType,out level2))
  {
   level2=new tagLevel2();

   m_Items.Add(leftType,level2);
  }//if

  Debug.Assert(!Object.ReferenceEquals(level2,null));

  Debug.Assert(!level2.ContainsKey(rightType));

  level2.Add(rightType,resultTypeMapping);

  return this;
 }//Add

 //-----------------------------------------------------------------------
 public RelationalTypeMapping BuildResultTypeMapping
                               (ErrSourceID   errSrcID,
                                string        op2ENodeSign,
                                SqlExpression leftExpression,
                                SqlExpression rightExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(op2ENodeSign,null));
  Debug.Assert(op2ENodeSign.Length>0);
  Debug.Assert(op2ENodeSign==op2ENodeSign.Trim());

  Debug.Assert(!Object.ReferenceEquals(leftExpression,null));
  Debug.Assert(!Object.ReferenceEquals(rightExpression,null));

  //------------------------------------------------------------
  const string c_bugcheck_src
   ="Map_Op2ResultTypeMappings::Helper__BuildResultTypeMapping";

  //------------------------------------------------------------
  var leftSqlType
   =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
     (errSrcID,
      c_bugcheck_src,
      "#001",
      leftExpression);

  var rightSqlType
   =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
     (errSrcID,
      c_bugcheck_src,
      "#002",
      rightExpression);

  Debug.Assert(!Object.ReferenceEquals(leftSqlType,null));
  Debug.Assert(!Object.ReferenceEquals(rightSqlType,null));

  //------------------------------------------------------------
  RelationalTypeMapping resultTypeMapping=null;

  if(!this.Helper__TryGet(leftSqlType,rightSqlType,out resultTypeMapping))
  {
   ThrowBugCheck.SqlENode__UnsupportedArgTypes
    (errSrcID,
     op2ENodeSign,
     leftExpression,
     rightExpression);
  }//if

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  return resultTypeMapping;
 }//BuildResultTypeMapping

 //-----------------------------------------------------------------------
 public RelationalTypeMapping BuildResultTypeMapping
                               (ErrSourceID                  errSrcID,
                                string                       op2ENodeSign,
                                IReadOnlyList<SqlExpression> expressions)
 {
  Debug.Assert(!Object.ReferenceEquals(op2ENodeSign,null));
  Debug.Assert(op2ENodeSign.Length>0);
  Debug.Assert(op2ENodeSign==op2ENodeSign.Trim());

  Debug.Assert(!Object.ReferenceEquals(expressions,null));
  Debug.Assert(expressions.Count>1);

  //------------------------------------------------------------
  const string c_bugcheck_src
   ="Map_Op2ResultTypeMappings::Helper__BuildResultTypeMapping";

  //------------------------------------------------------------
  System.Type leftType=null;

  RelationalTypeMapping resultTypeMapping=null;

  for(int i=0,_c=expressions.Count;i!=_c;++i)
  {
   var curType
    =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
     (errSrcID,
      c_bugcheck_src,
      "#001",
      expressions[i]);

   Debug.Assert(!Object.ReferenceEquals(curType,null));

   if(i==0)
   {
    leftType=curType;

    continue;
   }//if i==0

   Debug.Assert(i>0);

   //------------------------------------------------------------
   if(!this.Helper__TryGet(leftType,curType,out resultTypeMapping))
   {
    ThrowBugCheck.SqlENode__UnsupportedArgTypes
     (errSrcID,
      op2ENodeSign,
      leftType,
      curType);
   }//if

   Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));
   Debug.Assert(!Object.ReferenceEquals(resultTypeMapping.ClrType,null));

   leftType
    =resultTypeMapping.ClrType.Extension__UnwrapMappingClrType();
  }//for i

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  return resultTypeMapping;
 }//BuildResultTypeMapping

 //helper methods --------------------------------------------------------
 private bool Helper__TryGet(Type                      leftType,
                             Type                      rightType,
                             out RelationalTypeMapping resultTypeMapping)
 {
  Debug.Assert(!Object.ReferenceEquals(leftType,null));
  Debug.Assert(!Object.ReferenceEquals(rightType,null));

  Debug.Assert(leftType.Extension__UnwrapMappingClrType()==leftType);
  Debug.Assert(rightType.Extension__UnwrapMappingClrType()==rightType);

  resultTypeMapping=null;

  tagLevel2 level2=null;

  if(!m_Items.TryGetValue(leftType,out level2))
   return false;

  if(!level2.TryGetValue(rightType,out resultTypeMapping))
   return false;

  Debug.Assert(!Object.ReferenceEquals(resultTypeMapping,null));

  return true;
 }//TryGet

 //private types ---------------------------------------------------------
 private sealed class tagLevel2:Dictionary<Type,RelationalTypeMapping>{ };
 private sealed class tagLevel1:Dictionary<Type,tagLevel2>{ };

 //private data ----------------------------------------------------------
 private readonly tagLevel1 m_Items=new tagLevel1();
};//class Map_Op2ResultTypeMappings

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes.Helpers
