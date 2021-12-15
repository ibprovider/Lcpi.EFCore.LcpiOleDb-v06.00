////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 17.05.2018.
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Infrastructure{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__DbContextOptionsBuilder

public sealed class LcpiOleDb__DbContextOptionsBuilder
 :RelationalDbContextOptionsBuilder<LcpiOleDb__DbContextOptionsBuilder,
                                    LcpiOleDb__DbContextOptionsExtension>
{
 public LcpiOleDb__DbContextOptionsBuilder(DbContextOptionsBuilder optionsBuilder)
  :base(optionsBuilder)
 {
 }//LcpiOleDb__DbContextOptionsBuilder

 //Interface -------------------------------------------------------------
 public LcpiOleDb__DbContextOptionsBuilder LcpiOleDb__ExecutionOfUnknownMethods(bool value)
 {
  return this.WithOption(e => e.WithExecutionOfUnknownMethods(value));
 }//LcpiOleDb__ExecutionOfUnknownMethods
};//class LcpiOleDb__DbContextOptionsBuilder

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Infrastructure
