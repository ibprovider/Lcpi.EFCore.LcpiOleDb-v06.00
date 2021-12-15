////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 28.11.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Migrations;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations{
////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__HistoryRepository

sealed class FB_V03_0_0__HistoryRepository
 :/*[2021-11-28] Give me poison*/ HistoryRepository
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_V03_0_0__HistoryRepository;

 //-----------------------------------------------------------------------
 public FB_V03_0_0__HistoryRepository(HistoryRepositoryDependencies dependencies)
  :base(dependencies)
 {
 }

 //HistoryRepository interface -------------------------------------------
 protected override string ExistsSql
 {
  get
  {
   if(!Object.ReferenceEquals(this.TableSchema,null))
   {
    ThrowError.DbmsErr__FB__FirebirdDoesNotSupportSchemas
     (c_ErrSrcID);
   }//if

   Debug.Assert(Object.ReferenceEquals(this.TableSchema,null));

   if(string.IsNullOrEmpty(this.TableName))
   {
    ThrowError.MSqlGenErr__TableNameNotDefined(c_ErrSrcID);
   }//if

   string sql
    ="SELECT COUNT(*) FROM RDB$RELATIONS WHERE RDB$RELATION_NAME="
    +Common.FB_Common__Utilities.TextToSqlLiteral(this.TableName);

   return sql;
  }//get
 }//ExistsSql

 //-----------------------------------------------------------------------
 protected override bool InterpretExistsResult(object value)
 {
  const string c_bugcheck_src
   ="FB_V03_0_0__HistoryRepository::InterpretExistsResult";

  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#001",
    nameof(value),
    value);

  var valueType
   =value.GetType();

  if(valueType==Structure.Structure_TypeCache.TypeOf__System_Int32)
  {
   //OK
  }
  else
  if(valueType==Structure.Structure_TypeCache.TypeOf__System_Int64)
  {
   //OK
  }
  else
  {
   ThrowBugCheck.unexpected_value_type
    (c_ErrSrcID,
     c_bugcheck_src,
     "#002",
     nameof(value),
     valueType);
  }//else

  var valueAsLong
   =System.Convert.ToInt64(value);

  switch(valueAsLong)
  {
   case 0:
    return false;

   case 1:
    return true;

   default:
   {
    ThrowBugCheck.unexpected_value
     (c_ErrSrcID,
      c_bugcheck_src,
      "#003",
      nameof(valueAsLong),
      valueAsLong);

    break;
   }//default
  }//switch

  return false;
 }//InterpretExistsResult

 //-----------------------------------------------------------------------
 public override string GetCreateIfNotExistsScript()
 {
  ThrowSysError.method_not_impl
   (c_ErrSrcID,
    nameof(GetCreateIfNotExistsScript),
    "#001");

  return null;
 }//GetCreateIfNotExistsScript

 //-----------------------------------------------------------------------
 public override string GetBeginIfNotExistsScript(string migrationId)
 {
  ThrowSysError.method_not_impl
   (c_ErrSrcID,
    nameof(GetBeginIfNotExistsScript),
    "#001");

  return null;
 }//GetBeginIfNotExistsScript

 //-----------------------------------------------------------------------
 public override string GetBeginIfExistsScript(string migrationId)
 {
  ThrowSysError.method_not_impl
   (c_ErrSrcID,
    nameof(GetBeginIfExistsScript),
    "#001");

  return null;
 }//GetBeginIfExistsScript

 //-----------------------------------------------------------------------
 public override string GetEndIfScript()
 {
  ThrowSysError.method_not_impl
   (c_ErrSrcID,
    nameof(GetEndIfScript),
    "#001");

  return null;
 }//GetEndIfScript
};//class FB_V03_0_0__HistoryRepository

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations
