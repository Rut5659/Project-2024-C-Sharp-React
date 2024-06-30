import { useState, ChangeEvent, useRef, RefObject } from "react"


export default function Inputs() {

    const [data, setData] = useState({
        firstName: '',
        lastName: '',
        age: 0,
        phone: 0,
        radio: 1
    })
    // const [value, setValue] = useState('')

    const inputRef = useRef<any>()

    // const onChangeHandler = (event: ChangeEvent<HTMLInputElement>, name: string) => {
    //     setData({ ...data, [name]: event.target.value })
    // }

    const onChangeHandler1 = (event: ChangeEvent<HTMLInputElement>) => {
        const { value, name } = event.target
        setData({ ...data, [name]: value })
    }

    // const onChangeHandler2 = (name: string) => (event: ChangeEvent<HTMLInputElement>) => {
    //     setData({ ...data, [name]: event.target.value })
    // }

    const handleSubmit = (event: any) => {
        event.preventDefault();
        // api call
    }

    return <form onSubmit={handleSubmit}>
        {/* // controlled component */}
        <input value={data.firstName} onChange={onChangeHandler1} name='firstName' />
        {/* <input value={data.firstName} onChange={onChangeHandler2('firstName')} name='firstName' /> */}
        {/* <input value={data.firstName} onChange={(event) => onChangeHandler(event, 'firstName')} name='firstName' /> */}
        <input value={data.lastName} onChange={onChangeHandler1} name='lastName' />
        <input value={data.age} type='number' onChange={onChangeHandler1} name='age' />
        <input value={data.phone} type='tel' onChange={onChangeHandler1} name='phone' />

        {/* unControlled */}
        <input ref={inputRef} name='name' />
        <button>Submit</button>
    </form>
}
   // const onClickHandler = () => {
    //     console.log(inputRef.current.value)
    //     inputRef.current.value = ''
    //     inputRef.current.focus()
    // }