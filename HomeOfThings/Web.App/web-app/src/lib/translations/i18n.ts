import i18next from 'i18next';
import { initReactI18next } from 'react-i18next';

// EN
import administration_en from './en/administration_en.json';
import common_en from './en/common_en.json';
import budget_en from './en/budget_en.json';
// DE
import administration_de from './de/administration_de.json';
import common_de from './de/common_de.json';
import budget_de from './de/budget_de.json';

const resources = {
  en: {
    common: common_en,
    budget: budget_en,
    administration: administration_en,
  },
  de: {
    common: common_de,
    budget: budget_de,
    administration: administration_de,
  },
};

i18next.use(initReactI18next).init({
  resources,
  lng: 'de',
  fallbackLng: 'en',
});

export default i18next;
