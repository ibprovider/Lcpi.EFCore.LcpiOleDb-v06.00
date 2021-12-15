////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 05.10.2018.
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Svcs{
////////////////////////////////////////////////////////////////////////////////
//Using

using Structure_MethodId
 =Structure.Structure_MethodId;

using Structure_MethodParameterDescr
 =Structure.Structure_MethodParameterDescr;

using Structure_TestConversionResult
 =Structure.Structure_TestConversionResult;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation

sealed partial class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation
{
 protected override Expression VisitMethodCall(MethodCallExpression node)
 {
  Debug.Assert(!Object.ReferenceEquals(node,null));
  Debug.Assert(!Object.ReferenceEquals(node.Method,null));
  Debug.Assert(!Object.ReferenceEquals(node.Arguments,null));

  const string c_bugcheck_src
   ="LcpiOleDb__LocalSvc__PrepareForLocalEvaluation::VisitMethodCall";

  //---------------------------------------- 1. Prepare node object
  Expression node_Object=node.Object;

  Expression node_Object2=null;

  while(!Object.ReferenceEquals(node_Object,null))
  {
   node_Object2=this.Visit(node_Object);

   //-----
   if(Object.ReferenceEquals(node_Object2,null))
   {
    ThrowBugCheck.LocalEvalErr__mutation__null_ptr_to_new_expression
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      node_Object);

    Debug.Assert(false);
   }//if

   Debug.Assert(!Object.ReferenceEquals(node_Object2,null));
   Debug.Assert(!Object.ReferenceEquals(node_Object2.Type,null));

   break;
  }//while(!Object.ReferenceEquals(node_Object2,null))

  //---------------------------------------- 2. Prepare node arguments
  var method=node.Method;

  Debug.Assert(!Object.ReferenceEquals(method,null));

  var method_Parameters
   =method.GetParameters();

  Debug.Assert(!Object.ReferenceEquals(method_Parameters,null));

  //-----
  var node_Arguments=node.Arguments;

  Debug.Assert(!Object.ReferenceEquals(node_Arguments,null));

  //[2018-10-14] By Fact?
  Debug.Assert(method_Parameters.Length==node_Arguments.Count);

  //-----
  var node_Arguments2=new Expression[node_Arguments.Count];

  Debug.Assert(!Object.ReferenceEquals(node_Arguments2,null));

  //-----
  for(int i=0,_c=node_Arguments.Count;i!=_c;++i)
  {
   var a=node_Arguments[i];

   Debug.Assert(!Object.ReferenceEquals(a,null));
   Debug.Assert(!Object.ReferenceEquals(a.Type,null));

   //-----
   var a2=this.Visit(a);

   if(Object.ReferenceEquals(a2,null))
   {
    ThrowBugCheck.LocalEvalErr__mutation__null_ptr_to_new_expression
     (c_ErrSrcID,
      c_bugcheck_src,
      "#002",
      a);

    Debug.Assert(false);
   }//if

   Debug.Assert(!Object.ReferenceEquals(a2,null));
   Debug.Assert(!Object.ReferenceEquals(a2.Type,null));

   node_Arguments2[i]=a2;
  }//for i

  //----------------------------------------
  var newMethodCallData
   =Helper__BuildCallWithNewMethod
     (method,
      node_Object2,
      node_Arguments2);

  if(Object.ReferenceEquals(newMethodCallData,null))
  {
   if(m_ExecutionOfUnknownMethods)
   {
    return Helper__MakeCallOfUnknownMethod
            (method,
             node_Object2,
             node_Arguments2); //throw
   }//if m_ExecutionOfUnknownMethods

   //ERROR - can't remap method
   ThrowError.LocalEvalErr__CantRemapMethodCall
    (c_ErrSrcID,
     method,
     node_Object2,
     node_Arguments2);
  }//if

  LcpiOleDb__LocalEval_MethodCallTranslator.tagOpData
   translationData
    =new LcpiOleDb__LocalEval_MethodCallTranslator.tagOpData
      (newMethodCallData.MethodId,
       newMethodCallData.CallObject,
       newMethodCallData.CallArguments,
       m_ExpressionServices);

  Debug.Assert(!Object.ReferenceEquals(translationData.MethodId,null));

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(m_ExpressionServices,null));
  Debug.Assert(!Object.ReferenceEquals(m_ExpressionServices.MethodCallTranslators,null));

  LcpiOleDb__LocalEval_MethodCallTranslator
   translator
    =null;

  if(m_ExpressionServices.MethodCallTranslators.TryGetValue(translationData.MethodId,out translator))
  {
   Debug.Assert(!Object.ReferenceEquals(translator,null));

   Expression
    result
     =translator.Translate
       (translationData);

   Debug.Assert(!Object.ReferenceEquals(result,null));

   return result;
  }//if TryGetValue

  // [2021-06-12] WTF?

  ThrowBugCheck.LocalEvalErr__unsupported_method
   (c_ErrSrcID,
    c_bugcheck_src,
    "#003",
    translationData.MethodId);

  Debug.Assert(false);

  return null;
 }//VisitMethodCall

 //Helper methods --------------------------------------------------------
 private static Expression Helper__MakeCallOfUnknownMethod
                                           (MethodInfo                methodInfo,
                                            Expression                callObject,
                                            IReadOnlyList<Expression> callArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(methodInfo,null));
  Debug.Assert(!Object.ReferenceEquals(callArguments,null));

  //try call own implementation

  //
  // [2021-06-08] At current time will do this without any correction of argument types.
  //

  var x
   =Expression.Call
     (callObject,
      methodInfo,
      callArguments); //throw

  Debug.Assert(!Object.ReferenceEquals(x,null));

  return x;
 }//Helper__MakeCallOfUnknownMethod

 //-----------------------------------------------------------------------
 private tagSuitableMethodData Helper__BuildCallWithNewMethod
                                           (MethodInfo   oldMethod,
                                            Expression   newObject,
                                            Expression[] newArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(oldMethod,null));
  //Debug.Assert(!Object.ReferenceEquals(newObject,null));
  Debug.Assert(!Object.ReferenceEquals(newArguments,null));

  //----------------------------------------------------------------------
  var originalMethodId
   =Structure_MethodId.Create
     (oldMethod);

  Debug.Assert(!Object.ReferenceEquals(originalMethodId,null));

  //----------------------------------------
  tagSuitableMethodData
   newMethodCallData
    =Helper__GetSuitableMethod
      (originalMethodId,
       newObject,
       newArguments);

  if(!Object.ReferenceEquals(newMethodCallData,null))
   return newMethodCallData;

  //----------------------------------------
  return null;
 }//Helper__BuildCallWithNewMethod

 //-----------------------------------------------------------------------
 private tagSuitableMethodData Helper__GetSuitableMethod
                                           (Structure_MethodId originalMethodId,
                                            Expression         newObject,
                                            Expression[]       newArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethodId,null));
  //Debug.Assert(!Object.ReferenceEquals(newObject,null));
  Debug.Assert(!Object.ReferenceEquals(newArguments,null));

  tagSuitableMethodDatas
   suitableMethods
    =this.Helper__GetSuitableMethods
      (originalMethodId,
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
                                           (Structure_MethodId originalMethodId,
                                            Expression         newObject,
                                            Expression[]       newArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethodId,null));
  //Debug.Assert(!Object.ReferenceEquals(newObject,null));
  Debug.Assert(!Object.ReferenceEquals(newArguments,null));

  if(!originalMethodId.IsStatic)
  {
   //Remap standard method

   Debug.Assert(!originalMethodId.IsExtension);

   Debug.Assert(!Object.ReferenceEquals(newObject,null));

   return this.Helper__GetSuitableMethods__Std
            (originalMethodId,
             newObject,
             newArguments);
  }//if

  Debug.Assert(originalMethodId.IsStatic);
  Debug.Assert(Object.ReferenceEquals(newObject,null));

  if(originalMethodId.IsExtension)
  {
   //Remap extension method

   return this.Helper__GetSuitableMethods__Ext
           (originalMethodId,
            newArguments);
  }//if

  Debug.Assert(!originalMethodId.IsExtension);

  Debug.Assert(originalMethodId.IsStatic);
  Debug.Assert(Object.ReferenceEquals(newObject,null));

  //Remap static method

  return this.Helper__GetSuitableMethods__Static
          (originalMethodId,
           newArguments);
 }//Helper__GetSuitableMethods

 //-----------------------------------------------------------------------
 private tagSuitableMethodDatas Helper__GetSuitableMethods__Std
                                           (Structure_MethodId originalMethodId,
                                            Expression         newObject,
                                            Expression[]       newArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethodId,null));
  Debug.Assert(!Object.ReferenceEquals(newObject,null));
  Debug.Assert(!Object.ReferenceEquals(newArguments,null));

  Debug.Assert(!originalMethodId.IsStatic);

  var suitableMethods=new tagSuitableMethodDatas();

  Debug.Assert(!Object.ReferenceEquals(m_ExpressionServices,null));
  Debug.Assert(!Object.ReferenceEquals(m_ExpressionServices.MethodCallTranslators,null));

  foreach(var testMethodId in m_ExpressionServices.MethodCallTranslators.GetMethodIDs(originalMethodId.MethodName))
  {
   Debug.Assert(!Object.ReferenceEquals(testMethodId,null));

   Debug.Assert(testMethodId.MethodName==originalMethodId.MethodName);

   tagSuitableMethodData testData=null;

   if(!testMethodId.IsStatic)
   {
    testData=Helper__CAN_USE_STD_FOR_STD(testMethodId,newObject,newArguments);
   }
   else
   if(testMethodId.IsExtension)
   {
    testData=Helper__CAN_USE_EXT_FOR_STD(testMethodId,newObject,newArguments);
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
 }//Helper__GetSuitableMethods__Std

 //-----------------------------------------------------------------------
 private tagSuitableMethodDatas Helper__GetSuitableMethods__Ext
                                           (Structure_MethodId originalMethodId,
                                            Expression[]       newArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethodId,null));
  Debug.Assert(!Object.ReferenceEquals(newArguments,null));

  Debug.Assert(originalMethodId.IsStatic);
  Debug.Assert(originalMethodId.IsExtension);

  var suitableMethods=new tagSuitableMethodDatas();

  Debug.Assert(!Object.ReferenceEquals(m_ExpressionServices,null));
  Debug.Assert(!Object.ReferenceEquals(m_ExpressionServices.MethodCallTranslators,null));

  foreach(var testMethodId in m_ExpressionServices.MethodCallTranslators.GetMethodIDs(originalMethodId.MethodName))
  {
   Debug.Assert(!Object.ReferenceEquals(testMethodId,null));

   Debug.Assert(testMethodId.MethodName==originalMethodId.MethodName);

   tagSuitableMethodData testData=null;

   if(!testMethodId.IsStatic)
   {
    testData=Helper__CAN_USE_STD_FOR_EXT(testMethodId,newArguments);
   }
   else
   if(testMethodId.IsExtension)
   {
    testData=Helper__CAN_USE_EXT_FOR_EXT(testMethodId,newArguments);
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
                                           (Structure_MethodId originalMethodId,
                                            Expression[]       newArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethodId,null));
  Debug.Assert(!Object.ReferenceEquals(originalMethodId.DeclaringType,null));
  Debug.Assert(!Object.ReferenceEquals(newArguments,null));

  Debug.Assert(originalMethodId.IsStatic);
  Debug.Assert(!originalMethodId.IsExtension);

  var suitableMethods=new tagSuitableMethodDatas();

  Debug.Assert(!Object.ReferenceEquals(m_ExpressionServices,null));
  Debug.Assert(!Object.ReferenceEquals(m_ExpressionServices.MethodCallTranslators,null));

  foreach(var testMethodId in m_ExpressionServices.MethodCallTranslators.GetMethodIDs(originalMethodId.MethodName))
  {
   Debug.Assert(!Object.ReferenceEquals(testMethodId,null));
   Debug.Assert(!Object.ReferenceEquals(testMethodId.DeclaringType,null));

   Debug.Assert(testMethodId.MethodName==originalMethodId.MethodName);

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
        originalMethodId.DeclaringType,
        newArguments);

   if(!Object.ReferenceEquals(testData,null))
    suitableMethods.Add(testData);

   continue;
  }//foreach testMethodId

  return suitableMethods;
 }//Helper__GetSuitableMethods__Static

 //-----------------------------------------------------------------------
 private tagSuitableMethodData Helper__CAN_USE_STD_FOR_STD
                                           (Structure_MethodId testMethodId,
                                            Expression         callObject,
                                            Expression[]       callArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(testMethodId,null));
  Debug.Assert(!Object.ReferenceEquals(testMethodId.DeclaringType,null));
  Debug.Assert(!testMethodId.IsStatic);
  Debug.Assert(!testMethodId.IsExtension);

  Debug.Assert(!Object.ReferenceEquals(callObject,null));
  Debug.Assert(!Object.ReferenceEquals(callObject.Type,null));
  Debug.Assert(!Object.ReferenceEquals(callArguments,null));

  var method_Parameters
   =testMethodId.Parameters;

  Debug.Assert(!Object.ReferenceEquals(method_Parameters,null));

  //method with another count of parameters
  if(method_Parameters.Count!=callArguments.Length)
   return null;

  //check source type
  var cvtResult1
   =Helper__TestCompatibleCallerType
     (callObject,
      testMethodId.DeclaringType);

  if(!cvtResult1.OK)
   return null;

  Debug.Assert(!Object.ReferenceEquals(cvtResult1.Expression,null));

  //----------------------------------------
  var callArguments2
   =new Expression[method_Parameters.Count];

  int cvtNumber2=0;

  for(int i=0,_c=callArguments.Length;i!=_c;++i)
  {
   var callArg=callArguments[i];

   Debug.Assert(!Object.ReferenceEquals(callArg,null));

   var methodArg=method_Parameters[i];

   Debug.Assert(!Object.ReferenceEquals(methodArg,null));

   Debug.Assert(Object.ReferenceEquals(callArguments2[i],null));

   if(!Helper__TryMakeSafeConversion(callArg,
                                     methodArg,
                                     out callArguments2[i]))
   {
    return null;
   }//if

   Debug.Assert(!Object.ReferenceEquals(callArguments2[i],null));
   Debug.Assert(!Object.ReferenceEquals(callArguments2[i].Type,null));

   Debug.Assert(callArguments2[i].Type==methodArg.ParameterType);

   if(!Object.ReferenceEquals(callArg,callArguments2[i]))
    ++cvtNumber2;
  }//for i

  //method can be used for call
  var result
   =new tagSuitableMethodData
     (testMethodId,
      cvtResult1.Expression,
      callArguments2,
      cvtResult1.Weight,
      cvtNumber2);

  return result;
 }//Helper__CAN_USE_STD_FOR_STD

 //-----------------------------------------------------------------------
 private tagSuitableMethodData Helper__CAN_USE_STD_FOR_EXT
                                           (Structure_MethodId testMethodId,
                                            Expression[]       callArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(testMethodId,null));
  Debug.Assert(!Object.ReferenceEquals(testMethodId.DeclaringType,null));
  Debug.Assert(!testMethodId.IsStatic);
  Debug.Assert(!testMethodId.IsExtension);

  Debug.Assert(!Object.ReferenceEquals(callArguments,null));
  Debug.Assert(callArguments.Length>0);

  var method_Parameters
   =testMethodId.Parameters;

  Debug.Assert(!Object.ReferenceEquals(method_Parameters,null));

  //method with another count of parameters
  if(method_Parameters.Count!=callArguments.Length-1)
   return null;

  //check source type
  Debug.Assert(!Object.ReferenceEquals(callArguments[0],null));
  Debug.Assert(!Object.ReferenceEquals(callArguments[0].Type,null));

  var cvtResult1
   =Helper__TestCompatibleCallerType
     (callArguments[0],
      testMethodId.DeclaringType);

  if(!cvtResult1.OK)
   return null;

  Debug.Assert(!Object.ReferenceEquals(cvtResult1.Expression,null));

  //----------------------------------------
  var callArguments2
   =new Expression[method_Parameters.Count];

  int cvtNumber2=0;

  for(int i=0,_c=method_Parameters.Count;i!=_c;++i)
  {
   var methodArg=method_Parameters[i];

   Debug.Assert(!Object.ReferenceEquals(methodArg,null));

   var callArg=callArguments[i+1];

   Debug.Assert(!Object.ReferenceEquals(callArg,null));

   Debug.Assert(Object.ReferenceEquals(callArguments2[i],null));

   if(!Helper__TryMakeSafeConversion(callArg,
                                     methodArg,
                                     out callArguments2[i]))
   {
    return null;
   }//if

   Debug.Assert(!Object.ReferenceEquals(callArguments2[i],null));
   Debug.Assert(!Object.ReferenceEquals(callArguments2[i].Type,null));

   Debug.Assert(callArguments2[i].Type==methodArg.ParameterType);

   if(!Object.ReferenceEquals(callArg,callArguments2[i]))
    ++cvtNumber2;
  }//for i

  //method can be used for call
  var result
   =new tagSuitableMethodData
     (testMethodId,
      cvtResult1.Expression,
      callArguments2,
      cvtResult1.Weight,
      cvtNumber2);

  return result;
 }//Helper__CAN_USE_STD_FOR_EXT

 //-----------------------------------------------------------------------
 private tagSuitableMethodData Helper__CAN_USE_EXT_FOR_EXT
                                           (Structure_MethodId testMethodId,
                                            Expression[]       callArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(testMethodId,null));
  Debug.Assert(testMethodId.IsExtension);

  Debug.Assert(!Object.ReferenceEquals(callArguments,null));
  Debug.Assert(callArguments.Length>0);

  var method_Parameters
   =testMethodId.Parameters;

  Debug.Assert(!Object.ReferenceEquals(method_Parameters,null));

  Debug.Assert(method_Parameters.Count>0);

  //extension with another count of parameters
  if(method_Parameters.Count!=callArguments.Length)
   return null;

  //check source type
  Debug.Assert(!Object.ReferenceEquals(method_Parameters[0],null));
  Debug.Assert(!Object.ReferenceEquals(method_Parameters[0].ParameterType,null));

  Debug.Assert(!Object.ReferenceEquals(callArguments[0],null));
  Debug.Assert(!Object.ReferenceEquals(callArguments[0].Type,null));

  var cvtResult1
   =Helper__TestCompatibleCallerType
     (callArguments[0],
      method_Parameters[0].ParameterType);

  if(!cvtResult1.OK)
   return null;

  Debug.Assert(!Object.ReferenceEquals(cvtResult1.Expression,null));

  //----------------------------------------
  var callArguments2
   =new Expression[method_Parameters.Count];

  callArguments2[0]=cvtResult1.Expression;

  int cvtNumber2=0;

  for(int i=1,_c=callArguments.Length;i!=_c;++i)
  {
   var callArg=callArguments[i];

   Debug.Assert(!Object.ReferenceEquals(callArg,null));

   var methodArg=method_Parameters[i];

   Debug.Assert(!Object.ReferenceEquals(methodArg,null));

   Debug.Assert(Object.ReferenceEquals(callArguments2[i],null));

   if(!Helper__TryMakeSafeConversion(callArg,
                                     methodArg,
                                     out callArguments2[i]))
   {
    return null;
   }//if

   Debug.Assert(!Object.ReferenceEquals(callArguments2[i],null));
   Debug.Assert(!Object.ReferenceEquals(callArguments2[i].Type,null));

   Debug.Assert(callArguments2[i].Type==methodArg.ParameterType);

   if(!Object.ReferenceEquals(callArg,callArguments2[i]))
    ++cvtNumber2;
  }//for i

  //method can be used for call
  var result
   =new tagSuitableMethodData
     (testMethodId,
      null,
      callArguments2,
      cvtResult1.Weight,
      cvtNumber2);

  return result;
 }//Helper__CAN_USE_EXT_FOR_EXT

 //-----------------------------------------------------------------------
 private tagSuitableMethodData Helper__CAN_USE_EXT_FOR_STD
                                           (Structure_MethodId testMethodId,
                                            Expression         callObject,
                                            Expression[]       callArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(testMethodId,null));
  Debug.Assert(testMethodId.IsExtension);

  Debug.Assert(!Object.ReferenceEquals(callObject,null));
  Debug.Assert(!Object.ReferenceEquals(callObject.Type,null));
  Debug.Assert(!Object.ReferenceEquals(callArguments,null));

  var method_Parameters
   =testMethodId.Parameters;

  Debug.Assert(!Object.ReferenceEquals(method_Parameters,null));

  Debug.Assert(method_Parameters.Count>0);

  //extension with another count of parameters
  if((method_Parameters.Count-1)!=callArguments.Length)
   return null;

  //Check source type
  Debug.Assert(!Object.ReferenceEquals(method_Parameters[0],null));
  Debug.Assert(!Object.ReferenceEquals(method_Parameters[0].ParameterType,null));

  var cvtResult1
   =Helper__TestCompatibleCallerType
     (callObject,
      method_Parameters[0].ParameterType);

  if(!cvtResult1.OK)
   return null;

  Debug.Assert(!Object.ReferenceEquals(cvtResult1.Expression,null));

  //----------------------------------------
  var callArguments2
   =new Expression[method_Parameters.Count];

  callArguments2[0]=cvtResult1.Expression;

  int cvtNumber2=0;

  for(int i=0,_c=callArguments.Length;i!=_c;)
  {
   var callArg=callArguments[i];

   Debug.Assert(!Object.ReferenceEquals(callArg,null));

   ++i;

   var methodArg=method_Parameters[i];

   Debug.Assert(!Object.ReferenceEquals(methodArg,null));

   Debug.Assert(Object.ReferenceEquals(callArguments2[i],null));

   if(!Helper__TryMakeSafeConversion(callArg,
                                     methodArg,
                                     out callArguments2[i]))
   {
    return null;
   }//if

   Debug.Assert(!Object.ReferenceEquals(callArguments2[i],null));

   if(!Object.ReferenceEquals(callArg,callArguments2[i]))
    ++cvtNumber2;
  }//for i

  //method can be used for call
  var result
   =new tagSuitableMethodData
     (testMethodId,
      null,
      callArguments2,
      cvtResult1.Weight,
      cvtNumber2);

  return result;
 }//Helper__CAN_USE_EXT_FOR_STD

 //-----------------------------------------------------------------------
 private tagSuitableMethodData Helper__CAN_USE_STATIC_FOR_STATIC
                                           (Structure_MethodId testMethodId,
                                            System.Type        callDeclaringType,
                                            Expression[]       callArguments)
 {
  Debug.Assert(!Object.ReferenceEquals(testMethodId,null));
  Debug.Assert(!Object.ReferenceEquals(testMethodId.DeclaringType,null));
  Debug.Assert(testMethodId.IsStatic);
  Debug.Assert(!testMethodId.IsExtension);

  Debug.Assert(!Object.ReferenceEquals(callDeclaringType,null));
  Debug.Assert(!Object.ReferenceEquals(callArguments,null));

  var method_Parameters
   =testMethodId.Parameters;

  Debug.Assert(!Object.ReferenceEquals(method_Parameters,null));

  //method with another count of parameters
  if(method_Parameters.Count!=callArguments.Length)
   return null;

  //----------------------------------------
  var cvtResult1
   =Helper__TestCompatibleDeclaringType
     (callDeclaringType,
      testMethodId.DeclaringType);

  if(!cvtResult1.OK)
   return null;

  //----------------------------------------
  var callArguments2
   =new Expression[method_Parameters.Count];

  int cvtNumber2=0;

  for(int i=0,_c=callArguments.Length;i!=_c;++i)
  {
   var callArg=callArguments[i];

   Debug.Assert(!Object.ReferenceEquals(callArg,null));

   var methodArg=method_Parameters[i];

   Debug.Assert(!Object.ReferenceEquals(methodArg,null));

   Debug.Assert(Object.ReferenceEquals(callArguments2[i],null));

   if(!Helper__TryMakeSafeConversion(callArg,
                                     methodArg,
                                     out callArguments2[i]))
   {
    return null;
   }//if

   Debug.Assert(!Object.ReferenceEquals(callArguments2[i],null));

   if(!Object.ReferenceEquals(callArg,callArguments2[i]))
    ++cvtNumber2;
  }//for i

  //method can be used for call
  var result
   =new tagSuitableMethodData
     (testMethodId,
      /*callObject*/null,
      callArguments2,
      cvtResult1.Weight,
      cvtNumber2);

  return result;
 }//Helper__CAN_USE_STATIC_FOR_STATIC

 //-----------------------------------------------------------------------
 private static bool Helper__TryMakeSafeConversion
                                           (Expression                     fromArg,
                                            Structure_MethodParameterDescr toParam,
                                            out Expression                 result)
 {
  Debug.Assert(!Object.ReferenceEquals(fromArg,null));
  Debug.Assert(!Object.ReferenceEquals(fromArg.Type,null));
  Debug.Assert(!Object.ReferenceEquals(toParam,null));
  Debug.Assert(!Object.ReferenceEquals(toParam.ParameterType,null));

  return Helper__TryMakeSafeConversion
          (fromArg,
           toParam.ParameterType,
           out result);
 }//Helper__TryMakeSafeConversion

 //-----------------------------------------------------------------------
 private static bool Helper__TryMakeSafeConversion
                                           (Expression     source,
                                            System.Type    resultType,
                                            out Expression result)
 {
  Debug.Assert(!Object.ReferenceEquals(source,null));
  Debug.Assert(!Object.ReferenceEquals(source.Type,null));
  Debug.Assert(!Object.ReferenceEquals(resultType,null));

  result=null;

  //-------------------------------------------------------
  var testSafeCvt
   =Core.Core_TestSafeConversion.Exec
     (source.Type,
      resultType);

  if(!testSafeCvt.OK)
  {
   // [2021-12-03] Research. Catch WTF.
   Debug.Assert(source.Type!=resultType);

   return false;
  }//if

  //-------------------------------------------------------
  if(source.Type==resultType)
  {
   result=source;

   return true;
  }//if

  //-------------------------------------------------------
  result
   =Expression.Convert
     (source,
      resultType);

  Debug.Assert(!Object.ReferenceEquals(result,null));
  Debug.Assert(!Object.ReferenceEquals(result.Type,null));
  Debug.Assert(result.Type==resultType);

  return true;
 }//Helper__TryMakeSafeConversion

 //-----------------------------------------------------------------------
 private static tagTestConversionResult Helper__TestCompatibleCallerType
                                           (Expression  callObject,
                                            System.Type declaringType)
 {
  Debug.Assert(!Object.ReferenceEquals(callObject,null));
  Debug.Assert(!Object.ReferenceEquals(declaringType,null));

  //-------------------------------------------------------
  if(declaringType==callObject.Type)
  {
   return tagTestConversionResult.Create_OK
           (0,
            callObject);
  }//if

  //-------------------------------------------------------
  if(declaringType.IsInterface)
  {
   if(declaringType.IsAssignableFrom(callObject.Type))
   {
    var callObject2
     =Expression.Convert
       (callObject,
        declaringType);

    return tagTestConversionResult.Create_OK
            (Int32.MaxValue,
             callObject2);
   }//if

   return tagTestConversionResult.Create_NO();
  }//if

  //-------------------------------------------------------
  int cvtNumber1=0;

  for(var x=callObject.Type.BaseType;;x=x.BaseType)
  {
   if(Object.ReferenceEquals(x,null))
    return tagTestConversionResult.Create_NO();

   ++cvtNumber1;

   if(x!=declaringType)
    continue;

   var callObject2
    =Expression.Convert
      (callObject,
       declaringType);

   return tagTestConversionResult.Create_OK
           (cvtNumber1,
            callObject2);
  }//for x
 }//Helper__TestCompatibleCallerType

 //-----------------------------------------------------------------------
 private static Structure_TestConversionResult Helper__TestCompatibleDeclaringType
                             (System.Type   callDeclaringType,
                              System.Type   testDeclaringType)
 {
  if(testDeclaringType==callDeclaringType)
   return Structure_TestConversionResult.Create_OK(0);

  int cvtNumber1=0;

  for(var x=callDeclaringType.BaseType;;x=x.BaseType)
  {
   if(Object.ReferenceEquals(x,null))
   {
    return Structure_TestConversionResult.Create_NO();
   }//if

   ++cvtNumber1;

   if(x==testDeclaringType)
   {
    //OK
    return Structure_TestConversionResult.Create_OK(cvtNumber1);
   }//if
  }//for[ever] x
 }//Helper__TestCompatibleDeclaringType

 //private types ---------------------------------------------------------
 private sealed class tagSuitableMethodData
 {
  public readonly Structure_MethodId MethodId;
  public readonly Expression         CallObject;
  public readonly Expression[]       CallArguments;
  public readonly int                CvtNumber1;
  public readonly int                CvtNumber2;

  //----------------------------------------
  public tagSuitableMethodData(Structure_MethodId methodId,
                               Expression         callObject,
                               Expression[]       callArguments,
                               int                cvtNumber1,
                               int                cvtNumber2)
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

 //-----------------------------------------------------------------------
 private struct tagTestConversionResult
 {
  public readonly bool OK;

  public readonly int Weight;

  public readonly Expression Expression;

  //-------------------------------------------------------
  private tagTestConversionResult(bool       ok,
                                  int        weight,
                                  Expression expression)
  {
   this.OK=ok;
   this.Weight=weight;
   this.Expression=expression;
  }//tagTestConversionResult

  //-------------------------------------------------------
  public static tagTestConversionResult Create_OK(int        weight,
                                                  Expression expression)
  {
   Debug.Assert(weight>=0);

   Debug.Assert(!Object.ReferenceEquals(expression,null));

   return new tagTestConversionResult
           (true,
            weight,
            expression);
  }//Create_OK

  //-------------------------------------------------------
  public static tagTestConversionResult Create_NO()
  {
   return new tagTestConversionResult
           (false,
            /*weight*/0,
            /*expression*/null);
  }//Create_NO
 };//struct tagTestConversionResult
};//class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Svcs
