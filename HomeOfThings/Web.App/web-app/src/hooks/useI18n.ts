import React from "react";
import { useTranslation } from "react-i18next";

export const useI18n = () =>{
    
    const {i18n, t} = useTranslation(["common"])
   

    const handleLanguageChanged = React.useCallback((lang: "en" | "de") =>{
        i18n.changeLanguage(lang)
    },[i18n])

    const getResource = React.useCallback((res: string) =>{
        const splitted = res.split(".")

        if(splitted?.length === 2){
            return t(splitted[1], { ns: splitted[0] })
        }

        
        return t(res)
    },[t])

    return{
        handleLanguageChanged,
        getResource
    }
}