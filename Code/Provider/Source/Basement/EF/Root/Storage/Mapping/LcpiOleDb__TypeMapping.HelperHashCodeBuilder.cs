////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 01.10.2021.
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage.Mapping{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__TypeMapping

abstract partial class LcpiOleDb__TypeMapping:RelationalTypeMapping
{
 private static class HelperHashCodeBuilder
 {
  public static int Exec(LcpiOleDb__TypeMapping x1)
  {
   Debug.Assert(!Object.ReferenceEquals(x1,null));

   //--------------------------------------- RelationalTypeMapping
   int resultValue
    =Exec(x1.Parameters);

   resultValue
    =Helper__Combine(resultValue,x1.SqlLiteralFormatString);

   return resultValue;
  }//Exec - LcpiOleDb__TypeMapping

  //-------------------------------------------------------
  public static int Exec(in RelationalTypeMappingParameters x1)
  {
   int resultValue
    =Exec(x1.CoreParameters);

   resultValue
    =Helper__Combine(resultValue,x1.StoreType);

   resultValue
    =Helper__Combine_N(resultValue,x1.DbType);

   resultValue
    =Helper__Combine_V(resultValue,x1.Unicode);

   resultValue
    =Helper__Combine_N(resultValue,x1.Size);

   resultValue
    =Helper__Combine_N(resultValue,x1.Precision);

   resultValue
    =Helper__Combine_N(resultValue,x1.Scale);

   resultValue
    =Helper__Combine_V(resultValue,x1.FixedLength);

   resultValue
    =Helper__Combine_V(resultValue,x1.StoreTypePostfix);

   return resultValue;
  }//Exec - RelationalTypeMappingParameters

  //------------------------------------------------------------
  public static int Exec(in CoreTypeMappingParameters x1)
  {
   int resultValue
    =Helper__Combine(0,x1.ClrType);

   resultValue
    =Helper__Combine(resultValue,x1.Converter);

   resultValue
    =Helper__Combine(resultValue,x1.Comparer);

   resultValue
    =Helper__Combine(resultValue,x1.KeyComparer);

   //obsoled in EFCore 5.0
   //x1.StructuralComparer

   resultValue
    =Helper__Combine(resultValue,x1.ValueGeneratorFactory);

   return resultValue;
  }//Exec - CoreTypeMappingParameters

  //Helper methods ---------------------------------------------
  private static int Helper__Combine<T>(int hashCode,T obj)
   where T:class
  {
   if(Object.ReferenceEquals(obj,null))
    return hashCode;

   unchecked
   {
    int newHashCode
     =(hashCode*397)^obj.GetHashCode();

    return newHashCode;
   }//unchecked
  }//Helper__Combine

  //------------------------------------------------------------
  private static int Helper__Combine_V<T>(int hashCode,T obj)
   where T:struct
  {
   unchecked
   {
    int newHashCode
     =(hashCode*397)^obj.GetHashCode();

    return newHashCode;
   }//unchecked
  }//Helper__Combine_V

  //------------------------------------------------------------
  private static int Helper__Combine_N<T>(int hashCode,Nullable<T> obj)
   where T:struct
  {
   if(!obj.HasValue)
    return hashCode;

   unchecked
   {
    int newHashCode
     =(hashCode*397)^obj.GetHashCode();

    return newHashCode;
   }//unchecked
  }//Helper__Combine_N
 };//class HelperComparer
};//class LcpiOleDb__TypeMapping

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage.Mapping
