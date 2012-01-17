[System.Reflection.Assembly]::LoadWithPartialName("Lapointe.PowerShell.MamlGenerator.dll")
Get-ChildItem *.xml | Remove-Item
[Lapointe.PowerShell.MamlGenerator.CmdletHelpGenerator]::GenerateHelp((Get-ChildItem .\vPowerModule.dll).Fullname, (Get-Location), $true)
Get-ChildItem *.xml | Rename-Item -force -newname { $_.name -replace ".cmdlets"}