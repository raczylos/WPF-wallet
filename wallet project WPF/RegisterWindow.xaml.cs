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
    /// Logika interakcji dla klasy RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        User user = new User();
        public RegisterWindow()
        {
            this.DataContext = user;
            InitializeComponent();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            using (WalletContext _context = new WalletContext())
            {
                _context.Database.EnsureCreated();
               
                if (!_context.Users.Any(u => u.Name == User_Name.Text) && User_Password.Password == User_Password_Repeat.Password && User_Name.Text.Length > 0 && User_Password.Password.Length >= 6)
                {
                    user.Password = User_Password.Password;
                    user.Name = User_Name.Text;
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.Show();
                    this.Close();

                }
                else if (_context.Users.Any(u => u.Name == User_Name.Text))
                {
                    MessageBox.Show("UserName already taken", "UserName error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if(User_Name.Text.Length == 0)
                {
                    MessageBox.Show("Username to short", "UserName error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if(User_Password.Password != User_Password_Repeat.Password)
                {
                    MessageBox.Show("Passwords do not match", "Password error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if(User_Password.Password.Length < 6 || User_Password_Repeat.Password.Length < 6)
                {
                    MessageBox.Show("Password lenght must be at least 6 ", "Password error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                //_context.Users.Add(user);
                //_context.SaveChanges();
                //SelectWallet selectWalletWindow = new SelectWallet(user);
                //selectWalletWindow.DataContext = user;
                //selectWalletWindow.ShowDialog();
            }

        }
    }
}
