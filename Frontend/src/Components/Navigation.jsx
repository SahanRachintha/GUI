import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import './Navigation.css';
import logo from '/public/logo.png';

const Navigation = () => {
  const navigate = useNavigate();

  const handleLogout = () => {
   
    navigate('/');
  };

  return (
    <nav className="navigation">
      <div className="nav-left">
      <img src="/logo.png"  alt="Logo" className="logo" />
        <h1>Personal Finance Tracker</h1>
      </div>
      <ul className="nav-center">
        <li><Link to="/dashboard">Dashboard</Link></li>
        <li><Link to="/income">Income</Link></li>
        <li><Link to="/expenses">Expenses</Link></li>
      </ul>
      <div className="nav-right">
        <Link to="/profile" className="profile-link">Profile</Link>
        <button onClick={handleLogout} className="logout-btn">Logout</button>
      </div>
    </nav>
  );
};

export default Navigation;

