#
# Module manifest for module ''
#
# Generated by: Dima Stadub
#
# Generated on: 28.04.20
#

@{

# Script module or binary module file associated with this manifest.
RootModule = 'TranslitModule.psm1'

# Version number of this module.
ModuleVersion = '0.1.0'

# Supported PSEditions
CompatiblePSEditions = 'Desktop', 'Core'

# ID used to uniquely identify this module
GUID = 'd926d983-26c3-4879-8dc8-b6c2e0e28346'

# Author of this module
Author = 'Dima Stadub'

# Company or vendor of this module
CompanyName = 'LeSofto'

# Copyright statement for this module
Copyright = '(c) Dima Stadub. All rights reserved.'

# Description of the functionality provided by this module
Description = 'Cyrillic/Latin text transliteration'

# Minimum version of the PowerShell engine required by this module
PowerShellVersion = '4.0'

# Name of the PowerShell host required by this module
# PowerShellHostName = ''

# Minimum version of the PowerShell host required by this module
# PowerShellHostVersion = ''

# Minimum version of Microsoft .NET Framework required by this module. This prerequisite is valid for the PowerShell Desktop edition only.
# DotNetFrameworkVersion = ''

# Minimum version of the common language runtime (CLR) required by this module. This prerequisite is valid for the PowerShell Desktop edition only.
# CLRVersion = ''

# Processor architecture (None, X86, Amd64) required by this module
# ProcessorArchitecture = ''

# Modules that must be imported into the global environment prior to importing this module
# RequiredModules = @()

# Assemblies that must be loaded prior to importing this module
# RequiredAssemblies = @()
RequiredAssemblies = @('bin\NickBuhro.Translit.dll')

# Script files (.ps1) that are run in the caller's environment prior to importing this module.
# ScriptsToProcess = @()

# Type files (.ps1xml) to be loaded when importing this module
# TypesToProcess = @()

# Format files (.ps1xml) to be loaded when importing this module
# FormatsToProcess = @()

# Modules to import as nested modules of the module specified in RootModule/ModuleToProcess
NestedModules = @('bin\TranslitModule.dll')

# Functions to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no functions to export.
FunctionsToExport = @('ConvertTo-LatinTransliteration','ConvertFrom-LatinTransliteration')

# Cmdlets to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no cmdlets to export.
CmdletsToExport = @()

# Variables to export from this module
VariablesToExport = '*'

# Aliases to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no aliases to export.
AliasesToExport = @('*')

# DSC resources to export from this module
# DscResourcesToExport = @()

# List of all modules packaged with this module
# ModuleList = @()

# List of all files packaged with this module
# FileList = @()

# Private data to pass to the module specified in RootModule/ModuleToProcess. This may also contain a PSData hashtable with additional module metadata used by PowerShell.
PrivateData = @{

    PSData = @{

        # Tags applied to this module. These help with module discovery in online galleries.
		Tags = @('transliteration','translit','cyrillic','latin')

        # A URL to the license for this module.
        LicenseUri = 'http://opensource.org/licenses/MIT'

        # A URL to the main website for this project.
        ProjectUri = 'https://github.com/PsModules/TranslitModule'

        # A URL to an icon representing this module.
        IconUri = 'hhttps://github.com/PsModules/TranslitModule/blob/master/Assets/Icon.ico'

        # ReleaseNotes of this module
        ReleaseNotes = '
        *Initial version
		* Change some letter behaviour
        '

        # Prerelease string of this module
        # Prerelease = ''

        # Flag to indicate whether the module requires explicit user acceptance for install/update/save
        RequireLicenseAcceptance = $false

        # External dependent modules of this module
        # ExternalModuleDependencies = @()

    } # End of PSData hashtable

} # End of PrivateData hashtable

# HelpInfo URI of this module
# HelpInfoURI = 'https://github.com/PsModules/TranslitModule/blob/master/README.md'

# Default prefix for commands exported from this module. Override the default prefix using Import-Module -Prefix.
# DefaultCommandPrefix = ''

}

