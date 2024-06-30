import { ReactNode, createContext, useState } from "react";
import { LanguageContextType, LanguageType } from "./types";

export const LanguageContext = createContext<LanguageContextType | null>(null)

type Props = {
    children: ReactNode
}
// שמירת מידע גלובלי לפריקט כדי למנוע גלילת נתונים
export default function LanguageProvider({ children }: Props) {
    const [language, setLanguage] = useState<LanguageType>('he')

    const toggleLanguage = () => {
        setLanguage(language === 'en' ? 'he' : 'en')
    }

    return <LanguageContext.Provider value={{ language, setLanguage: toggleLanguage }}>
        {children}
    </LanguageContext.Provider>

}