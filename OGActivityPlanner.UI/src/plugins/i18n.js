import { createI18n } from 'vue-i18n';
import de from '@/locales/de.json';

const messages = { de };

const browserLanguage = navigator.language.split('-')[0];
const locale = Object.keys(messages).includes(browserLanguage) ? browserLanguage : 'de';

const i18n = createI18n({
  locale: locale,
  fallbackLocale: 'de',
  messages,
});

export default i18n;
