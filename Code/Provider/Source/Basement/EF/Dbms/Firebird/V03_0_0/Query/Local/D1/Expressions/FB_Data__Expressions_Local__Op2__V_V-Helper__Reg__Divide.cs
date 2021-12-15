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
 private static LcpiOleDb__LocalEval_Op2__Map Helper__Reg__Divide(LcpiOleDb__LocalEval_Op2__Map Map)
 {
  Debug.Assert(!Object.ReferenceEquals(Map,null));

  Map
   .Reg(LcpiOleDb__ExpressionType.Divide)

   .Add(FB3_D0_ETRS.ETranslators__Divide__Decimal.sm_Instance__Decimal)                        //Double
   .Add(FB3_D0_ETRS.ETranslators__Divide__Decimal.sm_Instance__Double)                         //Double
   .Add(FB3_D0_ETRS.ETranslators__Divide__Decimal.sm_Instance__NullableDecimal)                //Double?
   .Add(FB3_D0_ETRS.ETranslators__Divide__Decimal.sm_Instance__NullableDouble)                 //Double?

   .Add(FB3_D0_ETRS.ETranslators__Divide__Double.sm_Instance__Decimal)                         //Double
   .Add(FB3_D0_ETRS.ETranslators__Divide__Double.sm_Instance__Double)                          //Double
   .Add(FB3_D1_ETRS.ETranslators__Divide__Double.sm_Instance__Int16)                           //Double
   .Add(FB3_D1_ETRS.ETranslators__Divide__Double.sm_Instance__Int32)                           //Double
   .Add(FB3_D1_ETRS.ETranslators__Divide__Double.sm_Instance__Int64)                           //Double
   .Add(FB3_D0_ETRS.ETranslators__Divide__Double.sm_Instance__Single)                          //Double
   .Add(FB3_D0_ETRS.ETranslators__Divide__Double.sm_Instance__NullableDecimal)                 //Double?
   .Add(FB3_D0_ETRS.ETranslators__Divide__Double.sm_Instance__NullableDouble)                  //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__Double.sm_Instance__NullableInt16)                   //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__Double.sm_Instance__NullableInt32)                   //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__Double.sm_Instance__NullableInt64)                   //Double?
   .Add(FB3_D0_ETRS.ETranslators__Divide__Double.sm_Instance__NullableSingle)                  //Double?

   .Add(FB3_D1_ETRS.ETranslators__Divide__Int16.sm_Instance__Double)                           //Double
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int16.sm_Instance__Int16)                            //Double
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int16.sm_Instance__Int32)                            //Double
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int16.sm_Instance__Int64)                            //Double
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int16.sm_Instance__NullableDouble)                   //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int16.sm_Instance__NullableInt16)                    //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int16.sm_Instance__NullableInt32)                    //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int16.sm_Instance__NullableInt64)                    //Double?

   .Add(FB3_D1_ETRS.ETranslators__Divide__Int32.sm_Instance__Double)                           //Double
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int32.sm_Instance__Int16)                            //Double
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int32.sm_Instance__Int32)                            //Double
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int32.sm_Instance__Int64)                            //Double
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int32.sm_Instance__NullableDouble)                   //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int32.sm_Instance__NullableInt16)                    //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int32.sm_Instance__NullableInt32)                    //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int32.sm_Instance__NullableInt64)                    //Double?

   .Add(FB3_D1_ETRS.ETranslators__Divide__Int64.sm_Instance__Double)                           //Double
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int64.sm_Instance__Int16)                            //Double
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int64.sm_Instance__Int32)                            //Double
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int64.sm_Instance__Int64)                            //Double
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int64.sm_Instance__NullableDouble)                   //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int64.sm_Instance__NullableInt16)                    //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int64.sm_Instance__NullableInt32)                    //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__Int64.sm_Instance__NullableInt64)                    //Double?

   .Add(FB3_D0_ETRS.ETranslators__Divide__NullableDecimal.sm_Instance__Decimal)                //Double?
   .Add(FB3_D0_ETRS.ETranslators__Divide__NullableDecimal.sm_Instance__Double)                 //Double?
   .Add(FB3_D0_ETRS.ETranslators__Divide__NullableDecimal.sm_Instance__NullableDecimal)        //Double?
   .Add(FB3_D0_ETRS.ETranslators__Divide__NullableDecimal.sm_Instance__NullableDouble)         //Double?

   .Add(FB3_D0_ETRS.ETranslators__Divide__NullableDouble.sm_Instance__Decimal)                 //Double?
   .Add(FB3_D0_ETRS.ETranslators__Divide__NullableDouble.sm_Instance__Double)                  //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableDouble.sm_Instance__Int16)                   //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableDouble.sm_Instance__Int32)                   //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableDouble.sm_Instance__Int64)                   //Double?
   .Add(FB3_D0_ETRS.ETranslators__Divide__NullableDouble.sm_Instance__Single)                  //Double?
   .Add(FB3_D0_ETRS.ETranslators__Divide__NullableDouble.sm_Instance__NullableDecimal)         //Double?
   .Add(FB3_D0_ETRS.ETranslators__Divide__NullableDouble.sm_Instance__NullableDouble)          //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableDouble.sm_Instance__NullableInt16)           //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableDouble.sm_Instance__NullableInt32)           //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableDouble.sm_Instance__NullableInt64)           //Double?
   .Add(FB3_D0_ETRS.ETranslators__Divide__NullableDouble.sm_Instance__NullableSingle)          //Double?

   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt16.sm_Instance__Double)                   //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt16.sm_Instance__Int16)                    //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt16.sm_Instance__Int32)                    //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt16.sm_Instance__Int64)                    //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt16.sm_Instance__NullableDouble)           //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt16.sm_Instance__NullableInt16)            //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt16.sm_Instance__NullableInt32)            //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt16.sm_Instance__NullableInt64)            //Double?

   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt32.sm_Instance__Double)                   //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt32.sm_Instance__Int16)                    //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt32.sm_Instance__Int32)                    //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt32.sm_Instance__Int64)                    //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt32.sm_Instance__NullableDouble)           //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt32.sm_Instance__NullableInt16)            //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt32.sm_Instance__NullableInt32)            //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt32.sm_Instance__NullableInt64)            //Double?

   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt64.sm_Instance__Double)                   //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt64.sm_Instance__Int16)                    //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt64.sm_Instance__Int32)                    //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt64.sm_Instance__Int64)                    //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt64.sm_Instance__NullableDouble)           //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt64.sm_Instance__NullableInt16)            //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt64.sm_Instance__NullableInt32)            //Double?
   .Add(FB3_D1_ETRS.ETranslators__Divide__NullableInt64.sm_Instance__NullableInt64)            //Double?

   .Add(FB3_D0_ETRS.ETranslators__Divide__NullableSingle.sm_Instance__Double)                  //Double?
   .Add(FB3_D0_ETRS.ETranslators__Divide__NullableSingle.sm_Instance__Single)                  //Double?
   .Add(FB3_D0_ETRS.ETranslators__Divide__NullableSingle.sm_Instance__NullableDouble)          //Double?
   .Add(FB3_D0_ETRS.ETranslators__Divide__NullableSingle.sm_Instance__NullableSingle)          //Double?

   .Add(FB3_D0_ETRS.ETranslators__Divide__Single.sm_Instance__Double)                          //Double
   .Add(FB3_D0_ETRS.ETranslators__Divide__Single.sm_Instance__Single)                          //Double
   .Add(FB3_D0_ETRS.ETranslators__Divide__Single.sm_Instance__NullableDouble)                  //Double?
   .Add(FB3_D0_ETRS.ETranslators__Divide__Single.sm_Instance__NullableSingle)                  //Double?

   /*END*/
   ;

  return Map;
 }//Helper__Reg__Divide
};//class FB_Data__Expressions_Local__Op2__V_V

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Query.Local.D1.Expressions
