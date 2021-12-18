@SETLOCAL

cd %~dp0
cd ..

@ECHO "Delete Code\Provider\obj"
@RMDIR /S /Q Code\Provider\obj

@IF NOT %ERRORLEVEL% == 0 GOTO :ERROR

@ECHO "Delete Code\Provider\bin"
@RMDIR /S /Q Code\Provider\bin

@IF NOT %ERRORLEVEL% == 0 GOTO :ERROR

@ECHO "Delete Tests\General\obj"
@RMDIR /S /Q Tests\General\obj

@IF NOT %ERRORLEVEL% == 0 GOTO :ERROR

@ECHO "Delete Tests\General\bin"
@RMDIR /S /Q Tests\General\bin

@IF NOT %ERRORLEVEL% == 0 GOTO :ERROR

@rem ECHO "Delete .vs"
@rem RMDIR /S /Q .vs

@IF NOT %ERRORLEVEL% == 0 GOTO :ERROR

@ECHO "Delete _output"
@RMDIR /S /Q _output

@IF NOT %ERRORLEVEL% == 0 GOTO :ERROR

@rem ------------------------------------------- DONE
@GOTO :EXIT

@rem ------------------------------------------- ERROR
:ERROR
@ECHO ERROR!
@GOTO :EXIT_WITH_ERROR

@rem ------------------------------------------- EXIT

:EXIT

@ECHO EXIT FROM CLEAN

@ENDLOCAL

@EXIT /B %ERRORLEVEL%

@rem ------------------------------------------- EXIT_WITH_ERROR

:EXIT_WITH_ERROR

@ECHO EXIT FROM CLEAN

@ENDLOCAL

@EXIT /B 999

@rem ------------------------------------------- EOF
:EOF
