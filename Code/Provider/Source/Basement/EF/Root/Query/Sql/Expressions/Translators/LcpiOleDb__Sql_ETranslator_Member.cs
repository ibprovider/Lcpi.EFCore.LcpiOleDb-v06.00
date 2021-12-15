////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 06.05.2019.
using System;
using System.Diagnostics;
using System.Reflection;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Sql.Expressions.Translators{
////////////////////////////////////////////////////////////////////////////////
//using

using LcpiOleDb__ISqlTreeNodeBuilder
 =Root.Query.LcpiOleDb__ISqlTreeNodeBuilder;

using LcpiOleDb__SqlExpressionFactory
 =Root.Query.LcpiOleDb__SqlExpressionFactory;

using Structure_MemberId
 =Structure.Structure_MemberId;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__Sql_ETranslator_Member

abstract class LcpiOleDb__Sql_ETranslator_Member
{
 public struct tagDescr
 {
  public readonly Structure_MemberId MemberId;

  public readonly LcpiOleDb__Sql_ETranslator_Member Translator;

  //------------------------------------------------------------
  public tagDescr(Structure_MemberId                memberId,
                  LcpiOleDb__Sql_ETranslator_Member translator)
  {
   Debug.Assert(!Object.ReferenceEquals(memberId,null));
   Debug.Assert(!Object.ReferenceEquals(translator,null));

   this.MemberId   =memberId;
   this.Translator =translator;
  }//tagDescr
 };//struct tagDescr

 //-----------------------------------------------------------------------
 public struct tagOpData
 {
  public readonly MemberInfo Member;

  public readonly SqlExpression Instance;

  public readonly LcpiOleDb__ISqlTreeNodeBuilder SqlTreeNodeBuilder;

  public readonly LcpiOleDb__SqlExpressionFactory SqlExpressionFactory;

  public readonly Core.Core_ConnectionOptions CnOptions;

  //------------------------------------------------------------
  public tagOpData(MemberInfo                      member,
                   SqlExpression                   instance,
                   LcpiOleDb__ISqlTreeNodeBuilder  sqlTreeNodeBuilder,
                   LcpiOleDb__SqlExpressionFactory sqlExpressionFactory,
                   Core.Core_ConnectionOptions     cnOptions)
  {
   Debug.Assert(!Object.ReferenceEquals(member,null));
   Debug.Assert(!Object.ReferenceEquals(sqlTreeNodeBuilder,null));
   Debug.Assert(!Object.ReferenceEquals(sqlExpressionFactory,null));
   Debug.Assert(!Object.ReferenceEquals(cnOptions,null));

   //----------
   this.Member=member;

   this.Instance=instance;

   this.SqlTreeNodeBuilder=sqlTreeNodeBuilder;

   this.SqlExpressionFactory=sqlExpressionFactory;

   this.CnOptions=cnOptions;

   //----------
   Debug.Assert(!Object.ReferenceEquals(this.Member,null));
   //Debug.Assert(!Object.ReferenceEquals(this.Expression,null));
   Debug.Assert(!Object.ReferenceEquals(this.SqlTreeNodeBuilder,null));
   Debug.Assert(!Object.ReferenceEquals(this.SqlExpressionFactory,null));
   Debug.Assert(!Object.ReferenceEquals(this.CnOptions,null));
  }//tagOpData

  //----------------------------------------------------------------------
#if DEBUG
  public void DEBUG_CheckMemberId(Structure_MemberId id)
  {
   Debug.Assert(!Object.ReferenceEquals(id,null));

   Debug.Assert(id.MemberIsStatic==Object.ReferenceEquals(this.Instance,null));

   Debug.Assert(id.MemberName==this.Member.Name);

   Debug.Assert(!Object.ReferenceEquals(id.ObjectType,null));

   var expectedObjectType
    =Core.SQL.Core_SQL__MemberIdBuilder.DEBUG__MakeObjectType
      (this.Instance,
       this.Member);

   Debug.Assert(!Object.ReferenceEquals(expectedObjectType,null));

   Debug.Assert(id.ObjectType.Equals(expectedObjectType));
  }//DEBUG_CheckMemberId
#endif
 };//struct tagOpData

 //-----------------------------------------------------------------------
 public LcpiOleDb__Sql_ETranslator_Member()
 {
 }//LcpiOleDb__Sql_ETranslator_Member

 //interface -------------------------------------------------------------
 public abstract SqlExpression Translate(in tagOpData opData);
};//class LcpiOleDb__Sql_ETranslator_Member

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Sql.Expressions.Translators
