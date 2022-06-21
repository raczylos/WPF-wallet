using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy AddWalletWindow.xaml
    /// </summary>
    public partial class AddWalletWindow : Window
    {
        User user;
        public AddWalletWindow(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            
        }

        private void Close_Window_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            using (WalletContext _context = new WalletContext())
            {
                _context.Database.EnsureCreated();

                if(Wallet_Name.Text.Length == 0)
                {
                    MessageBox.Show("Enter Wallet name", "Wallet Name error", MessageBoxButton.OK, MessageBoxImage.Error);
                }              
                else
                {
                    if(Wallet_Balance.Text == "0" || Wallet_Balance.Text.Length == 0)
                    {
                        Wallet wallet = new Wallet() { Balance = 0,  WalletName = Wallet_Name.Text, UserOwnerId = user.UserId };
                        _context.Wallets.Add(wallet);
                        _context.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        Wallet wallet = new Wallet() { Balance = int.Parse(Wallet_Balance.Text),  WalletName = Wallet_Name.Text, UserOwnerId = user.UserId };
                        _context.Wallets.Add(wallet);
                        _context.SaveChanges();
                        this.Close();
                    }
                }
            }
        }
    }
}
