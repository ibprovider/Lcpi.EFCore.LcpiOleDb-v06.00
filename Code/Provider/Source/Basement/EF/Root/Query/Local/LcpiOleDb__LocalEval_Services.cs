////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 08.01.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_Services

sealed class LcpiOleDb__LocalEval_Services
{
 private LcpiOleDb__LocalEval_Services(Core.Core_TextServices                     TextServices,
                                       LcpiOleDb__LocalEval_Convert__Map          EConvertDescrs,
                                       LcpiOleDb__LocalEval_Op1__Map              Op1Map,
                                       LcpiOleDb__LocalEval_Op2__Map              Op2Map,
                                       LcpiOleDb__LocalEval_MethodCallTranslators MethodCallTranslators)
 {
  Debug.Assert(!Object.ReferenceEquals(TextServices,null));
  Debug.Assert(!Object.ReferenceEquals(EConvertDescrs,null));
  Debug.Assert(!Object.ReferenceEquals(Op1Map,null));
  Debug.Assert(!Object.ReferenceEquals(Op2Map,null));
  Debug.Assert(!Object.ReferenceEquals(MethodCallTranslators,null));

  //----------------------------------------
  m_EConvertDescrs=EConvertDescrs;

  m_Op1Map=Op1Map;

  m_Op2Map=Op2Map;

  m_MethodCallTranslators=MethodCallTranslators;

  //----------------------------------------
  var valueCvtCtx
   =new tagValueCvtCtx
     (TextServices,
      EConvertDescrs);

  m_ExpressionWithValueCvtCtx
   =Expression.Constant
     (valueCvtCtx,
      Structure.Structure_TypeCache.TypeOf__LcpiEF__Core_ValueCvtCtx);

  Debug.Assert(!Object.ReferenceEquals(m_ExpressionWithValueCvtCtx,null));

  //----------------------------------------
  var op2Provider
   =new tagOp2Provider
     (Op2Map);

  //----------------------------------------
  var execCtx
   =new tagExecCtx
     (valueCvtCtx,
      op2Provider);

  m_ExpressionWithExecCtx
   =Expression.Constant
     (execCtx,
      Structure.Structure_TypeCache.TypeOf__LcpiEF__Core_OperationCtx);

  Debug.Assert(!Object.ReferenceEquals(m_ExpressionWithExecCtx,null));
 }//LcpiOleDb__LocalEval_Services

 //-----------------------------------------------------------------------
 public static LcpiOleDb__LocalEval_Services Create(Core.Core_TextServices                     TextServices,
                                                    LcpiOleDb__LocalEval_Convert__Map          EConvertDescrs,
                                                    LcpiOleDb__LocalEval_Op1__Map              Op1Map,
                                                    LcpiOleDb__LocalEval_Op2__Map              Op2Map,
                                                    LcpiOleDb__LocalEval_MethodCallTranslators MethodCallTranslators)
 {
  Debug.Assert(!Object.ReferenceEquals(TextServices,null));
  Debug.Assert(!Object.ReferenceEquals(EConvertDescrs,null));
  Debug.Assert(!Object.ReferenceEquals(Op1Map,null));
  Debug.Assert(!Object.ReferenceEquals(Op2Map,null));
  Debug.Assert(!Object.ReferenceEquals(MethodCallTranslators,null));

  //----------------------------------------
  return new LcpiOleDb__LocalEval_Services
          (TextServices,
           EConvertDescrs,
           Op1Map,
           Op2Map,
           MethodCallTranslators);
 }//Create

 //interface -------------------------------------------------------------
 public LcpiOleDb__LocalEval_MethodCallTranslators MethodCallTranslators
 {
  get
  {
   Debug.Assert(!Object.ReferenceEquals(m_MethodCallTranslators,null));

   return m_MethodCallTranslators;
  }//get
 }//MethodCallTranslators

