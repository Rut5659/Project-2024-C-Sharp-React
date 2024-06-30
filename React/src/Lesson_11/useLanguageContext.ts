import { useContext } from "react";
import { LanguageContext } from "./LanguageProvider";

// custom hook
export function useLanguageContext() {
    const context = useContext(LanguageContext)

    if (context === null) {
        throw new Error('useLanguageContext must be used inside LanguageProvider')
    }

    return context

}