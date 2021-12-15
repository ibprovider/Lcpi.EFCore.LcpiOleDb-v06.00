////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 06.10.2018.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_MemberId

sealed class Structure_MemberId
{
 public Structure_MemberId(Type   objectType,
                           string memberName,
                           bool   memberIsStatic)
 {
  Debug.Assert(!Object.ReferenceEquals(objectType,null));
  Debug.Assert(!string.IsNullOrWhiteSpace(memberName));

  //----------------------------------------
  m_ObjectType     =objectType;
  m_MemberName     =memberName;
  m_MemberIsStatic =memberIsStatic;

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(m_ObjectType,null));
  Debug.Assert(!string.IsNullOrWhiteSpace(m_MemberName));
 }//Structure_MemberId

 //-----------------------------------------------------------------------
 public Structure_MemberId(System.Linq.Expressions.MemberExpression memberExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(memberExpression,null));
  Debug.Assert(!Object.ReferenceEquals(memberExpression.Member,null));
  Debug.Assert(!Object.ReferenceEquals(memberExpression.Member.DeclaringType,null));

  Debug.Assert(!string.IsNullOrWhiteSpace(memberExpression.Member.Name));

  //----------------------------------------
  m_ObjectType     =Helper__GetObjectType(memberExpression);
  m_MemberName     =Helper__GetMemberName(memberExpression);
  m_MemberIsStatic =Helper__MemberIsStatic(memberExpression);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(m_ObjectType,null));
  Debug.Assert(!string.IsNullOrWhiteSpace(m_MemberName));
 }//Structure_MemberId

 //-----------------------------------------------------------------------
 public static Structure_MemberId Create_ObjectMember(Type   objectType,
                                                      string memberName)
 {
  // [2020-10-16] Tested.

  return new Structure_MemberId
          (objectType,
           memberName,
           /*memberIsStatic*/false);
 }//Create_ObjectMember

 //-----------------------------------------------------------------------
 public static Structure_MemberId Create_ClassMember(Type   objectType,
                                                     string memberName)
 {
  // [2020-10-16] Tested.

  return new Structure_MemberId
          (objectType,
           memberName,
           /*memberIsStatic*/true);
 }//Create_ClassMember

 //interface -------------------------------------------------------------
 public Type ObjectType
 {
  get
  {
   // [2020-10-16] Tested.

   Debug.Assert(!Object.ReferenceEquals(m_ObjectType,null));

   return m_ObjectType;
  }//get
 }//ObjectType

 //-----------------------------------------------------------------------
 public string MemberName
 {
  get
  {
   // [2020-10-16] Tested.

   Debug.Assert(!string.IsNullOrWhiteSpace(m_MemberName));

   return m_MemberName;
  }//get
 }//MemberName

 //-----------------------------------------------------------------------
 public bool MemberIsStatic
 {
  get
  {
   // [2020-10-16] Tested.

   return m_MemberIsStatic;
  }//get
 }//MemberIsStatic

 //-----------------------------------------------------------------------
 public bool Equals(Structure_MemberId x)
 {
  // [2020-10-16] Tested.

  bool r;

  if(Object.ReferenceEquals(x,null))
  {
   r=false;
  }
  else
  if(Object.ReferenceEquals(x,this))
  {
   r=true;
  }
  else
  {
   r=this.Helper__EqualsMembers(x);
  }//else

  return r;
 }//Equals - Structure_MemberId

 //-----------------------------------------------------------------------
 public static bool operator == (Structure_MemberId x1,
                                 Structure_MemberId x2)
 {
  // [2020-10-16] Tested.

  if(Object.ReferenceEquals(x1,null))
  {
   if(Object.ReferenceEquals(x2,null))
    return true;

   return false;
  }//if

  Debug.Assert(!Object.ReferenceEquals(x1,null));

  if(Object.ReferenceEquals(x2,null))
   return false;

  if(Object.ReferenceEquals(x1,x2))
   return true;

  return x1.Helper__EqualsMembers(x2);
 }//operator ==

 //-----------------------------------------------------------------------
 public static bool operator != (Structure_MemberId x1,
                                 Structure_MemberId x2)
 {
  // [2020-10-16] Tested.

  return !(x1==x2);
 }//operator !=

 //-----------------------------------------------------------------------
#if DEBUG

 public static bool operator == (Structure_MemberId                       id,
                                 System.Linq.Expressions.MemberExpression e)
 {
  Debug.Assert(!Object.ReferenceEquals(id,null));
  Debug.Assert(!Object.ReferenceEquals(e,null));

  return id.Helper__EqualTo(e);
 }//operator == MemberExpression

 //-----------------------------------------------------------------------
 public static bool operator != (Structure_MemberId                       id,
                                 System.Linq.Expressions.MemberExpression e)
 {
  Debug.Assert(!Object.ReferenceEquals(id,null));
  Debug.Assert(!Object.ReferenceEquals(e,null));

  return !id.Helper__EqualTo(e);
 }//operator != MemberExpression

 //-----------------------------------------------------------------------
 public static bool operator == (System.Linq.Expressions.MemberExpression e,
                                 Structure_MemberId                       id)
 {
  Debug.Assert(!Object.ReferenceEquals(id,null));
  Debug.Assert(!Object.ReferenceEquals(e,null));

  return id.Helper__EqualTo(e);
 }//revert operator == MemberExpression

 //-----------------------------------------------------------------------
 public static bool operator != (System.Linq.Expressions.MemberExpression e,
                                 Structure_MemberId                       id)
 {
  Debug.Assert(!Object.ReferenceEquals(id,null));
  Debug.Assert(!Object.ReferenceEquals(e,null));

  return !id.Helper__EqualTo(e);
 }//revert operator != MemberExpression

