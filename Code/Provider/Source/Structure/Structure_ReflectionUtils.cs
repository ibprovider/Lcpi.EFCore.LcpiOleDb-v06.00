////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 13.10.2020.

using System;
using System.Diagnostics;
using System.Reflection;
//using lib=lcpi.lib;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_ReflectionUtils

static class Structure_ReflectionUtils
{
 public static bool IsExtensionMethod(MethodInfo method)
 {
  //[2020-10-13] Tested.

  Debug.Assert(!Object.ReferenceEquals(method,null));
  Debug.Assert(!Object.ReferenceEquals(method.CustomAttributes,null));

  if(!method.IsStatic)
  {
#if DEBUG
   foreach(var a in method.CustomAttributes)
   {
    Debug.Assert(!Object.ReferenceEquals(a.AttributeType,null));

    Debug.Assert(a.AttributeType!=Structure_TypeCache.TypeOf__SystemRuntimeCompilerServices_ExtensionAttribute);
   }//foreach a
#endif

   return false;
  }//if !method.IsStatic

  Debug.Assert(method.IsStatic);

  foreach(var a in method.CustomAttributes)
  {
   Debug.Assert(!Object.ReferenceEquals(a.AttributeType,null));

   if(a.AttributeType==Structure_TypeCache.TypeOf__SystemRuntimeCompilerServices_ExtensionAttribute)
    return true;
  }//foreach a

  return false;
 }//IsExtensionMethod

 //-----------------------------------------------------------------------
 public static string BuildMethodSign(System.Reflection.MethodInfo m)
 {
  //[2020-13-10] Tested.

  Debug.Assert(!Object.ReferenceEquals(m,null));

  var sb=new System.Text.StringBuilder();

  sb.Append(m.DeclaringType.Extension__BuildHumanName());
  sb.Append(".");
  sb.Append(m.Name);

  if(m.IsGenericMethod)
  {
   sb.Append("<");

   var gargs
    =m.GetGenericArguments();

   Debug.Assert(!Object.ReferenceEquals(gargs,null));

   sb.Append(Structure_ADP.BuildParamsSign(gargs));
   sb.Append(">");
  }//if

  sb.Append("(");

  if(IsExtensionMethod(m))
  {
   sb.Append("this ");
  }//if

  var mparams
   =m.GetParameters();

  Debug.Assert(!Object.ReferenceEquals(mparams,null));

  string sep=string.Empty;

  foreach(var param in mparams)
  {
   sb.Append(sep);

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
   }//else

   sep=", ";
  }//foreach

  sb.Append(")");

  return sb.ToString();
 }//BuildMethodSign

 //-----------------------------------------------------------------------
 public static string BuildMemberSign(System.Reflection.MemberInfo m)
 {
  Debug.Assert(!Object.ReferenceEquals(m,null));

  var sb=new System.Text.StringBuilder();

  sb.Append(m.DeclaringType.Extension__BuildHumanName());
  sb.Append(".");
  sb.Append(m.Name);

  return sb.ToString();
 }//BuildMemberSign
};//class Structure_ReflectionUtils

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
