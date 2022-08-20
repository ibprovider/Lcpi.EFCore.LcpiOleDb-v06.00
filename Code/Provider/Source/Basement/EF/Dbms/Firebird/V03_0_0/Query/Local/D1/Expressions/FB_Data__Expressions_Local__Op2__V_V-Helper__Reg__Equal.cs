////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 10.12.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D1.Expressions{
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
 private static LcpiOleDb__LocalEval_Op2__Map Helper__Reg__Equal(LcpiOleDb__LocalEval_Op2__Map Map)
 {
  Debug.Assert(!Object.ReferenceEquals(Map,null));

  Map
   .Reg(LcpiOleDb__ExpressionType.Equal)

   .Add(Common_ETRS.ETranslators__Equal__Array1_Object.sm_Instance__Array1_Object)

   .Add(Common_ETRS.ETranslators__Equal__Array1_Char.sm_Instance__Array1_Char)

   .Add(Common_ETRS.ETranslators__Equal__Boolean.sm_Instance__Boolean)
   .Add(Common_ETRS.ETranslators__Equal__Boolean.sm_Instance__String)
   .Add(Common_ETRS.ETranslators__Equal__Boolean.sm_Instance__NullableBoolean)

   .Add(Common_ETRS.ETranslators__Equal__Byte.sm_Instance__Byte)
   .Add(Common_ETRS.ETranslators__Equal__Byte.sm_Instance__Decimal)
   .Add(Common_ETRS.ETranslators__Equal__Byte.sm_Instance__Double)
   .Add(Common_ETRS.ETranslators__Equal__Byte.sm_Instance__Int16)
   .Add(Common_ETRS.ETranslators__Equal__Byte.sm_Instance__Int32)
   .Add(Common_ETRS.ETranslators__Equal__Byte.sm_Instance__Int64)
   .Add(Common_ETRS.ETranslators__Equal__Byte.sm_Instance__SByte)
   .Add(Common_ETRS.ETranslators__Equal__Byte.sm_Instance__Single)
   .Add(Common_ETRS.ETranslators__Equal__Byte.sm_Instance__NullableByte)
   .Add(Common_ETRS.ETranslators__Equal__Byte.sm_Instance__NullableDecimal)
   .Add(Common_ETRS.ETranslators__Equal__Byte.sm_Instance__NullableDouble)
   .Add(Common_ETRS.ETranslators__Equal__Byte.sm_Instance__NullableInt16)
   .Add(Common_ETRS.ETranslators__Equal__Byte.sm_Instance__NullableInt32)
   .Add(Common_ETRS.ETranslators__Equal__Byte.sm_Instance__NullableInt64)
   .Add(Common_ETRS.ETranslators__Equal__Byte.sm_Instance__NullableSByte)
   .Add(Common_ETRS.ETranslators__Equal__Byte.sm_Instance__NullableSingle)

   .Add(Common_ETRS.ETranslators__Equal__DateOnly.sm_Instance__DateOnly)
   .Add(FB3_D0_ETRS.ETranslators__Equal__DateOnly.sm_Instance__DateTime)
   .Add(Common_ETRS.ETranslators__Equal__DateOnly.sm_Instance__String)
   .Add(Common_ETRS.ETranslators__Equal__DateOnly.sm_Instance__NullableDateOnly)

   .Add(FB3_D0_ETRS.ETranslators__Equal__DateTime.sm_Instance__DateOnly)
   .Add(FB3_D0_ETRS.ETranslators__Equal__DateTime.sm_Instance__DateTime)
   .Add(Common_ETRS.ETranslators__Equal__DateTime.sm_Instance__String)
   .Add(FB3_D0_ETRS.ETranslators__Equal__DateTime.sm_Instance__NullableDateTime)

   .Add(Common_ETRS.ETranslators__Equal__Decimal.sm_Instance__Byte)
   .Add(Common_ETRS.ETranslators__Equal__Decimal.sm_Instance__Decimal)
   .Add(Common_ETRS.ETranslators__Equal__Decimal.sm_Instance__Double)
   .Add(Common_ETRS.ETranslators__Equal__Decimal.sm_Instance__Int16)
   .Add(Common_ETRS.ETranslators__Equal__Decimal.sm_Instance__Int32)
   .Add(Common_ETRS.ETranslators__Equal__Decimal.sm_Instance__Int64)
   .Add(Common_ETRS.ETranslators__Equal__Decimal.sm_Instance__SByte)
   .Add(Common_ETRS.ETranslators__Equal__Decimal.sm_Instance__Single)
   .Add(Common_ETRS.ETranslators__Equal__Decimal.sm_Instance__NullableByte)
   .Add(Common_ETRS.ETranslators__Equal__Decimal.sm_Instance__NullableDecimal)
   .Add(Common_ETRS.ETranslators__Equal__Decimal.sm_Instance__NullableDouble)
   .Add(Common_ETRS.ETranslators__Equal__Decimal.sm_Instance__NullableInt16)
   .Add(Common_ETRS.ETranslators__Equal__Decimal.sm_Instance__NullableInt32)
   .Add(Common_ETRS.ETranslators__Equal__Decimal.sm_Instance__NullableInt64)
   .Add(Common_ETRS.ETranslators__Equal__Decimal.sm_Instance__NullableSByte)
   .Add(Common_ETRS.ETranslators__Equal__Decimal.sm_Instance__NullableSingle)

   .Add(Common_ETRS.ETranslators__Equal__Double.sm_Instance__Byte)
   .Add(Common_ETRS.ETranslators__Equal__Double.sm_Instance__Decimal)
   .Add(Common_ETRS.ETranslators__Equal__Double.sm_Instance__Double)
   .Add(Common_ETRS.ETranslators__Equal__Double.sm_Instance__Int16)
   .Add(Common_ETRS.ETranslators__Equal__Double.sm_Instance__Int32)
   .Add(Common_ETRS.ETranslators__Equal__Double.sm_Instance__Int64)
   .Add(Common_ETRS.ETranslators__Equal__Double.sm_Instance__SByte)
   .Add(Common_ETRS.ETranslators__Equal__Double.sm_Instance__Single)
   .Add(Common_ETRS.ETranslators__Equal__Double.sm_Instance__NullableByte)
   .Add(Common_ETRS.ETranslators__Equal__Double.sm_Instance__NullableDecimal)
   .Add(Common_ETRS.ETranslators__Equal__Double.sm_Instance__NullableDouble)
   .Add(Common_ETRS.ETranslators__Equal__Double.sm_Instance__NullableInt16)
   .Add(Common_ETRS.ETranslators__Equal__Double.sm_Instance__NullableInt32)
   .Add(Common_ETRS.ETranslators__Equal__Double.sm_Instance__NullableInt64)
   .Add(Common_ETRS.ETranslators__Equal__Double.sm_Instance__NullableSByte)
   .Add(Common_ETRS.ETranslators__Equal__Double.sm_Instance__NullableSingle)

   .Add(Common_ETRS.ETranslators__Equal__Guid.sm_Instance__Guid)
   .Add(Common_ETRS.ETranslators__Equal__Guid.sm_Instance__NullableGuid)

   .Add(Common_ETRS.ETranslators__Equal__Int16.sm_Instance__Byte)
   .Add(Common_ETRS.ETranslators__Equal__Int16.sm_Instance__Decimal)
   .Add(Common_ETRS.ETranslators__Equal__Int16.sm_Instance__Double)
   .Add(Common_ETRS.ETranslators__Equal__Int16.sm_Instance__Int16)
   .Add(Common_ETRS.ETranslators__Equal__Int16.sm_Instance__Int32)
   .Add(Common_ETRS.ETranslators__Equal__Int16.sm_Instance__Int64)
   .Add(Common_ETRS.ETranslators__Equal__Int16.sm_Instance__SByte)
   .Add(Common_ETRS.ETranslators__Equal__Int16.sm_Instance__Single)
   .Add(Common_ETRS.ETranslators__Equal__Int16.sm_Instance__NullableByte)
   .Add(Common_ETRS.ETranslators__Equal__Int16.sm_Instance__NullableDecimal)
   .Add(Common_ETRS.ETranslators__Equal__Int16.sm_Instance__NullableDouble)
   .Add(Common_ETRS.ETranslators__Equal__Int16.sm_Instance__NullableInt16)
   .Add(Common_ETRS.ETranslators__Equal__Int16.sm_Instance__NullableInt32)
   .Add(Common_ETRS.ETranslators__Equal__Int16.sm_Instance__NullableInt64)
   .Add(Common_ETRS.ETranslators__Equal__Int16.sm_Instance__NullableSByte)
   .Add(Common_ETRS.ETranslators__Equal__Int16.sm_Instance__NullableSingle)

   .Add(Common_ETRS.ETranslators__Equal__Int32.sm_Instance__Byte)
   .Add(Common_ETRS.ETranslators__Equal__Int32.sm_Instance__Decimal)
   .Add(Common_ETRS.ETranslators__Equal__Int32.sm_Instance__Double)
   .Add(Common_ETRS.ETranslators__Equal__Int32.sm_Instance__Int16)
   .Add(Common_ETRS.ETranslators__Equal__Int32.sm_Instance__Int32)
   .Add(Common_ETRS.ETranslators__Equal__Int32.sm_Instance__Int64)
   .Add(Common_ETRS.ETranslators__Equal__Int32.sm_Instance__SByte)
   .Add(Common_ETRS.ETranslators__Equal__Int32.sm_Instance__Single)
   .Add(Common_ETRS.ETranslators__Equal__Int32.sm_Instance__NullableByte)
   .Add(Common_ETRS.ETranslators__Equal__Int32.sm_Instance__NullableDecimal)
   .Add(Common_ETRS.ETranslators__Equal__Int32.sm_Instance__NullableDouble)
   .Add(Common_ETRS.ETranslators__Equal__Int32.sm_Instance__NullableInt16)
   .Add(Common_ETRS.ETranslators__Equal__Int32.sm_Instance__NullableInt32)
   .Add(Common_ETRS.ETranslators__Equal__Int32.sm_Instance__NullableInt64)
   .Add(Common_ETRS.ETranslators__Equal__Int32.sm_Instance__NullableSByte)
   .Add(Common_ETRS.ETranslators__Equal__Int32.sm_Instance__NullableSingle)

   .Add(Common_ETRS.ETranslators__Equal__Int64.sm_Instance__Byte)
   .Add(Common_ETRS.ETranslators__Equal__Int64.sm_Instance__Decimal)
   .Add(Common_ETRS.ETranslators__Equal__Int64.sm_Instance__Double)
   .Add(Common_ETRS.ETranslators__Equal__Int64.sm_Instance__Int16)
   .Add(Common_ETRS.ETranslators__Equal__Int64.sm_Instance__Int32)
   .Add(Common_ETRS.ETranslators__Equal__Int64.sm_Instance__Int64)
   .Add(Common_ETRS.ETranslators__Equal__Int64.sm_Instance__SByte)
   .Add(Common_ETRS.ETranslators__Equal__Int64.sm_Instance__Single)
   .Add(Common_ETRS.ETranslators__Equal__Int64.sm_Instance__NullableByte)
   .Add(Common_ETRS.ETranslators__Equal__Int64.sm_Instance__NullableDecimal)
   .Add(Common_ETRS.ETranslators__Equal__Int64.sm_Instance__NullableDouble)
   .Add(Common_ETRS.ETranslators__Equal__Int64.sm_Instance__NullableInt16)
   .Add(Common_ETRS.ETranslators__Equal__Int64.sm_Instance__NullableInt32)
   .Add(Common_ETRS.ETranslators__Equal__Int64.sm_Instance__NullableInt64)
   .Add(Common_ETRS.ETranslators__Equal__Int64.sm_Instance__NullableSByte)
   .Add(Common_ETRS.ETranslators__Equal__Int64.sm_Instance__NullableSingle)

   .Add(Common_ETRS.ETranslators__Equal__NullableBoolean.sm_Instance__Boolean)
   .Add(Common_ETRS.ETranslators__Equal__NullableBoolean.sm_Instance__String)
   .Add(Common_ETRS.ETranslators__Equal__NullableBoolean.sm_Instance__NullableBoolean)

   .Add(Common_ETRS.ETranslators__Equal__NullableByte.sm_Instance__Byte)
   .Add(Common_ETRS.ETranslators__Equal__NullableByte.sm_Instance__Decimal)
   .Add(Common_ETRS.ETranslators__Equal__NullableByte.sm_Instance__Double)
   .Add(Common_ETRS.ETranslators__Equal__NullableByte.sm_Instance__Int16)
   .Add(Common_ETRS.ETranslators__Equal__NullableByte.sm_Instance__Int32)
   .Add(Common_ETRS.ETranslators__Equal__NullableByte.sm_Instance__Int64)
   .Add(Common_ETRS.ETranslators__Equal__NullableByte.sm_Instance__SByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableByte.sm_Instance__Single)
   .Add(Common_ETRS.ETranslators__Equal__NullableByte.sm_Instance__NullableByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableByte.sm_Instance__NullableDecimal)
   .Add(Common_ETRS.ETranslators__Equal__NullableByte.sm_Instance__NullableDouble)
   .Add(Common_ETRS.ETranslators__Equal__NullableByte.sm_Instance__NullableInt16)
   .Add(Common_ETRS.ETranslators__Equal__NullableByte.sm_Instance__NullableInt32)
   .Add(Common_ETRS.ETranslators__Equal__NullableByte.sm_Instance__NullableInt64)
   .Add(Common_ETRS.ETranslators__Equal__NullableByte.sm_Instance__NullableSByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableByte.sm_Instance__NullableSingle)

   .Add(Common_ETRS.ETranslators__Equal__NullableDateOnly.sm_Instance__DateOnly)
   .Add(Common_ETRS.ETranslators__Equal__NullableDateOnly.sm_Instance__String)
   .Add(Common_ETRS.ETranslators__Equal__NullableDateOnly.sm_Instance__NullableDateOnly)

   .Add(FB3_D0_ETRS.ETranslators__Equal__NullableDateTime.sm_Instance__DateTime)
   .Add(Common_ETRS.ETranslators__Equal__NullableDateTime.sm_Instance__String)
   .Add(FB3_D0_ETRS.ETranslators__Equal__NullableDateTime.sm_Instance__NullableDateTime)

   .Add(Common_ETRS.ETranslators__Equal__NullableDecimal.sm_Instance__Byte)
   .Add(Common_ETRS.ETranslators__Equal__NullableDecimal.sm_Instance__Decimal)
   .Add(Common_ETRS.ETranslators__Equal__NullableDecimal.sm_Instance__Double)
   .Add(Common_ETRS.ETranslators__Equal__NullableDecimal.sm_Instance__Int16)
   .Add(Common_ETRS.ETranslators__Equal__NullableDecimal.sm_Instance__Int32)
   .Add(Common_ETRS.ETranslators__Equal__NullableDecimal.sm_Instance__Int64)
   .Add(Common_ETRS.ETranslators__Equal__NullableDecimal.sm_Instance__SByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableDecimal.sm_Instance__Single)
   .Add(Common_ETRS.ETranslators__Equal__NullableDecimal.sm_Instance__NullableByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableDecimal.sm_Instance__NullableDecimal)
   .Add(Common_ETRS.ETranslators__Equal__NullableDecimal.sm_Instance__NullableDouble)
   .Add(Common_ETRS.ETranslators__Equal__NullableDecimal.sm_Instance__NullableInt16)
   .Add(Common_ETRS.ETranslators__Equal__NullableDecimal.sm_Instance__NullableInt32)
   .Add(Common_ETRS.ETranslators__Equal__NullableDecimal.sm_Instance__NullableInt64)
   .Add(Common_ETRS.ETranslators__Equal__NullableDecimal.sm_Instance__NullableSByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableDecimal.sm_Instance__NullableSingle)

   .Add(Common_ETRS.ETranslators__Equal__NullableDouble.sm_Instance__Byte)
   .Add(Common_ETRS.ETranslators__Equal__NullableDouble.sm_Instance__Decimal)
   .Add(Common_ETRS.ETranslators__Equal__NullableDouble.sm_Instance__Double)
   .Add(Common_ETRS.ETranslators__Equal__NullableDouble.sm_Instance__Int16)
   .Add(Common_ETRS.ETranslators__Equal__NullableDouble.sm_Instance__Int32)
   .Add(Common_ETRS.ETranslators__Equal__NullableDouble.sm_Instance__Int64)
   .Add(Common_ETRS.ETranslators__Equal__NullableDouble.sm_Instance__SByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableDouble.sm_Instance__Single)
   .Add(Common_ETRS.ETranslators__Equal__NullableDouble.sm_Instance__NullableByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableDouble.sm_Instance__NullableDecimal)
   .Add(Common_ETRS.ETranslators__Equal__NullableDouble.sm_Instance__NullableDouble)
   .Add(Common_ETRS.ETranslators__Equal__NullableDouble.sm_Instance__NullableInt16)
   .Add(Common_ETRS.ETranslators__Equal__NullableDouble.sm_Instance__NullableInt32)
   .Add(Common_ETRS.ETranslators__Equal__NullableDouble.sm_Instance__NullableInt64)
   .Add(Common_ETRS.ETranslators__Equal__NullableDouble.sm_Instance__NullableSByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableDouble.sm_Instance__NullableSingle)

   .Add(Common_ETRS.ETranslators__Equal__NullableGuid.sm_Instance__Guid)
   .Add(Common_ETRS.ETranslators__Equal__NullableGuid.sm_Instance__NullableGuid)

   .Add(Common_ETRS.ETranslators__Equal__NullableInt16.sm_Instance__Byte)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt16.sm_Instance__Decimal)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt16.sm_Instance__Double)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt16.sm_Instance__Int16)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt16.sm_Instance__Int32)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt16.sm_Instance__Int64)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt16.sm_Instance__SByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt16.sm_Instance__Single)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt16.sm_Instance__NullableByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt16.sm_Instance__NullableDecimal)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt16.sm_Instance__NullableDouble)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt16.sm_Instance__NullableInt16)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt16.sm_Instance__NullableInt32)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt16.sm_Instance__NullableInt64)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt16.sm_Instance__NullableSByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt16.sm_Instance__NullableSingle)

   .Add(Common_ETRS.ETranslators__Equal__NullableInt32.sm_Instance__Byte)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt32.sm_Instance__Decimal)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt32.sm_Instance__Double)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt32.sm_Instance__Int16)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt32.sm_Instance__Int32)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt32.sm_Instance__Int64)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt32.sm_Instance__SByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt32.sm_Instance__Single)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt32.sm_Instance__NullableByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt32.sm_Instance__NullableDecimal)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt32.sm_Instance__NullableDouble)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt32.sm_Instance__NullableInt16)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt32.sm_Instance__NullableInt32)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt32.sm_Instance__NullableInt64)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt32.sm_Instance__NullableSByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt32.sm_Instance__NullableSingle)

   .Add(Common_ETRS.ETranslators__Equal__NullableInt64.sm_Instance__Byte)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt64.sm_Instance__Decimal)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt64.sm_Instance__Double)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt64.sm_Instance__Int16)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt64.sm_Instance__Int32)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt64.sm_Instance__Int64)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt64.sm_Instance__SByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt64.sm_Instance__Single)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt64.sm_Instance__NullableByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt64.sm_Instance__NullableDecimal)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt64.sm_Instance__NullableDouble)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt64.sm_Instance__NullableInt16)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt64.sm_Instance__NullableInt32)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt64.sm_Instance__NullableInt64)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt64.sm_Instance__NullableSByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableInt64.sm_Instance__NullableSingle)

   .Add(Common_ETRS.ETranslators__Equal__NullableSByte.sm_Instance__Byte)
   .Add(Common_ETRS.ETranslators__Equal__NullableSByte.sm_Instance__Decimal)
   .Add(Common_ETRS.ETranslators__Equal__NullableSByte.sm_Instance__Double)
   .Add(Common_ETRS.ETranslators__Equal__NullableSByte.sm_Instance__Int16)
   .Add(Common_ETRS.ETranslators__Equal__NullableSByte.sm_Instance__Int32)
   .Add(Common_ETRS.ETranslators__Equal__NullableSByte.sm_Instance__Int64)
   .Add(Common_ETRS.ETranslators__Equal__NullableSByte.sm_Instance__SByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableSByte.sm_Instance__Single)
   .Add(Common_ETRS.ETranslators__Equal__NullableSByte.sm_Instance__NullableByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableSByte.sm_Instance__NullableDecimal)
   .Add(Common_ETRS.ETranslators__Equal__NullableSByte.sm_Instance__NullableDouble)
   .Add(Common_ETRS.ETranslators__Equal__NullableSByte.sm_Instance__NullableInt16)
   .Add(Common_ETRS.ETranslators__Equal__NullableSByte.sm_Instance__NullableInt32)
   .Add(Common_ETRS.ETranslators__Equal__NullableSByte.sm_Instance__NullableInt64)
   .Add(Common_ETRS.ETranslators__Equal__NullableSByte.sm_Instance__NullableSByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableSByte.sm_Instance__NullableSingle)

   .Add(Common_ETRS.ETranslators__Equal__NullableSingle.sm_Instance__Byte)
   .Add(Common_ETRS.ETranslators__Equal__NullableSingle.sm_Instance__Decimal)
   .Add(Common_ETRS.ETranslators__Equal__NullableSingle.sm_Instance__Double)
   .Add(Common_ETRS.ETranslators__Equal__NullableSingle.sm_Instance__Int16)
   .Add(Common_ETRS.ETranslators__Equal__NullableSingle.sm_Instance__Int32)
   .Add(Common_ETRS.ETranslators__Equal__NullableSingle.sm_Instance__Int64)
   .Add(Common_ETRS.ETranslators__Equal__NullableSingle.sm_Instance__SByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableSingle.sm_Instance__Single)
   .Add(Common_ETRS.ETranslators__Equal__NullableSingle.sm_Instance__NullableByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableSingle.sm_Instance__NullableDecimal)
   .Add(Common_ETRS.ETranslators__Equal__NullableSingle.sm_Instance__NullableDouble)
   .Add(Common_ETRS.ETranslators__Equal__NullableSingle.sm_Instance__NullableInt16)
   .Add(Common_ETRS.ETranslators__Equal__NullableSingle.sm_Instance__NullableInt32)
   .Add(Common_ETRS.ETranslators__Equal__NullableSingle.sm_Instance__NullableInt64)
   .Add(Common_ETRS.ETranslators__Equal__NullableSingle.sm_Instance__NullableSByte)
   .Add(Common_ETRS.ETranslators__Equal__NullableSingle.sm_Instance__NullableSingle)

   .Add(FB3_D0_ETRS.ETranslators__Equal__NullableTimeOnly.sm_Instance__TimeOnly)
   .Add(Common_ETRS.ETranslators__Equal__NullableTimeOnly.sm_Instance__String)
   .Add(FB3_D0_ETRS.ETranslators__Equal__NullableTimeOnly.sm_Instance__NullableTimeOnly)

   .Add(FB3_D0_ETRS.ETranslators__Equal__NullableTimeSpan.sm_Instance__TimeSpan)
   .Add(FB3_D0_ETRS.ETranslators__Equal__NullableTimeSpan.sm_Instance__NullableTimeSpan)

   .Add(Common_ETRS.ETranslators__Equal__Object.sm_Instance__Object)

   .Add(Common_ETRS.ETranslators__Equal__SByte.sm_Instance__Byte)
   .Add(Common_ETRS.ETranslators__Equal__SByte.sm_Instance__Decimal)
   .Add(Common_ETRS.ETranslators__Equal__SByte.sm_Instance__Double)
   .Add(Common_ETRS.ETranslators__Equal__SByte.sm_Instance__Int16)
   .Add(Common_ETRS.ETranslators__Equal__SByte.sm_Instance__Int32)
   .Add(Common_ETRS.ETranslators__Equal__SByte.sm_Instance__Int64)
   .Add(Common_ETRS.ETranslators__Equal__SByte.sm_Instance__SByte)
   .Add(Common_ETRS.ETranslators__Equal__SByte.sm_Instance__Single)
   .Add(Common_ETRS.ETranslators__Equal__SByte.sm_Instance__NullableByte)
   .Add(Common_ETRS.ETranslators__Equal__SByte.sm_Instance__NullableDecimal)
   .Add(Common_ETRS.ETranslators__Equal__SByte.sm_Instance__NullableDouble)
   .Add(Common_ETRS.ETranslators__Equal__SByte.sm_Instance__NullableInt16)
   .Add(Common_ETRS.ETranslators__Equal__SByte.sm_Instance__NullableInt32)
   .Add(Common_ETRS.ETranslators__Equal__SByte.sm_Instance__NullableInt64)
   .Add(Common_ETRS.ETranslators__Equal__SByte.sm_Instance__NullableSByte)
   .Add(Common_ETRS.ETranslators__Equal__SByte.sm_Instance__NullableSingle)

   .Add(Common_ETRS.ETranslators__Equal__Single.sm_Instance__Byte)
   .Add(Common_ETRS.ETranslators__Equal__Single.sm_Instance__Decimal)
   .Add(Common_ETRS.ETranslators__Equal__Single.sm_Instance__Double)
   .Add(Common_ETRS.ETranslators__Equal__Single.sm_Instance__Int16)
   .Add(Common_ETRS.ETranslators__Equal__Single.sm_Instance__Int32)
   .Add(Common_ETRS.ETranslators__Equal__Single.sm_Instance__Int64)
   .Add(Common_ETRS.ETranslators__Equal__Single.sm_Instance__SByte)
   .Add(Common_ETRS.ETranslators__Equal__Single.sm_Instance__Single)
   .Add(Common_ETRS.ETranslators__Equal__Single.sm_Instance__NullableByte)
   .Add(Common_ETRS.ETranslators__Equal__Single.sm_Instance__NullableDecimal)
   .Add(Common_ETRS.ETranslators__Equal__Single.sm_Instance__NullableDouble)
   .Add(Common_ETRS.ETranslators__Equal__Single.sm_Instance__NullableInt16)
   .Add(Common_ETRS.ETranslators__Equal__Single.sm_Instance__NullableInt32)
   .Add(Common_ETRS.ETranslators__Equal__Single.sm_Instance__NullableInt64)
   .Add(Common_ETRS.ETranslators__Equal__Single.sm_Instance__NullableSByte)
   .Add(Common_ETRS.ETranslators__Equal__Single.sm_Instance__NullableSingle)

   .Add(Common_ETRS.ETranslators__Equal__String.sm_Instance__Boolean)
   .Add(Common_ETRS.ETranslators__Equal__String.sm_Instance__DateOnly)
   .Add(Common_ETRS.ETranslators__Equal__String.sm_Instance__DateTime)
   .Add(Common_ETRS.ETranslators__Equal__String.sm_Instance__String)
   .Add(Common_ETRS.ETranslators__Equal__String.sm_Instance__TimeOnly)
   .Add(Common_ETRS.ETranslators__Equal__String.sm_Instance__NullableBoolean)
   .Add(Common_ETRS.ETranslators__Equal__String.sm_Instance__NullableDateOnly)
   .Add(Common_ETRS.ETranslators__Equal__String.sm_Instance__NullableDateTime)
   .Add(Common_ETRS.ETranslators__Equal__String.sm_Instance__NullableTimeOnly)

   .Add(FB3_D0_ETRS.ETranslators__Equal__TimeOnly.sm_Instance__TimeOnly)
   .Add(Common_ETRS.ETranslators__Equal__TimeOnly.sm_Instance__String)
   .Add(FB3_D0_ETRS.ETranslators__Equal__TimeOnly.sm_Instance__NullableTimeOnly)

   .Add(FB3_D0_ETRS.ETranslators__Equal__TimeSpan.sm_Instance__TimeSpan)
   .Add(FB3_D0_ETRS.ETranslators__Equal__TimeSpan.sm_Instance__NullableTimeSpan)

   /*END*/
   ;

  return Map;
 }//Helper__Reg__Equal
};//class FB_Data__Expressions_Local__Op2__V_V

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D1.Expressions
