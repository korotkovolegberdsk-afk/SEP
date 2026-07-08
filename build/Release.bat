@echo off
title SEP Release

cd /d "%~dp0.."

set /p VERSION=<VERSION.txt

echo.
echo ===============================
echo Building SEP %VERSION%
echo ===============================

dotnet clean SEP.sln

dotnet build SEP.sln -c Release

if not exist Release mkdir Release

if exist Release\SEP_%VERSION% rmdir /S /Q Release\SEP_%VERSION%

mkdir Release\SEP_%VERSION%

xcopy /E /I /Y SEP.Viewer\bin\Release\net8.0-windows Release\SEP_%VERSION%

echo.
echo ===============================
echo RELEASE READY
echo ===============================
echo.
echo Release\SEP_%VERSION%

pause