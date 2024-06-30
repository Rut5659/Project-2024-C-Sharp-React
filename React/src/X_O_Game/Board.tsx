import Square from "./Square"
import { SquareValueType } from "./game.types"


type Props = {
    squares: SquareValueType[];
    move: (index: number) => void
}

export default function Board({ squares, move }: Props) {


    return <div className="board">
        {squares.map((square, index) => (
            <Square value={square} onClick={() => move(index)} />
        ))}</div>
}