////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.05.2018.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__Extensions__Type

static partial class LcpiOleDb__Extensions__Type
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__Extensions__Type;

 //-----------------------------------------------------------------------
 public static MethodInfo Extension__GetRuntimeMethod
                           (this Type type,
                            string    name,
                            Type[]    parameters)
 {
  Debug.Assert(!Object.ReferenceEquals(type,null));
  Debug.Assert(!Object.ReferenceEquals(name,null));
  Debug.Assert(!Object.ReferenceEquals(parameters,null));

  Debug.Assert(name.Length>0);
  Debug.Assert(name.Trim()==name);

#if DEBUG
  for(int i=0;i!=parameters.Length;++i)
   Debug.Assert(!Object.ReferenceEquals(parameters[i],null));
#endif

  var resultMethodInfo
   =type.GetRuntimeMethod
     (name,
      parameters);

  if(Object.ReferenceEquals(resultMethodInfo,null))
  {
   ThrowError.MethodNotSupported
    (c_ErrSrcID,
     type,
     name,
     parameters);
  }//if

  Debug.Assert(!Object.ReferenceEquals(resultMethodInfo,null));

  return resultMethodInfo;
 }//Extension__GetRuntimeMethod

 //-----------------------------------------------------------------------
 public static MethodInfo Extension__BindToTypeMethod
                            (this Type    type,
                             string       name,
                             Type         returnType, //may be null
                             Type[]       parameters,
                             BindingFlags bindFlags)
 {
  Debug.Assert(!Object.ReferenceEquals(type,null));

#if DEBUG
  if(!Object.ReferenceEquals(type,null))
  {
   for(int i=0;i!=parameters.Length;++i)
    Debug.Assert(!Object.ReferenceEquals(parameters[i],null));
  }//if
#endif

  var methodInfo
   =type.GetMethod
     (name,
      bindFlags,
      null,
      parameters, //special tests
      null);

  if(Object.ReferenceEquals(methodInfo,null))
  {
   ThrowBugCheck.BindToTypeMethod__NotFound
    (c_ErrSrcID,
     type,
     name,
     parameters,
     bindFlags);
  }//if

  //----------------------------------------------------------------------
  Debug.Assert(!Object.ReferenceEquals(methodInfo,null));

#if DEBUG
  {
   var debug__actualParameters=methodInfo.GetParameters();

   if(Object.ReferenceEquals(parameters,null))
   {
    //[2020-11-25] Research
    Debug.Assert(Object.ReferenceEquals(debug__actualParameters,null));
   }
   else
   {
    Debug.Assert(!Object.ReferenceEquals(parameters,null));
    Debug.Assert(!Object.ReferenceEquals(debug__actualParameters,null));

    Debug.Assert(parameters.Length==debug__actualParameters.Length);

    for(int i=0;i!=parameters.Length;++i)
    {
     Debug.Assert(!Object.ReferenceEquals(debug__actualParameters[i],null));
     Debug.Assert(!Object.ReferenceEquals(debug__actualParameters[i].ParameterType,null));

     Debug.Assert(parameters[i]==debug__actualParameters[i].ParameterType);
    }//for i
   }//if
  }//local
#endif

  //----------------------------------------------------------------------
  if(methodInfo.ReturnType!=returnType)
  {
   ThrowBugCheck.BindToTypeMethod__BadReturnType
    (c_ErrSrcID,
     type,
     name,
     parameters,
     bindFlags,
     /*expected*/returnType,
     /*actual*/methodInfo.ReturnType);
  }//if

  Debug.Assert(!Object.ReferenceEquals(methodInfo,null));

  return methodInfo;
 }//Extension__BindToTypeMethod

 //-----------------------------------------------------------------------
 public static System.Type Extension__GetNestedType(this System.Type type,
                                                    string           name,
                                                    BindingFlags     bindFlags)
 {
  Debug.Assert(!Object.ReferenceEquals(type,null));
  Debug.Assert(!Object.ReferenceEquals(name,null));
  Debug.Assert(name.Length>0);
  Debug.Assert(name.Trim()==name);

  var nestedType
   =type.GetNestedType
     (name,
      bindFlags);

  if(Object.ReferenceEquals(nestedType,null))
  {
   ThrowBugCheck.GetNestedType__NotFound
    (c_ErrSrcID,
     type,
     name,
     bindFlags);
  }//if

  Debug.Assert(!Object.ReferenceEquals(nestedType,null));

  return nestedType;
 }//Extension__GetNestedType

 //-----------------------------------------------------------------------
 public static Type Extension__GetUnderlyingValueType(this Type type)
 {
  // [2020-10-13] Tested.

  Debug.Assert(!Object.ReferenceEquals(type,null));

  type=type.Extension__UnwrapNullableType();

  Debug.Assert(!Object.ReferenceEquals(type,null));

  if(type.IsEnum)
   type=System.Enum.GetUnderlyingType(type);

  Debug.Assert(!Object.ReferenceEquals(type,null));

  return type;
 }//Extension__GetUnderlyingValueType

 //-----------------------------------------------------------------------
 public static Type Extension__UnwrapMappingClrType(this Type ClrType)
 {
  // [2020-11-30] Tested.

  Debug.Assert(!Object.ReferenceEquals(ClrType,null));

  //Expected!
  Debug.Assert(ClrType==ClrType.Extension__UnwrapNullableType());

  if(ClrType.IsEnum)
   ClrType=System.Enum.GetUnderlyingType(ClrType);

  Debug.Assert(!Object.ReferenceEquals(ClrType,null));

  return ClrType;
 }//Extension__UnwrapMappingClrType

 //-----------------------------------------------------------------------
 public static Type Extension__UnwrapNullableType(this Type type)
 {
  // [2020-10-13] Tested.

  Debug.Assert(!Object.ReferenceEquals(type,null));

  var r=Nullable.GetUnderlyingType(type);

  if(!Object.ReferenceEquals(r,null))
   return r;

  return type;
 }//Extension__UnwrapNullableType

 //-----------------------------------------------------------------------
 public static bool Extension__IsNullableValueType(this Type type)
 {
  if(!type.IsConstructedGenericType)
   return false;

  if(type.GetGenericTypeDefinition()!=Structure_TypeCache.TypeOf__System_Nullable)
   return false;

  Debug.Assert(type.IsValueType);

  return true;
 }//Extension__IsNullableValueType

 //-----------------------------------------------------------------------
 public static bool Extension__IsNullableType(this Type type)
 {
  //! \todo [2021-06-07] I offer to rename this method to Extension__IsNullableDataType

  Debug.Assert(!Object.ReferenceEquals(type,null));

  //
  // [2021-06-06] typeof(Enum).IsValueType==false
  //
  if(type==Structure_TypeCache.TypeOf__System_Enum)
   return false;

  if(!type.IsValueType)
   return true;

  if(Extension__IsNullableValueType(type))
   return true;

  return false;
 }//Extension__IsNullableType

 //-----------------------------------------------------------------------
 public static bool Extension__IsInstanceOfGenericList(this Type type) 
 {
  Debug.Assert(!Object.ReferenceEquals(type,null));

  return Helper__IsInstanceOfGeneric
          (type,
           Structure_TypeCache.TypeOf__System_Collection_Generic_List);
 }//Extension__IsInstanceOfGenericList

 //-----------------------------------------------------------------------
 public static bool Extension__IsInstanceOfGenericEnumerable(this Type type) 
 {
  Debug.Assert(!Object.ReferenceEquals(type,null));

  return Helper__IsInstanceOfGeneric
          (type,
           Structure_TypeCache.TypeOf__System_Collection_Generic_IEnumerable);
 }//Extension__IsInstanceOfGenericEnumerable

 //-----------------------------------------------------------------------
 private static bool Helper__IsInstanceOfGeneric(System.Type testType,
                                                 System.Type genericType)
 {
  Debug.Assert(!Object.ReferenceEquals(testType,null));

  Debug.Assert(!Object.ReferenceEquals(genericType,null));
  Debug.Assert(genericType.IsGenericType);
  Debug.Assert(genericType.IsGenericTypeDefinition);

  if(!testType.IsGenericType)
   return false;

  if(testType.IsGenericTypeDefinition)
   return false;

  var testType_g
   =testType.GetGenericTypeDefinition();

  Debug.Assert(!Object.ReferenceEquals(testType_g,null));

  if(testType_g==genericType)
   return true;

  return false;
 }//Helper__IsInstanceOfGeneric

 //-----------------------------------------------------------------------
 //public static Type MakeNullable(this Type type)
 //    => type.IsNullableType()
 //        ? type
 //        : typeof(Nullable<>).MakeGenericType(type);

 //-----------------------------------------------------------------------
 public static bool Extension__IsInteger__Exact(this Type type)
 {
  // [2020-10-13] Tested.

  Debug.Assert(!Object.ReferenceEquals(type,null));

  type=type.Extension__UnwrapNullableType();

  Debug.Assert(!Object.ReferenceEquals(type,null));

  //---------------------
  if(type==Structure_TypeCache.TypeOf__System_SByte)
   return true;

  if(type==Structure_TypeCache.TypeOf__System_Int16)
   return true;

  if(type==Structure_TypeCache.TypeOf__System_Int32)
   return true;

  if(type==Structure_TypeCache.TypeOf__System_Int64)
   return true;

  //---------------------
  if(type==Structure_TypeCache.TypeOf__System_Byte)
   return true;

  if(type==Structure_TypeCache.TypeOf__System_UInt16)
   return true;

  if(type==Structure_TypeCache.TypeOf__System_UInt32)
   return true;

  if(type==Structure_TypeCache.TypeOf__System_UInt64)
   return true;

  //---------------------
  return false;
 }//Extension__IsInteger__Exact

 //-----------------------------------------------------------------------
 // public static bool IsIntegerForIdentity(this Type type)
 // {
 //  type = type.UnwrapNullableType();
 //
 //  return (type == typeof(int))
 //         || (type == typeof(long));
 // }

 //-----------------------------------------------------------------------
 // public static Type UnwrapEnumType(this Type type)
 // {
 //  var isNullable = type.IsNullableType();
 //
 //  type = isNullable ? type.UnwrapNullableType() : type;
 //
 //  var underlyingEnumType = type.GetTypeInfo().IsEnum ? Enum.GetUnderlyingType(type) : type;
 //
 //  return isNullable ? MakeNullable(underlyingEnumType) : underlyingEnumType;
 // }

 //-----------------------------------------------------------------------
 // public static Type TryGetElementType(this Type type, Type interfaceOrBaseType)
 // {
 //  if (!type.GetTypeInfo().IsGenericTypeDefinition)
 //  {
 //   var types = GetGenericTypeImplementations(type, interfaceOrBaseType).ToArray();
 //
 //   return types.Length == 1 ? types[0].GetTypeInfo().GenericTypeArguments.FirstOrDefault() : null;
 //  }
 //
 //  return null;
 // }

 //-----------------------------------------------------------------------
 // public static IEnumerable<Type> GetGenericTypeImplementations(this Type type, Type interfaceOrBaseType)
 // {
 //  var typeInfo = type.GetTypeInfo();
 //
 //  if (!typeInfo.IsGenericTypeDefinition)
 //  {
 //   return (interfaceOrBaseType.GetTypeInfo().IsInterface ? typeInfo.ImplementedInterfaces : type.GetBaseTypes())
 //       .Union(new[] { type })
 //       .Where(
 //           t => t.GetTypeInfo().IsGenericType
 //                && (t.GetGenericTypeDefinition() == interfaceOrBaseType));
 //  }
 //
 //  return Enumerable.Empty<Type>();
 // }

 //-----------------------------------------------------------------------
 // public static IEnumerable<Type> GetBaseTypes(this Type type)
 // {
 //  type = type.GetTypeInfo().BaseType;
 //
 //  while (type != null)
 //  {
 //   yield return type;
 //
 //   type = type.GetTypeInfo().BaseType;
 //  }
 // }//GetBaseTypes
};//class LcpiOleDb__Extensions__Type

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb
