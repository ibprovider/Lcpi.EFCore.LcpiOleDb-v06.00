////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.05.2018.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//struct Structure_ValueWithNull

struct Structure_ValueWithNull<T>
{
 public Structure_ValueWithNull(T Value,bool IsNull)
 {
  m_HasValue=!IsNull;

  m_Value=Value;
 }//Structure_ValueWithNull

 //-----------------------------------------------------------------------
 public Structure_ValueWithNull(T Value)
 {
  m_HasValue=true;

  m_Value=Value;
 }//Structure_ValueWithNull

 //Modificators ----------------------------------------------------------
 public Structure_ValueWithNull<T> SetValue(T Value)
 {
  m_Value=Value;

  m_HasValue=true;

  return this;
 }//SetValue

 //-----------------------------------------------------------------------
 public Structure_ValueWithNull<T> Reset()
 {
  m_Value=default(T);

  m_HasValue=false;

  return this;
 }//Reset

 //Selectors -------------------------------------------------------------
 public object GetAsDBValue()
 {
  if(!m_HasValue)
   return DBNull.Value;

  return m_Value;
 }//GetAsDBValue

 //-----------------------------------------------------------------------
 public T GetValueOrDefault(T defaultValue)
 {
  if(!m_HasValue)
   return defaultValue;

  return m_Value;
 }//GetValueOrDefault

 //-----------------------------------------------------------------------
 public bool IsNull
 {
  get
  {
   return !m_HasValue;
  }
 }//IsNull

 //-----------------------------------------------------------------------
 public T Value
 {
  get
  {
   Debug.Assert(m_HasValue);

   return m_Value;
  }
 }//IsNull

 //private data ----------------------------------------------------------
 private bool m_HasValue;
 private T    m_Value;
};//struct Structure_ValueWithNull<T>

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
