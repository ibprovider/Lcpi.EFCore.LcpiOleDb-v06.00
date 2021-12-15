////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 05.10.2018.
using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Svcs{
////////////////////////////////////////////////////////////////////////////////
//Using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation

/// <summary>
///  Service for prepare expression tree for local evaluations.
/// </summary>
sealed partial class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation
 :ExpressionVisitor
 ,Core.Engines.EngineSvc__ExpressionVisitor
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__LocalSvc__PrepareForLocalEvaluation;

 //-----------------------------------------------------------------------
 public LcpiOleDb__LocalSvc__PrepareForLocalEvaluation
                   (LcpiOleDb__LocalEval_Services          ExpressionServices,
                    LcpiOleDb__LocalEval_MemberTranslators MemberTranslators,
                    bool                                   ExecutionOfUnknownMethods)
 {
  Debug.Assert(!Object.ReferenceEquals(ExpressionServices,null));
  Debug.Assert(!Object.ReferenceEquals(MemberTranslators,null));

  //----------------------------------------
  m_ExpressionServices        =ExpressionServices;
  m_MemberTranslators         =MemberTranslators;
  m_ExecutionOfUnknownMethods =ExecutionOfUnknownMethods;

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(m_ExpressionServices,null));
  Debug.Assert(!Object.ReferenceEquals(m_MemberTranslators,null));
 }//LcpiOleDb__LocalSvc__PrepareForLocalEvaluation

 //ExpressionVisitor interface -------------------------------------------
 public override Expression Visit(Expression node)
 {
  var r
   =base.Visit(node);

  if(Object.ReferenceEquals(r,null))
   return r;

  Debug.Assert(!Object.ReferenceEquals(r,null));
  Debug.Assert(!Object.ReferenceEquals(r.Type,null));

  //switch to underlying data types
  var nativeType
   =r.Type.Extension__SwitchToUnderlying();

  Debug.Assert(!Object.ReferenceEquals(nativeType,null));

  if(r.Type==nativeType)
   return r;

  var methodForCvtToNative
   =Helper__GetSysCvtMethodToNative(r,nativeType);

  var r2
   =Expression.Convert
     (r,
      nativeType,
      methodForCvtToNative);

  Debug.Assert(!Object.ReferenceEquals(r2,null));

  return r2;
 }//Visit

 //-----------------------------------------------------------------------
 protected override Expression VisitUnary(UnaryExpression node)
 {
  Debug.Assert(!Object.ReferenceEquals(node,null));

  //----------------------------------------
  const string c_bugcheck_src
   ="LcpiOleDb__LocalSvc__PrepareForLocalEvaluation::VisitUnary";

  //----------------------------------------
  if(Helper__CanRemoveConvert(node))
  {
   return Helper__RemoveConvert(node);
  }//if

  //----------------------------------------
  ExpressionType nodeType2;

  if(node.Extension__IsConvert2())
  {
   nodeType2=ExpressionType.Convert;
  }
  else
  {
   Debug.Assert(!node.Extension__IsConvert2());

   switch(node.NodeType)
   {
    case ExpressionType.NegateChecked:
     nodeType2=ExpressionType.Negate;
     break;

    default:
     Debug.Assert(!node.Extension__IsConvert2());

     nodeType2=node.NodeType;
     break;
   }//switch
  }//else

  //----------------------------------------
  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#001",
    "node.Operand",
    node.Operand);

  //----------------------------------------
  var translatedOperand
   =this.Visit(node.Operand);

  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#002",
    nameof(translatedOperand),
    translatedOperand);

  //----------------------------------------
  LcpiOleDb__LocalEval_Op1__Descr
   op1Descr
    =default;

  if(!m_ExpressionServices.TryGetOp1Descr(nodeType2,translatedOperand.Type,out op1Descr))
  {
   ThrowError.LocalEvalErr__UnaryOperatorNotSupported
    (c_ErrSrcID,
     nodeType2,
     translatedOperand.Type);

   Debug.Assert(false);
  }//if

  Debug.Assert(!Object.ReferenceEquals(op1Descr.Translator,null));

  //----------------------------------------
  var opData
   =new LcpiOleDb__LocalEval_UnaryTranslator.tagOpData
     (nodeType2,
      node.Type,
      translatedOperand,
      m_ExpressionServices);

  var r
   =op1Descr.Translator.Translate
     (opData);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//VisitUnary

 //-----------------------------------------------------------------------
 protected override Expression VisitBinary(BinaryExpression node)
 {
  Debug.Assert(!Object.ReferenceEquals(node,null));
  Debug.Assert(!Object.ReferenceEquals(node.Left,null));
  Debug.Assert(!Object.ReferenceEquals(node.Right,null));

  //----------------------------------------
  const string c_bugcheck_src
   ="LcpiOleDb__LocalSvc__PrepareForLocalEvaluation::VisitBinary";

  //----------------------------------------
  var node_Left=this.Visit(node.Left);

  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#001",
    nameof(node_Left),
    node_Left);

  //----------------------------------------
  var node_Right=this.Visit(node.Right);

  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#002",
    nameof(node_Right),
    node_Right);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(node_Left,null));
  Debug.Assert(!Object.ReferenceEquals(node_Right,null));

  //----------------------------------------
  var type_Left  =node_Left.Type;
  var type_Right =node_Right.Type;

  Debug.Assert(!Object.ReferenceEquals(type_Left,null));
  Debug.Assert(!Object.ReferenceEquals(type_Right,null));

  //[2021-02-12]
  Debug.Assert(type_Left  ==type_Left.Extension__SwitchToUnderlying());
  Debug.Assert(type_Right ==type_Right.Extension__SwitchToUnderlying());

  //----------------------------------------
  LcpiOleDb__ExpressionType
   nodeType2;

  if(!Core.Core_MapSysETypeToLcpiOleDbEType.TryMap(node.NodeType,out nodeType2))
  {
   ThrowError.LocalEvalErr__BinaryOperatorNotSupported
    (c_ErrSrcID,
     node.NodeType,
     type_Left,
     type_Right);
  }//if

  //----------------------------------------
  LcpiOleDb__LocalEval_Op2__Descr
   op2Descr
    =default;

  if(!m_ExpressionServices.TryGetOp2Descr(nodeType2,
                                          type_Left,
                                          type_Right,
                                          out op2Descr))
  {
   //ERROR - Binary operator not implemented

   ThrowError.LocalEvalErr__BinaryOperatorNotSupported
    (c_ErrSrcID,
     nodeType2,
     type_Left,
     type_Right);
  }//if

  Debug.Assert(!Object.ReferenceEquals(op2Descr.Translator,null));

  var translationData
   =new LcpiOleDb__LocalEval_BinaryTranslator.tagOpData
     (node_Left,
      node_Right,
      m_ExpressionServices);

  var r
   =op2Descr.Translator.Translate
     (translationData);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//VisitBinary

 //Helper methods --------------------------------------------------------
 private static T Helper__DetectMutation<T>
                   (string     bugCheckSrc,
                    T          originalExpression,
                    Expression newExpression)
  where T:Expression
 {
  Debug.Assert(!String.IsNullOrWhiteSpace(bugCheckSrc));
  Debug.Assert(!Object.ReferenceEquals(originalExpression,null));

  if(Object.ReferenceEquals(newExpression,null))
  {
   //ERROR - [BUG CHECK] Mutation

   ThrowBugCheck.LocalEvalErr__mutation__null_ptr_to_new_expression
    (c_ErrSrcID,
     bugCheckSrc,
     "#DM1",
     originalExpression);

   Debug.Assert(false);
  }//if

  Debug.Assert(!Object.ReferenceEquals(newExpression,null));

  if(originalExpression.GetType()!=newExpression.GetType())
  {
   //ERROR - [BUG CHECK] Mutation

   ThrowBugCheck.LocalEvalErr__mutation__changed_result_type_of_expression
    (c_ErrSrcID,
     bugCheckSrc,
     "#DM2",
     originalExpression,
     newExpression);

   Debug.Assert(false);
  }//if

  Debug.Assert(originalExpression.GetType()==newExpression.GetType());

  Debug.Assert(newExpression is T);

  if(originalExpression.NodeType!=newExpression.NodeType)
  {
   //ERROR - [BUG CHECK] Mutation

   ThrowBugCheck.LocalEvalErr__mutation__changed_node_type_of_expression
    (c_ErrSrcID,
     bugCheckSrc,
     "#DM3",
     originalExpression,
     newExpression);

   Debug.Assert(false);
  }//if

  Debug.Assert(originalExpression.NodeType==newExpression.NodeType);

  Debug.Assert(newExpression is T);

  return (T)newExpression;
 }//Helper__DetectMutation

 //Helper ----------------------------------------------------------------
 private static bool Helper__CanRemoveConvert(UnaryExpression unaryExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(unaryExpression,null));

  if(!unaryExpression.Extension__IsConvert2())
   return false;

  Debug.Assert(!Object.ReferenceEquals(unaryExpression.Type,null));
  Debug.Assert(!Object.ReferenceEquals(unaryExpression.Operand,null));
  Debug.Assert(!Object.ReferenceEquals(unaryExpression.Operand.Type,null));

  if(unaryExpression.Type==Structure.Structure_TypeCache.TypeOf__System_Object)
  {
   //Remove convert to object

   //Result of SQL Translator
   //return true;

   //Our decision at current time
   return false;
  }//if

  var innerType=unaryExpression.Operand.Type.Extension__GetUnderlyingValueType();

  var convertedType=unaryExpression.Type.Extension__GetUnderlyingValueType();

  //
  // SQL Translator rule:
  //
  // if(innerType==convertedType)
  // {
  //  return true;
  // }//if

  if(convertedType==Structure_TypeCache.TypeOf__System_Enum)
  {
   if(innerType==Structure_TypeCache.TypeOf__System_Byte   ||
      innerType==Structure_TypeCache.TypeOf__System_SByte  ||
      innerType==Structure_TypeCache.TypeOf__System_Int16  ||
      innerType==Structure_TypeCache.TypeOf__System_UInt16 ||
      innerType==Structure_TypeCache.TypeOf__System_Int32  ||
      innerType==Structure_TypeCache.TypeOf__System_UInt32 ||
      innerType==Structure_TypeCache.TypeOf__System_Int64  ||
      innerType==Structure_TypeCache.TypeOf__System_UInt64)
   {
    return true;
   }//if
  }
  else
  if(convertedType==Structure_TypeCache.TypeOf__System_Int32)
  {
   if(innerType==Structure_TypeCache.TypeOf__System_Byte   ||
      innerType==Structure_TypeCache.TypeOf__System_SByte  ||
      innerType==Structure_TypeCache.TypeOf__System_Char   ||
      innerType==Structure_TypeCache.TypeOf__System_Int16  ||
      innerType==Structure_TypeCache.TypeOf__System_UInt16 ||
      innerType==Structure_TypeCache.TypeOf__System_Int32)
   {
    return true;
   }//if
  }
  else
  if(convertedType==Structure_TypeCache.TypeOf__System_Int64)
  {
   //LcpiOleDb provider specific.

   if(innerType==Structure_TypeCache.TypeOf__System_Byte   ||
      innerType==Structure_TypeCache.TypeOf__System_SByte  ||
      innerType==Structure_TypeCache.TypeOf__System_Char   ||
      innerType==Structure_TypeCache.TypeOf__System_Int16  ||
      innerType==Structure_TypeCache.TypeOf__System_UInt16 ||
      innerType==Structure_TypeCache.TypeOf__System_Int32  ||
      innerType==Structure_TypeCache.TypeOf__System_UInt32 ||
      innerType==Structure_TypeCache.TypeOf__System_Int64)
   {
    return true;
   }//if
  }//if

  //
  // [2020-12-06] Save conversion to decimal:
  //
  // 7 / (decimal)2 == 3.5m
  // 7 / 2 == 3
  //

  return false;
 }//Helper__CanRemoveConvert

 //-----------------------------------------------------------------------
 private Expression Helper__RemoveConvert(UnaryExpression node)
 {
  Debug.Assert(!Object.ReferenceEquals(node,null));
  Debug.Assert(!Object.ReferenceEquals(node.Operand,null));

  Debug.Assert(node.Extension__IsConvert2());

  //----------------------------------------------------------------------
  const string c_bugcheck_src
   ="LcpiOleDb__LocalSvc__PrepareForLocalEvaluation::Helper__RemoveConvert";

  var translatedOperand
   =this.Visit(node.Operand);

  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#001",
    nameof(translatedOperand),
    translatedOperand);

  if(!Helper__NeedMakeNullabilityOfResultType(node.Type,translatedOperand.Type))
   return translatedOperand;

  //-------------------------------------------------- MAKE NULLABILITY
  var adjustedType_for_translatedOperand
   =translatedOperand.Type.MakeNullable(true);

  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#002",
    nameof(adjustedType_for_translatedOperand),
    adjustedType_for_translatedOperand);

  Debug.Assert(!Object.ReferenceEquals(adjustedType_for_translatedOperand,null));
  Debug.Assert(adjustedType_for_translatedOperand.Extension__IsNullableType());

  var adjusted_translatedOperand
   =Expression.Convert
     (translatedOperand,
      adjustedType_for_translatedOperand);

  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#003",
    nameof(adjusted_translatedOperand),
    adjusted_translatedOperand);

  Debug.Assert(!Object.ReferenceEquals(adjusted_translatedOperand,null));
  Debug.Assert(!Object.ReferenceEquals(adjusted_translatedOperand.Type,null));
  Debug.Assert(!Object.ReferenceEquals(adjusted_translatedOperand.Operand,null));

  Debug.Assert(adjusted_translatedOperand.Type==adjustedType_for_translatedOperand);

  Debug.Assert(Object.ReferenceEquals(adjusted_translatedOperand.Operand,translatedOperand));

  //-------------------------------------------------- GO HOME
  return adjusted_translatedOperand;
 }//Helper__RemoveConvert

 //-----------------------------------------------------------------------
 private static bool Helper__NeedMakeNullabilityOfResultType
                                        (System.Type expectedType,
                                         System.Type actualType)
 {
  Debug.Assert(!Object.ReferenceEquals(expectedType,null));
  Debug.Assert(!Object.ReferenceEquals(actualType,null));

  if(!expectedType.Extension__IsNullableType())
   return false;

  Debug.Assert(expectedType.Extension__IsNullableType());

  if(actualType.Extension__IsNullableType())
   return false;

  Debug.Assert(!actualType.Extension__IsNullableType());

  return true;
 }//Helper__NeedMakeNullabilityOfResultType

 //-----------------------------------------------------------------------
 private static MethodInfo Helper__GetSysCvtMethodToNative
                             (Expression  sourceExpression,
                              System.Type nativeType)
 {
  Debug.Assert(!Object.ReferenceEquals(sourceExpression,null));
  Debug.Assert(!Object.ReferenceEquals(nativeType,null));

  if(nativeType.IsArray)
  {
   var nativeElementType
    =nativeType.GetElementType();

   Debug.Assert(!Object.ReferenceEquals(nativeElementType,null));

   if(nativeElementType.Extension__IsNullableValueType())
   {
    var nativeElementType_u
     =System.Nullable.GetUnderlyingType(nativeElementType);

    Debug.Assert(!Object.ReferenceEquals(nativeElementType_u,null));

    return Helper__GetSysCvtMethodToNative__ArrayWithNullabilityValues
            (sourceExpression,
             nativeElementType_u);
   }//if

   return null;
  }//if nativeType.IsArray

  if(nativeType.Extension__IsInstanceOfGenericList())
  {
   return Helper__GetSysCvtMethodToNative__GenericContainer
           (Structure_TypeCache.TypeOf__LcpiEF__Core_ValueUtil__TransformatorOfGenericList,
            Structure_TypeCache.TypeOf__LcpiEF__Core_ValueUtil__TransformatorOfGenericListWithNullabilityValues,
            sourceExpression,
            nativeType);
  }//if nativeType.Extension__IsInstanceOfGenericList()

  if(nativeType.Extension__IsInstanceOfGenericEnumerable())
  {
   return Helper__GetSysCvtMethodToNative__GenericContainer
           (Structure_TypeCache.TypeOf__LcpiEF__Core_ValueUtil__TransformatorOfGenericEnumerable,
            Structure_TypeCache.TypeOf__LcpiEF__Core_ValueUtil__TransformatorOfGenericEnumerableWithNullabilityValues,
            sourceExpression,
            nativeType);
  }//if nativeType.Extension__IsInstanceOfGenericEnumerable()

  return null;
 }//Helper__GetSysCvtMethodToNative

 //-----------------------------------------------------------------------
 private static MethodInfo Helper__GetSysCvtMethodToNative__ArrayWithNullabilityValues
                             (Expression  sourceExpression,
                              System.Type nativeElementType_u)
 {
  Debug.Assert(!Object.ReferenceEquals(sourceExpression,null));
  Debug.Assert(!Object.ReferenceEquals(sourceExpression.Type,null));
  Debug.Assert(sourceExpression.Type.IsArray);
  Debug.Assert(!Object.ReferenceEquals(sourceExpression.Type.GetElementType(),null));
  Debug.Assert(sourceExpression.Type.GetElementType().Extension__IsNullableValueType());

  Debug.Assert(!Object.ReferenceEquals(nativeElementType_u,null));

  var sourceElementType_u
   =Nullable.GetUnderlyingType(sourceExpression.Type.GetElementType());

  Debug.Assert(!Object.ReferenceEquals(nativeElementType_u,null));

  //Expected
  Debug.Assert(sourceElementType_u.IsEnum);
  Debug.Assert(System.Enum.GetUnderlyingType(sourceElementType_u)==nativeElementType_u);

  //-------------------------------------------------------
  var cvtWorker_type_g
   =Structure_TypeCache.TypeOf__LcpiEF__Core_ValueUtil__TransformatorOfArrayWithNullabilityValues;

  Debug.Assert(!Object.ReferenceEquals(cvtWorker_type_g,null));

  //Parameters for Core_ValueUtil__TransformatorOfArrayWithNullabilityValues
  System.Type[]
   cvtWorker_types
    =new System.Type[]
      {
       sourceElementType_u,
       nativeElementType_u,
      };

  var cvtWorker_type
   =cvtWorker_type_g.MakeGenericType
     (cvtWorker_types);

  Debug.Assert(!Object.ReferenceEquals(cvtWorker_type,null));

  var cvtMethod
   =cvtWorker_type.Extension__GetRuntimeMethod
     ("Exec",
      new System.Type[]
      {
       sourceExpression.Type
      });

  Debug.Assert(!Object.ReferenceEquals(cvtMethod,null));

  return cvtMethod;
 }//Helper__GetSysCvtMethodToNative__ArrayWithNullabilityValues

 //-----------------------------------------------------------------------
 private static MethodInfo Helper__GetSysCvtMethodToNative__GenericContainer
                             (System.Type genericTransformatorForDirectValues_2,
                              System.Type genericTransformatorForNullabilityValues_2,
                              Expression  sourceExpression,
                              System.Type nativeType)
 {
  Debug.Assert(!Object.ReferenceEquals(genericTransformatorForDirectValues_2,null));
  Debug.Assert(!Object.ReferenceEquals(genericTransformatorForNullabilityValues_2,null));
  Debug.Assert(!Object.ReferenceEquals(sourceExpression,null));
  Debug.Assert(!Object.ReferenceEquals(sourceExpression.Type,null));
  Debug.Assert(sourceExpression.Type.IsGenericType);
  Debug.Assert(!sourceExpression.Type.IsGenericTypeDefinition);

  Debug.Assert(!Object.ReferenceEquals(nativeType,null));
  Debug.Assert(nativeType.IsGenericType);
  Debug.Assert(!nativeType.IsGenericTypeDefinition);

  var nativeType_Args
   =nativeType.GetGenericArguments();

  Debug.Assert(!Object.ReferenceEquals(nativeType_Args,null));

  Debug.Assert(nativeType_Args.Length==1);

  Debug.Assert(!Object.ReferenceEquals(nativeType_Args[0],null));

  var nativeElementType
   =nativeType_Args[0];

  Debug.Assert(!Object.ReferenceEquals(nativeElementType,null));

  if(nativeElementType.IsNullableValueType())
  {
   return Helper__GetSysCvtMethodToNative__GenericContainerWithNullabilityValues
           (genericTransformatorForNullabilityValues_2,
            sourceExpression,
            nativeElementType);
  }//if
  
  return Helper__GetSysCvtMethodToNative__GenericContainerWithDirectValues
           (genericTransformatorForDirectValues_2,
            sourceExpression,
            nativeElementType);
 }//Helper__GetSysCvtMethodToNative__GenericContainer

 //-----------------------------------------------------------------------
 private static MethodInfo Helper__GetSysCvtMethodToNative__GenericContainerWithDirectValues
                             (System.Type genericTransformator_2,
                              Expression  sourceExpression,
                              System.Type nativeElementType)
 {
  Debug.Assert(!Object.ReferenceEquals(genericTransformator_2,null));
  Debug.Assert(!Object.ReferenceEquals(sourceExpression,null));
  Debug.Assert(!Object.ReferenceEquals(sourceExpression.Type,null));
  Debug.Assert(sourceExpression.Type.IsGenericType);
  Debug.Assert(!sourceExpression.Type.IsGenericTypeDefinition);

  Debug.Assert(!Object.ReferenceEquals(nativeElementType,null));

  //Expected

  //-------------------------------------------------------
  var sourceType
   =sourceExpression.Type;

  Debug.Assert(!Object.ReferenceEquals(sourceType,null));
  Debug.Assert(sourceType.IsGenericType);
  Debug.Assert(!sourceType.IsGenericTypeDefinition);
  //Debug.Assert(sourceType.GetGenericTypeDefinition()==Structure_TypeCache.TypeOf__System_Collection_Generic_List);

  var sourceType_Args
   =sourceType.GetGenericArguments();

  Debug.Assert(!Object.ReferenceEquals(sourceType_Args,null));
  Debug.Assert(sourceType_Args.Length==1);
  Debug.Assert(!Object.ReferenceEquals(sourceType_Args[0],null));

  var sourceElementType
   =sourceType_Args[0];

  Debug.Assert(!Object.ReferenceEquals(sourceElementType,null));

  //-------------------------------------------------------
  var cvtWorker_type_g
   =genericTransformator_2;

  Debug.Assert(!Object.ReferenceEquals(cvtWorker_type_g,null));

  //Parameters for genericTransformator_2
  System.Type[]
   cvtWorker_types
    =new System.Type[]
      {
       sourceElementType,
       nativeElementType,
      };

  var cvtWorker_type
   =cvtWorker_type_g.MakeGenericType
     (cvtWorker_types);

  Debug.Assert(!Object.ReferenceEquals(cvtWorker_type,null));

  var cvtMethod
   =cvtWorker_type.Extension__GetRuntimeMethod
     ("Exec",
      new System.Type[]
      {
       sourceExpression.Type
      });

  Debug.Assert(!Object.ReferenceEquals(cvtMethod,null));

  return cvtMethod;
 }//Helper__GetSysCvtMethodToNative__GenericContainerWithDirectValues

 //-----------------------------------------------------------------------
 private static MethodInfo Helper__GetSysCvtMethodToNative__GenericContainerWithNullabilityValues
                             (System.Type genericTransformator_2,
                              Expression  sourceExpression,
                              System.Type nativeElementType)
 {
  Debug.Assert(!Object.ReferenceEquals(genericTransformator_2,null));
  Debug.Assert(!Object.ReferenceEquals(sourceExpression,null));
  Debug.Assert(!Object.ReferenceEquals(sourceExpression.Type,null));
  Debug.Assert(sourceExpression.Type.IsGenericType);
  Debug.Assert(!sourceExpression.Type.IsGenericTypeDefinition);

  Debug.Assert(!Object.ReferenceEquals(nativeElementType,null));
  Debug.Assert(nativeElementType.Extension__IsNullableValueType());

  //Expected

  //-------------------------------------------------------
  var sourceType
   =sourceExpression.Type;

  Debug.Assert(!Object.ReferenceEquals(sourceType,null));
  Debug.Assert(sourceType.IsGenericType);
  Debug.Assert(!sourceType.IsGenericTypeDefinition);
  //Debug.Assert(sourceType.GetGenericTypeDefinition()==Structure_TypeCache.TypeOf__System_Collection_Generic_IEnumerable);

  var sourceType_Args
   =sourceType.GetGenericArguments();

  Debug.Assert(!Object.ReferenceEquals(sourceType_Args,null));
  Debug.Assert(sourceType_Args.Length==1);
  Debug.Assert(!Object.ReferenceEquals(sourceType_Args[0],null));

  var sourceElementType
   =sourceType_Args[0];

  Debug.Assert(!Object.ReferenceEquals(sourceElementType,null));
  Debug.Assert(sourceElementType.Extension__IsNullableValueType());

  var sourceElementType_u
   =System.Nullable.GetUnderlyingType(sourceElementType);

  Debug.Assert(!Object.ReferenceEquals(sourceElementType_u,null));

  //-------------------------------------------------------
  var nativeElementType_u
   =System.Nullable.GetUnderlyingType(nativeElementType);

  Debug.Assert(!Object.ReferenceEquals(nativeElementType_u,null));

  //-------------------------------------------------------
  var cvtWorker_type_g
   =genericTransformator_2;

  Debug.Assert(!Object.ReferenceEquals(cvtWorker_type_g,null));

  //Parameters for genericTransformator_2
  System.Type[]
   cvtWorker_types
    =new System.Type[]
      {
       sourceElementType_u,
       nativeElementType_u,
      };

  var cvtWorker_type
   =cvtWorker_type_g.MakeGenericType
     (cvtWorker_types);

  Debug.Assert(!Object.ReferenceEquals(cvtWorker_type,null));

  var cvtMethod
   =cvtWorker_type.Extension__GetRuntimeMethod
     ("Exec",
      new System.Type[]
      {
       sourceExpression.Type
      });

  Debug.Assert(!Object.ReferenceEquals(cvtMethod,null));

  return cvtMethod;
 }//Helper__GetSysCvtMethodToNative__GenericContainerWithNullabilityValues

 //private data ----------------------------------------------------------
 private readonly LcpiOleDb__LocalEval_Services
  m_ExpressionServices;

 //-----------------------------------------------------------------------
 private readonly LcpiOleDb__LocalEval_MemberTranslators
  m_MemberTranslators;

 //-----------------------------------------------------------------------
 private readonly bool
  m_ExecutionOfUnknownMethods;
};//class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Svcs
