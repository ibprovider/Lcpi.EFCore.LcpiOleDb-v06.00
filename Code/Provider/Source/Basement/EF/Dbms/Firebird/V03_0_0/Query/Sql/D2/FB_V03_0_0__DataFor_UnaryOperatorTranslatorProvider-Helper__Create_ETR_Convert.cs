////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 03.10.2021.

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D2{
////////////////////////////////////////////////////////////////////////////////
//using

using Code0
 =Firebird.Common.Query.Sql.Expressions.Nodes.SSCodes.Unary__Convert;

using Code1
 =D3.Expressions.Nodes.SSCodes.Unary_Convert;

using FB_COMMON_ETRS_CODE
 =Common.Query.Sql.Expressions.Translators.Code;

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__DataFor_UnaryOperatorTranslatorProvider

sealed partial class FB_V03_0_0__DataFor_UnaryOperatorTranslatorProvider
{
 private static FB_COMMON_ETRS_CODE.FB_Common__Sql_ETranslator_Unary__Convert
  Helper__Create_ETR_Convert()
 {
  var ETR
   =new FB_COMMON_ETRS_CODE.FB_Common__Sql_ETranslator_Unary__Convert()
     .Reg(Structure_TypeCache.TypeOf__System_Byte         , Structure_TypeCache.TypeOf__System_Byte        , true  , Code0.SSCode_Unary_Convert__CastAs__IntToByte.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Byte         , Structure_TypeCache.TypeOf__System_Int16       , true  , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Byte         , Structure_TypeCache.TypeOf__System_Int32       , true  , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Byte         , Structure_TypeCache.TypeOf__System_Int64       , true  , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Byte         , Structure_TypeCache.TypeOf__System_Single      , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Byte         , Structure_TypeCache.TypeOf__System_Double      , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Byte         , Structure_TypeCache.TypeOf__System_Decimal     , false  ,Code1.SSCode_Unary_Convert__CastAs__Int16ToDecimal.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Byte         , Structure_TypeCache.TypeOf__System_String      , false , Code0.SSCode_Unary_Convert__CastAs__ToVarCharN.Instance__FromByte)

     .Reg(Structure_TypeCache.TypeOf__System_Int16        , Structure_TypeCache.TypeOf__System_Byte        , false , Code0.SSCode_Unary_Convert__CastAs__IntToByte.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int16        , Structure_TypeCache.TypeOf__System_Int16       , true  , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int16        , Structure_TypeCache.TypeOf__System_Int32       , true  , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int16        , Structure_TypeCache.TypeOf__System_Int64       , true  , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int16        , Structure_TypeCache.TypeOf__System_Single      , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int16        , Structure_TypeCache.TypeOf__System_Double      , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int16        , Structure_TypeCache.TypeOf__System_Decimal     , false  ,Code1.SSCode_Unary_Convert__CastAs__Int16ToDecimal.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int16        , Structure_TypeCache.TypeOf__System_String      , false , Code0.SSCode_Unary_Convert__CastAs__ToVarCharN.Instance__FromInt16)

     .Reg(Structure_TypeCache.TypeOf__System_Int32        , Structure_TypeCache.TypeOf__System_Byte        , false , Code0.SSCode_Unary_Convert__CastAs__IntToByte.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int32        , Structure_TypeCache.TypeOf__System_Int16       , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int32        , Structure_TypeCache.TypeOf__System_Int32       , true  , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int32        , Structure_TypeCache.TypeOf__System_Int64       , true  , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int32        , Structure_TypeCache.TypeOf__System_Single      , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int32        , Structure_TypeCache.TypeOf__System_Double      , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int32        , Structure_TypeCache.TypeOf__System_Decimal     , false , Code1.SSCode_Unary_Convert__CastAs__Int32ToDecimal.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int32        , Structure_TypeCache.TypeOf__System_String      , false , Code0.SSCode_Unary_Convert__CastAs__ToVarCharN.Instance__FromInt32)

     .Reg(Structure_TypeCache.TypeOf__System_Int64        , Structure_TypeCache.TypeOf__System_Byte        , false , Code0.SSCode_Unary_Convert__CastAs__IntToByte.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int64        , Structure_TypeCache.TypeOf__System_Int16       , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int64        , Structure_TypeCache.TypeOf__System_Int32       , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int64        , Structure_TypeCache.TypeOf__System_Int64       , true  , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int64        , Structure_TypeCache.TypeOf__System_Single      , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int64        , Structure_TypeCache.TypeOf__System_Double      , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int64        , Structure_TypeCache.TypeOf__System_Decimal     , false , Code1.SSCode_Unary_Convert__CastAs__Int64ToDecimal.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Int64        , Structure_TypeCache.TypeOf__System_String      , false , Code0.SSCode_Unary_Convert__CastAs__ToVarCharN.Instance__FromInt64)

     .Reg(Structure_TypeCache.TypeOf__System_Single       , Structure_TypeCache.TypeOf__System_Byte        , false , Code0.SSCode_Unary_Convert__CastAs__FloatToByte.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Single       , Structure_TypeCache.TypeOf__System_Int16       , false , Code0.SSCode_Unary_Convert__CastAs__WithTrunc.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Single       , Structure_TypeCache.TypeOf__System_Int32       , false , Code0.SSCode_Unary_Convert__CastAs__WithTrunc.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Single       , Structure_TypeCache.TypeOf__System_Int64       , false , Code0.SSCode_Unary_Convert__CastAs__WithTrunc.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Single       , Structure_TypeCache.TypeOf__System_Single      , true  , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Single       , Structure_TypeCache.TypeOf__System_Double      , true  , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Single       , Structure_TypeCache.TypeOf__System_Decimal     , false , Code1.SSCode_Unary_Convert__CastAs__FloatToDecimal.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Single       , Structure_TypeCache.TypeOf__System_String      , false , Code0.SSCode_Unary_Convert__CastAs__ToVarCharN.Instance__FromDouble)

     .Reg(Structure_TypeCache.TypeOf__System_Double       , Structure_TypeCache.TypeOf__System_Byte        , false , Code0.SSCode_Unary_Convert__CastAs__FloatToByte.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Double       , Structure_TypeCache.TypeOf__System_Int16       , false , Code0.SSCode_Unary_Convert__CastAs__WithTrunc.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Double       , Structure_TypeCache.TypeOf__System_Int32       , false , Code0.SSCode_Unary_Convert__CastAs__WithTrunc.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Double       , Structure_TypeCache.TypeOf__System_Int64       , false , Code0.SSCode_Unary_Convert__CastAs__WithTrunc.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Double       , Structure_TypeCache.TypeOf__System_Single      , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Double       , Structure_TypeCache.TypeOf__System_Double      , true  , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Double       , Structure_TypeCache.TypeOf__System_Decimal     , false , Code1.SSCode_Unary_Convert__CastAs__FloatToDecimal.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Double       , Structure_TypeCache.TypeOf__System_String      , false , Code0.SSCode_Unary_Convert__CastAs__ToVarCharN.Instance__FromDouble)

     .Reg(Structure_TypeCache.TypeOf__System_Decimal      , Structure_TypeCache.TypeOf__System_Byte        , false , Code0.SSCode_Unary_Convert__CastAs__FloatToByte.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Decimal      , Structure_TypeCache.TypeOf__System_Int16       , false , Code0.SSCode_Unary_Convert__CastAs__WithTrunc.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Decimal      , Structure_TypeCache.TypeOf__System_Int32       , false , Code0.SSCode_Unary_Convert__CastAs__WithTrunc.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Decimal      , Structure_TypeCache.TypeOf__System_Int64       , false , Code0.SSCode_Unary_Convert__CastAs__WithTrunc.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Decimal      , Structure_TypeCache.TypeOf__System_Single      , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Decimal      , Structure_TypeCache.TypeOf__System_Double      , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_Decimal      , Structure_TypeCache.TypeOf__System_String      , false , Code0.SSCode_Unary_Convert__CastAs__ToVarCharN.Instance__FromDecimal)

     .Reg(Structure_TypeCache.TypeOf__System_TimeOnly     , Structure_TypeCache.TypeOf__System_String      , false , Code0.SSCode_Unary_Convert__CastAs__ToVarCharN.Instance__FromTIME)

     .Reg(Structure_TypeCache.TypeOf__System_DateOnly     , Structure_TypeCache.TypeOf__System_String      , false , Code0.SSCode_Unary_Convert__CastAs__ToVarCharN.Instance__FromTypeDate)

     .Reg(Structure_TypeCache.TypeOf__System_DateTime     , Structure_TypeCache.TypeOf__System_String      , false , Code0.SSCode_Unary_Convert__CastAs__ToVarCharN.Instance__FromTS__D3)

     .Reg(Structure_TypeCache.TypeOf__System_Boolean      , Structure_TypeCache.TypeOf__System_String      , false , Code0.SSCode_Unary_Convert__CastAs__ToVarCharN.Instance__FromBOOLEAN)

     .Reg(Structure_TypeCache.TypeOf__System_String       , Structure_TypeCache.TypeOf__System_Boolean     , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_String       , Structure_TypeCache.TypeOf__System_TimeOnly    , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     //.Reg(Structure_TypeCache.TypeOf__System_String       , Structure_TypeCache.TypeOf__System_DateOnly        , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_String       , Structure_TypeCache.TypeOf__System_DateTime    , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_String       , Structure_TypeCache.TypeOf__System_Int16       , false , Code0.SSCode_Unary_Convert__CastAs__WithTrunc.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_String       , Structure_TypeCache.TypeOf__System_Int32       , false , Code0.SSCode_Unary_Convert__CastAs__WithTrunc.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_String       , Structure_TypeCache.TypeOf__System_Int64       , false , Code0.SSCode_Unary_Convert__CastAs__WithTrunc.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_String       , Structure_TypeCache.TypeOf__System_Single      , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)
     .Reg(Structure_TypeCache.TypeOf__System_String       , Structure_TypeCache.TypeOf__System_Double      , false , Code0.SSCode_Unary_Convert__CastAs__Std.Instance)

     .Reg(Structure_TypeCache.TypeOf__System_Char         , Structure_TypeCache.TypeOf__System_String      , true  , Code0.SSCode_Unary_Convert__CastAs__ToVarCharN.Instance__FromChar)

#if DEBUG
     .DEBUG__Complete()
#endif
    /*END*/
    ;

  return ETR;
 }//Helper__Create_ETR_Convert
};//FB_V03_0_0__DataFor_UnaryOperatorTranslatorProvider

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D2
