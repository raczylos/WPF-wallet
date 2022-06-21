using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy EditWalletWindow.xaml
    /// </summary>
    public partial class EditWalletWindow : Window
    {
        Wallet wallet;
        public EditWalletWindow(Wallet wallet)
        {
            InitializeComponent();
            this.wallet = wallet;
            Wallet_Name.Text = wallet.WalletName;
            Wallet_Balance.Text = wallet.Balance.ToString();
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

                if (Wallet_Name.Text.Length == 0)
                {
                    MessageBox.Show("Enter Wallet name", "Wallet Name error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (Wallet_Balance.Text == "0" || Wallet_Balance.Text.Length == 0)
                    {
                        wallet.Balance = 0;
                        wallet.WalletName = Wallet_Name.Text;
                        _context.Wallets.Update(wallet);
                        _context.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        wallet.Balance = int.Parse(Wallet_Balance.Text);
                        wallet.WalletName = Wallet_Name.Text;
                        _context.Wallets.Update(wallet);
                        _context.SaveChanges();
                        this.Close();
                    }
                }
            }
        }


    }
}
