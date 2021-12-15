////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 08.06.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.MasterCode{
////////////////////////////////////////////////////////////////////////////////

using T_RESULT
 =System.Nullable<System.Boolean>;

////////////////////////////////////////////////////////////////////////////////
//class Method_MasterCode__IEnumerable_generic__Contains

static class Method_MasterCode__IEnumerable_generic__Contains
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Method_MasterCode__IEnumerable_generic__Contains;

 //-----------------------------------------------------------------------
 public static T_RESULT Exec<T_ITEM,T_VALUE>(Core.Core_OperationCtx  opCtx,
                                             IEnumerable<T_ITEM>     collection,
                                             T_VALUE                 value)
 {
  Debug.Assert(!Object.ReferenceEquals(opCtx,null));

  //----------------------------------------
  const string c_bugcheck_src
   ="Method_MasterCode__IEnumerable_generic__Contains::Exec";

  //----------------------------------------
  if(Object.ReferenceEquals(collection,null))
   return null;

  //----------------------------------------
  Core.Core_Op2Provider
   op2Provider
    =Core.Core_SvcUtils.QuerySvc<Core.Core_Op2Provider>
      (opCtx,
       Core.Core_SvcID.Core_Op2Provider); //throw

  Debug.Assert(!Object.ReferenceEquals(op2Provider,null));

  //----------------------------------------
  var typeItem =typeof(T_ITEM).Extension__SwitchToUnderlying();
  var typeValue=typeof(T_VALUE).Extension__SwitchToUnderlying();

  Debug.Assert(!Object.ReferenceEquals(typeValue,null));

  //----------------------------------------
  var op2
   =op2Provider.GetOp2
     (LcpiOleDb__ExpressionType.Equal,
      typeItem,
      typeValue); //no throw

  if(Object.ReferenceEquals(op2,null))
  {
   ThrowError.LocalEvalErr__BinaryOperatorNotSupported
    (c_ErrSrcID,
     LcpiOleDb__ExpressionType.Equal,
     typeItem,
     typeValue);
  }//if

  Debug.Assert(!Object.ReferenceEquals(op2,null));

  //----------------------------------------
  var op2_t
   =Check.BugCheck_Value_NotNullAndInstanceOf<Core.Core_Op2<T_ITEM,T_VALUE,bool>,Core.Core_Op2>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      nameof(op2),
      op2);

  Debug.Assert(!Object.ReferenceEquals(op2_t,null));

  //----------------------------------------
  foreach(T_ITEM v in collection)
  {
   bool result;

   op2_t.Exec
    (opCtx,
     v,
     value,
     out result); //throw?

   if(result)
    return true;
  }//foreach

  return false;
 }//Exec
};//class Method_MasterCode__IEnumerable_generic__Contains

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.MasterCode
