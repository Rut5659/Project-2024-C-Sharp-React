import { useState } from "react";
import Board from "./Board";
import './style.css'
import { SquareValueType } from "./game.types";

export default function Game() {
    const [squareArr, setSquareArr] = useState<SquareValueType[]>(Array(9).fill(null))
    const [currentPlayer, setCurrentPlayer] = useState<SquareValueType>(Math.round(Math.random()) ? 'X' : 'O')
    const isWin = isWinner(squareArr)

    function move(index: number) {
        if (isWin) {
            return;
        }
        const newSquares = [...squareArr]
        newSquares[index] = currentPlayer
        setSquareArr(newSquares)
        setCurrentPlayer(getNextPlayer(currentPlayer))
    }

    return <>
        {isWin ? `The winner is ${getNextPlayer(currentPlayer)}` : `Current player ${currentPlayer}`}
        <Board squares={squareArr} move={move} />
    </>
}

function isWinner(squares: SquareValueType[]) {
    const lines = [[0, 1, 2], [3, 4, 5], [6, 7, 8], [0, 4, 8], [2, 4, 6], [0, 3, 6], [1, 4, 7], [2, 5, 8]]
    for (let index = 0; index < lines.length; index++) {
        const line = lines[index];
        const [a, b, c] = line
        if (squares[a] === squares[b] && squares[a] === squares[c] && squares[a] !== null) {
            return true
        }
    }
    return false
}

function getNextPlayer(currentPlayer: SquareValueType) {
    return currentPlayer === 'X' ? 'O' : 'X'
}