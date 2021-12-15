////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.10.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ENode_Unary__Convert.SSCode

sealed partial class FB_Common__Sql_ENode_Unary__Convert
{
 public sealed class SSCodes
 {
  public SSCodes()
  {
   m_Items=new tagLevel0();

#if DEBUG
   m_DEBUG__IsCompleted=false;
#endif
  }//SSCodes

  //interface ------------------------------------------------------------
  public SSCodes Add(System.Type fromType,
                     System.Type toType,
                     bool        canIgnore,
                     SSCode      ssCode)
  {
   Debug.Assert(!Object.ReferenceEquals(fromType,null));
   Debug.Assert(!Object.ReferenceEquals(toType,null));
   Debug.Assert(!Object.ReferenceEquals(ssCode,null));

   Debug.Assert(fromType ==fromType.Extension__UnwrapNullableType());
   Debug.Assert(toType   ==toType.Extension__UnwrapNullableType());

   Debug.Assert(fromType ==fromType.Extension__UnwrapMappingClrType());
   Debug.Assert(toType   ==toType.Extension__UnwrapMappingClrType());

   Debug.Assert(!Object.ReferenceEquals(m_Items,null));

   Debug.Assert(!Object.ReferenceEquals(ssCode,null));

   //----------------------------------------
#if DEBUG
   Debug.Assert(!m_DEBUG__IsCompleted);
#endif

   //----------------------------------------
   tagLevel1 level1=null;

   if(!m_Items.TryGetValue(fromType,out level1))
   {
    level1=new tagLevel1();

    m_Items.Add(fromType,level1); //throw
   }//if

   Debug.Assert(!Object.ReferenceEquals(level1,null));

   Debug.Assert(!level1.ContainsKey(toType));

   level1.Add
    (toType,
     new tagDescr
      {
       CanIgnore=canIgnore,
       SSCode   =ssCode
      }); //throw

   return this;
  }//Add

  //----------------------------------------------------------------------
#if DEBUG
  public SSCodes DEBUG__Complete()
  {
   Debug.Assert(!m_DEBUG__IsCompleted);

   m_DEBUG__IsCompleted=true;

   return this;
  }//DEBUG__Complete
#endif

  //----------------------------------------------------------------------
  public bool TryGet(System.Type fromType,
                     System.Type toType,
                     out bool    result_CanIgnore,
                     out SSCode  result_SSCode)
  {
   Debug.Assert(!Object.ReferenceEquals(fromType,null));
   Debug.Assert(!Object.ReferenceEquals(toType,null));

   Debug.Assert(!Object.ReferenceEquals(m_Items,null));

   //---------------------------------------
   var fromType_u
    =fromType.Extension__UnwrapMappingClrType();

   Debug.Assert(!Object.ReferenceEquals(fromType_u,null));

   var toType_u
    =toType.Extension__UnwrapMappingClrType();

   Debug.Assert(!Object.ReferenceEquals(toType_u,null));

   //---------------------------------------
   result_CanIgnore=false;

   result_SSCode=null;

   //---------------------------------------
   tagLevel1 level1=null;

   if(!m_Items.TryGetValue(fromType_u,out level1))
    return false;

   Debug.Assert(!Object.ReferenceEquals(level1,null));

   tagDescr descr;

   if(!level1.TryGetValue(toType_u,out descr))
    return false;

   Debug.Assert(!Object.ReferenceEquals(descr.SSCode,null));

   //---------------------------------------
   result_CanIgnore=descr.CanIgnore;

   result_SSCode=descr.SSCode;

   return true;
  }//TryGet

  //private types --------------------------------------------------------
  public struct tagDescr
  {
   public bool    CanIgnore;
   public SSCode  SSCode;
  };//struct tagDescr

  //map: [ToType] -> [SSCode]
  private sealed class tagLevel1:Dictionary<System.Type,tagDescr>{};

  //----------------------------------------------------------------------
  //map: [FromType] -> [tagLevel1]
  private sealed class tagLevel0:Dictionary<System.Type,tagLevel1>{};

  //private data ---------------------------------------------------------
  private readonly tagLevel0 m_Items;

#if DEBUG
  private bool m_DEBUG__IsCompleted;
#endif
 };//class SSCodes
};//class FB_Common__Sql_ENode_Unary__Convert

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Nodes
