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
    /// <summary>
    /// Logika interakcji dla klasy Window4.xaml
    /// </summary>
    public partial class TransactionWindow : Window
    {
        private readonly WalletContext _context = new WalletContext();
        private CollectionViewSource categoryViewSource;
        public Transaction transaction = new Transaction();
        public Category category = new Category() { Name="zywnosc" };
        public Category category2 = new Category() { Name="podatki" };

        // TODO: get active wallet from other view
        // for now take the first wallet in db
        public Wallet? activeWallet; 
        
        public TransactionWindow()
        {
            InitializeComponent();
            this.DataContext = transaction;
            categoryViewSource = (CollectionViewSource)FindResource(nameof(categoryViewSource));
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            _context.Database.EnsureCreated();
            _context.Wallets.Load();
            _context.Transactions.Load();
            _context.Categories.Load();
            activeWallet = _context.Wallets.Find(1);
            categoryViewSource.Source = _context.Categories.Local.ToObservableCollection();
            Categories_Combobox.SelectedIndex = 0;
            //_context.Categories.Add(category);
            //_context.Categories.Add(category2);
            //_context.SaveChanges();
        }


        private void Button_Click(object sender, RoutedEventArgs e) {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) {

        }

        private void Delete_Transaction(object sender, RoutedEventArgs e) {

        }

        private void Add_Transaction(object sender, RoutedEventArgs e) {
            _context.Add(transaction);
            _context.SaveChanges();
            transaction = new Transaction();
        }

        private void Edit_Transacion(object sender, RoutedEventArgs e) {

        }

    }
}
