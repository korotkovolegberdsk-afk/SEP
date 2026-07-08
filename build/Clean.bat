@echo off
title SEP Clean

echo ===========================
echo Cleaning SEP...
echo ===========================

cd /d "%~dp0.."

dotnet clean SEP.sln

echo.
echo ===========================
echo CLEAN FINISHED
echo ===========================

pause