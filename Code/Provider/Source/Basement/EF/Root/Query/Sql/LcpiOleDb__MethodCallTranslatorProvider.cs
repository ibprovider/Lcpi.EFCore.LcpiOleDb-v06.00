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
using Microsoft.EntityFrameworkCore.Metadata;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Sql{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MethodId
 =Structure.Structure_MethodId;

using Structure_ReflectionUtils
 =Structure.Structure_ReflectionUtils;

using T_TEST_CVT_RESULT
 =Structure.Structure_TestConversionResult;

using T_TRANSLATORS1
 =Svcs.LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__MethodCallTranslatorProvider

//
// Required core services:
//  - LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider
//

sealed class LcpiOleDb__MethodCallTranslatorProvider
 :IMethodCallTranslatorProvider
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__MethodCallTranslatorProvider;

 //-----------------------------------------------------------------------
 public LcpiOleDb__MethodCallTranslatorProvider
                             (LcpiOleDb__ISqlTreeNodeBuilder            sqlTreeNodeBuilder,
                              LcpiOleDb__SqlExpressionFactory           sqlExpressionFactory,
                              IEnumerable<IMethodCallTranslatorPlugin>  plugins,
                              Core.Core_ConnectionOptions               cnOptions)
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
      LcpiOleDb__SvcIDs.LcpiOleDb__SqlSvc__DataFor_MethodCallTranslatorProvider); //throw

  Debug.Assert(!Object.ReferenceEquals(m_translators1,null));

  m_sqlTreeNodeBuilder=sqlTreeNodeBuilder;

  m_sqlExpressionFactory=sqlExpressionFactory;

  m_translators2.AddRange(plugins.SelectMany(p => p.Translators));

  m_CnOptions=cnOptions;

  //---------------------------------------- STD
  //! \todo Uncomment

  // m_translators.Add(new EnumHasFlagTranslator());
  // m_translators.Add(new EqualsTranslator(dependencies.Logger));
  // m_translators.Add(new GetValueOrDefaultTranslator());
  // //m_translators.Add(new IsNullOrEmptyTranslator());
  // m_translators.Add(new LikeTranslator());
 }//LcpiOleDb__MethodCallTranslatorProvider

 //ICompositeMethodCallTranslator interface ------------------------------
 public SqlExpression Translate(IModel                                     model,
                                SqlExpression                              instance,
                                MethodInfo                                 method,
                                IReadOnlyList<SqlExpression>               arguments,
                                IDiagnosticsLogger<DbLoggerCategory.Query> logger)
 {
  Debug.Assert(!Object.ReferenceEquals(model,null));
  Debug.Assert(!Object.ReferenceEquals(method,null));
  Debug.Assert(!Object.ReferenceEquals(arguments,null));

  //----------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Translate),
    nameof(model),
    model);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Translate),
    nameof(method),
    method);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Translate),
    nameof(arguments),
    arguments);

  //----------------------------------------
  var r
   =Helper__Translate
     (model,
      instance,
      method,
      arguments,
      logger);

  return r;
 }//Translate

 //Helper methods --------------------------------------------------------
 private SqlExpression Helper__Translate(IModel                                     model,
                                         SqlExpression                              instance,
                                         MethodInfo                                 method,
                                         IReadOnlyList<SqlExpression>               arguments,
                                         IDiagnosticsLogger<DbLoggerCategory.Query> logger)
 {
  Debug.Assert(!Object.ReferenceEquals(model,null));
  Debug.Assert(!Object.ReferenceEquals(method,null));
  Debug.Assert(!Object.ReferenceEquals(arguments,null));

  Debug.Assert(!Object.ReferenceEquals(m_translators1,null));
  Debug.Assert(!Object.ReferenceEquals(m_translators2,null));

  //----------------------------------------
  //! \todo
  //!  Append support for IDbFunction

  //---------------------------------------- PASS 1
  SqlExpression resultExpression=null;

  if(this.Helper__Pass1(method,instance,arguments,out resultExpression))
   return resultExpression;

  //---------------------------------------- PASS 2
  if(this.Helper__Pass2(method,instance,arguments,out resultExpression))
   return resultExpression;

  //----------------------------------------
  foreach(var translator2 in m_translators2)
  {
   Debug.Assert(!Object.ReferenceEquals(translator2,null));

   var e=translator2.Translate(instance,method,arguments,logger);

   if(!Object.ReferenceEquals(e,null))
    return e;
  }//for translator2

  return null;
 }//Helper__Translate

 //-----------------------------------------------------------------------
 private bool Helper__Pass1(MethodInfo                   originalMethod,
                            SqlExpression                instance,
                            IReadOnlyList<SqlExpression> arguments,
                            out SqlExpression            resultExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethod,null));
  Debug.Assert(!Object.ReferenceEquals(arguments,null));

  Debug.Assert(!Object.ReferenceEquals(m_translators1,null));

  //----------------------------------------
  resultExpression=null;

  //----------------------------------------
  var methodId
   =Core.SQL.Core_SQL__MethodIdBuilder.Create
     (originalMethod,
      instance,
      arguments);

  //----------------------------------------
  Query.Sql.Expressions.Translators.LcpiOleDb__Sql_ETranslator_MethodCall
   translator1
    =null;

  if(!m_translators1.TryGetData(methodId,out translator1))
   return false;

  Debug.Assert(!Object.ReferenceEquals(translator1,null));

  var opData
   =new Query.Sql.Expressions.Translators.LcpiOleDb__Sql_ETranslator_MethodCall.tagOpData
     (methodId,
      instance,
      arguments,
      m_sqlTreeNodeBuilder,
      m_sqlExpressionFactory,
      m_CnOptions);

  resultExpression
   =translator1.Translate
     (/*in*/opData);

  return true;
 }//Helper__Pass1

 //-----------------------------------------------------------------------
 private bool Helper__Pass2(MethodInfo                   originalMethod,
                            SqlExpression                instance,
                            IReadOnlyList<SqlExpression> arguments,
                            out SqlExpression            resultExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethod,null));
  Debug.Assert(!Object.ReferenceEquals(arguments,null));

  Debug.Assert(!Object.ReferenceEquals(m_translators1,null));

  //----------------------------------------
  resultExpression=null;

  var newMethodCallData
   =Helper__BuildCallWithNewMethod
     (originalMethod,
      instance,
      arguments);

  if(Object.ReferenceEquals(newMethodCallData,null))
   return false;

  //----------------------------------------
  if(!m_translators1.TryGetData(newMethodCallData.MethodId,out var translator1))
  {
   //WTF? Must exist!
   Debug.Assert(false);

   return false;
  }//if

  Debug.Assert(!Object.ReferenceEquals(translator1,null));

  var opData
   =new Query.Sql.Expressions.Translators.LcpiOleDb__Sql_ETranslator_MethodCall.tagOpData
     (newMethodCallData.MethodId,
      newMethodCallData.CallObject,
      newMethodCallData.CallArguments,
      m_sqlTreeNodeBuilder,
      m_sqlExpressionFactory,
      m_CnOptions);

  resultExpression
   =translator1.Translate
     (/*in*/opData);

  return true;
 }//Helper__Pass2

 //-----------------------------------------------------------------------
 private tagSuitableMethodData Helper__BuildCallWithNewMethod
                                           (MethodInfo                   originalMethod,
                                            SqlExpression                newObject,
                                            IReadOnlyList<SqlExpression> newArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethod,null));
  //Debug.Assert(!Object.ReferenceEquals(newObject,null));
  Debug.Assert(!Object.ReferenceEquals(newArguments,null));

  //----------------------------------------
  var newMethodCallData
   =Helper__GetSuitableMethod
     (originalMethod,
      newObject,
      newArguments);

  if(!Object.ReferenceEquals(newMethodCallData,null))
   return newMethodCallData;

  //----------------------------------------
  return null;
 }//Helper__BuildCallWithNewMethod

 //-----------------------------------------------------------------------
 private tagSuitableMethodData Helper__GetSuitableMethod
                                           (MethodInfo                   originalMethod,
                                            SqlExpression                newObject,
                                            IReadOnlyList<SqlExpression> newArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethod,null));
  //Debug.Assert(!Object.ReferenceEquals(newObject,null));
  Debug.Assert(!Object.ReferenceEquals(newArguments,null));

  tagSuitableMethodDatas
   suitableMethods
    =this.Helper__GetSuitableMethods
      (originalMethod,
       newObject,
       newArguments);

  Debug.Assert(!Object.ReferenceEquals(suitableMethods,null));

  if(suitableMethods.Count==0)
   return null;

  Debug.Assert(suitableMethods.Count>0);

  //Sort suitableMethods
  suitableMethods.Sort(tagSuitableMethodDataComparer.Instance);

  //All suitaibleMethods are valid. Use the most preferred.

  var r=suitableMethods[0];

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Helper__GetSuitableMethod

 //-----------------------------------------------------------------------
 private tagSuitableMethodDatas Helper__GetSuitableMethods
                                           (MethodInfo                   originalMethod,
                                            SqlExpression                newObject,
                                            IReadOnlyList<SqlExpression> newArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethod,null));
  //Debug.Assert(!Object.ReferenceEquals(newObject,null));
  Debug.Assert(!Object.ReferenceEquals(newArguments,null));

  if(!Object.ReferenceEquals(newObject,null))
  {
   //Remap standard method

   Debug.Assert(!originalMethod.IsStatic);
   Debug.Assert(!Structure_ReflectionUtils.IsExtensionMethod(originalMethod));

   return this.Helper__GetSuitableMethods__Std
            (originalMethod,
             newObject,
             newArguments);
  }//if

  Debug.Assert(Object.ReferenceEquals(newObject,null));
  Debug.Assert(originalMethod.IsStatic);
  Debug.Assert(Object.ReferenceEquals(newObject,null));

  if(Structure_ReflectionUtils.IsExtensionMethod(originalMethod))
  {
   //! \todo Remap extension method

   return this.Helper__GetSuitableMethods__Ext
            (originalMethod,
             newArguments);
  }//if

  Debug.Assert(!Structure_ReflectionUtils.IsExtensionMethod(originalMethod));

  Debug.Assert(originalMethod.IsStatic);
  Debug.Assert(Object.ReferenceEquals(newObject,null));

  //Remap static method

  return this.Helper__GetSuitableMethods__Static
          (originalMethod,
           newArguments);
 }//Helper__GetSuitableMethods

 //-----------------------------------------------------------------------
 private tagSuitableMethodDatas Helper__GetSuitableMethods__Std
                                           (MethodInfo                   originalMethod,
                                            SqlExpression                callObject,
                                            IReadOnlyList<SqlExpression> callArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethod,null));
  Debug.Assert(!Object.ReferenceEquals(callObject,null));
  Debug.Assert(!Object.ReferenceEquals(callArguments,null));

  Debug.Assert(!Object.ReferenceEquals(m_translators1,null));

  //----------------------------------------
  var suitableMethods=new tagSuitableMethodDatas();

  foreach(var testMethodId in m_translators1.SelectKeysByName(originalMethod.Name))
  {
   Debug.Assert(!Object.ReferenceEquals(testMethodId,null));
   Debug.Assert(!Object.ReferenceEquals(testMethodId.MethodName,null));
   Debug.Assert(System.StringComparer.Ordinal.Equals(testMethodId.MethodName,originalMethod.Name));

   tagSuitableMethodData testData=null;

   if(!testMethodId.IsStatic)
   {
    //Test STD method

    Debug.Assert(!testMethodId.IsExtension);

    testData
     =Helper__CAN_USE_STD_FOR_STD
       (testMethodId,
        callObject,
        callArguments);
   }//if
   else
   if(testMethodId.IsExtension)
   {
    // Test Extension Method

    Debug.Assert(testMethodId.IsStatic);

    testData
     =Helper__CAN_USE_EXT_FOR_STD
       (testMethodId,
        callObject,
        callArguments);
   }
   else
   {
    Debug.Assert(testMethodId.IsStatic);
    Debug.Assert(!testMethodId.IsExtension);

    /*Ignore simple static methods*/
    continue;
   }//else

   if(!Object.ReferenceEquals(testData,null))
    suitableMethods.Add(testData);
  }//foreach testMethodId

  //----------------------------------------
  return suitableMethods;
 }//Helper__GetSuitableMethods__Std

 //-----------------------------------------------------------------------
 private tagSuitableMethodDatas Helper__GetSuitableMethods__Ext
                                           (MethodInfo                   originalMethod,
                                            IReadOnlyList<SqlExpression> callArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethod,null));
  Debug.Assert(!Object.ReferenceEquals(callArguments,null));

  Debug.Assert(originalMethod.IsStatic);
  Debug.Assert(Structure_ReflectionUtils.IsExtensionMethod(originalMethod));

  //----------------------------------------
  var suitableMethods=new tagSuitableMethodDatas();

  foreach(var testMethodId in m_translators1.SelectKeysByName(originalMethod.Name))
  {
   Debug.Assert(!Object.ReferenceEquals(testMethodId,null));
   Debug.Assert(!Object.ReferenceEquals(testMethodId.MethodName,null));
   Debug.Assert(System.StringComparer.Ordinal.Equals(testMethodId.MethodName,originalMethod.Name));

   tagSuitableMethodData testData=null;

   if(!testMethodId.IsStatic)
   {
    Debug.Assert(!testMethodId.IsExtension);

    testData
     =Helper__CAN_USE_STD_FOR_EXT
       (testMethodId,
        callArguments);
   }
   else
   if(testMethodId.IsExtension)
   {
    Debug.Assert(testMethodId.IsStatic);

    testData
     =Helper__CAN_USE_EXT_FOR_EXT
       (testMethodId,
        callArguments);
   }//if
   else
   {
    Debug.Assert(testMethodId.IsStatic);
    Debug.Assert(!testMethodId.IsExtension);

    /*Ignore simple static methods*/
    continue;
   }//else

   if(!Object.ReferenceEquals(testData,null))
    suitableMethods.Add(testData);

   continue;
  }//foreach testMethod

  return suitableMethods;
 }//Helper__GetSuitableMethods__Ext

 //-----------------------------------------------------------------------
 private tagSuitableMethodDatas Helper__GetSuitableMethods__Static
                                           (MethodInfo                   originalMethod,
                                            IReadOnlyList<SqlExpression> callArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethod,null));
  Debug.Assert(!Object.ReferenceEquals(originalMethod.DeclaringType,null));
  Debug.Assert(!Object.ReferenceEquals(callArguments,null));

  Debug.Assert(originalMethod.IsStatic);
  Debug.Assert(!Structure_ReflectionUtils.IsExtensionMethod(originalMethod));

  //----------------------------------------
  var suitableMethods=new tagSuitableMethodDatas();

  foreach(var testMethodId in m_translators1.SelectKeysByName(originalMethod.Name))
  {
   Debug.Assert(!Object.ReferenceEquals(testMethodId,null));
   Debug.Assert(!Object.ReferenceEquals(testMethodId.MethodName,null));
   Debug.Assert(!Object.ReferenceEquals(testMethodId.DeclaringType,null));
   Debug.Assert(System.StringComparer.Ordinal.Equals(testMethodId.MethodName,originalMethod.Name));

   if(!testMethodId.IsStatic)
   {
    Debug.Assert(!testMethodId.IsExtension);

    //ignore standard method
    continue;
   }//if

   Debug.Assert(testMethodId.IsStatic);

   if(testMethodId.IsExtension)
   {
    //ignore extension method

    //[2019-04-24] Let it be so.

    continue;
   }//if

   Debug.Assert(!testMethodId.IsExtension);

   tagSuitableMethodData
    testData
     =Helper__CAN_USE_STATIC_FOR_STATIC
       (testMethodId,
        originalMethod.DeclaringType,
        callArguments);

   if(!Object.ReferenceEquals(testData,null))
    suitableMethods.Add(testData);

   continue;
  }//foreach testMethodId

  return suitableMethods;
 }//Helper__GetSuitableMethods__Static

 //-----------------------------------------------------------------------
 private tagSuitableMethodData Helper__CAN_USE_STD_FOR_STD
                                           (Structure_MethodId           testMethodId,
                                            SqlExpression                callObject,
                                            IReadOnlyList<SqlExpression> callArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(testMethodId,null));
  Debug.Assert(!Object.ReferenceEquals(testMethodId.DeclaringType,null));
  Debug.Assert(!testMethodId.IsStatic);
  Debug.Assert(!testMethodId.IsExtension);

  Debug.Assert(!Object.ReferenceEquals(callObject,null));
  Debug.Assert(!Object.ReferenceEquals(callObject.Type,null));
  Debug.Assert(!Object.ReferenceEquals(callArguments,null));

  //-------------------------------------------------------
  var method_Parameters=testMethodId.Parameters;

  Debug.Assert(!Object.ReferenceEquals(method_Parameters,null));

  //method with another count of parameters
  if(method_Parameters.Count!=callArguments.Count)
   return null;

  //check object type
  var cvtResult1
   =Helper__TestCompatibleCallerType
     (callObject,
      testMethodId.DeclaringType);

  if(!cvtResult1.OK)
   return null;

  //----------------------------------------
  long cvtNumber2=0;

  for(int i=0,_c=callArguments.Count;i!=_c;++i)
  {
   var callArg=callArguments[i];

   Debug.Assert(!Object.ReferenceEquals(callArg,null));

   var methodArg=method_Parameters[i];

   Debug.Assert(!Object.ReferenceEquals(methodArg,null));

   var cr
    =LcpiOleDb__TestSafeSqlConversion.Exec
      (callArg,
       methodArg);

   if(!cr.OK)
   {
    return null;
   }//of

   Debug.Assert(cr.OK);
   Debug.Assert(cr.Weight>=0);

   cvtNumber2+=cr.Weight;
  }//for i

  //method can be used for call
  var r
   =new tagSuitableMethodData
     (testMethodId,
      callObject,
      callArguments,
      cvtResult1.Weight,
      cvtNumber2);

  return r;
 }//Helper__CAN_USE_STD_FOR_STD

 //-----------------------------------------------------------------------
 private tagSuitableMethodData Helper__CAN_USE_EXT_FOR_STD
                                           (Structure_MethodId           testMethodId,
                                            SqlExpression                callObject,
                                            IReadOnlyList<SqlExpression> callArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(testMethodId,null));
  Debug.Assert(testMethodId.IsExtension);

  Debug.Assert(!Object.ReferenceEquals(callObject,null));
  Debug.Assert(!Object.ReferenceEquals(callObject.Type,null));
  Debug.Assert(!Object.ReferenceEquals(callArguments,null));

  //-------------------------------------------------------
  var method_Parameters=testMethodId.Parameters;

  Debug.Assert(!Object.ReferenceEquals(method_Parameters,null));

  Debug.Assert(method_Parameters.Count>0);

  //extension with another count of parameters
  if((method_Parameters.Count-1)!=callArguments.Count)
   return null;

  //[2018-10-14] At current time we support only exact extensions

  var cvtResult1
   =Helper__TestCompatibleCallerType
     (callObject,
      method_Parameters[0].ParameterType);

  if(!cvtResult1.OK)
   return null;

  //----------------------------------------
  var callArguments2=new SqlExpression[method_Parameters.Count];

  callArguments2[0]=callObject;

  long cvtNumber2=0;

  for(int i=0,_c=callArguments.Count;i!=_c;)
  {
   var callArg=callArguments[i];

   Debug.Assert(!Object.ReferenceEquals(callArg,null));

   ++i;

   var methodArg=method_Parameters[i];

   Debug.Assert(!Object.ReferenceEquals(methodArg,null));

   Debug.Assert(Object.ReferenceEquals(callArguments2[i],null));

   var cr
    =LcpiOleDb__TestSafeSqlConversion.Exec
      (callArg,
       methodArg);

   if(!cr.OK)
   {
    return null;
   }//of

   Debug.Assert(cr.OK);
   Debug.Assert(cr.Weight>=0);

   cvtNumber2+=cr.Weight;

   //----
   callArguments2[i]=callArg;
  }//for i

  //method can be used for call
  var r
   =new tagSuitableMethodData
     (testMethodId,
      null,
      callArguments2,
      cvtResult1.Weight,
      cvtNumber2);

  return r;
 }//Helper__CAN_USE_EXT_FOR_STD

 //-----------------------------------------------------------------------
 private tagSuitableMethodData Helper__CAN_USE_STD_FOR_EXT
                                           (Structure_MethodId           testMethodId,
                                            IReadOnlyList<SqlExpression> callArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(testMethodId,null));
  Debug.Assert(!Object.ReferenceEquals(testMethodId.DeclaringType,null));
  Debug.Assert(!testMethodId.IsStatic);
  Debug.Assert(!testMethodId.IsExtension);

  Debug.Assert(!Object.ReferenceEquals(callArguments,null));
  Debug.Assert(callArguments.Count>0);

  var method_Parameters=testMethodId.Parameters;

  Debug.Assert(!Object.ReferenceEquals(method_Parameters,null));

  //method with another count of parameters
  if(method_Parameters.Count!=callArguments.Count-1)
   return null;

  var cvtResult1
   =Helper__TestCompatibleCallerType
     (callArguments[0],
      testMethodId.DeclaringType);

  if(!cvtResult1.OK)
   return null;

  //----------------------------------------
  var callArguments2=new SqlExpression[method_Parameters.Count];

  long cvtNumber2=0;

  for(int i=0,_c=method_Parameters.Count;i!=_c;++i)
  {
   var methodArg=method_Parameters[i];

   Debug.Assert(!Object.ReferenceEquals(methodArg,null));

   var callArg=callArguments[i+1];

   Debug.Assert(!Object.ReferenceEquals(callArg,null));

   Debug.Assert(Object.ReferenceEquals(callArguments2[i],null));

   var cr
    =LcpiOleDb__TestSafeSqlConversion.Exec
      (callArg,
       methodArg);

   if(!cr.OK)
   {
    return null;
   }//of

   Debug.Assert(cr.OK);
   Debug.Assert(cr.Weight>=0);

   cvtNumber2+=cr.Weight;

   //----
   callArguments2[i]=callArg;

   Debug.Assert(!Object.ReferenceEquals(callArguments2[i],null));
   Debug.Assert(!Object.ReferenceEquals(callArguments2[i].Type,null));
  }//for i

  //method can be used for call
  var r
   =new tagSuitableMethodData
     (testMethodId,
      callArguments[0],
      callArguments2,
      cvtResult1.Weight,
      cvtNumber2);

  return r;
 }//Helper__CAN_USE_STD_FOR_EXT

 //-----------------------------------------------------------------------
 private tagSuitableMethodData Helper__CAN_USE_EXT_FOR_EXT
                                           (Structure_MethodId           testMethodId,
                                            IReadOnlyList<SqlExpression> callArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(testMethodId,null));
  Debug.Assert(testMethodId.IsStatic);
  Debug.Assert(testMethodId.IsExtension);

  Debug.Assert(!Object.ReferenceEquals(callArguments,null));
  Debug.Assert(callArguments.Count>0);

  var method_Parameters=testMethodId.Parameters;

  Debug.Assert(!Object.ReferenceEquals(method_Parameters,null));

  Debug.Assert(method_Parameters.Count>0);

  //extension with another count of parameters
  if(method_Parameters.Count!=callArguments.Count)
   return null;

  //check source type
  var cvtResult1
   =Helper__TestCompatibleCallerType
     (callArguments[0],
      method_Parameters[0].ParameterType);

  if(!cvtResult1.OK)
   return null;

  //----------------------------------------
  long cvtNumber2=0;

  for(int i=1,_c=callArguments.Count;i!=_c;++i)
  {
   var callArg=callArguments[i];

   Debug.Assert(!Object.ReferenceEquals(callArg,null));

   var methodArg=method_Parameters[i];

   Debug.Assert(!Object.ReferenceEquals(methodArg,null));

   var cr
    =LcpiOleDb__TestSafeSqlConversion.Exec
      (callArg,
       methodArg);

   if(!cr.OK)
   {
    return null;
   }//of

   Debug.Assert(cr.OK);
   Debug.Assert(cr.Weight>=0);

   cvtNumber2+=cr.Weight;
  }//for i

  //method can be used for call
  var r
   =new tagSuitableMethodData
     (testMethodId,
      null,
      callArguments,
      cvtResult1.Weight,
      cvtNumber2);

  return r;
 }//Helper__CAN_USE_EXT_FOR_EXT

 //-----------------------------------------------------------------------
 private tagSuitableMethodData Helper__CAN_USE_STATIC_FOR_STATIC
                                           (Structure_MethodId           testMethodId,
                                            System.Type                  callDeclaringType,
                                            IReadOnlyList<SqlExpression> callArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(testMethodId,null));
  Debug.Assert(!Object.ReferenceEquals(testMethodId.DeclaringType,null));
  Debug.Assert(testMethodId.IsStatic);
  Debug.Assert(!testMethodId.IsExtension);

  Debug.Assert(!Object.ReferenceEquals(callDeclaringType,null));
  Debug.Assert(!Object.ReferenceEquals(callArguments,null));

  var method_Parameters=testMethodId.Parameters;

  Debug.Assert(!Object.ReferenceEquals(method_Parameters,null));

  //method with another count of parameters
  if(method_Parameters.Count!=callArguments.Count)
   return null;

  //----------------------------------------
  var cvtResult1
   =Helper__TestCompatibleDeclaringType
     (callDeclaringType,
      testMethodId.DeclaringType);

  if(!cvtResult1.OK)
   return null;

  //----------------------------------------
  long cvtNumber2=0;

  for(int i=0,_c=callArguments.Count;i!=_c;++i)
  {
   var callArg=callArguments[i];

   Debug.Assert(!Object.ReferenceEquals(callArg,null));

   var methodArg=method_Parameters[i];

   Debug.Assert(!Object.ReferenceEquals(methodArg,null));

   var cr
    =LcpiOleDb__TestSafeSqlConversion.Exec
      (callArg,
       methodArg);

   if(!cr.OK)
   {
    return null;
   }//if

   Debug.Assert(cr.OK);
   Debug.Assert(cr.Weight>=0);

   cvtNumber2+=cr.Weight;
  }//for i

  //method can be used for call
  var r
   =new tagSuitableMethodData
     (testMethodId,
      /*callObject*/null,
      callArguments,
      cvtResult1.Weight,
      cvtNumber2);

  return r;
 }//Helper__CAN_USE_STATIC_FOR_STATIC

 //-----------------------------------------------------------------------
 private static T_TEST_CVT_RESULT Helper__TestCompatibleCallerType
                             (SqlExpression callObject,
                              System.Type   declaringType)
 {
  Debug.Assert(!Object.ReferenceEquals(callObject,null));
  Debug.Assert(!Object.ReferenceEquals(declaringType,null));

  //
  // [2021-06-16]
  //
  //  Nullable<T>.GetDefaultValue. Need unpack T.
  //
  declaringType
   =declaringType.Extension__UnwrapNullableType();

  Debug.Assert(!Object.ReferenceEquals(declaringType,null));

  //
  // [2021-06-07]
  //
  // At current time, we expect here the CLEAR declaringType only:
  // - NOT Enumerable
  //
  Debug.Assert(declaringType==declaringType.Extension__GetUnderlyingValueType());

  //-------------------------------------------------------
  const string c_bugcheck_src
   ="LcpiOleDb__MethodCallTranslatorProvider::Helper__TestCompatibleCallerType";

  //-------------------------------------------------------
  System.Type
   callObject_type
    =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
      (c_ErrSrcID,
       c_bugcheck_src,
       "#001",
       callObject);

  Debug.Assert(!Object.ReferenceEquals(callObject_type,null));
  Debug.Assert(callObject_type==callObject_type.Extension__UnwrapNullableType());
  Debug.Assert(callObject_type==callObject_type.Extension__UnwrapMappingClrType());

  //-------------------------------------------------------
  if(declaringType.IsInterface)
  {
   if(declaringType.IsAssignableFrom(callObject_type))
    return T_TEST_CVT_RESULT.Create_OK(Int32.MaxValue);

   return T_TEST_CVT_RESULT.Create_NO();
  }//if

  //-------------------------------------------------------
  return Helper__TestCompatibleDeclaringType
          (callObject_type,
           declaringType);
 }//Helper__TestCompatibleCallerType

 //-----------------------------------------------------------------------
 private static T_TEST_CVT_RESULT Helper__TestCompatibleDeclaringType
                             (System.Type   callDeclaringType,
                              System.Type   testDeclaringType)
 {
  if(testDeclaringType==callDeclaringType)
   return T_TEST_CVT_RESULT.Create_OK(0);

  int cvtNumber1=0;

  for(var x=callDeclaringType.BaseType;;x=x.BaseType)
  {
   if(Object.ReferenceEquals(x,null))
   {
    return T_TEST_CVT_RESULT.Create_NO();
   }//if

   ++cvtNumber1;

   if(x==testDeclaringType)
   {
    //OK
    return T_TEST_CVT_RESULT.Create_OK(cvtNumber1);
   }//if
  }//for[ever] x
 }//Helper__TestCompatibleDeclaringType

 //private types ---------------------------------------------------------
 private sealed class tagSuitableMethodData
 {
  public readonly Structure_MethodId           MethodId;
  public readonly SqlExpression                CallObject;
  public readonly IReadOnlyList<SqlExpression> CallArguments;
  public readonly long                         CvtNumber1;
  public readonly long                         CvtNumber2;

  //----------------------------------------
  public tagSuitableMethodData(Structure_MethodId           methodId,
                               SqlExpression                callObject,
                               IReadOnlyList<SqlExpression> callArguments,
                               long                         cvtNumber1,
                               long                         cvtNumber2)
  {
   Debug.Assert(!Object.ReferenceEquals(methodId,null));
   //Debug.Assert(!Object.ReferenceEquals(callObject,null));
   Debug.Assert(!Object.ReferenceEquals(callArguments,null));

   Debug.Assert(cvtNumber1>=0);
   Debug.Assert(cvtNumber2>=0);

   //----
   this.MethodId      =methodId;
   this.CallObject    =callObject;
   this.CallArguments =callArguments;
   this.CvtNumber1    =cvtNumber1;
   this.CvtNumber2    =cvtNumber2;
  }//tagSuitableMethodData
 };//class tagSuitableMethodData

 //-----------------------------------------------------------------------
 private sealed class tagSuitableMethodDataComparer:IComparer<tagSuitableMethodData>
 {
  public static readonly tagSuitableMethodDataComparer Instance
   =new tagSuitableMethodDataComparer();

  //----------------------------------------------------------------------
  private tagSuitableMethodDataComparer()
  {
  }//tagSuitableMethodDataComparer

  //IComparer interface --------------------------------------------------
  public int Compare(tagSuitableMethodData a,
                     tagSuitableMethodData b)
  {
   Debug.Assert(!Object.ReferenceEquals(a,null));
   Debug.Assert(!Object.ReferenceEquals(b,null));

   if(a.CvtNumber1<b.CvtNumber1)
    return -1;

   if(a.CvtNumber1>b.CvtNumber1)
    return 1;

   if(a.CvtNumber2<b.CvtNumber2)
    return -1;

   if(a.CvtNumber2>b.CvtNumber2)
    return 1;

   return 0;
  }//Compare
 };//class tagSuitableMethodDataComparer

 //-----------------------------------------------------------------------
 private sealed class tagSuitableMethodDatas:List<tagSuitableMethodData>{};

 //private data ----------------------------------------------------------
 private readonly T_TRANSLATORS1
  m_translators1;

 private readonly List<IMethodCallTranslator>
  m_translators2
   =new List<IMethodCallTranslator>();

 private readonly LcpiOleDb__ISqlTreeNodeBuilder
  m_sqlTreeNodeBuilder;

 private readonly LcpiOleDb__SqlExpressionFactory
  m_sqlExpressionFactory;

 private readonly Core.Core_ConnectionOptions
  m_CnOptions;
};//class LcpiOleDb__MethodCallTranslatorProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Sql
