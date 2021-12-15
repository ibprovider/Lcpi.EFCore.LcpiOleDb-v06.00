////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 12.11.2021.
using System;
using System.Diagnostics;

using xEFCore
 =Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace Microsoft.EntityFrameworkCore{
////////////////////////////////////////////////////////////////////////////////

using xEFCore;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__Extensions__Property

public static partial class LcpiOleDb__Extensions__Property
{
 private const xEFCore.ErrSourceID
  c_ErrSrcID
   =xEFCore.ErrSourceID.LcpiOleDb__Extensions__Property;

 //private types ---------------------------------------------------------
 private abstract class tagTypeInfoProvider
 {
  public abstract System.Type GetClrType();

  public abstract bool CanProvidePrecisionAndScale();

  public abstract Nullable<int> GetScale();
 };//class tagTypeInfoProvider

 //-----------------------------------------------------------------------
 private sealed class tagTypeInfoProvider__ForValueConverter
  :tagTypeInfoProvider
 {
  public tagTypeInfoProvider__ForValueConverter(Storage.ValueConversion.ValueConverter valueConverter)
  {
   Debug.Assert(!Object.ReferenceEquals(valueConverter,null));

   m_ValueConverter=valueConverter;
  }//tagTypeInfoProvider__ForValueConverter

  //interface ----------------------------------------
  public override System.Type GetClrType()
  {
   Debug.Assert(!Object.ReferenceEquals(m_ValueConverter,null));

   var providerClrType
    =m_ValueConverter.ProviderClrType;

   Debug.Assert(!Object.ReferenceEquals(providerClrType,null));

   //Expected
   Debug.Assert(providerClrType==providerClrType.Extension__UnwrapNullableType());
   Debug.Assert(providerClrType==providerClrType.Extension__SwitchToUnderlying());

   return providerClrType;
  }//GetClrType

  //--------------------------------------------------
  public override bool CanProvidePrecisionAndScale()
  {
   Debug.Assert(!Object.ReferenceEquals(m_ValueConverter,null));

   if(Object.ReferenceEquals(m_ValueConverter.MappingHints,null))
    return false;

   return true;
  }//CanProvidePrecisionAndScale

  //--------------------------------------------------
  public override Nullable<int> GetScale()
  {
   Debug.Assert(Object.ReferenceEquals(m_ValueConverter,null));
   Debug.Assert(Object.ReferenceEquals(m_ValueConverter.MappingHints,null));

   return m_ValueConverter.MappingHints.Scale;
  }//GetScale

  //private data -------------------------------------
  private readonly Storage.ValueConversion.ValueConverter
   m_ValueConverter;
 };//class tagTypeInfoProvider__ForValueConverter

 //-----------------------------------------------------------------------
 private sealed class tagTypeInfoProvider__ForTypeMapping
  :tagTypeInfoProvider
 {
  public tagTypeInfoProvider__ForTypeMapping(Storage.RelationalTypeMapping typeMapping)
  {
   Debug.Assert(!Object.ReferenceEquals(typeMapping,null));

   m_TypeMapping=typeMapping;
  }//tagTypeInfoProvider__ForValueConverter

  //interface ----------------------------------------
  public override System.Type GetClrType()
  {
   Debug.Assert(!Object.ReferenceEquals(m_TypeMapping,null));

   var clrType
    =m_TypeMapping.ClrType;

   Debug.Assert(!Object.ReferenceEquals(clrType,null));

   //Expected
   Debug.Assert(clrType==clrType.Extension__UnwrapNullableType());

   return clrType.Extension__UnwrapMappingClrType();
  }//GetClrType

  //--------------------------------------------------
  public override bool CanProvidePrecisionAndScale()
  {
   return true;
  }//CanProvidePrecisionAndScale

  //--------------------------------------------------
  public override Nullable<int> GetScale()
  {
   Debug.Assert(!Object.ReferenceEquals(m_TypeMapping,null));

   return m_TypeMapping.Scale;
  }//GetScale

  //private data -------------------------------------
  private readonly Storage.RelationalTypeMapping
   m_TypeMapping;
 };//class tagTypeInfoProvider__ForTypeMapping
};//class LcpiOleDb__Extensions__Property

////////////////////////////////////////////////////////////////////////////////
}//namespace Microsoft.EntityFrameworkCore
