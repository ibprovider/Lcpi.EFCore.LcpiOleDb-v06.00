////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 09.12.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Translators{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MethodIdCache
 =Structure.Structure_MethodIdCache;

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

using Structure_ExpressionUtils
 =Structure.Structure_ExpressionUtils;

using Root.Query.Local.Extensions.LcpiOleDb__LocalEval_Services__Extensions;

////////////////////////////////////////////////////////////////////////////////
//class ETranslator__String__std__Concat__obj3

sealed class ETranslator__String__std__Concat__obj3
 :Root.Query.Local.LcpiOleDb__LocalEval_MethodCallTranslator
{
 public static readonly Root.Query.Local.LcpiOleDb__LocalEval_MethodCallTranslator
  Instance
   =new ETranslator__String__std__Concat__obj3();

 //-----------------------------------------------------------------------
 private ETranslator__String__std__Concat__obj3()
  :base(Structure_MethodIdCache.MethodIdOf__String__std__Concat__obj3)
 {
 }//ETranslator__String__std__Concat__obj3

 //interface -------------------------------------------------------------
 public override Expression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(!Object.ReferenceEquals(opData.ExpressionServices,null));

  Debug.Assert(opData.MethodId==Structure_MethodInfoCache.MethodInfoOf__String__std__Concat__obj3);

  //----------------------------------------
  Debug.Assert(Object.ReferenceEquals(opData.CallObject,null));

  Debug.Assert(!Object.ReferenceEquals(opData.Arguments,null));
  Debug.Assert(opData.Arguments.Count==3);

  //----------------------------------------
  var node_Arg0
   =opData.Arguments[0];

  Debug.Assert(!Object.ReferenceEquals(node_Arg0,null));
  Debug.Assert(!Object.ReferenceEquals(node_Arg0.Type,null));

  //----------------------------------------
  var node_Arg1
   =opData.Arguments[1];

  Debug.Assert(!Object.ReferenceEquals(node_Arg1,null));
  Debug.Assert(!Object.ReferenceEquals(node_Arg1.Type,null));

  //----------------------------------------
  var node_Arg2
   =opData.Arguments[2];

  Debug.Assert(!Object.ReferenceEquals(node_Arg2,null));
  Debug.Assert(!Object.ReferenceEquals(node_Arg2.Type,null));

  //----------------------------------------
  var expr0
   =Structure_ExpressionUtils.RemoveConvertToObject
     (node_Arg0);

  Debug.Assert(!Object.ReferenceEquals(expr0,null));
  Debug.Assert(!Object.ReferenceEquals(expr0.Type,null));

  var expr1
   =Structure_ExpressionUtils.RemoveConvertToObject
     (node_Arg1);

  Debug.Assert(!Object.ReferenceEquals(expr1,null));
  Debug.Assert(!Object.ReferenceEquals(expr1.Type,null));

  var expr2
   =Structure_ExpressionUtils.RemoveConvertToObject
     (node_Arg2);

  Debug.Assert(!Object.ReferenceEquals(expr2,null));
  Debug.Assert(!Object.ReferenceEquals(expr2.Type,null));

  //----------------------------------------
  var r1
   =opData.ExpressionServices.Extension__MakeBinary__Concat__Throw
    (expr0,
     expr1);

  Debug.Assert(!Object.ReferenceEquals(r1,null));

  //----------------------------------------
  var r2
   =opData.ExpressionServices.Extension__MakeBinary__Concat__Throw
    (r1,
     expr2);

  Debug.Assert(!Object.ReferenceEquals(r2,null));

  return r2;
 }//Translate
};//class ETranslator__String__std__Concat__obj3

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Translators
