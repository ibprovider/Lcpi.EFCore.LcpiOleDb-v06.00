////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 19.11.2018.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Local.Expressions.Methods.Code.DbCast.Converters{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class DbCast_Cvt__Int32__Double

sealed class DbCast_Cvt__Int32__Double
 :Core.Core_ValueCvt<object,object>
{
 public static readonly DbCast_Cvt__Int32__Double
  Instance
   =new DbCast_Cvt__Int32__Double();

 //Core_ValueCvt interface -----------------------------------------------
 public void Exec(Core.Core_ValueCvtCtx context,
                  object                sourceValue,
                  out object            targetValue)
 {
  Debug.Assert(!Object.ReferenceEquals(context,null));
  Debug.Assert(!Object.ReferenceEquals(sourceValue,null));
  Debug.Assert(sourceValue.GetType()==Structure_TypeCache.TypeOf__System_Int32);

  System.Int32 typedSourceValue=(System.Int32)sourceValue;

  targetValue=(System.Double)typedSourceValue;

  Debug.Assert(!Object.ReferenceEquals(targetValue,null));
  Debug.Assert(targetValue.GetType()==Structure_TypeCache.TypeOf__System_Double);
 }//Exec
};//class DbCast_Cvt__Int32__Double

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Local.Expressions.Methods.Code.DbCast.Converters
