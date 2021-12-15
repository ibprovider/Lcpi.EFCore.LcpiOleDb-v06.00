////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.09.2018.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__String__Substring___startIndex__length

static class Method_Code__String__Substring___startIndex__length
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Method_Code__String__Substring___startIndex__length;

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__String__Substring___startIndex__length)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 //! \todo
 //!  What about support nullable startIndex and length?
 private static String Exec(String obj,
                            Int32  startIndex,
                            Int32  length)
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
  }//if startIndex<0

  Debug.Assert(startIndex>=0);

  if(length<0)
  {
   //ERROR - negative length

   ThrowSysError.argument_out_of_range___negative_value
    (c_ErrSrcID,
     nameof(Exec),
     nameof(length),
     length);

   Debug.Assert(false);
  }//if  length<0

  Debug.Assert(length>=0);

  if(Object.ReferenceEquals(obj,null))
   return null;

  //----------------------------------------
  int processedChars=0;

  int offset1=0;

  try
  {
   offset1
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

  Debug.Assert(offset1>=0);
  Debug.Assert(offset1<=obj.Length);

  Debug.Assert(processedChars<=startIndex);

  if(offset1==obj.Length)
   return string.Empty;

  Debug.Assert(offset1<obj.Length);

  //----------------------------------------
  int processedChars2=0;

  int offset2=0;

  try
  {
   offset2
    =Structure.Structure_CS_UTF16.GetOffset
      (obj,
       /*initialOffset*/offset1,
       length,
       out processedChars2);
  }
  catch(Exception e)
  {
   ThrowError.FailedToProcessValue
    (c_ErrSrcID,
     "obj",
     e); //throw!

   Debug.Assert(false);
  }//catch

  Debug.Assert(offset1<obj.Length);

  Debug.Assert(offset2>=offset1);
  Debug.Assert(offset2<=obj.Length);

  Debug.Assert(processedChars2<=length);

  return obj.Substring(offset1,offset2-offset1);
 }//Helper__Code__String_Substring__startIndex_length
};//class Method_Code__String__Substring___startIndex__length

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code
