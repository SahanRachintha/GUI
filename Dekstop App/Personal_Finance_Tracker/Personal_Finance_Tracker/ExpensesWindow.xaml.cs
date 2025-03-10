using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Personal_Finance_Tracker
{
    public partial class ExpensesWindow : Window
    {
        public ExpensesWindow()
        {
            InitializeComponent();
            ExpensesListView.ItemsSource = FinanceData.Expenses;
        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text) ||
                string.IsNullOrWhiteSpace(AmountTextBox.Text) ||
                string.IsNullOrWhiteSpace(CategoryTextBox.Text) ||
                !DatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!decimal.TryParse(AmountTextBox.Text, out decimal amount))
            {
                MessageBox.Show("Invalid amount.");
                return;
            }

            FinanceData.Expenses.Add(new Expense
            {
                Date = DatePicker.SelectedDate.Value.ToString("yyyy-MM-dd"),
                Description = DescriptionTextBox.Text,
                Amount = $"${amount:0.00}",
                Category = CategoryTextBox.Text
            });

            DescriptionTextBox.Clear();
            AmountTextBox.Clear();
            CategoryTextBox.Clear();
            DatePicker.SelectedDate = null;
        }

        private void DeleteExpense_Click(object sender, RoutedEventArgs e)
        {
            if (ExpensesListView.SelectedItem is Expense selectedExpense)
            {
                FinanceData.Expenses.Remove(selectedExpense);
            }
            else
            {
                MessageBox.Show("Please select an expense to delete.");
            }
        }

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            var dashboardWindow = new DashboardWindow();
            dashboardWindow.Show();
            this.Close();
        }

        private void Income_Click(object sender, RoutedEventArgs e)
        {
            var incomeWindow = new IncomeWindow();
            incomeWindow.Show();
            this.Close();
        }
        private void Expenses_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            var profileWindow = new ProfileWindow();
            profileWindow.Show();
            this.Close();
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }

        private void DescriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }


    public class Expense
    {
        public string? Date { get; set; }
        public string? Description { get; set; }
        public string? Amount { get; set; }
        public string? Category { get; set; }
    }
}
