import axios from "../axios"

export const login = async (userName: string, password: string) => {
    const response = await axios.get(`/User/Login/${userName}/${password}`)
    return response.data
}
