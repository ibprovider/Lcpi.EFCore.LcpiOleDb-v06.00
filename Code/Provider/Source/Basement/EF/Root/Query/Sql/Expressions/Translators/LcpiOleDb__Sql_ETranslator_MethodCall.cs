////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.10.2018.
using System;
using System.Diagnostics;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Sql.Expressions.Translators{
////////////////////////////////////////////////////////////////////////////////
//using

using LcpiOleDb__ISqlTreeNodeBuilder
 =Root.Query.LcpiOleDb__ISqlTreeNodeBuilder;

using LcpiOleDb__SqlExpressionFactory
 =Root.Query.LcpiOleDb__SqlExpressionFactory;

using Structure_MethodId
 =Structure.Structure_MethodId;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__Sql_ETranslator_MethodCall

abstract class LcpiOleDb__Sql_ETranslator_MethodCall
{
 public struct tagDescr
 {
  public readonly Structure_MethodId MethodId;

  public readonly LcpiOleDb__Sql_ETranslator_MethodCall Translator;

  //------------------------------------------------------------
  public tagDescr(Structure_MethodId                    methodId,
                  LcpiOleDb__Sql_ETranslator_MethodCall translator)
  {
   Debug.Assert(!Object.ReferenceEquals(methodId,null));
   Debug.Assert(!Object.ReferenceEquals(translator,null));

   this.MethodId   =methodId;
   this.Translator =translator;
  }//tagDescr
 };//struct tagDescr

 //-----------------------------------------------------------------------
 public struct tagOpData
 {
  public readonly Structure_MethodId MethodId;

  public readonly SqlExpression Instance;

  public readonly IReadOnlyList<SqlExpression> Arguments;

  public readonly LcpiOleDb__ISqlTreeNodeBuilder SqlTreeNodeBuilder;

  public readonly LcpiOleDb__SqlExpressionFactory SqlExpressionFactory;

  public readonly Core.Core_ConnectionOptions CnOptions;

  //------------------------------------------------------------
  public tagOpData(Structure_MethodId              methodId,
                   SqlExpression                   instance,
                   IReadOnlyList<SqlExpression>    arguments,
                   LcpiOleDb__ISqlTreeNodeBuilder  sqlTreeNodeBuilder,
                   LcpiOleDb__SqlExpressionFactory sqlExpressionFactory,
                   Core.Core_ConnectionOptions     cnOptions)
  {
   Debug.Assert(!Object.ReferenceEquals(methodId,null));
   Debug.Assert(!Object.ReferenceEquals(arguments,null));
   Debug.Assert(!Object.ReferenceEquals(sqlTreeNodeBuilder,null));
   Debug.Assert(!Object.ReferenceEquals(sqlExpressionFactory,null));
   Debug.Assert(!Object.ReferenceEquals(cnOptions,null));

   //----------
   this.MethodId=methodId;

   this.Instance=instance;

   this.Arguments=arguments;

   this.SqlTreeNodeBuilder=sqlTreeNodeBuilder;

   this.SqlExpressionFactory=sqlExpressionFactory;

   this.CnOptions=cnOptions;

   //----------
   Debug.Assert(!Object.ReferenceEquals(this.MethodId,null));
   Debug.Assert(!Object.ReferenceEquals(this.Arguments,null));
   Debug.Assert(!Object.ReferenceEquals(this.SqlTreeNodeBuilder,null));
   Debug.Assert(!Object.ReferenceEquals(this.SqlExpressionFactory,null));
   Debug.Assert(!Object.ReferenceEquals(this.CnOptions,null));
  }//tagOpData
 };//struct tagOpData

 //constructors ----------------------------------------------------------
 public LcpiOleDb__Sql_ETranslator_MethodCall()
 {
 }//LcpiOleDb__Sql_ETranslator_MethodCall

 //interface -------------------------------------------------------------
 public abstract SqlExpression Translate(in tagOpData opData);
};//class LcpiOleDb__Sql_ETranslator_MethodCall

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Sql.Expressions.Translators
