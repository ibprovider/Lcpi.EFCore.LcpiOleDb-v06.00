////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.02.2021.
using System;
using System.Diagnostics;

using structure_lib=lcpi.lib.structure;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure{
////////////////////////////////////////////////////////////////////////////////
//class Structure_NumericDigits

partial class Structure_NumericDigits
{
 public sealed class RW:Structure_NumericDigits
 {
  private const ErrSourceID
   c_ErrSrcID
    =ErrSourceID.Structure_NumericDigits_RW;

  //----------------------------------------------------------------------
  public RW(int nCapacity)
  {
   m_Data=((nCapacity==0)?null:new byte[nCapacity]);
  }//RW

  //Interface ------------------------------------------------------------
  public void Reset()
  {
   m_Size=0;

   m_Scale=0;

   m_MantisseSign=Structure_NumberSign.Undefined;

   m_Data=null;
  }//Reset

  //-----------------------------------------------------------------------
  public void SetMantisseSign(Structure_NumberSign sign)
  {
   m_MantisseSign=sign;
  }//SetMantisseSign

  //-----------------------------------------------------------------------
  public void SetDigit(int index,byte value)
  {
   Debug.Assert(index>=0);
   Debug.Assert(index<int.MaxValue);

   Debug.Assert(value>=0);
   Debug.Assert(value<=9);

   Debug.Assert(index<this.Helper__GetCapacity());

   Debug.Assert(m_Size<=this.Helper__GetCapacity());

   for(int i=m_Size;i<index;++i)
   {
    m_Data[i]=0;
   }//for

   m_Data[index]=value;

   if(m_Size<=index)
    m_Size=index+1;
  }//SetDigit

  //-----------------------------------------------------------------------
  public void SetScale(int value)
  {
   m_Scale=value;
  }//SetScale

  //-----------------------------------------------------------------------
  public void Clamp()
  {
   // [2021-03-02] Tested.

#if DEBUG
   this.DEBUG__CheckState();
#endif

   for(;m_Size>0;--m_Size)
   {
    if(this.GetDigit(m_Size-1)!=0)
     break;
   }//for

#if DEBUG
   this.DEBUG__CheckState();
#endif
  }//Clamp

  //-----------------------------------------------------------------------
  public void ShiftOnPositiveScale(uint n)
  {
   // [2021-03-02] Tested.

#if DEBUG
   this.DEBUG__CheckState();
#endif

   if(n==0)
    return;

   Debug.Assert(n>0);

   if(m_Size==0)
    return;

   Debug.Assert(m_Size>0);

   uint reserved_n=(uint)(m_Data.Length-m_Size);

   if(reserved_n<n)
   {
    //0. check overflow
    //1. allocate new data
    //2. copy old data to new data
    //3. assign new data

    if((int.MaxValue-m_Size)<n)
    {
     ThrowSysError.cant_alloc_new_array__overflow
      (c_ErrSrcID,
       "ShiftOnPositiveScale",
       "#001");
    }//if

    Debug.Assert(n<=(int.MaxValue-m_Size));

    int newLength=(int)(m_Size+n);

    var newData=new byte[newLength];

    int iDst=0;

    for(;iDst!=n;++iDst)
    {
     newData[iDst]=0;
    }//for iDst

    Debug.Assert(iDst==n);

    for(int iSrc=0;iSrc!=m_Size;++iSrc,++iDst)
    {
     newData[iDst]=m_Data[iSrc];
    }//for

    Debug.Assert(iDst==newData.Length);

    m_Data=newData;
   }
   else
   {
    Debug.Assert(n<=reserved_n);

    int eDst=(int)(m_Size+n);
    int eSrc=m_Size;

    for(;eSrc!=0;)
    {
     --eSrc;
     --eDst;

     m_Data[eDst]=m_Data[eSrc];
    }//for

    Debug.Assert(eSrc==0);
    Debug.Assert(eDst==n);

    for(;eDst!=0;)
    {
     --eDst;

     m_Data[eDst]=0;
    }//for

    Debug.Assert(eDst==0);
   }//else

   m_Size=(int)(m_Size+n);

#if DEBUG
   this.DEBUG__CheckState();
#endif
  }//ShiftOnPositiveScale

  //-----------------------------------------------------------------------
  public void ShiftOnNegativeScale(uint n,bool round)
  {
   // [2021-03-02] Tested.

#if DEBUG
   this.DEBUG__CheckState();
#endif

   if(n==0)
    return;

   Debug.Assert(n>0);

   if(m_Size==0)
    return;

   Debug.Assert(m_Size>0);

   if(m_Size<n)
   {
    for(int i=0;i!=m_Size;++i)
    {
     Debug.Assert(!Object.ReferenceEquals(m_Data,null));

     m_Data[i]=0;
    }//for i

    m_Size=0;
   }
   else
   {
    Debug.Assert(n<=m_Size);
    Debug.Assert(n<=int.MaxValue);

    bool makeInc=round && m_Data[n-1]>=5;

    int i=0;

    for(int s=(int)n;s!=m_Size;++s,++i)
    {
     Debug.Assert(!Object.ReferenceEquals(m_Data,null));

     m_Data[i]=m_Data[s];
    }//for s

    Debug.Assert(i<=m_Size);

    for(;i!=m_Size;++i)
    {
     Debug.Assert(!Object.ReferenceEquals(m_Data,null));

     m_Data[i]=0;
    }//for i

    Debug.Assert(i<=m_Size);

    m_Size-=(int)n;

    if(makeInc)
    {
     this.Helper__MakeInc__fast();
    }//if
   }//if n<=m_Size

#if DEBUG
   this.DEBUG__CheckState();
#endif
  }//ShiftOnNegativeScale

 //Helper methods --------------------------------------------------------
  private void Helper__MakeInc__fast()
  {
   Debug.Assert(!Object.ReferenceEquals(m_Data,null));
   Debug.Assert(m_Size<m_Data.Length);

   for(int i=0;i!=m_Size;++i)
   {
    Debug.Assert(m_Data[i]>=0);
    Debug.Assert(m_Data[i]<=9);

    int s=m_Data[i]+1;

    Debug.Assert(s>=1);
    Debug.Assert(s<=10);

    if(s<10)
    {
     m_Data[i]=(byte)s;

     return;
    }//if

    m_Data[i]=(byte)(s-10);
   }//for i

   m_Data[m_Size]=1;

   ++m_Size;
  }//Helper__MakeInc__fast

  //Debug methods --------------------------------------------------------
#if DEBUG
  private void DEBUG__CheckState()
  {
   if(Object.ReferenceEquals(m_Data,null))
   {
    Debug.Assert(m_Size==0);

    return;
   }//if

   Debug.Assert(!Object.ReferenceEquals(m_Data,null));

   Debug.Assert(m_Size>=0);
   Debug.Assert(m_Size<=m_Data.Length);

   for(int i=m_Size;i!=m_Data.Length;++i)
   {
    Debug.Assert(m_Data[i]==0);
   }//for i
  }//DEBUG__CheckState
#endif
 };//class RW
};//class Structure_NumericDigits

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Structure
