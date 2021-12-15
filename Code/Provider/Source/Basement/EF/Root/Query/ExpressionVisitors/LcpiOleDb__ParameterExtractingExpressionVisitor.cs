////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 24.09.2018.

//------------------------------------------------------------------------
#if   BUILD_CONF__NET5_0_0
// CER is deprecated
//# define LOCAL_BUILD_CONF__Use_CER
#elif BUILD_CONF__NET6_0_0
// CER is deprecated
//# define LOCAL_BUILD_CONF__Use_CER
#else
# error "Unexpected Target Platform!"
#endif

//------------------------------------------------------------------------
using System;
using System.Diagnostics;
using System.Linq.Expressions;

#if LOCAL_BUILD_CONF__Use_CER
using System.Runtime.CompilerServices;
#endif

using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.Internal;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors{
////////////////////////////////////////////////////////////////////////////////

using ParameterExtractingExpressionVisitor
 =Lcpi.EXT.Microsoft.EntityFrameworkCore.Query.Internal.ParameterExtractingExpressionVisitor;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__ParameterExtractingExpressionVisitor

sealed class LcpiOleDb__ParameterExtractingExpressionVisitor:ParameterExtractingExpressionVisitor
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__ParameterExtractingExpressionVisitor;

 //-----------------------------------------------------------------------
 public LcpiOleDb__ParameterExtractingExpressionVisitor
         (IEvaluatableExpressionFilter               evaluatableExpressionFilter,
          IParameterValues                           parameterValues,
          Type                                       contextType,
          IModel                                     model,
          IDiagnosticsLogger<DbLoggerCategory.Query> logger,
          bool                                       parameterize,
          bool                                       generateContextAccessors,
          Core.Core_ConnectionOptions                cnOptions)
  :base(evaluatableExpressionFilter,
        parameterValues,
        contextType,
        model,
        logger,
        parameterize,
        generateContextAccessors)
 {
  Debug.Assert(!Object.ReferenceEquals(cnOptions,null));

#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__ParameterExtractingExpressionVisitor::LcpiOleDb__ParameterExtractingExpressionVisitor");
#endif

  m_CnOptions=cnOptions;

  m_nGetValueCalls=0;

  Debug.Assert(!Object.ReferenceEquals(m_CnOptions,null));
 }//LcpiOleDb__ParameterExtractingExpressionVisitor

 //ParameterExtractingExpressionVisitor interface ------------------------
 protected override Expression LCPI__GenerateConstantExpression(object constantValue,
                                                                Type   returnType)
 {
  Debug.Assert(!Object.ReferenceEquals(returnType,null));

  System.Type valueType;

  if(Object.ReferenceEquals(constantValue,null))
  {
   valueType=returnType.MakeNullable(true);
  }
  else
  {
   Debug.Assert(!(constantValue is Expression));

   valueType=constantValue.GetType();

   Debug.Assert(!Object.ReferenceEquals(valueType,null));

   //
   // [2021-01-25] Save original value type
   //
   //if(valueType==returnType.Extension__UnwrapNullableType())
   // valueType=returnType;
  }//else

  Debug.Assert(!Object.ReferenceEquals(valueType,null));

  var constantExpression
   =Expression.Constant
     (constantValue,
      valueType);

  Debug.Assert(!Object.ReferenceEquals(constantExpression,null));
  Debug.Assert(!Object.ReferenceEquals(constantExpression.Type,null));

  if(constantExpression.Type==returnType)
   return constantExpression;

  return new Expressions.LcpiOleDb__SqlStubExpression
          (constantExpression,
           returnType);
 }//LCPI__GenerateConstantExpression

 //-----------------------------------------------------------------------
 protected override Expression LCPI__GenerateParameterExpression(string parameterName,
                                                                 object parameterValue,
                                                                 Type   returnType)
 {
  Debug.Assert(!Object.ReferenceEquals(returnType,null));
  Debug.Assert(!string.IsNullOrEmpty(parameterName));
  Debug.Assert(parameterName==parameterName.Trim());

  System.Type valueType;

  if(Object.ReferenceEquals(parameterValue,null))
  {
   valueType=returnType.MakeNullable(true);
  }
  else
  {
   if(parameterValue is Expression e)
   {
    Debug.Assert(!Object.ReferenceEquals(e.Type,null));

    // [2021-01-25] Not tested yet!

    ThrowSysError.method_not_impl
     (c_ErrSrcID,
      "LCPI__GenerateParameterExpression",
      "#001");

    valueType=e.Type;
   }
   else
   {
    valueType=parameterValue.GetType();
   }//else

   Debug.Assert(!Object.ReferenceEquals(valueType,null));

   //
   // [2021-01-25] Save original value type
   //
   //if(valueType==returnType.Extension__UnwrapNullableType())
   // valueType=returnType;
  }//else

  Debug.Assert(!Object.ReferenceEquals(valueType,null));

  var parameterExpression
   =Expression.Parameter
     (valueType,
      parameterName);

  Debug.Assert(!Object.ReferenceEquals(parameterExpression,null));
  Debug.Assert(!Object.ReferenceEquals(parameterExpression.Type,null));

  if(parameterExpression.Type==returnType)
   return parameterExpression;

  return new Expressions.LcpiOleDb__SqlStubExpression
          (parameterExpression,
           returnType);
 }//LCPI__GenerateParameterExpression

 //-----------------------------------------------------------------------
 protected override object GetValue(Expression expression,
                                    out string parameterName)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__ParameterExtractingExpressionVisitor::GetValue\n"
   +"  expression: {0}",
    expression);
#endif

  object resultValue=null;

#if LOCAL_BUILD_CONF__Use_CER
  RuntimeHelpers.PrepareConstrainedRegions();             //-------------- CER
#endif

  try // [finally]
  {
   ++m_nGetValueCalls;

   Debug.Assert(m_nGetValueCalls>0);

   if(m_nGetValueCalls==1)
   {
    //transformation of expression tree. first iteration only.

    if(!Object.ReferenceEquals(expression,null))
    {
     var prepareSvc
      =Core.Core_SvcUtils.QuerySvc<Core.Engines.EngineSvc__ExpressionVisitor>
        (m_CnOptions,
         LcpiOleDb__SvcIDs.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation);

     expression
      =prepareSvc.Visit(expression);

     Debug.Assert(!Object.ReferenceEquals(expression,null));
    }//if
   }//if m_nGetValueCalls==1

   resultValue
    =base.GetValue
      (expression,
       out parameterName);
  }
  finally
  {
   Debug.Assert(m_nGetValueCalls>0);

   --m_nGetValueCalls;
  }//finally                                              //--------------/CER

  return resultValue;
 }//GetValue

 //private data ----------------------------------------------------------
 private readonly Core.Core_ConnectionOptions m_CnOptions;

 //-----------------------------------------------------------------------
 //Counter of recursive calls of GetValue method
 private ulong m_nGetValueCalls;
};//class LcpiOleDb__ParameterExtractingExpressionVisitor

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.ExpressionVisitors