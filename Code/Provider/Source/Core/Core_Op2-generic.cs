////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 12.02.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////
//interface Core_Op2

/// <summary>
///  Interface of binary operation implementation.
/// </summary>
interface Core_Op2<T_LEFT,T_RIGHT,T_RESULT>:Core_Op2
{
 void Exec(Core_OperationCtx opCtx,
           T_LEFT            left,
           T_RIGHT           right,
           out T_RESULT      result);
};//interface Core_Op2<T_RESULT,T_LEFT,T_RIGHT>

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core
