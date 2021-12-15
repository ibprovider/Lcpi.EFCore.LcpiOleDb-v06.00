////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.02.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_NumericDigits

partial class Structure_NumericDigits
{
 private Structure_NumericDigits()
 {
  m_MantisseSign=Structure_NumberSign.Undefined;

  m_Scale=0;

  m_Size=0;

  m_Data=null;
 }//Structure_NumericDigits

 //Interface -------------------------------------------------------------
 public bool IsEmpty
 {
  get
  {
   return m_Size==0;
  }//get
 }//IsEmpty

 //-----------------------------------------------------------------------
 public int Size
 {
  get
  {
   return m_Size;
  }//get
 }//Size

 //-----------------------------------------------------------------------
 public int Scale
 {
  get
  {
   return m_Scale;
  }//get
 }//Scale

 //-----------------------------------------------------------------------
 public Structure_NumberSign MantisseSign
 {
  get
  {
   return m_MantisseSign;
  }//get
 }//MantisseSign

 //-----------------------------------------------------------------------
 public byte GetDigit(int index)
 {
  Debug.Assert(index<m_Size);

  Debug.Assert(!Object.ReferenceEquals(m_Data,null));

  Debug.Assert(m_Size<=m_Data.Length);

  Debug.Assert(m_Data[index]>=0);
  Debug.Assert(m_Data[index]<=9);

  return m_Data[index];
 }//GetDigit

 //-----------------------------------------------------------------------
 public RW Clone()
 {
  var result=new RW(/*capacity*/this.Size);

  for(int i=0,_c=this.Size;i!=_c;++i)
  {
   result.SetDigit(i,this.GetDigit(i));
  }//for i

  Debug.Assert(this.Size==result.Size);

  result.SetMantisseSign(this.MantisseSign);

  result.SetScale(this.Scale);

  return result;
 }//Clone

 //Helper methods --------------------------------------------------------
 protected int Helper__GetCapacity()
 {
  if(Object.ReferenceEquals(m_Data,null))
   return 0;

  return m_Data.Length;
 }//Helper__GetCapacity

 //Private data ----------------------------------------------------------
 private Structure_NumberSign m_MantisseSign;

 private int m_Scale;

 private int m_Size;

 private byte[] m_Data;
};//class Structure_NumericDigits

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
