////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 24.11.2020.
using System;
using System.Diagnostics;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

using RelationalParameterBasedSqlProcessor
 =Microsoft.EntityFrameworkCore.Query.RelationalParameterBasedSqlProcessor;

using RelationalParameterBasedSqlProcessorDependencies
 =Microsoft.EntityFrameworkCore.Query.RelationalParameterBasedSqlProcessorDependencies;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__ParameterBasedSqlProcessor

sealed class LcpiOleDb__ParameterBasedSqlProcessor
 :RelationalParameterBasedSqlProcessor
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__ParameterBasedSqlProcessor;

 //-----------------------------------------------------------------------
 public LcpiOleDb__ParameterBasedSqlProcessor
     (RelationalParameterBasedSqlProcessorDependencies dependencies,
      Core.Core_ConnectionOptions                      cnOptions,
      bool                                             useRelationalNulls)
  :base(dependencies,useRelationalNulls)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(cnOptions),
    cnOptions);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(cnOptions,null));

  m_cnOptions=cnOptions;
 }//LcpiOleDb__ParameterBasedSqlProcessor

 //RelationalParameterBasedSqlProcessor interface ------------------------
 protected override SelectExpression ProcessSqlNullability
                                           (SelectExpression                    selectExpression,
                                            IReadOnlyDictionary<string, object> parametersValues,
                                            out bool                            canCache)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ProcessSqlNullability),
    nameof(selectExpression),
    selectExpression);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ProcessSqlNullability),
    nameof(parametersValues),
    parametersValues);

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(selectExpression,null));
  Debug.Assert(!Object.ReferenceEquals(parametersValues,null));

  var x
   =new LcpiOleDb__SqlNullabilityProcessor
     (Dependencies,
      UseRelationalNulls);

  return x.Process
            (selectExpression,
             parametersValues,
             out canCache);
 }//ProcessSqlNullability

 //-----------------------------------------------------------------------
 protected override SelectExpression ExpandFromSqlParameter
                                           (SelectExpression                    selectExpression,
                                            IReadOnlyDictionary<string, object> parametersValues,
                                            out bool                            canCache)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ProcessSqlNullability),
    nameof(selectExpression),
    selectExpression);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ProcessSqlNullability),
    nameof(parametersValues),
    parametersValues);

  //------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(selectExpression,null));
  Debug.Assert(!Object.ReferenceEquals(parametersValues,null));

  var r
   =ExpressionVisitors.LcpiOleDb__FromSqlParameterExpandingExpressionVisitor.Expand
     (this.Dependencies,
      m_cnOptions,
      selectExpression,
      parametersValues,
      out canCache);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//ExpandFromSqlParameter

 //Private data ----------------------------------------------------------
 private readonly Core.Core_ConnectionOptions m_cnOptions;
};//class LcpiOleDb__ParameterBasedSqlProcessor

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query
