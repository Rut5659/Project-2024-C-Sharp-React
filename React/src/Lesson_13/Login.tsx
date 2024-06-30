import { useNavigate } from "react-router-dom"

export default function Login() {
    const navigate = useNavigate()

    const login = () => {
        if (true) {// אם למשתמש יש הרשאות
            navigate('/home')
        }
    }

    return <div>
        <button onClick={login}>login</button>
    </div>
}