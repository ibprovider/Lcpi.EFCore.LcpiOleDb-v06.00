////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.06.2021.
using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_SwitchToUnderlying

static class Structure_SwitchToUnderlying
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Structure_SwitchToUnderlying;

 //-----------------------------------------------------------------------
 public static MethodInfo Exec(MethodInfo originalMethod)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethod,null));
  Debug.Assert(!Object.ReferenceEquals(originalMethod.DeclaringType,null));

  //---------------------------------------- GENERIC
  if(!originalMethod.IsGenericMethod)
   return Helper__Exec__NORMAL(originalMethod);

  //Expected!
  Debug.Assert(!originalMethod.IsGenericMethodDefinition);

  return Helper__Exec__GENERIC(originalMethod);
 }//Exec

 //Helper methods --------------------------------------------------------
 private static MethodInfo Helper__Exec__NORMAL(MethodInfo originalMethod)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethod,null));
  Debug.Assert(!Object.ReferenceEquals(originalMethod.DeclaringType,null));
  Debug.Assert(!originalMethod.IsGenericMethod);

  //---------------------------------------- DECLARING TYPE
  var new_DeclaringType
   =originalMethod.DeclaringType.Extension__SwitchToUnderlying();

  //---------------------------------------- PARAMETERS
  var originalMethod_Parameters
   =originalMethod.GetParameters();

  Debug.Assert(!Object.ReferenceEquals(originalMethod_Parameters,null));

  var new_ParameterTypes
   =Helper__SwitchTypes(originalMethod_Parameters);

  Debug.Assert(!Object.ReferenceEquals(originalMethod_Parameters,null));

  //----------------------------------------
  //
  // Simple create a remapped method.
  //

  var new_MethodInfo
   =new_DeclaringType.GetRuntimeMethod
     (originalMethod.Name,
      new_ParameterTypes);

  for(;;)
  {
   if(Object.ReferenceEquals(new_MethodInfo,null))
    break;

   Debug.Assert(new_MethodInfo.Name==originalMethod.Name);

   if(new_MethodInfo.IsStatic!=originalMethod.IsStatic)
    break;

   return new_MethodInfo;
  }//for[ever]

  ThrowError.CantRemapNormalMethodCall
   (c_ErrSrcID,
    originalMethod,
    new_DeclaringType,
    new_ParameterTypes);

  Debug.Assert(false);

  return null;
 }//Helper__Exec__NORMAL

 //-----------------------------------------------------------------------
 private static MethodInfo Helper__Exec__GENERIC(MethodInfo originalMethod)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethod,null));
  Debug.Assert(!Object.ReferenceEquals(originalMethod.DeclaringType,null));
  Debug.Assert(originalMethod.IsGenericMethod);
  Debug.Assert(!originalMethod.IsGenericMethodDefinition);

  //---------------------------------------- GENERIC ARGS
  var originalMethod_g
   =originalMethod.GetGenericMethodDefinition();

  Debug.Assert(!Object.ReferenceEquals(originalMethod_g,null));

  var genericArgs
   =originalMethod.GetGenericArguments();

  Debug.Assert(!Object.ReferenceEquals(genericArgs,null));

  var genericArgs_u
   =new System.Type[genericArgs.Length];

  for(int i=0,_c=genericArgs.Length;i!=_c;++i)
  {
   Debug.Assert(!Object.ReferenceEquals(genericArgs[i],null));

   genericArgs_u[i]
    =genericArgs[i].Extension__SwitchToUnderlying();

   Debug.Assert(!Object.ReferenceEquals(genericArgs_u[i],null));
  }//for

  var originalMethod2
   =originalMethod_g.MakeGenericMethod(genericArgs_u);

  Debug.Assert(!Object.ReferenceEquals(originalMethod2,null));

  //---------------------------------------- DECLARING TYPE
  var new_DeclaringType
   =originalMethod2.DeclaringType.Extension__SwitchToUnderlying();

  //---------------------------------------- PARAMETERS
  var originalMethod2_Parameters
   =originalMethod2.GetParameters();

  Debug.Assert(!Object.ReferenceEquals(originalMethod2_Parameters,null));

  var new_ParameterTypes
   =Helper__SwitchTypes(originalMethod2_Parameters);

  Debug.Assert(!Object.ReferenceEquals(originalMethod2_Parameters,null));

  //----------------------------------------------------------------------
  //
  // Find in new_DeclaringType a generic method with
  //  1. originalMethod_g.GetGenericArguments()
  //  2. new_ParameterTypes
  //

  var originalMethod_g__genericArgs
   =originalMethod_g.GetGenericArguments();

  Debug.Assert(!Object.ReferenceEquals(originalMethod_g__genericArgs,null));

  var new_DeclaringType_Methods
   =new_DeclaringType.GetMethods();

  Debug.Assert(!Object.ReferenceEquals(new_DeclaringType_Methods,null));

  foreach(var x in new_DeclaringType_Methods)
  {
   if(x.DeclaringType!=new_DeclaringType)
    continue;

   if(x.Name!=originalMethod2.Name)
    continue;

   if(x.IsStatic!=originalMethod.IsStatic)
    continue;

   if(!x.IsGenericMethod)
    continue;

   Debug.Assert(x.IsGenericMethod);
   Debug.Assert(x.IsGenericMethodDefinition);

   if(x.GetGenericArguments().Length!=originalMethod_g__genericArgs.Length)
    continue;

   MethodInfo x2;

   try
   {
    //
    // WILL TRY. MAY FAIL.
    //
    x2=x.MakeGenericMethod(genericArgs_u);
   }
   catch(ArgumentException)
   {
#if TRACE
    Core.Core_Trace.Send("EXC: ArgumentException. Can't MakeGenericMethod");
#endif

    continue;
   }//catch
   catch(NotSupportedException)
   {
#if TRACE
    Core.Core_Trace.Send("EXC: NotSupportedException. Can't MakeGenericMethod");
#endif

    continue;
   }//catch

   Debug.Assert(!Object.ReferenceEquals(x2,null));

   var x2_Parameters
    =x2.GetParameters();

   Debug.Assert(!Object.ReferenceEquals(x2_Parameters,null));

   if(!Helper__EqualSequences(x2_Parameters,new_ParameterTypes))
    continue;

   //OK, FOUND IT!

   return x2;
  }//foreach x

  ThrowError.CantRemapGenericMethodCall
   (c_ErrSrcID,
    originalMethod,
    new_DeclaringType,
    new_ParameterTypes,
    genericArgs_u);

  Debug.Assert(false);

  return null;
 }//Helper__Exec__GENERIC

 //-----------------------------------------------------------------------
 private static bool Helper__EqualSequences(ParameterInfo[] paramArray,System.Type[] typeArray)
 {
  Debug.Assert(!Object.ReferenceEquals(paramArray,null));
  Debug.Assert(!Object.ReferenceEquals(typeArray,null));

  if(paramArray.Length!=typeArray.Length)
   return false;

  for(int i=0,_c=paramArray.Length;i!=_c;++i)
  {
   var p=paramArray[i];
   var t=typeArray[i];

   Debug.Assert(!Object.ReferenceEquals(p,null));
   Debug.Assert(!Object.ReferenceEquals(t,null));

   if(p.ParameterType!=t)
    return false;
  }//for i

  return true;
 }//Helper__EqualSequences

 //-----------------------------------------------------------------------
 private static System.Type[] Helper__SwitchTypes(ParameterInfo[] paramArray)
 {
  Debug.Assert(!Object.ReferenceEquals(paramArray,null));

  System.Type[] new_ParameterTypes
   =new System.Type[paramArray.Length];

  Debug.Assert(!Object.ReferenceEquals(paramArray,null));

  for(int i=0,_c=paramArray.Length;i!=_c;++i)
  {
   var originalParameter
    =paramArray[i];

   Debug.Assert(!Object.ReferenceEquals(originalParameter,null));

   var originalParameter_Type
    =originalParameter.ParameterType;

   Debug.Assert(!Object.ReferenceEquals(originalParameter_Type,null));

   var new_ParameterType
    =originalParameter_Type.Extension__SwitchToUnderlying();

   Debug.Assert(!Object.ReferenceEquals(new_ParameterType,null));

   new_ParameterTypes[i]
    =new_ParameterType;
  }//for i

  return new_ParameterTypes;
 }//Helper__SwitchTypes
};//class Structure_SwitchToUnderlying

////////////////////////////////////////////////////////////////////////////////
}//Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
