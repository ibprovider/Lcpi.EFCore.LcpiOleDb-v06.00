////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 24.11.2020.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__ParameterBasedSqlProcessorFactory

sealed class LcpiOleDb__ParameterBasedSqlProcessorFactory
 :IRelationalParameterBasedSqlProcessorFactory
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__ParameterBasedSqlProcessorFactory;

 //-----------------------------------------------------------------------
 public LcpiOleDb__ParameterBasedSqlProcessorFactory
          (RelationalParameterBasedSqlProcessorDependencies dependencies,
           Core.Core_ConnectionOptions                      cnOptions)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(dependencies),
    dependencies);

  Check.Arg_NotNull
   (c_ErrSrcID,
    "constructor",
    nameof(cnOptions),
    cnOptions);

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(cnOptions,null));

  m_Dependencies=dependencies;
  m_CnOptions   =cnOptions;
 }//LcpiOleDb__ParameterBasedSqlProcessorFactory

 //IRelationalParameterBasedSqlProcessorFactory interface ----------------
 public RelationalParameterBasedSqlProcessor Create(bool useRelationalNulls)
 {
  Debug.Assert(!Object.ReferenceEquals(m_Dependencies,null));

  return new LcpiOleDb__ParameterBasedSqlProcessor
          (m_Dependencies,
           m_CnOptions,
           useRelationalNulls);
 }//Create

 //private data ----------------------------------------------------------
 private readonly RelationalParameterBasedSqlProcessorDependencies
  m_Dependencies;

 private readonly Core.Core_ConnectionOptions
  m_CnOptions;
};//class LcpiOleDb__ParameterBasedSqlProcessorFactory

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query