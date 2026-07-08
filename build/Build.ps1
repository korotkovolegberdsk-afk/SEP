Clear-Host

Write-Host ""
Write-Host "======================================" -ForegroundColor Cyan
Write-Host " SEP Build System" -ForegroundColor Green
Write-Host "======================================" -ForegroundColor Cyan
Write-Host ""

Set-Location "$PSScriptRoot\.."

$Version = Get-Content VERSION.txt

Write-Host "Version : $Version"
Write-Host ""

dotnet build SEP.sln -c Release

Write-Host ""
Write-Host "======================================" -ForegroundColor Cyan
Write-Host " BUILD FINISHED" -ForegroundColor Green
Write-Host "======================================" -ForegroundColor Cyan
Write-Host ""

Read-Host "Press ENTER"