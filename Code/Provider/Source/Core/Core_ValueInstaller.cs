////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 14.05.2018.
using System;
using System.Diagnostics;

using IColumnModification
 =Microsoft.EntityFrameworkCore.Update.IColumnModification;

using ValueConverter
 =Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter;

using com_lib=lcpi.lib.com;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////
//class Core_ValueInstaller

static class Core_ValueInstaller
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Core_ValueInstaller;

 //-----------------------------------------------------------------------
 public static void Exec(Core_ValueCvtCtx    valueCvtCtx,
                         IColumnModification columnModificator,
                         object              value)
 {
  Debug.Assert(!Object.ReferenceEquals(valueCvtCtx,null));
  Debug.Assert(!Object.ReferenceEquals(columnModificator,null));
  Debug.Assert(!Object.ReferenceEquals(columnModificator.Property,null));
  Debug.Assert(!Object.ReferenceEquals(columnModificator.Property.ClrType,null));

  try // [catch]
  {
   Helper__Exec
    (valueCvtCtx,
     columnModificator,
     value); //throw
  }
  catch(Exception e)
  {
   var exc=new LcpiOleDb__DataToolException(e);

   exc.add_error
    (com_lib.HResultCode.E_FAIL,
     c_ErrSrcID,
     ErrMessageID.common_err__failed_to_set_property_value_3);

   exc.push(columnModificator.Property.DeclaringType.Name)
      .push(columnModificator.Property.Name)
      .push(columnModificator.ColumnName)
      .raise();
  }//catch
 }//Exec

 //Helper methods --------------------------------------------------------
 private static void Helper__Exec(Core_ValueCvtCtx    valueCvtCtx,
                                  IColumnModification columnModificator,
                                  object              value)
 {
  Debug.Assert(!Object.ReferenceEquals(valueCvtCtx,null));
  Debug.Assert(!Object.ReferenceEquals(columnModificator,null));
  Debug.Assert(!Object.ReferenceEquals(columnModificator.Property,null));
  Debug.Assert(!Object.ReferenceEquals(columnModificator.Property.ClrType,null));

  if(Helper__ValueIsNull(value))
  {
   Helper__Setup_Null
    (columnModificator);

   return;
  }//if

  var propCvt
   =columnModificator.TypeMapping?.Converter;

  if(!Object.ReferenceEquals(propCvt,null))
  {
   Helper__Exec2__WithPropCvt
    (valueCvtCtx,
     columnModificator,
     value,
     propCvt);

   return;
  }//if

  Helper__Exec2__Direct
   (valueCvtCtx,
    columnModificator,
    value);
 }//Helper__Exec

 //-----------------------------------------------------------------------
 private static void Helper__Exec2__Direct
                        (Core_ValueCvtCtx    valueCvtCtx,
                         IColumnModification columnModificator,
                         object              value)
 {
  Debug.Assert(!Object.ReferenceEquals(valueCvtCtx,null));
  Debug.Assert(!Object.ReferenceEquals(columnModificator,null));
  Debug.Assert(!Object.ReferenceEquals(columnModificator.Property,null));
  Debug.Assert(!Object.ReferenceEquals(columnModificator.Property.ClrType,null));

  Debug.Assert(!Helper__ValueIsNull(value));

  //------------------------------------------------------------
  const string c_bugcheck_src
   ="Core_ValueInstaller::Helper__Exec2__Direct";

  //------------------------------------------------------------
  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#001",
    "columnModificator.Property.ClrType",
    columnModificator.Property.ClrType);

  System.Type
   providerClrType
    =columnModificator.Property.ClrType.Extension__UnwrapNullableType();

  Debug.Assert(!Object.ReferenceEquals(providerClrType,null));
  Debug.Assert(!providerClrType.Extension__IsNullableValueType());

  var valueCvt
   =valueCvtCtx.GetValueCvt
     (value.GetType(),
      providerClrType);

  if(Object.ReferenceEquals(valueCvt,null))
  {
   //ERROR - conversion not supported

   ThrowError.UnsupportedDataTypesConversion
    (c_ErrSrcID,
     value.GetType(),
     providerClrType);
  }//if

  Debug.Assert(!Object.ReferenceEquals(valueCvt,null));

  var valueCvt_obj_to_obj
   =Check.BugCheck_Value_NotNullAndInstanceOf<Core_ValueCvt<object,object>,Core_ValueCvt>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#002",
      nameof(valueCvt),
      valueCvt);

  object providerValue;

  valueCvt_obj_to_obj.Exec
   (valueCvtCtx,
    value,
    out providerValue); //throw

  if(Helper__ValueIsNull(providerValue))
  {
   Helper__Setup_Null
    (columnModificator);

   return;
  }//if

  Helper__Setup_NotNull
   (columnModificator,
    providerValue);
 }//Helper__Exec2__Direct

 //-----------------------------------------------------------------------
 private static void Helper__Exec2__WithPropCvt
                        (Core_ValueCvtCtx    valueCvtCtx,
                         IColumnModification columnModificator,
                         object              value,
                         ValueConverter      propCvt)
 {
  Debug.Assert(!Object.ReferenceEquals(valueCvtCtx,null));
  Debug.Assert(!Object.ReferenceEquals(columnModificator,null));
  Debug.Assert(!Object.ReferenceEquals(columnModificator.Property,null));
  Debug.Assert(!Object.ReferenceEquals(columnModificator.Property.ClrType,null));
  Debug.Assert(!Object.ReferenceEquals(propCvt,null));

  Debug.Assert(!Helper__ValueIsNull(value));

  //------------------------------------------------------------
  const string c_bugcheck_src
   ="Core_ValueInstaller::Helper__Exec2__WithPropCvt";

  //------------------------------------------------------------
  Check.BugCheck_Value_NotNull
   (c_ErrSrcID,
    c_bugcheck_src,
    "#001",
    "propCvt.ProviderClrType",
    propCvt.ProviderClrType);

  System.Type
   providerClrType
    =propCvt.ProviderClrType;

  Debug.Assert(!Object.ReferenceEquals(providerClrType,null));
  Debug.Assert(!providerClrType.Extension__IsNullableValueType());

  var valueCvt
   =valueCvtCtx.GetValueCvt
     (value.GetType(),
      providerClrType);

  if(Object.ReferenceEquals(valueCvt,null))
  {
   //ERROR - conversion not supported

   ThrowError.UnsupportedDataTypesConversion
    (c_ErrSrcID,
     value.GetType(),
     providerClrType);
  }//if

  Debug.Assert(!Object.ReferenceEquals(valueCvt,null));

  var valueCvt_obj_to_obj
   =Check.BugCheck_Value_NotNullAndInstanceOf<Core_ValueCvt<object,object>,Core_ValueCvt>
     (c_ErrSrcID,
      c_bugcheck_src,
      "#002",
      nameof(valueCvt),
      valueCvt);

  object providerValue;

  valueCvt_obj_to_obj.Exec
   (valueCvtCtx,
    value,
    out providerValue); //throw

  if(Helper__ValueIsNull(providerValue))
  {
   Helper__Setup_Null
    (columnModificator);

   return;
  }//if

  var targetValue
   =propCvt.ConvertFromProvider
     (providerValue);

  if(Helper__ValueIsNull(targetValue))
  {
   Helper__Setup_Null
    (columnModificator);

   return;
  }//if

  Helper__Setup_NotNull
   (columnModificator,
    targetValue);
 }//Helper__Exec2__WithPropCvt

 //-----------------------------------------------------------------------
 private static void Helper__Setup_NotNull(IColumnModification columnModificator,
                                           object              value)
 {
  Debug.Assert(!Object.ReferenceEquals(columnModificator,null));

  Debug.Assert(!Helper__ValueIsNull(value));

  columnModificator.Value=value;
 }//Helper__Setup_NotNull

 //-----------------------------------------------------------------------
 private static void Helper__Setup_Null(IColumnModification columnModificator)
 {
  Debug.Assert(!Object.ReferenceEquals(columnModificator,null));
  Debug.Assert(!Object.ReferenceEquals(columnModificator.Property,null));
  Debug.Assert(!Object.ReferenceEquals(columnModificator.Property.ClrType,null));

  if(!columnModificator.Property.ClrType.Extension__IsNullableType())
  {
   //ERROR - not nullable property

   ThrowError.TargetPropertyNotAcceptNullValue
    (c_ErrSrcID);
  }//if

  columnModificator.Value=null;
 }//Helper__Setup_Null

 //-----------------------------------------------------------------------
 private static bool Helper__ValueIsNull(object value)
 {
  if(Object.ReferenceEquals(value,null))
   return true;

  if(DBNull.Value.Equals(value))
   return true;

  return false;
 }//Helper__ValueIsNull
};//class Core_ValueInstaller

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core
