import { useRef, forwardRef, KeyboardEvent } from "react"

export default function ForwordRef() {
    const inputsRefs = useRef<(HTMLInputElement | null)[]>([])

    const handleSubmit = (event: any) => {
        event.preventDefault()
        console.log(inputsRefs.current)
    }

    const handleKeyUp = (index: number) => (event: KeyboardEvent<HTMLInputElement>) => {
        if (event.key === 'Enter') {
            inputsRefs.current[index + 1]?.focus()
        }
    }

    return <form onSubmit={handleSubmit}>
        <Input ref={ref => inputsRefs.current!.push(ref)} onKeyUp={handleKeyUp(0)} label='name' />
        <Input ref={ref => inputsRefs.current!.push(ref)} onKeyUp={handleKeyUp(1)} label='age' />
        <Input ref={ref => inputsRefs.current!.push(ref)} onKeyUp={handleKeyUp(2)} label='phone' />
        <Input ref={ref => inputsRefs.current!.push(ref)} onKeyUp={handleKeyUp(3)} label='address' />
        <button>Submit</button>
    </form>
}

type Props = {
    label: string,
    onKeyUp: (e: KeyboardEvent<HTMLInputElement>) => void
}

const Input = forwardRef<HTMLInputElement, Props>((props, ref) => {
    return <>
        <label>{props.label}</label>
        <input ref={ref} onKeyUp={props.onKeyUp} />
    </>
})



// import { useRef, forwardRef } from "react"

// export default function ForwordRef() {
//     const inputRef = useRef<HTMLInputElement>(null)

//     const handleClick = () => {
//         inputRef.current?.focus()
//         inputRef.current?.select()
//     }

//     const handleSubmit = (event: any) => {
//         event.preventDefault()
//         console.log(inputRef.current?.value)
//     }

//     return <form onSubmit={handleSubmit}>
//         <Input ref={inputRef} label='name' />
//         <button type="button" onClick={handleClick}>Ref</button>
//         {/* הטייפ הדיפולטיבי של כפתור בתוך טופס, הוא סבמיט, כדי לבטל את ההתנהגות צריך לתת טייפ button */}
//         <button>Submit</button>
//     </form>
// }

// type Props = {
//     label: string
// }

// const Input = forwardRef<HTMLInputElement, Props>((props, ref) => {
//     return <>
//         <label>{props.label}</label>
//         <input ref={ref} />
//     </>
// })

/// מתי נשתמש ב REF
// כשרוצים שהערך ישמר בין רינדורים, ואין צורך לרינדור מחודש של הקומפוננטה בכל שינוי, הערך לא מוצג על המסך
// כשרוצים לבצע פעולות על אלמנט שריאקט לא מאפשרת
