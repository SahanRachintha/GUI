import React from 'react';
import { Link } from 'react-router-dom';
import './Home.css';

const Home = () => {
  return (
    <div className="home">
      <h1>Welcome to Personal Finance Tracker</h1>
      <h3>Blance Your Books,Balance your Life</h3>
      <p>Manage your money easily with our with our easy to use tracking tools.<br/>
        our tool helps you stay on top of your finances. Get a clear overview of your <br/>spending habits, set budgets, and make informed decisions to grow your wealth</p>
      <div className="auth-buttons">
        <Link to="/login" className="btn btn-primary">Login</Link>
        <Link to="/signup" className="btn btn-secondary">Sign Up</Link>
      </div>
    </div>
  );
};

export default Home;

