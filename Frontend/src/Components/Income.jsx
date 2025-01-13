import React, { useState } from 'react';
import { useFinance } from '../Context/FinanceContext';
import './Income.css';

const Income = () => {
  const { incomes, addIncome } = useFinance();
  const [newIncome, setNewIncome] = useState({ source: '', amount: '', date: '' });

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setNewIncome({ ...newIncome, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    addIncome({
      source: newIncome.source,
      amount: parseFloat(newIncome.amount),
      date: newIncome.date,
    });
    setNewIncome({ source: '', amount: '', date: '' });
  };

  return (
    <div className="income">
      <h2>Income</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <input
            type="text"
            name="source"
            placeholder="Income Source"
            value={newIncome.source}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="form-group">
          <input
            type="number"
            name="amount"
            placeholder="Amount"
            value={newIncome.amount}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="form-group">
          <input
            type="date"
            name="date"
            value={newIncome.date}
            onChange={handleInputChange}
            required
          />
        </div>
        <button type="submit" className="add-btn">Add Income</button>
      </form>
      <table>
        <thead>
          <tr>
            <th>Date</th>
            <th>Source</th>
            <th>Amount</th>
          </tr>
        </thead>
        <tbody>
          {incomes.map((income) => (
            <tr key={income.id}>
              <td>{income.date}</td>
              <td>{income.source}</td>
              <td>${income.amount.toFixed(2)}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Income;

