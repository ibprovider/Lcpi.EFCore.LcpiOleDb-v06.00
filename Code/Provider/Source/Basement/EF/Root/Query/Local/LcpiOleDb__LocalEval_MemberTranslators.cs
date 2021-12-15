////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 04.10.2018.
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local{
////////////////////////////////////////////////////////////////////////////////
//using

using Structure_MemberId
 =Structure.Structure_MemberId;

////////////////////////////////////////////////////////////////////////////////
//class LcpiOleDb__LocalEval_MemberTranslators

sealed class LcpiOleDb__LocalEval_MemberTranslators
 :Dictionary<Structure_MemberId,LcpiOleDb__LocalEval_MemberTranslator>
{
 public LcpiOleDb__LocalEval_MemberTranslators Add(LcpiOleDb__LocalEval_MemberTranslator x)
 {
  Debug.Assert(!Object.ReferenceEquals(x,null));
  Debug.Assert(!Object.ReferenceEquals(x.MemberId,null));

  Debug.Assert(!base.ContainsKey(x.MemberId));

  base.Add(x.MemberId,x);

  return this;
 }//Add
};//class LcpiOleDb__LocalEval_MemberTranslators

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Root.Query.Local
