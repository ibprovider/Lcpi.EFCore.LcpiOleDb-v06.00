////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.11.2020.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__Dummy__MethodNotSupportedInCurrentCnDialect

sealed class FB_Common__Sql_ETranslator__Dummy__MethodNotSupportedInCurrentCnDialect
 :FB_Common__Sql_ETranslator_MethodCall
{
 public static readonly FB_Common__Sql_ETranslator_MethodCall
  Instance
   =new FB_Common__Sql_ETranslator__Dummy__MethodNotSupportedInCurrentCnDialect();

 //-----------------------------------------------------------------------
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ETranslator__Dummy__MethodNotSupportedInCurrentCnDialect;

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__Dummy__MethodNotSupportedInCurrentCnDialect
                                           ()
 {
 }//FB_Common__Sql_ETranslator__Dummy__MethodNotSupportedInCurrentCnDialect

 //MethodTranslator interface --------------------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.MethodId,null));
  Debug.Assert(!Object.ReferenceEquals(opData.CnOptions,null));

#if DEBUG
  //opData.DEBUG_CheckMemberId(this.MemberId);
#endif

  //----------------------------------------
  var cnInfoCns
   =Core.Core_SvcUtils.QuerySvc<Core.Engines.Dbms.IscBase.IscBase_EngineSvc__ConnectionInfo>
     (opData.CnOptions,
      Core.Engines.EngineSvcID.IscBase_EngineSvc__ConnectionInfo);

  Debug.Assert(!Object.ReferenceEquals(cnInfoCns,null));

  //----------------------------------------
  ThrowError.SqlGenErr__TranslationOfMemberNotSupportedInCurrentCnDialect
   (c_ErrSrcID,
    cnInfoCns.ConnectionDialect,
    opData.MethodId);

  Debug.Assert(false);

  return null;
 }//Translate
};//class FB_Common__Sql_ETranslator__Dummy__MethodNotSupportedInCurrentCnDialect

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal
