////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 26.01.2021.

//------------------------------------------------------------------------
#if   BUILD_CONF__NET5_0_0
// CER is deprecated
//# define LOCAL_BUILD_CONF__Use_CER
#elif BUILD_CONF__NET6_0_0
// CER is deprecated
//# define LOCAL_BUILD_CONF__Use_CER
#else
# error "Unexpected Target Platform!"
#endif

//------------------------------------------------------------------------
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

#if LOCAL_BUILD_CONF__Use_CER
using System.Runtime.CompilerServices;
#endif

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Helpers{
////////////////////////////////////////////////////////////////////////////////
//class Convert_Helper__DOUBLE__STRING

/// <summary>
///  Translation of double/float to string by Firebird v3 rule.
/// </summary>
///
///  This function uses external code - __stdio_common_vswprintf from ucrtbase.dll.
///
///  This allow to build the exact result string.
///
///  double.Format("g16") may return the another result.
///
///  Example.
///
///  Source digit: 9.2233720368548086e+18
///
///  Firebird translates to       "9.223372036854808e+18"
///  Format("g16") translates to  "9.223372036854809e+18"

static class Convert_Helper__DOUBLE__STRING
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Core_Engines_Dbms_FB_Common_Mirror__Convert_Helper__DOUBLE__STRING;

 //-----------------------------------------------------------------------
 public static System.String Exec(System.Double v,
                                  int           precision)
 {
  Debug.Assert(precision>0);
  Debug.Assert(precision<=18); //max

  //--------------------------
  if(double.IsNaN(v))
   return "nan(ind)";

  if(double.IsNegativeInfinity(v))
   return "-inf";

  if(double.IsPositiveInfinity(v))
   return "inf";

  //--------------------------
  Debug.Assert(!Object.ReferenceEquals(ConvertConfig.CvtCulture,null));

  var r=Helper__BuildRawStr(v,precision);

  Debug.Assert(!string.IsNullOrEmpty(r));

  Debug.Assert(!r.Contains('E'));

  var iE=r.IndexOf('e');

  if(iE>=0)
  {
   Debug.Assert(iE>=1);
   Debug.Assert(iE<r.Length);

   var iP=r.IndexOf('.',0,iE);

   if(iP==-1)
   {
    r=r.Substring(0,iE)+"."+r.Substring(iE);

    //++iP;
    ++iE;
   }//if

   int n=precision+1;

   if(v<0)
    ++n;

   if(iE<n)
   {
    r=r.Substring(0,iE)+new string('0',n-iE)+r.Substring(iE);
   }//if

   return r;
  }//if iE>=0

  Debug.Assert(iE==-1);

  {
   int n=precision+1;

   //
   // [2021-02-27] It is problem with DEBUG build of server
   //
   // if(v==0)
   //  ++n;    // additional '0' for zero value
   // else
   if(v<0)
    ++n;

   if(!r.Contains('.'))
    r+=".";

   if(r.Length<n)
    r=r+new string('0',n-r.Length);

   Debug.Assert(!string.IsNullOrEmpty(r));

   return r;
  }//local
 }//Exec

 //-----------------------------------------------------------------------
 private static string Helper__BuildRawStr(System.Double v,
                                           int           precision)
 {
  Debug.Assert(precision>0);
  Debug.Assert(precision<=18); //max

  //--------------------------
  const string c_bugcheck_src
   ="Convert_Helper__DOUBLE__STRING::Helper__BuildRawStr";

  //--------------------------
  const uint c_cchBuffer=128;

  //--------------------------
  string rawStr;

  Debug.Assert(sizeof(char)==2);

  using(var mem=new lcpi.lib.win32.MemoryBuffer(sizeof(char)*c_cchBuffer))
  {
   bool lockFlag=false;

#if LOCAL_BUILD_CONF__Use_CER
   RuntimeHelpers.PrepareConstrainedRegions();            //-------------- CER
#endif

   try // [finally]
   {
    mem.DangerousAddRef(ref lockFlag);

    if(!lockFlag)
    {
     ThrowBugCheck.generic_error
      (c_ErrSrcID,
       c_bugcheck_src,
       "#001",
       "Failed to lock memory buffer");
    }//if

    Debug.Assert(lockFlag);

    Debug.Assert(mem.DangerousGetHandle()!=IntPtr.Zero);

    //-----------
    var args
     =new tagVA_ARGS3 //in stack, fixed in memory
       (/*width*/23,
        precision,
        v);

    //-----------
    var r
     =__stdio_common_vswprintf___for_double
        (_CRT_options,
         mem.DangerousGetHandle(),
         (IntPtr)c_cchBuffer,
         "%- #*.*g",
         IntPtr.Zero,
         ref args);

    if(r<0)
    {
     ThrowBugCheck.generic_error
      (c_ErrSrcID,
       c_bugcheck_src,
       "#002",
       "Failed to translate a double to string");
    }//if r

    if(!(r<c_cchBuffer))
    {
     ThrowBugCheck.generic_error
      (c_ErrSrcID,
       c_bugcheck_src,
       "#003",
       "Too large result from __stdio_common_vswprintf: "+r);
    }//if

    Debug.Assert(r<c_cchBuffer);

    rawStr=Marshal.PtrToStringUni(mem.DangerousGetHandle(),r);
   }
   finally
   {
    if(lockFlag)
    {
     mem.DangerousRelease();
    }//if
   }//finally                                             //--------------/CER
  }//using mem

  var rawStr2=rawStr.Trim();

  return rawStr2;
 }//Helper__BuildRawStr

 //-----------------------------------------------------------------------
 //
 // [2021-04-02] Data from my local computer.
 //
 private const int _CRT_INTERNAL_LOCAL_PRINTF_OPTIONS              =36;
 private const int _CRT_INTERNAL_PRINTF_STANDARD_SNPRINTF_BEHAVIOR =2;

 //-----------------------------------------------------------------------
 private const ulong _CRT_options
  = _CRT_INTERNAL_LOCAL_PRINTF_OPTIONS
   |_CRT_INTERNAL_PRINTF_STANDARD_SNPRINTF_BEHAVIOR;

 //-----------------------------------------------------------------------
  [StructLayout(LayoutKind.Sequential)]
  private struct tagVA_ARGS3
  {
   public System.IntPtr arg1;
   public System.IntPtr arg2;
   public System.Double arg3;

   public tagVA_ARGS3(System.Int32  width,
                      System.Int32  precision,
                      System.Double value)
   {
    this.arg1 =new System.IntPtr(width);
    this.arg2 =new System.IntPtr(precision);
    this.arg3 =value;
   }//tagVA_ARGS3
  };//struct tagVA_ARGS3

 //-----------------------------------------------------------------------
  //  _Success_(return >= 0)
  //  _Check_return_opt_
  //  _ACRTIMP int __cdecl __stdio_common_vswprintf(
  //      _In_                                    unsigned __int64 _Options,
  //      _Out_writes_opt_z_(_BufferCount)        wchar_t*         _Buffer,
  //      _In_                                    size_t           _BufferCount,
  //      _In_z_ _Printf_format_string_params_(2) wchar_t const*   _Format,
  //      _In_opt_                                _locale_t        _Locale,     //pointer
  //                                              va_list          _ArgList
  //      );

 [DllImport("ucrtbase.dll",
  EntryPoint = "__stdio_common_vswprintf",
  CharSet=CharSet.Unicode,
  CallingConvention=CallingConvention.Cdecl,
  PreserveSig=true)]
 private static extern int __stdio_common_vswprintf___for_double
                              (System.UInt64       options,
                               System.IntPtr       buffer,
                               System.IntPtr       bufferSize,
                               System.String       format,
                               System.IntPtr       locale,
                               ref tagVA_ARGS3     args);
};//class Convert_Helper__DOUBLE__STRING

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Helpers
