import { PostType } from "../../Lesson_14/post/post.slice"
import axios from "../axios"

export const getPostById = async (id: number) => {
    const response = await axios.get(`/posts/${id}`)
    return response.data
}

export const addPost = async (post: PostType) => {
    const response = await axios.post<PostType>('/posts', post)
    const newPost = response.data
    return newPost
}
