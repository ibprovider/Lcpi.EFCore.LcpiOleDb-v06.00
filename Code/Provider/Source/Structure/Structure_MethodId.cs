////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.05.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_MethodId

sealed class Structure_MethodId
{
 public Structure_MethodId(System.Type                                   declaringType,
                           string                                        methodName,
                           IReadOnlyList<Structure_MethodParameterDescr> parameters,
                           Structure_MethodFlags                         methodFlags)
 {
  Debug.Assert(!Object.ReferenceEquals(declaringType,null));
  Debug.Assert(!Object.ReferenceEquals(methodName,null));
  Debug.Assert(!Object.ReferenceEquals(parameters,null));

  Debug.Assert(methodName.Trim()==methodName);

#if DEBUG
  for(int i=0;i!=parameters.Count;++i)
  {
   Debug.Assert(!Object.ReferenceEquals(parameters[i],null));
  }
#endif

  //----------------------------------------
  m_DeclaringType   =declaringType;
  m_MethodName      =methodName;
  m_Parameters      =parameters;
  m_MethodFlags     =methodFlags;
 }//Structure_MethodId

 //-----------------------------------------------------------------------
 public static Structure_MethodId Create(System.Type                declaringType,
                                         string                     methodName,
                                         IReadOnlyList<System.Type> parameterTypes)
 {
  Debug.Assert(!Object.ReferenceEquals(declaringType,null));
  Debug.Assert(!Object.ReferenceEquals(methodName,null));
  Debug.Assert(!Object.ReferenceEquals(parameterTypes,null));

  return Helper__Create
          (declaringType,
           methodName,
           parameterTypes,
           /*methodFlags*/0);
 }//Create - declaringType, methodName, parameterTypes 

 //-----------------------------------------------------------------------
 public static Structure_MethodId Create_Static
                                        (System.Type                declaringType,
                                         string                     methodName,
                                         IReadOnlyList<System.Type> parameterTypes)
 {
  Debug.Assert(!Object.ReferenceEquals(declaringType,null));
  Debug.Assert(!Object.ReferenceEquals(methodName,null));
  Debug.Assert(!Object.ReferenceEquals(parameterTypes,null));

  return Helper__Create
          (declaringType,
           methodName,
           parameterTypes,
           Structure_MethodFlags.IsStatic);
 }//Create_Static - declaringType, methodName, parameterTypes 

 //-----------------------------------------------------------------------
 private static Structure_MethodId Helper__Create
                                           (System.Type                declaringType,
                                            string                     methodName,
                                            IReadOnlyList<System.Type> parameterTypes,
                                            Structure_MethodFlags      methodFlags)
 {
  Debug.Assert(!Object.ReferenceEquals(declaringType,null));
  Debug.Assert(!Object.ReferenceEquals(methodName,null));
  Debug.Assert(!Object.ReferenceEquals(parameterTypes,null));

  var parameters
   =new Structure_MethodParameterDescr[parameterTypes.Count];

  for(int i=0,_c=parameterTypes.Count;i!=_c;++i)
  {
   Debug.Assert(!Object.ReferenceEquals(parameterTypes[i],null));

   parameters[i]
    =Structure_MethodParameterDescr.Create
      (parameterTypes[i]);

   Debug.Assert(!Object.ReferenceEquals(parameters[i],null));
  }//for i

  var result
   =new Structure_MethodId
     (declaringType,
      methodName,
      parameters,
      methodFlags);

  return result;
 }//Helper__Create - declaringType, methodName, parameters, methodFlags

 //-----------------------------------------------------------------------
 public static Structure_MethodId Create(MethodInfo methodInfo)
 {
  Debug.Assert(!Object.ReferenceEquals(methodInfo,null));
  Debug.Assert(!Object.ReferenceEquals(methodInfo.Name,null));

  //----------------------------------------
  var methodParameters
   =methodInfo.GetParameters();

  Debug.Assert(!Object.ReferenceEquals(methodParameters,null));

  var parameters
   =new Structure_MethodParameterDescr[methodParameters.Length];

  for(int i=0,_c=methodParameters.Length;i!=_c;++i)
  {
   parameters[i]
    =Structure_MethodParameterDescr.Create
      (methodParameters[i]);

   Debug.Assert(!Object.ReferenceEquals(parameters[i],null));
  }//for i

  //----------------------------------------
  Structure_MethodFlags
   methodFlags
    =0;

  if(methodInfo.IsStatic)
   methodFlags|=Structure_MethodFlags.IsStatic;

  if(Structure_ReflectionUtils.IsExtensionMethod(methodInfo))
   methodFlags|=Structure_MethodFlags.IsExtension;

  //----------------------------------------
  var result
   =new Structure_MethodId
     (methodInfo.DeclaringType,
      methodInfo.Name,
      parameters,
      methodFlags);

  return result;
 }//Create - methodInfo

