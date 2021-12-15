////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 24.11.2020.
using Microsoft.EntityFrameworkCore.Query;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__QueryTranslationPreprocessorFactory

sealed class LcpiOleDb__QueryTranslationPreprocessorFactory
 :IQueryTranslationPreprocessorFactory
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__QueryTranslationPreprocessorFactory;

 //-----------------------------------------------------------------------
 public LcpiOleDb__QueryTranslationPreprocessorFactory
                             (QueryTranslationPreprocessorDependencies dependencies)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Create),
    nameof(dependencies),
    dependencies);

  //----------------------------------------
  m_dependencies=dependencies;
 }//LcpiOleDb__QueryTranslationPreprocessorFactory

 //IQueryTranslationPreprocessorFactory interface ------------------------
 public QueryTranslationPreprocessor Create(QueryCompilationContext queryCompilationContext)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(Create),
    nameof(queryCompilationContext),
    queryCompilationContext);

  return new LcpiOleDb__QueryTranslationPreprocessor
              (m_dependencies,
               queryCompilationContext);
 }//Create

 //private ---------------------------------------------------------------
 private readonly QueryTranslationPreprocessorDependencies m_dependencies;
};//class LcpiOleDb__QueryTranslationPreprocessorFactory

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query
