import { ChangeEvent, KeyboardEvent, useState } from "react"

export default function Lists() {

    const [products, setProducts] = useState<string[]>([])
    const [value, setValue] = useState('')

    const addProduct = (event: KeyboardEvent<HTMLInputElement>)=>{
             if(event.key === 'Enter'){
                // setProducts(products.concat(value))
                setProducts([...products, value])
                setValue('')
             }
      
    }

    const onChange = (event:ChangeEvent<HTMLInputElement>)=>{
        setValue(event.target.value)
    }

    const deleteProducts = (product:string)=>{
        // const productIndex = products.indexOf(product)
        // const newArr = [...products]
        // newArr.splice(productIndex, 1)
        setProducts(products.filter(p => p !== product))

        // דרכים לעשות העתקה עמוקה למערך
        // const newArr = [...products]
        // const newArr = products.slice()
        // const newArr = products.map(p=> p)
        // const newArr = products.filter(p=> true)
        // const newArr = product.concat()
    }

    const shuffle = () => {
        setProducts([...products].sort(()=> Math.random() -0.5 ))
    }

    return <div>
        {/* <input onChange={(e) => setValue(e.target.value)} value={value} onKeyUp={addProduct}/> */}
        <input onChange={onChange} value={value} onKeyUp={addProduct}/>
        {products.map((product) => (
        <div key={product}>  
            <input type="checkbox" />
            {product} 
            <button onClick={()=> deleteProducts(product)}>×</button>
        </div>
        ))}
        <button onClick={shuffle}>Shuffle</button>
        </div>
  }












  
//   const colorList = ['red', 'blue', 'green', 'black']

        // const colorsElement: any = []
    
        // colorList.forEach(color => {
        //     colorsElement.push(<li>{color}<button style={{ color }}>delete</button></li>)
        // })
    
        // const colorElements = colorList.map(color => (
        //     <li>{color}<button style={{ color }}>delete</button></li>
        // ))


        // פונקציות שלא נשתמש בהם
        // push, splice

        // פונקציות שכן נשתמש בהם
        // concat, map, [...], slice