////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.11.2020.
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

using SqlNullabilityProcessor
 =Lcpi.EXT.Microsoft.EntityFrameworkCore.Query.SqlNullabilityProcessor;

using RelationalParameterBasedSqlProcessorDependencies
 =Microsoft.EntityFrameworkCore.Query.RelationalParameterBasedSqlProcessorDependencies;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__SqlNullabilityProcessor

sealed class LcpiOleDb__SqlNullabilityProcessor:SqlNullabilityProcessor
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__SqlNullabilityProcessor;

 //-----------------------------------------------------------------------
 public LcpiOleDb__SqlNullabilityProcessor
                             (RelationalParameterBasedSqlProcessorDependencies dependencies,
                              bool                                             useRelationalNulls)
  :base(dependencies,useRelationalNulls)
 {
 }//LcpiOleDb__SqlNullabilityProcessor

 //SqlNullabilityProcessor interface -------------------------------------
 protected override bool LCPI__GetPermissionForTransformation(LCPI__TransformationRule optRule)
 {
  //
  // nullableStringColumn + a -> COALESCE(nullableStringColumn, "") + a
  //
  // [2020-11-24] Disable it.
  //
  // [2020-12-29] SHIT: (string)null+null == "" !!!
  //

  //if(optRule==LCPI__TransformationRule.AddNullConcatenationProtection)
  // return false;

  return base.LCPI__GetPermissionForTransformation(optRule);
 }//LCPI__GetPermissionForTransformation
};//class LcpiOleDb__SqlNullabilityProcessor

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query
