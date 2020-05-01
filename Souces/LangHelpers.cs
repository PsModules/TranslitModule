using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using NickBuhro.Translit;

namespace TranslitModule
{

    public class SystemLanguageProvider
    {
        private static Dictionary<string,Language> _cultureInfoMapping = new Dictionary<string, Language>()
        {
            { "ru-ru", NickBuhro.Translit.Language.Russian},
            { "be-by", NickBuhro.Translit.Language.Belorussian},
            { "uk-ua", NickBuhro.Translit.Language.Ukrainian},
            { "bg-bg", NickBuhro.Translit.Language.Bulgarian},
            { "mk-mk", NickBuhro.Translit.Language.Macedonian},
        };
        
        public static bool TryParseLanguage(CultureInfo culture, out Language lang)
        {
            var locale = culture.Name.ToLower();

            if (Enum.TryParse(locale, out lang))
                return true;
            
            if (_cultureInfoMapping.TryGetValue(locale, out lang))
                return true;

            return false;
        }
        
        public bool TryParseLanguage(string langString, out Language lang)
        {
            langString = langString.ToLower();
            if (Enum.TryParse(langString, out lang))
                return true;
            
            if (_cultureInfoMapping.TryGetValue(langString, out lang))
                return true;

            foreach (var language in _cultureInfoMapping)
            {

                var found= language.Key
                    .Split('-')
                    .Any(s => s.Contains(langString));

                if (found)
                {
                    lang = language.Value;
                    return true;
                }
                
            }
            return false;
        }
        
        public Language GetLanguageFromLocale()
        {     
            Language lang;

            var culture = Thread.CurrentThread.CurrentUICulture;
            if (TryParseLanguage(culture, out lang))
                return lang; 

            culture = Thread.CurrentThread.CurrentCulture;
            if (TryParseLanguage(culture, out lang))
                return lang; 
            
            culture = CultureInfo.CurrentCulture;
            if (TryParseLanguage(culture, out lang))
                return lang; 
            
            culture = CultureInfo.CurrentUICulture;
            if (TryParseLanguage(culture, out lang))
                return lang;

            culture = CultureInfo.InstalledUICulture;
            if (TryParseLanguage(culture, out lang))
                return lang;

            return NickBuhro.Translit.Language.Unknown;
        }
    }
}