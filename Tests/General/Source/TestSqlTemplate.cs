////////////////////////////////////////////////////////////////////////////////
//NUnit tests for "EF Core Provider for LCPI OLE DB"
//                                      IBProvider and Contributors. 08.12.2020.
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

using xdb=lcpi.data.oledb;

using xEFCore=Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb;

namespace EFCore_LcpiOleDb_Tests.General{
////////////////////////////////////////////////////////////////////////////////
//class TestSqlTemplate

sealed class TestSqlTemplate
{
 public TestSqlTemplate()
 {
  m_Parent=null;

  m_Parts=new List<tagPartData>();
 }//TestSqlTemplate

 //-----------------------------------------------------------------------
 public TestSqlTemplate(TestSqlTemplate pParent)
 {
  m_Parent=pParent;

  m_Parts=new List<tagPartData>();
 }//TestSqlTemplate

 //interface -------------------------------------------------------------
 public TestSqlTemplate PUSH()
 {
  var x=new TestSqlTemplate(this);

  m_Parts.Add(new tagPartData(x));

  return x;
 }//PUSH

 //-----------------------------------------------------------------------
 public TestSqlTemplate POP()
 {
  Debug.Assert(!Object.ReferenceEquals(m_Parent,null));

  return m_Parent;
 }//POP

 //-----------------------------------------------------------------------
 public TestSqlTemplate T(TestSqlTemplate data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(data));

  return this;
 }//T

