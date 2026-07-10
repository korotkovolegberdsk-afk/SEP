@echo off
title Pack SEP Source

echo ==========================================
echo Creating source archive...
echo ==========================================

if exist SEP_Source.zip del SEP_Source.zip

powershell Compress-Archive ^
-Path ^
SEP.Core, ^
SEP.Database, ^
SEP.Import, ^
SEP.Library, ^
SEP.Viewer, ^
database, ^
docs, ^
drawings, ^
samples, ^
tests, ^
build, ^
.gitignore, ^
.gitattributes, ^
README.md, ^
ROADMAP.md, ^
VERSION.txt, ^
SEP.sln ^
-DestinationPath SEP_Source.zip

echo.
echo Archive created:
echo.
echo SEP_Source.zip

pause