using System;
using System.Collections.Generic;
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
using LiveCharts;
using LiveCharts.Wpf;



namespace Personal_Finance_Tracker
{
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
            UpdateFinancialOverview();
            LoadPieChart();
        }

        private void UpdateFinancialOverview()
        {
            TotalIncomeTextBlock.Text = $"Total Income: ${FinanceData.GetTotalIncome():0.00}";
            TotalExpensesTextBlock.Text = $"Total Expenses: ${FinanceData.GetTotalExpenses():0.00}";
            CurrentBalanceTextBlock.Text = $"Current Balance: ${FinanceData.GetCurrentBalance():0.00}";
        }

        private void LoadPieChart()
        {
            decimal income = FinanceData.GetTotalIncome();
            decimal expenses = FinanceData.GetTotalExpenses();

            FinancePieChart.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Income",
                    Values = new ChartValues<double> { (double)income },
                    Fill = System.Windows.Media.Brushes.Green
                },
                new PieSeries
                {
                    Title = "Expenses",
                    Values = new ChartValues<double> { (double)expenses },
                    Fill = System.Windows.Media.Brushes.Red
                }
            };
        }

        private void Dashboard_Click(object sender, RoutedEventArgs e) { }

        private void Income_Click(object sender, RoutedEventArgs e)
        {
            var incomeWindow = new IncomeWindow();
            incomeWindow.Show();
            this.Close();
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
}
