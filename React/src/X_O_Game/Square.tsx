import { SquareValueType } from "./game.types"

type Props = {
    value: SquareValueType;
    onClick: VoidFunction
}

export default function Square({ value, onClick }: Props) {

    return <div className="square" onClick={onClick}>{value}</div>
}