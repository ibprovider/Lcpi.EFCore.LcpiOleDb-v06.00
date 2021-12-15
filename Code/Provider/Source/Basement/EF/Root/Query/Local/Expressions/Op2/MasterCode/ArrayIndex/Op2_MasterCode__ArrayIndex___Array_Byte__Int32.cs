////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 28.05.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode{
////////////////////////////////////////////////////////////////////////////////
//using

using T_ARG1_E
 =System.Byte;

using T_ARG2
 =System.Int32;

using T_RESULT
 =System.Nullable<System.Byte>;

////////////////////////////////////////////////////////////////////////////////
//class Op2_MasterCode__ArrayIndex___Array_Byte__Int32

static class Op2_MasterCode__ArrayIndex___Array_Byte__Int32
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Op2_MasterCode__ArrayIndex___Array_Byte__Int32;

 //-----------------------------------------------------------------------
 public static T_RESULT Exec(T_ARG1_E[] a,T_ARG2 b)
 {
  if(Object.ReferenceEquals(a,null))
  {
   return null;
  }//if

  Debug.Assert(!Object.ReferenceEquals(a,null));

  //----------------------------------------
  if(!Helper__IsValidIndex(a,b))
  {
   //ERROR - OUT OF RANGE

   ThrowError.IndexOutOfRange
    (c_ErrSrcID,
     b,
     a.Length);

   Debug.Assert(false);
  }//if

  Debug.Assert(0<=b);
  Debug.Assert(b<a.Length);

  //----------------------------------------
  T_RESULT r=a[b];

  return r;
 }//Exec

 //Helper methods --------------------------------------------------------
 private static bool Helper__IsValidIndex(T_ARG1_E[] container,T_ARG2 index)
 {
  if(index<0)
   return false;

  if(container.Length<=index)
   return false;

  return true;
 }//Helper__IsValidIndex
};//class Op2_MasterCode__ArrayIndex___Array_Byte__Int32

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Op2.MasterCode