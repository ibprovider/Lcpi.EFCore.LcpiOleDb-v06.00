////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 18.11.2020.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Sql_ETranslator__Dummy__MemberNotSupportedInCurrentCnDialect

sealed class FB_Common__Sql_ETranslator__Dummy__MemberNotSupportedInCurrentCnDialect
 :FB_Common__Sql_ETranslator_Member
{
 public static readonly FB_Common__Sql_ETranslator_Member
  Instance
   =new FB_Common__Sql_ETranslator__Dummy__MemberNotSupportedInCurrentCnDialect();

 //-----------------------------------------------------------------------
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Sql_ETranslator__Dummy__MemberNotSupportedInCurrentCnDialect;

 //-----------------------------------------------------------------------
 private FB_Common__Sql_ETranslator__Dummy__MemberNotSupportedInCurrentCnDialect()
 {
 }//FB_Common__Sql_ETranslator__Dummy__MemberNotSupportedInCurrentCnDialect

 //IMemberTranslator interface -------------------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(!Object.ReferenceEquals(opData.Instance,null));
  Debug.Assert(!Object.ReferenceEquals(opData.CnOptions,null));
  Debug.Assert(!Object.ReferenceEquals(opData.Member,null));

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
    opData.Member);

  Debug.Assert(false);

  return null;
 }//Translate
};//class FB_Common__Sql_ETranslator__Dummy__MemberNotSupportedInCurrentCnDialect

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql.Expressions.Translators.Internal