 //interface -------------------------------------------------------------
 public System.Type DeclaringType
 {
  get
  {
   Debug.Assert(!Object.ReferenceEquals(m_DeclaringType,null));

   return m_DeclaringType;
  }//get
 }//DeclaringType

 //-----------------------------------------------------------------------
 public System.String MethodName
 {
  get
  {
   Debug.Assert(!Object.ReferenceEquals(m_MethodName,null));

   return m_MethodName;
  }//get
 }//MethodName

 //-----------------------------------------------------------------------
 public IReadOnlyList<Structure_MethodParameterDescr> Parameters
 {
  get
  {
   Debug.Assert(!Object.ReferenceEquals(m_Parameters,null));

   return m_Parameters;
  }//get
 }//Parameters

 //-----------------------------------------------------------------------
 public Structure_MethodFlags MethodFlags
 {
  get
  {
   return m_MethodFlags;
  }//get
 }//MethodFlags

 //-----------------------------------------------------------------------
 public bool IsStatic
 {
  get
  {
   return m_MethodFlags.HasFlag(Structure_MethodFlags.IsStatic);
  }//get
 }//IsStatic

 //-----------------------------------------------------------------------
 public bool IsExtension
 {
  get
  {
   return m_MethodFlags.HasFlag(Structure_MethodFlags.IsExtension);
  }//get
 }//IsExtension

 //-----------------------------------------------------------------------
 public bool Equals(Structure_MethodId x)
 {
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
 }//Equals - Structure_MethodId

 //-----------------------------------------------------------------------
 public bool Equals(MethodInfo x)
 {
  bool r;

  if(Object.ReferenceEquals(x,null))
  {
   r=false;
  }
  else
  {
   r=this.Helper__EqualsMembers(x);
  }//else

  return r;
 }//Equals - MethodInfo

 //-----------------------------------------------------------------------
 public static bool operator == (Structure_MethodId a,MethodInfo b)
 {
  if(Object.ReferenceEquals(a,null))
  {
   if(Object.ReferenceEquals(b,null))
    return true;

   Debug.Assert(!Object.ReferenceEquals(b,null));

   return false;
  }//if

  Debug.Assert(!Object.ReferenceEquals(a,null));

  if(Object.ReferenceEquals(b,null))
  {
   return false;
  }//if

  Debug.Assert(!Object.ReferenceEquals(b,null));

  return a.Equals(b);
 }// Structure_MethodId == MethodInfo

 //-----------------------------------------------------------------------
 public static bool operator == (MethodInfo a,Structure_MethodId b)
 {
  return b==a;
 }// MethodInfo == Structure_MethodId

 //-----------------------------------------------------------------------
 public static bool operator != (Structure_MethodId a,MethodInfo b)
 {
  return !(a==b);
 }// Structure_MethodId != MethodInfo

 //-----------------------------------------------------------------------
 public static bool operator != (MethodInfo a,Structure_MethodId b)
 {
  return !(a==b);
 }// MethodInfo != Structure_MethodId

