////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core.
//                                      IBProvider and Contributors. 07.09.2018.
using System;
using System.Diagnostics;

using structure_lib=lcpi.lib.structure;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core{
////////////////////////////////////////////////////////////////////////////////
//class Core_Trace

#if TRACE

static class Core_Trace
{
 public static void Send(string s)
 {
  Helper__Send(string.Empty,s);
 }//Send

 //-----------------------------------------------------------------------
 public static void Send(string s,params object[] args)
 {
  string x=string.Format(s,args);

  Helper__Send(string.Empty,x);
 }//Send

 //-----------------------------------------------------------------------
 public static void Method(string s,params object[] args)
 {
  string x=string.Format(s,Helper__WrapArgs(args));

  Helper__Send(string.Empty,x);
 }//Method

 //-----------------------------------------------------------------------
 public static void Method_Err(string s,params object[] args)
 {
  string x=string.Format(s,Helper__WrapArgs(args));

  Helper__Send("ERROR: ",x);
 }//Method_Err

 //-----------------------------------------------------------------------
 public static void Method_Exc(Exception       e,
                               string          s,
                               params object[] args)
 {
  Debug.Assert(!Object.ReferenceEquals(e,null));
  Debug.Assert(!Object.ReferenceEquals(s,null));

  string x=string.Format(s,Helper__WrapArgs(args));

  var e_src=structure_lib.StringUtils.ValueOrDefault(e.Source,"<No SRC>");
  var e_msg=structure_lib.StringUtils.ValueOrDefault(e.Message,"<No MSG>");

  x=string.Format("{0} | {1} - {2}",
                  x,
                  e_src,
                  e_msg);

  Helper__Send("EXCEPTION: ",x);
 }//Method_Exc

 //-----------------------------------------------------------------------
 public static void Method_Enter(string s,params object[] args)
 {
  string x=string.Format(s,Helper__WrapArgs(args));

  Helper__Send("IN : ",x);
 }//Method_Enter

 //-----------------------------------------------------------------------
 public static void Method_Exit(string s,params object[] args)
 {
  string x=string.Format(s,Helper__WrapArgs(args));

  Helper__Send("OUT: ",x);
 }//Method_Exit

 //-----------------------------------------------------------------------
 public static object WrapUnkArg(object a)
 {
  return structure_lib.TraceMsgBuilderUtils.WrapUnkArg(a);
 }//WrapUnkArg

 //-----------------------------------------------------------------------
 private static void Helper__Send(string prefix,string s)
 {
  lock(sm_guard)
  {
   string msg=string.Format("EF_LCPI_OLEDB [{0:D7}] {1}{2}",++sm_num,prefix,s);

   Trace.WriteLine(msg);
  }//lock
 }//Send

 //-----------------------------------------------------------------------
 private static object[] Helper__WrapArgs(object[] args)
 {
  if(Object.ReferenceEquals(args,null))
   return args;

  var _c=args.Length;

  Debug.Assert(_c>=0);

  var resultArray=new object[_c];

  for(int i=0;i!=_c;++i)
  {
   resultArray[i]=WrapUnkArg(args[i]);
  }//for i

  return resultArray;
 }//Helper__WrapArgs

 //-----------------------------------------------------------------------
 private static readonly object sm_guard=new object();

 private static int sm_num=0;
};//class Core_Trace

#endif // TRACE

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core
