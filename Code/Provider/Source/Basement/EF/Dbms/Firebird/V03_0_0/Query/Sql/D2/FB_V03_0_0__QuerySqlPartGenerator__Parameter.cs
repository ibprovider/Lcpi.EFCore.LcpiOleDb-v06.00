////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.07.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D2{
////////////////////////////////////////////////////////////////////////////////

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__QuerySqlPartGenerator__Parameter

sealed class FB_V03_0_0__QuerySqlPartGenerator__Parameter
 :Firebird.Common.Query.Sql.FB_Common__IQuerySqlPartGenerator__Parameter
{
 public static readonly Firebird.Common.Query.Sql.FB_Common__IQuerySqlPartGenerator__Parameter
  Instance
   =new FB_V03_0_0__QuerySqlPartGenerator__Parameter();

 //-----------------------------------------------------------------------
 private FB_V03_0_0__QuerySqlPartGenerator__Parameter()
 {
 }//FB_V03_0_0__QuerySqlPartGenerator__Parameter

 //interface -------------------------------------------------------------
 public void Exec(Common.Query.Sql.FB_Common__QuerySqlGenerator sqlGenerator,
                  SqlParameterExpression                        sqlParameterExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlGenerator,null));
  Debug.Assert(!Object.ReferenceEquals(sqlParameterExpression,null));

  //------------------------------------------------------------
  if(!Helper__CanCastParam(sqlParameterExpression))
  {
   sqlGenerator.VisitSqlParameter_base(sqlParameterExpression);
  }
  else
  {
   Debug.Assert(!Object.ReferenceEquals(sqlParameterExpression.TypeMapping.StoreType,null));

   sqlGenerator.Sql.Append("CAST(");

   sqlGenerator.VisitSqlParameter_base(sqlParameterExpression);

   sqlGenerator.Sql.Append(" AS ");

   sqlGenerator.Sql.Append(Helper__GetTargetSqlTypeName(sqlParameterExpression));

   sqlGenerator.Sql.Append(")");
  }//else
 }//Exec

 //Helper methods --------------------------------------------------------
 private static bool Helper__CanCastParam(SqlParameterExpression sqlParameterExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlParameterExpression,null));
  Debug.Assert(!Object.ReferenceEquals(sqlParameterExpression.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(sqlParameterExpression.TypeMapping.ClrType,null));

  var clearClrType
   =sqlParameterExpression.TypeMapping.ClrType.Extension__UnwrapMappingClrType();

  if(clearClrType==Structure_TypeCache.TypeOf__System_DateOnly)
  {
   //No way for second dialect

   return false;
  }//if

  if(clearClrType==Structure_TypeCache.TypeOf__System_Decimal)
  {
   if(sqlParameterExpression.TypeMapping.Precision.HasValue)
    return true;

   Debug.Assert(!sqlParameterExpression.TypeMapping.Scale.HasValue);

   return false;
  }//if

  return true;
 }//Helper__CanCastParam

 //-----------------------------------------------------------------------
 private static string Helper__GetTargetSqlTypeName(SqlParameterExpression sqlParameterExpression)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlParameterExpression,null));
  Debug.Assert(!Object.ReferenceEquals(sqlParameterExpression.TypeMapping,null));
  Debug.Assert(!Object.ReferenceEquals(sqlParameterExpression.TypeMapping.StoreType,null));

  return sqlParameterExpression.TypeMapping.StoreType;
 }//Helper__GetTargetSqlTypeName
};//class FB_V03_0_0__QuerySqlPartGenerator__Parameter

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D2
