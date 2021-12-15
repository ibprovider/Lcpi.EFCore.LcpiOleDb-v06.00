////////////////////////////////////////////////////////////////////////////////
//EF Core Provider for LCPI OLE DB.
//                                      IBProvider and Contributors. 30.11.2021.
using System;
using System.Diagnostics;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Storage{
////////////////////////////////////////////////////////////////////////////////
//class FB_V03_0_0__SqlGenerationHelper

sealed class FB_V03_0_0__SqlGenerationHelper
 :ISqlGenerationHelper
{
 private const ErrSourceID
  c_ErrSrcID
   =ErrSourceID.FB_V03_0_0__SqlGenerationHelper;

 //-----------------------------------------------------------------------
 public FB_V03_0_0__SqlGenerationHelper(Core.Core_ConnectionOptions cnOptions)
 {
  Debug.Assert(!Object.ReferenceEquals(cnOptions,null));

  //---------------------
#if TRACE
  Core.Core_Trace.Method
   ("FB_V03_0_0__SqlGenerationHelper::FB_V03_0_0__SqlGenerationHelper({0})",
    cnOptions);
#endif

  //---------------------
  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(FB_V03_0_0__SqlGenerationHelper),
    nameof(cnOptions),
    cnOptions);

  //---------------------
  m_EngineSvc__ObjectIdentifierBuilder
   =Core.Core_SvcUtils.QuerySvc<Core.Engines.EngineSvc__ObjectIdentifierBuilder>
     (cnOptions,
      Core.Engines.EngineSvcID.EngineSvc__ObjectIdentifierBuilder);

  Debug.Assert(!Object.ReferenceEquals(m_EngineSvc__ObjectIdentifierBuilder,null));

  //---------------------
  m_EngineSvc__CommandParameterNameBuilder
   =Core.Core_SvcUtils.QuerySvc<Core.Engines.EngineSvc__CommandParameterNameBuilder>
     (cnOptions,
      Core.Engines.EngineSvcID.EngineSvc__CommandParameterNameBuilder);

  Debug.Assert(!Object.ReferenceEquals(m_EngineSvc__CommandParameterNameBuilder,null));
 }//FB_V03_0_0__SqlGenerationHelper

 //ISqlGenerationHelper interface ----------------------------------------
 string ISqlGenerationHelper.StatementTerminator
 {
  get
  {
   return c_StatementTerminator;
  }
 }//StatementTerminator

 //-----------------------------------------------------------------------
 string ISqlGenerationHelper.BatchTerminator
 {
  get
  {
   return Environment.NewLine;
  }
 }//BatchTerminator

 //-----------------------------------------------------------------------
 string ISqlGenerationHelper.StartTransactionStatement
 {
  get
  {
   return "SET TRANSACTION"+c_StatementTerminator;
  }
 }//StartTransactionStatement

 //-----------------------------------------------------------------------
 string ISqlGenerationHelper.CommitTransactionStatement
 {
  get
  {
   return "COMMIT"+c_StatementTerminator;
  }
 }//CommitTransactionStatement

 //-----------------------------------------------------------------------
 string ISqlGenerationHelper.SingleLineCommentToken
 {
  get
  {
   return c_SingleLineCommentToken;
  }
 }//SingleLineCommentToken

 //-----------------------------------------------------------------------
 string ISqlGenerationHelper.DelimitIdentifier(string identifier)
 {
  Debug.Assert(!Object.ReferenceEquals(m_EngineSvc__ObjectIdentifierBuilder,null));

#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_V03_0_0__SqlGenerationHelper::DelimitIdentifier({0})",
    identifier);
#endif

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ISqlGenerationHelper.DelimitIdentifier),
    nameof(identifier),
    identifier);

  var r
   =m_EngineSvc__ObjectIdentifierBuilder.QuoteIdentifier
     (identifier);

#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_V03_0_0__SqlGenerationHelper::DelimitIdentifier({0}) - {1}",
    identifier,
    r);
#endif

  return r;
 }//DelimitIdentifier

 //-----------------------------------------------------------------------
 void ISqlGenerationHelper.DelimitIdentifier(StringBuilder builder,
                                             string        identifier)
 {
  Debug.Assert(!Object.ReferenceEquals(m_EngineSvc__ObjectIdentifierBuilder,null));

#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_V03_0_0__SqlGenerationHelper::DelimitIdentifier({0},{1})",
    builder,
    identifier);
