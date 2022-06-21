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
        User user = new User() { Name="Username", Password="Password" };
        public RegisterWindow()
        {
            this.DataContext = user;
            InitializeComponent();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e) {
            using(WalletContext _context = new WalletContext()) {
                _context.Database.EnsureCreated();
                if(User_Password.Password == User_Password_Repeat.Password) {
                    user.Password = User_Password.Password;
                }
                _context.Users.Add(user);
                _context.SaveChanges();
                SelectWallet selectWalletWindow = new SelectWallet();
                selectWalletWindow.DataContext = user;
                selectWalletWindow.ShowDialog();
            }

        }
    }
}
