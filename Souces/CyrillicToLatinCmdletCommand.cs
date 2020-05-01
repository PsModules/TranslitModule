﻿using System;
 using System.Management.Automation;
 using NickBuhro.Translit;

namespace TranslitModule
{
    
    [Cmdlet(VerbsData.ConvertTo, "LatinTransliteration", ConfirmImpact = ConfirmImpact.Low, 
        DefaultParameterSetName = "System", SupportsShouldProcess = true)]
    [OutputType(typeof(string))]
    public class CyrillicToLatinCmdletCommand : Cmdlet
    {
        protected Language Lang = NickBuhro.Translit.Language.Unknown;
        protected ParameterSet ParameterSetName;
        private string _langString;
        private string _text;
        private string _lng = "uk";
        
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "System")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "Specific")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "SpecificTrim")]
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

            if ( Lang == NickBuhro.Translit.Language.Unknown)
                Lang = lang.GetLanguageFromLocale();
            
            WriteVerbose($"Using for Transliteration {Lang} language.");
        }
        
        protected string ChangeMisspell(string text)
        {
            switch (Lang)
            {
                case NickBuhro.Translit.Language.Unknown:
                    break;
                case NickBuhro.Translit.Language.Russian:
                    break;
                case NickBuhro.Translit.Language.Belorussian:
                    text = text.Replace('ы','y');
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
        
        
        protected override void ProcessRecord()
        {
            var  translit=Transliteration.CyrillicToLatin(Text, Lang);
            WriteObject(translit);
        }
        
        protected override void EndProcessing()
        {
            WriteVerbose("Finished processing text Transliteration");
        }
    }
    
}
