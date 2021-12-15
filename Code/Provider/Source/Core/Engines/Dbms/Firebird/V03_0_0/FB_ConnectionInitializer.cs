////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 31.05.2018.
using System;
using System.Diagnostics;

using xdb=lcpi.data.oledb;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.V03_0_0{
////////////////////////////////////////////////////////////////////////////////
//class FB_ConnectionInitializer

/// <summary>
///  Initialization of services for connection to Firebird database
/// </summary>
static class FB_ConnectionInitializer
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Core_Engines_Dbms_FB_V03_0_0__ConnectionInitializer;

 //-----------------------------------------------------------------------
 /// <summary>
 ///  Initialization of services for connection to Firebird database
 /// </summary>
 /// <param name="Data">
 ///  Not null.
 /// </param>
 /// <param name="DsInfoRow">
 ///  Not null. Row of "DataSourceInformation" metadata collection.
 /// </param>
 public static void Exec(Core_ConnectionOptionsData Data,
                         System.Data.DataRow        DsInfoRow)
 {
  Debug.Assert(!Object.ReferenceEquals(Data,null));
  Debug.Assert(!Object.ReferenceEquals(DsInfoRow,null));
  Debug.Assert(!Object.ReferenceEquals(DsInfoRow.Table,null));
  Debug.Assert(DsInfoRow.Table.TableName==xdb.OleDbMetaDataCollectionNames.DataSourceInformation);

  //----------------------------------------------------------------------
  Data.IsMultipleActiveResultSetsEnabled
   =true;

  //----------------------------------------------------------------------

  //SVC: IscBase_EngineSvc__ConnectionInfo

  var cnInfoSvc
   =IscBase.IscBase_EngineSvc__ConnectionInfo.Create(DsInfoRow);

  Debug.Assert(!Object.ReferenceEquals(cnInfoSvc,null));

  Data.RegService
   (EngineSvcID.IscBase_EngineSvc__ConnectionInfo,
    cnInfoSvc);

  //----------------------------------------------------------------------

  //SVC: EngineSvc__ObjectIdentifierBuilder

  switch(cnInfoSvc.ConnectionDialect)
  {
   case 1:
   {
    //quoted identifier not supported
    Data.RegService
     (Engines.EngineSvcID.EngineSvc__ObjectIdentifierBuilder,
      Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1.Create());

    break;
   }//case 1

   case 2:
   {
    //quoted identifier not supported
    Data.RegService
     (Engines.EngineSvcID.EngineSvc__ObjectIdentifierBuilder,
      Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d1.Create());

    break;
   }//case 2

   case 3:
   {
    Data.RegService
     (Engines.EngineSvcID.EngineSvc__ObjectIdentifierBuilder,
      Engines.Dbms.IscBase.IscBase_EngineSvc__ObjectIdentifierBuilder__cn_d3.Create());

    break;
   }//case 3

   default:
   {
    ThrowError.UnsupportedConnectionDialect
     (c_ErrSrcID,
      cnInfoSvc.ConnectionDialect);

    break;
   }//default
  }//switch value__ISC_ConnectionDialect
 }//Exec
};//class FB_ConnectionInitializer

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.V03_0_0
