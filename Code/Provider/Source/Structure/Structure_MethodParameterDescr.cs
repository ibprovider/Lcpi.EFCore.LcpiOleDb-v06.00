////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.05.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_MethodParameterDescr

sealed class Structure_MethodParameterDescr
{
 private Structure_MethodParameterDescr(System.Type parameterType)
 {
  Debug.Assert(!Object.ReferenceEquals(parameterType,null));

  m_ParameterType=parameterType;
 }//Structure_MethodParameterDescr

 //-----------------------------------------------------------------------
 public static Structure_MethodParameterDescr Create(System.Type parameterType)
 {
  Debug.Assert(!Object.ReferenceEquals(parameterType,null));

  //----------------------------------------
  var r
   =new Structure_MethodParameterDescr
     (parameterType);

  return r;
 }//Create - parameterType

 //-----------------------------------------------------------------------
 public static Structure_MethodParameterDescr Create(ParameterInfo parameterInfo)
 {
  Debug.Assert(!Object.ReferenceEquals(parameterInfo,null));
  Debug.Assert(!Object.ReferenceEquals(parameterInfo.ParameterType,null));

  var r
   =new Structure_MethodParameterDescr
     (parameterInfo.ParameterType);

  return r;
 }//Create - parameterInfo

 //interface -------------------------------------------------------------
 public System.Type ParameterType
 {
  get
  {
   return m_ParameterType;
  }//get
 }//ParameterType

 //-----------------------------------------------------------------------
 public bool Equals(Structure_MethodParameterDescr x)
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
 }//Equals - Structure_MethodParameterDescr

 //-----------------------------------------------------------------------
 public bool Equals(ParameterInfo x)
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
 }//Equals - ParameterInfo

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
  if(x.GetType()==Structure_TypeCache.TypeOf__LcpiEF__Structure_MethodParameterDescr)
  {
   Debug.Assert(x is Structure_MethodParameterDescr);

   r=this.Helper__EqualsMembers((Structure_MethodParameterDescr)x);
  }
  else
  if(x.GetType()==Structure_TypeCache.TypeOf__SystemReflection__ParameterInfo)
  {
   Debug.Assert(x is ParameterInfo);

   r=this.Helper__EqualsMembers((ParameterInfo)x);
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
  Debug.Assert(!Object.ReferenceEquals(m_ParameterType,null));

  unchecked
  {
   var hashCode=m_ParameterType.GetHashCode();

   return hashCode;
  }//unchecked
 }//GetHashCode

 //Helper methods --------------------------------------------------------
 private bool Helper__EqualsMembers(Structure_MethodParameterDescr x)
 {
  Debug.Assert(!Object.ReferenceEquals(x,null));
  Debug.Assert(!Object.ReferenceEquals(x.m_ParameterType,null));

  Debug.Assert(!Object.ReferenceEquals(m_ParameterType,null));

  if(m_ParameterType!=x.m_ParameterType)
   return false;

  return true;
 }//Helper__EqualsMembers

 //-----------------------------------------------------------------------
 private bool Helper__EqualsMembers(ParameterInfo x)
 {
  Debug.Assert(!Object.ReferenceEquals(x,null));
  Debug.Assert(!Object.ReferenceEquals(x.ParameterType,null));

  Debug.Assert(!Object.ReferenceEquals(m_ParameterType,null));

  if(m_ParameterType!=x.ParameterType)
   return false;

  return true;
 }//Helper__EqualsMembers

 //private data ----------------------------------------------------------
 private readonly System.Type m_ParameterType;
};//class Structure_MethodParameterDescr

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure