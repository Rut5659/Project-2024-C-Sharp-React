import { useLanguageContext } from "./useLanguageContext";

function Language() {
    const { language, setLanguage } = useLanguageContext()

    const translate = {
        he: 'שלום',
        en: 'hello'
    }

    return (
        <>
            <h1>{translate[language]}</h1>
            <button onClick={setLanguage}>{`Change to ${language === 'en' ? 'Hebrow' : 'English'}`} </button>
        </>
    );
}

export default Language;