 //-----------------------------------------------------------------------
 public TestSqlTemplate T(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Text,data));

  return this;
 }//T

 //-----------------------------------------------------------------------
 public TestSqlTemplate N(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Name,data));

  return this;
 }//N

 //-----------------------------------------------------------------------
 public TestSqlTemplate N(string part1,string part2)
 {
  Debug.Assert(!Object.ReferenceEquals(part1,null));
  Debug.Assert(!Object.ReferenceEquals(part2,null));

  this.N(part1);
  this.T(".");
  this.N(part2);

  return this;
 }//N - part1, part2

 //-----------------------------------------------------------------------
 public TestSqlTemplate N_AS_VCH(string part1,string part2,int n)
 {
  Debug.Assert(!Object.ReferenceEquals(part1,null));
  Debug.Assert(!Object.ReferenceEquals(part2,null));

  this.T("CAST(");
  this.N(part1);
  this.T(".");
  this.N(part2);
  this.T(" AS VARCHAR("+n+"))");

  return this;
 }//N_AS_VCH

 //-----------------------------------------------------------------------
 public TestSqlTemplate N_AS_INT(string part1,string part2)
 {
  Debug.Assert(!Object.ReferenceEquals(part1,null));
  Debug.Assert(!Object.ReferenceEquals(part2,null));

  this.T("CAST(");
  this.N(part1);
  this.T(".");
  this.N(part2);
  this.T(" AS INTEGER)");

  return this;
 }//N_AS_INT

 //-----------------------------------------------------------------------
 public TestSqlTemplate N_AS_DBL(string part1,string part2)
 {
  Debug.Assert(!Object.ReferenceEquals(part1,null));
  Debug.Assert(!Object.ReferenceEquals(part2,null));

  this.T("CAST(");
  this.N(part1);
  this.T(".");
  this.N(part2);
  this.T(" AS DOUBLE PRECISION)");

  return this;
 }//N_AS_DBL

 //-----------------------------------------------------------------------
 public TestSqlTemplate N_AS_FLT(string part1,string part2)
 {
  Debug.Assert(!Object.ReferenceEquals(part1,null));
  Debug.Assert(!Object.ReferenceEquals(part2,null));

  this.T("CAST(");
  this.N(part1);
  this.T(".");
  this.N(part2);
  this.T(" AS FLOAT)");

  return this;
 }//N_AS_FLT

 //-----------------------------------------------------------------------
 public TestSqlTemplate N_AS_TS(string part1,string part2)
 {
  Debug.Assert(!Object.ReferenceEquals(part1,null));
  Debug.Assert(!Object.ReferenceEquals(part2,null));

  this.T("CAST(");
  this.N(part1);
  this.T(".");
  this.N(part2);
  this.T(" AS TIMESTAMP)");

  return this;
 }//N_AS_TS

 //-----------------------------------------------------------------------
 public TestSqlTemplate N_AS_TM(string part1,string part2)
 {
  Debug.Assert(!Object.ReferenceEquals(part1,null));
  Debug.Assert(!Object.ReferenceEquals(part2,null));

  this.T("CAST(");
  this.N(part1);
  this.T(".");
  this.N(part2);
  this.T(" AS TIME)");

  return this;
 }//N_AS_TM

 //-----------------------------------------------------------------------
 public TestSqlTemplate N_TXT_NP(string part1,string part2)
 {
  Debug.Assert(!Object.ReferenceEquals(part1,null));
  Debug.Assert(!Object.ReferenceEquals(part2,null));

  this.T("COALESCE(");
  this.N(part1);
  this.T(".");
  this.N(part2);
  this.T(", _utf8 '')");

  return this;
 }//N_TXT_NP - part1, part2

 //-----------------------------------------------------------------------
 public TestSqlTemplate N_I4_VALUE(string part1,string part2)
 {
  Debug.Assert(!Object.ReferenceEquals(part1,null));
  Debug.Assert(!Object.ReferenceEquals(part2,null));

  this.T("COALESCE(");
  this.N(part1);
  this.T(".");
  this.N(part2);
  this.T(", CAST(_utf8 'TRAP FOR NULL' AS INTEGER))");

  return this;
 }//N_I4_VALUE - part1, part2

 //-----------------------------------------------------------------------
 public TestSqlTemplate N_DEC_VALUE(string part1,string part2)
 {
  Debug.Assert(!Object.ReferenceEquals(part1,null));
  Debug.Assert(!Object.ReferenceEquals(part2,null));

  this.T("COALESCE(");
  this.N(part1);
  this.T(".");
  this.N(part2);
  this.T(", CAST(_utf8 'TRAP FOR NULL' AS DECIMAL))");

  return this;
 }//N_DEC_VALUE - part1, part2

 //-----------------------------------------------------------------------
 public TestSqlTemplate P(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Parameter,data,tagParamType.NONE));

  return this;
 }//P

 //-----------------------------------------------------------------------
 public TestSqlTemplate P_TIMESPAN(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Parameter,data,tagParamType.TIMESPAN));

  return this;
 }//P_TIMESPAN

 //-----------------------------------------------------------------------
 public TestSqlTemplate P_ID(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Parameter,data,tagParamType.I8));

  return this;
 }//P_ID

 //-----------------------------------------------------------------------
 public TestSqlTemplate P_I2(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Parameter,data,tagParamType.I2));

  return this;
 }//P_I2

 //-----------------------------------------------------------------------
 public TestSqlTemplate P_I4(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Parameter,data,tagParamType.I4));

  return this;
 }//P_I4

 //-----------------------------------------------------------------------
 public TestSqlTemplate P_I8(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Parameter,data,tagParamType.I8));

  return this;
 }//P_I8

 //-----------------------------------------------------------------------
 public TestSqlTemplate P_NUM(string data,
                              int    precision,
                              int    scale)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add
    (new tagPartData
      (tagPartType.Parameter,
       data,
       tagParamType.NUM,
       precision,
       scale));

  return this;
 }//P_I2

 //-----------------------------------------------------------------------
 public TestSqlTemplate P_R4(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Parameter,data,tagParamType.R4));

  return this;
 }//P_R4

 //-----------------------------------------------------------------------
 public TestSqlTemplate P_R8(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Parameter,data,tagParamType.R8));

  return this;
 }//P_R8

 //-----------------------------------------------------------------------
 public TestSqlTemplate P_TXT(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Parameter,data,tagParamType.TXT));

  return this;
 }//P_TXT

 //-----------------------------------------------------------------------
 public TestSqlTemplate P_BIN(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Parameter,data,tagParamType.BIN));

  return this;
 }//P_BIN

 //-----------------------------------------------------------------------
 public TestSqlTemplate P_BOOL(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Parameter,data,tagParamType.BOOL));

  return this;
 }//P_BOOL

 //-----------------------------------------------------------------------
 public TestSqlTemplate P_TS(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Parameter,data,tagParamType.TS));

  return this;
 }//P_TS

 //-----------------------------------------------------------------------
 public TestSqlTemplate P_TM(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Parameter,data,tagParamType.TM));

  return this;
 }//P_TM

 //-----------------------------------------------------------------------
 public TestSqlTemplate P_DE(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Parameter,data,tagParamType.DE));

  return this;
 }//P_DE

 //-----------------------------------------------------------------------
 public TestSqlTemplate P_CH1(string data)
 {
  Debug.Assert(!Object.ReferenceEquals(data,null));

  m_Parts.Add(new tagPartData(tagPartType.Parameter,data,tagParamType.CH1));

  return this;
 }//P_CH1

 //-----------------------------------------------------------------------
 public TestSqlTemplate EOL()
 {
  return this.T("\n");
 }//EOL

 //-----------------------------------------------------------------------
 public TestSqlTemplate CRLF()
 {
  return this.T("\r\n");
 }//CRLF

 //-----------------------------------------------------------------------
 public TestSqlTemplate W_BRKTS()
 {
  m_Parts.Insert(0,new tagPartData(tagPartType.Text,"("));

  m_Parts.Add(new tagPartData(tagPartType.Text,")"));

  return this;
 }//W_BRKTS

 //-----------------------------------------------------------------------
 public TestSqlTemplate W_CastAsDBL()
 {
  m_Parts.Insert(0,new tagPartData(tagPartType.Text,"CAST("));

  m_Parts.Add(new tagPartData(tagPartType.Text," AS DOUBLE PRECISION)"));

  return this;
 }//W_CastAsDBL

 //-----------------------------------------------------------------------
 public TestSqlTemplate W_Trunc_CastAs(string sqlTypeName)
 {
  m_Parts.Insert(0,new tagPartData(tagPartType.Text,"CAST(TRUNC("));

  m_Parts.Add(new tagPartData(tagPartType.Text,") AS "+sqlTypeName+")"));

  return this;
 }//W_Trunc_CastAs

 //-----------------------------------------------------------------------
 public TestSqlTemplate W_Trunc_CastAsSMALLINT()
 {
  return W_Trunc_CastAs("SMALLINT");
 }//W_Trunc_CastAsSMALLINT

 //-----------------------------------------------------------------------
 public TestSqlTemplate W_Trunc_CastAsINTEGER()
 {
  return W_Trunc_CastAs("INTEGER");
 }//W_Trunc_CastAsINTEGER

 //-----------------------------------------------------------------------
 public TestSqlTemplate W_CastAsVCH(int n)
 {
  m_Parts.Insert(0,new tagPartData(tagPartType.Text,"CAST("));

  m_Parts.Add(new tagPartData(tagPartType.Text," AS VARCHAR("+n+"))"));

  return this;
 }//W_CastAsVCH

 //-----------------------------------------------------------------------
 public TestSqlTemplate IS_NULL()
 {
  this.T(" IS NULL");

  return this;
 }//IS_NULL

 //-----------------------------------------------------------------------
 public TestSqlTemplate IS_NOT_NULL()
 {
  this.T(" IS NOT NULL");

  return this;
 }//IS_NOT_NULL

 //-----------------------------------------------------------------------
 public string BuildSql(xdb.OleDbConnection cn)
 {
  Debug.Assert(!Object.ReferenceEquals(cn,null));

  var ds=cn.GetSchema(xdb.OleDbMetaDataCollectionNames.DataSourceInformation);

  var ds_row=ds.Rows[0];

  string dsProp__ParamPrefix
   =(string)ds_row[xdb.OleDbMetaDataCollectionColumnNames.DataSourceInformation.LCPI_ParameterPrefix];

  var sb=new StringBuilder();

  foreach(var part in m_Parts)
  {
   switch(part.Type)
   {
    case tagPartType.Template:
    {
     sb.Append(part.Template.BuildSql(cn));
     break;
    }//case Template

    case tagPartType.Text:
    {
     sb.Append(part.Data);
     break;
    }//case Text

    case tagPartType.Name:
    {
     sb.Append(xdb.OleDbCommandBuilder.QuoteObjectNamePart(part.Data,cn));
     break;
    }//case Name

    case tagPartType.Parameter:
    {
     if(part.ParamType==tagParamType.NONE)
     {
      sb.Append(dsProp__ParamPrefix);
      sb.Append(part.Data);
     }
     else
     {
      sb.Append("CAST(");
      sb.Append(dsProp__ParamPrefix);
      sb.Append(part.Data);
      sb.Append(" AS ");

      string type;

      if(Helper__TryGetParamMutableSqlTypeName(ds,part,out type))
      {
       //OK
      }
      else
      if(sm_FbParamTypes.TryGetValue(part.ParamType,out type))
      {
       //OK
      }
      else
      {
       throw new ApplicationException("UNKNOWN PARAMETER TYPE ID: "+part.ParamType+".");
      }//else

      sb.Append(type);
      sb.Append(")");
     }//else

     break;
    }//case Param_I2

    default:
    {
     var msg=string.Format("Unknown TestSqlTemplate part type: {0}.",part.Type);

     throw new ApplicationException(msg);
    }//default
   }//switch Type
  }//foreach part

  return sb.ToString();
 }//BuildSql

 //private types ---------------------------------------------------------
 private enum tagPartType
 {
  Template  =1,
  Text      =2,
  Name      =3,
  Parameter =4,
 };//enum tagPartType

 //-----------------------------------------------------------------------
 private enum tagParamType
 {
  NONE        =0,
  I2          =10,
  I4          =11,
  I8          =12,
  R4          =13,
  R8          =14,
  DE          =15,
  TM          =16,
  TS          =17,
  TXT         =18,
  BIN         =19,
  BOOL        =20,
  CH1         =21,
  NUM         =22,
  TIMESPAN    =23,
 };//enum tagParamType

 //-----------------------------------------------------------------------
 private struct tagPartData
 {
  public readonly tagPartType     Type;

  public readonly TestSqlTemplate Template;

  public readonly string          Data;

  public readonly tagParamType    ParamType;

  public readonly int?            Precision;

  public readonly int?            Scale;

  //------------------------------------------------------------
  public tagPartData(TestSqlTemplate template)
  {
   Debug.Assert(!Object.ReferenceEquals(template,null));

   this.Type     =tagPartType.Template;
   this.Template =template;
   this.Data     =null;
   this.ParamType=tagParamType.NONE;
   this.Precision=null;
   this.Scale    =null;
  }//tagPartData

  //------------------------------------------------------------
  public tagPartData(tagPartType type,
                     string      data)
  {
   Debug.Assert(!Object.ReferenceEquals(data,null));

   //Use another constructor
   Debug.Assert(type!=tagPartType.Parameter);

   this.Type     =type;
   this.Template =null;
   this.Data     =data;
   this.ParamType=tagParamType.NONE;
   this.Precision=null;
   this.Scale    =null;
  }//tagPartData

  //------------------------------------------------------------
  public tagPartData(tagPartType  type,
                     string       data,
                     tagParamType paramType)
  {
   Debug.Assert(!Object.ReferenceEquals(data,null));

   this.Type     =type;
   this.Template =null;
   this.Data     =data;
   this.ParamType=paramType;
   this.Precision=null;
   this.Scale    =null;
  }//tagPartData

  //------------------------------------------------------------
  public tagPartData(tagPartType  type,
                     string       data,
                     tagParamType paramType,
                     int          precision,
                     int          scale)
  {
   Debug.Assert(!Object.ReferenceEquals(data,null));

   this.Type     =type;
   this.Template =null;
   this.Data     =data;
   this.ParamType=paramType;
   this.Precision=precision;
   this.Scale    =scale;
  }//tagPartData
 };//struct tagPartData

 //-----------------------------------------------------------------------
 private sealed class tagFbParamTypes:Dictionary<tagParamType,string>
 {
  public new tagFbParamTypes Add(tagParamType id,string text)
  {
   Debug.Assert(!this.ContainsKey(id));

   base.Add(id,text);

   return this;
  }//Add
 };//class tagFbParamTypes

 //Helper methods --------------------------------------------------------
 private static bool Helper__TryGetParamMutableSqlTypeName
                                           (System.Data.DataTable dsInfo,
                                            tagPartData           paramData,
                                            out string            sqlTypeName)
 {
  sqlTypeName=null;

  if(paramData.ParamType==tagParamType.NUM)
  {
   sqlTypeName="NUMERIC";

   if(paramData.Precision.HasValue)
   {
    sqlTypeName+="(";
    sqlTypeName+=paramData.Precision;

    if(paramData.Scale.HasValue)
    {
     sqlTypeName+=",";
     sqlTypeName+=paramData.Scale;
    }

    sqlTypeName+=")";
   }

   return true;
  }//if

  if(paramData.ParamType==tagParamType.I8)
  {
   int connectionDialect
    =(int)dsInfo.Rows[0][xdb.OleDbMetaDataCollectionColumnNames.DataSourceInformation.ISC.ConnectionDialect];

   switch(connectionDialect)
   {
    case 1:
     sqlTypeName=xEFCore.Basement.EF.Dbms.Firebird.V03_0_0.FB_V03_0_0__Consts.c_TypeOf_BIGINT_D1;
     break;

    default:
     sqlTypeName="BIGINT";
     break;
   }//switch

   return true;
  }//if - I8

  if(paramData.ParamType==tagParamType.TIMESPAN)
  {
   int connectionDialect
    =(int)dsInfo.Rows[0][xdb.OleDbMetaDataCollectionColumnNames.DataSourceInformation.ISC.ConnectionDialect];

   switch(connectionDialect)
   {
    case 1:
     sqlTypeName=xEFCore.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__TimeSpan__as_Decimal9_4.DatabaseStoreType;
     break;

    default:
     sqlTypeName=xEFCore.Basement.EF.Dbms.Firebird.Common.Storage.Mapping.FB_Common__TypeMapping__TimeSpan__as_Decimal18_4.DatabaseStoreType;
     break;
   }//switch

   return true;
  }//if - TIMESPAN

  return false;
 }//Helper__TryGetParamMutableSqlTypeName

 //private data ----------------------------------------------------------
 private readonly TestSqlTemplate m_Parent;

 private readonly List<tagPartData> m_Parts;

 //-----------------------------------------------------------------------
 private static readonly tagFbParamTypes sm_FbParamTypes
  =new tagFbParamTypes()
   .Add(tagParamType.I2  ,"SMALLINT")
   .Add(tagParamType.I4  ,"INTEGER")
   //.Add(tagParamType.I8  ,"BIGINT")
   .Add(tagParamType.R4  ,"FLOAT")
   .Add(tagParamType.R8  ,"DOUBLE PRECISION")
   .Add(tagParamType.TS  ,"TIMESTAMP")
   .Add(tagParamType.TM  ,"TIME")
   .Add(tagParamType.DE  ,"DATE")
   .Add(tagParamType.TXT ,"BLOB SUB_TYPE TEXT CHARACTER SET UTF8")
   .Add(tagParamType.BIN ,"BLOB SUB_TYPE BINARY")
   .Add(tagParamType.BOOL,"BOOLEAN")
   .Add(tagParamType.CH1 ,"CHAR(1) CHARACTER SET UTF8")
   ;
};//class TestSqlTemplate

////////////////////////////////////////////////////////////////////////////////
}//namespace EFCore_LcpiOleDb_Tests.General
