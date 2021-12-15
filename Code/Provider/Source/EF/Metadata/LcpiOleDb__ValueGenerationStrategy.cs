////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 23.09.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.MetaData{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__ValueGenerationStrategy

public static class LcpiOleDb__ValueGenerationStrategy
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__ValueGenerationStrategy;

 //-----------------------------------------------------------------------
 public static LcpiOleDb__AnnotationData__ValueGenerationStrategy None
 {
  get
  {
   return LcpiOleDb__AnnotationData__ValueGenerationStrategy_None.Create();
  }//get
 }//None

 //-----------------------------------------------------------------------
 public static LcpiOleDb__AnnotationData__ValueGenerationStrategy SequenceTrigger
                                           (string triggerName,
                                            string sequenceName)
 {
  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(SequenceTrigger),
    nameof(triggerName),
    triggerName);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(SequenceTrigger),
    nameof(sequenceName),
    sequenceName);

  //----------------------------------------
  return LcpiOleDb__AnnotationData__ValueGenerationStrategy_SequenceTrigger.Create
          (triggerName,
           sequenceName);
 }//SequenceTrigger

 //-----------------------------------------------------------------------
 public static LcpiOleDb__AnnotationData__ValueGenerationStrategy IdentityByDefaultColumn
 {
  get
  {
   return LcpiOleDb__AnnotationData__ValueGenerationStrategy_IdentityByDefaultColumn.Create();
  }//get
 }//IdentityByDefaultColumn
};//class LcpiOleDb__ValueGenerationStrategy

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.MetaData
