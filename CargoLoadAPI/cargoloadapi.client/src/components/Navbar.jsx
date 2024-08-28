import React from "react";
import { Link } from "react-router-dom";

function Navbar() {
  return (
    <nav>
      <img src="/logo.jpg" alt="Logo" width="200" height="200" />
      <ul>
        <li>
          <Link to="/">Cargo Load Management</Link>
        </li>
        <li>
          <Link to="/export">Export Cargo Loads</Link>
        </li>
      </ul>
    </nav>
  );
}

export default Navbar;
