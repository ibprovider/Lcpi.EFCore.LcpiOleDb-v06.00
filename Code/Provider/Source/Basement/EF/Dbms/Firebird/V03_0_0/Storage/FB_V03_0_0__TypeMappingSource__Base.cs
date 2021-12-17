////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 06.10.2021.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;

using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Storage{
////////////////////////////////////////////////////////////////////////////////

using Structure_MethodInfoCache
 =Structure.Structure_MethodInfoCache;

using Structure_TypeCache
 =Structure.Structure_TypeCache;

using Structure_ADP
 =Structure.Structure_ADP;

////////////////////////////////////////////////////////////////////////////////

using T_FB_DATATYPE_PARSER
 =Core.Engines.Dbms.Firebird.V03_0_0.FB_DataTypeParser;

using T_FB_DATATYPE_DESCR
 =Core.Engines.Dbms.Firebird.Common.FB_Common__DataTypeDescr;

////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__TypeMappingSource__Base

abstract class FB_V03_0_0__TypeMappingSource__Base:RelationalTypeMappingSource
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_V03_0_0__TypeMappingSource__Base;

 //-----------------------------------------------------------------------
 protected FB_V03_0_0__TypeMappingSource__Base
                        (TypeMappingSourceDependencies           dependencies,
                         RelationalTypeMappingSourceDependencies relationalDependencies)
  :base(dependencies,relationalDependencies)
 {
 }//FB_V03_0_0__TypeMappingSource__Base

 //RelationalTypeMappingSource interface ---------------------------------
 public override sealed RelationalTypeMapping FindMapping
                        (System.Type           type,
                         string                storeTypeName,
                         bool                  keyOrIndex,
                         System.Nullable<bool> unicode,
                         System.Nullable<int>  size,
                         System.Nullable<bool> rowVersion,
                         System.Nullable<bool> fixedLength,
                         System.Nullable<int>  precision,
                         System.Nullable<int>  scale)
 {
  string storeTypeBaseName=null;

  if(!Object.ReferenceEquals(storeTypeName,null))
  {
   storeTypeBaseName
    =this.ParseStoreTypeName
      (storeTypeName,
       out var parsedUnicode,
       out var parsedSize,
       out var parsedPrecision,
       out var parsedScale);

   // Voice the whole (error) list, please ...
   List<Core.Core_ExceptionRecord>
    errorRecords
     =null;

   if(!Structure_ADP.AssignOnceIfNotNull(ref size,parsedSize))
   {
    Helper__Reg__TypeMappingErr__MultipleDefinitionOfTypeProperty
     (ref errorRecords,
      nameof(size),
      size,
      parsedSize);
   }//if

   if(!Structure_ADP.AssignOnceIfNotNull(ref precision,parsedPrecision))
   {
    Helper__Reg__TypeMappingErr__MultipleDefinitionOfTypeProperty
     (ref errorRecords,
      nameof(precision),
      precision,
      parsedPrecision);
   }//if

   if(!Structure_ADP.AssignOnceIfNotNull(ref scale,parsedScale))
   {
    Helper__Reg__TypeMappingErr__MultipleDefinitionOfTypeProperty
     (ref errorRecords,
      nameof(scale),
      scale,
      parsedScale);
   }//if

   if(!Structure_ADP.AssignOnceIfNotNull(ref unicode,parsedUnicode))
   {
    Helper__Reg__TypeMappingErr__MultipleDefinitionOfTypeProperty
     (ref errorRecords,
      nameof(unicode),
      unicode,
      parsedUnicode);
   }//if

   ErrorUtils.ThrowIfNotEmpty
    (errorRecords);
  }//if !Object.ReferenceEquals(storeTypeName,null)

  //----------------------------------------
  var info
   =new RelationalTypeMappingInfo
     (type,
      storeTypeName,
      storeTypeBaseName,
      keyOrIndex,
      unicode,
      size,
      rowVersion,
      fixedLength,
      precision,
      scale);

  return Helper__EFCore__FindMappingWithConversion
          (/*in*/info,
           null);
 }//FindMapping

 //RelationalTypeMappingSource interface ---------------------------------
 public override sealed CoreTypeMapping FindMapping(MemberInfo member)
 {
  Check.Arg_NotNull
   (c_ErrSrcID,
    "FindMapping(member)",
    nameof(member),
    member);

  return base.FindMapping(member);
 }//FindMapping - member

 //-----------------------------------------------------------------------
 protected override sealed RelationalTypeMapping FindMapping(in RelationalTypeMappingInfo mappingInfo)
 {
  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);

#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_V03_0_0__TypeMappingSource__Base::FindMapping(mappingInfo: {{ClrType: {0}, StoreTypeNameBase:{1}}})",
    mappingInfo.ClrType,
    mappingInfo.StoreTypeNameBase);
#endif

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(FindMapping),
    nameof(mappingInfo),
    mappingInfo);

  //----------------------------------------------------------------------
  var typeMapping
   =this.Helper__FindMapping(mappingInfo);

  // [2019-03-15] If not found, then not found.
  //Debug.Assert(!Object.ReferenceEquals(r,null));

#if DEBUG
  for(;;)
  {
   if(Object.ReferenceEquals(typeMapping,null))
    break;
    
   Debug.Assert(!Object.ReferenceEquals(typeMapping.ClrType,null));

   if(Object.ReferenceEquals(mappingInfo.ClrType,null))
    break;

   //EXPECTED
   Debug.Assert(typeMapping.ClrType==mappingInfo.ClrType);

   break;
  }//for[ever]
#endif

#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_V03_0_0__TypeMappingSource__Base::FindMapping(mappingInfo: {{ClrType: {0}, StoreTypeNameBase:{1}}}) - {2}",
    mappingInfo.ClrType,
    mappingInfo.StoreTypeNameBase,
    typeMapping);
#endif

  return typeMapping;
 }//FindMapping - mappingInfo

 //-----------------------------------------------------------------------
 //  public override CoreTypeMapping FindMapping(Type clrType)
 //  {
 //   [2020-12-01] SHIT
 //  }//FindMapping - type

 //Helper methods --------------------------------------------------------
 private RelationalTypeMapping Helper__FindMapping(in RelationalTypeMappingInfo mappingInfo)
 {
  //Debug.Assert(!Object.ReferenceEquals(mappingInfo,null));
  Debug.Assert(mappingInfo.GetType().IsValueType);

  //------------------------------------------------------- By StoreTypeName
  if(!Object.ReferenceEquals(mappingInfo.StoreTypeName,null))
  {
   var typeMapping
    =Helper__FindMapping__ByStoreTypeName
      (mappingInfo.StoreTypeName,
       mappingInfo); //throw

   if(!Object.ReferenceEquals(typeMapping,null))
    return typeMapping;
  }//if

  //------------------------------------------------------- By StoreTypeNameBase
  if(!Object.ReferenceEquals(mappingInfo.StoreTypeNameBase,null))
  {
   var typeMapping
    =Helper__FindMapping__ByStoreTypeName
      (mappingInfo.StoreTypeNameBase,
       mappingInfo); //throw

   if(!Object.ReferenceEquals(typeMapping,null))
    return typeMapping;
  }//if

  //------------------------------------------------------- By ClrType
  if(!Object.ReferenceEquals(mappingInfo.ClrType,null))
  {
   var typeMapping
    =Internal__FindMapping__ByClrType
      (mappingInfo);

   if(!Object.ReferenceEquals(typeMapping,null))
    return typeMapping;
  }//if

  //------------------------------------------------------- EXIT

  //ERROR - can't map to datatype!

  // [2019-03-15] If not found, then not found.

  // Debug.Assert(false);
  //
  // ThrowError.TypeMappingErr__CantMapInfoToProviderDatatype
  //  (c_ErrSrcID,
  //   mappingInfo__clrType,
  //   mappingInfo__StoreTypeNameBase);

  return null;
 }//Helper__FindMapping - mappingInfo

 //-----------------------------------------------------------------------
 protected override sealed string ParseStoreTypeName
                                           (string                    storeTypeName,
                                            out System.Nullable<bool> result_unicode,
                                            out System.Nullable<int>  result_size,
                                            out System.Nullable<int>  result_precision,
                                            out System.Nullable<int>  result_scale)
 {
  const string c_bugcheck_src
   ="FB_V03_0_0__TypeMappingSource__Base::ParseStoreTypeName";

  //-------------------------------------------------------
  result_unicode   =null;
  result_size      =null;
  result_precision =null;
  result_scale     =null;

  if(Object.ReferenceEquals(storeTypeName, null))
   return null;

  T_FB_DATATYPE_PARSER.tagResultData
   storeTypeDescr;

  var parserResultCode
   =T_FB_DATATYPE_PARSER.Exec
     (storeTypeName,
      out storeTypeDescr);

  switch(parserResultCode)
  {
   case T_FB_DATATYPE_PARSER.ResultCode.Ok:
    break;

   case T_FB_DATATYPE_PARSER.ResultCode.NoData:
    return null;

   case T_FB_DATATYPE_PARSER.ResultCode.UnknownTypeName:
   {
    //ERROR - UNKNOWN DATA TYPE

    ThrowError.TypeMappingErr__UnknownStoreTypeName
     (c_ErrSrcID,
      storeTypeName);

    break;
   }//case - UnknownTypeName

   default:
   {
    //ERROR - unknown datatype parser code

    ThrowBugCheck.UnknownParserResultCode
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      parserResultCode);

    break;
   }//default
  }//switch

  //----------------------------------------
  result_precision
   =storeTypeDescr.DataTypeDescr.Precision;

  result_scale
   =storeTypeDescr.DataTypeDescr.Scale;

  result_size
   =storeTypeDescr.DataTypeDescr.Length;

  Debug.Assert(!Object.ReferenceEquals(storeTypeDescr.DataTypeDescr.DataTypeNameBase,null));

  return storeTypeDescr.DataTypeDescr.DataTypeNameBase;
 }//ParseStoreTypeName

 //Internal interface ----------------------------------------------------

 protected abstract RelationalTypeMapping Internal__FindMapping__ByStoreDataTypeInfo
                                           (in T_FB_DATATYPE_DESCR        storeDataTypeInfo,
                                            in RelationalTypeMappingInfo  mappingInfo);

 protected abstract RelationalTypeMapping Internal__FindMapping__ByClrType
                                           (in RelationalTypeMappingInfo mappingInfo);

 //Helper methods --------------------------------------------------------
 private RelationalTypeMapping Helper__FindMapping__ByStoreTypeName
                                           (string                       storeDataType,
                                            in RelationalTypeMappingInfo mappingInfo)
 {
  const string c_bugcheck_src
   ="FB_V03_0_0__TypeMappingSource__Base::Helper__FindMapping__ByStoreTypeName";

  //-------------------------------------------------------
  T_FB_DATATYPE_PARSER.tagResultData
   storeDataTypeInfo;

  var parserResultCode
   =T_FB_DATATYPE_PARSER.Exec
     (storeDataType,
      out storeDataTypeInfo);

  switch(parserResultCode)
  {
   case T_FB_DATATYPE_PARSER.ResultCode.Ok:
   {
    break;
   }

   case T_FB_DATATYPE_PARSER.ResultCode.NoData:
   {
    return null;
   }

   case T_FB_DATATYPE_PARSER.ResultCode.UnknownTypeName:
   {
    //ERROR - unknown storeDataType descr

    ThrowError.TypeMappingErr__UnknownStoreTypeName
     (c_ErrSrcID,
      storeDataType);

    break;
   }//case - UnknownTypeName

   default:
   {
    //ERROR - unexpected parser result code

    ThrowBugCheck.UnknownParserResultCode
     (c_ErrSrcID,
      c_bugcheck_src,
      "#001",
      parserResultCode);

    break;
   }//default
  }//switch

  //------------------------------------------------------------

  // CHECK DATA CONSISTENCY IN storeDataTypeInfo and mappingInfo:
  //  size
  //  precision
  //  scale

  var mappingInfo_Size
   =mappingInfo.Size;

  var mappingInfo_Precision
   =mappingInfo.Precision;

  var mappingInfo_Scale
   =mappingInfo.Scale;

  // Voice the whole (error) list, please ...
  List<Core.Core_ExceptionRecord>
   errorRecords
    =null;

  if(!Structure_ADP.AssignOnceIfNotNull(ref mappingInfo_Size,storeDataTypeInfo.DataTypeDescr.Length))
  {
   Helper__Reg__TypeMappingErr__MultipleDefinitionOfTypeProperty
    (ref errorRecords,
     "size",
     mappingInfo_Size,
     storeDataTypeInfo.DataTypeDescr.Length);
  }//if

  if(!Structure_ADP.AssignOnceIfNotNull(ref mappingInfo_Precision,storeDataTypeInfo.DataTypeDescr.Precision))
  {
   Helper__Reg__TypeMappingErr__MultipleDefinitionOfTypeProperty
    (ref errorRecords,
     "precision",
     mappingInfo_Precision,
     storeDataTypeInfo.DataTypeDescr.Precision);
  }//if

  if(!Structure_ADP.AssignOnceIfNotNull(ref mappingInfo_Scale,storeDataTypeInfo.DataTypeDescr.Scale))
  {
   Helper__Reg__TypeMappingErr__MultipleDefinitionOfTypeProperty
    (ref errorRecords,
     "scale",
     mappingInfo_Scale,
     storeDataTypeInfo.DataTypeDescr.Scale);
  }//if

  ErrorUtils.ThrowIfNotEmpty
   (errorRecords);

  //------------------------------------------------------------
  var mappingInfo2
   =new RelationalTypeMappingInfo
     (mappingInfo.ClrType,
      storeDataType,
      storeDataTypeInfo.DataTypeDescr.DataTypeNameBase,
      mappingInfo.IsKeyOrIndex,
      mappingInfo.IsUnicode,
      mappingInfo_Size,
      mappingInfo.IsRowVersion,
      mappingInfo.IsFixedLength,
      mappingInfo_Precision,
      mappingInfo_Scale);

  return Internal__FindMapping__ByStoreDataTypeInfo
          (storeDataTypeInfo.DataTypeDescr,
           mappingInfo2);
 }//Helper__FindMapping__ByStoreTypeName

 //-----------------------------------------------------------------------

 // private RelationalTypeMapping? FindMappingWithConversion
 //   (in RelationalTypeMappingInfo mappingInfo,
 //    IReadOnlyList<IProperty>?    principals)

 private RelationalTypeMapping Helper__EFCore__FindMappingWithConversion
                                           (in RelationalTypeMappingInfo mappingInfo,
                                            IReadOnlyList<IProperty>     principals)
 {
  //------------------------------------------------------------ Debug Checks
#if DEBUG
  {
   Debug.Assert
    (!Object.ReferenceEquals
      (Structure_MethodInfoCache.Hack__MethodInfoOf__RelationalTypeMappingSource__FindMappingWithConversion,
       null));

   Debug.Assert
    (Structure_MethodInfoCache.Hack__MethodInfoOf__RelationalTypeMappingSource__FindMappingWithConversion.ReturnType
      ==Structure_TypeCache.TypeOf__MS_EFCore_Storage__RelationalTypeMapping);

   var debug__methodParams
    =Structure_MethodInfoCache.Hack__MethodInfoOf__RelationalTypeMappingSource__FindMappingWithConversion.GetParameters();

   Debug.Assert(!Object.ReferenceEquals(debug__methodParams,null));

   Debug.Assert(debug__methodParams.Length==2);

   Debug.Assert(!Object.ReferenceEquals(debug__methodParams[0],null));
   Debug.Assert(!Object.ReferenceEquals(debug__methodParams[1],null));

   Debug.Assert(debug__methodParams[0].ParameterType==typeof(RelationalTypeMappingInfo).MakeByRefType());
   Debug.Assert(debug__methodParams[1].ParameterType==typeof(IReadOnlyList<IProperty>));

   /* OK! */
  }//local
#endif //DEBUG

  //------------------------------------------------------------
  var parameters
   =new object[]
     {
      /* 0 */ mappingInfo,
      /* 1 */ principals
     };//parameters

  System.Object
   invokeResult_obj
    =Structure_MethodInfoCache.Hack__MethodInfoOf__RelationalTypeMappingSource__FindMappingWithConversion
      .Extension__InvokeWithTransparentHandlingOfException
        (this,
         parameters); //throw

  //--------------------------
#if DEBUG
  for(;;)
  {
   if(Object.ReferenceEquals(invokeResult_obj,null))
    break;

   if(invokeResult_obj.GetType().IsAssignableTo(Structure_TypeCache.TypeOf__MS_EFCore_Storage__RelationalTypeMapping))
    break;

   Debug.Assert(false);
  }//for[ever]
#endif

  //------------------------------------------------------------
  return (RelationalTypeMapping)invokeResult_obj;
 }//Helper__EFCore__TryRewriteEntityEquality

 //-----------------------------------------------------------------------
 private static void Helper__Reg__TypeMappingErr__MultipleDefinitionOfTypeProperty
                        (ref List<Core.Core_ExceptionRecord> errorRecords,
                         string                              propertyName,
                         object                              propertyValue1,
                         object                              propertyValue2)
 {
  var errRec
   =ErrorRecordCreator.TypeMappingErr__MultipleDefinitionOfTypeProperty
     (c_ErrSrcID,
      propertyName,
      propertyValue1,
      propertyValue2);

  ErrorUtils.Add
   (ref errorRecords,
    errRec);
 }//Helper__Reg__TypeMappingErr__MultipleDefinitionOfTypeProperty
};//class FB_V03_0_0__TypeMappingSource__Base

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Storage
