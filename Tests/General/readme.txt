General tests for Lcpi.EntityFrameWork.DataProvider.LcpiOleDb

2020-11-26

+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

[Run tests]

Executable:

c:\Program Files (x86)\Microsoft Visual Studio\2019\Preview\Common7\IDE\Extensions\TestPlatform\vstest.console.exe

Arguments:

Lcpi.EntityFrameworkCore.DataProvider.LcpiOleDb.Tests.General-net5_0_0.dll /Parallel /logger:trx;LogFileName=test.trx /TestCaseFilter:FullyQualifiedName~Operators&(FullyQualifiedName~DateTime|FullyQualifiedName~TimeSpan)

/TestCaseFilter:FullyQualifiedName~NotEqual&FullyQualifiedName~Complete2__objs

++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

[REGEXP]

HAS "recs=db"
NOT HAS "object"

^(?!.*object).*recs=db.*$
