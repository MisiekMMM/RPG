@echo off
setlocal

REM ===== Configuration =====
set RUNTIME=win-x64
set CONFIG=Release

REM ===== Publish =====
dotnet publish ^
  -c %CONFIG% ^
  -r %RUNTIME% ^
  --self-contained true ^
  -p:PublishSingleFile=true ^
  -p:IncludeNativeLibrariesForSelfExtract=true ^
  -p:PublishTrimmed=true ^
  -p:DebugType=None ^
  -p:DebugSymbols=false ^
  -p:StripSymbols=true

IF %ERRORLEVEL% NEQ 0 (
  echo.
  echo ❌ Publish failed
  exit /b %ERRORLEVEL%
)

echo.
echo ✅ Publish completed successfully
echo Output is in:
echo bin\%CONFIG%\*\%RUNTIME%\publish

endlocal
