////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 23.09.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.MetaData.Internal{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__AnnotationProvider

sealed class LcpiOleDb__AnnotationProvider
 :RelationalAnnotationProvider
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__AnnotationProvider;

 //-----------------------------------------------------------------------
 public LcpiOleDb__AnnotationProvider(RelationalAnnotationProviderDependencies dependencies)
  :base(dependencies)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__AnnotationProvider::LcpiOleDb__AnnotationProvider");
#endif
 }//LcpiOleDb__AnnotationProvider

 //RelationalAnnotationProvider interface --------------------------------
 public override IEnumerable<IAnnotation> For(IColumn column,
                                              bool    designTime)
 {
#if TRACE
  Core.Core_Trace.Method
   ("LcpiOleDb__AnnotationProvider::For(IColumn ...)");
#endif

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(For)+"(IColumn...)",
    nameof(column),
    column);

  //--------------------------------------------------
  if(!designTime)
  {
   yield break;
  }//if !designTime

  //--------------------------------------------------
  foreach(var x in For_Column__VGS(column))
  {
   yield return x;
  }//foreach x
 }//For - IColumn

 //Helper methods --------------------------------------------------------
 private static IEnumerable<IAnnotation> For_Column__VGS(IColumn column)
 {
  Debug.Assert(!Object.ReferenceEquals(column,null));

  const string c_bugcheck_src
   ="LcpiOleDb__AnnotationProvider::For_Column__VGS";

		var valueGenerationStrategies
   =column
     .PropertyMappings
     .Where(columnMapping =>
             {
              //
              // [2021-11-16]
              //
              // Additional filter. Code from MSSQL, PG providers.
              //

              Debug.Assert(!Object.ReferenceEquals(columnMapping,null));
              Debug.Assert(!Object.ReferenceEquals(columnMapping.TableMapping,null));
              Debug.Assert(!Object.ReferenceEquals(columnMapping.TableMapping.EntityType,null));
              Debug.Assert(!Object.ReferenceEquals(columnMapping.Property,null));
              Debug.Assert(!Object.ReferenceEquals(columnMapping.Property.DeclaringEntityType,null));

              //
              // IsSharedTablePrincipal:
              //
              //    Gets the value indicating whether this is the mapping for the principal entity type
              //    if the table-like object is shared.
              //

              return columnMapping.TableMapping.IsSharedTablePrincipal && columnMapping.TableMapping.EntityType==columnMapping.Property.DeclaringEntityType;
             })
     .Select(columnMapping =>
             {
              Debug.Assert(!Object.ReferenceEquals(columnMapping,null));
              Debug.Assert(!Object.ReferenceEquals(columnMapping.Property,null));

              //
              // Internal__SelectValueGenerationStrategy can return null (when VGS not applicatibled).
              //
              return columnMapping.Property.Internal__SelectValueGenerationStrategy();
             })
     .Where(vgs =>
             {
              return !Object.ReferenceEquals(vgs,null);
             })
     .ToArray();

  Debug.Assert(!Object.ReferenceEquals(valueGenerationStrategies,null));

  if(valueGenerationStrategies.Length==0)
  {
  }
  else
  if(valueGenerationStrategies.Length==1)
  {
   Debug.Assert(!Object.ReferenceEquals(valueGenerationStrategies[0],null));

   //
   // We allow to NONE go outside.
   //

   yield return new Annotation
                 (LcpiOleDb__AnnotationNames.ValueGenerationStrategy,
                  valueGenerationStrategies[0]);
  }
  else
  {
   //BUG CHECK - multiple VGS!

   ThrowBugCheck.ColumnHasMultipleVGS
    (c_ErrSrcID,
     c_bugcheck_src,
     "#001",
     column.Table.Name,
     column.Name);
  }//else
 }//For_Column__VGS
};//class LcpiOleDb__AnnotationProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.MetaData.Internal
