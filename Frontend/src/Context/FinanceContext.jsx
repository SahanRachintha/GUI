import React, { createContext, useState, useContext } from 'react';

const FinanceContext = createContext();

export const useFinance = () => useContext(FinanceContext);

export const FinanceProvider = ({ children }) => {
  const [incomes, setIncomes] = useState([
    { id: 1, source: 'Salary', amount: 5000, date: '2023-05-01' },
    { id: 2, source: 'Freelance', amount: 1000, date: '2023-05-15' },
  ]);

  const [expenses, setExpenses] = useState([
    { id: 1, description: 'Rent', amount: 1500, date: '2023-05-01', category: 'Housing' },
    { id: 2, description: 'Groceries', amount: 200, date: '2023-05-05', category: 'Food' },
  ]);

  const [userProfile, setUserProfile] = useState({
    name: '',
    email: '',
    password: ''
  });

  const addIncome = (income) => {
    setIncomes([...incomes, { ...income, id: Date.now() }]);
  };

  const addExpense = (expense) => {
    setExpenses([...expenses, { ...expense, id: Date.now() }]);
  };

  const deleteTransaction = (id, type) => {
    if (type === 'income') {
      setIncomes(incomes.filter(income => income.id !== id));
    } else {
      setExpenses(expenses.filter(expense => expense.id !== id));
    }
  };

  const updateUserProfile = (newProfile) => {
    setUserProfile({ ...userProfile, ...newProfile });
  };

  const totalIncome = incomes.reduce((sum, income) => sum + income.amount, 0);
  const totalExpenses = expenses.reduce((sum, expense) => sum + expense.amount, 0);
  const balance = totalIncome - totalExpenses;

  return (
    <FinanceContext.Provider 
      value={{ 
        incomes, 
        expenses, 
        addIncome, 
        addExpense, 
        deleteTransaction,
        totalIncome, 
        totalExpenses, 
        balance,
        userProfile,
        updateUserProfile
      }}
    >
      {children}
    </FinanceContext.Provider>
  );
};

