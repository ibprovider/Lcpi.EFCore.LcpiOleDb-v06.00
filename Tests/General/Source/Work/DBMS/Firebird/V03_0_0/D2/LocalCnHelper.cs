////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 27.01.2021.
using System;
using System.Diagnostics;

using xdb=lcpi.data.oledb;

namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2{
////////////////////////////////////////////////////////////////////////////////
//class LocalCnHelper

static class LocalCnHelper
{
 public static xdb.OleDbConnection CreateCn()
 {
  return CreateCn((string)null);
 }//CreateCn

 //-----------------------------------------------------------------------
 public static xdb.OleDbConnection CreateCn__UTF8()
 {
  return CreateCn("ctype=UTF8");
 }//CreateCn__UTF8

 //-----------------------------------------------------------------------
 public static xdb.OleDbConnection CreateCn(string ExCnParams)
 {
  var cnsb=new xdb.OleDbConnectionStringBuilder(TestServices.Conf__GetCnStr());

  //----------------------------------------
  if(!Object.ReferenceEquals(ExCnParams,null))
  {
   var ex=new lcpi.lib.structure.ParameterList(ExCnParams);

   for(int i=0;i!=ex.Size();++i)
   {
    var p=ex[i];

    cnsb[p.Name]=p.Value;
   }//for
  }//if

  //----------------------------------------
  cnsb["dialect"]=2;

  return new xdb.OleDbConnection(cnsb.ConnectionString);
 }//CreateCn
};//class LocalCnHelper

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General.Work.DBMS.Firebird.V03_0_0.D2
