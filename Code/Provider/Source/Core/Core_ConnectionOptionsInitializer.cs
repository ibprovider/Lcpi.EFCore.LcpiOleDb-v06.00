////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 24.05.2018.
using System;
using System.Diagnostics;
using System.Data.Common;

using xdb=lcpi.data.oledb;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class Core_ConnectionOptionsInitializer

static class Core_ConnectionOptionsInitializer
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Core_ConnectionOptionsInitializer;

 //-----------------------------------------------------------------------
 public static void Exec(Core_ConnectionOptionsData cnData,
                         DbConnection               cn)
 {
  Debug.Assert(!Object.ReferenceEquals(cnData,null));
  Debug.Assert(!Object.ReferenceEquals(cn,null));

  //----------------------------------------
  const string c_bug_check_place
   ="Core_ConnectionOptionsInitializer::Exec(cnData,cn)";

  //---------------------------------------- get info schema
  var schemaInfo
   =cn.GetSchema(xdb.OleDbMetaDataCollectionNames.DataSourceInformation);

  Debug.Assert(!Object.ReferenceEquals(schemaInfo,null));

  var schemaInfoRows=schemaInfo.Rows;

  Debug.Assert(!Object.ReferenceEquals(schemaInfoRows,null));

  if(schemaInfoRows.Count!=1)
  {
   //[BUG CHECK] schemaInfo contains unexpected row count

   ThrowBugCheck.schema_contains_unexpected_row_count
    (c_ErrSrcID,
     c_bug_check_place,
     "#001",
     schemaInfo.TableName,
     schemaInfoRows.Count);
  }//if

  Debug.Assert(schemaInfoRows.Count==1);

  var rowInfo=schemaInfoRows[0];

  Debug.Assert(!Object.ReferenceEquals(rowInfo,null));

  //---------------------------------------- SERVER NAME
  int iCol_DataSourceProductName
   =Structure_ADP.IndexOf
     (c_ErrSrcID,
      schemaInfo,
      xdb.OleDbMetaDataCollectionColumnNames.DataSourceInformation.DataSourceProductName);

  cnData.ServerName
   =Structure_ADP.GetString2_NN
     (c_ErrSrcID,
      rowInfo,
      iCol_DataSourceProductName);

  //---------------------------------------- SERVER VERSION
  cnData.ServerVersion
   =new Version(cn.ServerVersion);

  //----------------------------------------
  if(Structure_ADP.EqualDbmsName(cnData.ServerName,Engines.Dbms.DBMS__ID.Firebird))
  {
   Engines.Dbms.Firebird.FB_ConnectionInitializer.Exec
    (cnData,
     rowInfo);
  }
  else
  {
   //ERROR - unexpected dbms name

   ThrowError.UnknownDbmsName
    (c_ErrSrcID,
     cnData.ServerName);
  }//else

  //---------------------------------------- COMMON: EngineSvc__CommandParameterNameBuilder
  int iCol_LCPI_ParameterPrefix
   =Structure_ADP.IndexOf
     (c_ErrSrcID,
      schemaInfo,
      xdb.OleDbMetaDataCollectionColumnNames.DataSourceInformation.LCPI_ParameterPrefix);

  string value__LCPI_ParameterPrefix
   =Structure_ADP.GetString2_NN
     (c_ErrSrcID,
      rowInfo,
      iCol_LCPI_ParameterPrefix);

  Debug.Assert(!Object.ReferenceEquals(value__LCPI_ParameterPrefix,null));

  int iCol_LCPI_ParameterPrefixInName
   =Structure_ADP.IndexOf
     (c_ErrSrcID,
      schemaInfo,
      xdb.OleDbMetaDataCollectionColumnNames.DataSourceInformation.LCPI_ParameterPrefixInName);

  bool value__LCPI_ParameterPrefixInName
   =Structure_ADP.GetBoolean_NN
     (c_ErrSrcID,
      rowInfo,
      iCol_LCPI_ParameterPrefixInName);

  cnData.RegService
   (Engines.EngineSvcID.EngineSvc__CommandParameterNameBuilder,
    Helper__CreateEngineSvc__CommandParamereterNameBuilder
     (value__LCPI_ParameterPrefix,
      value__LCPI_ParameterPrefixInName));
 }//Exec

 //Helper methods --------------------------------------------------------
 private static Core_Svc
  Helper__CreateEngineSvc__CommandParamereterNameBuilder
   (string ParameterPrefix,
    bool   ParameterPrefixInName) 
 {
  Debug.Assert(!Object.ReferenceEquals(ParameterPrefix,null));

  if(ParameterPrefix.Length==0)
   return Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__Error_NoPrefix.Create();

  if(ParameterPrefixInName)
   return Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithPrefix.Create(ParameterPrefix);

  return Engines.Common.Common_EngineSvc__CommandParamereterNameBuilder__NameWithoutPrefix.Create(ParameterPrefix);
 }//Helper__CreateEngineSvc__CommandParamereterNameBuilder
};//class Core_ConnectionOptionsInitializer

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core
