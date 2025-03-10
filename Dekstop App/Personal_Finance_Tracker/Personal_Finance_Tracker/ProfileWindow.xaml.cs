using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class ProfileWindow : Window
    {
        public UserProfile User { get; set; }

        public ProfileWindow()
        {
            InitializeComponent();
            User = new UserProfile { Name = "John Doe", Email = "john@example.com" }; 
            DataContext = User;
        }

        private void EditProfile_Click(object sender, RoutedEventArgs e)
        {
            var editProfileWindow = new EditProfileWindow(User);
            editProfileWindow.ShowDialog();
            DataContext = null;
            DataContext = User; 
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
            var expensesWindow = new ExpensesWindow();
            expensesWindow.Show();
            this.Close();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }

    }

    public class UserProfile : INotifyPropertyChanged
    {
        private string? _name;
        private string? _email;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Email
        {
            get =>  _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
