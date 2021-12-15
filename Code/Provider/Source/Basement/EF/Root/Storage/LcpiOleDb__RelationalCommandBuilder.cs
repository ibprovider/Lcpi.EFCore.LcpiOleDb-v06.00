////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.05.2018.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__RelationalCommandBuilder

sealed class LcpiOleDb__RelationalCommandBuilder:RelationalCommandBuilder
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__RelationalCommandBuilder;

 //-----------------------------------------------------------------------
 public LcpiOleDb__RelationalCommandBuilder
                (RelationalCommandBuilderDependencies dependencies,
                 ISqlGenerationHelper                 sqlGenerationHelper)
  :base(dependencies)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlGenerationHelper,null));

#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__RelationalCommandBuilder::LcpiOleDb__RelationalCommandBuilder({0},{1})",
    dependencies,
    sqlGenerationHelper);
#endif

  //----------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(LcpiOleDb__RelationalCommandBuilder),
    nameof(sqlGenerationHelper),
    sqlGenerationHelper);

  //----------------------------------------
  m_SqlGenerationHelper=sqlGenerationHelper;

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(m_SqlGenerationHelper,null));
 }//LcpiOleDb__RelationalCommandBuilder

 //RelationalCommandBuilder interface ------------------------------------
 public override IRelationalCommand Build()
 {
  Debug.Assert(!Object.ReferenceEquals(m_SqlGenerationHelper,null));

  //Research asserts
  Debug.Assert(!Object.ReferenceEquals(this.Dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(this.Parameters,null));

  //----------------------------------------------------------------------
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__RelationalCommandBuilder::Build()");

  if(!Object.ReferenceEquals(this.Parameters,null))
  {
   Core.Core_Trace.Send
    (" Parameters [Count: {0}]",
     this.Parameters.Count);
  }//if
#endif

  //----------------------------------------------------------------------
  return new LcpiOleDb__RelationalCommand
              (this.ToString(),
               this.Parameters,
               m_SqlGenerationHelper);
 }//BuildCore

 //private data ----------------------------------------------------------

 //Not null.
 private readonly ISqlGenerationHelper m_SqlGenerationHelper;
};//class LcpiOleDb__RelationalCommandBuilder

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage
