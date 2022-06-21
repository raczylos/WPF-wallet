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
        public Transaction transaction = new Transaction() { isIncoming = true, isCycle = false };
        //public Category category = new Category() { Name="zywnosc" };
        //public Category category2 = new Category() { Name="podatki" };
        private bool isEditing = false;

        // TODO: get active wallet from other view
        // for now take the first wallet in db
        public Wallet? activeWallet; 

        public TransactionWindow(Wallet wallet) {
            activeWallet = wallet;
            _context.Entry(wallet).State = EntityState.Detached;
            InitializeComponent();
            refreshTransaction();
            this.DataContext = transaction;
            categoryViewSource = (CollectionViewSource)FindResource(nameof(categoryViewSource));
        }
        
        public TransactionWindow()
        {
            InitializeComponent();
            refreshTransaction();
            this.DataContext = transaction;
            categoryViewSource = (CollectionViewSource)FindResource(nameof(categoryViewSource));
            TransactionCRUDlist.ItemsSource = _context.Transactions.Local.ToObservableCollection();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            _context.Database.EnsureCreated();
            //_context.Wallets.Load();
            _context.Transactions.Load();
            _context.Categories.Load();
            //_context.Wallets.Attach(activeWallet);

            //activeWallet = _context.Wallets.Find(1);
            categoryViewSource.Source = _context.Categories.Local.ToObservableCollection();
            Categories_Combobox.SelectedIndex = 0;
            TransactionCRUDlist.ItemsSource = _context.Transactions.Where(t => t.Wallet == activeWallet).ToList();

            //_context.Categories.Add(category);
            //_context.Categories.Add(category2);
            //_context.SaveChanges();
        }

        private void Delete_Transaction(object sender, RoutedEventArgs e)
        {
            var selectedId = TransactionCRUDlist.SelectedIndex;
            _context.Remove(_context.Transactions.ToList()[selectedId]);
            _context.SaveChanges();
            TransactionCRUDlist.ItemsSource = _context.Transactions.Local.ToObservableCollection();
        }

        private void Add_Transaction(object sender, RoutedEventArgs e) {
            using (WalletContext context = new WalletContext()) {
                //context.Database.EnsureCreated();
                //context.Wallets.Attach(activeWallet);
                ////context.Categories.Attach(transaction.Category);
                //if (transaction.isCycle == true) {
                //    transaction.date = DateTime.Now;
                //}
                //if (!isEditing) {
                //    context.Add(transaction);
                //}
                //context.SaveChanges();
                //refreshTransaction();
                //this.DataContext = transaction;
                //TransactionCRUDlist.ItemsSource = context.Transactions.Where(t => t.Wallet == activeWallet).ToList();
                //TransactionCRUDlist.Items.Refresh();
                //if (isEditing) {
                //    isEditing = false;
                //}
            }
            _context.Database.EnsureCreated();
            _context.Categories.Attach(transaction.Category);
            _context.Wallets.Attach(activeWallet);
            if (transaction.isCycle == true) {
                transaction.date = DateTime.Now;
            }
            if (!isEditing) {
                _context.Add(transaction);
            }
            _context.SaveChanges();
            refreshTransaction();
            this.DataContext = transaction;
            TransactionCRUDlist.ItemsSource = _context.Transactions.Where(t => t.Wallet == activeWallet).ToList();
            TransactionCRUDlist.Items.Refresh();
            if (isEditing) {
                isEditing = false;
            }

            //TransactionCRUDlist.ItemsSource = _context.Transactions.ToList();
        }

        private void Edit_Transaction(object sender, RoutedEventArgs e) {
            isEditing = true;
            var selectedId = TransactionCRUDlist.SelectedIndex;
            transaction = _context.Transactions.ToList()[selectedId];
            this.DataContext = transaction;
        }

        private void refreshTransaction() {
            transaction = new Transaction() { isIncoming = true, isCycle = false, Wallet = activeWallet };
        }

        private void Category_Add_Click(object sender, RoutedEventArgs e) {
            using (WalletContext context = new WalletContext()) { 
                Category category = new Category() { Name=Category_Name.Text };
                context.Categories.Add(category);
                context.SaveChanges();
                Categories_Combobox.Items.Refresh();
            }
        }
    }
}
