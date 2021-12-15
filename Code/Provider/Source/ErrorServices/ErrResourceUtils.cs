////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.05.2018.
using System;
using System.Globalization;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//using

using com_lib=lcpi.lib.com;

using oledb_lib=lcpi.lib.oledb;

using structure_lib=lcpi.lib.structure;

using resources_lib=lcpi.lib.resources;

using xdb=lcpi.data.oledb;

using Structure_TypeCache
 =Structure.Structure_TypeCache;

////////////////////////////////////////////////////////////////////////////////
//using

using TSrcID=ErrSourceID;
using TMsgID=ErrMessageID;

////////////////////////////////////////////////////////////////////////////////
//class ErrResourceUtils

/// <summary>
///  Utilities for work with module resources
/// </summary>
static class ErrResourceUtils
{
 public static string GetSourceName(CultureInfo    culture_info,
                                    TSrcID         src_id)
 {
  Debug.Assert(!Object.ReferenceEquals(sm_Src,null));

  return sm_Src.BuildMessage(culture_info,src_id,null);
 }//GetSourceName

 //-----------------------------------------------------------------------
 public static string BuildMessage(CultureInfo    culture_info,
                                   TMsgID         msg_id,
                                   IList<object>  args)
 {
  Debug.Assert(!Object.ReferenceEquals(sm_Msg,null));

  return sm_Msg.BuildMessage(culture_info,msg_id,args);
 }//BuildMessage

 //-----------------------------------------------------------------------
 public static string FormatMessage(CultureInfo     culture_info,
                                      TMsgID          msg_id,
                                      params object[] args)
 {
  Debug.Assert(!Object.ReferenceEquals(sm_Msg,null));

  return sm_Msg.FormatMessage(culture_info,msg_id,args);
 }//FormatMessage

 //-----------------------------------------------------------------------
 public static resources_lib.StrResourceLoader<TSrcID> GetLoader_for_sources()
 {
  Debug.Assert(!Object.ReferenceEquals(sm_Src,null));

  return sm_Src.GetLoader();
 }//GetLoader_for_sources

 //-----------------------------------------------------------------------
 public static resources_lib.StrResourceLoader<TMsgID> GetLoader_for_messages()
 {
  Debug.Assert(!Object.ReferenceEquals(sm_Msg,null));

  return sm_Msg.GetLoader();
 }//GetLoader_for_messages

 //Helper methods --------------------------------------------------------
 private static void Helper__MsgParamPusher(structure_lib.StringFormatter fmsg,
                                            CultureInfo                   ci,
                                            object                        param)
 {
  Debug.Assert(!Object.ReferenceEquals(fmsg,null));

  if(Object.ReferenceEquals(param,null))
  {
   fmsg.Push("#NULL");

   return;
  }//if

  var param_type=param.GetType();

  if(param_type.Equals(Structure_TypeCache.TypeOf__LcpiEF__ErrSourceID))
   fmsg.Push(sm_Src.FormatMessage(ci,(ErrSourceID)param));
  else
  if(param_type.Equals(Structure_TypeCache.TypeOf__LcpiEF__ErrMessageID))
   fmsg.Push(sm_Msg.FormatMessage(ci,(ErrMessageID)param));
  else
  if(param_type.Equals(Structure_TypeCache.TypeOf__LcpiEF__ExpressionType))
   fmsg.Push(((LcpiOleDb__ExpressionType)param).ToString());
  else
  if(param_type.Equals(Structure_TypeCache.TypeOf__ComLib_HResultCode))
   fmsg.Push(com_lib.HResultUtils.ToHumanName((com_lib.HResultCode)param));
  else
  if(param_type.Equals(Structure_TypeCache.TypeOf__OleDbLib_DBTypeCode))
   fmsg.Push(((oledb_lib.DBTypeCode)param).ToString());
  else
  if(param_type.Equals(Structure_TypeCache.TypeOf__OleDbLib_DBCOLUMNFLAGS))
   fmsg.Push(((oledb_lib.DBCOLUMNFLAGS)param).ToString());
  else
  if(param_type.Equals(Structure_TypeCache.TypeOf__LcpiDataOleDb__OleDbType))
   fmsg.Push(((xdb.OleDbType)param).ToString());
  else
  if(param_type.Equals(Structure_TypeCache.TypeOf__System_Guid))
   fmsg.Push(param.ToString().ToUpper());
  else
  if(param_type.IsAssignableTo(Structure_TypeCache.TypeOf__System_Type))
   fmsg.Push(((System.Type)param).Extension__BuildHumanName());
  else
  if(param_type.Equals(Structure_TypeCache.TypeOf__System_DBNull))
   fmsg.Push("#DBNULL");
  else
  if(param_type.Equals(Structure_TypeCache.TypeOf__System_Version))
   fmsg.Push(param.ToString());
  else
  if(param_type.Equals(Structure_TypeCache.TypeOf__SystemReflection__BindingFlags))
   fmsg.Push(((System.Reflection.BindingFlags)param).ToString());
  else
  if(param_type.Equals(Structure_TypeCache.TypeOf__SystemData_ConnectionState))
   fmsg.Push(((System.Data.ConnectionState)param).ToString());
  else
  if(param_type.Equals(Structure_TypeCache.TypeOf__SystemData_ParameterDirection))
   fmsg.Push(((System.Data.ParameterDirection)param).ToString());
  else
  if(param_type.Equals(Structure_TypeCache.TypeOf__SystemData_DbType))
   fmsg.Push(((System.Data.DbType)param).ToString());
  else
  if(param_type.Equals(Structure_TypeCache.TypeOf__SystemLinqExpressions_ExpressionType))
   fmsg.Push(((System.Linq.Expressions.ExpressionType)param).ToString());
  else
  if(param is System.Reflection.MethodInfo m)
   fmsg.Push(m.Helper__FullName());
  else
  if(param_type.Equals(Structure_TypeCache.TypeOf__System_TimeSpan))
  {
   string timeSpan_s
    =((System.TimeSpan)param).ToString
      ("c",
       System.Globalization.CultureInfo.InvariantCulture);

   fmsg.Push(timeSpan_s);
  }
  else
  if(param_type.Equals(Structure_TypeCache.TypeOf__MS_EFCore_Migrations__ReferentialAction))
   fmsg.Push(((Microsoft.EntityFrameworkCore.Migrations.ReferentialAction)param).ToString());
  else
   fmsg.PushObject(param);
 }//Helper__MsgParamPusher

 //-----------------------------------------------------------------------
 private static string Helper__FullName(this System.Reflection.MethodInfo m)
 {
  Debug.Assert(!Object.ReferenceEquals(m,null));

  return Structure.Structure_ReflectionUtils.BuildMethodSign(m);
 }//Helper__FullName

 //private data ----------------------------------------------------------
 private static readonly resources_lib.MsgResourceBuilder<TSrcID>
  sm_Src=new resources_lib.MsgResourceBuilder<TSrcID>
              (Assembly.GetExecutingAssembly(),
               Resources.ResourceFileID.error_sources,
               Helper__MsgParamPusher);

 private static readonly resources_lib.MsgResourceBuilder<TMsgID>
  sm_Msg=new resources_lib.MsgResourceBuilder<TMsgID>
              (Assembly.GetExecutingAssembly(),
               Resources.ResourceFileID.error_messages,
               Helper__MsgParamPusher);
};//class ErrResourceUtils

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb
