////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 25.07.2021.
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Update{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__ModificationCommandFactory

sealed class LcpiOleDb__ModificationCommandFactory:IModificationCommandFactory
{
 public IModificationCommand CreateModificationCommand(in ModificationCommandParameters modificationCommandParameters)
 {
  return new LcpiOleDb__ModificationCommand(modificationCommandParameters);
 }//CreateModificationCommand
};//class LcpiOleDb__ModificationCommandFactory

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Update

