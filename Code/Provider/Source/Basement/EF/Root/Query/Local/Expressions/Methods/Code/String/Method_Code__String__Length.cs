////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 27.09.2018.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code{
////////////////////////////////////////////////////////////////////////////////
//class Method_Code__String__Length

static class Method_Code__String__Length
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.Root_Query_Local_Expressions__Method_Code__String__Length;

 //-----------------------------------------------------------------------
 public static readonly System.Reflection.MethodInfo
  MethodInfo
   =typeof(Method_Code__String__Length)
     .GetTypeInfo()
     .GetDeclaredMethod(nameof(Exec));

 //-----------------------------------------------------------------------
 private static Nullable<Int32> Exec(String obj)
 {
  if(Object.ReferenceEquals(obj,null))
   return null;

  int cch=0;

  try
  {
   cch=Structure.Structure_CS_UTF16.GetCharCount(obj); //catch
  }
  catch(Exception e)
  {
   ThrowError.FailedToProcessValue
    (c_ErrSrcID,
     "obj",
     e); //throw!

   Debug.Assert(false);
  }//catch

  Debug.Assert(cch>=0);
  Debug.Assert(cch<=obj.Length);

  return cch;
 }//Exec
};//class Method_Code__String__Length

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local.Expressions.Methods.Code
