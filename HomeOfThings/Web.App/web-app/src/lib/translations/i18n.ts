import i18next from 'i18next'
import {initReactI18next} from 'react-i18next'


// EN
import common_en from './en/common_en.json'

// DE
import common_de from './de/common_de.json'

const resources = {
    en:{
        common: common_en
    },
    de:{
        common: common_de
    }
}

i18next.use(initReactI18next).init({
    resources,
    lng: "de",
    fallbackLng: 'en',
})

export default i18next