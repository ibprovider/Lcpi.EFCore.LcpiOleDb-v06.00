////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 11.06.2018.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__QueryCompiler

sealed class LcpiOleDb__QueryCompiler:QueryCompiler
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__QueryCompiler;

 //-----------------------------------------------------------------------
 public LcpiOleDb__QueryCompiler
         (IQueryContextFactory                       queryContextFactory,
          ICompiledQueryCache                        compiledQueryCache,
          ICompiledQueryCacheKeyGenerator            compiledQueryCacheKeyGenerator,
          IDatabase                                  database,
          IDiagnosticsLogger<DbLoggerCategory.Query> logger,
          ICurrentDbContext                          currentContext,
          IEvaluatableExpressionFilter               evaluatableExpressionFilter,
          IModel                                     model,
          Core.Core_ConnectionOptions                cnOptions)
  :base(queryContextFactory,
        compiledQueryCache,
        compiledQueryCacheKeyGenerator,
        database,
        logger,
        currentContext,
        evaluatableExpressionFilter,
        model)
 {
  Debug.Assert(!Object.ReferenceEquals(evaluatableExpressionFilter,null));
  Debug.Assert(!Object.ReferenceEquals(currentContext,null));
  Debug.Assert(!Object.ReferenceEquals(cnOptions,null));

#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__QueryCompiler::LcpiOleDb__QueryCompiler");
#endif

  //----------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(evaluatableExpressionFilter),
    evaluatableExpressionFilter);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(currentContext),
    currentContext);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(currentContext)+"."+nameof(currentContext.Context),
    currentContext);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(model),
    model);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(cnOptions),
    cnOptions);

  //----------------------------------------
  m_evaluatableExpressionFilter = evaluatableExpressionFilter;
  m_contextType                 = currentContext.Context.GetType();
  m_Model                       = model;
  m_cnOptions                   = cnOptions;

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(m_evaluatableExpressionFilter,null));
  Debug.Assert(!Object.ReferenceEquals(m_cnOptions,null));
 }//LcpiOleDb__QueryCompiler

 //QueryCompiler interface -----------------------------------------------
 public override Expression ExtractParameters
                             (Expression                                 query,
                              IParameterValues                           parameterValues,
                              IDiagnosticsLogger<DbLoggerCategory.Query> logger,
                              bool                                       parameterize,
                              bool                                       generateContextAccessors)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__QueryCompiler::ExtractParameters");
#endif

  var visitor
   =new ExpressionVisitors.LcpiOleDb__ParameterExtractingExpressionVisitor
         (m_evaluatableExpressionFilter,
          parameterValues,
          m_contextType,
          m_Model,
          logger,
          parameterize,
          generateContextAccessors,
          m_cnOptions);

  return visitor.ExtractParameters(query);
 }//ExtractParameters

 //private data ----------------------------------------------------------
 private readonly IEvaluatableExpressionFilter m_evaluatableExpressionFilter; // [SHIT]
 private readonly Type                         m_contextType; // [SHIT]
 private readonly IModel                       m_Model; // [SHIT]
 private readonly Core.Core_ConnectionOptions  m_cnOptions;
};//class LcpiOleDb__QueryCompiler

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query
