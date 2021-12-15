////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 21.09.2021.
using System;
using System.Diagnostics;
using System.Reflection;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb{
////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__Extensions__MethodInfo

static class LcpiOleDb__Extensions__MethodInfo
{
 public static System.Object Extension__InvokeWithTransparentHandlingOfException
                                           (this MethodInfo methodInfo,
                                            System.Object   instance,
                                            System.Object[] parameters)
 {
  Debug.Assert(!Object.ReferenceEquals(methodInfo,null));
  Debug.Assert(!Object.ReferenceEquals(parameters,null));

  System.Object invokeResult;

  try
  {
   invokeResult
    =methodInfo
      .Invoke
        (instance,
         parameters);
  }
  catch(System.Reflection.TargetInvocationException e)
  {
   if(Object.ReferenceEquals(e.InnerException,null))
    throw;

   throw e.InnerException;
  }//catch

  return invokeResult;
 }//Extension__InvokeWithTransparentHandlingOfException
};//class LcpiOleDb__Extensions__MethodInfo

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb
