////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB. Core. Engines. Dbms. Firebird.
//                                      IBProvider and Contributors. 20.02.2021.
using System;
using System.Diagnostics;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Helpers{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_StrHelpers
 =Structure.Structure_StrHelpers;

////////////////////////////////////////////////////////////////////////////////
//class Convert_Helper__Utils__ProcessDigit

static class Convert_Helper__Utils__ProcessDigit
{
 public static bool Exec(string  strValue,
                         int     iStart,
                         int     iEnd,
                         int     minWidth,
                         int     maxWidth,
                         int     minValue,
                         int     maxValue,
                         out int resultValue)
 {
  Debug.Assert(!Object.ReferenceEquals(strValue,null));

  Debug.Assert(iStart<iEnd);

  Debug.Assert(iStart>=0);
  Debug.Assert(iEnd<=strValue.Length);

  Debug.Assert(0<minWidth);
  Debug.Assert(minWidth<=maxWidth);

  resultValue=0;

  int width=(iEnd-iStart);

  Debug.Assert(width>0);

  if(width<minWidth)
  {
   //bad format - conversion error.

   return false;
  }//if

  if(maxWidth<width)
  {
   //bad format - conversion error.

   return false;
  }//if

  int tmpValue=0;

  for(int i=iStart;i!=iEnd;++i)
  {
   Debug.Assert(Structure_StrHelpers.IsDigit(strValue[i]));

   tmpValue=tmpValue*10;

   tmpValue=tmpValue+(strValue[i]-'0');
  }//for i

  if(tmpValue<minValue)
  {
   return false;
  }//if

  if(maxValue<tmpValue)
  {
   return false;
  }//if

  resultValue=tmpValue;

  return true;
 }//Exec
};//Convert_Helper__Utils__ProcessDigit

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Core.Engines.Dbms.Firebird.Common.Mirror.Value.Converts.Helpers
