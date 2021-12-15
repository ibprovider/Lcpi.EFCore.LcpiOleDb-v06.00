////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 05.09.2021.
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
 public static string Extension__BuildHumanName(this Type type)
 {
  Debug.Assert(!type.IsGenericParameter);

  var ctx
   =new tagBuildHumanNameCtx
     (type);

  var result
   =Helper__BuildHumanName
     (ref ctx,
      type);

  return result;
 }//Extension__BuildHumanName

 //Helper types ----------------------------------------------------------
 private struct tagBuildHumanNameCtx
 {
  public int nSkipGenericArgs;

  public Type[] GenericArguments;

  public tagBuildHumanNameCtx(Type type)
  {
   this.nSkipGenericArgs=0;

   if(!type.IsGenericType)
   {
    this.GenericArguments=null;
   }
   else
   {
    this.GenericArguments=type.GetGenericArguments();

    Debug.Assert(!Object.ReferenceEquals(this.GenericArguments,null));
   }//else
  }//tagBuildHumanNameCtx
 };//struct tagBuildHumanNameCtx

 //-----------------------------------------------------------------------
 private struct tagResultOfExtractGenericName
 {
  public bool    HasGenericParams;
  public string  Name;

  public tagResultOfExtractGenericName(bool hasGenericParams,string name)
  {
   this.HasGenericParams=hasGenericParams;

   this.Name=name;
  }//tagResultOfExtractGenericName
 };//struct tagResultOfExtractGenericName

 //Helper methods --------------------------------------------------------
 private static string Helper__BuildHumanName(ref tagBuildHumanNameCtx ctx,
                                              Type                     type)
 {
  Debug.Assert(!Object.ReferenceEquals(type,null));

  var sb
   =new System.Text.StringBuilder();

  //------------------------------------------------------- ARRAY
  if(type.IsArray)
  {
   var elementType
    =type.GetElementType();

   Debug.Assert(!Object.ReferenceEquals(elementType,null));

   sb.Append
    (Extension__BuildHumanName(elementType));

   var arrayRank
    =type.GetArrayRank();

   Debug.Assert(arrayRank>0);

   for(int i=0;i!=arrayRank;++i)
    sb.Append("[]");

   return sb.ToString();
  }//if type.IsArray

  Debug.Assert(!type.IsArray);

  //------------------------------------------------------- STD

  //------------------------- parent class OR namespace
  if(!Object.ReferenceEquals(type.DeclaringType,null))
  {
   var declaringTypeSign
    =Helper__BuildHumanName
      (ref ctx,
       type.DeclaringType);

   Debug.Assert(!string.IsNullOrEmpty(declaringTypeSign));

   sb.Append(declaringTypeSign);
   sb.Append('+');
  }
  else
  {
   for(;;)
   {
    if(Helper__BuildHumanName__SkipNms(type))
     break;

    var nms
     =type.Namespace;

    if(Object.ReferenceEquals(nms,null))
     break;

    Debug.Assert(nms.Length>0);

    if(nms.Length==0)
     break;

    sb.Append(nms);
    sb.Append('.');

    break;
   }//for[ever]
  }//else

  //------------------------- name
  if(!type.IsGenericType)
  {
   Debug.Assert(ctx.nSkipGenericArgs==0);

   sb.Append(Helper__CheckTypeName(type.Name));
  }
  else
  {
   Debug.Assert(type.IsGenericType);

   //-------------------------
   var extractResult
    =Helper__ExtractGenericName(type);

   sb.Append(extractResult.Name);

   var genericArgs
     =type.GetGenericArguments();

   Debug.Assert(!Object.ReferenceEquals(genericArgs,null));

   Debug.Assert(genericArgs.Length>0);

   Debug.Assert(ctx.nSkipGenericArgs<=genericArgs.Length);

   if(ctx.nSkipGenericArgs==genericArgs.Length)
   {
    //NO GENERIC PARAMETERS

    Debug.Assert(!extractResult.HasGenericParams);
   }
   else
   {
    //HAS GENERIC PARAMETERS

    Debug.Assert(extractResult.HasGenericParams);

    sb.Append('<');

    bool isFirst
     =true;

    for(int iArg=ctx.nSkipGenericArgs,_cArgs=genericArgs.Length;iArg!=_cArgs;++iArg,isFirst=false)
    {
     Debug.Assert(iArg<ctx.GenericArguments.Length);

     var a
      =ctx.GenericArguments[iArg];

     Debug.Assert(!Object.ReferenceEquals(a,null));

     if(!isFirst)
      sb.Append(',');

     if(!a.IsGenericParameter)
     {
      if(!isFirst)
       sb.Append(' ');

      sb.Append
       (Extension__BuildHumanName(a));
     }//if !a.IsGenericParameter
    }//for i

    sb.Append('>');

    //-----
    ctx.nSkipGenericArgs=genericArgs.Length;
   }//if extractResult.Item1
  }//else type.IsGenericType with parameters

  //-------------------------- Go home...
  return sb.ToString();
 }//Helper__BuildHumanName

 //-----------------------------------------------------------------------
 private static bool Helper__BuildHumanName__SkipNms(Type type)
 {
  Debug.Assert(!Object.ReferenceEquals(type,null));

  if(!type.IsGenericType)
   return false;

  if(!type.IsGenericTypeDefinition)
   type=type.GetGenericTypeDefinition();

  //special support for Nullable - skip namespace
  if(type==Structure_TypeCache.TypeOf__System_Nullable)
   return true;

  return false;
 }//Helper__BuildHumanName__SkipNms

 //-----------------------------------------------------------------------
 private static tagResultOfExtractGenericName Helper__ExtractGenericName(Type type)
 {
  Debug.Assert(!Object.ReferenceEquals(type,null));
  Debug.Assert(type.IsGenericType);

  //Example: "Nullable`1"
  var name
   =Helper__CheckTypeName(type.Name);

  var i
   =name.IndexOf('`');

  if(i==-1)
  {
   return new tagResultOfExtractGenericName
           (false,
            name);
  }//if

  Debug.Assert(i>0);

  var name2
   =name.Substring(0,i);

  return new tagResultOfExtractGenericName
          (true,
           Helper__CheckTypeName(name2));
 }//Helper__ExtractGenericName

 //-----------------------------------------------------------------------
 private static string Helper__CheckTypeName(string name)
 {
  Debug.Assert(!string.IsNullOrEmpty(name));

  if(Object.ReferenceEquals(name,null))
   return "##NULL_TYPE_NAME";

  if(name.Length==0)
   return "##EMPTY_TYPE_NAME";

  return name;
 }//Helper__CheckTypeName
};//class LcpiOleDb__Extensions__Type

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb
