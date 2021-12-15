////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 25.04.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations{
////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__MigrationsSqlGenerator

sealed partial class FB_V03_0_0__MigrationsSqlGenerator
{
 //MigrationsSqlGenerator interface --------------------------------------
 protected override void DefaultValue(object                      defaultValue,
                                      string                      defaultValueSql,
                                      string                      columnType,
                                      MigrationCommandListBuilder builder)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(DefaultValue),
    nameof(builder),
    builder);

  //--------------------------------------------------
  string preparedDefaultValue
   =Helper__PrepareDefaultValue
     (defaultValue,
      defaultValueSql);

  if(!Object.ReferenceEquals(preparedDefaultValue,null))
  {
   Helper__GenerateSQL_DefaultValue
    (builder,
     preparedDefaultValue);

   return;
  }//if

  Debug.Assert(Object.ReferenceEquals(preparedDefaultValue,null));
 }//DefaultValue

 //Helper methods --------------------------------------------------------
 private string Helper__PrepareDefaultValue(object defaultValue,
                                            string defaultValueSql)
 {
  if(!Object.ReferenceEquals(defaultValue,null))
  {
   if(!Object.ReferenceEquals(defaultValueSql,null))
    ThrowError.MSqlGenErr__DetectedMultipleDefinitionOfDefaultValue(c_ErrSrcID);

   return Helper__PrepareDefaultValue(defaultValue);
  }//if defaultValue==null

  Debug.Assert(Object.ReferenceEquals(defaultValue,null));

  if(!Object.ReferenceEquals(defaultValueSql,null))
  {
   return Helper__PrepareDefaultValueSql(defaultValueSql);
  }//if defaultValueSql==null

  Debug.Assert(Object.ReferenceEquals(defaultValueSql,null));

  return null;
 }//Helper__PrepareDefaultValue

 //-----------------------------------------------------------------------
 private string Helper__PrepareDefaultValue(object defaultValue)
 {
  var typeMapping
   =this.Dependencies.TypeMappingSource.GetMappingForValue
     (defaultValue);

  if(Object.ReferenceEquals(typeMapping,null))
  {
   ThrowError.MSqlGenErr__CantFindTypeMappingForDefaultValue
    (c_ErrSrcID,
     defaultValue.GetType());
  }//if

  Debug.Assert(!Object.ReferenceEquals(typeMapping,null));

  var valueSqlLiteral
   =typeMapping.GenerateSqlLiteral
     (defaultValue);

  Debug.Assert(!Object.ReferenceEquals(valueSqlLiteral,null));

  Debug.Assert(valueSqlLiteral.Length>0);

  return valueSqlLiteral;
 }//Helper__PrepareDefaultValue

 //-----------------------------------------------------------------------
 private static string Helper__PrepareDefaultValueSql(string defaultValueSql)
 {
  Debug.Assert(!Object.ReferenceEquals(defaultValueSql,null));

  var trimmed_defaultValueSql
   =defaultValueSql.Trim();

  if(trimmed_defaultValueSql.Length==0)
  {
   //! \todo throw invalid operation exception?

   ThrowSysError.argument_is_empty
    (c_ErrSrcID,
     nameof(defaultValueSql),
     nameof(defaultValueSql));
  }//if

  Debug.Assert(trimmed_defaultValueSql.Length>0);

  return trimmed_defaultValueSql;
 }//Helper__PrepareDefaultValueSql

 //-----------------------------------------------------------------------
 private static void Helper__GenerateSQL_DefaultValue
                                           (MigrationCommandListBuilder builder,
                                            string                      defaultValueSql)
 {
  Debug.Assert(!Object.ReferenceEquals(builder,null));
  Debug.Assert(!Object.ReferenceEquals(defaultValueSql,null));

  Debug.Assert(defaultValueSql.Length>0);

  Debug.Assert(defaultValueSql.Trim()==defaultValueSql);

  //-------------------------------------------------------
  builder.Append(" DEFAULT ");

  builder.Append(defaultValueSql);
 }//Helper__GenerateSQL_DefaultValue
};//class FB_V03_0_0__MigrationsSqlGenerator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations
