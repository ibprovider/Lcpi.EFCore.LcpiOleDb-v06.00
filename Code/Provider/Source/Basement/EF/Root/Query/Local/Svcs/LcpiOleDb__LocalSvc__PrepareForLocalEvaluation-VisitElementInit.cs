///////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.06.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Svcs{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation

sealed partial class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation
{
 protected override ElementInit VisitElementInit(ElementInit node)
 {
  Debug.Assert(!Object.ReferenceEquals(node,null));
  Debug.Assert(!Object.ReferenceEquals(node.AddMethod,null));
  Debug.Assert(!Object.ReferenceEquals(node.Arguments,null));

  //---------------------------------------- ARGUMENTS
  var newNode_Arguments
   =this.Visit(node.Arguments);

  Debug.Assert(!Object.ReferenceEquals(newNode_Arguments,null));

  //---------------------------------------- ADD METHOD
  MethodInfo
   newNode_AddMethod
    =Structure.Structure_SwitchToUnderlying.Exec
      (node.AddMethod); //throw

  Debug.Assert(!Object.ReferenceEquals(newNode_AddMethod,null));

  //---------------------------------------- BUILD NEW NODE
  var newNode
   =Expression.ElementInit
     (newNode_AddMethod,
      newNode_Arguments);

  Debug.Assert(!Object.ReferenceEquals(newNode,null));

  return newNode;
 }//VisitElementInit
};//class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Svcs
