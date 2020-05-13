export const LOCALES = {
    english: "en",
    french: "fr"
  };
  
export const getLocaleCode = (langCode) => {
    switch(langCode) 
    {
        case 'en': 
            return LOCALES.english;

        case 'fr': 
            return LOCALES.french;
        
        default: 
            return LOCALES.english;
    }
}
  