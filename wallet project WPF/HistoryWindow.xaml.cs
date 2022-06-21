using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace wallet_project_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        Wallet wallet;
        public HistoryWindow(Wallet wallet) {
            InitializeComponent();
            this.wallet = wallet;

            _context.Database.EnsureCreated();
            _context.Wallets.Load();
            _context.Transactions.Load();
            _context.Categories.Load();


            //transactionList.ItemsSource = transations; 

            transactionList.ItemsSource = _context.Transactions.ToList();

            List<String> list = new List<String>();
            list.Add("");
            foreach (Transaction transaction in _context.Transactions) {
                //MessageBox.Show(transaction.Category.Name);
                string text5 = transaction.Category.Name;
                //MessageBox.Show(text5);
                list.Add(text5);

            }
            categoryComboBox.ItemsSource = list;
        }

        //Transation[] transations = new Transation[]
        //{
        //    new Transation("test1", 100, "kredyt"),
        //    new Transation("test2", 200, "produkty spozywcze")
        //};

        private readonly WalletContext _context = new WalletContext();

        //private readonly Transaction transaction = new Transaction();

        public HistoryWindow() {
            InitializeComponent();

            _context.Database.EnsureCreated();
            _context.Wallets.Load();
            _context.Transactions.Load();
            _context.Categories.Load();


            //transactionList.ItemsSource = transations; 

            transactionList.ItemsSource = _context.Transactions.ToList();

            List<String> list = new List<String>();
            list.Add("");
            foreach (Transaction transaction in _context.Transactions) {
                //MessageBox.Show(transaction.Category.Name);
                string text5 = transaction.Category.Name;
                //MessageBox.Show(text5);
                list.Add(text5);


            }
            categoryComboBox.ItemsSource = list;

            //MessageBox.Show(_context.Transactions.ToList()[1].MoneyAmount.ToString());


            //_context.Remove(_context.Transactions.ToList()[0]);
            //_context.SaveChanges();

            //_context.Transactions.ToList();

        }






        private bool MyFilter(object obj)
        {

            var filterObj = obj as Transaction;
            var text = categoryComboBox.SelectedItem.ToString();


            var selectedCategory = categoryComboBox.SelectedItem.ToString();
            var selectedPriceFrom = priceFrom.Text;
            var selectedPriceTo = priceTo.Text;

            //return filterObj.category.Contains(categoryComboBox.Text);
            

            if (selectedCategory == "" && selectedPriceFrom == "" && selectedPriceTo == "")
            {
                return true;
            }

            if (selectedPriceFrom == "")
            {
                selectedPriceFrom = "0";
            }

            if (selectedPriceTo == "")
            {
                selectedPriceTo = "2147483647";
            }


            if (filterObj.Category.Name.Contains(selectedCategory) && (filterObj.MoneyAmount > Convert.ToInt32(selectedPriceFrom)) && (filterObj.MoneyAmount < Convert.ToInt32(selectedPriceTo)))
            {
                return true;
            }



            return false;
        }

        private bool TransactionFilter(object item)
        {

            return true;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CategoriesChanged(object sender, SelectionChangedEventArgs e)
        {

            transactionList.Items.Filter = MyFilter;
            //categoryComboBox.ItemsSource



        }

        private void priceFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            transactionList.Items.Filter = MyFilter;
        }

        private void priceTo_TextChanged(object sender, TextChangedEventArgs e)
        {
            transactionList.Items.Filter = MyFilter;
        }

        private void Change_Window_Transaction_Click(object sender, RoutedEventArgs e) {
            TransactionWindow transactionWindow = new TransactionWindow(wallet);
            transactionWindow.ShowDialog();
        }
    }
}
