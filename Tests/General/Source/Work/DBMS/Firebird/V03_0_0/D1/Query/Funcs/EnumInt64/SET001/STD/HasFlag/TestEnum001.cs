////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 02.06.2021.
using System;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.EnumInt64.SET001.STD.HasFlag{
////////////////////////////////////////////////////////////////////////////////
//enum TestEnum001

[Flags]
enum TestEnum001:long
{
 Flag1 =0x01,
 Flag2 =0x02,
 Flag3 =0x04,
};//enum TestEnum001

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D1.Query.Funcs.EnumInt64.SET001.STD.HasFlag