#endif

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ISqlGenerationHelper.DelimitIdentifier),
    nameof(builder),
    builder);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ISqlGenerationHelper.DelimitIdentifier),
    nameof(identifier),
    identifier);

  m_EngineSvc__ObjectIdentifierBuilder.QuoteIdentifier
   (builder,
    identifier);

#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_V03_0_0__SqlGenerationHelper::DelimitIdentifier({0},{1})",
    builder,
    identifier);
#endif
 }//DelimitIdentifier

 //-----------------------------------------------------------------------
 string ISqlGenerationHelper.DelimitIdentifier(string name,
                                               string schema)
 {
  Debug.Assert(!Object.ReferenceEquals(m_EngineSvc__ObjectIdentifierBuilder,null));

#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_V03_0_0__SqlGenerationHelper::DelimitIdentifier({0},{1})",
    name,
    schema);
#endif

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ISqlGenerationHelper.DelimitIdentifier),
    nameof(name),
    name);

  if(!Object.ReferenceEquals(schema,null))
  {
   ThrowError.DbmsErr__FB__FirebirdDoesNotSupportSchemas
    (c_ErrSrcID);
  }//if

  var r
   =m_EngineSvc__ObjectIdentifierBuilder.QuoteIdentifier
    (name);

#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_V03_0_0__SqlGenerationHelper::DelimitIdentifier({0},{1}) - {2}",
    name,
    schema,
    r);
#endif

  return r;
 }//DelimitIdentifier - name, schema

 //-----------------------------------------------------------------------
 void ISqlGenerationHelper.DelimitIdentifier(StringBuilder builder,
                                             string        name,
                                             string        schema)
 {
  Debug.Assert(!Object.ReferenceEquals(m_EngineSvc__ObjectIdentifierBuilder,null));

#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_V03_0_0__SqlGenerationHelper::DelimitIdentifier({0},{1},{2})",
    builder,
    name,
    schema);
#endif

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ISqlGenerationHelper.DelimitIdentifier),
    nameof(builder),
    builder);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ISqlGenerationHelper.DelimitIdentifier),
    nameof(name),
    name);

  if(!Object.ReferenceEquals(schema,null))
  {
   ThrowError.DbmsErr__FB__FirebirdDoesNotSupportSchemas
    (c_ErrSrcID);
  }//if

  m_EngineSvc__ObjectIdentifierBuilder.QuoteIdentifier
   (builder,
    name);

#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_V03_0_0__SqlGenerationHelper::DelimitIdentifier({0},{1},{2})",
    builder,
    name,
    schema);
#endif
 }//DelimitIdentifier - builder, name, schema

 //-----------------------------------------------------------------------
 string ISqlGenerationHelper.GenerateParameterName
                                           (string name)
 {
  Debug.Assert(!Object.ReferenceEquals(m_EngineSvc__CommandParameterNameBuilder,null));

#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_V03_0_0__SqlGenerationHelper::GenerateParameterName({0})",
    name);
#endif

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ISqlGenerationHelper.GenerateParameterName),
    nameof(name),
    name);

  var r
   =m_EngineSvc__CommandParameterNameBuilder.GenParameterName
     (name);

#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_V03_0_0__SqlGenerationHelper::GenerateParameterName({0}) - {1}",
    name,
    r);
#endif

  return r;
 }//GenerateParameterName

 //-----------------------------------------------------------------------
 void ISqlGenerationHelper.GenerateParameterName
                                           (StringBuilder builder,
                                            string        name)
 {
  Debug.Assert(!Object.ReferenceEquals(m_EngineSvc__CommandParameterNameBuilder,null));

#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_V03_0_0__SqlGenerationHelper::GenerateParameterName({0},{1})",
    builder,
    name);
#endif

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ISqlGenerationHelper.GenerateParameterName),
    nameof(builder),
    builder);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ISqlGenerationHelper.GenerateParameterName),
    nameof(name),
    name);

  m_EngineSvc__CommandParameterNameBuilder.GenParameterName
   (builder,
    name);

#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_V03_0_0__SqlGenerationHelper::GenerateParameterName({0},{1})",
    builder,
    name);
#endif
 }//GenerateParameterName

 //-----------------------------------------------------------------------
 string ISqlGenerationHelper.GenerateParameterNamePlaceholder
                                           (string name)
 {
  Debug.Assert(!Object.ReferenceEquals(m_EngineSvc__CommandParameterNameBuilder,null));

#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_V03_0_0__SqlGenerationHelper::GenerateParameterNamePlaceholder({0})",
    name);
#endif

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ISqlGenerationHelper.GenerateParameterNamePlaceholder),
    nameof(name),
    name);

  var r
   =m_EngineSvc__CommandParameterNameBuilder.GenParameterMarker
     (name);

