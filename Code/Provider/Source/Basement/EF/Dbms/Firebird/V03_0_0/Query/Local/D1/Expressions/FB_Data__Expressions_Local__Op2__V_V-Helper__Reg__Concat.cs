////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.12.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D3.Expressions{
////////////////////////////////////////////////////////////////////////////////
//using

using Common_ETRS
 =Root.Query.Local.Expressions.Op2.Translators.Instances;

using Common_ETR_STD
 =Root.Query.Local.Expressions.Op2.Translators.Std;

using FB3_D0_ETRS
 =Firebird.V03_0_0.Query.Local.D0.Expressions.Op2.Translators.Instances;

using FB3_D1_ETRS
 =Firebird.V03_0_0.Query.Local.D1.Expressions.Op2.Translators.Instances;

using LcpiOleDb__LocalEval_Op2__Map
 =Root.Query.Local.LcpiOleDb__LocalEval_Op2__Map;

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//class FB_Data__Expressions_Local__Op2__V_V

static partial class FB_Data__Expressions_Local__Op2__V_V
{
 private static LcpiOleDb__LocalEval_Op2__Map Helper__Reg__Concat(LcpiOleDb__LocalEval_Op2__Map Map)
 {
  Debug.Assert(!Object.ReferenceEquals(Map,null));

  System.Type[]
   supportedArgTypes
    ={
      Structure_TypeCache.TypeOf__System_Object,
      Structure_TypeCache.TypeOf__System_String,
      Structure_TypeCache.TypeOf__System_Boolean,
      Structure_TypeCache.TypeOf__System_Decimal,
      Structure_TypeCache.TypeOf__System_Double,
      Structure_TypeCache.TypeOf__System_Byte,
      Structure_TypeCache.TypeOf__System_Int16,
      Structure_TypeCache.TypeOf__System_Int32,
      Structure_TypeCache.TypeOf__System_Int64,
      Structure_TypeCache.TypeOf__System_Single,
      Structure_TypeCache.TypeOf__System_DateTime,
      Structure_TypeCache.TypeOf__System_DateOnly,
      Structure_TypeCache.TypeOf__System_TimeOnly,
      Structure_TypeCache.TypeOf__System_NullableBoolean,
      Structure_TypeCache.TypeOf__System_NullableDecimal,
      Structure_TypeCache.TypeOf__System_NullableDouble,
      Structure_TypeCache.TypeOf__System_NullableByte,
      Structure_TypeCache.TypeOf__System_NullableInt16,
      Structure_TypeCache.TypeOf__System_NullableInt32,
      Structure_TypeCache.TypeOf__System_NullableInt64,
      Structure_TypeCache.TypeOf__System_NullableSingle,
      Structure_TypeCache.TypeOf__System_NullableDateTime,
      Structure_TypeCache.TypeOf__System_NullableDateOnly,
      Structure_TypeCache.TypeOf__System_NullableTimeOnly,
     };//supportedArgTypes

  foreach(var leftType in supportedArgTypes)
  {
   foreach(var rightType in supportedArgTypes)
   {
    Map
    .Reg(LcpiOleDb__ExpressionType.Concat)
    .Add_Concat(leftType,rightType)

    /*END*/
    ;
   }//for rightType
  }//for leftType

  return Map;
 }//Helper__Reg__Concat
};//class FB_Data__Expressions_Local__Op2__V_V

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D3.Expressions
