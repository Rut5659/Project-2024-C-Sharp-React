import { Outlet } from "react-router-dom";
import NavBar from "./NavBar";

export default function Layout() {

    return <>
        <header><NavBar /></header>
        <main><Outlet /></main>
        <footer>&copy; React Course</footer>
    </>
}

// Outlet - מציג את האלמנט של התת ניתוב