using Microsoft.EntityFrameworkCore;
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
    public partial class MainWindow : Window
    {
        private readonly WalletContext _context = new WalletContext();

        private CollectionViewSource walletViewSource;
        //private CollectionViewSource userWalletsViewSource;
        public MainWindow()
        {
            InitializeComponent();
            walletViewSource = (CollectionViewSource)FindResource(nameof(walletViewSource));
            //userWalletsViewSource = (CollectionViewSource)FindResource(nameof(userWalletsViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            _context.Database.EnsureCreated();
            _context.Wallets.Load();
            _context.Users.Load();
            walletViewSource.Source = _context.Users.Local.ToObservableCollection();
            //userWalletsViewSource.Source = _context.Users.Local.ToObservableCollection();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            _context.SaveChanges();
            walletsDataGrid.Items.Refresh();
            usersDataGrid.Items.Refresh();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            _context.Dispose();
            base.OnClosing(e);
        }
    }
}
