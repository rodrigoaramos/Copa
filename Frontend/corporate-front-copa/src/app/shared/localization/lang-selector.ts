import { environment } from './../../../environments/environment';
import { Localization } from './por-br-messages';

export const LanguageSelector: any = {

  getActiveLanguage(): any {
    let messages = {};
    const language = environment.localization.language;
    switch (language)
    {
      case 'por-br':
        messages = Localization.messages;
        break;
      default:
        messages = Localization.messages;
        break;
    }
    return messages;
  }
};
