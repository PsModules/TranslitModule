#
# Script module for module 'PSScriptAnalyzer'
#
Set-StrictMode -Version Latest

 $VerbosePreference = "continue"

# Set up some helper variables to make it easier to work with the module
$PSModule = $ExecutionContext.SessionState.Module
$PSModuleRoot = $PSModule.ModuleBase

# Import the appropriate nested binary module based on the current PowerShell version
$binaryModuleRoot = Join-Path $PSModuleRoot 'bin'


if (($PSVersionTable.Keys -contains "PSEdition") -and ($PSVersionTable.PSEdition -ne 'Desktop')) {
    $binaryModuleRoot = Join-Path -Path $binaryModuleRoot -ChildPath 'coreclr'
}
else
{
    if ($PSVersionTable.PSVersion -lt [Version]'5.0')
    {
        $binaryModuleRoot = Join-Path -Path $binaryModuleRoot -ChildPath 'v3'
    }
    else{
        $binaryModuleRoot = Join-Path -Path $binaryModuleRoot -ChildPath 'dotnet'
    }
}


Write-Verbose "Binary module Dir: $binaryModuleRoot"

$binaryModulePath = Join-Path -Path $binaryModuleRoot -ChildPath 'TranslitModule.dll'

$dependencies = Get-ChildItem -Path $binaryModuleRoot -Exclude $binaryModulePath

$loadedAssemblies = @()

Foreach ($dll in $dependencies)
{
    $loadedAssemblies += Import-Module -Name $dll -PassThru
}

$loadedAssemblies += Import-Module -Name $binaryModulePath -PassThru

Write-Verbose "Loaded Assemblies: $loadedAssemblies"

# When the module is unloaded, remove the nested binary module that was loaded with it
$PSModule.OnRemove = {
    [array]::Reverse($loadedAssemblies)
    Foreach ($dll in $loadedAssemblies)
    {
        Write-Verbose "Removing Assembly: $dll"
        Remove-Module -ModuleInfo $dll
    }    
}

Set-Alias untranslit ConvertFrom-LatinTransliteration
Set-Alias translit ConvertTo-LatinTransliteration 

Export-ModuleMember -Cmdlet ConvertFrom-LatinTransliteration, ConvertTo-LatinTransliteration -Alias untranslit, translit

