@SETLOCAL

@cd %~dp0

@call helper-clean.cmd

@cd ..

@IF NOT %ERRORLEVEL% == 0 GOTO :ERROR

@rem -------------------------------------------
@SET OUTPUT_DIR__MY=.\_Output\

@rem ------------------------------------------- VS2022

@SET VS170COMNTOOLS__MY=c:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\

@IF NOT EXIST "%VS170COMNTOOLS__MY%" goto :no_VS170COMNTOOLS

@SETLOCAL

@call "%VS170COMNTOOLS__MY%..\..\vc\Auxiliary\Build\vcvarsamd64_x86.bat"

@SET CURRENT_SOLUTION_FILE=%1

@IF ERRORLEVEL 1 GOTO :ERROR_compile

msbuild %CURRENT_SOLUTION_FILE% /restore /t:Rebuild /p:Configuration=Debug /p:Platform="Any CPU" /fileLogger /fileLoggerParameters:LogFile=%OUTPUT_DIR__MY%\logs\vs2022-debug-1-build.log

@IF ERRORLEVEL 1 GOTO :ERROR_compile

msbuild %CURRENT_SOLUTION_FILE% /restore /t:Rebuild /p:Configuration=Release /p:Platform="Any CPU" /fileLogger /fileLoggerParameters:LogFile=%OUTPUT_DIR__MY%\logs\vs2022-release-1-build.log

@IF ERRORLEVEL 1 GOTO :ERROR_compile

msbuild %CURRENT_SOLUTION_FILE% /t:pack /p:Configuration=Release /p:Platform="Any CPU" /fileLogger /fileLoggerParameters:LogFile=%OUTPUT_DIR__MY%\logs\vs2022-release-2-pack.log

@IF ERRORLEVEL 1 GOTO :ERROR_compile

@ENDLOCAL

@rem ------------------------------------------- COPY TO _OUTPUT
@ECHO "Copy Tests\General to %OUTPUT_DIR__MY%"
@XCOPY Tests\General\bin %OUTPUT_DIR__MY%\binaries\Tests-General /E /I
@IF NOT %ERRORLEVEL% == 0 GOTO :ERROR

@ECHO "Copy Code\Provider to %OUTPUT_DIR__MY%"
@XCOPY Code\Provider\bin %OUTPUT_DIR__MY%\binaries\Code-Provider /E /I
@IF NOT %ERRORLEVEL% == 0 GOTO :ERROR

@ECHO "Make %OUTPUT_DIR__MY%\nuget"
@MKDIR %OUTPUT_DIR__MY%\nuget
@IF NOT %ERRORLEVEL% == 0 GOTO :ERROR

@ECHO "Moving NUPKG packages into %OUTPUT_DIR__MY%nuget"
FOR /R %OUTPUT_DIR__MY%binaries %%a IN (.) DO @IF EXIST %%a\*.nupkg @MOVE %%a\*.nupkg %OUTPUT_DIR__MY%nuget\
@IF NOT %ERRORLEVEL% == 0 GOTO :ERROR

@ECHO "Moving SNUPKG packages into %OUTPUT_DIR__MY%nuget"
@FOR /R %OUTPUT_DIR__MY%binaries %%a IN (.) DO @IF EXIST %%a\*.snupkg @MOVE %%a\*.snupkg %OUTPUT_DIR__MY%nuget\
@IF NOT %ERRORLEVEL% == 0 GOTO :ERROR

@rem ------------------------------------------- DONE
@GOTO :EXIT

@rem ------------------------------------------- ERRORS

:no_VS170COMNTOOLS
@echo ERROR: VS2022 CE is not installed.
@goto :EXIT_WITH_ERROR

:ERROR_compile
@ENDLOCAL
@echo ERROR: Failed to compile
@goto :EXIT_WITH_ERROR

:ERROR_compile_boot_app_msgs
@POPD
@echo ERROR: Failed to compile boot_app message tables
@goto :EXIT_WITH_ERROR

:ERROR
@ECHO ERROR!
@GOTO :EXIT_WITH_ERROR

@rem ------------------------------------------- EXIT

:EXIT

@ECHO EXIT

@ENDLOCAL

@EXIT /B %ERRORLEVEL%

@rem ------------------------------------------- EXIT_WITH_ERROR

:EXIT_WITH_ERROR

@ECHO EXIT

@ENDLOCAL

@EXIT /B 999

@rem ------------------------------------------- EOF
:EOF
