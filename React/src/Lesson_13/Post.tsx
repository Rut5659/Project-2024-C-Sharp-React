import { useLoaderData, useParams } from "react-router-dom"

export default function Post() {
    const params = useParams()
    const data: any = useLoaderData()

    console.log(params)
    console.log(data)

    return <div>Post
        <h1>{data.id} </h1>
        <h1>{data.title} </h1>
        <h1>{data.body} </h1>
        <h1>{data.userId} </h1>
    </div>
}