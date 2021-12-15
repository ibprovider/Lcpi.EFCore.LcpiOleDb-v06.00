////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.10.2021.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage.Mapping{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__TypeMapping

abstract partial class LcpiOleDb__TypeMapping
 :RelationalTypeMapping
{
 protected LcpiOleDb__TypeMapping(in RelationalTypeMappingParameters parameters)
  :base(parameters)
 {
 }//LcpiOleDb__TypeMapping

 //Object interface ------------------------------------------------------
 public override bool Equals(object obj)
 {
#if TRACE
  Core.Core_Trace.Method_Enter
   ("LcpiOleDb__TypeMapping::Equals\n"
   +" ({0})",
    obj);
#endif

  //------------------------------------------------------------
  bool r;

  if(Object.ReferenceEquals(obj,null))
  {
   r=false;
  }
  else
  if(Object.ReferenceEquals(obj,this))
  {
   r=true;
  }
  else
  if(obj.GetType()!=this.GetType())
  {
   r=false;
  }
  else
  {
   var typedObj=(LcpiOleDb__TypeMapping)obj;

   Debug.Assert(!Object.ReferenceEquals(typedObj,null));

   if(!HelperComparer.IsEquals(this,typedObj))
   {
    Debug.Assert(!base.Equals(typedObj));

    r=false;
   }
   else
   {
 #if DEBUG
    var h1=this.GetHashCode();
    var h2=obj .GetHashCode();

    Debug.Assert(h1==h2);
 #endif

    r=true;
   }//else
  }//else

#if TRACE
  Core.Core_Trace.Method_Exit
   ("LcpiOleDb__TypeMapping::Equals\n"
   +" ({0}) - {1}",
    obj,
    r);
#endif

  return r;
 }//Equals

 //-----------------------------------------------------------------------
 public override int GetHashCode()
 {
#if TRACE
  Core.Core_Trace.Method_Enter
   ("LcpiOleDb__TypeMapping::GetHashCode()");
#endif

  //------------------------------------------------------------
  var hashCode=HelperHashCodeBuilder.Exec(this);

#if TRACE
  Core.Core_Trace.Method_Exit
   ("LcpiOleDb__TypeMapping::GetHashCode() - {0}",
    hashCode);
#endif

  return hashCode;
 }//GetHashCode
};//class LcpiOleDb__TypeMapping

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage.Mapping
