import { Link } from 'react-router-dom';

const Navbar = () => {
  return (
    <nav>
      <ul>
        <li>
          <Link to="/">Strona główna</Link>
        </li>
        <li>
          <Link to="/UserManagementScreen">Users</Link>
        </li>
        <li>
          <Link to="/LabelManagementScreen">Label</Link>
        </li>
        <li>
          <Link to="/RaportsScreen">Raports</Link>
        </li>
        <li>
          <Link to="/LoginScreen">Login</Link>
        </li>
      </ul>
    </nav>
  );
}

export default Navbar;