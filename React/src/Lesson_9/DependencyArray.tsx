import { useCallback, useEffect, useState } from "react"

export default function DependencyArray() {
    const [counter, setCounter] = useState(0);
    const [name, setName] = useState('');

    //  - כל עוד לא השתנה לי מערץ התלות שומר על מצביע של פונקציה בין רינדורים
    const increaseCounter = useCallback(() => {
        setCounter(counter + 1)
    }, [counter])

    useEffect(() => {
        const interval = setInterval(() => {
            increaseCounter()
        }, 1000)

        return () => {
            clearInterval(interval)
        }
    }, [increaseCounter])


    return <>
        <h3>{counter}</h3>
        {/* <Closure /> */}
        <button onClick={() => increaseCounter()}>Click</button>
    </>
}


type Product = { id: number, name: string }

export function Closure() {


    const products = [
        { id: 1, name: 'milk' },
        { id: 2, name: 'bread' }
    ]

    function getNameFromId(id: number) {
        return (items: Product[]) => {
            return items.find(p => p.id === id)?.name
        }
    }

    const getMilk = getNameFromId(1)
    const milk = getMilk(products)
    console.log(milk)

    const getBread = getNameFromId(2)
    const bread = getBread(products)
    console.log(bread)
    console.log(getMilk(products))

    return <></>
}


