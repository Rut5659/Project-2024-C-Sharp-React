import { NavLink } from "react-router-dom";
import { PATHS } from "../../routes/paths";

export default function NavBar() {

    return <nav>
        <NavLink to={PATHS.home}>Home</NavLink>
    </nav>
}