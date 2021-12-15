////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.03.2021.
using System;
using System.Data.Common;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;

using xdb=lcpi.data.oledb;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__RelationalDatabaseCreator

sealed class LcpiOleDb__RelationalDatabaseCreator:RelationalDatabaseCreator
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__RelationalDatabaseCreator;

 //-----------------------------------------------------------------------
 public LcpiOleDb__RelationalDatabaseCreator(RelationalDatabaseCreatorDependencies dependencies)
  :base(dependencies)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__RelationalDatabaseCreator::LcpiOleDb__RelationalDatabaseCreator\n"
   +"(dependencies: {0})",
    dependencies);
#endif
 }//LcpiOleDb__RelationalDatabaseCreator

 //RelationalDatabaseCreator interface -----------------------------------
 public override bool Exists()
 {
#if TRACE
  Core.Core_Trace.Method_Enter
   ("LcpiOleDb__RelationalDatabaseCreator::Exists()");
#endif

  try
  {
   this.Dependencies.Connection.Open();
  }
  catch(xdb.OleDbException)
  {
   //! \todo
   //!  [2021-04-25] CHECK THE ERROR CODE!

#if TRACE
   Core.Core_Trace.Method_Exit
    ("LcpiOleDb__RelationalDatabaseCreator::Exists - FALSE");
#endif

   return false;
  }//catch

  this.Dependencies.Connection.Close();

#if TRACE
  Core.Core_Trace.Method_Exit
   ("LcpiOleDb__RelationalDatabaseCreator::Exists - TRUE");
#endif

  return true;
 }//Exists

 //-----------------------------------------------------------------------
 public override void Create()
 {
  ThrowSysError.method_not_impl
   (c_ErrSrcID,
    "Create");
 }//Create

 //-----------------------------------------------------------------------
 public override void Delete()
 {
  ThrowSysError.method_not_impl
   (c_ErrSrcID,
    "Delete");
 }//Delete

 //-----------------------------------------------------------------------
 public override bool HasTables()
 {
#if TRACE
  Core.Core_Trace.Method_Enter
   ("LcpiOleDb__RelationalDatabaseCreator::HasTables()");
#endif

  //-------------------------------------------------------
  const string c_bugcheck_src
   ="LcpiOleDb__RelationalDatabaseCreator::HasTables";

  bool resultValue=false;

#if TRACE
  try // [catch]
#endif
  {
   var connection
    =this.Dependencies.Connection;

   Check.BugCheck_Value_NotNull
    (c_ErrSrcID,
     c_bugcheck_src,
     "#001",
     nameof(connection),
     connection);

   connection.Open(); //throw

   try // [finally]
   {
    var dbConnection
     =connection.DbConnection;

   Check.BugCheck_Value_NotNull
    (c_ErrSrcID,
     c_bugcheck_src,
     "#002",
     nameof(dbConnection),
     dbConnection);

    resultValue
     =Helper__HasTables
       (dbConnection);
   }
   finally
   {
    connection.Close(); //throw?
   }//finally
  }
#if TRACE
  catch(Exception exc)
  {
   Core.Core_Trace.Method_Exc
    (exc,
     "LcpiOleDb__RelationalDatabaseCreator::Exists");

   throw;
  }//catch
#endif

#if TRACE
  Core.Core_Trace.Method_Exit
   ("LcpiOleDb__RelationalDatabaseCreator::Exists - {0}",
    resultValue);
#endif

  return resultValue;
 }//HasTables

 //Helper methods --------------------------------------------------------
 private static bool Helper__HasTables(DbConnection dbConnection)
 {
  Debug.Assert(!Object.ReferenceEquals(dbConnection,null));

  var iRestruction__TABLE_TYPE
   =Helper__GetIndexOfRestriction__TABLE_TYPE
     (dbConnection);

  Debug.Assert(iRestruction__TABLE_TYPE>=0);

  var restrictions
   =new string[iRestruction__TABLE_TYPE+1];

  restrictions[iRestruction__TABLE_TYPE]
   ="TABLE";

  var schema
   =dbConnection.GetSchema
     (xdb.OleDbMetaDataCollectionNames.Tables,
      restrictions);

  Debug.Assert(!Object.ReferenceEquals(schema,null));
  Debug.Assert(!Object.ReferenceEquals(schema.Rows,null));

  Debug.Assert(schema.Rows.Count>=0);

  if(schema.Rows.Count==0)
   return false;

  return true;
 }//Helper__HasTables

 //-----------------------------------------------------------------------
 private static int Helper__GetIndexOfRestriction__TABLE_TYPE(DbConnection dbConnection)
 {
  Debug.Assert(!Object.ReferenceEquals(dbConnection,null));

  const string c_bugcheck_src
   ="LcpiOleDb__RelationalDatabaseCreator::Helper__GetIndexOfRestriction__TABLE_TYPE";

  Debug.Assert(!Object.ReferenceEquals(sm_QueryRestriction__Tables__TABLE_TYPE,null));
  Debug.Assert(sm_QueryRestriction__Tables__TABLE_TYPE.Length==2);

  var restrictionsSchema
   =dbConnection.GetSchema
     (xdb.OleDbMetaDataCollectionNames.Restrictions,
      sm_QueryRestriction__Tables__TABLE_TYPE);

  Debug.Assert(!Object.ReferenceEquals(restrictionsSchema,null));

  Debug.Assert(restrictionsSchema.Rows.Count>=0);

  if(restrictionsSchema.Rows.Count==0)
  {
   ThrowError.Schema__DataProviderNotSupportReqRestriction
    (c_ErrSrcID,
     sm_QueryRestriction__Tables__TABLE_TYPE[0],
     sm_QueryRestriction__Tables__TABLE_TYPE[1]);
  }//if

  if(restrictionsSchema.Rows.Count!=1)
  {
   ThrowBugCheck.schema_contains_unexpected_row_count
    (c_ErrSrcID,
     c_bugcheck_src,
     "#001",
     xdb.OleDbMetaDataCollectionNames.Restrictions,
     restrictionsSchema.Rows.Count);
  }//if

  Debug.Assert(restrictionsSchema.Rows.Count==1);

  int iCol__RestrictionNumber
   =Structure_ADP.IndexOf
     (c_ErrSrcID,
      restrictionsSchema,
      xdb.OleDbMetaDataCollectionColumnNames.Restrictions.RestrictionNumber);

  //Expected values: [1....)
  int restrictionNumber
   =Structure_ADP.GetInt32_NN
    (c_ErrSrcID,
     restrictionsSchema.Rows[0],
     iCol__RestrictionNumber);

  Debug.Assert(restrictionNumber>=0);

  if(restrictionNumber<1)
  {
   ThrowBugCheck.incorrect_schema_restriction_number
    (c_ErrSrcID,
     c_bugcheck_src,
     "#002",
     sm_QueryRestriction__Tables__TABLE_TYPE[0],
     sm_QueryRestriction__Tables__TABLE_TYPE[1],
     restrictionNumber);
  }//if

  Debug.Assert(restrictionNumber>=1);

  return restrictionNumber-1;
 }//Helper__GetIndexOfRestriction__TABLE_TYPE

 //private data ----------------------------------------------------------
 private static readonly string[]
  sm_QueryRestriction__Tables__TABLE_TYPE
   =new string[]
     {
      xdb.OleDbMetaDataCollectionNames.Tables,
      xdb.OleDbSchemaColumnNames.Tables.TABLE_TYPE
     };//sm_QueryRestriction__Tables__TABLE_TYPE
};//class LcpiOleDb__RelationalDatabaseCreator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage
