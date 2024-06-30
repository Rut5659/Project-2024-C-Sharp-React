import { useState } from 'react';

export default function State() {
    const [position, setPosition] = useState({
        x: 0,
        y: 0
    });

    const [firstName, setFirstName] = useState('')
    const [lastName, setLastName] = useState('')
    const fullName = firstName + lastName
    const [products, setProducts] = useState([
        {
            id: 1,
            name: 'milk',
            price: 5
        },
        {
            id: 2,
            name: 'sugar',
            price: 5
        },
    ])
    const [selectedItemIndex, setSelectedItemIndex] = useState<number>(0)

    // const { x, y, ...rest } = position

    const onClickHandler = () => {
        // setPosition({ x: 2, y: 3 })
        // setPosition({ ...position, y: 3 })
        // setFirstName('dsssss')
        // setSelectedItemIndex(1)
        const newP = { x: 10, y: 20 }

        console.log(newP)
        setPosition(newP)
    };

    return (
        <div>
            {/* {products[selectedItemIndex]?.name}
            {products[selectedItemIndex]?.id} */}
            <h1>{position.x}</h1>
            <h1>{position.y}</h1>
            <button onClick={onClickHandler}>Click Me</button>
        </div>
    );
}
