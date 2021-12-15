////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 31.08.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.SQL{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MethodId
 =Structure.Structure_MethodId;

using Structure_MethodParameterDescr
 =Structure.Structure_MethodParameterDescr;

using Structure_MethodFlags
 =Structure.Structure_MethodFlags;

using Structure_ReflectionUtils
 =Structure.Structure_ReflectionUtils;

////////////////////////////////////////////////////////////////////////////////
//class Core_SQL__MethodIdBuilder

static class Core_SQL__MethodIdBuilder
{
 public static Structure_MethodId Create(MethodInfo                   originalMethodInfo,
                                         SqlExpression                instance,
                                         IReadOnlyList<SqlExpression> arguments)
 {
  Debug.Assert(!Object.ReferenceEquals(originalMethodInfo,null));
  Debug.Assert(!Object.ReferenceEquals(arguments,null));

  //---------------- ObjectType
  var objectType
   =Helper__MakeObjectType
     (instance,
      originalMethodInfo);

  Debug.Assert(!Object.ReferenceEquals(objectType,null));

  //---------------- MethodName
  var methodName
   =originalMethodInfo.Name;

  Debug.Assert(!string.IsNullOrWhiteSpace(methodName));

  //---------------- Parameters
  var parameters
   =new Structure_MethodParameterDescr[arguments.Count];

  for(int i=0,_c=arguments.Count;i!=_c;++i)
  {
   Debug.Assert(!Object.ReferenceEquals(arguments[i],null));
   Debug.Assert(!Object.ReferenceEquals(arguments[i].Type,null));

   var sqlParameterType
    =arguments[i].Type.Extension__SwitchToUnderlying();

   Debug.Assert(!Object.ReferenceEquals(sqlParameterType,null));

   parameters[i]
    =Structure_MethodParameterDescr.Create
      (sqlParameterType);

   Debug.Assert(!Object.ReferenceEquals(parameters[i],null));
  }//for i

  //---------------- MethodFlags
  Structure_MethodFlags
   methodFlags
    =0;

  if(!Object.ReferenceEquals(instance,null))
  {
   Debug.Assert(!Structure_ReflectionUtils.IsExtensionMethod(originalMethodInfo));
  }
  else
  {
   Debug.Assert(originalMethodInfo.IsStatic);

   methodFlags|=Structure_MethodFlags.IsStatic;

   if(Structure_ReflectionUtils.IsExtensionMethod(originalMethodInfo))
    methodFlags|=Structure_MethodFlags.IsExtension;
  }//else

  //----------------
  var result
   =new Structure_MethodId
     (objectType,
      methodName,
      parameters,
      methodFlags);

  return result;
 }//Create

 //Helper methods --------------------------------------------------------
 private static System.Type Helper__MakeObjectType(SqlExpression instance,
                                                   MethodInfo    methodInfo)
 {
  Debug.Assert(!Object.ReferenceEquals(methodInfo,null));
  Debug.Assert(!Object.ReferenceEquals(methodInfo.DeclaringType,null));

  //----------------
  System.Type objectType;

  if(Object.ReferenceEquals(instance,null))
  {
   objectType=methodInfo.DeclaringType;
  }
  else
  if(methodInfo.DeclaringType.Extension__IsNullableType())
  {
   Debug.Assert(!Object.ReferenceEquals(instance,null));
   Debug.Assert(!Object.ReferenceEquals(instance.Type,null));

   objectType=instance.Type.MakeNullable(true);
  }
  else
  {
   Debug.Assert(!Object.ReferenceEquals(instance,null));
   Debug.Assert(!Object.ReferenceEquals(instance.Type,null));

   objectType=instance.Type;
  }//else

  Debug.Assert(!Object.ReferenceEquals(objectType,null));

  //
  // [2021-08-31]
  //
  //  Switch to underlying SQL type
  //
  var objectType2
   =objectType.Extension__SwitchToUnderlying();

  Debug.Assert(!Object.ReferenceEquals(objectType2,null));

  return objectType2;
 }//Helper__MakeObjectType
};//class Core_SQL__MethodIdBuilder

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.SQL
