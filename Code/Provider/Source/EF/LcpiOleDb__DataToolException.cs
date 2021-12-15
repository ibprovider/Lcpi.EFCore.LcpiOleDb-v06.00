////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.05.2018.
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Diagnostics;

using oledb_lib=lcpi.lib.oledb;
using com_lib=lcpi.lib.com;
using structure_lib=lcpi.lib.structure;
using xdb=lcpi.data.oledb;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__DataToolException

//
// [2021-11-18]
//
//  Could it be better to inherit the InvalidOperationException?
//

[Serializable]
sealed class LcpiOleDb__DataToolException
 :Exception
 ,structure_lib.IErrorRecords
{
 private const ErrSourceID c_ErrSource
  =ErrSourceID.LcpiOleDb__DataToolException;

 //-----------------------------------------------------------------------
 private LcpiOleDb__DataToolException(com_lib.HResultCode                               ComErrorCode,
                                      structure_lib.ErrorUtils.tag_unpack_ExceptionData ExcData)
  :base(string.Empty,
        ExcData.innerException)
 {
  m_Records=ExcData.err_records;

  //----
  base.HResult=(int)ComErrorCode;
 }//LcpiOleDb__DataToolException

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException(com_lib.HResultCode ComErrorCode)
 {
  base.HResult=(int)ComErrorCode;
 }//LcpiOleDb__DataToolException - ComErrorCode

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException(Exception innerException)
  :this(com_lib.ErrorUtils.MapExceptionToHResultCode(innerException),
        structure_lib.ErrorUtils.UnpackException(innerException))
 {
 }//LcpiOleDb__DataToolException - innerException

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException(LcpiOleDb__DataToolException exception)
  :base(string.Empty,
        Helper__GetInnerException(exception))
 {
  if(Object.ReferenceEquals(exception,null))
  {
   base.HResult=(int)com_lib.HResultCode.E_FAIL;
  }
  else
  {
   Debug.Assert(!Object.ReferenceEquals(exception,null));

   if(!Object.ReferenceEquals(exception.m_Records,null))
   {
    int _c=exception.m_Records.Count;

    m_Records=new List<structure_lib.IErrorRecord>(_c);

    for(int i=0;i!=_c;++i)
     m_Records.Add(exception.m_Records[i]);
   }//if

   base.HResult=exception.HResult;
  }//else
 }//LcpiOleDb__DataToolException

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException(Core.Core_ExceptionRecord errRec)
 {
  Debug.Assert(!Object.ReferenceEquals(errRec,null));

  base.HResult=(int)errRec.ComErrorCode;

  this.add(errRec);
 }//LcpiOleDb__DataToolException - ComErrorCode, SourceID, MessageID

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException(com_lib.HResultCode ComErrorCode,
                                       ErrSourceID         SourceID,
                                       ErrMessageID        MessageID)
 {
  base.HResult=(int)ComErrorCode;

  this.add_error(ComErrorCode,
                 SourceID,
                 MessageID);
 }//LcpiOleDb__DataToolException - ComErrorCode, SourceID, MessageID

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException(com_lib.HResultCode ComErrorCode,
                                       ErrSourceID         SourceID,
                                       ErrMessageID        MessageID,
                                       Exception           innerException)
  :this(ComErrorCode,
        structure_lib.ErrorUtils.UnpackException(innerException))
 {
  this.add_error(ComErrorCode,
                 SourceID,
                 MessageID);
 }//LcpiOleDb__DataToolException - ComErrorCode, SourceID, MessageID, innerException

 //-----------------------------------------------------------------------
 private LcpiOleDb__DataToolException(SerializationInfo si,
                                      StreamingContext  sc)
  :base(si,sc)
 {
  Debug.Assert(!Object.ReferenceEquals(si,null));

  structure_lib.SerializationUtils.ReadValue
   (si,
    c_prop_name__m_Records,
    out m_Records);

  structure_lib.SerializationUtils.ReadValue
   (si,
    c_prop_name__m_CurRecord,
    out m_CurRecord);
 }//LcpiOleDb__DataToolException - deserialization

 //-----------------------------------------------------------------------
 [OnDeserialized]
 private void CheckDeserializedData(StreamingContext sc)
 {
  if(!Object.ReferenceEquals(m_CurRecord,null))
  {
   if(Object.ReferenceEquals(m_Records,null))
    ThrowBugCheck.deserialization__wrong_state(c_ErrSource,"#001");

   if(structure_lib.ArrayUtils.Empty(m_Records))
    ThrowBugCheck.deserialization__wrong_state(c_ErrSource,"#002");

   if(!Object.ReferenceEquals(structure_lib.ArrayUtils.Back(m_Records),m_CurRecord))
    ThrowBugCheck.deserialization__wrong_state(c_ErrSource,"#003");
  }//if m_CurRecord!=null

  //----------------------------------------------------------------------
  if(!Object.ReferenceEquals(m_Records,null))
  {
   for(int iRec=0,cRecs=m_Records.Count;iRec!=cRecs;++iRec)
   {
    if(Object.ReferenceEquals(m_Records[iRec],null))
    {
     ThrowBugCheck.deserialization__null_item_ptr
      (c_ErrSource,
       c_prop_name__m_Records,
       iRec);
    }//if
   }//for iRec
  }//if m_Records!=null
 }//CheckDeserializedData

 //raise method ----------------------------------------------------------
 internal void raise()
 {
  throw this;
 }//raise

 //-----------------------------------------------------------------------
 internal void raise(com_lib.HResultCode ComErrorCode)
 {
  base.HResult=(int)ComErrorCode;

  throw this;
 }//raise - err_code

 //modificators ----------------------------------------------------------
 internal LcpiOleDb__DataToolException add(structure_lib.IErrorRecord err_record)
 {
  Debug.Assert(!Object.ReferenceEquals(err_record,null));

  if(Object.ReferenceEquals(m_Records,null))
   m_Records=new List<structure_lib.IErrorRecord>();

  Debug.Assert(!Object.ReferenceEquals(m_Records,null));

  m_Records.Add(err_record);

  Debug.Assert(m_Records.Count>0);

  m_CurRecord=null;

  return this;
 }//add - err_record

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException add_error(com_lib.HResultCode ComErrorCode,
                                                 ErrSourceID         SourceID,
                                                 ErrMessageID        MessageID)
 {
  var tmp=new Core.Core_ExceptionRecord(ComErrorCode,
                                        SourceID,
                                        MessageID);

  this.add(tmp);

  m_CurRecord=tmp;

  return this;
 }//add_error - err_code, err_src, err_msg

 //push_iif methods ------------------------------------------------------o

 //push methods ----------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.Byte value)
 {
  return this.push_object(value);
 }//push Byte

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.UInt16 value)
 {
  return this.push_object(value);
 }//push UInt16

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.UInt32 value)
 {
  return this.push_object(value);
 }//push UInt32

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.UInt64 value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push UInt64

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.UIntPtr value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push UIntPtr

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.SByte value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push SByte

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.Int16 value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push Int16

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.Int32 value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push Int32

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.Int64 value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push Int64

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.Decimal value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push Decimal

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.IntPtr value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push IntPtr

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.Single value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push Single

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.Double value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push Double

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.Boolean value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push Boolean

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.String value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push String

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.TimeSpan value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push TimeSpan

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.Guid value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push Guid

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(System.Version value)
 {
  Debug.Assert(!Object.ReferenceEquals(value,null));
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push Version

 //-----------------------------------------------------------------------
 public LcpiOleDb__DataToolException push(System.Type value)
 {
  Debug.Assert(!Object.ReferenceEquals(value,null));
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push Type

 //-----------------------------------------------------------------------
 public LcpiOleDb__DataToolException push(System.Linq.Expressions.ExpressionType value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push System.Linq.Expressions.ExpressionType

 //-----------------------------------------------------------------------
 public LcpiOleDb__DataToolException push(System.Reflection.MethodInfo value)
 {
  Debug.Assert(!Object.ReferenceEquals(value,null));
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push System.Reflection.MethodInfo

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(com_lib.HResultCode value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push HResultCode

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(oledb_lib.DBTypeCode value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push oledb_lib.DBTypeCode

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(oledb_lib.DBCOLUMNFLAGS value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push oledb_lib.DBCOLUMNFLAGS

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(xdb.OleDbType value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push xdb.OleDbType

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(ErrSourceID value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push ErrSourceID

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(ErrMessageID value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push ErrMessageID

 //-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push(Microsoft.EntityFrameworkCore.Migrations.ReferentialAction value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push(value);

  return this;
 }//push ErrMessageID

//-----------------------------------------------------------------------
 internal LcpiOleDb__DataToolException push_object(System.Object value)
 {
  Debug.Assert(!Object.ReferenceEquals(m_CurRecord,null));

  m_CurRecord.push_object(value);

  return this;
 }//push_object

 //Exception interface ---------------------------------------------------
 public override string Message
 {
  get
  {
   if(this.Helper__GetRecordCount()==0)
   {
    return ErrResourceUtils.FormatMessage
             (/*culture_info*/null,
              ErrMessageID.com_err__com_code_error_1,
              this.ErrorCode);
   }//if

   Debug.Assert(!Object.ReferenceEquals(m_Records,null));
   Debug.Assert(m_Records.Count>0);

   if(structure_lib.ErrorUtils.ErrorsFromOneSource(m_Records,null))
   {
    return structure_lib.ErrorUtils.BuildMessageList
             (m_Records,
              /*culture_id*/null,
              /*src_reader*/null);
   }//if

   Debug.Assert(m_Records.Count>1);

   return structure_lib.ErrorUtils.BuildMessageList
            (m_Records,
             /*culture_id*/null,
             /*src_reader*/Helper__GetSourceName);
  }//get_Message
 }//Message

 //-----------------------------------------------------------------------
 public override string Source
 {
  get
  {
   if(this.Helper__GetRecordCount()==0)
    return ErrResourceUtils.GetSourceName(null,ErrSourceID.unknown_source);

   Debug.Assert(!Object.ReferenceEquals(m_Records,null));
   Debug.Assert(m_Records.Count>0);

   if(structure_lib.ErrorUtils.ErrorsFromOneSource(m_Records,null))
    return Helper__GetSourceName(m_Records[0],null);

   Debug.Assert(m_Records.Count>1);

   return ErrResourceUtils.GetSourceName(null,ErrSourceID.multiple_sources);
  }//get_Source
 }//Source

 //-----------------------------------------------------------------------
 public com_lib.HResultCode ErrorCode
 {
  get
  {
   return (com_lib.HResultCode)base.HResult;
  }
 }//ErrorCode - new

 //t_err_records_r interface ---------------------------------------------
 int structure_lib.IErrorRecords.GetRecordCount() //abstract
 {
  return this.Helper__GetRecordCount();
 }//GetRecordCount

 //-----------------------------------------------------------------------
 structure_lib.IErrorRecord structure_lib.IErrorRecords.GetRecord(int index)
 {
  Debug.Assert(!Object.ReferenceEquals(m_Records,null));

  Debug.Assert(index>=0);

  Debug.Assert(index<m_Records.Count,
               "wrong index",
               string.Format("index={0};count={1}",index,m_Records.Count));

  Debug.Assert(!Object.ReferenceEquals(m_Records[index],null));

  //----------------------------------------
  return m_Records[index];
 }//get_record

 //ISerializable interface -----------------------------------------------
 public override void GetObjectData(SerializationInfo si,
                                    StreamingContext  sc)
 {
  base.GetObjectData(si,sc);

  Debug.Assert(!Object.ReferenceEquals(si,null));

  structure_lib.SerializationUtils.WriteValue
   (si,
    c_prop_name__m_Records,
    m_Records);

  structure_lib.SerializationUtils.WriteValue
   (si,
    c_prop_name__m_CurRecord,
    m_CurRecord);
 }//GetObjectData

 //Helper methods --------------------------------------------------------
 private static Exception Helper__GetInnerException(LcpiOleDb__DataToolException exception)
 {
  if(Object.ReferenceEquals(exception,null))
   return null;

  return exception.InnerException;
 }//Helper__GetInnerException

 //-----------------------------------------------------------------------
 private static string Helper__GetSourceName(structure_lib.IErrorRecord err_record,
                                             object                     culture_id)
 {
  Debug.Assert(!Object.ReferenceEquals(err_record,null));
  Debug.Assert(Object.ReferenceEquals(culture_id,null));

  string original_source_name=err_record.GetSource(culture_id);

  if(!string.IsNullOrEmpty(original_source_name))
   return original_source_name;

  var ci=structure_lib.ErrorUtils.GetCultureInfoFromID(culture_id);

  return ErrResourceUtils.GetSourceName
          (ci,
           ErrSourceID.unknown_source);
 }//Helper__GetSourceName

 //-----------------------------------------------------------------------
 private int Helper__GetRecordCount()
 {
  if(Object.ReferenceEquals(m_Records,null))
   return 0;

  return m_Records.Count;
 }//Helper__GetRecordCount

 //member identifiers ----------------------------------------------------
 private const string c_prop_name_prefix
  ="Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.LcpiOleDb__DataToolException.";

 private const string c_prop_name__m_Records
  =c_prop_name_prefix+"m_Records";

 private const string c_prop_name__m_CurRecord
  =c_prop_name_prefix+"m_CurRecord";

 //Internal data----------------------------------------------------------
 private List<structure_lib.IErrorRecord> m_Records=null;

 private Core.Core_ExceptionRecord m_CurRecord=null;
};//class LcpiOleDb__DataToolException

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb
