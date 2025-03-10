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
using MySql.Data.MySqlClient;

namespace Personal_Finance_Tracker
{
    public partial class IncomeWindow : Window
    {
        private string connectionString = "server=localhost;database=personalfinancedb;user=root;password=gr717rmn;";

        public IncomeWindow()
        {
            InitializeComponent();
            LoadIncomeData();
            IncomeList.ItemsSource = FinanceData.IncomeEntries;
        }

        private void LoadIncomeData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT date, source, amount FROM income";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    FinanceData.IncomeEntries.Clear();
                    while (reader.Read())
                    {
                        FinanceData.IncomeEntries.Add(new IncomeEntry
                        {
                            Date = reader.GetDateTime("date").ToShortDateString(),
                            Source = reader.GetString("source"),
                            Amount = $"${reader.GetDecimal("amount"):0.00}"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddIncome_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IncomeSourceTextBox.Text) ||
                string.IsNullOrWhiteSpace(IncomeAmountTextBox.Text) ||
                IncomeDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!decimal.TryParse(IncomeAmountTextBox.Text, out decimal amount))
            {
                MessageBox.Show("Invalid amount.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO income (date, source, amount) VALUES (@date, @source, @amount)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@date", IncomeDatePicker.SelectedDate.Value);
                    cmd.Parameters.AddWithValue("@source", IncomeSourceTextBox.Text);
                    cmd.Parameters.AddWithValue("@amount", amount);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Income added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadIncomeData();

                        IncomeSourceTextBox.Clear();
                        IncomeAmountTextBox.Clear();
                        IncomeDatePicker.SelectedDate = null;
                    }
                    else
                    {
                        MessageBox.Show("Failed to add income.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteIncome_Click(object sender, RoutedEventArgs e)
        {
            if (IncomeList.SelectedItem is IncomeEntry selectedIncome)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM income WHERE date = @date AND source = @source AND amount = @amount LIMIT 1";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@date", DateTime.Parse(selectedIncome.Date).ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@source", selectedIncome.Source);
                        cmd.Parameters.AddWithValue("@amount", decimal.Parse(selectedIncome.Amount.Replace("$", "")));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Income deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            LoadIncomeData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete income.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an income entry to delete.");
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
            
        }

        private void Expenses_Click(object sender, RoutedEventArgs e)
        {
            var expensesWindow = new ExpensesWindow();
            expensesWindow.Show();
            this.Close();  
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
    }

    public class IncomeEntry
    {
        public string? Date { get; set; }
        public string? Source { get; set; }
        public string? Amount { get; set; }
    }
}