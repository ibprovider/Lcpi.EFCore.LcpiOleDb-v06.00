////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.09.2021.
using Microsoft.EntityFrameworkCore.Query;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query{
////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__QueryTranslationPostprocessorFactory

sealed class FB_V03_0_0__QueryTranslationPostprocessorFactory
 :IQueryTranslationPostprocessorFactory
{
 public FB_V03_0_0__QueryTranslationPostprocessorFactory
    (QueryTranslationPostprocessorDependencies           dependencies,
     RelationalQueryTranslationPostprocessorDependencies relationalDependencies)
 {
  m_Dependencies           = dependencies;
  m_RelationalDependencies = relationalDependencies;
 }//FB_V03_0_0__QueryTranslationPostprocessorFactory

 //-----------------------------------------------------------------------
 public QueryTranslationPostprocessor Create(QueryCompilationContext queryCompilationContext)
 {
  return new FB_V03_0_0__QueryTranslationPostprocessor
          (m_Dependencies,
           m_RelationalDependencies,
           queryCompilationContext);
 }//Create

 //Helper data -----------------------------------------------------------
 private readonly QueryTranslationPostprocessorDependencies
  m_Dependencies;

 private readonly RelationalQueryTranslationPostprocessorDependencies
  m_RelationalDependencies;
};//class FB_V03_0_0__QueryTranslationPostprocessorFactory

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query
