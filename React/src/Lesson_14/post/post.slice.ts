import { PayloadAction, createSlice } from '@reduxjs/toolkit'

export type PostType = {
    id: number
}

const postSlice = createSlice({
    name: 'post',
    initialState: [] as PostType[],
    reducers: {
        addPost: (state: PostType[], action: PayloadAction<PostType>) => {
            state.push(action.payload)
        },
        deletePost: (state: PostType[], action: PayloadAction<number>) => {
            // state = state.filter(p => p.id !== action.payload)
            return state.filter(p => p.id !== action.payload)
        },
        setPost:(state: PostType[], action: PayloadAction<PostType[]>) => {
            state=action.payload
        }
        
    }
})

export const { addPost } = postSlice.actions

export default postSlice.reducer