////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 28.05.2021.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Sql{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MethodParameterDescr
 =Structure.Structure_MethodParameterDescr;

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using T_TEST_RESULT
 =Structure.Structure_TestConversionResult;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__TestSafeSqlConversion

static class LcpiOleDb__TestSafeSqlConversion
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__TestSafeSqlConversion;

 //-----------------------------------------------------------------------
 public static T_TEST_RESULT Exec
                             (SqlExpression                  callArg,
                              Structure_MethodParameterDescr parameterDescr)
 {
  Debug.Assert(!Object.ReferenceEquals(callArg,null));
  Debug.Assert(!Object.ReferenceEquals(callArg.Type,null));

  Debug.Assert(!Object.ReferenceEquals(parameterDescr,null));
  Debug.Assert(!Object.ReferenceEquals(parameterDescr.ParameterType,null));

  //[2021-09-03] Expected
  Debug.Assert(parameterDescr.ParameterType==parameterDescr.ParameterType.Extension__SwitchToUnderlying());

  //-------------------------------------------------------
  const string c_bugcheck_src
   ="LcpiOleDb__TestSafeSqlConversion::Exec";

  //-------------------------------------------------------
  var callArg_sqlType
   =Core.SQL.Core_SQL__ExpressionUtils.GetSqlType
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      callArg);

  Debug.Assert(!Object.ReferenceEquals(callArg_sqlType,null));

  Debug.Assert(callArg_sqlType==callArg_sqlType.Extension__UnwrapNullableType());

  //-------------------------------------------------------
  var result
   =Core.Core_TestSafeConversion.Exec
     (callArg_sqlType,
      parameterDescr.ParameterType);

  return result;
 }//Exec
};//class LcpiOleDb__TestSafeSqlConversion

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Sql
