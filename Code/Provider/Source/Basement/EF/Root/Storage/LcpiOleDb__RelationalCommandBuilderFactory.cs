////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.05.2018.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__RelationalCommandBuilderFactory

sealed class LcpiOleDb__RelationalCommandBuilderFactory:IRelationalCommandBuilderFactory
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__RelationalCommandBuilderFactory;

 //-----------------------------------------------------------------------
 public LcpiOleDb__RelationalCommandBuilderFactory
                (RelationalCommandBuilderDependencies dependencies,
                 ISqlGenerationHelper                 sqlGenerationHelper)
 {
  Debug.Assert(!Object.ReferenceEquals(sqlGenerationHelper,null));

#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__RelationalCommandBuilderFactory::LcpiOleDb__RelationalCommandBuilderFactory({0},{1})",
    dependencies,
    sqlGenerationHelper);
#endif

  //----------------------------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(LcpiOleDb__RelationalCommandBuilderFactory),
    nameof(dependencies),
    dependencies);

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(LcpiOleDb__RelationalCommandBuilderFactory),
    nameof(sqlGenerationHelper),
    sqlGenerationHelper);

  //----------------------------------------
  m_Dependencies=dependencies;

  m_SqlGenerationHelper=sqlGenerationHelper;

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(m_Dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(m_SqlGenerationHelper,null));
 }//LcpiOleDb__RelationalCommandBuilderFactory

 //IRelationalCommandBuilderFactory interface ----------------------------
 public IRelationalCommandBuilder Create()
 {
  Debug.Assert(!Object.ReferenceEquals(m_Dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(m_SqlGenerationHelper,null));

#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__RelationalCommandBuilderFactory::Create()");
#endif

  return new LcpiOleDb__RelationalCommandBuilder
              (m_Dependencies,
               m_SqlGenerationHelper);
 }//Create

 //private data ----------------------------------------------------------

 //Not null.
 private readonly RelationalCommandBuilderDependencies m_Dependencies;

 //Not null.
 private readonly ISqlGenerationHelper m_SqlGenerationHelper;
};//class LcpiOleDb__RelationalCommandBuilderFactory

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage
