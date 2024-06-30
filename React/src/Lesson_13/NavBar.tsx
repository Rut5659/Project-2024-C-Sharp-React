import { NavLink } from 'react-router-dom';
import './style.css';

export default function NavBar() {
  return (
    <nav>
      <NavLink to=''>Home</NavLink>
      <NavLink to='about'>About</NavLink>
      <NavLink to='products'>Products</NavLink>
      {/* <NavLink to='/home/post/1'>Post_1</NavLink> */}
    </nav>
  );
}
