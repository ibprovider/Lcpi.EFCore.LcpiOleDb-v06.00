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
//class DbCast_Cvt__Decimal__Int32

sealed class DbCast_Cvt__Decimal__Int32
 :Core.Core_ValueCvt<object,object>
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_Common__Query_Local_Expressions__DbCast_Cvt__Decimal__Int32;

 //-----------------------------------------------------------------------
 public static readonly DbCast_Cvt__Decimal__Int32
  Instance
   =new DbCast_Cvt__Decimal__Int32();

 //Core_ValueCvt interface -----------------------------------------------
 public void Exec(Core.Core_ValueCvtCtx context,
                  object                sourceValue,
                  out object            targetValue)
 {
  Debug.Assert(!Object.ReferenceEquals(context,null));
  Debug.Assert(!Object.ReferenceEquals(sourceValue,null));
  Debug.Assert(sourceValue.GetType()==Structure_TypeCache.TypeOf__System_Decimal);

  Decimal typedSourceValue=(Decimal)sourceValue;

  Int32 typedTargetValue=0;

  try
  {
   typedTargetValue=(Int32)Math.Round(typedSourceValue);
  }
  catch(OverflowException e)
  {
   ThrowError.FailedToConvertValueBetweenTypes__overflow
    (c_ErrSrcID,
     Structure_TypeCache.TypeOf__System_Decimal,
     Structure_TypeCache.TypeOf__System_Int32,
     e);

   Debug.Assert(false);
  }//catch

  targetValue=typedTargetValue;

  Debug.Assert(!Object.ReferenceEquals(targetValue,null));
  Debug.Assert(targetValue.GetType()==Structure_TypeCache.TypeOf__System_Int32);
 }//Exec
};//class DbCast_Cvt__Decimal__Int32

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common.Query.Local.Expressions.Methods.Code.DbCast.Converters
