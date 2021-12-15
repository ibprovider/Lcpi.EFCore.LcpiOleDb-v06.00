////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 11.04.2019.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Local.Expressions.Methods.Code.DbCast.Converters{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class DbCast_Cvt__Int64__Int64

sealed class DbCast_Cvt__Int64__Int64
 :Core.Core_ValueCvt<object,object>
{
 public static readonly DbCast_Cvt__Int64__Int64
  Instance
   =new DbCast_Cvt__Int64__Int64();

 //Core_ValueCvt interface -----------------------------------------------
 public void Exec(Core.Core_ValueCvtCtx context,
                  object                sourceValue,
                  out object            targetValue)
 {
  Debug.Assert(!Object.ReferenceEquals(context,null));
  Debug.Assert(!Object.ReferenceEquals(sourceValue,null));
  Debug.Assert(sourceValue.GetType()==Structure_TypeCache.TypeOf__System_Int64);

  targetValue=sourceValue;

  Debug.Assert(!Object.ReferenceEquals(targetValue,null));
  Debug.Assert(targetValue.GetType()==Structure_TypeCache.TypeOf__System_Int64);
 }//Exec
};//class DbCast_Cvt__Int64__Int64

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Core.Values.Converters
