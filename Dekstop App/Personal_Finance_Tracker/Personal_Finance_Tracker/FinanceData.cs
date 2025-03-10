using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace Personal_Finance_Tracker
{
    public static class FinanceData
    {
        public static ObservableCollection<IncomeEntry> IncomeEntries { get; set; } = new ObservableCollection<IncomeEntry>();
        public static ObservableCollection<Expense> Expenses { get; set; } = new ObservableCollection<Expense>();

        public static decimal GetTotalIncome()
        {
            decimal totalIncome = 0;
            foreach (var income in IncomeEntries)
            {
                if (decimal.TryParse(income.Amount.Replace("$", ""), out decimal amount))
                {
                    totalIncome += amount;
                }
            }
            return totalIncome;
        }

        public static decimal GetTotalExpenses()
        {
            decimal totalExpenses = 0;
            foreach (var expense in Expenses)
            {
                if (decimal.TryParse(expense.Amount.Replace("$", ""), out decimal amount))
                {
                    totalExpenses += amount;
                }
            }
            return totalExpenses;
        }

        public static decimal GetCurrentBalance()
        {
            return GetTotalIncome() - GetTotalExpenses();
        }
    }
}

