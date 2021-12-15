////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.06.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_ArrayAllocators

static class Structure_ArrayAllocators
{
 public static System.Type[] Alloc_Array_Of_SystemType(int count)
 {
  Debug.Assert(count>=0);

  if(count==0)
   return Structure_ConstData.Array_SystemType__EMPTY;

  Debug.Assert(count>0);

  return new System.Type[count];
 }//Alloc_Array_Of_SystemType

 //-----------------------------------------------------------------------
 public static Expression[] Alloc_Array_Of_LinqExpression(int count)
 {
  Debug.Assert(count>=0);

  if(count==0)
   return Structure_ConstData.Array_LinqExpression__EMPTY;

  Debug.Assert(count>0);

  return new Expression[count];
 }//Alloc_Array_Of_LinqExpression
};//class Structure_ArrayAllocators

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