 //-----------------------------------------------------------------------
 public bool TryGetECvtDescr(System.Type                             typeFrom,
                             System.Type                             typeTo,
                             out LcpiOleDb__LocalEval_Convert__Descr cvtDescr)
 {
  Debug.Assert(!Object.ReferenceEquals(typeFrom,null));
  Debug.Assert(!Object.ReferenceEquals(typeTo,null));

  Debug.Assert(!Object.ReferenceEquals(m_EConvertDescrs,null));

  return m_EConvertDescrs.TryGetValue
          (typeFrom,
           typeTo,
           out cvtDescr);
 }//TryGetECvtDescr

 //-----------------------------------------------------------------------
 public bool TryGetOp1Descr(ExpressionType                      opID,
                            System.Type                         type1,
                            out LcpiOleDb__LocalEval_Op1__Descr op1Descr)
 {
  Debug.Assert(!Object.ReferenceEquals(type1,null));

  // [2021-02-12]
  Debug.Assert(type1==type1.Extension__SwitchToUnderlying());

  Debug.Assert(!Object.ReferenceEquals(m_Op2Map,null));

  return m_Op1Map.TryGetValue
          (opID,
           type1,
           out op1Descr);
 }//TryGetOp1Descr

 //-----------------------------------------------------------------------
 public bool TryGetOp2Descr(LcpiOleDb__ExpressionType           opID,
                            System.Type                         type1,
                            System.Type                         type2,
                            out LcpiOleDb__LocalEval_Op2__Descr op2Descr)
 {
  Debug.Assert(!Object.ReferenceEquals(type1,null));
  Debug.Assert(!Object.ReferenceEquals(type2,null));

  // [2021-02-12]
  Debug.Assert(type1==type1.Extension__SwitchToUnderlying());
  Debug.Assert(type2==type2.Extension__SwitchToUnderlying());

  Debug.Assert(!Object.ReferenceEquals(m_Op2Map,null));

  return m_Op2Map.TryGetValue
          (opID,
           type1,
           type2,
           out op2Descr);
 }//TryGetOp2Descr

 //-----------------------------------------------------------------------
 public void GetOp2Descr(ErrSourceID                         errSrcID,
                         LcpiOleDb__ExpressionType           opID,
                         System.Type                         type1,
                         System.Type                         type2,
                         out LcpiOleDb__LocalEval_Op2__Descr op2Descr)
 {
  Debug.Assert(!Object.ReferenceEquals(type1,null));
  Debug.Assert(!Object.ReferenceEquals(type2,null));

  if(!this.TryGetOp2Descr(opID,
                          type1,
                          type2,
                          out op2Descr))
  {
   ThrowError.LocalEvalErr__BinaryOperatorNotSupported
    (errSrcID,
     opID,
     type1,
     type2);
  }//if

  Debug.Assert(!Object.ReferenceEquals(op2Descr.Translator,null));

  //OK.
 }//GetOp2Descr

 //-----------------------------------------------------------------------
 public Expression GetExpressionWithValueCvtCtx()
 {
  Debug.Assert(!Object.ReferenceEquals(m_ExpressionWithValueCvtCtx,null));

  return m_ExpressionWithValueCvtCtx;
 }//GetExpressionWithValueCvtCtx

 //-----------------------------------------------------------------------
 public Expression GetExpressionWithExecCtx()
 {
  Debug.Assert(!Object.ReferenceEquals(m_ExpressionWithExecCtx,null));

  return m_ExpressionWithExecCtx;
 }//GetExpressionWithExecCtx

