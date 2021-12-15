////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 25.07.2021.
using Microsoft.EntityFrameworkCore.Update;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Update{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__ModificationCommand

sealed class LcpiOleDb__ModificationCommand:ModificationCommand
{
 public LcpiOleDb__ModificationCommand(ModificationCommandParameters modificationCommandParameters)
  :base(modificationCommandParameters)
 {
 }

 //ModificationCommand interface -----------------------------------------
 protected override IColumnModification CreateColumnModification(in ColumnModificationParameters columnModificationParameters)
 {
  return new LcpiOleDb__ColumnModification(columnModificationParameters);
 }//CreateColumnModification
};//class LcpiOleDb__ModificationCommand

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Update