 //Object interface ------------------------------------------------------
 public override bool Equals(object x)
 {
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
  if(x.GetType()==Structure_TypeCache.TypeOf__LcpiEF__Structure_MethodId)
  {
   Debug.Assert(x is Structure_MethodId);

   r=this.Helper__EqualsMembers((Structure_MethodId)x);
  }
  else
  if(x.GetType()==Structure_TypeCache.TypeOf__SystemReflection__MethodInfo)
  {
   Debug.Assert(x is MethodInfo);

   r=this.Helper__EqualsMembers((MethodInfo)x);
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
  Debug.Assert(!Object.ReferenceEquals(m_DeclaringType,null));
  Debug.Assert(!Object.ReferenceEquals(m_MethodName,null));
  Debug.Assert(!Object.ReferenceEquals(m_Parameters,null));

  unchecked
  {
   var hashCode=m_DeclaringType.GetHashCode();

   hashCode=(hashCode*397)^m_MethodName.GetHashCode();

   hashCode=(hashCode*397)^m_MethodFlags.GetHashCode();

   hashCode=(hashCode*397)^m_Parameters.Count.GetHashCode();

   for(int i=0,_c=m_Parameters.Count;i!=_c;++i)
   {
    Debug.Assert(!Object.ReferenceEquals(m_Parameters[i],null));

    hashCode=(hashCode*397)^m_Parameters[i].GetHashCode();
   }//for i

   return hashCode;
  }//unchecked
 }//GetHashCode

  //-----------------------------------------------------------------------
  public override string ToString()
  {
   var sb=new System.Text.StringBuilder();

   sb.Append(this.DeclaringType.Extension__BuildHumanName());
   sb.Append(".");
   sb.Append(this.MethodName);
   sb.Append("(");

   if(this.IsExtension)
   {
    sb.Append("this ");
   }//if

   var mparams=this.Parameters;

   string value="";

   foreach(var param in mparams)
   {
    sb.Append(value);

    var ptype=param.ParameterType;

    string text=ptype.Extension__BuildHumanName();

    if(ptype.IsByRef)
    {
     sb.Append(text.TrimEnd('&'));
     sb.Append(" ByRef");
    }
    else
    {
     sb.Append(text);
    }

    value=", ";
   }//foreach

   sb.Append(")");

   return sb.ToString();
  }//ToString

  //Helper methods --------------------------------------------------------
  private bool Helper__EqualsMembers(Structure_MethodId x)
 {
  Debug.Assert(!Object.ReferenceEquals(x,null));
  Debug.Assert(!Object.ReferenceEquals(x.m_DeclaringType,null));
  Debug.Assert(!Object.ReferenceEquals(x.m_MethodName,null));
  Debug.Assert(!Object.ReferenceEquals(x.m_Parameters,null));

  Debug.Assert(!Object.ReferenceEquals(m_DeclaringType,null));
  Debug.Assert(!Object.ReferenceEquals(m_MethodName,null));
  Debug.Assert(!Object.ReferenceEquals(m_Parameters,null));

  //----------------------------------------
  if(m_DeclaringType!=x.m_DeclaringType)
   return false;

  if(!System.StringComparer.Ordinal.Equals(m_MethodName,x.m_MethodName))
   return false;

  if(m_MethodFlags!=x.m_MethodFlags)
   return false;

  if(m_Parameters.Count!=x.m_Parameters.Count)
   return false;

  for(int i=0,_c=m_Parameters.Count;i!=_c;++i)
  {
   Debug.Assert(!Object.ReferenceEquals(m_Parameters[i],null));
   Debug.Assert(!Object.ReferenceEquals(x.m_Parameters[i],null));

   if(!m_Parameters[i].Equals(x.m_Parameters[i]))
    return false;
  }//for i

  return true;
 }//Helper__EqualsMembers - Structure_MethodId

 //-----------------------------------------------------------------------
 private bool Helper__EqualsMembers(MethodInfo x)
 {
  Debug.Assert(!Object.ReferenceEquals(x,null));
  Debug.Assert(!Object.ReferenceEquals(x.DeclaringType,null));
  Debug.Assert(!Object.ReferenceEquals(x.Name,null));

  Debug.Assert(!Object.ReferenceEquals(m_DeclaringType,null));
  Debug.Assert(!Object.ReferenceEquals(m_MethodName,null));
  Debug.Assert(!Object.ReferenceEquals(m_Parameters,null));

  //----------------------------------------
  if(m_DeclaringType!=x.DeclaringType)
   return false;

  if(!System.StringComparer.Ordinal.Equals(m_MethodName,x.Name))
   return false;

  if(m_MethodFlags!=Helper__BuildMethodFlags(x))
   return false;

  var x_Parameters
   =x.GetParameters();

  Debug.Assert(!Object.ReferenceEquals(x_Parameters,null));

  if(m_Parameters.Count!=x_Parameters.Length)
   return false;

  for(int i=0,_c=m_Parameters.Count;i!=_c;++i)
  {
   Debug.Assert(!Object.ReferenceEquals(m_Parameters[i],null));
   Debug.Assert(!Object.ReferenceEquals(x_Parameters[i],null));

   if(!m_Parameters[i].Equals(x_Parameters[i]))
    return false;
  }//for i

  return true;
 }//Helper__EqualsMembers - MethodInfo

 //-----------------------------------------------------------------------
 private static Structure_MethodFlags Helper__BuildMethodFlags(MethodInfo methodInfo)
 {
  Debug.Assert(!Object.ReferenceEquals(methodInfo,null));

  Structure_MethodFlags
   methodFlags
    =0;

  if(methodInfo.IsStatic)
   methodFlags|=Structure_MethodFlags.IsStatic;

  if(Structure_ReflectionUtils.IsExtensionMethod(methodInfo))
   methodFlags|=Structure_MethodFlags.IsExtension;

  return methodFlags;
 }//Helper__BuildMethodFlags

 //private data ----------------------------------------------------------
 private readonly System.Type                                   m_DeclaringType;
 private readonly string                                        m_MethodName;
 private readonly IReadOnlyList<Structure_MethodParameterDescr> m_Parameters;
 private readonly Structure_MethodFlags                         m_MethodFlags;
}
////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
