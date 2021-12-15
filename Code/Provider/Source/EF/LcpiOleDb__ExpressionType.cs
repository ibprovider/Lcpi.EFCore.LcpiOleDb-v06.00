////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.12.2020.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//enum LcpiOleDb__ExpressionOperationType

enum LcpiOleDb__ExpressionType
{
 Add                =0,
 Subtract           =1,
 Multiply           =2,
 Divide             =3,
 Equal              =4,
 NotEqual           =5,
 ExclusiveOr        =6,
 And                =7,
 Or                 =8,
 Modulo             =9,
 AndAlso            =10,
 OrElse             =11,
 LeftShift          =12,
 RightShift         =13,
 LessThan           =14,
 LessThanOrEqual    =15,
 GreaterThan        =16,
 GreaterThanOrEqual =17,
 ArrayLength        =18,
 ArrayIndex         =19,
 Coalesce           =20,
 Convert            =21,
 Not                =22,
 Negate             =23,

 //Specific operations -----------------------------------------

 //
 // Binary operation for concatenation of string presentation of arguments.
 // Result type: System.String.
 //
 Concat             =1000,
};//enum LcpiOleDb__ExpressionType

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb
