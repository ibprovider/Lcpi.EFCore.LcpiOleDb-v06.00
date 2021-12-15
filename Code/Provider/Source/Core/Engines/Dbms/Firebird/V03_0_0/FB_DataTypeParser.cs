////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 20.10.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.V03_0_0{
////////////////////////////////////////////////////////////////////////////////
//using

using FB_Common__DataTypeDescr
 =Common.FB_Common__DataTypeDescr;

using FB_Common__SqlDataTypeNames
 =Common.FB_Common__SqlDataTypeNames;

using FB_Common__DataTypeID
 =Common.FB_Common__DataTypeID;

using FB_Common__BlobSubTypeID
 =Common.FB_Common__BlobSubTypeID;

using FB_Common__BlobSubTypeNames
 =Common.FB_Common__BlobSubTypeNames;

////////////////////////////////////////////////////////////////////////////////
//class FB_DataTypeParser

static partial class FB_DataTypeParser
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Core_Engines_Dbms_FB_V03_0_0__DataTypeParser;

 //-----------------------------------------------------------------------
 public struct tagResultData
 {
  public string SourceStr;

  public int iBegin;

  public int iPos;

  public FB_Common__DataTypeDescr DataTypeDescr;
 };//struct tagResultData

 //-----------------------------------------------------------------------
 public enum ResultCode
 {
  Ok                  = 0,
  NoData              = 1,
  UnknownTypeName     = 2,
 };//enum ResultCode

 //-----------------------------------------------------------------------
 public static ResultCode Exec(string sourceStr,out tagResultData resultData)
 {
  resultData=default;

  resultData.SourceStr=sourceStr;

  //----------------------------------------
  if(Object.ReferenceEquals(sourceStr,null))
   return ResultCode.NoData;

  //---------------------------------------- TYPE NAME
  resultData.iBegin
   =0;

  resultData.iPos
   =tagUtils.SkipEmptySpace
     (sourceStr,
      resultData.iBegin);

  if(resultData.iPos==sourceStr.Length)
   return ResultCode.NoData;

  //----------------------------------------
  {
   var r
    =Helper__FindDataTypeParserDescr
      (sourceStr,
       resultData.iPos,
       sm_ParserDescrs,
       /*iTestNamePart*/0,
       out var parserDescr,
       out resultData.iPos);

   if(r!=ResultCode.Ok)
   {
    Debug.Assert
     (r==ResultCode.NoData ||
      r==ResultCode.UnknownTypeName);

    return r;
   }//if

   Debug.Assert(r==ResultCode.Ok);

   Debug.Assert(!Object.ReferenceEquals(parserDescr,null));
   Debug.Assert(!Object.ReferenceEquals(parserDescr.ParserFunc,null));

   resultData.DataTypeDescr.DataTypeID
    =parserDescr.DataTypeID;

   resultData.DataTypeDescr.DataTypeNameBase
    =parserDescr.DataTypeNameBase;

   parserDescr.ParserFunc
    (ref resultData); //throw
  }//local

  resultData.iPos
   =tagUtils.SkipEmptySpace
     (sourceStr,
      resultData.iPos);

  if(resultData.iPos!=sourceStr.Length)
  {
   ThrowError.TypeMappingErr__UnexpectedDataAtEndOfDataTypeDefinition
    (c_ErrSrcID,
     resultData.DataTypeDescr.DataTypeID.ToString());
  }//if

  return ResultCode.Ok;
 }//Exec

 //Helper methods --------------------------------------------------------
 private static void Helper__Parse__CHAR
                        (ref tagResultData resultData)
 {
  Helper__Parse__VARCHAR_or_CHAR
   (ref resultData);
 }//Helper__Parse__CHAR

 //-----------------------------------------------------------------------
 private static void Helper__Parse__VARCHAR
                        (ref tagResultData resultData)
 {
  Helper__Parse__VARCHAR_or_CHAR
   (ref resultData);
 }//Helper__Parse__VARCHAR

 //-----------------------------------------------------------------------
 private static void Helper__Parse__BINARY
                        (ref tagResultData resultData)
 {
  Helper__Parse__VARBINARY_or_BINARY
   (ref resultData);
 }//Helper__Parse__BINARY

 //-----------------------------------------------------------------------
 private static void Helper__Parse__VARBINARY
                        (ref tagResultData resultData)
 {
  Helper__Parse__VARBINARY_or_BINARY
   (ref resultData);
 }//Helper__Parse__VARBINARY

 //-----------------------------------------------------------------------
 private static void Helper__Parse__DECIMAL
                        (ref tagResultData resultData)
 {
  Helper__Parse__DECIMAL_or_NUMERIC
   (ref resultData);
 }//Helper__Parse__DECIMAL

 //-----------------------------------------------------------------------
 private static void Helper__Parse__NUMERIC
                        (ref tagResultData resultData)
 {
  Helper__Parse__DECIMAL_or_NUMERIC
   (ref resultData);
 }//Helper__Parse__NUMERIC

 //-----------------------------------------------------------------------
 private static void Helper__Parse__SMALLINT
                        (ref tagResultData resultData)
 {
  Helper__Parse__SIMPLE
   (ref resultData);
 }//Helper__Parse__SMALLINT

 //-----------------------------------------------------------------------
 private static void Helper__Parse__INTEGER
                        (ref tagResultData resultData)
 {
  Helper__Parse__SIMPLE
   (ref resultData);
 }//Helper__Parse__INTEGER

 //-----------------------------------------------------------------------
 private static void Helper__Parse__BIGINT
                        (ref tagResultData resultData)
 {
  Helper__Parse__SIMPLE
   (ref resultData);
 }//Helper__Parse__BIGINT

 //-----------------------------------------------------------------------
 private static void Helper__Parse__FLOAT
                        (ref tagResultData resultData)
 {
  Helper__Parse__SIMPLE
   (ref resultData);
 }//Helper__Parse__FLOAT

 //-----------------------------------------------------------------------
 private static void Helper__Parse__DOUBLE
                        (ref tagResultData resultData)
 {
  Helper__Parse__SIMPLE
   (ref resultData);
 }//Helper__Parse__DOUBLE

 //-----------------------------------------------------------------------
 private static void Helper__Parse__BOOLEAN
                        (ref tagResultData resultData)
 {
  Helper__Parse__SIMPLE
   (ref resultData);
 }//Helper__Parse__BOOLEAN

 //-----------------------------------------------------------------------
 private static void Helper__Parse__TIMESTAMP
                        (ref tagResultData resultData)
 {
  Helper__Parse__SIMPLE
   (ref resultData);
 }//Helper__Parse__TIMESTAMP

 //-----------------------------------------------------------------------
 private static void Helper__Parse__DATE
                        (ref tagResultData resultData)
 {
  Helper__Parse__SIMPLE
   (ref resultData);
 }//Helper__Parse__DATE

 //-----------------------------------------------------------------------
 private static void Helper__Parse__TIME
                        (ref tagResultData resultData)
 {
  Helper__Parse__SIMPLE
   (ref resultData);
 }//Helper__Parse__TIME

 //-----------------------------------------------------------------------
 private static void Helper__Parse__SIMPLE
                        (ref tagResultData resultData)
 {
#if DEBUG
  var debug__iStart
   =resultData.iPos;
#endif

  Helper__Parse__ArrayBounds
   (ref resultData);

#if DEBUG
  //EXPECTED!
  Debug.Assert(debug__iStart<=resultData.iPos);
#endif
 }//Helper__Parse__SIMPLE

 //-----------------------------------------------------------------------
 private static void Helper__Parse__VARCHAR_or_CHAR
                        (ref tagResultData resultData)
 {
#if DEBUG
  var debug__iStart
   =resultData.iPos;
#endif

  Helper__Parse__DataTypeWithLength
   (ref resultData);

#if DEBUG
  //EXPECTED!
  Debug.Assert(debug__iStart<=resultData.iPos);
#endif

  Helper__Parse__ArrayBounds
   (ref resultData);

#if DEBUG
  //EXPECTED!
  Debug.Assert(debug__iStart<=resultData.iPos);
#endif

  Helper__Parse__CharSetName
   (ref resultData);

#if DEBUG
  //EXPECTED!
  Debug.Assert(debug__iStart<=resultData.iPos);
#endif
 }//Helper__Parse__VARCHAR_or_CHAR

 //-----------------------------------------------------------------------
 private static void Helper__Parse__VARBINARY_or_BINARY
                        (ref tagResultData resultData)
 {
#if DEBUG
  var debug__iStart
   =resultData.iPos;
#endif

  Helper__Parse__DataTypeWithLength
   (ref resultData);

#if DEBUG
  //EXPECTED!
  Debug.Assert(debug__iStart<=resultData.iPos);
#endif

  Helper__Parse__ArrayBounds
   (ref resultData);

#if DEBUG
  //EXPECTED!
  Debug.Assert(debug__iStart<=resultData.iPos);
#endif
 }//Helper__Parse__VARBINARY_or_BINARY

 //-----------------------------------------------------------------------
 private static void Helper__Parse__DECIMAL_or_NUMERIC
                        (ref tagResultData resultData)
 {
#if DEBUG
  var debug__iStart
   =resultData.iPos;
#endif

  Helper__Parse__DataTypeWithPrecisionAndScale
   (ref resultData);

#if DEBUG
  //EXPECTED!
  Debug.Assert(debug__iStart<=resultData.iPos);
#endif

  Helper__Parse__ArrayBounds
   (ref resultData);

#if DEBUG
  //EXPECTED!
  Debug.Assert(debug__iStart<=resultData.iPos);
#endif
 }//Helper__Parse__DECIMAL_or_NUMERIC

 //-----------------------------------------------------------------------
 private static void Helper__Parse__BLOB
                        (ref tagResultData resultData)
 {
#if DEBUG
  var debug__iStart
   =resultData.iPos;
#endif

  Helper__Parse__BlobSubType
   (ref resultData);

#if DEBUG
  //EXPECTED!
  Debug.Assert(debug__iStart<=resultData.iPos);
#endif

  Helper__Parse__CharSetName
   (ref resultData);

#if DEBUG
  //EXPECTED!
  Debug.Assert(debug__iStart<=resultData.iPos);
#endif

  if(!Object.ReferenceEquals(resultData.DataTypeDescr.CharSetName,null))
  {
   if(resultData.DataTypeDescr.BlobSubTypeID!=FB_Common__BlobSubTypeID.TEXT)
   {
    ThrowError.TypeMappingErr__DefinitionOfBlobCharsetAllowedOnlyForSubTypeText
     (c_ErrSrcID);
   }//if
  }//if
 }//Helper__Parse__BLOB

 //-----------------------------------------------------------------------
 private static void Helper__Parse__DataTypeWithLength
                        (ref tagResultData resultData)
 {
#if DEBUG
  var debug__iStart
   =resultData.iPos;
#endif

  resultData.iPos
   =tagUtils.SkipEmptySpace
     (resultData.SourceStr,
      resultData.iPos);

  if(resultData.iPos==resultData.SourceStr.Length)
   return;

  if(resultData.SourceStr[resultData.iPos]!='(')
   return;

  ++resultData.iPos;

  Helper__Parse__Length
   (ref resultData);

  resultData.iPos
   =tagUtils.SkipEmptySpace
     (resultData.SourceStr,
      resultData.iPos);

  if(resultData.iPos==resultData.SourceStr.Length)
  {
   //ERROR - incompleted datatype definition

   ThrowError.TypeMappingErr__IncompletedDataTypeDefinition
    (c_ErrSrcID,
     resultData.DataTypeDescr.DataTypeID.ToString());
  }//if

  if(resultData.SourceStr[resultData.iPos]!=')')
  {
   //ERROR - bad datatype definition

   ThrowError.TypeMappingErr__BadDataTypeDefinition
    (c_ErrSrcID,
     resultData.DataTypeDescr.DataTypeID.ToString());
  }//if

  ++resultData.iPos;
 }//Helper__Parse__DataTypeWithLength

 //-----------------------------------------------------------------------
 private static void Helper__Parse__DataTypeWithPrecisionAndScale
                        (ref tagResultData resultData)
 {
#if DEBUG
  var debug__iStart
   =resultData.iPos;
#endif

  resultData.iPos
   =tagUtils.SkipEmptySpace
     (resultData.SourceStr,
      resultData.iPos);

  if(resultData.iPos==resultData.SourceStr.Length)
   return;

  if(resultData.SourceStr[resultData.iPos]!='(')
   return;

  ++resultData.iPos;

  Helper__Parse__Precision_and_Scale
   (ref resultData);

  resultData.iPos
   =tagUtils.SkipEmptySpace
     (resultData.SourceStr,
      resultData.iPos);

  if(resultData.iPos==resultData.SourceStr.Length)
  {
   //ERROR - incompleted datatype definition

   ThrowError.TypeMappingErr__IncompletedDataTypeDefinition
    (c_ErrSrcID,
     resultData.DataTypeDescr.DataTypeID.ToString());
  }//if

  if(resultData.SourceStr[resultData.iPos]!=')')
  {
   //ERROR - bad datatype definition

   ThrowError.TypeMappingErr__BadDataTypeDefinition
    (c_ErrSrcID,
     resultData.DataTypeDescr.DataTypeID.ToString());
  }//if

  ++resultData.iPos;
 }//Helper__Parse__DataTypeWithPrecisionAndScale

 //-----------------------------------------------------------------------
 private static void Helper__Parse__ArrayBounds
                        (ref tagResultData resultData)
 {
  // not implemented
 }//Helper__ParseArrayBounds

 //-----------------------------------------------------------------------
 private static void Helper__Parse__Length
                        (ref tagResultData resultData)
 {
#if DEBUG
  var debug__iStart
   =resultData.iPos;
#endif

  resultData.iPos
   =tagUtils.SkipEmptySpace
     (resultData.SourceStr,
      resultData.iPos);

  if(resultData.iPos==resultData.SourceStr.Length)
  {
   //ERROR - incompleted datatype definition

   ThrowError.TypeMappingErr__IncompletedDataTypeDefinition
    (c_ErrSrcID,
     resultData.DataTypeDescr.DataTypeID.ToString());
  }//if

  if(!tagUtils.IsDigit(resultData.SourceStr[resultData.iPos]))
  {
   //ERROR - expected length of datatype

   ThrowError.TypeMappingErr__FailedToParseDataTypeLength
    (c_ErrSrcID,
     resultData.DataTypeDescr.DataTypeID.ToString());
  }//if

  var iSizeBeg
   =resultData.iPos;

  for(;;)
  {
   Debug.Assert(resultData.iPos>=0);
   Debug.Assert(resultData.iPos<resultData.SourceStr.Length);

   ++resultData.iPos;

   if(resultData.iPos==resultData.SourceStr.Length)
    break;

   if(!tagUtils.IsDigit(resultData.SourceStr[resultData.iPos]))
    break;
  }//for[ever]

  if(!tagUtils.TryCvtStrRangeToInt
                        (resultData.SourceStr.AsSpan(iSizeBeg,resultData.iPos-iSizeBeg),
                         out var length))
  {
   //ERROR - too large length of datatype

   ThrowError.TypeMappingErr__TooLargeLengthOfDataType
    (c_ErrSrcID,
     resultData.DataTypeDescr.DataTypeID.ToString());
  }//if

  Debug.Assert(length>=0);

  resultData.DataTypeDescr.Length
   =length;
 }//Helper__Parse__Length

 //-----------------------------------------------------------------------
 private static void Helper__Parse__Precision_and_Scale
                        (ref tagResultData resultData)
 {
  Helper__Parse__Precision
   (ref resultData);

  resultData.iPos
   =tagUtils.SkipEmptySpace
     (resultData.SourceStr,
      resultData.iPos);

  if(resultData.iPos==resultData.SourceStr.Length)
   return;

  if(resultData.SourceStr[resultData.iPos]!=',')
   return;

  ++resultData.iPos;

  Helper__Parse__Scale
   (ref resultData);
 }//Helper__Parse__Precision_and_Scale

 //-----------------------------------------------------------------------
 private static void Helper__Parse__Precision
                        (ref tagResultData resultData)
 {
#if DEBUG
  var debug__iStart
   =resultData.iPos;
#endif

  resultData.iPos
   =tagUtils.SkipEmptySpace
     (resultData.SourceStr,
      resultData.iPos);

  if(resultData.iPos==resultData.SourceStr.Length)
  {
   //ERROR - incompleted datatype definition

   ThrowError.TypeMappingErr__IncompletedDataTypeDefinition
    (c_ErrSrcID,
     resultData.DataTypeDescr.DataTypeID.ToString());
  }//if

  if(!tagUtils.IsDigit(resultData.SourceStr[resultData.iPos]))
  {
   //ERROR - expected precision of datatype

   ThrowError.TypeMappingErr__FailedToParseDataTypePrecision
    (c_ErrSrcID,
     resultData.DataTypeDescr.DataTypeID.ToString());
  }//if

  var iPrecisionBeg
   =resultData.iPos;

  for(;;)
  {
   Debug.Assert(resultData.iPos>=0);
   Debug.Assert(resultData.iPos<resultData.SourceStr.Length);

   ++resultData.iPos;

   if(resultData.iPos==resultData.SourceStr.Length)
    break;

   if(!tagUtils.IsDigit(resultData.SourceStr[resultData.iPos]))
    break;
  }//for[ever]

  if(!tagUtils.TryCvtStrRangeToInt
                        (resultData.SourceStr.AsSpan(iPrecisionBeg,resultData.iPos-iPrecisionBeg),
                         out var precision))
  {
   //ERROR - too large precision of datatype

   ThrowError.TypeMappingErr__TooLargePrecisionOfDataType
    (c_ErrSrcID,
     resultData.DataTypeDescr.DataTypeID.ToString());
  }//if

  Debug.Assert(precision>=0);

  resultData.DataTypeDescr.Precision
   =precision;
 }//Helper__Parse__Precision

 //-----------------------------------------------------------------------
 private static void Helper__Parse__Scale
                        (ref tagResultData resultData)
 {
#if DEBUG
  var debug__iStart
   =resultData.iPos;
#endif

  resultData.iPos
   =tagUtils.SkipEmptySpace
     (resultData.SourceStr,
      resultData.iPos);

  if(resultData.iPos==resultData.SourceStr.Length)
  {
   //ERROR - incompleted datatype definition

   ThrowError.TypeMappingErr__IncompletedDataTypeDefinition
    (c_ErrSrcID,
     resultData.DataTypeDescr.DataTypeID.ToString());
  }//if

  if(!tagUtils.IsDigit(resultData.SourceStr[resultData.iPos]))
  {
   //ERROR - expected scale of datatype

   ThrowError.TypeMappingErr__FailedToParseDataTypeScale
    (c_ErrSrcID,
     resultData.DataTypeDescr.DataTypeID.ToString());
  }//if

  var iScaleBeg
   =resultData.iPos;

  for(;;)
  {
   Debug.Assert(resultData.iPos>=0);
   Debug.Assert(resultData.iPos<resultData.SourceStr.Length);

   ++resultData.iPos;

   if(resultData.iPos==resultData.SourceStr.Length)
    break;

   if(!tagUtils.IsDigit(resultData.SourceStr[resultData.iPos]))
    break;
  }//for[ever]

  if(!tagUtils.TryCvtStrRangeToInt
                        (resultData.SourceStr.AsSpan(iScaleBeg,resultData.iPos-iScaleBeg),
                         out var scale))
  {
   //ERROR - too large scale of datatype

   ThrowError.TypeMappingErr__TooLargeScaleOfDataType
    (c_ErrSrcID,
     resultData.DataTypeDescr.DataTypeID.ToString());
  }//if

  Debug.Assert(scale>=0);

  resultData.DataTypeDescr.Scale
   =scale;
 }//Helper__Parse__Scale

 //-----------------------------------------------------------------------
 private static void Helper__Parse__CharSetName
                        (ref tagResultData resultData)
 {
  resultData.iPos
   =tagUtils.SkipEmptySpace
     (resultData.SourceStr,
      resultData.iPos);

  int iPos
   =resultData.iPos;

  //---------------------------------------- PARSE "CHARACTER SET"
  for(int n=0;n!=sm_CsParts.Length;++n)
  {
   Debug.Assert(iPos>=0);
   Debug.Assert(iPos<=resultData.SourceStr.Length);

   var iBeg
    =iPos;

   iPos
    =tagUtils.SkipKeyword
      (resultData.SourceStr,
       iPos);

   if(iBeg==iPos)
   {
    if(n==0)
     return; //no charset section

    ThrowError.TypeMappingErr__IncompletedDataTypeDefinition
     (c_ErrSrcID,
      resultData.DataTypeDescr.DataTypeID.ToString());
   }//if

   Debug.Assert(iBeg<iPos);

   if(!tagUtils.TestStrRange__IsKeyword
                        (resultData.SourceStr.AsSpan(iBeg,iPos-iBeg),
                         sm_CsParts[n]))
   {
    if(n==0)
    {
     //no charset section

     return;
    }//if

    Debug.Assert(n>0);

    //ERROR - bad datatype definition

    ThrowError.TypeMappingErr__BadDataTypeDefinition
     (c_ErrSrcID,
      resultData.DataTypeDescr.DataTypeID.ToString());
   }//if

   iPos
    =tagUtils.SkipEmptySpace
      (resultData.SourceStr,
       iPos);
  }//for n

  //---------------------------------------- PARSE "CS_NAME"

  var iCsNameBeg
   =iPos;

  iPos
   =tagUtils.SkipCharSetName
     (resultData.SourceStr,
      iPos);

  if(iCsNameBeg==iPos)
  {
   //ERROR - Not defined name of charset

   ThrowError.TypeMappingErr__NoCharSetName
    (c_ErrSrcID,
     resultData.DataTypeDescr.DataTypeID.ToString());
  }//if

  resultData.DataTypeDescr.CharSetName
   =tagUtils.MakeCharSetNameFromStrRange
     (resultData.SourceStr.AsSpan
       (iCsNameBeg,
        iPos-iCsNameBeg));

  resultData.iPos
   =iPos;
 }//Helper__Parse__CharSetName

 //-----------------------------------------------------------------------
 private static void Helper__Parse__BlobSubType
                        (ref tagResultData resultData)
 {
  resultData.iPos
   =tagUtils.SkipEmptySpace
     (resultData.SourceStr,
      resultData.iPos);

  int iPos
   =resultData.iPos;

  //---------------------------------------- PARSE "SUB_TYPE"
  Debug.Assert(iPos>=0);
  Debug.Assert(iPos<=resultData.SourceStr.Length);

  var iBeg
   =iPos;

  iPos
   =tagUtils.SkipKeyword
     (resultData.SourceStr,
      iPos);

  if(iBeg==iPos)
   return; //no sub_type section

  Debug.Assert(iBeg<iPos);

  if(!tagUtils.TestStrRange__IsKeyword
                        (resultData.SourceStr.AsSpan(iBeg,iPos-iBeg),
                         "SUB_TYPE"))
  {
   return; //no sub_type section
  }//if

  iPos
   =tagUtils.SkipEmptySpace
     (resultData.SourceStr,
      iPos);

  //---------------------------------------- PARSE "SUB_TYPE_NAME"

  var iSubTypeNameBeg
   =iPos;

  iPos
   =tagUtils.SkipSubTypeName
     (resultData.SourceStr,
      iPos);

  if(iSubTypeNameBeg==iPos)
  {
   //ERROR - Not defined name of sub_type

   ThrowError.TypeMappingErr__NoSubTypeName
    (c_ErrSrcID,
     resultData.DataTypeDescr.DataTypeID.ToString());
  }//if

  resultData.DataTypeDescr.BlobSubTypeID
   =Helper__ParseBlobSubTypeID
     (resultData.SourceStr.AsSpan
       (iSubTypeNameBeg,
        iPos-iSubTypeNameBeg));

  resultData.iPos
   =iPos;
 }//Helper__Parse__BlobSubType

 //-----------------------------------------------------------------------
 private static FB_Common__BlobSubTypeID Helper__ParseBlobSubTypeID(ReadOnlySpan<char> sourceStr)
 {
  if(tagUtils.TestStrRange__IsBlobSubType(sourceStr,FB_Common__BlobSubTypeNames.BINARY))
   return FB_Common__BlobSubTypeID.BINARY;

  if(tagUtils.TestStrRange__IsBlobSubType(sourceStr,FB_Common__BlobSubTypeNames.TEXT))
   return FB_Common__BlobSubTypeID.TEXT;

  ThrowError.TypeMappingErr__UnknownBlobSubType
   (c_ErrSrcID,
    sourceStr.ToString());

  return 0;
 }//Helper__ParseBlobSubTypeID

 //private data ----------------------------------------------------------
 private static readonly string[]
  sm_CsParts
   ={
     "CHARACTER",   // UPPER!
     "SET",         // UPPER!
    };//sm_CsParts

 //-----------------------------------------------------------------------
 private delegate void tagDataTypeParserFunc(ref tagResultData resultData);

 private class tagDataTypeParserDescr
 {
  public readonly IReadOnlyList<string>  DataTypeNameParts;
  public readonly FB_Common__DataTypeID  DataTypeID;
  public readonly string                 DataTypeNameBase;
  public readonly tagDataTypeParserFunc  ParserFunc;

  //-------------------------------------------------------
  public tagDataTypeParserDescr(string                dataTypeName,
                                FB_Common__DataTypeID dataTypeID,
                                string                dataTypeNameBase,
                                tagDataTypeParserFunc parserFunc)
  {
   Debug.Assert(!string.IsNullOrEmpty(dataTypeName));
   Debug.Assert(!string.IsNullOrEmpty(dataTypeNameBase));
   Debug.Assert(!Object.ReferenceEquals(parserFunc,null));

   this.DataTypeNameParts = new[]{dataTypeName};
   this.DataTypeID        = dataTypeID;
   this.DataTypeNameBase  = dataTypeNameBase;
   this.ParserFunc        = parserFunc;
  }//tagDataTypeParserDescr

  //-------------------------------------------------------
  public tagDataTypeParserDescr(IReadOnlyList<string> dataTypeNameParts,
                                FB_Common__DataTypeID dataTypeID,
                                string                dataTypeNameBase,
                                tagDataTypeParserFunc parserFunc)
  {
   Debug.Assert(!Object.ReferenceEquals(dataTypeNameParts,null));
   Debug.Assert(dataTypeNameParts.Count>0);
   Debug.Assert(!string.IsNullOrEmpty(dataTypeNameBase));
   Debug.Assert(!Object.ReferenceEquals(parserFunc,null));

#if DEBUG
   foreach(var x in dataTypeNameParts)
   {
    Debug.Assert(!string.IsNullOrEmpty(x));
   }//for x
#endif

   this.DataTypeNameParts = dataTypeNameParts;
   this.DataTypeID        = dataTypeID;
   this.DataTypeNameBase  = dataTypeNameBase;
   this.ParserFunc        = parserFunc;
  }//tagDataTypeParserDescr
 };//struct tagDataTypeParserDescr

 //-----------------------------------------------------------------------
 private static ResultCode Helper__FindDataTypeParserDescr
                        (string                                sourceStr,
                         int                                   sourceOffset,
                         IReadOnlyList<tagDataTypeParserDescr> sourceDescrs,
                         int                                   iTestNamePart,
                         out tagDataTypeParserDescr            result_Descr,
                         out int                               result_Offset)
 {
  //
  // Recursive method.
  //

  Debug.Assert(!Object.ReferenceEquals(sourceStr,null));
  Debug.Assert(sourceOffset>=0);
  Debug.Assert(sourceOffset<=sourceStr.Length);

  Debug.Assert(!Object.ReferenceEquals(sourceDescrs,null));
  Debug.Assert(sourceDescrs.Count>0);
  Debug.Assert(iTestNamePart>=0);

  result_Descr  = default;
  result_Offset = sourceOffset;

  //----------------------------------------
  var iPos
   =tagUtils.SkipEmptySpace
     (sourceStr,
      sourceOffset);

  if(iPos==sourceStr.Length)
   return ResultCode.NoData;

  //----------------------------------------
  var iTypeNamePartBeg
   =iPos;

  iPos
    =tagUtils.SkipTypeName
      (sourceStr,
       iPos);

  if(iTypeNamePartBeg==iPos)
   return ResultCode.NoData; //NO DATA

  //----------------------------------------
  var currentTypeNamePart
   =sourceStr.AsSpan(iTypeNamePartBeg,iPos-iTypeNamePartBeg);

  List<tagDataTypeParserDescr>
   newSourceDescrs
    =null;

  int maxPartCount=0;

  for(int i=0;i!=sourceDescrs.Count;++i)
  {
   var descr
    =sourceDescrs[i];

   Debug.Assert(!Object.ReferenceEquals(descr,null));
   Debug.Assert(!Object.ReferenceEquals(descr.DataTypeNameParts,null));
   Debug.Assert(descr.DataTypeNameParts.Count>0);

   Debug.Assert(iTestNamePart<descr.DataTypeNameParts.Count);

   if(!tagUtils.TestStrRange__IsDataType(currentTypeNamePart,descr.DataTypeNameParts[iTestNamePart]))
    continue;

   if(maxPartCount<descr.DataTypeNameParts.Count)
    maxPartCount=descr.DataTypeNameParts.Count;

   if(Object.ReferenceEquals(newSourceDescrs,null))
    newSourceDescrs=new List<tagDataTypeParserDescr>();

   newSourceDescrs.Add(descr);
  }//for i

  if(Object.ReferenceEquals(newSourceDescrs,null))
   return ResultCode.UnknownTypeName;

  Debug.Assert(newSourceDescrs.Count>0);

  var iTestNamePart_next
   =iTestNamePart+1;

  Debug.Assert(iTestNamePart_next<=maxPartCount);

  if(iTestNamePart_next==maxPartCount)
  {
   //NO AMBIGUITY!
   Debug.Assert(newSourceDescrs.Count==1);

   result_Descr  =newSourceDescrs[0];
   result_Offset =iPos;

   return ResultCode.Ok;
  }//if

  Debug.Assert(iTestNamePart_next<maxPartCount);

  //RECURSIVE CALL

  var r
   =Helper__FindDataTypeParserDescr
     (sourceStr,
      iPos,
      newSourceDescrs,
      iTestNamePart_next,
      out result_Descr,
      out result_Offset);

  if(r==ResultCode.Ok)
  {
   Debug.Assert(!Object.ReferenceEquals(result_Descr,null));

   //Expected a movig to foward
   Debug.Assert(iPos<result_Offset);

   return r;
  }//if

  Debug.Assert(r!=ResultCode.Ok);

  //
  // Let's try to select the result from newSourceDescrs
  //

  Debug.Assert(!Object.ReferenceEquals(newSourceDescrs,null));
  Debug.Assert(newSourceDescrs.Count>0);

  for(int i=0;i!=newSourceDescrs.Count;++i)
  {
   var descr
    =newSourceDescrs[i];

   Debug.Assert(!Object.ReferenceEquals(descr,null));
   Debug.Assert(!Object.ReferenceEquals(descr.DataTypeNameParts,null));
   Debug.Assert(descr.DataTypeNameParts.Count>0);

   Debug.Assert(iTestNamePart_next<=descr.DataTypeNameParts.Count);

   if(iTestNamePart_next<descr.DataTypeNameParts.Count)
    continue;

   Debug.Assert(iTestNamePart_next==descr.DataTypeNameParts.Count);

#if DEBUG
   for(int i2=i+1;i2!=newSourceDescrs.Count;++i2)
   {
    //EXPECTED. NO AMBIGUITY!
    Debug.Assert(iTestNamePart_next<newSourceDescrs[i2].DataTypeNameParts.Count);
   }//for i2
#endif

   result_Descr  =descr;
   result_Offset =iPos;

   return ResultCode.Ok;
  }//for i

  if(r==ResultCode.NoData)
  {
   if(newSourceDescrs.Count==1)
   {
    ThrowError.TypeMappingErr__IncompletedDataTypeDefinition
     (c_ErrSrcID,
      newSourceDescrs[0].DataTypeID.ToString());
   }
   else
   {
    // [2021-10-21] No way to hit here. May be in future :)

    ThrowError.TypeMappingErr__IncompletedDataTypeDefinition
     (c_ErrSrcID);
   }//else
  }//if r==ResultCode.NoData

  // WITHOUT VARIANTS
  Debug.Assert(r==ResultCode.UnknownTypeName);

  return ResultCode.UnknownTypeName;
 }//Helper__FindDataTypeParserDescr

 //-----------------------------------------------------------------------
 private static readonly tagDataTypeParserDescr[]
  sm_ParserDescrs
   =new[]
    {
     new tagDataTypeParserDescr(FB_Common__SqlDataTypeNames.VARCHAR   , FB_Common__DataTypeID.VARCHAR   ,FB_Common__SqlDataTypeNames.VARCHAR     ,  Helper__Parse__VARCHAR),

     new tagDataTypeParserDescr(FB_Common__SqlDataTypeNames.CHAR      , FB_Common__DataTypeID.CHAR      ,FB_Common__SqlDataTypeNames.CHAR        ,  Helper__Parse__CHAR),

     new tagDataTypeParserDescr(FB_Common__SqlDataTypeNames.VARBINARY , FB_Common__DataTypeID.VARBINARY ,FB_Common__SqlDataTypeNames.VARCHAR/*!*/,  Helper__Parse__VARBINARY),

     new tagDataTypeParserDescr(FB_Common__SqlDataTypeNames.BINARY    , FB_Common__DataTypeID.BINARY    ,FB_Common__SqlDataTypeNames.CHAR/*!*/   ,  Helper__Parse__BINARY),

     new tagDataTypeParserDescr(FB_Common__SqlDataTypeNames.DECIMAL   , FB_Common__DataTypeID.DECIMAL   ,FB_Common__SqlDataTypeNames.DECIMAL     ,  Helper__Parse__DECIMAL),

     new tagDataTypeParserDescr(FB_Common__SqlDataTypeNames.NUMERIC   , FB_Common__DataTypeID.NUMERIC   ,FB_Common__SqlDataTypeNames.NUMERIC     ,  Helper__Parse__NUMERIC),

     new tagDataTypeParserDescr(FB_Common__SqlDataTypeNames.SMALLINT  , FB_Common__DataTypeID.SMALLINT  ,FB_Common__SqlDataTypeNames.SMALLINT    ,  Helper__Parse__SMALLINT),

     new tagDataTypeParserDescr(FB_Common__SqlDataTypeNames.INTEGER   , FB_Common__DataTypeID.INTEGER   ,FB_Common__SqlDataTypeNames.INTEGER     ,  Helper__Parse__INTEGER),

     new tagDataTypeParserDescr(FB_Common__SqlDataTypeNames.BIGINT    , FB_Common__DataTypeID.BIGINT    ,FB_Common__SqlDataTypeNames.BIGINT      ,  Helper__Parse__BIGINT),

     new tagDataTypeParserDescr(FB_Common__SqlDataTypeNames.FLOAT     , FB_Common__DataTypeID.FLOAT     ,FB_Common__SqlDataTypeNames.FLOAT       ,  Helper__Parse__FLOAT),

     new tagDataTypeParserDescr(new[]{"DOUBLE","PRECISION"}           , FB_Common__DataTypeID.DOUBLE    ,FB_Common__SqlDataTypeNames.DOUBLE      ,  Helper__Parse__DOUBLE),

     new tagDataTypeParserDescr(FB_Common__SqlDataTypeNames.BOOLEAN   , FB_Common__DataTypeID.BOOLEAN   ,FB_Common__SqlDataTypeNames.BOOLEAN     ,  Helper__Parse__BOOLEAN),

     new tagDataTypeParserDescr(FB_Common__SqlDataTypeNames.TIMESTAMP , FB_Common__DataTypeID.TIMESTAMP ,FB_Common__SqlDataTypeNames.TIMESTAMP   ,  Helper__Parse__TIMESTAMP),

     new tagDataTypeParserDescr(FB_Common__SqlDataTypeNames.DATE      , FB_Common__DataTypeID.DATE      ,FB_Common__SqlDataTypeNames.DATE        ,  Helper__Parse__DATE),

     new tagDataTypeParserDescr(FB_Common__SqlDataTypeNames.TIME      , FB_Common__DataTypeID.TIME      ,FB_Common__SqlDataTypeNames.TIME        ,  Helper__Parse__TIME),

     new tagDataTypeParserDescr(FB_Common__SqlDataTypeNames.BLOB      , FB_Common__DataTypeID.BLOB      ,FB_Common__SqlDataTypeNames.BLOB        ,  Helper__Parse__BLOB),
    };//sm_ParserDescrs
};//class FB_DataTypeParser

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.V03_0_0
