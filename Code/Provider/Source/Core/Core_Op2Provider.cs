////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 12.02.2021.
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////
//interface Core_Op2

/// <summary>
///  Interface of binary operation implementation provider service.
/// </summary>
interface Core_Op2Provider:Core_Svc
{
 /// <summary>
 ///  Get a object with binary operation implementation.
 /// </summary>
 //! \param[in] opId
 //!  Binary operation Id.
 //! \param[in] typeLeft
 //!  Not null.
 //! \param[in] typeRight
 //!  Not null.
 //! \returns
 //!  Null, if operation isn't supported.
 Core_Op2 GetOp2(LcpiOleDb__ExpressionType opId,
                 System.Type               typeLeft,
                 System.Type               typeRight);
};//interface Core_Op2Provider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core
