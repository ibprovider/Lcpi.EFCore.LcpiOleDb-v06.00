////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 08.10.2018.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Extensions.LcpiOleDb__LocalEval_Services__Extensions{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_Services__Extensions

static class LcpiOleDb__LocalEval_Services__Extensions
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__LocalEval_Services__Extensions;

 //-----------------------------------------------------------------------
 public static Expression Extension__MakeBinary__Subtract__Throw
                             (this LcpiOleDb__LocalEval_Services services,
                              Expression                         leftArg,
                              Expression                         rightArg)
 {
  Debug.Assert(!Object.ReferenceEquals(services,null));
  Debug.Assert(!Object.ReferenceEquals(leftArg,null));
  Debug.Assert(!Object.ReferenceEquals(rightArg,null));

  return Helper__MakeBinary__Throw
          (services,
           LcpiOleDb__ExpressionType.Subtract,
           leftArg,
           rightArg);
 }//Extension__MakeBinary__Subtract__Throw

 //-----------------------------------------------------------------------
 public static Expression Extension__MakeBinary__Concat__Throw
                             (this LcpiOleDb__LocalEval_Services services,
                              Expression                         leftArg,
                              Expression                         rightArg)
 {
  Debug.Assert(!Object.ReferenceEquals(services,null));
  Debug.Assert(!Object.ReferenceEquals(leftArg,null));
  Debug.Assert(!Object.ReferenceEquals(rightArg,null));

  return Helper__MakeBinary__Throw
          (services,
           LcpiOleDb__ExpressionType.Concat,
           leftArg,
           rightArg);
 }//Extension__MakeBinary__Concat__Throw

 //Helper methods --------------------------------------------------------
 private static Expression Helper__MakeBinary__Throw
                             (this LcpiOleDb__LocalEval_Services services,
                              LcpiOleDb__ExpressionType          op2ID,
                              Expression                         leftArg,
                              Expression                         rightArg)
 {
  Debug.Assert(!Object.ReferenceEquals(services,null));
  Debug.Assert(!Object.ReferenceEquals(leftArg,null));
  Debug.Assert(!Object.ReferenceEquals(leftArg.Type,null));
  Debug.Assert(!Object.ReferenceEquals(rightArg,null));
  Debug.Assert(!Object.ReferenceEquals(rightArg.Type,null));

  LcpiOleDb__LocalEval_Op2__Descr
   op2Descr
    =default;

  services.GetOp2Descr
   (c_ErrSrcID,
    op2ID,
    leftArg.Type,
    rightArg.Type,
    out op2Descr);

  Debug.Assert(!Object.Equals(op2Descr.Translator,null));

  var opData
   =new LcpiOleDb__LocalEval_BinaryTranslator.tagOpData
     (leftArg,
      rightArg,
      services);

  var resutExpression
   =op2Descr.Translator.Translate
     (/*in*/opData);

  Debug.Assert(!Object.ReferenceEquals(resutExpression,null));

  return resutExpression;
 }//Helper__MakeBinary__Throw
};//class LcpiOleDb__LocalEval_Services__Extensions

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Extensions.LcpiOleDb__LocalEval_Services__Extensions
