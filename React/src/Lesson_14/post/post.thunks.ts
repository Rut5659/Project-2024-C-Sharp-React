import { PostType } from "./post.slice";
import { addPost as addPostApi } from '../../Lesson_12/services/post.service'
import { AppThunk } from "../store";
import { addPost as addPostAction } from './post.slice'

export const addPost = (post: PostType): AppThunk<PostType> => async (dispatch, getState) => {
    const state = getState()// אם רוצים לקבל מידע מהרידקס כדי לשלוח לקריאת שרת
    const newPost = await addPostApi(post)
    dispatch(addPostAction(newPost))
    return newPost
}