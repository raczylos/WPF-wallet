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

namespace wallet_project_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        User user = new User();
        public LoginWindow()
        {
            this.DataContext = user;
            InitializeComponent();
        }

        private void Go_To_Register_Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void Handle_Login_Button_Click(object sender, RoutedEventArgs e)
        {
            using (WalletContext _context = new WalletContext())
            {
                _context.Database.EnsureCreated();
                User user = _context.Users.FirstOrDefault(user => user.Name == User_Name.Text);
                if (user == null)
                {
                    MessageBox.Show("userName not registered  ", "UserName error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (User_password.Password != user.Password)
                {
                    MessageBox.Show("Wrong Password  ", "Password error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Login succesful", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                    SelectWallet selectWallet = new SelectWallet(user);
                    selectWallet.Show();
                    this.Close();
                }


            }

        }
    }

}

