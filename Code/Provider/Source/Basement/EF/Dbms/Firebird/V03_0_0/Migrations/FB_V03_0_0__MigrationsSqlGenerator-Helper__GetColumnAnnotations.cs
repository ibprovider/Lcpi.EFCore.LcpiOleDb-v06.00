////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 10.11.2021.
using System;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations{
////////////////////////////////////////////////////////////////////////////////

using LcpiOleDb__AnnotationNames
 =DataProvider.LcpiOleDb.MetaData.Internal.LcpiOleDb__AnnotationNames;

using LcpiOleDb__AnnotationData__ValueGenerationStrategy
 =DataProvider.LcpiOleDb.MetaData.LcpiOleDb__AnnotationData__ValueGenerationStrategy;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__MigrationsSqlGenerator

sealed partial class FB_V03_0_0__MigrationsSqlGenerator
{
 private static tagColumnAnnotations Helper__GetColumnAnnotations(ColumnOperation columnOperation)
 {
  Debug.Assert(!Object.ReferenceEquals(columnOperation,null));

  tagColumnAnnotations
   columnAnnotations
    =default;

  //Scan annotations
  foreach(var a in columnOperation.GetAnnotations())
  {
   switch(a.Name)
   {
    case LcpiOleDb__AnnotationNames.ValueGenerationStrategy:
    {
     Check.Annotation__SetupOnceNotNullBasedOn
      (c_ErrSrcID,
       a,
       ref columnAnnotations.ValueGenerationStrategy);

     Debug.Assert(!columnAnnotations.ValueGenerationStrategy.IsNull);

     break;
    }//case

    default:
    {
     //ERROR - unexpected column annotation
     ThrowError.UnknownAnnotation
      (c_ErrSrcID,
       a.Name);

     break;
    }//default
   }//switch
  }//for each a

  return columnAnnotations;
 }//Helper__GetColumnAnnotations

 //Helper types ----------------------------------------------------------
 private struct tagColumnAnnotations
 {
  public Structure.Structure_ValueWithNull<LcpiOleDb__AnnotationData__ValueGenerationStrategy>
   ValueGenerationStrategy;
 };//struct tagColumnAnnotations
};//class FB_V03_0_0__MigrationsSqlGenerator

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Migrations
