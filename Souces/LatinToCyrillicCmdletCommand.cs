﻿using System;
 using System.Management.Automation;
 using NickBuhro.Translit;

namespace TranslitModule
{
    [Cmdlet(VerbsData.ConvertFrom, "LatinTransliteration",
        ConfirmImpact = ConfirmImpact.Low,
        DefaultParameterSetName = "System", SupportsShouldProcess = true)]
    [OutputType(typeof(string))]
    public class LatinToCyrillicCmdletCommand : Cmdlet
    {
        protected Language Lang = NickBuhro.Translit.Language.Unknown;
        protected ParameterSet ParameterSetName;
        private string _langString;
        private string _text;
        private string _lng = "uk";

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = "System")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = "Specific")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SpecificTrim")]
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                ParameterSetName = ParameterSet.SpecificTrim;
            }
        }


        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "Specific")]
        [ValidateSet("Russian", "Belorussian", "Ukrainian", "Bulgarian", "Macedonian")]
        public string Language
        {
            get => _langString;
            set
            {
                _langString = value;
                ParameterSetName = ParameterSet.Specific;
            }
        }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "SpecificTrim")]
        [ValidateSet("ru", "by", "uk", "bg", "mk")]
        public string Lng
        {
            get => _lng;
            set
            {
                _lng = value;
                ParameterSetName = ParameterSet.SpecificTrim;
            }
        }

        protected override void BeginProcessing()
        {
            WriteVerbose("Starting processing text Transliteration.");
            var lang = new SystemLanguageProvider();

            switch (ParameterSetName)
            {
                case ParameterSet.System:
                    Lang = lang.GetLanguageFromLocale();
                    break;
                case ParameterSet.Specific:
                case ParameterSet.SpecificTrim:
                    lang.TryParseLanguage(Lng,out Lang);
                    break;   
            }

            if (Lang == NickBuhro.Translit.Language.Unknown)
            {
                WriteVerbose($"Locale is not set, using system locale.");
                Lang = lang.GetLanguageFromLocale();
            }
            
            WriteVerbose($"Using for Transliteration {Lang} language.");

        }
    
        protected override void ProcessRecord()
        {
            var translit=Transliteration.LatinToCyrillic(Text, Lang);
            
            WriteObject(ChangeMisspell(translit));
        }

        protected string ChangeMisspell(string text)
        {
            switch (Lang)
            {
                case NickBuhro.Translit.Language.Unknown:
                    break;
                case NickBuhro.Translit.Language.Russian:
                    text = text.Replace('h','г');
                    break;
                case NickBuhro.Translit.Language.Belorussian:
                    break;
                case NickBuhro.Translit.Language.Ukrainian:
                    break;
                case NickBuhro.Translit.Language.Bulgarian:
                    break;
                case NickBuhro.Translit.Language.Macedonian:
                    break;
            }

            return text;
        }

        protected override void EndProcessing()
        {
            WriteVerbose("Finished processing text Transliteration");
        }
    }
    
}
