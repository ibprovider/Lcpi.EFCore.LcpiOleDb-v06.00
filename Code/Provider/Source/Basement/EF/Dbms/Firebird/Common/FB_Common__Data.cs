////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 29.10.2020.
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common{
////////////////////////////////////////////////////////////////////////////////
//class FB_Common__Data

static class FB_Common__Data
{
 //-----------------------------------------------------------------------
 public static readonly ConstantExpression
  sm_ConstantExpression__Int16__ZERO
   =Expression.Constant((System.Int16)0,Structure.Structure_TypeCache.TypeOf__System_Int16);

 //-----------------------------------------------------------------------
 public static readonly ConstantExpression
  sm_ConstantExpression__Int32__ZERO
   =Expression.Constant((System.Int32)0,Structure.Structure_TypeCache.TypeOf__System_Int32);

 //-----------------------------------------------------------------------
 public static readonly ConstantExpression
  sm_ConstantExpression__Int64__ZERO
   =Expression.Constant((System.Int64)0,Structure.Structure_TypeCache.TypeOf__System_Int64);

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__Int16__ZERO
   =new SqlConstantExpression
     (sm_ConstantExpression__Int16__ZERO,
      FB_Common__TypeMappingCache.TypeMapping__INT16);

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__Int32__ZERO
   =new SqlConstantExpression
     (sm_ConstantExpression__Int32__ZERO,
      FB_Common__TypeMappingCache.TypeMapping__INT32);

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__Int32__NEGATIVE_ONE
   =new SqlConstantExpression
     (Expression.Constant(-1,Structure.Structure_TypeCache.TypeOf__System_Int32),
      FB_Common__TypeMappingCache.TypeMapping__INT32);

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__Int32__ONE
   =new SqlConstantExpression
     (Expression.Constant(1,Structure.Structure_TypeCache.TypeOf__System_Int32),
      FB_Common__TypeMappingCache.TypeMapping__INT32);

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__Int32__MillisecondsInDay
   =new SqlConstantExpression
     (Expression.Constant(24*60*60*1000,Structure.Structure_TypeCache.TypeOf__System_Int32), //86 400 000
      FB_Common__TypeMappingCache.TypeMapping__INT32);

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__Int32__MillisecondsInHour
   =new SqlConstantExpression
     (Expression.Constant(60*60*1000,Structure.Structure_TypeCache.TypeOf__System_Int32), //3 600 000
      FB_Common__TypeMappingCache.TypeMapping__INT32);

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__Int32__MillisecondsInMinute
   =new SqlConstantExpression
     (Expression.Constant(60*1000,Structure.Structure_TypeCache.TypeOf__System_Int32), // 60 000
      FB_Common__TypeMappingCache.TypeMapping__INT32);

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__Int32__MillisecondsInSecond
   =new SqlConstantExpression
     (Expression.Constant(1000,Structure.Structure_TypeCache.TypeOf__System_Int32), // 1 000
      FB_Common__TypeMappingCache.TypeMapping__INT32);

 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__Int32__MillisecondsInSecond__negative
   =new SqlConstantExpression
     (Expression.Constant(-1000,Structure.Structure_TypeCache.TypeOf__System_Int32), // -1 000
      FB_Common__TypeMappingCache.TypeMapping__INT32);

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__Int32__SecondsInDay
   =new SqlConstantExpression
     (Expression.Constant(24*60*60,Structure.Structure_TypeCache.TypeOf__System_Int32), //86 400
      FB_Common__TypeMappingCache.TypeMapping__INT32);

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__Int32__SecondsInHour
   =new SqlConstantExpression
     (Expression.Constant(60*60,Structure.Structure_TypeCache.TypeOf__System_Int32), //3 600
      FB_Common__TypeMappingCache.TypeMapping__INT32);

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__Int32__SecondsInMinute
   =new SqlConstantExpression
     (Expression.Constant(60,Structure.Structure_TypeCache.TypeOf__System_Int32), //60
      FB_Common__TypeMappingCache.TypeMapping__INT32);

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__Int64__ZERO
   =new SqlConstantExpression
     (sm_ConstantExpression__Int64__ZERO,
      FB_Common__TypeMappingCache.TypeMapping__INT64);

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__NUMERIC_4_3__MillisecondAsPartOfSecond
   =new SqlConstantExpression
     (Expression.Constant(0.001m,Structure.Structure_TypeCache.TypeOf__System_Decimal), // 0.001
      FB_Common__TypeMappingCache.TypeMapping__NUMERIC_4_3);
 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__Boolean__NULL
   =new SqlConstantExpression
     (Expression.Constant(null,Structure.Structure_TypeCache.TypeOf__System_NullableBoolean),
      FB_Common__TypeMappingCache.TypeMapping__BOOLEAN);

 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__Boolean__TRUE
   =new SqlConstantExpression
     (Expression.Constant(true,Structure.Structure_TypeCache.TypeOf__System_Boolean),
      FB_Common__TypeMappingCache.TypeMapping__BOOLEAN);

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__VARCHAR___EMPTY
   =new SqlConstantExpression
                         //""
     (Expression.Constant(string.Empty,Structure.Structure_TypeCache.TypeOf__System_String),
      Storage.Mapping.FB_Common__TypeMapping__VARCHAR.Create(1));

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__VARCHAR___DEFIS
   =new SqlConstantExpression
                         //1
     (Expression.Constant("-",Structure.Structure_TypeCache.TypeOf__System_String),
      Storage.Mapping.FB_Common__TypeMapping__VARCHAR.Create(1));

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__VARCHAR___OUT_OF_RANGE
   =new SqlConstantExpression
                         //123456789012
     (Expression.Constant("OUT OF RANGE",Structure.Structure_TypeCache.TypeOf__System_String),
      Storage.Mapping.FB_Common__TypeMapping__VARCHAR.Create(12));

 //-----------------------------------------------------------------------
 public static readonly SqlConstantExpression
  sm_SqlConstantExpression__VARCHAR___TRAP_FOR_NULL
   =new SqlConstantExpression
                         //1234567890123
     (Expression.Constant("TRAP FOR NULL",Structure.Structure_TypeCache.TypeOf__System_String),
      Storage.Mapping.FB_Common__TypeMapping__VARCHAR.Create(13));
};//class FB_Common__Data

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.Common
