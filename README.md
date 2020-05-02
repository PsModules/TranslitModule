# TranslitModule - Cyrillic/Latin text transliteration

The module is based on Transliteration Nuget Library [![NuGet Badge](https://buildstats.info/nuget/NickBuhro.Translit)](https://www.nuget.org/packages/NickBuhro.Translit/)

[![PowerShell 3](https://Stadub-Gh.visualstudio.com/PowershellScripts/_apis/build/status/TranslitModule?branchName=master)](https://Stadub-Gh.visualstudio.com/PowershellBinary/_build/latest?definitionId=3?branchName=master)
[![PowerShell 4, 5 & Core on Windows build](https://ci.appveyor.com/api/projects/status/7tmg8wy30ipanjsd?svg=true)](https://ci.appveyor.com/project/stadub/PowershellBinary)
[![Linux & MacOS build](https://img.shields.io/travis/stadub/PowershellBinary/master.svg?label=linux/macos+build)](https://travis-ci.org/stadub/PowershellBinary)
[![latest version](https://img.shields.io/powershellgallery/v/TranslitModule.svg?label=latest+version)](https://www.powershellgallery.com/packages/TranslitModule/)
[![downloads](https://img.shields.io/powershellgallery/dt/TranslitModule.svg?label=downloads)](https://www.powershellgallery.com/packages/TranslitModule)

<!-- [Documentation](https://powershellscripts.readthedocs.io/en/latest/) -->

![ConsoleDemo](https://raw.githubusercontent.com/PsModules/TranslitModule/master/Assets/demo.gif)

## Instalation

Powershell Gallery:

[![https://www.powershellgallery.com/packages/TranslitModuel/](https://img.shields.io/badge/PowerShell%20Gallery-download-blue.svg?style=popout&logo=powershell)](https://www.powershellgallery.com/packages/Bookmarks/)

`PowerShellGet` Installation :

```powershell
Install-Module -Name TranslitModule
```

Direct download instalation:

```powershell
iex ('$module="TranslitModule"'+(new-object net.webclient).DownloadString('https://raw.githubusercontent.com/stadub/PowershellBinary/master/install.ps1'))
```

Module import:

```powershell
Import-Module TranslitModule
```

# Commands


```powershell

ConvertTo-LatinTransliteration - Convert cyrillic text to latin
  [-Text] <string>
  [-Language] (Optional) Slavic translit language [if not set - system language is used] 
  

ConvertFrom-LatinTransliteration  - Convert latin-cyrillic text to cyrillic
  [-Text] <string>
  [-Language] (Optional) Slavic translit language [if not set - system language is used] 
  
```

## Aliases

| Cmdlet                           | Alias      |
| ---------------------------------|:----------:|
| ConvertTo-LatinTransliteration   | translit   |
| ConvertFrom-LatinTransliteration | untranslit |

## Usage

Convert from cyrillic to latin:

```powershell
/> translit -Text "фва" -Language Bulgarian
```

```powershell
/> ConvertTo-LatinTransliteration -Text "цукен" -Lng mk
```

```powershell
/> "текст" | ConvertTo-LatinTransliteration -Language Russian
```

```powershell
/> "купалiнка цемная ночка, дзеж твая дочка" | ConvertTo-LatinTransliteration -Language Belorussian
```

```powershell
/> "Поплакала і знов фіалка розцвіла Засяяв день таємними знаками " | ConvertTo-LatinTransliteration -Language Ukrainian
```


Convert from latin to cyrillic:


```powershell
/> untranslit -Text "fva" -Language Bulgarian
```

```powershell
/> ConvertFrom-LatinTransliteration -Text "czuke" -Lng mk
```

```powershell
/> "tekst" | ConvertFrom-LatinTransliteration -Language Russian
```

```powershell
/> "kastrychniczkaya" | ConvertFrom-LatinTransliteration -Language Belorussian
```

```powershell
/> "zakoxana" | ConvertFrom-LatinTransliteration -Language Ukrainian
```

## Changelog

### [v1.0.0] Apr 29, 2020

* Create module
* Replace some translitiration letters  


## Donate

The modules are created and actively maintained during evenings and weekends for my own needs.
If it's useful for you too, that's great. I don't demand anything in return.

However, if you like it and feel the urge to give something back,
a coffee or a beer is always appreciated. Thank you very much in advance.

[![Buy Me A Coffee](https://www.buymeacoffee.com/assets/img/custom_images/purple_img.png)](https://www.buymeacoffee.com/dima)
[![Support by Yandex](https://raw.githubusercontent.com/GitStatic/Resources/master/yaMoney.png)](https://money.yandex.ru/to/410014572567962/200)

<!--   By Paypal [![PayPal.me](https://img.shields.io/badge/PayPal-me-blue.svg?maxAge=2592000)](https://www.paypal.me/dima.by)
 -->

If you have any idea or suggestion - please add a github issue.

<!-- https://www.contributor-covenant.org/version/1/4/code-of-conduct -->
