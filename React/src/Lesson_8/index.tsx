import { useState } from "react";
import Effects from './Effects'

export default function ShowEffects() {
    const [show, setShow] = useState<boolean>(false)

    return <>
        <button onClick={() => setShow(show)!} >Show Effect</button>
        {show && <Effects />}
        {/* {show ? <Effects /> : null} */}
    </>
}