import React from 'react';
import { PieChart, Pie, Cell, ResponsiveContainer, Legend, Tooltip } from 'recharts';
import { useFinance } from '../Context/FinanceContext';
import './Dashboard.css';

const Dashboard = () => {
  const { incomes, expenses, totalIncome, totalExpenses, balance, deleteTransaction } = useFinance();

  const data = [
    { name: 'Income', value: totalIncome },
    { name: 'Expenses', value: totalExpenses },
  ];

  const COLORS = ['#27c400', '#b81919'];

  const recentTransactions = [...incomes, ...expenses]
    .sort((a, b) => new Date(b.date) - new Date(a.date))
    .slice(0, 5);

  const handleDelete = (id, type) => {
    deleteTransaction(id, type);
  };

  return (
    <div className="dashboard">
      <h2>Financial Overview</h2>
      <div className="financial-summary">
        <div className="summary-item">
          <h3>Current Balance</h3>
          <p className={balance >= 0 ? 'positive' : 'negative'}>${balance.toFixed(2)}</p>
        </div>
        <div className="summary-item">
          <h3>Total Income</h3>
          <p className="positive">${totalIncome.toFixed(2)}</p>
        </div>
        <div className="summary-item">
          <h3>Total Expenses</h3>
          <p className="negative">${totalExpenses.toFixed(2)}</p>
        </div>
      </div>
      <div className="chart-container">
        <h3>Income vs Expenses</h3>
        <ResponsiveContainer width="100%" height={300}>
          <PieChart>
            <Pie
              data={data}
              cx="50%"
              cy="50%"
              labelLine={false}
              outerRadius={80}
              fill="#8884d8"
              dataKey="value"
              label={({ name, percent }) => `${name} ${(percent * 100).toFixed(0)}%`}
            >
              {data.map((entry, index) => (
                <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
              ))}
            </Pie>
            <Tooltip />
            <Legend />
          </PieChart>
        </ResponsiveContainer>
      </div>
      <div className="transactions">
        <h3>Recent Transactions</h3>
        <ul>
          {recentTransactions.map((transaction) => (
            <li key={transaction.id} className={transaction.source ? 'income' : 'expense'}>
              <span className="transaction-date">{transaction.date}</span>
              <span className="transaction-description">{transaction.source || transaction.description}</span>
              <span className="transaction-amount">${transaction.amount.toFixed(2)}</span>
              <button 
                className="delete-btn" 
                onClick={() => handleDelete(transaction.id, transaction.source ? 'income' : 'expense')}
              >
                Delete
              </button>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default Dashboard;

