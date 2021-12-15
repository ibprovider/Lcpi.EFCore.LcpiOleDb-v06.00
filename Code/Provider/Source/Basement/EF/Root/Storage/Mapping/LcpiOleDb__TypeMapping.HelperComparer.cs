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
 private static class HelperComparer
 {
  public static bool IsEquals(LcpiOleDb__TypeMapping x1,
                              LcpiOleDb__TypeMapping x2)
  {
   Debug.Assert(!Object.ReferenceEquals(x1,null));
   Debug.Assert(!Object.ReferenceEquals(x2,null));

   if(Object.ReferenceEquals(x1,x2))
    return true;

   //--------------------------------------- RelationalTypeMapping
   if(!IsEquals(x1.Parameters,x2.Parameters))
    return false;

   //Parameters.StoreTypePostfix
   Debug.Assert(x1.StoreTypePostfix   == x2.StoreTypePostfix);

   Debug.Assert(x1.StoreType          == x2.StoreType);

   Debug.Assert(x1.StoreTypeNameBase  == x2.StoreTypeNameBase);

   //Parameters.DbType;
   Debug.Assert(x1.DbType             == x2.DbType);

   //Parameters.Unicode
   Debug.Assert(x1.IsUnicode          == x2.IsUnicode);

   //Parameters.Size
   Debug.Assert(x1.Size               == x2.Size);

   //Parameters.Precision
   Debug.Assert(x1.Precision          == x2.Precision);

   //Parameters.Scale
   Debug.Assert(x1.Scale              == x2.Scale);

   //Parameters.IsFixedLength
   Debug.Assert(x1.IsFixedLength      == x2.IsFixedLength);

   if(x1.SqlLiteralFormatString != x2.SqlLiteralFormatString)
    return false;

   //--------------------------------------- CoreTypeMapping

   //Converter?.ModelClrType??Parameters.ClrType;
   Debug.Assert(x1.ClrType                == x2.ClrType);

   //Parameters.Converter
   Debug.Assert(x1.Converter              == x2.Converter);

   //Parameters.ValueGeneratorFactory??converter?.MappingHints?.ValueGeneratorFactory
   Debug.Assert(x1.ValueGeneratorFactory  == x2.ValueGeneratorFactory);

   //Debug.Assert(x1.Comparer               == x2.Comparer);
   //Debug.Assert(x1.KeyComparer            == x2.KeyComparer);

   return true;
  }//IsEquals - LcpiOleDb__TypeMapping

  //-------------------------------------------------------
  public static bool IsEquals(in RelationalTypeMappingParameters x1,
                              in RelationalTypeMappingParameters x2)
  {
   if(!Equals(x1.CoreParameters, x2.CoreParameters))
    return false;

   if(x1.StoreType != x2.StoreType)
    return false;

   if(x1.DbType != x2.DbType)
    return false;

   if(x1.Unicode != x2.Unicode)
    return false;

   if(x1.Size != x2.Size)
    return false;

   if(x1.Precision != x2.Precision)
    return false;

   if(x1.Scale != x2.Scale)
    return false;

   if(x1.FixedLength != x2.FixedLength)
    return false;

   if(x1.StoreTypePostfix != x2.StoreTypePostfix)
    return false;

   return true;
  }//IsEquals - RelationalTypeMappingParameters

  //------------------------------------------------------------
  public static bool IsEquals(in CoreTypeMappingParameters x1,
                              in CoreTypeMappingParameters x2)
  {
   if(x1.ClrType != x2.ClrType)
    return false;

   if(x1.Converter != x2.Converter)
    return false;

   if(x1.Comparer != x2.Comparer)
    return false;

   if(x1.KeyComparer != x2.KeyComparer)
    return false;

   //obsoled in EFCore 5.0
   //if(x1.StructuralComparer != x2.StructuralComparer)
   // return false;

   if(x1.ValueGeneratorFactory != x2.ValueGeneratorFactory)
    return false;

   return true;
  }//IsEquals - CoreTypeMappingParameters
 };//class HelperComparer
};//class LcpiOleDb__TypeMapping

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Storage.Mapping