#endif //DEBUG

 //Object interface ------------------------------------------------------
 public override bool Equals(object x)
 {
  // [2020-10-16] Tested.

  bool r;

  if(Object.ReferenceEquals(x,null))
  {
   r=false;
  }
  else
  if(Object.ReferenceEquals(x,this))
  {
   r=true;
  }
  else
  if(x.GetType()==Structure_TypeCache.TypeOf__LcpiEF__Structure_MemberId)
  {
   Debug.Assert(x is Structure_MemberId);

   r=this.Helper__EqualsMembers((Structure_MemberId)x);
  }
  else
  {
   r=false;
  }//else

  return r;
 }//Equals - object

 //-----------------------------------------------------------------------
 public override int GetHashCode()
 {
  Debug.Assert(!Object.ReferenceEquals(m_ObjectType,null));
  Debug.Assert(!string.IsNullOrWhiteSpace(m_MemberName));

  unchecked
  {
   var hashCode=m_ObjectType.GetHashCode();

   hashCode=(hashCode*397)^m_MemberName.GetHashCode();

   hashCode=(hashCode*397)^m_MemberIsStatic.GetHashCode();

   return hashCode;
  }//unchecked
 }//GetHashCode

 //-----------------------------------------------------------------------
 public override string ToString()
 {
  var sb=new System.Text.StringBuilder();

  sb.Append(m_ObjectType.Extension__BuildHumanName());
  sb.Append(".");
  sb.Append(m_MemberName);

  return sb.ToString();
 }//ToString

 //Helper interface ------------------------------------------------------
#if DEBUG

 public bool Helper__EqualTo(System.Linq.Expressions.MemberExpression e)
 {
  Debug.Assert(!Object.ReferenceEquals(e,null));

  bool r;

  if(m_ObjectType!=Helper__GetObjectType(e))
  {
   r=false;
  }
  else
  if(m_MemberName!=Helper__GetMemberName(e))
  {
   r=false;
  }
  else
  if(m_MemberIsStatic!=Helper__MemberIsStatic(e))
  {
   r=false;
  }
  else
  {
   r=true;
  }//else

  return r;
 }//Helper__EqualTo

#endif //DEBUG

 //-----------------------------------------------------------------------
 private bool Helper__EqualsMembers(Structure_MemberId x)
 {
  // [2020-10-16] Tested.

  Debug.Assert(!Object.ReferenceEquals(x,null));
  Debug.Assert(!Object.ReferenceEquals(x.m_ObjectType,null));
  Debug.Assert(!string.IsNullOrWhiteSpace(x.m_MemberName));

  Debug.Assert(!Object.ReferenceEquals(m_ObjectType,null));
  Debug.Assert(!string.IsNullOrWhiteSpace(m_MemberName));

  if(m_ObjectType!=x.m_ObjectType)
   return false;

  if(m_MemberName!=x.m_MemberName)
   return false;

  if(m_MemberIsStatic!=x.m_MemberIsStatic)
   return false;

  return true;
 }//Helper__EqualsMembers

 //-----------------------------------------------------------------------
 private static bool Helper__MemberIsStatic(System.Linq.Expressions.MemberExpression e)
 {
  Debug.Assert(!Object.ReferenceEquals(e,null));

  if(Object.ReferenceEquals(e.Expression,null))
   return true;

  return false;
 }//Helper__MemberIsStatic

 //-----------------------------------------------------------------------
 private static Type Helper__GetObjectType(System.Linq.Expressions.MemberExpression e)
 {
  Debug.Assert(!Object.ReferenceEquals(e,null));
  Debug.Assert(!Object.ReferenceEquals(e.Member,null));
  Debug.Assert(!Object.ReferenceEquals(e.Member.DeclaringType,null));

  if(Object.ReferenceEquals(e.Expression,null))
  {
   //Static

   return e.Member.DeclaringType;
  }//if

  Debug.Assert(!Object.ReferenceEquals(e.Expression,null));
  Debug.Assert(!Object.ReferenceEquals(e.Expression.Type,null));

  //
  // [2018-10-08]
  //  Research
  //
  // [2021-05-24]
  //  e.Member.DeclaringType : System.Array
  //  e.Expression.Type      : System.Byte[]
  //
  //Debug.Assert(e.Member.DeclaringType==e.Expression.Type);

  return e.Expression.Type;
 }//Helper__GetObjectType

 //-----------------------------------------------------------------------
 private static string Helper__GetMemberName(System.Linq.Expressions.MemberExpression e)
 {
  Debug.Assert(!Object.ReferenceEquals(e,null));
  Debug.Assert(!Object.ReferenceEquals(e.Member,null));
  Debug.Assert(!string.IsNullOrWhiteSpace(e.Member.Name));

  return e.Member.Name;
 }//Helper__GetMemberName

 //-----------------------------------------------------------------------
 private readonly Type m_ObjectType;

 private readonly string m_MemberName;

 private readonly bool m_MemberIsStatic;
};//class Structure_MemberId

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
