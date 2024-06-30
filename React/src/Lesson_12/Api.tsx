import { useState } from 'react'
import { Todo } from './types/todo.types'
import { getTodos as getTodosApi, addTodo as addTodosApi, updateTodo as updateTodoApi, deleteTodo as deleteTodoApi, } from './services/todo.service'
import { getUsers as getUsersApi, } from './services/user.service'

export default function Api() {
    const [todos, setTodos] = useState<Todo[]>([])

    const getTodos = async () => {
        try {
            const todos = await getTodosApi()
            setTodos(todos)
        } catch (error) {
            console.log(error)
        }
    }

    const getUsers = async () => {
        try {
            const users = await getUsersApi()
            console.log(users)
        } catch (error) {
            console.log(error)
        }
    }

    const addTodo = async () => {
        try {
            const newTodo = await addTodosApi({
                title: 'new Todo',
                userId: 1,
                completed: false,
            })
            setTodos([newTodo, ...todos])
        } catch (error) {
            console.log(error)
        }
    }

    const updateTodo = async () => {
        try {
            const todoToUpdate = { ...todos[0] }
            todoToUpdate.title = 'updated todo'
            const updatedTodo = await updateTodoApi(todoToUpdate)
            const newTodo = [...todos]
            newTodo[0] = updatedTodo
            setTodos(newTodo)
        } catch (error) {
            console.log(error)
        }
    }

    const deleteTodo = async () => {
        try {
            const deleteItemId = 1
            await deleteTodoApi(deleteItemId)
            setTodos(todos.filter(todo => todo.id !== deleteItemId))
        } catch (error) {
            console.log(error)
        }
    }

    return (
        <>
            <button onClick={getUsers}>Get Users</button>
            <button onClick={getTodos}>Get Todos</button>
            <button onClick={addTodo}>Add Todo</button>
            <button onClick={updateTodo}>Update Todo</button>
            <button onClick={deleteTodo}>Delete Todo</button>
            {todos.map(todo => (
                <div key={todo.id}>
                    {todo.id}
                    {todo.title}
                    {todo.userId}
                    {todo.completed ? '✔' : 'X'}
                </div>
            ))}
        </>
    )
}