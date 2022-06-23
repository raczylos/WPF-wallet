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


      
        private readonly WalletContext _context = new WalletContext();


        Wallet wallet;
        public HistoryWindow(Wallet wallet) {

            InitializeComponent();
            this.wallet = wallet;

            _context.Database.EnsureCreated();
            _context.Wallets.Load();
            _context.Transactions.Load();
            _context.Categories.Load();


            transactionList.ItemsSource = _context.Transactions.Where(t => t.Wallet == wallet).ToList();


            List<String> list = new List<String>();
            list.Add("");

            foreach (Category category in _context.Categories.ToList())
            {

                list.Add(category.Name);

            }


            categoryComboBox.ItemsSource = list;

        }

        //public HistoryWindow() {
        //    InitializeComponent();

        //    _context.Database.EnsureCreated();
        //    _context.Wallets.Load();
        //    _context.Transactions.Load();
        //    _context.Categories.Load();


        //    //transactionList.ItemsSource = transations; 

        //    transactionList.ItemsSource = _context.Transactions.ToList();

        //    List<String> list = new List<String>();
        //    list.Add("");
        //    foreach (Transaction transaction in _context.Transactions) {
        //        //MessageBox.Show(transaction.Category.Name);
        //        string text5 = transaction.Category.Name;
        //        //MessageBox.Show(text5);
        //        list.Add(text5);


        //    }
        //    categoryComboBox.ItemsSource = list;

        //    //MessageBox.Show(_context.Transactions.ToList()[1].MoneyAmount.ToString());


        //    //_context.Remove(_context.Transactions.ToList()[0]);
        //    //_context.SaveChanges();

        //    //_context.Transactions.ToList();

        //}



  

        private bool MyFilter(object obj)
        {

            var filterObj = obj as Transaction;
            var text = categoryComboBox.SelectedItem.ToString();


            var selectedCategory = categoryComboBox.SelectedItem.ToString();
            var selectedPriceFrom = priceFrom.Text;
            var selectedPriceTo = priceTo.Text;
            bool? isIncoming = incomingButton.IsChecked;
            bool? isExpense = expenseButton.IsChecked;

            var searchBox = SearchTextBox.Text;

            if (selectedCategory == "" && selectedPriceFrom == "" && selectedPriceTo == "" && isIncoming == false && isExpense == false && searchBox == "")
            {
                return true;
            }

            if (selectedPriceFrom == "")
            {
                selectedPriceFrom = "0";
            }

            if (selectedPriceTo == "")
            {
                selectedPriceTo = Int32.MaxValue.ToString();
            }

            if (filterObj.Category.Name.Contains(selectedCategory) && (filterObj.MoneyAmount > Convert.ToInt32(selectedPriceFrom)) && (filterObj.MoneyAmount < Convert.ToInt32(selectedPriceTo)) && filterObj.Title.Contains(searchBox)) 
            {
                if (filterObj.isOutgoing.Equals(!isExpense) && filterObj.isIncoming.Equals(!isIncoming))
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }


            return false;
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
            //_context.Transactions.Load();
            using(var context = new WalletContext()) {
                transactionList.ItemsSource = context.Transactions.Where(t => t.Wallet == wallet).ToList();
                //transactionList.Items.Refresh();
            }
        }
        private void incomingButton_Checked(object sender, RoutedEventArgs e)
        {
            expenseButton.IsChecked = false;
            transactionList.Items.Filter = MyFilter;
        }

        private void expenseButton_Checked(object sender, RoutedEventArgs e)
        {
            incomingButton.IsChecked = false;
            transactionList.Items.Filter = MyFilter;
        }

        private void incomingButton_Unchecked(object sender, RoutedEventArgs e)
        {
            transactionList.Items.Filter = MyFilter;
        }

        private void expenseButton_Unchecked(object sender, RoutedEventArgs e)
        {
            transactionList.Items.Filter = MyFilter;
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        { 
             
                PrintDialog printDialog = new PrintDialog();
                if(printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(transactionList, "test");
                }
           

        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            transactionList.Items.Filter = MyFilter;
        }
    }
}
