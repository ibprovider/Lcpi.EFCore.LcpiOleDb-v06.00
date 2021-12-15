////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 02.09.2021.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_LegacyReferenceEqualityComparer

sealed class Structure_LegacyReferenceEqualityComparer
 :IEqualityComparer<object>
 ,IEqualityComparer
{
 public static readonly Structure_LegacyReferenceEqualityComparer
  Instance
   =new Structure_LegacyReferenceEqualityComparer();

 //-----------------------------------------------------------------------
 private Structure_LegacyReferenceEqualityComparer()
 {
 }//Structure_LegacyReferenceEqualityComparer

 //-----------------------------------------------------------------------
 public new bool Equals(object? x, object? y)
 {
  return Object.ReferenceEquals(x, y);
 }//Equals

 //-----------------------------------------------------------------------
 public int GetHashCode(object obj)
 {
  return RuntimeHelpers.GetHashCode(obj);
 }//GetHashCode

 //-----------------------------------------------------------------------
 bool IEqualityComparer<object>.Equals(object? x, object? y)
 {
  return Object.ReferenceEquals(x, y);
 }//Equals

 //-----------------------------------------------------------------------
 int IEqualityComparer.GetHashCode(object obj)
 {
  return RuntimeHelpers.GetHashCode(obj);
 }//GetHashCode

 //-----------------------------------------------------------------------
 bool IEqualityComparer.Equals(object? x, object? y)
 {
  return Object.ReferenceEquals(x, y);
 }//Equals

 //-----------------------------------------------------------------------
 int IEqualityComparer<object>.GetHashCode(object obj)
 {
  return RuntimeHelpers.GetHashCode(obj);
 }//GetHashCode
};//class Structure_LegacyReferenceEqualityComparer

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
