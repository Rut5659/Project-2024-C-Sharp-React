import { getUsers as getUsersApi, login } from './Lesson_12/services/user.service'
import axios from './Lesson_12/axios'
export default function Api() {
    const getUsers = async () => {
        try {
            const users = await getUsersApi()
            console.log(users)
        } catch (error) {
            console.log(error)
        }
    }

    const handleLogin = async () => {
        try {
            const token = await login('name', 'password')
            localStorage.setItem('token', token)
            axios.defaults.headers['Authorization'] = `Bearer Token ${token}`
        } catch (error) {
            console.log(error)
        }
    }



    return (
        <>
            <button onClick={getUsers}>Get Users</button>
            <button onClick={handleLogin}>Login</button>
        </>
    )
}