 //private types ---------------------------------------------------------
 private sealed class tagValueCvtCtx
  :Core.Core_ValueCvtCtx
  ,Core.Core_SvcProvider
 {
  public tagValueCvtCtx(Core.Core_TextServices            TextServices,
                        LcpiOleDb__LocalEval_Convert__Map EConvertDescrs)
  {
   Debug.Assert(!Object.ReferenceEquals(TextServices,null));
   Debug.Assert(!Object.ReferenceEquals(EConvertDescrs,null));

   m_TextServices=TextServices;

   m_EConvertDescrs=EConvertDescrs;
  }//tagValueCvtCtx

  //Core_ValueCvtCtx interface -------------
  public Core.Core_ValueCvt GetValueCvt(System.Type typeSource,
                                        System.Type typeTarget)
  {
   Debug.Assert(!Object.ReferenceEquals(typeSource,null));
   Debug.Assert(!Object.ReferenceEquals(typeTarget,null));

   Debug.Assert(!Object.ReferenceEquals(m_EConvertDescrs,null));

   LcpiOleDb__LocalEval_Convert__Descr cvtDescr;

   if(!m_EConvertDescrs.TryGetValue(typeSource,typeTarget,out cvtDescr))
    return null;

   return cvtDescr.ValueCvt;
  }//GetValueCvt

  //Core_SvcProvider interface -------------
  public Core.Core_Svc QuerySvc(Guid SvcID)
  {
   if(SvcID==Core.Core_SvcID.Core_TextServices)
    return m_TextServices;

   return null;
  }//QuerySvc

  //----------------------------------------
  private readonly Core.Core_TextServices
   m_TextServices;

  private readonly LcpiOleDb__LocalEval_Convert__Map
   m_EConvertDescrs;
 };//class tagValueCvtCtx

 //-----------------------------------------------------------------------
 private sealed class tagOp2Provider:Core.Core_Op2Provider
 {
  public tagOp2Provider(LcpiOleDb__LocalEval_Op2__Map Op2Map)
  {
   Debug.Assert(!Object.ReferenceEquals(Op2Map,null));

   m_Op2Map=Op2Map;
  }//tagOp2Provider

  //Interface ------------------------------
  public Core.Core_Op2 GetOp2(LcpiOleDb__ExpressionType opId,
                              System.Type               typeLeft,
                              System.Type               typeRight)
  {
   Debug.Assert(!Object.ReferenceEquals(typeLeft,null));
   Debug.Assert(!Object.ReferenceEquals(typeRight,null));

   LcpiOleDb__LocalEval_Op2__Descr op2Descr=default;

   if(!m_Op2Map.TryGetValue(opId,typeLeft,typeRight,out op2Descr))
    return null;

   return op2Descr.Op2; //may be null
  }//GetOp2

  //----------------------------------------
  private readonly LcpiOleDb__LocalEval_Op2__Map
   m_Op2Map;
 };//class tagOp2Provider

 //-----------------------------------------------------------------------
 private sealed class tagExecCtx:Core.Core_OperationCtx
 {
  public tagExecCtx(Core.Core_ValueCvtCtx valueCvtCtx,
                    Core.Core_Op2Provider op2Provider)
  {
   Debug.Assert(!Object.ReferenceEquals(valueCvtCtx,null));
   Debug.Assert(!Object.ReferenceEquals(op2Provider,null));

   //-----
   m_ValueCvtCtx=valueCvtCtx;

   m_Op2Provider=op2Provider;
  }//tagExecCtx

  //----------------------------------------
  public Core.Core_Svc QuerySvc(System.Guid SvcID)
  {
   if(SvcID==Core.Core_SvcID.Core_ValueCvtCtx)
    return m_ValueCvtCtx;

   if(SvcID==Core.Core_SvcID.Core_Op2Provider)
    return m_Op2Provider;

   return null;
  }//QuerySvc

  //----------------------------------------
  private readonly Core.Core_ValueCvtCtx m_ValueCvtCtx;

  private readonly Core.Core_Op2Provider m_Op2Provider;
 };//class tagExecCtx

 //private data ----------------------------------------------------------
 private readonly LcpiOleDb__LocalEval_Convert__Map
  m_EConvertDescrs;

 private readonly LcpiOleDb__LocalEval_Op1__Map
  m_Op1Map;

 private readonly LcpiOleDb__LocalEval_Op2__Map
  m_Op2Map;

 private readonly LcpiOleDb__LocalEval_MethodCallTranslators
  m_MethodCallTranslators;

 private readonly Expression
  m_ExpressionWithValueCvtCtx;

 private readonly Expression
  m_ExpressionWithExecCtx;
};//class LcpiOleDb__LocalEval_Services

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local
