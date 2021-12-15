////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.09.2018.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__String__Substring___startIndex

static class Method_Code__String__Substring___startIndex
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Method_Code__String__Substring___startIndex;

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__String__Substring___startIndex)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static String Exec(String obj,Int32 startIndex)
 {
  if(startIndex<0)
  {
   //ERROR - negative startIndex

   ThrowSysError.argument_out_of_range___negative_value
    (c_ErrSrcID,
     nameof(Exec),
     nameof(startIndex),
     startIndex);

   Debug.Assert(false);
  }//if

  Debug.Assert(startIndex>=0);

  //----------------------------------------
  if(Object.ReferenceEquals(obj,null))
   return null;

  int processedChars=0;

  int offset=0;

  try
  {
   offset
    =Structure.Structure_CS_UTF16.GetOffset
     (obj,
      /*initialOffset*/0,
      startIndex,
      out processedChars); //throw
  }
  catch(Exception e)
  {
   ThrowError.FailedToProcessValue
    (c_ErrSrcID,
     "obj",
     e); //throw!

   Debug.Assert(false);
  }//catch

  Debug.Assert(offset>=0);
  Debug.Assert(offset<=obj.Length);

  Debug.Assert(processedChars<=startIndex);

  if(offset==obj.Length)
   return string.Empty;

  Debug.Assert(offset<obj.Length);

  return obj.Substring(offset);
 }//Helper__Code__String_Substring__startIndex
};//class Method_Code__String__Substring___startIndex

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code
