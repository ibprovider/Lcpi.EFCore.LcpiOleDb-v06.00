////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 23.06.2021.
using System;
using System.Diagnostics;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Translators.Code{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Nodes
 =Common.Query.Sql.Expressions.Nodes;

using FB_Common__TypeMappingCache
 =Common.FB_Common__TypeMappingCache;

using FB_Common__Sql_ETranslator_Op2
 =Common.Query.Sql.Expressions.Translators.FB_Common__Sql_ETranslator_Op2;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__Sql_ETranslator_Op2__Coalesce

sealed class FB_V03_0_0__Sql_ETranslator_Op2__Coalesce
 :FB_Common__Sql_ETranslator_Op2
{
 public static readonly FB_Common__Sql_ETranslator_Op2
  Instance
   =new FB_V03_0_0__Sql_ETranslator_Op2__Coalesce();

 //-----------------------------------------------------------------------
 private FB_V03_0_0__Sql_ETranslator_Op2__Coalesce()
 {
 }//FB_V03_0_0__Sql_ETranslator_Op2__Coalesce

 //FB_Common__Sql_ETranslator_Op2 interface ------------------------------
 public override SqlExpression Translate(in tagOpData opData)
 {
  Debug.Assert(opData.OperationType==LcpiOleDb__ExpressionType.Coalesce);

  Debug.Assert(!Object.ReferenceEquals(opData.SqlLeft,null));
  Debug.Assert(!Object.ReferenceEquals(opData.SqlRight,null));
  //Debug.Assert(!Object.ReferenceEquals(opData.SqlResultTypeMapping,null));

  //------------------------------------------------------------
#if DEBUG
  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (opData.SqlLeft);

  Core.SQL.Core_SQL__ExpressionUtils.DEBUG__CheckSqlTypeMapping
   (opData.SqlRight);
#endif

  //------------------------------------------------------------
  var arguments
   =new[]
    {
     opData.SqlLeft,
     opData.SqlRight
    };

  var r
   =Nodes.FB_Common__Sql_ENode_Function__SQL__COALESCE.Create
     (arguments,
      sm_SupportedStates);

  Debug.Assert(!Object.ReferenceEquals(r,null));

  return r;
 }//Translate

 //private data ----------------------------------------------------------
 private static readonly Nodes.Helpers.Map_Op2ResultTypeMappings
  sm_SupportedStates
   =new Nodes.Helpers.Map_Op2ResultTypeMappings()
       .Add(Structure_TypeCache.TypeOf__System_Int16      ,Structure_TypeCache.TypeOf__System_Int16      ,FB_Common__TypeMappingCache.TypeMapping__INT16)
       .Add(Structure_TypeCache.TypeOf__System_Int16      ,Structure_TypeCache.TypeOf__System_Int32      ,FB_Common__TypeMappingCache.TypeMapping__INT32)
       .Add(Structure_TypeCache.TypeOf__System_Int16      ,Structure_TypeCache.TypeOf__System_Int64      ,FB_Common__TypeMappingCache.TypeMapping__INT64)
       .Add(Structure_TypeCache.TypeOf__System_Int16      ,Structure_TypeCache.TypeOf__System_Single     ,FB_Common__TypeMappingCache.TypeMapping__FLOAT)
       .Add(Structure_TypeCache.TypeOf__System_Int16      ,Structure_TypeCache.TypeOf__System_Double     ,FB_Common__TypeMappingCache.TypeMapping__DOUBLE)
       .Add(Structure_TypeCache.TypeOf__System_Int16      ,Structure_TypeCache.TypeOf__System_Decimal    ,FB_Common__TypeMappingCache.TypeMapping__DECIMAL)
       .Add(Structure_TypeCache.TypeOf__System_Int16      ,Structure_TypeCache.TypeOf__System_String     ,FB_Common__TypeMappingCache.TypeMapping__TEXT)

       .Add(Structure_TypeCache.TypeOf__System_Int32      ,Structure_TypeCache.TypeOf__System_Int16      ,FB_Common__TypeMappingCache.TypeMapping__INT32)
       .Add(Structure_TypeCache.TypeOf__System_Int32      ,Structure_TypeCache.TypeOf__System_Int32      ,FB_Common__TypeMappingCache.TypeMapping__INT32)
       .Add(Structure_TypeCache.TypeOf__System_Int32      ,Structure_TypeCache.TypeOf__System_Int64      ,FB_Common__TypeMappingCache.TypeMapping__INT64)
       .Add(Structure_TypeCache.TypeOf__System_Int32      ,Structure_TypeCache.TypeOf__System_Single     ,FB_Common__TypeMappingCache.TypeMapping__FLOAT)
       .Add(Structure_TypeCache.TypeOf__System_Int32      ,Structure_TypeCache.TypeOf__System_Double     ,FB_Common__TypeMappingCache.TypeMapping__DOUBLE)
       .Add(Structure_TypeCache.TypeOf__System_Int32      ,Structure_TypeCache.TypeOf__System_Decimal    ,FB_Common__TypeMappingCache.TypeMapping__DECIMAL)
       .Add(Structure_TypeCache.TypeOf__System_Int32      ,Structure_TypeCache.TypeOf__System_String     ,FB_Common__TypeMappingCache.TypeMapping__TEXT)

       .Add(Structure_TypeCache.TypeOf__System_Int64      ,Structure_TypeCache.TypeOf__System_Int16      ,FB_Common__TypeMappingCache.TypeMapping__INT64)
       .Add(Structure_TypeCache.TypeOf__System_Int64      ,Structure_TypeCache.TypeOf__System_Int32      ,FB_Common__TypeMappingCache.TypeMapping__INT64)
       .Add(Structure_TypeCache.TypeOf__System_Int64      ,Structure_TypeCache.TypeOf__System_Int64      ,FB_Common__TypeMappingCache.TypeMapping__INT64)
       .Add(Structure_TypeCache.TypeOf__System_Int64      ,Structure_TypeCache.TypeOf__System_Single     ,FB_Common__TypeMappingCache.TypeMapping__FLOAT)
       .Add(Structure_TypeCache.TypeOf__System_Int64      ,Structure_TypeCache.TypeOf__System_Double     ,FB_Common__TypeMappingCache.TypeMapping__DOUBLE)
       .Add(Structure_TypeCache.TypeOf__System_Int64      ,Structure_TypeCache.TypeOf__System_Decimal    ,FB_Common__TypeMappingCache.TypeMapping__DECIMAL)
       .Add(Structure_TypeCache.TypeOf__System_Int64      ,Structure_TypeCache.TypeOf__System_String     ,FB_Common__TypeMappingCache.TypeMapping__TEXT)

       .Add(Structure_TypeCache.TypeOf__System_Single     ,Structure_TypeCache.TypeOf__System_Int16      ,FB_Common__TypeMappingCache.TypeMapping__FLOAT)
       .Add(Structure_TypeCache.TypeOf__System_Single     ,Structure_TypeCache.TypeOf__System_Int32      ,FB_Common__TypeMappingCache.TypeMapping__FLOAT)
       .Add(Structure_TypeCache.TypeOf__System_Single     ,Structure_TypeCache.TypeOf__System_Int64      ,FB_Common__TypeMappingCache.TypeMapping__FLOAT)
       .Add(Structure_TypeCache.TypeOf__System_Single     ,Structure_TypeCache.TypeOf__System_Single     ,FB_Common__TypeMappingCache.TypeMapping__FLOAT)
       .Add(Structure_TypeCache.TypeOf__System_Single     ,Structure_TypeCache.TypeOf__System_Double     ,FB_Common__TypeMappingCache.TypeMapping__DOUBLE)
       .Add(Structure_TypeCache.TypeOf__System_Single     ,Structure_TypeCache.TypeOf__System_Decimal    ,FB_Common__TypeMappingCache.TypeMapping__FLOAT)
       .Add(Structure_TypeCache.TypeOf__System_Single     ,Structure_TypeCache.TypeOf__System_String     ,FB_Common__TypeMappingCache.TypeMapping__TEXT)

       .Add(Structure_TypeCache.TypeOf__System_Double     ,Structure_TypeCache.TypeOf__System_Int16      ,FB_Common__TypeMappingCache.TypeMapping__DOUBLE)
       .Add(Structure_TypeCache.TypeOf__System_Double     ,Structure_TypeCache.TypeOf__System_Int32      ,FB_Common__TypeMappingCache.TypeMapping__DOUBLE)
       .Add(Structure_TypeCache.TypeOf__System_Double     ,Structure_TypeCache.TypeOf__System_Int64      ,FB_Common__TypeMappingCache.TypeMapping__DOUBLE)
       .Add(Structure_TypeCache.TypeOf__System_Double     ,Structure_TypeCache.TypeOf__System_Single     ,FB_Common__TypeMappingCache.TypeMapping__DOUBLE)
       .Add(Structure_TypeCache.TypeOf__System_Double     ,Structure_TypeCache.TypeOf__System_Double     ,FB_Common__TypeMappingCache.TypeMapping__DOUBLE)
       .Add(Structure_TypeCache.TypeOf__System_Double     ,Structure_TypeCache.TypeOf__System_Decimal    ,FB_Common__TypeMappingCache.TypeMapping__DOUBLE)
       .Add(Structure_TypeCache.TypeOf__System_Double     ,Structure_TypeCache.TypeOf__System_String     ,FB_Common__TypeMappingCache.TypeMapping__TEXT)

       .Add(Structure_TypeCache.TypeOf__System_Decimal    ,Structure_TypeCache.TypeOf__System_Int16      ,FB_Common__TypeMappingCache.TypeMapping__DECIMAL)
       .Add(Structure_TypeCache.TypeOf__System_Decimal    ,Structure_TypeCache.TypeOf__System_Int32      ,FB_Common__TypeMappingCache.TypeMapping__DECIMAL)
       .Add(Structure_TypeCache.TypeOf__System_Decimal    ,Structure_TypeCache.TypeOf__System_Int64      ,FB_Common__TypeMappingCache.TypeMapping__DECIMAL)
       .Add(Structure_TypeCache.TypeOf__System_Decimal    ,Structure_TypeCache.TypeOf__System_Single     ,FB_Common__TypeMappingCache.TypeMapping__FLOAT)
       .Add(Structure_TypeCache.TypeOf__System_Decimal    ,Structure_TypeCache.TypeOf__System_Double     ,FB_Common__TypeMappingCache.TypeMapping__DOUBLE)
       .Add(Structure_TypeCache.TypeOf__System_Decimal    ,Structure_TypeCache.TypeOf__System_Decimal    ,FB_Common__TypeMappingCache.TypeMapping__DECIMAL)
       .Add(Structure_TypeCache.TypeOf__System_Decimal    ,Structure_TypeCache.TypeOf__System_String     ,FB_Common__TypeMappingCache.TypeMapping__TEXT)

       .Add(Structure_TypeCache.TypeOf__System_Boolean    ,Structure_TypeCache.TypeOf__System_Boolean    ,FB_Common__TypeMappingCache.TypeMapping__BOOLEAN)
       .Add(Structure_TypeCache.TypeOf__System_Boolean    ,Structure_TypeCache.TypeOf__System_String     ,FB_Common__TypeMappingCache.TypeMapping__TEXT)

       .Add(Structure_TypeCache.TypeOf__System_String     ,Structure_TypeCache.TypeOf__System_Int16      ,FB_Common__TypeMappingCache.TypeMapping__TEXT)
       .Add(Structure_TypeCache.TypeOf__System_String     ,Structure_TypeCache.TypeOf__System_Int32      ,FB_Common__TypeMappingCache.TypeMapping__TEXT)
       .Add(Structure_TypeCache.TypeOf__System_String     ,Structure_TypeCache.TypeOf__System_Int64      ,FB_Common__TypeMappingCache.TypeMapping__TEXT)
       .Add(Structure_TypeCache.TypeOf__System_String     ,Structure_TypeCache.TypeOf__System_Single     ,FB_Common__TypeMappingCache.TypeMapping__TEXT)
       .Add(Structure_TypeCache.TypeOf__System_String     ,Structure_TypeCache.TypeOf__System_Double     ,FB_Common__TypeMappingCache.TypeMapping__TEXT)
       .Add(Structure_TypeCache.TypeOf__System_String     ,Structure_TypeCache.TypeOf__System_Decimal    ,FB_Common__TypeMappingCache.TypeMapping__TEXT)
       .Add(Structure_TypeCache.TypeOf__System_String     ,Structure_TypeCache.TypeOf__System_TimeOnly   ,FB_Common__TypeMappingCache.TypeMapping__TEXT)
       .Add(Structure_TypeCache.TypeOf__System_String     ,Structure_TypeCache.TypeOf__System_DateOnly   ,FB_Common__TypeMappingCache.TypeMapping__TEXT)
       .Add(Structure_TypeCache.TypeOf__System_String     ,Structure_TypeCache.TypeOf__System_DateTime   ,FB_Common__TypeMappingCache.TypeMapping__TEXT)
       .Add(Structure_TypeCache.TypeOf__System_String     ,Structure_TypeCache.TypeOf__System_Boolean    ,FB_Common__TypeMappingCache.TypeMapping__TEXT)
       .Add(Structure_TypeCache.TypeOf__System_String     ,Structure_TypeCache.TypeOf__System_String     ,FB_Common__TypeMappingCache.TypeMapping__TEXT)

       .Add(Structure_TypeCache.TypeOf__System_DateTime   ,Structure_TypeCache.TypeOf__System_DateTime   ,FB_Common__TypeMappingCache.TypeMapping__TIMESTAMP)
       .Add(Structure_TypeCache.TypeOf__System_DateTime   ,Structure_TypeCache.TypeOf__System_String     ,FB_Common__TypeMappingCache.TypeMapping__TEXT)

/*D3*/ .Add(Structure_TypeCache.TypeOf__System_TimeSpan   ,Structure_TypeCache.TypeOf__System_TimeSpan   ,FB_Common__TypeMappingCache.TypeMapping__TimeSpan__as_Decimal18_4)

/*D3*/ .Add(Structure_TypeCache.TypeOf__System_DateOnly   ,Structure_TypeCache.TypeOf__System_DateOnly   ,FB_Common__TypeMappingCache.TypeMapping_D3__TYPE_DATE__as_DateOnly)
       .Add(Structure_TypeCache.TypeOf__System_DateOnly   ,Structure_TypeCache.TypeOf__System_String     ,FB_Common__TypeMappingCache.TypeMapping__TEXT)

/*D3*/ .Add(Structure_TypeCache.TypeOf__System_TimeOnly   ,Structure_TypeCache.TypeOf__System_TimeOnly   ,FB_Common__TypeMappingCache.TypeMapping_D3__TIME__as_TimeOnly)
       .Add(Structure_TypeCache.TypeOf__System_TimeOnly   ,Structure_TypeCache.TypeOf__System_String     ,FB_Common__TypeMappingCache.TypeMapping__TEXT)

       /*END*/
       ;
};//class FB_V03_0_0__Sql_ETranslator_Op2__Coalesce

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Sql.D3.Expressions.Translators.Code