#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_V03_0_0__SqlGenerationHelper::GenerateParameterNamePlaceholder({0}) - {1}",
    name,
    r);
#endif

  return r;
 }//GenerateParameterNamePlaceholder

 //-----------------------------------------------------------------------
 void ISqlGenerationHelper.GenerateParameterNamePlaceholder
                                           (StringBuilder builder,
                                            string        name)
 {
  Debug.Assert(!Object.ReferenceEquals(m_EngineSvc__CommandParameterNameBuilder,null));

#if TRACE
  Core.Core_Trace.Method_Enter
   ("FB_V03_0_0__SqlGenerationHelper::GenerateParameterNamePlaceholder({0},{1})",
    builder,
    name);
#endif

  Check.Arg_NotNull
   (c_ErrSrcID,
    nameof(ISqlGenerationHelper.GenerateParameterNamePlaceholder),
    nameof(builder),
    builder);

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ISqlGenerationHelper.GenerateParameterNamePlaceholder),
    nameof(name),
    name);

  m_EngineSvc__CommandParameterNameBuilder.GenParameterMarker
   (builder,
    name);

#if TRACE
  Core.Core_Trace.Method_Exit
   ("FB_V03_0_0__SqlGenerationHelper::GenerateParameterNamePlaceholder({0},{1})",
    builder,
    name);
#endif
 }//GenerateParameterNamePlaceholder

 //-----------------------------------------------------------------------
 string ISqlGenerationHelper.GenerateComment(string text)
 {
  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ISqlGenerationHelper.GenerateComment),
    nameof(text),
    text);

  var builder=new StringBuilder();

  using(var reader=new System.IO.StringReader(text))
  {
   for(;;)
   {
    string line=reader.ReadLine();

    if(Object.ReferenceEquals(line,null))
     break;

    builder.Append(c_SingleLineCommentToken).Append(' ').AppendLine(line);
   }//for[ever]
  }//using

  return builder.ToString();
 }//GenerateComment

 //-----------------------------------------------------------------------
 string ISqlGenerationHelper.GenerateCreateSavepointStatement(string name)
 {
  Debug.Assert(!Object.ReferenceEquals(m_EngineSvc__ObjectIdentifierBuilder,null));

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ISqlGenerationHelper.GenerateCreateSavepointStatement),
    nameof(name),
    name);

  var r
   ="SAVEPOINT "
   +m_EngineSvc__ObjectIdentifierBuilder.QuoteIdentifier(name)
   +c_StatementTerminator;

  return r;
 }//GenerateCreateSavepointStatement

 //-----------------------------------------------------------------------
 string ISqlGenerationHelper.GenerateRollbackToSavepointStatement(string name)
 {
  Debug.Assert(!Object.ReferenceEquals(m_EngineSvc__ObjectIdentifierBuilder,null));

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ISqlGenerationHelper.GenerateCreateSavepointStatement),
    nameof(name),
    name);

  var r
   ="ROLLBACK TO "
   +m_EngineSvc__ObjectIdentifierBuilder.QuoteIdentifier(name)
   +c_StatementTerminator;

  return r;
 }//GenerateRollbackToSavepointStatement

 //-----------------------------------------------------------------------
 string ISqlGenerationHelper.GenerateReleaseSavepointStatement(string name)
 {
  Debug.Assert(!Object.ReferenceEquals(m_EngineSvc__ObjectIdentifierBuilder,null));

  Check.Arg_NotNullAndNotEmpty
   (c_ErrSrcID,
    nameof(ISqlGenerationHelper.GenerateCreateSavepointStatement),
    nameof(name),
    name);

  var r
   ="RELEASE SAVEPOINT "
   +m_EngineSvc__ObjectIdentifierBuilder.QuoteIdentifier(name)
   +c_StatementTerminator;

  return r;
 }//GenerateReleaseSavepointStatement

 //private data ----------------------------------------------------------
 private const string c_StatementTerminator
  =";";

 private const string c_SingleLineCommentToken
  ="--";

 private readonly Core.Engines.EngineSvc__ObjectIdentifierBuilder
  m_EngineSvc__ObjectIdentifierBuilder; //Not null

 private readonly Core.Engines.EngineSvc__CommandParameterNameBuilder
  m_EngineSvc__CommandParameterNameBuilder; //Not null
};//class FB_V03_0_0__SqlGenerationHelper

////////////////////////////////////////////////////////////////////////////////
}//namespace Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Basement.EF.Dbms.Firebird.V03_0_0.Storage
