////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 14.05.2018.
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Diagnostics;

using oledb_lib=lcpi.lib.oledb;
using com_lib=lcpi.lib.com;
using structure_lib=lcpi.lib.structure;

using xdb=lcpi.data.oledb;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////
//class Core_ExceptionRecord

[Serializable]
sealed class Core_ExceptionRecord:structure_lib.IErrorRecord
                                 ,ISerializable
{
 private const ErrSourceID c_src_id=ErrSourceID.Core_ExceptionRecord;

 //-----------------------------------------------------------------------
 public Core_ExceptionRecord(com_lib.HResultCode ComErrorCode,
                             ErrSourceID         SourceID,
                             ErrMessageID        MessageID)
 {
  m_ComErrorCode =ComErrorCode;
  m_SourceID     =SourceID;
  m_MessageID    =MessageID;
 }//Core_ExceptionRecord

 //-----------------------------------------------------------------------
 private Core_ExceptionRecord(SerializationInfo si,
                              StreamingContext  sc)
 {
  if(Object.ReferenceEquals(si,null))
   ThrowSysError.argument_is_null(c_src_id,"constructor","si");

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(si,null));

  structure_lib.SerializationUtils.ReadValue
   (si,
    c_prop_name__m_ComErrorCode,
    out m_ComErrorCode);

  structure_lib.SerializationUtils.ReadValue
   (si,
    c_prop_name__m_SourceID,
    out m_SourceID);

  structure_lib.SerializationUtils.ReadValue
   (si,
    c_prop_name__m_MessageID,
    out m_MessageID);

  structure_lib.SerializationUtils.ReadValue
   (si,
    c_prop_name__m_Args,
    out m_Args);
 }//Core_ExceptionRecord

 //-----------------------------------------------------------------------
 public com_lib.HResultCode ComErrorCode
 {
  get
  {
   return m_ComErrorCode;
  }
 }//ComErrorCode

 //push_iif methods ------------------------------------------------------
 public Core_ExceptionRecord push_iif(System.String value,
                                      ErrMessageID  default_value)
 {
  if(Object.ReferenceEquals(value,null))
   return this.push(default_value);

  return this.push(value);
 }//push_iif - string, ErrMessageID

 //-----------------------------------------------------------------------
 public Core_ExceptionRecord push_iif(System.Type  value,
                                      ErrMessageID default_value)
 {
  if(Object.ReferenceEquals(value,null))
   return this.push(default_value);

  return this.push(value);
 }//push_iif - Type, ErrMessageID

 //-----------------------------------------------------------------------
 // public Core_ExceptionRecord push_iif(Structure.Structure_ValueWithNull<string> value,
 //                                      ErrMessageID                              default_value)
 // {
 //  if(value.IsNull)
 //   return this.push(default_value);
 // 
 //  return this.push(value.Value);
 // }//push_iif

 //-----------------------------------------------------------------------
 // public Core_ExceptionRecord push_iif(Structure.Structure_ValueWithNull<string> value,
 //                                      string                                    default_value)
 // {
 //  if(value.IsNull)
 //   return this.push(default_value);
 // 
 //  return this.push(value.Value);
 // }//push_iif

 //push methods ----------------------------------------------------------
 public Core_ExceptionRecord push(System.Byte value)
 {
  return this.push_object(value);
 }//push Byte

 public Core_ExceptionRecord push(System.UInt16 value)
 {
  return this.push_object(value);
 }//push UInt16

 public Core_ExceptionRecord push(System.UInt32 value)
 {
  return this.push_object(value);
 }//push UInt32

 public Core_ExceptionRecord push(System.UInt64 value)
 {
  return this.push_object(value);
 }//push UInt64

 public Core_ExceptionRecord push(System.UIntPtr value)
 {
  return this.push_object(value);
 }//push UIntPtr

 public Core_ExceptionRecord push(System.SByte value)
 {
  return this.push_object(value);
 }//push SByte

 public Core_ExceptionRecord push(System.Int16 value)
 {
  return this.push_object(value);
 }//push Int16

 public Core_ExceptionRecord push(System.Int32 value)
 {
  return this.push_object(value);
 }//push Int32

 public Core_ExceptionRecord push(System.Int64 value)
 {
  return this.push_object(value);
 }//push Int64

 public Core_ExceptionRecord push(System.Decimal value)
 {
  return this.push_object(value);
 }//push Decimal

 public Core_ExceptionRecord push(System.IntPtr value)
 {
  return this.push_object(value);
 }//push IntPtr

 public Core_ExceptionRecord push(System.Single value)
 {
  return this.push_object(value);
 }//push Single

 public Core_ExceptionRecord push(System.Double value)
 {
  return this.push_object(value);
 }//push Double

 public Core_ExceptionRecord push(System.Boolean value)
 {
  return this.push_object(value);
 }//push Boolean

 public Core_ExceptionRecord push(System.String value)
 {
  return this.push_object(value);
 }//push String

 public Core_ExceptionRecord push(System.TimeSpan value)
 {
  return this.push_object(value);
 }//push TimeSpan

 public Core_ExceptionRecord push(System.Guid value)
 {
  return this.push_object(value);
 }//push Guid

 public Core_ExceptionRecord push(System.Version value)
 {
  return this.push_object(value);
 }//push String

 public Core_ExceptionRecord push(System.Type value)
 {
  return this.push_object(value);
 }//push Type

 //-----------------------------------------------------------------------
 public Core_ExceptionRecord push(System.Reflection.BindingFlags value)
 {
  return this.push_object(value);
 }//push System.Reflection.BindingFlags

 //-----------------------------------------------------------------------
 public Core_ExceptionRecord push(System.Data.ConnectionState value)
 {
  return this.push_object(value);
 }//push System.Data.ConnectionState

 //-----------------------------------------------------------------------
 public Core_ExceptionRecord push(System.Data.ParameterDirection value)
 {
  return this.push_object(value);
 }//push System.Data.ParameterDirection

 //-----------------------------------------------------------------------
 public Core_ExceptionRecord push(System.Data.DbType value)
 {
  return this.push_object(value);
 }//push System.Data.DbType

 //-----------------------------------------------------------------------
 public Core_ExceptionRecord push(System.Linq.Expressions.ExpressionType value)
 {
  return this.push_object(value);
 }//push System.Linq.Expressions.ExpressionType

 //-----------------------------------------------------------------------
 public Core_ExceptionRecord push(System.Reflection.MethodInfo value)
 {
  return this.push_object(value);
 }//push System.Reflection.MethodInfo

 //-----------------------------------------------------------------------
 public Core_ExceptionRecord push(com_lib.HResultCode value)
 {
  return this.push_object(value);
 }//push HResultCode

 //-----------------------------------------------------------------------
 internal Core_ExceptionRecord push(oledb_lib.DBTypeCode value)
 {
  return this.push_object(value);
 }//push oledb_lib.DBTypeCode

 //-----------------------------------------------------------------------
 internal Core_ExceptionRecord push(oledb_lib.DBCOLUMNFLAGS value)
 {
  return this.push_object(value);
 }//push oledb_lib.DBCOLUMNFLAGS

 //-----------------------------------------------------------------------
 internal Core_ExceptionRecord push(xdb.OleDbType value)
 {
  return this.push_object(value);
 }//push oledb_lib.xdb.OleDbType

 //-----------------------------------------------------------------------
 public Core_ExceptionRecord push(ErrSourceID value)
 {
  return this.push_object(value);
 }//push ErrSourceID

 //-----------------------------------------------------------------------
 public Core_ExceptionRecord push(ErrMessageID value)
 {
  return this.push_object(value);
 }//push ErrMessageID

 //-----------------------------------------------------------------------
 public Core_ExceptionRecord push(Microsoft.EntityFrameworkCore.Migrations.ReferentialAction value)
 {
  return this.push_object(value);
 }//push Microsoft.EntityFrameworkCore.Migrations.ReferentialAction

 //-----------------------------------------------------------------------
 public Core_ExceptionRecord push(LcpiOleDb__ExpressionType value)
 {
  return this.push_object(value);
 }//push LcpiOleDb__ExpressionType

 //-----------------------------------------------------------------------
 public Core_ExceptionRecord push_object(System.Object value)
 {
  if(Object.ReferenceEquals(m_Args,null))
   m_Args=new List<object>();

  m_Args.Add(value);

  return this;
 }//push_object

 //t_err_record interface ------------------------------------------------
 public string GetSystemID() //abstract
 {
  return structure_lib.err_system_id.err_system_id__com;
 }//GetSystemID

 //-----------------------------------------------------------------------
 public string GetSubSystemID() //abstract
 {
  return structure_lib.err_subsystem_id.err_subsystem_id__unk;
 }//GetSubSystemID

 //-----------------------------------------------------------------------
 public int GetErrorCode() //abstract
 {
  return (int)m_ComErrorCode;
 }//GetErrorCode

 //-----------------------------------------------------------------------
 public string GetSource(object culture_id) //abstract
 {
  var ci=structure_lib.ErrorUtils.GetCultureInfoFromID(culture_id);

  return ErrResourceUtils.GetSourceName
          (ci,
           m_SourceID);
 }//GetSource

 //-----------------------------------------------------------------------
 public string GetDescription(object culture_id) //abstract
 {
  var ci=structure_lib.ErrorUtils.GetCultureInfoFromID(culture_id);

  return ErrResourceUtils.BuildMessage
          (ci,
           m_MessageID,
           m_Args);
 }//GetDescription

 //-----------------------------------------------------------------------
 public string GetMessage(object culture_id) //abstract
 {
  var culture_info=structure_lib.ErrorUtils.GetCultureInfoFromID(culture_id);

  var result=new System.Text.StringBuilder(this.GetDescription(culture_info));

  structure_lib.StringUtils.TotalTrimr(result);

  result.Append(System.Environment.NewLine);
  result.Append(System.Environment.NewLine);

  result.Append
   (ErrResourceUtils.FormatMessage
     (culture_info,
      ErrMessageID.com_err__com_code_error_1,
      m_ComErrorCode));

  return result.ToString();
 }//GetMessage

 //-----------------------------------------------------------------------
 public string GetHelpFile(object culture_id) //abstract
 {
  return null;
 }//GetHelpFile

 //-----------------------------------------------------------------------
 public Nullable<int> GetHelpContextID(object  culture_id) //abstract
 {
  return null;
 }//GetHelpContextID

 //ISerializable interface -----------------------------------------------
 public void GetObjectData(SerializationInfo si,
                           StreamingContext  sc)//abstract
 {
  if(Object.ReferenceEquals(si,null))
   ThrowSysError.argument_is_null(c_src_id,"GetObjectData","si");

  //----------------------------------------
  Debug.Assert(!Object.ReferenceEquals(si,null));

  structure_lib.SerializationUtils.WriteValue
   (si,
    c_prop_name__m_ComErrorCode,
    m_ComErrorCode);

  structure_lib.SerializationUtils.WriteValue
   (si,
    c_prop_name__m_SourceID,
    m_SourceID);

  structure_lib.SerializationUtils.WriteValue
   (si,
    c_prop_name__m_MessageID,
    m_MessageID);

  structure_lib.SerializationUtils.WriteValue
   (si,
    c_prop_name__m_Args,
    m_Args);
 }//GetObjectData

 //-----------------------------------------------------------------------
 private const string c_prop_name_prefix
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Core_ExceptionRecord.";

 private const string c_prop_name__m_ComErrorCode
   =c_prop_name_prefix+"m_ComErrorCode";

 private const string c_prop_name__m_SourceID
   =c_prop_name_prefix+"m_SourceID";

 private const string c_prop_name__m_MessageID
   =c_prop_name_prefix+"m_MessageID";

 private const string c_prop_name__m_Args
   =c_prop_name_prefix+"m_Args";

 //Internal Data ---------------------------------------------------------
 private readonly com_lib.HResultCode  m_ComErrorCode;
 private readonly ErrSourceID          m_SourceID;
 private readonly ErrMessageID         m_MessageID;

 private List<object> m_Args;
};//class Core_ExceptionRecord

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core
