////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 05.09.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__Extensions__Type

static partial class LcpiOleDb__Extensions__Type
{
 public static Type Extension__SwitchToUnderlying(this Type type)
 {
  Debug.Assert(!Object.ReferenceEquals(type,null));

  var valueType
   =Extension__UnwrapNullableType(type);

  Debug.Assert(!Object.ReferenceEquals(valueType,null));

  if(valueType.IsArray)
  {
   // [2021-06-09] When this assert will triggered, kill me.
   Debug.Assert(valueType.GetArrayRank()==1);

   var elementType
    =valueType.GetElementType();

   Debug.Assert(!Object.ReferenceEquals(elementType,null));

   var elementType_u
    =elementType.Extension__SwitchToUnderlying();

   Debug.Assert(!Object.ReferenceEquals(elementType_u,null));

   valueType
    =elementType_u.MakeArrayType();
  }
  else
  if(valueType.IsEnum)
  {
   valueType=System.Enum.GetUnderlyingType(valueType);
  }//if
  else
  if(valueType.IsGenericType)
  {
   //Expected!
   Debug.Assert(!valueType.IsGenericTypeDefinition);

   var valueType_g
    =valueType.GetGenericTypeDefinition();

   Debug.Assert(!Object.ReferenceEquals(valueType_g,null));

   var genericArgs
    =valueType.GetGenericArguments();

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

   valueType
    =valueType_g.MakeGenericType(genericArgs_u);

   Debug.Assert(!Object.ReferenceEquals(valueType,null));
  }//if valueType.IsGenericType

  Debug.Assert(!Object.ReferenceEquals(valueType,null));

  //----------------------------------------
  if(!Extension__IsNullableType(type))
   return valueType;

  if(Extension__IsNullableType(valueType))
   return valueType;

  var nullableType
   =Structure.Structure_TypeCache.TypeOf__System_Nullable.MakeGenericType
     (valueType);

  Debug.Assert(!Object.ReferenceEquals(nullableType,null));

  return nullableType;
 }//Extension__SwitchToUnderlying
};//class LcpiOleDb__Extensions__Type

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb
