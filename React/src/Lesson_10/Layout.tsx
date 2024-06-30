import { Children } from 'react'

export default function Main() {

    return <>
        <Comp1 />
        <Comp2 />
    </>
}

export function Layout(props: any) {
    console.log(props)
    Children.count(props.children)
    Children.forEach(props.children, (child, index) => {

    })

    return <>
        <h1>Hello</h1>
        {props.children}
        <button>Click</button>
    </>
}


export function Comp1(props: any) {


    return <>
        <Layout>
            <label>Comp1</label>
        </Layout>
    </>
}



export function Comp2() {


    return <>
        <Layout>
            <section>Comp2</section>
        </Layout>
    </>
}


