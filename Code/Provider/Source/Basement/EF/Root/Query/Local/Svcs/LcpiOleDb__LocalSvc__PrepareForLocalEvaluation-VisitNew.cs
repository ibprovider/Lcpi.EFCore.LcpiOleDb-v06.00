////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.06.2021.
using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Svcs{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_ArrayAllocators
 =Structure.Structure_ArrayAllocators;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation

sealed partial class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation
{
 protected override Expression VisitNew(NewExpression node)
 {
  Debug.Assert(!Object.ReferenceEquals(node,null));

  //-------------------------------------------------------
  const string c_bugcheck_src
   ="LcpiOleDb__LocalSvc__PrepareForLocalEvaluation::VisitNew";

  //-------------------------------------------------------
  var newArgs
   =this.Helper__VisitArguments
     (node);

  Debug.Assert(!Object.ReferenceEquals(newArgs,null));

  var objectType_u
   =node.Type.Extension__SwitchToUnderlying();

  Debug.Assert(!Object.ReferenceEquals(objectType_u,null));

  if(objectType_u==node.Type)
  {
   return node.Update(newArgs); //throw
  }//if

  //----------------------------------------
  var newArgTypes
   =Structure_ArrayAllocators.Alloc_Array_Of_SystemType(newArgs.Length);

  Debug.Assert(!Object.ReferenceEquals(newArgTypes,null));

  for(int i=0,n=newArgs.Length;i!=n;++i)
  {
   Debug.Assert(!Object.ReferenceEquals(newArgs[i],null));
   Debug.Assert(!Object.ReferenceEquals(newArgs[i].Type,null));

   newArgTypes[i]
    =newArgs[i].Type;
  }//for i

  Expression node2;

  if(Object.ReferenceEquals(node.Constructor,null))
  {
   //NO CONSTRUCTOR

   if(newArgTypes.Length!=0)
   {
    ThrowBugCheck.not_empty_argument_list
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      newArgs.Length);
   }//if

   Debug.Assert(newArgTypes.Length==0);

   node2
    =Expression.New
      (objectType_u);

   Debug.Assert(!Object.ReferenceEquals(node2,null));
  }
  else
  {
   //
   // [2020-01-15] Simple way. A search and usage of constructor with required types.
   //

   ConstructorInfo
    ctrl
     =objectType_u.GetConstructor
       (newArgTypes);

   if(Object.ReferenceEquals(ctrl,null))
   {
    // ERROR - constructor not found

    ThrowError.LocalEvalErr__CantRemapObjectCreation
     (c_ErrSrcID,
      node.Type,
      objectType_u,
      newArgs);

    Debug.Assert(false);
   }//if

   Debug.Assert(!Object.ReferenceEquals(ctrl,null));

   node2
    =Expression.New
      (ctrl,
       newArgs);

   Debug.Assert(!Object.ReferenceEquals(node2,null));
  }//else

  Debug.Assert(!Object.ReferenceEquals(node2,null));

  return node2;
 }//VisitNew

 //Helper methods --------------------------------------------------------
 private Expression[] Helper__VisitArguments(IArgumentProvider nodes)
 {
  Debug.Assert(!Object.ReferenceEquals(nodes,null));
  Debug.Assert(nodes.ArgumentCount>=0);

  const string c_bugcheck_src
   ="LcpiOleDb__LocalSvc__PrepareForLocalEvaluation::Helper__VisitArguments";

  var cArguments
   =nodes.ArgumentCount;

  var newNodes
   =Structure_ArrayAllocators.Alloc_Array_Of_LinqExpression(cArguments);

  Debug.Assert(!Object.ReferenceEquals(newNodes,null));

  for(int i=0;i!=cArguments;++i)
  {
   Expression curNode=nodes.GetArgument(i);

   Check.BugCheck_Value_NotNull
    (c_ErrSrcID,
     c_bugcheck_src,
     "#001",
     nameof(curNode),
     curNode);

   //-------------------------
   Expression
    node
     =this.Visit(curNode);

   Check.BugCheck_Value_NotNull
    (c_ErrSrcID,
     c_bugcheck_src,
     "#002",
     nameof(node),
     node);

   Debug.Assert(!Object.ReferenceEquals(node,null));

   //-------------------------
   newNodes[i]=node;
  }//for i

  return newNodes;
 }//Helper__VisitArguments
};//class LcpiOleDb__LocalSvc__PrepareForLocalEvaluation

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Svcs
