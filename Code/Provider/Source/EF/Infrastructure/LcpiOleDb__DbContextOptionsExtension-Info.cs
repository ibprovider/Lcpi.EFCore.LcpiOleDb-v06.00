////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 14.10.2020.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;

using Microsoft.EntityFrameworkCore.Infrastructure;

using com_lib=lcpi.lib.com;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Infrastructure{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__DbContextOptionsExtension

public sealed partial class LcpiOleDb__DbContextOptionsExtension
{
 /// <summary>
 ///  Complete implementation of RelationalExtensionInfo class
 /// </summary>
 //! Implements:
 //! - PopulateDebugInfo
 //! - GetServiceProviderHashCode
 private sealed class tagExtensionInfo:RelationalExtensionInfo
 {
  private const ErrSourceID
   c_ErrSrcID
    =ErrSourceID.LcpiOleDb__DbContextOptionsExtension_tagExtensionInfo;

  //----------------------------------------------------------------------
  /// <summary>
  ///  Constructor
  /// </summary>
  //! \param[in] OptionsExtension
  //!  Not null.
  public tagExtensionInfo(LcpiOleDb__DbContextOptionsExtension OptionsExtension)
   :base(OptionsExtension)
  {
   Debug.Assert(!Object.ReferenceEquals(OptionsExtension,null));

#if TRACE
   Core.Core_Trace.Method
    ("LcpiOleDb__DbContextOptionsExtension::tagExtensionInfo::tagExtensionInfo(...)");
#endif

   Debug.Assert(this.IsDatabaseProvider);

   //------
   Debug.Assert(!m_ServiceProviderHashCode.HasValue);

   Debug.Assert(Object.ReferenceEquals(m_Data__ConnectionString,null));
  }//tagExtensionInfo

  //DbContextOptionsExtensionInfo interface ------------------------------
  public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
  {
   Debug.Assert(!Object.ReferenceEquals(debugInfo,null));

#if TRACE
   Core.Core_Trace.Method
    ("LcpiOleDb__DbContextOptionsExtension::tagExtensionInfo::PopulateDebugInfo(...)");
#endif

   Check.Arg_NotNull
    (c_ErrSrcID,
     nameof(PopulateDebugInfo),
     nameof(debugInfo),
     debugInfo);

   debugInfo["LcpiOleDb"]="1";
  }//PopulateDebugInfo

  //----------------------------------------------------------------------
  public override int GetServiceProviderHashCode()
  {
#if TRACE
   Core.Core_Trace.Method
    ("LcpiOleDb__DbContextOptionsExtension::tagExtensionInfo::GetServiceProviderHashCode()");
#endif

   if(!m_ServiceProviderHashCode.HasValue)
   {
    m_ServiceProviderHashCode=this.Helper__BuildServiceProviderHashCode();
   }//if

   Debug.Assert(m_ServiceProviderHashCode.HasValue);

   return m_ServiceProviderHashCode.Value;
  }//GetServiceProviderHashCode

  //Helper methods -------------------------------------------------------
  private int Helper__BuildServiceProviderHashCode()
  {
   const string c_bugcheck_src
    ="tagExtensionInfo::Helper__BuildServiceProviderHashCode";

   //------------------------------------------------------
   var parentExtension
    =Check.BugCheck_Value_NotNullAndInstanceOf<LcpiOleDb__DbContextOptionsExtension,RelationalOptionsExtension>
      (c_ErrSrcID,
       c_bugcheck_src,
       "#001",
       "base.Extension",
       this.Extension);

   //------------------------------------------------------
   int result
    =HashCode.Combine
      (base.GetServiceProviderHashCode(),
       this.Helper__GetConnectionString(),
       parentExtension.m_ExecutionOfUnknownMethods);

   return result;
  }//Helper__BuildServiceProviderHashCode

  //----------------------------------------------------------------------
  private string Helper__GetConnectionString()
  {
   if(!Object.ReferenceEquals(m_Data__ConnectionString,null))
    return m_Data__ConnectionString;

   string result=null;

   if(!Object.ReferenceEquals(this.Extension.Connection,null))
   {
    result=this.Extension.Connection.ConnectionString;

    if(string.IsNullOrEmpty(result))
    {
     var exc=new LcpiOleDb__DataToolException
              (com_lib.HResultCode.E_FAIL,
               c_ErrSrcID,
               ErrMessageID.common_err__connection_object_contains_empty_connection_string_0);

     exc.raise();
    }//if
   }
   else
   if(!string.IsNullOrEmpty(this.Extension.ConnectionString))
   {
    result=this.Extension.ConnectionString;
   }
   else
   {
    var exc=new LcpiOleDb__DataToolException
             (com_lib.HResultCode.E_FAIL,
              c_ErrSrcID,
              ErrMessageID.common_err__failed_to_read_connection_properties_0);

    exc.raise();
   }//else

   Debug.Assert(!string.IsNullOrEmpty(result));

   Interlocked.CompareExchange
    (ref m_Data__ConnectionString,
     result,
     null);

   Debug.Assert(!Object.ReferenceEquals(m_Data__ConnectionString,null));

   return m_Data__ConnectionString;
  }//Helper__GetConnectionString

  //private data ---------------------------------------------------------
  private Nullable<int> m_ServiceProviderHashCode;

  private string m_Data__ConnectionString;
 };//class tagExtensionInfo
};//class LcpiOleDb__DbContextOptionsExtension

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Infrastructure
