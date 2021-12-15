////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 31.08.2021.
using System;
using System.Diagnostics;
using System.Reflection;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.SQL{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MemberId
 =Structure.Structure_MemberId;

////////////////////////////////////////////////////////////////////////////////
//class Core_SQL__MemberIdBuilder

static class Core_SQL__MemberIdBuilder
{
 public static Structure_MemberId Create(SqlExpression instance,
                                         MemberInfo    memberInfo)
 {
  Debug.Assert(!Object.ReferenceEquals(memberInfo,null));

  //---------------- ObjectType
  var objectType
   =Helper__MakeObjectType
     (instance,
      memberInfo);

  Debug.Assert(!Object.ReferenceEquals(objectType,null));

  //---------------- MemberName
  var memberName
   =memberInfo.Name;

  Debug.Assert(!string.IsNullOrWhiteSpace(memberName));

  //---------------- MemberIsStatic
  bool memberIsStatic
   =Object.ReferenceEquals(instance,null);

  //----------------
  return new Structure_MemberId
              (objectType,
               memberName,
               memberIsStatic);
 }//Create

 //-----------------------------------------------------------------------
#if DEBUG
 public static System.Type DEBUG__MakeObjectType(SqlExpression instance,
                                                 MemberInfo    memberInfo)
 {
  return Helper__MakeObjectType
          (instance,
           memberInfo);
 }//DEBUG__MakeObjectType
#endif

 //Helper methods --------------------------------------------------------
 private static System.Type Helper__MakeObjectType(SqlExpression instance,
                                                   MemberInfo    memberInfo)
 {
  Debug.Assert(!Object.ReferenceEquals(memberInfo,null));
  Debug.Assert(!Object.ReferenceEquals(memberInfo.DeclaringType,null));

  //----------------
  System.Type objectType;

  //
  // [2020-10-23]
  //  Avoid a problem with SqlExpression. It unwrap Nullable types.
  //
  // [2021-05-24]
  //  Problem with Byte[].LongLength. member describes 'Array.LongLength'.
  //
  if(Object.ReferenceEquals(instance,null))
  {
   objectType=memberInfo.DeclaringType;
  }
  else
  if(memberInfo.DeclaringType.Extension__IsNullableType())
  {
   //
   // [2021-05-24]
   //  Recovery type of nullable instance
   //

   Debug.Assert(!Object.ReferenceEquals(instance,null));
   Debug.Assert(!Object.ReferenceEquals(instance.Type,null));

   objectType=instance.Type.MakeNullable(true);
  }
  else
  {
   //[2019-05-06] Research
   //Debug.Assert(instance.Type.Equals(member.DeclaringType));

   Debug.Assert(!Object.ReferenceEquals(instance,null));
   Debug.Assert(!Object.ReferenceEquals(instance.Type,null));

   objectType=instance.Type;
  }//else

  //[2021-05-24]
  //objectType=member.DeclaringType;

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
};//class Core_SQL__MemberIdBuilder

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.SQL
