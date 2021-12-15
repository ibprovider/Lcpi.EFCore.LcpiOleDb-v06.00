////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 26.11.2020.
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Update{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__ColumnModification

sealed class LcpiOleDb__ColumnModification:IColumnModification
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.LcpiOleDb__ColumnModification;

 //-----------------------------------------------------------------------
 public LcpiOleDb__ColumnModification(ColumnModificationParameters columnModificationParameters)
 {
  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    "constructor",
    "columnModificationParameters.ColumnName",
    columnModificationParameters.ColumnName);

  //--------------------------------------------------
  this.ColumnName           = columnModificationParameters.ColumnName;
  m_originalValue           = columnModificationParameters.OriginalValue;
  m_value                   = columnModificationParameters.Value;
  this.Property             = columnModificationParameters.Property;
  this.ColumnType           = columnModificationParameters.ColumnType;
  this.TypeMapping          = columnModificationParameters.TypeMapping;
  this.IsRead               = columnModificationParameters.IsRead;
  this.IsWrite              = columnModificationParameters.IsWrite;
  this.IsKey                = columnModificationParameters.IsKey;
  this.IsCondition          = columnModificationParameters.IsCondition;
  m_sensitiveLoggingEnabled = columnModificationParameters.SensitiveLoggingEnabled;
  this.IsNullable           = columnModificationParameters.IsNullable;
  m_generateParameterName   = columnModificationParameters.GenerateParameterName;
  this.Entry                = columnModificationParameters.Entry;

  //--------------------------------------------------
  m_parameterName=null;

  m_originalParameterName=null;

  m_sharedColumnModifications=null;
 }//LcpiOleDb__ColumnModification

 //ColumnModification interface ------------------------------------------
 public IUpdateEntry Entry
 {
  get;
 }//Entry

 //-----------------------------------------------------------------------
 public IProperty Property
 {
  get;
 }//Property

 //-----------------------------------------------------------------------
 public RelationalTypeMapping TypeMapping
 {
  get;
 }//TypeMapping

 //-----------------------------------------------------------------------
 public bool? IsNullable
 {
  get;
 }//IsNullable

 //-----------------------------------------------------------------------
 public bool IsRead
 {
  get;
 }//IsRead

 //-----------------------------------------------------------------------
 public bool IsWrite
 {
  get;
 }//IsWrite

 //-----------------------------------------------------------------------
 public bool IsCondition
 {
  get;
 }//IsCondition

 //-----------------------------------------------------------------------
 [Obsolete]
 public bool IsConcurrencyToken
 {
  get;
 }//IsConcurrencyToken

 //-----------------------------------------------------------------------
 public bool IsKey
 {
  get;
 }//IsKey

 //-----------------------------------------------------------------------
 public bool UseOriginalValueParameter
 {
  get
  {
   return this.Helper__CanUseParameters() && this.IsCondition;
  }//get
 }//UseOriginalValueParameter

 //-----------------------------------------------------------------------
 public bool UseCurrentValueParameter
 {
  get
  {
   return this.Helper__CanUseParameters() && this.IsWrite;
  }//get
 }//UseCurrentValueParameter

 //-----------------------------------------------------------------------
 bool IColumnModification.UseOriginalValue
 {
  get
  {
   return this.IsCondition;
  }//get
 }//UseOriginalValue

 //-----------------------------------------------------------------------
 bool IColumnModification.UseCurrentValue
 {
  get
  {
   return this.IsWrite;
  }//get
 }//UseCurrentValue

 //-----------------------------------------------------------------------
 bool IColumnModification.UseParameter
 {
  get
  {
   if(Object.ReferenceEquals(m_generateParameterName,null))
    return false;

   return true;
  }//get
 }//UseParameter

 //-----------------------------------------------------------------------
 public string ParameterName
 {
  get
  {
   const string c_bugcheck_src
    ="LcpiOleDb__ColumnModification::get_ParameterName";

   if(!Object.ReferenceEquals(m_parameterName,null))
    return m_parameterName;

   Check.BugCheck_Value_NotNull
    (c_ErrSrcID,
     c_bugcheck_src,
     "#001",
     nameof(m_generateParameterName),
     m_generateParameterName);

   Debug.Assert(!Object.ReferenceEquals(m_generateParameterName,null));

   m_parameterName=m_generateParameterName();

   return m_parameterName;
  }//get
 }//ParameterName

 //-----------------------------------------------------------------------
 public string OriginalParameterName
 {
  get
  {
   const string c_bugcheck_src
    ="LcpiOleDb__ColumnModification::get_OriginalParameterName";

   //[2021-04-26] Expected that.
   if(!this.IsCondition)
   {
    ThrowBugCheck.incorrect_call_of_method
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001");
   }//if

   Debug.Assert(this.IsCondition);

   if(!Object.ReferenceEquals(m_originalParameterName,null))
    return m_originalParameterName;

   Check.BugCheck_Value_NotNull
    (c_ErrSrcID,
     c_bugcheck_src,
     "#002",
     nameof(m_generateParameterName),
     m_generateParameterName);

   Debug.Assert(!Object.ReferenceEquals(m_generateParameterName,null));

   m_originalParameterName=m_generateParameterName();

   return m_originalParameterName;
  }//get
 }//OriginalParameterName

 //-----------------------------------------------------------------------
 public string ColumnName
 {
  get;
 }//ColumnName

 //-----------------------------------------------------------------------
 public string ColumnType
 {
  get;
 }//ColumnType

 //-----------------------------------------------------------------------
 public object OriginalValue
 {
  get
  {
   const string c_bugcheck_src
    ="LcpiOleDb__ColumnModification::get_OriginalValue";

   //[2021-04-26] Expected that.
   if(!this.IsCondition)
   {
    ThrowBugCheck.incorrect_call_of_method
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001");
   }//if

   Debug.Assert(this.IsCondition);

   if(Object.ReferenceEquals(this.Entry,null))
    return m_originalValue;

   if(Object.ReferenceEquals(this.Entry.SharedIdentityEntry,null))
    return this.Entry.GetOriginalValue(Property);

   return this.Entry.SharedIdentityEntry.GetOriginalValue(this.Property);
  }//get
 }//OriginalValue

 //-----------------------------------------------------------------------
 public object Value
 {
  get
  {
   if(Object.ReferenceEquals(this.Entry,null))
    return m_value;

   if(this.Entry.EntityState == EntityState.Deleted)
    return null;

   return Entry.GetCurrentValue(this.Property);
  }//get

  set
  {
   if(Object.ReferenceEquals(this.Entry,null))
   {
    m_value=value;
   }
   else
   {
    Entry.SetStoreGeneratedValue(this.Property,value);

    if(!Object.ReferenceEquals(m_sharedColumnModifications,null))
    {
     foreach(var sharedModification in m_sharedColumnModifications)
     {
      sharedModification.Value=value;
     }
    }//if
   }//else
  }//set
 }//Value

 //-----------------------------------------------------------------------
 public void AddSharedColumnModification(IColumnModification modification)
 {
  Debug.Assert(!Object.ReferenceEquals(modification,null));
  Debug.Assert(!Object.ReferenceEquals(modification.Entry,null));
  Debug.Assert(!Object.ReferenceEquals(modification.Property,null));

  Debug.Assert(!Object.ReferenceEquals(this.Entry,null));
  Debug.Assert(!Object.ReferenceEquals(this.Property,null));

  if(Object.ReferenceEquals(m_sharedColumnModifications,null))
  {
   m_sharedColumnModifications=new List<IColumnModification>();
  }//if

  if(this.UseCurrentValueParameter && !StructuralComparisons.StructuralEqualityComparer.Equals(this.Value,modification.Value))
  {
   Helper__ThrowError__ConflictingRowValues(modification);
  }//if

  if(this.UseOriginalValueParameter && !StructuralComparisons.StructuralEqualityComparer.Equals(this.OriginalValue,modification.OriginalValue))
  {
   if(this.Entry.EntityState==EntityState.Modified
      && modification.Entry.EntityState==EntityState.Added
      && Object.ReferenceEquals(modification.Entry.SharedIdentityEntry,null))
   {
    modification.Entry.SetOriginalValue
     (modification.Property,
      this.OriginalValue);
   }
   else
   {
    Helper__ThrowError__ConflictingOriginalRowValues(modification);
   }//else
  }//if

  Debug.Assert(!Object.ReferenceEquals(m_sharedColumnModifications,null));

  m_sharedColumnModifications.Add(modification);
 }//AddSharedColumnModification

 //Helper methods --------------------------------------------------------
 private bool Helper__CanUseParameters()
 {
  if(Object.ReferenceEquals(m_generateParameterName,null))
   return false;

  return true;
 }//Helper__CanUseParameters

 //-----------------------------------------------------------------------
 private void Helper__ThrowError__ConflictingRowValues(IColumnModification modification)
 {
  Debug.Assert(!Object.ReferenceEquals(modification,null));
  Debug.Assert(!Object.ReferenceEquals(modification.Entry,null));
  Debug.Assert(!Object.ReferenceEquals(modification.Property,null));

  Debug.Assert(!Object.ReferenceEquals(this.Entry,null));
  Debug.Assert(!Object.ReferenceEquals(this.Entry.EntityType,null));
  Debug.Assert(!Object.ReferenceEquals(this.Property,null));

  if(m_sensitiveLoggingEnabled)
  {
   ThrowError.ColumnModification__ConflictingRowValuesSensitive
    (c_ErrSrcID,
     this,
     modification);
  }//if

  {
   ThrowError.ColumnModification__ConflictingRowValues
    (c_ErrSrcID,
     this,
     modification);
  }//local
 }//Helper__ThrowError__ConflictingRowValues

 //-----------------------------------------------------------------------
 private void Helper__ThrowError__ConflictingOriginalRowValues(IColumnModification modification)
 {
  Debug.Assert(!Object.ReferenceEquals(modification,null));
  Debug.Assert(!Object.ReferenceEquals(modification.Entry,null));
  Debug.Assert(!Object.ReferenceEquals(modification.Property,null));

  Debug.Assert(!Object.ReferenceEquals(this.Entry,null));
  Debug.Assert(!Object.ReferenceEquals(this.Entry.EntityType,null));
  Debug.Assert(!Object.ReferenceEquals(this.Property,null));

  if(m_sensitiveLoggingEnabled)
  {
   ThrowError.ColumnModification__ConflictingOriginalRowValuesSensitive
    (c_ErrSrcID,
     this,
     modification);
  }//if

  {
   ThrowError.ColumnModification__ConflictingOriginalRowValues
    (c_ErrSrcID,
     this,
     modification);
  }//local
 }//Helper__ThrowError__ConflictingOriginalRowValues

 //private data ----------------------------------------------------------
 private string m_parameterName;
 private string m_originalParameterName;
 private readonly Func<string> m_generateParameterName;
 private readonly object m_originalValue;
 private object m_value;
 private readonly bool m_sensitiveLoggingEnabled;
 private List<IColumnModification> m_sharedColumnModifications;
};//class LcpiOleDb__ColumnModification

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Update
