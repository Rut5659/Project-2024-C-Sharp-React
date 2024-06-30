import { KeyboardEvent, ChangeEvent, useState } from "react";
import { selectPost } from "./post/post.selectors";
import { addPost } from "./post/post.thunks";
import { useAppDispatch, useAppSelector } from "./store";

export default function Post() {
    const [value, setValue] = useState('')
    const post = useAppSelector(selectPost)
    const dispatch = useAppDispatch()

    const addPostHandler = async (event: KeyboardEvent<HTMLInputElement>) => {
        if (event.key === 'Enter') {
            // await addPostApi({})
            // dispatch(addPost({ id: +value }))
            const newPost = await dispatch(addPost({ id: +value }))
            setValue('')
        }
    }

    const onChange = (event: ChangeEvent<HTMLInputElement>) => {
        setValue(event.target.value)
    }

    return (<>
        <input onChange={onChange} value={value} onKeyUp={addPostHandler} />
        {post.map((p, i) => <h1 key={i}>{p.id}</h1>)}
    </>
    );
}

// useSelector
// מקבלת פונקציית CB
// שולחת לה את כל הסטייט מהפרוביידר של רידקס,
// הפונקציה תחזיר את המידע המבוקש מהסטייט  שנשלח

// useDispatch
// זורק פעולה מסוימת לעדכון הסטור