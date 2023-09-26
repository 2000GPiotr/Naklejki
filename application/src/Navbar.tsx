import { Link } from 'react-router-dom';

const Navbar = () => {
  return (
    <nav>
      <ul>
        <li>
          <Link to="/">Strona główna</Link>
        </li>
        <li>
          <Link to="/Users">Users</Link>
        </li>
        <li>
          <Link to="/Documents">Documents</Link>
        </li>
        <li>
          <Link to="/Registry">Registry</Link>
        </li>
        <li>
          <Link to="/RaportsScreen">Raports</Link>
        </li>
        <li>
          <Link to="/LoginScreen">Login</Link>
        </li>
        <li>
          <Link to="/Test">test</Link>
        </li>
      </ul>
    </nav>
  );
}

export default Navbar;