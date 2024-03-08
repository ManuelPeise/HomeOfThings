import i18next from 'i18next'
import {initReactI18next} from 'react-i18next'


// EN
import common_en from './en/common_en.json'
import budget_en from "./en/budget_en.json"
// DE
import common_de from './de/common_de.json'
import budget_de from "./de/budget_de.json"

const resources = {
    en:{
        common: common_en,
        budget: budget_en
    },
    de:{
        common: common_de,
        budget: budget_de
    }
}

i18next.use(initReactI18next).init({
    resources,
    lng: "de",
    fallbackLng: 'en',
})

export default i18next