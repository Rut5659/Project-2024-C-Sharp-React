import axios from '../axios'
import { Todo } from "../types/todo.types"

export const getTodos = async () => {
    const response = await fetch('https://jsonplaceholder.typicode.com/todos')
    // לקריאת get & delete אין body
    // const response = await fetch('https://jsonplaceholder.typicode.com/todos', { method: 'POST', body: JSON.stringify({}) })
    const todos = await response.json()
    return todos
}

export const addTodo = async (todo: Omit<Todo, 'id'>) => {
    const response = await axios.post('/todos', todo)
    const newTodo = response.data
    return newTodo
}

export const updateTodo = async (todo: Todo) => {
    const response = await axios.put(`/todos/${todo.id}`, todo)
    const updatedTodo = response.data
    return updatedTodo
}

export const deleteTodo = async (id: number) => {
    const response = await axios.delete(`/todos/${id}`)
    return response
}

