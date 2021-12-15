////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 23.11.2020.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Sql{
////////////////////////////////////////////////////////////////////////////////
//using

using LcpiOleDb__ISqlTreeNodeBuilder
 =Root.Query.LcpiOleDb__ISqlTreeNodeBuilder;

using LcpiOleDb__SqlExpressionFactory
 =Root.Query.LcpiOleDb__SqlExpressionFactory;

using T_TRANSLATORS1
 =Svcs.LcpiOleDb__SqlSvc__DataFor_MemberTranslatorProvider;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__MemberTranslatorProvider

//
// Required core services:
//  - LcpiOleDb__SqlSvc__DataFor_MemberTranslatorProvider
//

sealed class LcpiOleDb__MemberTranslatorProvider
 :IMemberTranslatorProvider
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__MemberTranslatorProvider;

 //-----------------------------------------------------------------------
 public LcpiOleDb__MemberTranslatorProvider(LcpiOleDb__ISqlTreeNodeBuilder       sqlTreeNodeBuilder,
                                            LcpiOleDb__SqlExpressionFactory      sqlExpressionFactory,
                                            IEnumerable<IMemberTranslatorPlugin> plugins,
                                            Core.Core_ConnectionOptions          cnOptions)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlTreeNodeBuilder,null));
  Debug.Assert(!Object.ReferenceEquals(sqlExpressionFactory,null));
  Debug.Assert(!Object.ReferenceEquals(plugins,null));
  Debug.Assert(!Object.ReferenceEquals(cnOptions,null));

  //----------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(sqlTreeNodeBuilder),
    sqlTreeNodeBuilder);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(sqlExpressionFactory),
    sqlExpressionFactory);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(plugins),
    plugins);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(cnOptions),
    cnOptions);

  //----------------------------------------
  m_translators1
   =Core.Core_SvcUtils.QuerySvc<T_TRANSLATORS1>
     (cnOptions,
      LcpiOleDb__SvcIDs.LcpiOleDb__SqlSvc__DataFor_MemberTranslatorProvider); //throw

  Debug.Assert(!Object.ReferenceEquals(m_translators1,null));

  m_translators2.AddRange(plugins.SelectMany(p => p.Translators));

  m_SqlTreeNodeBuilder=sqlTreeNodeBuilder;

  m_SqlExpressionFactory=sqlExpressionFactory;

  m_CnOptions=cnOptions;
 }//LcpiOleDb__MemberTranslatorProvider

 //IMemberTranslator interface -------------------------------------------
 public SqlExpression Translate(SqlExpression                              instance,
                                MemberInfo                                 member,
                                Type                                       returnType,
                                IDiagnosticsLogger<DbLoggerCategory.Query> logger)
 {
  Debug.Assert(!Object.ReferenceEquals(member,null));
  Debug.Assert(!Object.ReferenceEquals(returnType,null));

  //----------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Translate),
    nameof(member),
    member);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Translate),
    nameof(returnType),
    returnType);

  //----------------------------------------
  var r=Helper__Translate(instance,member,returnType,logger);

  return r;
 }//Translate

 //Helper methods --------------------------------------------------------
 private SqlExpression Helper__Translate(SqlExpression                              instance,
                                         MemberInfo                                 member,
                                         Type                                       returnType,
                                         IDiagnosticsLogger<DbLoggerCategory.Query> logger)
 {
  Debug.Assert(!Object.ReferenceEquals(member,null));
  Debug.Assert(!Object.ReferenceEquals(returnType,null));

  Debug.Assert(!Object.ReferenceEquals(m_translators1,null));
  Debug.Assert(!Object.ReferenceEquals(m_translators2,null));

  //----------------------------------------
  var memberId
   =Core.SQL.Core_SQL__MemberIdBuilder.Create
     (instance,
      member);

  Root.Query.Sql.Expressions.Translators.LcpiOleDb__Sql_ETranslator_Member
   translator1=null;

  if(m_translators1.TryGetData(memberId,out translator1))
  {
   Debug.Assert(!Object.ReferenceEquals(translator1,null));

   var opData
    =new Root.Query.Sql.Expressions.Translators.LcpiOleDb__Sql_ETranslator_Member.tagOpData
          (member,
           instance,
           m_SqlTreeNodeBuilder,
           m_SqlExpressionFactory,
           m_CnOptions);

   return translator1.Translate(/*in*/opData);
  }//if

  //----------------------------------------
  foreach(var translator2 in m_translators2)
  {
   Debug.Assert(!Object.ReferenceEquals(translator2,null));

   var e=translator2.Translate(instance,member,returnType,logger);

   if(!Object.ReferenceEquals(e,null))
    return e;
  }//for translator2

  return null;
 }//Helper__Translate

 //private data ----------------------------------------------------------
 private readonly T_TRANSLATORS1
  m_translators1;

 //-----------------------------------------------------------------------
 private readonly List<IMemberTranslator>
  m_translators2
   =new List<IMemberTranslator>();

 //-----------------------------------------------------------------------
 private readonly LcpiOleDb__ISqlTreeNodeBuilder
  m_SqlTreeNodeBuilder;

 //-----------------------------------------------------------------------
 private readonly LcpiOleDb__SqlExpressionFactory
  m_SqlExpressionFactory;

 //-----------------------------------------------------------------------
 private readonly Core.Core_ConnectionOptions
  m_CnOptions;
};//class LcpiOleDb__MemberTranslatorProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Sql
