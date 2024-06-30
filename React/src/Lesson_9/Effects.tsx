import { useEffect, useState } from "react"

const getDataFromDB = async () => {
    return ['A', 'B', 'C']
}

export default function Effects() {
    const [data, setData] = useState<string[] | undefined>()
    const [name, setName] = useState<string>('')

    console.log('---------------- render -------------------')

    // אחרי כל רינדור
    useEffect(() => {
        console.log('after every render')

        return () => {
            console.log('return after every render')
        }
    })

    // רק אחרי הרינדור הראשוני
    // useEffect(() => {
    //     console.log('after first render')
    //     // A
    //     async function getData() {
    //         try {
    //             const dbData = await getDataFromDB()
    //             setData(dbData)
    //             // const dbData1 = await getDataFromDB()
    //             // setData(dbData1)
    //         } catch (error) {
    //             console.log(error)
    //         }
    //     }
    //     getData()

    //     // B
    //     // getDataFromDB().then((dbData) => {
    //     //     setData(dbData)
    //     //     getDataFromDB().then(async () => {
    //     //         try {
    //     //             await getDataFromDB()
    //     //         } catch (error) {

    //     //         }
    //     //     }).catch(err => {

    //     //     })
    //     // }).catch(err => {
    //     //     console.log(err)
    //     // })

    //     // פונקצית ניקוי unmount
    //     return () => {
    //         console.log('return after first render')
    //     }
    // },
    //     [])

    // רק אחרי רינדור שהשתנה בו המשתנה name
    useEffect(
        // מה לבצע
        () => {
            console.log('after render when name changed')

            return () => {
                console.log('return after render when name changed')
            }
        },
        // מתי לבצע
        [name])

    useEffect(() => {
        console.log('after render when name changed')

        return () => {
            console.log('return after render when name changed')
        }
    },
        // מתי לבצע
        [name])


    return <>
        hello
        {data?.map((item, index) => (
            <div key={index}>{item}</div>
        ))}
        <button onClick={() => setName('aaaaaaaaaa')}>change name</button>
    </>
}



// כללים של hooks
//  או בתוך customHook אפשר להשתמש בהם רק בתוך קומפוננטה מסוג פונקציה ולא מחלקה
// חייבים לקרוא להם רק בתוך הגוף של הפונקציה, ולא בתוך מטפל אירוע וכו'
// א"א להתנות את הקריאה שלהם


// פונקציה טהורה
// לא משנה את הקלט שלה
// עבור אותו קלט תחזיר אותה תוצאה (לא תלויה בערכים חיצוניים)


// let z = 0

// function calc(x: number, y: number) {

//     return x * y * Math.random()
// }


// מתי תזומן פונקצית return  useEffect
// כשהקומפוננטה יורדת מהמסך
// לפני הרצה של useEffect חדש