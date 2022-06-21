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
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class SelectWallet : Window
    {
        User user;
        public SelectWallet(User user)
        {
            this.user = user;
            InitializeComponent();
            using (WalletContext _context = new WalletContext())
            {
                List<Wallet> wallets = _context.Wallets.Where(wallet => wallet.UserOwner == user).ToList();
                Wallet_List.ItemsSource = wallets;
            }
        }

        private void Remove_Selected_Button_Click(object sender, RoutedEventArgs e)
        {
            Wallet toRemove = Wallet_List.SelectedItem as Wallet;
            if (toRemove != null)
            {


                using (WalletContext _context = new WalletContext())
                {
                    _context.Wallets.Remove(toRemove);
                    _context.SaveChanges();
                    List<Wallet> wallets = _context.Wallets.Where(wallet => wallet.UserOwner == user).ToList();
                    Wallet_List.ItemsSource = wallets;
                    
                }
            }
        }
        private void Edit_Wallet_Button_Click(object sender, RoutedEventArgs e)
        {
            Wallet toEdit = Wallet_List.SelectedItem as Wallet;
            EditWalletWindow editWalletWindow = new EditWalletWindow(toEdit);
            editWalletWindow.ShowDialog();
            using (WalletContext _context = new WalletContext())
            {
                List<Wallet> wallets = _context.Wallets.Where(wallet => wallet.UserOwner == user).ToList();
                Wallet_List.ItemsSource = wallets;
            }

        }
      
        private void Confirm_Wallet_Button_Click(object sender, RoutedEventArgs e)
        {
            Wallet selected = Wallet_List.SelectedItem as Wallet;
            HistoryWindow historyWindow = new HistoryWindow(selected);
            historyWindow.Show();
            this.Close();
        }
        private void Add_Wallet_Button_Click(object sender, RoutedEventArgs e)
        {
            AddWalletWindow addWalletWindow = new AddWalletWindow(user);
            addWalletWindow.ShowDialog();
            using (WalletContext _context = new WalletContext())
            {
                List<Wallet> wallets = _context.Wallets.Where(wallet => wallet.UserOwner == user).ToList();
                Wallet_List.ItemsSource = wallets;
            }

        }


    }
}
