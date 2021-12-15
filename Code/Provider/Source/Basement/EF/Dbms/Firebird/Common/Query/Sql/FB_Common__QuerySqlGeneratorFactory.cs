////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.05.2018.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__QuerySqlGeneratorFactory

/*public*/ sealed class FB_Common__QuerySqlGeneratorFactory:IQuerySqlGeneratorFactory
{
 public FB_Common__QuerySqlGeneratorFactory(QuerySqlGeneratorDependencies                dependencies,
                                            Core.Core_ConnectionOptions                  cnOptions,
                                            FB_Common__IQuerySqlPartGenerator__Parameter sqlPartGenerator__Parameter)
 {
  Debug.Assert(!Object.ReferenceEquals(dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(cnOptions,null));
  Debug.Assert(!Object.ReferenceEquals(sqlPartGenerator__Parameter,null));

#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__QuerySqlGeneratorFactory::FB_Common__QuerySqlGeneratorFactory()");
#endif

  m_dependencies=dependencies;

  m_cnOptions=cnOptions;

  m_sqlPartGenerator__Parameter=sqlPartGenerator__Parameter;
 }//FB_Common__QuerySqlGeneratorFactory

 //QuerySqlGeneratorFactoryBase interface --------------------------------
 public QuerySqlGenerator Create()
 {
  Debug.Assert(!Object.ReferenceEquals(m_dependencies,null));
  Debug.Assert(!Object.ReferenceEquals(m_cnOptions,null));
  Debug.Assert(!Object.ReferenceEquals(m_sqlPartGenerator__Parameter,null));

#if TRACE
  Core.Core_Trace.Method
   ("FB_Common__QuerySqlGeneratorFactory::Create()");
#endif

  return new FB_Common__QuerySqlGenerator
          (m_dependencies,
           m_cnOptions,
           m_sqlPartGenerator__Parameter);
 }//CreateDefault

 //private data ----------------------------------------------------------
 private readonly QuerySqlGeneratorDependencies
  m_dependencies;

 private readonly Core.Core_ConnectionOptions
  m_cnOptions;

 private readonly FB_Common__IQuerySqlPartGenerator__Parameter
  m_sqlPartGenerator__Parameter;
};//class FB_Common__QuerySqlGeneratorFactory

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Sql
